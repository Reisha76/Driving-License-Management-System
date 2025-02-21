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
    public partial class frmReplaceLostAndDamagedLicense : Form
    {
        private clsLicense _selectedLicense = new clsLicense();
        private clsDriver _selectedDriver = new clsDriver();
        private clsPerson _selectedPerson = new clsPerson();
        private clsLicense replacementLicense = new clsLicense();

        int replacementLicenseID;

        private decimal replaceDamagedFees = clsAppType.getAppTypeFees(4);
        private decimal replaceLostFees = clsAppType.getAppTypeFees(3);
        public frmReplaceLostAndDamagedLicense()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void userCtrlDriverLicenseSelector1_OnPersonSelected(int licenseID)
        {
            _selectedLicense = clsLicense.getLicense(licenseID);
            _selectedDriver=clsDriver.getDriverInfo(_selectedLicense.driverID);
            _selectedPerson=clsPerson.loadPersonInfo(_selectedDriver.personID);

            if (!_selectedLicense.isLicenseActive())
            { 
                MessageBox.Show("Selected license is Inactive, choose an active license.",
                    "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lnkLblShowLicHistory.Enabled = true;
                return;
            }

            btnIssueReplacement.Enabled = true;

        }

        private void setAppFees()
        { 
        if(rbDamagedLic.Checked)
                lblAppFees.Text=replaceDamagedFees.ToString();
        else
                lblAppFees.Text=replaceLostFees.ToString();
        }

        private void frmReplaceLostAndDamagedLicense_Load(object sender, EventArgs e)
        {
            lnkLblShowLicHistory.Enabled = false;
            lnkLblShowNewLic.Enabled = false;
            btnIssueReplacement.Enabled = false;

            setAppFees();
            lblAppDate.Text=DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobalSettings.currentlyLoggedInUser.userName;
        }

        private void lnkLblShowLicHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm1 = 
                new frmShowPersonLicenseHistory(_selectedDriver.personID);
            frm1.ShowDialog();
        }

        private void rbDamagedLic_CheckedChanged(object sender, EventArgs e)
        {
            setAppFees();
        }

        private void rbLostLic_CheckedChanged(object sender, EventArgs e)
        {
            setAppFees();
        }

        private int getAppType()
        {

            if (rbDamagedLic.Checked)
                return 4;
            else
                return 3;
        }
        private int getIssueReasonID()
        {
            if (rbLostLic.Checked)
                return 3;
            else
                return 4;
        }
        private decimal getAppFees()
        {
            decimal appFees = -1;

            if (rbDamagedLic.Checked)
                appFees = replaceDamagedFees;
            else
                appFees = replaceLostFees;

            return appFees;
        }
        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure of replacing this license?","Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.Yes)
            {
                _selectedLicense.deactivateLicense();

                clsApplication newApp = new clsApplication(-1, getAppType(),
                    _selectedPerson,3, DateTime.Now, DateTime.Now, getAppFees(),
                    clsGlobalSettings.currentlyLoggedInUser.userID);

                newApp.Add();

                 replacementLicense = new clsLicense(newApp.appID,
                    _selectedLicense.driverID,_selectedLicense.licenseClass,
                    newApp.appDate,
                   DateTime.Now.AddYears(clsLicenseClass.
                     getLicenseValidityPeriodInYears(_selectedLicense.licenseClass)),"",
                    getAppFees(),true,getIssueReasonID(),
                    clsGlobalSettings.currentlyLoggedInUser.userID);

                replacementLicenseID = replacementLicense.AddLicense();

                MessageBox.Show($"License replaced successfully with LicenseID={replacementLicense.licenseID}"
                 ,"License issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lnkLblShowNewLic.Enabled = true;
            }
            else
                return;
        }

        private void lnkLblShowNewLic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm1 = new frmShowLicense(replacementLicenseID);
            frm1.ShowDialog();
        }
    }
}
