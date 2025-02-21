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
    public partial class frmEditTestTypes : Form
    {
        private clsTestTypes _testType;
        private bool _errorFlag = false;

        public frmEditTestTypes(int testTypeID)
        {
            _testType=clsTestTypes.loadSingleTestTypeByID(testTypeID);
            InitializeComponent();
        }

        public void populateTestTypeCard()
        {
            lblTestTypeID.Text = _testType.id.ToString();

            txtBoxDescription.Text = _testType.description.ToString();
            txtBoxFees.Text = _testType.fees.ToString();
            txtBoxTitle.Text = _testType.title.ToString();
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validate boxes if not empty
            //call business which calls dataaccess to update in DB

            if (isOKToSave())
            {
                //set object to current info
                //call save method
                _testType.title = txtBoxTitle.Text;
                _testType.description = txtBoxDescription.Text;
                _testType.fees=Convert.ToDecimal(txtBoxFees.Text);

                if (_testType.update())
                {
                    MessageBox.Show("Updated test type successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Test type update FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                disableEntries();
                return;
            }
            else
            { 
            MessageBox.Show("Fields are incomplete!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void disableEntries()
        {
            txtBoxDescription.Enabled = false;
            txtBoxFees.Enabled = false;
            txtBoxTitle.Enabled = false;
            btnSave.Enabled = false;
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

        private void txtBoxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDescription.Text))
            {
                _errorFlag = true;

                e.Cancel = true;
                txtBoxDescription.Focus();
                errorProvider1.SetError(txtBoxDescription, "Field cannot be empty!");
            }
            else
            {

                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxDescription, "");
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
