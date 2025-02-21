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
    public partial class userCtrlLoginInfo : UserControl
    {
        private clsUser _user;

        public userCtrlLoginInfo()
        {
            InitializeComponent();
        }

        public void populateLoginInfo(int userID)
        { 
           _user=clsUser.loadUserInfo(userID);

            lblUserID.Text = _user.userID.ToString();
            lblUserName.Text = _user.userName;

            if (_user.isActive == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
                lblIsActive.Text = "No";

        }
    }
}
