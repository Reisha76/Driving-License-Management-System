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
    public partial class frmInternationalLicenseApplication : Form
    {
       private clsLicense _license = new clsLicense();
       private int _newIntlLicenseID = -1;
        private clsPerson _person = new clsPerson();
        private int _currentlySelectedLicenseID = -1;

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
                lblIntlAppID.Text = DateTime.Now.ToShortDateString();
                lblAppDate.Text = DateTime.Now.ToShortDateString();
                lblIssueDate.Text = DateTime.Now.ToShortDateString();
                lblIntlExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
                lblCreatedByUser.Text = clsGlobalSettings.currentlyLoggedInUser.userName;
                lblFees.Text = clsAppType.getAppTypeFees(6).ToString();

                LnkLblShowLicInfo.Enabled = false;
                btnIssue.Enabled = false;
        }

        private void userCtrlDriverLicenseSelector1_OnPersonSelected(int obj)
        {
            _license = clsLicense.getLicense(obj);
            _currentlySelectedLicenseID = obj;
            if (clsIntlLicenses.hasIntlLicense(_license.licenseID))
            {
                MessageBox.Show("Person has existing International License!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (clsLicense.isLicenseDetained(_license.licenseID))
            { 
            MessageBox.Show("Selected license is detained! Must release first or choose another license.",
                "Detained",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = true;

            if(obj>0)
                lblLocalLicID.Text = obj.ToString(); 

            _license = clsLicense.getLicense(obj);
            _person = clsPerson.loadPersonInfo(userCtrlDriverLicenseSelector1.person.PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _changeButtonsStatesAfterIssuing()
        { 
            btnIssue.Enabled=false;
            LnkLblShowLicInfo.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Now,
                _license.expirationDate) == -1 //-1 means date1 is before date2
                &&
                _license.isActive==true)
            {
                //_license = userCtrlDriverLicenseSelector1.selectedLicense;
                clsIntlLicenses intlLicense =
                    new clsIntlLicenses(_license.applicationID, _license.driverID,
                    _license.licenseID, DateTime.Now,
                    Convert.ToDateTime(lblIntlExpirationDate.Text), _license.isActive,
                    clsGlobalSettings.currentlyLoggedInUser.userID);

                _newIntlLicenseID = intlLicense.Add();

                if (_newIntlLicenseID > 0)
                {
                    _changeButtonsStatesAfterIssuing();
                    lblIntlLicID.Text = _newIntlLicenseID.ToString();

                    MessageBox.Show($"International license issued successfully with ID=[{_newIntlLicenseID}]",                        
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LnkLblShowLicInfo.Enabled = true;

                }
            }
        }

        private void LnkLblShowLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowIntlDrivLic frm1 = new frmShowIntlDrivLic(_currentlySelectedLicenseID);
            frm1.ShowDialog();
        }

        private void LnkLblShowLicHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // if (_license.licenseID<1)
           //     return;
            
            frmShowPersonLicenseHistory frm1 = 
                new frmShowPersonLicenseHistory(_person._NationalNum);
        }
    }
}
