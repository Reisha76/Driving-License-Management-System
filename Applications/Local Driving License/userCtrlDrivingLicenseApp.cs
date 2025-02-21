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

namespace My_DVLD
{
    public partial class userCtrlDrivingLicenseApp : UserControl
    {
        private clsLocalDrivingLicenseApplications _currentlySelectedApp;

        public userCtrlDrivingLicenseApp()
        {
            InitializeComponent();
        }

        public void populateLDLAppInfo(int LDLAppID)
        { 
            _currentlySelectedApp = clsLocalDrivingLicenseApplications.getLocalAppInfo(LDLAppID);

            lblDLAppID.Text = LDLAppID.ToString();
            lblLicenseClass.Text = 
                clsBusinessInfo.getLicenseClassName(_currentlySelectedApp.licenseClassID);
            lblPassedTestsCounter.Text = clsLocalDrivingLicenseApplications.
                getPassedTestsCounter(LDLAppID).ToString() + "/3";
        }

        private void userCtrlDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            
        }

        private void lblShowLicenseInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
