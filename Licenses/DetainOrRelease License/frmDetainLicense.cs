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
    public partial class frmDetainLicense : Form
    {
        private clsLicense _license = new clsLicense();
        //private 

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (clsLicense.isLicenseDetained(_license.licenseID))
            {
                MessageBox.Show("License is already detained", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(txtBoxFine.Text))
            {
                MessageBox.Show("Please enter fine fees", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to detain this license?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    int detainedLicenseID = -1;

                    clsDetainedLicenses detainedLic = new clsDetainedLicenses(_license.licenseID,
                        DateTime.Now, Convert.ToDecimal(txtBoxFine.Text), clsGlobalSettings.
                        currentlyLoggedInUser.userID, false);

                    detainedLicenseID = detainedLic.Add();

                    if (detainedLicenseID > 0)
                    {
                        MessageBox.Show($"License detained successfully" +
                            $" with ID={detainedLicenseID}", "License detained",
                            MessageBoxButtons.OK,MessageBoxIcon.Information);

                        btnDetain.Enabled = false;
                    }
                }
                else
                {
                    return;
                }


            }
        }

        private void userCtrlDriverLicenseSelector1_OnPersonSelected(int licenseID)
        {
            _license = clsLicense.getLicense(licenseID);
            btnDetain.Enabled = true;
            lnkLblShowLic.Enabled = true;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            lnkLblShowLic.Enabled = false;
        }

        private void txtBoxFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void lnkLblLicHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsDriver driver1=clsDriver.getDriverInfo(_license.driverID);

            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory(driver1.personID);
            frm.ShowDialog();
        }

        private void lnkLblShowLic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm1 = new frmShowLicense(_license.licenseID);
            frm1.ShowDialog();
        }

        private void txtBoxFine_Validating(object sender, CancelEventArgs e)
        {
            if(Convert.ToDecimal(txtBoxFine.Text) <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxFine, "Fine fees must be greater than 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxFine, "");
            }
        }
    }
}
