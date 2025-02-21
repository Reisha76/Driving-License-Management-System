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
    public partial class frmRenewLocalDrivLic : Form
    {
        private clsLicense _oldLicense=new clsLicense();
        private clsLicense _renewedLicense = new clsLicense();
        private clsPerson _person = new clsPerson();
        private clsDriver _driver = new clsDriver();
        private int _licenseValidityYears = -1;
        public frmRenewLocalDrivLic()
        {
            InitializeComponent();
        }

        private void userCtrlDriverLicenseSelector1_OnPersonSelected(int obj)
        {
            _oldLicense = userCtrlDriverLicenseSelector1.license;
            _person = userCtrlDriverLicenseSelector1.person;
            _driver = userCtrlDriverLicenseSelector1.driver;
            _licenseValidityYears = clsLicenseClass.
                getLicenseValidityPeriodInYears(_oldLicense.licenseClass);

            if (clsLicense.isLicenseDetained(_oldLicense.licenseID))
            { 
            MessageBox.Show("Selected license is detained! Must release first or choose another license.",
                "Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!_oldLicense.isLicenseActive())
            {
                MessageBox.Show("Selected license is INACTIVE! Cannot renew inactive license.",
                    "Inactive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (DateTime.Compare(DateTime.Now, _oldLicense.expirationDate) == -1)//not expired yet
            {
                MessageBox.Show($"Selected license is not yet expired," +
                    $" will expire on:{_oldLicense.expirationDate.ToShortDateString()}",
                    "Not expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            else if (_oldLicense.isActive == false)
            {
                MessageBox.Show($"Selected license is INACTIVE," +
                 $" cannot renew INACTIVE license",
                 "License is Inactive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if(_person.hasDetainedLicense())
            {
                MessageBox.Show($"Person has detained license, release any detained licenses first",
                    "Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                _populateNewLicenseCard();
                 btnRenew.Enabled = true;

            }
        }

        private void _populateNewLicenseCard()
        {
            lblOldLicenseID.Text =
                        _oldLicense.licenseID.ToString();
            lblExpirationDate.Text =
                Convert.ToString
                (DateTime.Now.AddYears(_licenseValidityYears));
            lblLicenseFees.Text = Convert.ToString(clsAppType.getAppTypeFees(2)); //1=new local app, 2 = renew driv lic
            lblTotalFees.Text = Convert.ToString((Convert.ToDecimal(lblLicenseFees.Text) + Convert.ToDecimal(lblAppFees.Text)));

        }

        private void _populateDriverInfoCard()
        {
            lblAppFees.Text =Convert.ToString(clsAppType.getAppTypeFees(1));
            lblAppDate.Text=DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUserID.Text=clsGlobalSettings.currentlyLoggedInUser.userName;

        }

        private void frmRenewLocalDrivLic_Load(object sender, EventArgs e)
        {
            btnRenew.Enabled = false;
            lnkLblShowNewLic.Enabled = false;
            _populateDriverInfoCard();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to renew this license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.Yes)
            {
                int newAppID = -1, renewedLicenseID = -1;

                clsApplication newApp = new clsApplication(-1, 2, _person, 3, DateTime.Now,
                    DateTime.Now, Convert.ToDecimal(lblAppFees.Text),
                    clsGlobalSettings.currentlyLoggedInUser.userID);

               newAppID= newApp.Add();

                clsLicense newLicense = new clsLicense(newAppID, _driver.driverID,
                    _oldLicense.licenseClass, DateTime.Now,
                    DateTime.Now.AddYears(_licenseValidityYears),
                    txtBoxNotes.Text, Convert.ToDecimal(lblLicenseFees.Text), true, 2,
                    clsGlobalSettings.currentlyLoggedInUser.userID);

                renewedLicenseID = newLicense.AddLicense();
                _renewedLicense = clsLicense.getLicense(renewedLicenseID);
                _oldLicense.deactivateLicense();

                MessageBox.Show($"License renewed successfully" +
                    $" with LicenseID={renewedLicenseID}", "License Renewed", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lnkLblShowNewLic.Enabled = true;
                btnRenew.Enabled = false;
                txtBoxNotes.Enabled = false;
            }
            else
                return;
        }

        private void lnkLblShowLicHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm1 = new frmShowPersonLicenseHistory(_person._NationalNum);
            frm1.ShowDialog();
        }
        private void lnkLblShowNewLic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm1 = new frmShowLicense(_renewedLicense.licenseID);
            frm1.ShowDialog();
        }
    }
}
