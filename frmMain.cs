using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
using My_DVLD.Screens_People;
namespace My_DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageUser = new frmManageUsers();
            frmManageUser.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo1 =new frmUserInfo(clsGlobalSettings.currentlyLoggedInUser.personID);
            
            frmUserInfo1.populateUserInfoCard();
            frmUserInfo1.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword1 =
                new frmChangePassword(clsGlobalSettings.currentlyLoggedInUser.userID);

            frmChangePassword1.populateEntireForm();
            frmChangePassword1.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.currentlyLoggedInUser = null;
            this.Close();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //clsGlobalSettings.currentlyLoggedInUser = clsUser.loadUserInfo(1);
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FORM  APPLICATION TYPES NEEDS 2 BE HERE
            frmListApplicationTypes frmManageApplicationTypes1 = new frmListApplicationTypes();
            frmManageApplicationTypes1.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm1=new frmManageTestTypes();
            frm1.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivLic frm1= new frmAddNewLocalDrivLic();
            frm1.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivApps frm1=new frmLocalDrivApps();
            frm1.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm1 =new frmManageDrivers();
            frm1.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication frm1=
                new frmInternationalLicenseApplication();
            frm1.ShowDialog();
        }

        private void internationalLicenseApplicationalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseApplications frm1 = 
                new frmManageInternationalLicenseApplications();
            frm1.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivLic frm1 = new frmRenewLocalDrivLic();
            frm1.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostAndDamagedLicense frm1 = new frmReplaceLostAndDamagedLicense();
            frm1.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm1 = new frmDetainLicense();
            frm1.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm1 = new frmReleaseLicense();
            frm1.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm1 = new frmManageDetainedLicenses();
            frm1.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm1 = new frmReleaseLicense();
            frm1.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivApps frm1 = new frmLocalDrivApps();
            frm1.ShowDialog();
        }
    }
}
