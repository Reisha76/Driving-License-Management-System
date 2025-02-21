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
    public partial class frmEditApplicationType : Form
    {
        private bool _errorFlag = true;
        private clsAppType _applicationType;

        public frmEditApplicationType(int applicationTypeID)
        {
            _applicationType = clsAppType.loadAppType(applicationTypeID);
            InitializeComponent();
        }

        public void populateEditAppCard()
        {
            txtBoxTitle.Text = _applicationType.name;
            txtBoxFees.Text = _applicationType.fees.ToString();
            lblAppID.Text = _applicationType.id.ToString();
        }

        private bool isOKToSave()
        {
            if (_errorFlag)
            {
                return false;
            }
            else
                return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isOKToSave())
            {

                _applicationType=new clsAppType(_applicationType.id,txtBoxTitle.Text,
                    Convert.ToDecimal(txtBoxFees.Text));
                _applicationType.updateAppType();
                disableFieldsAfterSaving();
                MessageBox.Show("Application info updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Application info update FAILED", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //refreshdatagridmethod
        }

        private void disableFieldsAfterSaving()
        {
            txtBoxFees.Enabled = false;
            txtBoxTitle.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxTitle.Text))
            {
                _errorFlag = true;

                e.Cancel = true;
                txtBoxTitle.Focus();
                errorProvider1.SetError(txtBoxTitle, "Field cannot be empty!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxTitle, "");
            }
        }

        private void txtBoxFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxFees.Text))
            {
                _errorFlag = true;

                e.Cancel = true;
                txtBoxFees.Focus();
                errorProvider1.SetError(txtBoxFees, "Field cannot be empty!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxFees, "");
            }
        }
    }
}
