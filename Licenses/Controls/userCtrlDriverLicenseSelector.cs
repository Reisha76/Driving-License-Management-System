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
    public partial class userCtrlDriverLicenseSelector : UserControl
    {
        private int _enteredLicenseID;
        private clsLicense _license = new clsLicense();
        private clsPerson _person = new clsPerson();
        private clsDriver _driver = new clsDriver();
        private int _enteredLocalLicenseID=-1;
        public clsDriver driver
        { get { return _driver; } }
        public clsLicense license
        { get { return _license; } }
        public clsPerson person 
        { get { return _person; } }

        public userCtrlDriverLicenseSelector()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int isPersonSelected)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
            { 
            handler(isPersonSelected);
            }
        }
        private void _populatePersonCard()
        {
            lblClass.Text = clsBusinessInfo.getLicenseClassName(_license.licenseClass);
            lblName.Text = _person.fullName;
            lblLicenseID.Text = _license.licenseID.ToString();
            lblNationalNo.Text = _person._NationalNum;
            if (_person._Gendor == 0)
                lblSex.Text = "Male";
            else
                lblSex.Text = "Female";
            lblIssueDate.Text = _license.issueDate.ToShortDateString();
            lblExpirationDate.Text = _license.expirationDate.ToShortDateString();
            lblIssueReason.Text = clsAppType.getIssueReason(_license.issueReasonID);
            if (string.IsNullOrEmpty(lblNotes.Text))
                lblNotes.Text = "No Notes";
            else
                lblNotes.Text = _license.notes;
            if (_license.isActive == true)
                lblIsActive.Text = "Yes";
            else if (_license.isActive == false)
                lblIsActive.Text = "No";

            lblDateOfBirth.Text = _person._DateOfBirth.ToShortDateString();
            lblDriverID.Text = _driver.driverID.ToString();
            lblExpirationDate.Text = _license.expirationDate.ToShortDateString();
            pictureBox1.ImageLocation = _person._ImagePath;

            if(clsLicense.isLicenseDetained(_license.licenseID))
                lblIsDetained.Text = "Yes";
            else
                lblIsDetained.Text = "No";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentLicenseID = Convert.ToInt32(txtBoxSearch.Text);

            if (clsLicense.isLicenseExist(currentLicenseID))
            {
                _license = clsLicense.getLicense(currentLicenseID);
                _driver = clsDriver.getDriverInfo(_license.driverID);
                _person = clsPerson.loadPersonInfo(_driver.personID);
                _enteredLicenseID = Convert.ToInt32(txtBoxSearch.Text);

                if(OnPersonSelected != null)
                    PersonSelected(currentLicenseID);
            }
            else
            {
                MessageBox.Show("Driver with LicenseID [" + currentLicenseID + "] can not be found!",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _populatePersonCard();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtBoxSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                e.Cancel = true;
                txtBoxSearch.Focus();
                errorProvider1.SetError(txtBoxSearch, "Cannot be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxSearch, "");
            }
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }
    }
}
