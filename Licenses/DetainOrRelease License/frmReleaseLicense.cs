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
    public partial class frmReleaseLicense : Form
    {
        private clsLicense _license = new clsLicense();
        private clsDetainedLicenses _detainedLic = new clsDetainedLicenses();
        private clsDriver _driver = new clsDriver();

        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        public frmReleaseLicense(int licenseID)
        {
            InitializeComponent();
            _license = clsLicense.getLicense(licenseID);
            _detainedLic = clsDetainedLicenses.getDetainedLicense(licenseID);
            _driver = clsDriver.getDriverInfo(_license.driverID);
            _populateCard();
            lnkLblLicHistory.Enabled = true;
            lnkLblShowLic.Enabled = true;
            btnRelease.Enabled = true;

            userCtrlDriverLicenseSelector1.Enabled = false;
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            lnkLblLicHistory.Enabled = false;
            lnkLblShowLic.Enabled = false;
            btnRelease.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _populateCard()
        {
            lblDetainID.Text = _detainedLic.detainID.ToString();
            lblDetainDate.Text = _detainedLic.detainDate.ToShortDateString();
            lblAppFees.Text = Convert.ToString(clsAppType.getAppTypeFees(clsAppType.ApplicationTypes.releaseDetained));
            lblCreatedBy.Text = clsGlobalSettings.currentlyLoggedInUser.userName;
            lblFineFees.Text = _detainedLic.fineFees.ToString();
            lblLicenseID.Text=_detainedLic.licenseID.ToString();

            lblTotalFees.Text = Convert.ToString(_detainedLic.fineFees
                + clsAppType.getAppTypeFees(clsAppType.ApplicationTypes.releaseDetained));
        }

        private void userCtrlDriverLicenseSelector1_OnPersonSelected(int licenseID)
        {
            _license = clsLicense.getLicense(licenseID);
            _detainedLic = clsDetainedLicenses.getDetainedLicense(licenseID);
            _driver = clsDriver.getDriverInfo(_license.driverID);

            lnkLblLicHistory.Enabled = true;
            lnkLblShowLic.Enabled = true;

            if (!_license.isLicenseActive())
            { 
            MessageBox.Show("Selected license is INACTIVE, cannot release INACTIVE license!",
                "Inactive License",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsLicense.isLicenseDetained(licenseID))
            {
                _populateCard();
                btnRelease.Enabled = true;
            }
            else
            {
                MessageBox.Show("This license is not detained", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void lnkLblLicHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsDriver driver = clsDriver.getDriverInfo(_license.driverID);

            frmShowPersonLicenseHistory frm1 =
                new frmShowPersonLicenseHistory(driver.personID);
            frm1.ShowDialog();
        }

        private void lnkLblShowLic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm1 = new frmShowLicense(_license.licenseID);
            frm1.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            //create new application with status completed
            //update detained license record to remove null values AND
            //set isReleased to true
            //set lblAppID to its value
            int newAppID = -1;

            clsPerson person = clsPerson.loadPersonInfo(_driver.personID);

            clsApplication app = new clsApplication(-1,
                clsAppType.ApplicationTypes.releaseDetained, person, 3, DateTime.Now,
                DateTime.Now, Convert.ToDecimal(lblTotalFees.Text),
                clsGlobalSettings.currentlyLoggedInUser.userID);

            newAppID = app.Add();

            _detainedLic.releaseLicense(newAppID);

            lblAppID.Text = newAppID.ToString();
            btnRelease.Enabled = false;

            MessageBox.Show("License Released Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
