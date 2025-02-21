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
using My_DVLD.Screens_People.formModes;



namespace My_DVLD.Screens_People
{

    public partial class frmScheduleTest : Form
    {
        private clsLocalDrivingLicenseApplications _localApp;
        private clsApplication _app = new clsApplication();
        private clsTestAppointments _testAppointment = new clsTestAppointments();
        
        private enum _testTypesID
        {
            Vision = 1,
            Written = 2,
            Street = 3
        }

        frmMode currentFormMode = new frmMode();

        _testTypesID testTypeIDs = new _testTypesID();

        public frmScheduleTest(int LDLAppID,int testAppID)
        {
            //for UPDATE appointment date
            InitializeComponent();

            _localApp = clsLocalDrivingLicenseApplications.getLocalAppInfo(LDLAppID);
            _app = _app.loadApplication(_localApp.appID);
            _testAppointment = clsTestAppointments.getTestAppointment(testAppID);

            currentFormMode = frmMode.UpdateAppointmentDate;
        }
        //for ADD new appointment
        public frmScheduleTest(int LDLAppID, frmMode frmOpen,int testAppID=-1)
        {
            InitializeComponent();
            _localApp = clsLocalDrivingLicenseApplications.getLocalAppInfo(LDLAppID);
            _app = _app.loadApplication(_localApp.appID);

            if (testAppID != null && testAppID >= 1)
            {
                _testAppointment = clsTestAppointments.getTestAppointment(testAppID);
            }

            if (frmOpen == frmMode.AddNewVisionAppointment)
            {
                currentFormMode = frmMode.AddNewVisionAppointment;
                testTypeIDs = _testTypesID.Vision;
            }
            if (frmOpen == frmMode.AddNewWrittenAppointment)
            {
                currentFormMode = frmMode.AddNewWrittenAppointment;
                testTypeIDs = _testTypesID.Written;
            }
            if (frmOpen == frmMode.AddNewStreetAppointment)
            {
                currentFormMode = frmMode.AddNewStreetAppointment;
                testTypeIDs = _testTypesID.Street;

            }
            if (frmOpen == frmMode.RetakeTest)
            {
                currentFormMode=frmMode.RetakeTest;
            }
        }

        private void _disableForm()
        { 
            btnSave.Enabled = false;
        }

        private void _populateBasicInfo()
        {
            lblDLAppID.Text = _localApp.localDrivLicID.ToString();
            lblLicenseClass.Text = clsBusinessInfo.getLicenseClassName(_localApp.licenseClassID);
            lblTrialCount.Text = "0";
            lblApplicantName.Text = _app.person.fullName;
            if(_testAppointment.testTypeID<1)
                lblFees.Text = clsTestTypes.getTestTypeFees((int)currentFormMode).ToString();
            else
                lblFees.Text= clsTestTypes.getTestTypeFees((int)_testAppointment.testTypeID).ToString();
            lblTrialCount.Text = clsTest.getTrialCount(_testAppointment.LDLAppID,
                _testAppointment.testTypeID).ToString();
        }

        private void _populateTestCard()
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            _populateBasicInfo();

            if (currentFormMode == frmMode.UpdateAppointmentDate)
            {

                dateTimePicker1.MinDate = _testAppointment.appointmentDate;
                dateTimePicker1.Text=_testAppointment.appointmentDate.ToShortDateString();

                lblFormTitle.Text = "Update Test Date";
            }

            if (currentFormMode == frmMode.RetakeTest)
            {
                lblFormTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;

                lblRetakeFees.Text=clsAppType.getAppTypeFees(7).ToString();
                lblTotalRetakeFees.Text=((Convert.ToDecimal( lblFees.Text)) + 
                    (Convert.ToDecimal(lblRetakeFees.Text))).ToString();
                lblRetakeAppID.Text = "N/A";
            }

            if (testTypeIDs == _testTypesID.Vision)
            {
                pictureBox1.Image = Resources.eyeTest;
                gbVisionTest.Text = "Vision Test";
            }
            if (testTypeIDs == _testTypesID.Written)
            {
                pictureBox1.Image = Resources.writtenTest;
                gbVisionTest.Text = "Written Test";
            }
            if (testTypeIDs == _testTypesID.Street)
            {
                pictureBox1.Image = Resources.streetTest;
                gbVisionTest.Text = "Street Test";
            }
        }

        private void _populateRetakeTestCard()
        { 
            lblRetakeFees.Text = "0";
        }

        //private void _disableEditAndTakeTest

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if(_testAppointment.testTypeID>=1)
                testTypeIDs = (_testTypesID) _testAppointment.testTypeID;

            gbRetakeTestInfo.Enabled = false;
            pictureBox1.Image = Resources.eyeTest;
           _populateTestCard();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentFormMode == frmMode.UpdateAppointmentDate)
            {
                clsTestAppointments updatedTestAppointment =
                    new clsTestAppointments(_testAppointment.testAppID,
                    _testAppointment.testTypeID, _testAppointment.LDLAppID,
                    dateTimePicker1.Value, _testAppointment.paidFees,
                    _testAppointment.createdByUserID, _testAppointment.isLocked);

                if (updatedTestAppointment.Update())
                    clsMisc.showDataSaveSuccessMsg();
                else
                    clsMisc.showDataSaveFailMsg();

                _disableForm();
            }
            if (currentFormMode == frmMode.RetakeTest)
            {
                //,make new constructor that takes retakeTestAppID
                clsTestAppointments retakeTest = new clsTestAppointments(_testAppointment.testTypeID,
                    _testAppointment.LDLAppID, dateTimePicker1.Value,
                    Convert.ToDecimal(lblTotalRetakeFees.Text),
                    _testAppointment.createdByUserID,false);

                if( retakeTest.AddRetakeTestApp() > 0)
                {
                    clsMisc.showDataSaveSuccessMsg();
                    _disableForm();
                }
            }
            if(currentFormMode == frmMode.AddNewVisionAppointment)
            {
                int testAppID = -1;

                clsTestAppointments testApp1 = new clsTestAppointments((int)_testTypesID.Vision,
                    Convert.ToInt32(lblDLAppID.Text), dateTimePicker1.Value,
                    Convert.ToDecimal(lblFees.Text),
                    clsGlobalSettings.currentlyLoggedInUser.userID, false);

                testAppID = testApp1.Add();

                if (testAppID > 0)
                {
                    clsMisc.showDataSaveSuccessMsg();
                    gbRetakeTestInfo.Enabled = false;
                    gbVisionTest.Enabled = false;

                    _disableForm();
                }
                else
                {
                    clsMisc.showDataSaveFailMsg();
                }
            }
            if (currentFormMode == frmMode.AddNewWrittenAppointment)
            {
                int testAppID = -1;

                clsTestAppointments testApp1 = new clsTestAppointments((int)_testTypesID.Written,
                    Convert.ToInt32(lblDLAppID.Text), dateTimePicker1.Value,
                    Convert.ToDecimal(lblFees.Text),
                    clsGlobalSettings.currentlyLoggedInUser.userID, false);

                testAppID = testApp1.Add();

                if (testAppID > 0)
                {
                    clsMisc.showDataSaveSuccessMsg();
                    gbRetakeTestInfo.Enabled = false;
                    gbVisionTest.Enabled = false;

                    _disableForm();
                }
                else
                {
                    clsMisc.showDataSaveFailMsg();
                }
            }
            if (currentFormMode == frmMode.AddNewStreetAppointment)
            {
                int testAppID = -1;

                clsTestAppointments testApp1 = new clsTestAppointments((int)_testTypesID.Street,
                    Convert.ToInt32(lblDLAppID.Text), dateTimePicker1.Value,
                    Convert.ToDecimal(lblFees.Text),
                    clsGlobalSettings.currentlyLoggedInUser.userID, false);

                testAppID = testApp1.Add();

                if (testAppID > 0)
                {
                    clsMisc.showDataSaveSuccessMsg();
                    gbRetakeTestInfo.Enabled = false;
                    gbVisionTest.Enabled = false;

                    _disableForm();
                }
                else
                {
                    clsMisc.showDataSaveFailMsg();
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gbVisionTest_Enter(object sender, EventArgs e)
        {

        }
    }

    namespace formModes
    {
        public enum frmMode
        {
            AddNewVisionAppointment = 1,
            AddNewWrittenAppointment = 2,
            AddNewStreetAppointment = 3,
            UpdateAppointmentDate = 4,
            RetakeTest=5
        }
    }
}
