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
    public partial class frmChangePassword : Form
    {
        private clsUser _user;
        private bool _errorFlag = true;

        public frmChangePassword(int userID)
        {
            _user=clsUser.loadUserInfo(userID);
            InitializeComponent();
        }

        public void populateEntireForm()
        {
            userCtrlLoginInfo1.populateLoginInfo(_user.userID);
            userCtrlPersonCard1.populatePersonCard(_user.personID);
        }

        private void txtBoxCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxCurrentPass.Text))
            {
                _errorFlag = true;

                txtBoxCurrentPass.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtBoxCurrentPass, "Enter current password!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxCurrentPass, "");
            }

            if (txtBoxCurrentPass.Text != _user.password)
            {
                _errorFlag = true;

                txtBoxCurrentPass.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtBoxCurrentPass, "Incorrect password!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxCurrentPass, "");
            }
        }

        private void txtBoxNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxNewPass.Text))
            {
                _errorFlag = true;

                txtBoxNewPass.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtBoxNewPass, "Password cannot be empty!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxNewPass, "");
            }

            if (txtBoxNewPass.Text == _user.password)
            {
                _errorFlag = true;

                txtBoxNewPass.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtBoxNewPass, "Cannot use old password!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxNewPass, "");
            }
        }

        private void txtBoxConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxConfirmPass.Text))
            {
                _errorFlag = true;

                txtBoxConfirmPass.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtBoxConfirmPass, "Confirm new password!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxConfirmPass, "");
            }

            if (txtBoxConfirmPass.Text != txtBoxNewPass.Text)
            {
                _errorFlag = true;

                txtBoxConfirmPass.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtBoxConfirmPass, "New password does not match!");
            }
            else
            {
                _errorFlag = false;

                e.Cancel = false;
                errorProvider1.SetError(txtBoxConfirmPass, "");
            }
        }

        private void txtBoxNewPass_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxCurrentPass.Text))
            {
                txtBoxConfirmPass.Enabled = false;
            }
            else
            {
                txtBoxConfirmPass.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_errorFlag)
            {
                MessageBox.Show("Enter passwords correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //method that updates password in DB
                if (_user.updatePassword(txtBoxNewPass.Text))
                { 
                MessageBox.Show("Password updated successfully","Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    disablePasswordFields();
                }

            }
        }

        private void disablePasswordFields()
        { 
            txtBoxNewPass.Enabled = false;
            txtBoxConfirmPass.Enabled = false;
            txtBoxCurrentPass.Enabled = false;

            btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
