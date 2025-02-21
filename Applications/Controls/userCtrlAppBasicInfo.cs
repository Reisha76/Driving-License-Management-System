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
    public partial class userCtrlAppBasicInfo : UserControl
    {
        clsApplication app=new clsApplication();

        public userCtrlAppBasicInfo()
        {
            InitializeComponent();
        }

        public void populateBasicInfoCard(int appID)
        {
            app = new clsApplication();
            app=app.loadApplication(appID);

            clsAppType appType1 = clsAppType.loadAppType(app.appTypeID);

            clsUser user1=clsUser.loadUserInfo(app.createdByUserID);


            lblAppID.Text = appID.ToString();
            lblDate.Text=app.appDate.ToShortDateString();
            lblStatusDate.Text=app.lastStatusDate.ToShortDateString();
            //UserName
            lblUser.Text = user1.userName.ToString();

            //status
            switch (app.appStatusID)
            {
                case 1: lblStatus.Text = "New";
                    break;
                case 2: lblStatus.Text = "Cancelled";
                    break;
                case 3:
                    lblStatus.Text = "Complete";
                    break;
            }
            //fees
            lblFees.Text=appType1.fees.ToString();
            //appType
            lblAppType.Text=appType1.name.ToString();
            //applicantName
            lblName.Text=app.person.fullName.ToString();
        }

        private void userCtrlAppBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonCard frm1 = new frmPersonCard(app.person.PersonID);
            frm1.ShowDialog();
        }
    }
}
