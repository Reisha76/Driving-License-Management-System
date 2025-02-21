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
    public partial class userCtrlPersonSelector : UserControl
    {

        private clsPerson _currentlySelectedPerson;
        private clsApplication _currentlySelectedApp = new clsApplication();
        private int _currentAppID = -1;
        public clsPerson currentlySelectedPerson
        { get { return _currentlySelectedPerson; } }
        public clsApplication currentlySelectedApplication
        {  get { return _currentlySelectedApp; } }
        public int currentAppID
        {  get { return _currentAppID; } }
        public userCtrlPersonSelector()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frm1=new frmAddPerson();
            frm1.ShowDialog();

            _currentlySelectedPerson=clsPerson.loadPersonInfo(frm1.obtainedPersonID);
            userCtrlPersonCard1.populatePersonCard(_currentlySelectedPerson.PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxSearch.Text))
            {
                MessageBox.Show("Search bar cant be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (cbFilters.Text == "Person ID")
            {
                if (clsPerson.isExist(Convert.ToInt32(txtBoxSearch.Text)))
                {
                    _currentlySelectedPerson = clsPerson.loadPersonInfo(Convert.ToInt32(txtBoxSearch.Text));
                    _currentAppID=clsApplication.getAppIDUsingPersonID(_currentlySelectedPerson.PersonID);
                    userCtrlPersonCard1.populatePersonCard(_currentlySelectedPerson.PersonID);
                }
                else
                {
                    MessageBox.Show($"Can't find person ID=[{txtBoxSearch.Text}]");
                }
            }
            if (cbFilters.Text == "National No.")
            {
                if (clsPerson.isExist(txtBoxSearch.Text))
                {
                    _currentlySelectedPerson = clsPerson.loadPersonInfo(txtBoxSearch.Text);
                    _currentAppID = clsApplication.getAppIDUsingPersonID(_currentlySelectedPerson.PersonID);
                    userCtrlPersonCard1.populatePersonCard(_currentlySelectedPerson.PersonID);
                }
                else
                {
                    MessageBox.Show($"Can't find National No. ID=[{txtBoxSearch.Text}]");
                }
            }
        }

        private void txtBoxSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbFilters.Text))
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
            if (cbFilters.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                {
                    e.Handled = true;
                }
            }
        }

        private void txtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        public void populateCard(string nationalNo)
        {
            cbFilters.Text="National No.";
            txtBoxSearch.Text=nationalNo;

            userCtrlPersonCard1.populatePersonCard(nationalNo);
            gbFilter.Enabled = false;
        }
    }
}
