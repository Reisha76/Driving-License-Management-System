using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD
{
    public partial class frmAddNewLocalDrivLic : Form
    {
        private int _newLocalDrivingLicenseID = 1;
        private int _emptyAppID = -1;
        private int appTypeID = 1;
        private int _existingAppID;
        private clsApplication _app = new clsApplication();

        private enum enLicenseClasses
        {
            smallMotorcycle = 1,
            heavyMotorcycle=2,
            ordinary=3,
            commercial = 4,
            agricultural=5,
            smallAndMediumBus=6,
            truckAndHeavyVehicle=7
        }
        private enLicenseClasses _enLicenseClass;
        public frmAddNewLocalDrivLic()
        {
            InitializeComponent();
        }
        public frmAddNewLocalDrivLic(string nationalNo)
        {
            InitializeComponent();
            userCtrlPersonSelector1.populateCard(nationalNo);
            btnSave.Enabled = false;
            cbLicenseClass.Enabled = false;
        }
        private void frmNewLocalDrivLic_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dVLDDataSetLICENSECLASSES.LicenseClasses' table. You can move, or remove it, as needed.
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobalSettings.currentlyLoggedInUser.userName;
            lblFees.Text = clsApplication.getNewAppFee().ToString();

            cbLicenseClass.SelectedIndex = 2;

        }
        private int getSelectedLicenseClassID()
        {
            switch (cbLicenseClass.SelectedIndex)
            {
                    case 0:
                        return 1;
                    case 1:
                        return 2;
                    case 2:
                        return 3;
                    case 3:
                        return 4;
                    case 4:
                        return 5;
                    case 5:
                        return 6;
                    case 6:
                        return 7;

                    default:
                        return -1;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checkIfExistActiveApplication()
        {
            //call dataacces method which checks FULL NAME, LICENSE CLASS and STATUS=NEW 
            //return true if exists, prevents user from having 2 applications of same type
            clsPerson person = userCtrlPersonSelector1.currentlySelectedPerson;

            string fullName = person._FirstName + " " + person._SecondName +
                " " + person._ThirdName + " " + person._LastName;

            _existingAppID = clsApplication.hasOpenApplication(fullName, cbLicenseClass.Text);

            if (_existingAppID == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isOKToSave())
            {
                int appID = -1;

                clsPerson person1 = userCtrlPersonSelector1.currentlySelectedPerson;

                clsApplication app1 = new clsApplication(_emptyAppID, _newLocalDrivingLicenseID,
                    person1, 1, DateTime.Now,DateTime.Now,
                    clsApplication.getNewAppFee(),clsGlobalSettings.currentlyLoggedInUser.userID);
                
                appID = app1.Add();


                clsLocalDrivingLicenseApplications localApp1 = new clsLocalDrivingLicenseApplications(-1,appID,getSelectedLicenseClassID());


                localApp1.Add();

                MessageBox.Show("Data saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblAppID.Text = localApp1.appID.ToString();
                disableEntries();
                return;
            }


        }
        private bool isOKToSave()
        {
            if (userCtrlPersonSelector1.currentlySelectedPerson == null)
            {
                MessageBox.Show("You must first select a person!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (checkIfExistActiveApplication())
            {
                MessageBox.Show("Choose another License Class, the selected person already has an" +
                    $" active application for the selected class with ID={_existingAppID.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (HasLicenseOfSameClass())
            {
                MessageBox.Show("Person already has a license of the same selected" +
                    " driving license class, choose different license class!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(userCtrlPersonSelector1.currentlySelectedPerson.hasDetainedLicense())
            {
                MessageBox.Show("Person has a detained license, must RELEASE ALL DETAINED LICENSE(s)" +
                    " to proceed with application",
                    "Person Has Detained License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //check minimum age of selected license
            int minAgeForSelectedClass = clsLicenseClass.
                getMinimumAllowedAgeForLicenseClass(cbLicenseClass.SelectedIndex + 1);
            int selectedPersonAge = (DateTime.Now - userCtrlPersonSelector1.currentlySelectedPerson._DateOfBirth).Days / 365;

            if (selectedPersonAge<minAgeForSelectedClass)
            {
                MessageBox.Show($"Person is {selectedPersonAge} years old,must be {minAgeForSelectedClass} for this license class .",
                    "Person is Underage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool HasLicenseOfSameClass()
        {
            return clsLicense.hasSameLicenseType(userCtrlPersonSelector1.currentAppID,
                getSelectedLicenseClassID());
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabCtrlNewApplication.SelectedTab = tabApplicationInfo;
        }
        private void disableEntries()
        { 
        userCtrlPersonSelector1.Enabled = false;
            cbLicenseClass.Enabled = false;

            btnSave.Enabled = false;
        }
    }
}
