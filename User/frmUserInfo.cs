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
    public partial class frmUserInfo : Form
    {
        private clsUser _user;
        public frmUserInfo(int personID)
        {
            //BUG HERE: PASSING PERSONID TO METHOD WHICH NEEDS USERID
            _user = clsUser.loadUserInfoByPersonID(personID);
            InitializeComponent();
        }

        public void populateUserInfoCard()
        { 
          userCtrlPersonCard1.populatePersonCard(_user.personID);
            userCtrlLoginInfo1.populateLoginInfo(_user.userID);
        }
    }
}
