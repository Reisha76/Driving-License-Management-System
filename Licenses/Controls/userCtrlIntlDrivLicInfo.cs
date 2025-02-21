using DVLD_Business;
using My_DVLD.Properties;
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
    public partial class userCtrlIntlDrivLicInfo : UserControl
    {
        private clsPerson _person=new clsPerson();
        private clsApplication _app = new clsApplication();
        private clsIntlLicenses _intlLicense= new clsIntlLicenses();

        public userCtrlIntlDrivLicInfo()
        {
            InitializeComponent();
        }
        public void _populateCard(int intlDriverLicenseID)
        {
            _intlLicense = clsIntlLicenses.getIntlLicense(intlDriverLicenseID);
            _app = _app.loadApplication(_intlLicense.appID);
            _person = clsPerson.loadPersonInfo(_app.person.PersonID);

            lblName.Text=_person.fullName;
            lblIntlLicID.Text=_intlLicense.intlLicenseID.ToString();
            lblLocalLicID.Text=_intlLicense.localLicenseID.ToString();
            lblNationalNo.Text=_person._NationalNum;
            if (_person._Gendor == 0)
                lblSex.Text = "Male";
            else
                lblSex.Text = "Female";
            lblIssueDate.Text=_intlLicense.issueDate.ToShortDateString();
            lblAppID.Text = _intlLicense.appID.ToString();
            if (_intlLicense.isActive == true)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
            lblDOB.Text=_person._DateOfBirth.ToShortDateString();
            lblDriverID.Text = _intlLicense.driverID.ToString();
            lblExpirationDate.Text=_intlLicense.expirationDate.ToShortDateString();
            if (string.IsNullOrEmpty(_person._ImagePath))
                pictureBox1.Image = Resources.man;
            else
                pictureBox1.ImageLocation=_person._ImagePath;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void userCtrlIntlDrivLicInfo_Load(object sender, EventArgs e)
        {
        
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
