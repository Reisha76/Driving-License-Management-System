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
    public partial class frmShowLicense : Form
    {
       private clsLicense _license = new clsLicense();
       private clsApplication _app = new clsApplication();

        public frmShowLicense(int licenseID)
        {
            InitializeComponent();
            _license=clsLicense.getLicense(licenseID);
            _app = _app.loadApplication(_license.applicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string getIssueReason(int issueReasonID)
        {
            switch (issueReasonID)
            {
                case 1:
                    return "First Time";
                case 2:
                    return "Renew";
                default:
                    return "Error";
            }
        }

        private void _populateLicenseCard()
        {
            lblLicenseClass.Text = clsBusinessInfo.getLicenseClassName(_license.licenseClass);
            lblDriverName.Text = _app.person.fullName;
            lblLicenseID.Text = _license.licenseID.ToString();
            lblNationalNo.Text = _app.person._NationalNum;
            picBoxDriver.ImageLocation=_app.person._ImagePath;

            if (_app.person._Gendor == 0)
                lblGender.Text = "Male";
            else if (_app.person._Gendor == 1)
                lblGender.Text = "Female";
            lblIssueDate.Text=_license.issueDate.ToShortDateString();
            lblIssueReason.Text = getIssueReason(_license.issueReasonID);
            if (string.IsNullOrEmpty(_license.notes))
                lblNotes.Text = "No Notes";
            else
                lblNotes.Text = _license.notes;

            if (_license.isActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

            lblDOB.Text=_app.person._DateOfBirth.ToShortDateString();
            lblDriverID.Text = _license.driverID.ToString();
            lblExpirationDate.Text=_license.expirationDate.ToShortDateString();
            if(clsLicense.isLicenseDetained(_license.licenseID))
                lblIsDetained.Text = "Yes";
            else
                lblIsDetained.Text = "No";
        }
        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            _populateLicenseCard();
        }
    }
}
