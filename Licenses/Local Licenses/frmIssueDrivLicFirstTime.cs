using DVLD_Business;
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
    public partial class frmIssueDrivLicFirstTime : Form
    {
        private clsDriver _newDriver=new clsDriver();
        private clsLicense _newLicense=new clsLicense();
        private clsApplication _app=new clsApplication();
        private clsLocalDrivingLicenseApplications _localApp=new clsLocalDrivingLicenseApplications();
        public frmIssueDrivLicFirstTime(int LDLAppID,int appID)
        {
            InitializeComponent();
            userCtrlAppBasicInfo1.populateBasicInfoCard(appID);
            userCtrlDrivingLicenseApp1.populateLDLAppInfo(LDLAppID);

            _localApp = clsLocalDrivingLicenseApplications.getLocalAppInfo(LDLAppID);
            _app = _app.loadApplication(appID);
            _newDriver = new clsDriver(_app.person.PersonID,
                clsGlobalSettings.currentlyLoggedInUser.userID,DateTime.Now);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int newLicenseID = -1;
            int driverID = -1;

            //if first time, create new driverID and use it to add
            //if already existing,just get existing driverID to be added to license
            //TODO: put if statement here checking if person already is a driver                driverID = clsDriver.isDriver(_app.person.PersonID);
            driverID = clsDriver.isDriver(_app.person.PersonID);

            if (driverID==-1)
            {
                driverID = _newDriver.AddDriver();
            }

            DateTime expirationDate = _newDriver.createdDate.AddYears(clsLicenseClass
                .getLicenseValidityPeriodInYears(_localApp.licenseClassID));

            decimal licenseClassFees = clsLicenseClass.getLicenseClassFees(_localApp.licenseClassID);
            
            if (txtBoxNotes.Text == string.Empty)
            {
                _newLicense = new clsLicense(_app.appID, driverID,
                _localApp.licenseClassID, _newDriver.createdDate, expirationDate,
                DBNull.Value.ToString(), licenseClassFees, true, _app.appTypeID,
                clsGlobalSettings.currentlyLoggedInUser.userID);
            }
            else
            {
                _newLicense = new clsLicense(_app.appID, driverID,
                _localApp.licenseClassID, _newDriver.createdDate, expirationDate,
                txtBoxNotes.Text, licenseClassFees, true, _app.appTypeID,
                clsGlobalSettings.currentlyLoggedInUser.userID);
            }
            
            newLicenseID = _newLicense.AddLicense();

            if (newLicenseID > 1)
            {
                MessageBox.Show("License issued successfully with LicenseID=" + newLicenseID,
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _app.setApplicationStatusToCompleted();
            }

            else
                MessageBox.Show("License was not issued!","Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            this.Close();
        }


    }
}
