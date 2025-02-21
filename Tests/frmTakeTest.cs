using DVLD_Business;
using My_DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD.Screens_People
{
    public partial class frmTakeTest : Form
    {
        private clsTestAppointments _testAppointment = new clsTestAppointments();
        private clsLocalDrivingLicenseApplications _LDLApp = new clsLocalDrivingLicenseApplications();
        private clsApplication _app = new clsApplication();

        private enum _enTestTypeIDs
        { 
        vision=1,
        written=2,
        street=3
        }

        _enTestTypeIDs enTestType;

        public frmTakeTest(int testAppointmentID)
        {
            InitializeComponent();

            _testAppointment = clsTestAppointments.getTestAppointment(testAppointmentID);
            _LDLApp = clsLocalDrivingLicenseApplications.getLocalAppInfo(_testAppointment.LDLAppID);
            _app=_app.loadApplication(_LDLApp.appID);
            enTestType = (_enTestTypeIDs) _testAppointment.testTypeID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _populateTestCard();
        }

        private void _populateTestCard()
        { 
            lblDLAppID.Text=_testAppointment.LDLAppID.ToString();
            lblLicenseClass.Text = clsBusinessInfo.getLicenseClassName(_LDLApp.licenseClassID);
            lblApplicantName.Text=_app.person.fullName;
            lblTrialCount.Text = clsTest.getTrialCount(_testAppointment.LDLAppID, 1).ToString();
            lblApptDate.Text=_testAppointment.appointmentDate.ToShortDateString();
            lblTestFees.Text = clsTestTypes.getTestTypeFees(_testAppointment.testTypeID).ToString();

            if (_testAppointment.isLocked == false)
            {
                lblTestID.Text = "Not taken yet";
            }
            else
            { 
            //clsTest finishedTest = clsTest.getTestRecord()
            }

            if (enTestType == _enTestTypeIDs.vision)
            { 
                pictureBox1.Image=Resources.eyeTest;
                gbTakeTest.Text = "Take Vision Test";
            }
            if (enTestType == _enTestTypeIDs.written)
            {
                pictureBox1.Image = Resources.writtenTest;
                gbTakeTest.Text = "Take Written Test";
            }
            if (enTestType == _enTestTypeIDs.street)
            {
                pictureBox1.Image = Resources.streetTest;
                gbTakeTest.Text = "Take Street Test";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         DialogResult result = MessageBox.Show("Are you sure? Pass/Fail results can not be changed later!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                bool isPassed;
                int insertedTestID = -1;

                if (rbPass.Checked)
                {
                    isPassed = true;
                    //update isLocked in TestAppointments table to true
                    _testAppointment.updateIsLockedState();

                }
                else
                {
                    isPassed = false;
                    _testAppointment.updateIsLockedState();
                }
                //updateLastStatusDate in Applications table
                _app.updateLastStatusDate();

                clsTest newTest = new clsTest(_testAppointment.testAppID,
                    isPassed, lblTestNotes.Text,
                    clsGlobalSettings.currentlyLoggedInUser.userID);

                insertedTestID = newTest.takeTest();


                if (insertedTestID > 0)
                {
                    clsMisc.showDataSaveSuccessMsg();
                }
                else
                { 
                clsMisc.showDataSaveFailMsg();
                }
                this.Close();
            }
        }
    }
}
