using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD.Screens_People
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void rememberMeSaveLoginCredentials()
        {

                //save current login info 
                //File.Open("RememberME.txt",FileMode.Open,FileAccess.Read);
                File.WriteAllText(clsGlobalSettings.credentialsFilePath,string.Empty);
                File.WriteAllText(clsGlobalSettings.credentialsFilePath, txtBoxUserName.Text+","+txtBoxPassword.Text);                
        }

        private void populateLoginScreen()
        {
            if (clsGlobalSettings.isRememberMeChecked)
            {
                string credentials = File.ReadAllText(clsGlobalSettings.credentialsFilePath);
                string[] credentialsArr;

                credentialsArr = credentials.Split(',');

                txtBoxUserName.Text = credentialsArr[0];
                txtBoxPassword.Text = credentialsArr[1];
                chkBoxRememberMe.Checked = true;
            }
            else
            {
                txtBoxUserName.Text = "";
                txtBoxPassword.Text = "";
                chkBoxRememberMe.Checked = false;

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser loginUser = clsUser.loadUserInfo(txtBoxUserName.Text);

            if (validateLoginCredentials(loginUser))
            {

                clsGlobalSettings.currentlyLoggedInUser = loginUser;

                if(chkBoxRememberMe.Checked)
                    rememberMeSaveLoginCredentials();

                frmMain frmMain1 = new frmMain();
                this.Hide();

                frmMain1.ShowDialog();

 
                populateLoginScreen();

                this.Show();
            }
            else
                return;

        }

        private bool validateLoginCredentials(clsUser userLoggingIn)
        {
            if (string.IsNullOrWhiteSpace(txtBoxUserName.Text)
                || string.IsNullOrWhiteSpace(txtBoxPassword.Text))
            {
                MessageBox.Show("Enter login credentials!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtBoxUserName.Text == userLoggingIn.userName
                && txtBoxPassword.Text == userLoggingIn.password)
            {
                if (userLoggingIn.isActive == false)
                {
                    MessageBox.Show("This user is deactivated, please contact your system administrator", "User Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Incorrect username/password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void chkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            clsGlobalSettings.isRememberMeChecked = chkBoxRememberMe.Checked;
        }
    }
}
