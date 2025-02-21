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
    public partial class frmAddUser : Form
    {
        enum enMode { Add,Update};

        enMode currentMode;

        private clsPerson _currentlySelectedPerson;
        private clsUser _currentlySelectedUser;

        private int _currentPersonId;
        private int _currentUserId;

        private bool canProceed = true;
        public clsPerson currentlySelectedPerson
        {
            get { return _currentlySelectedPerson; }
        }

        public frmAddUser()
        {
            InitializeComponent();
        }

        public frmAddUser(int userID)
        {
            InitializeComponent();
            populateEditUserScreen(userID);
            editUserScreen();
            populateLoginInfo();
        }

        private void populateLoginInfo()
        { 
            lblUserID.Text = _currentlySelectedUser.userID.ToString();
            txtBoxUserName.Text= _currentlySelectedUser.userName;
            txtBoxPass.Text= _currentlySelectedUser.password;
            txtBoxConfirmPass.Text = _currentlySelectedUser.password;

            if(_currentlySelectedUser.isActive==true)
                chkBoxIsActive.Checked = true;
            else
                chkBoxIsActive.Checked = false;
        }

        private void populateEditUserScreen(int userID)
        {
            _currentlySelectedUser = clsUser.loadUserInfo(userID);
            _currentlySelectedPerson = clsPerson.loadPersonInfo(_currentlySelectedUser.personID);


            cbFilters.Text = "Person ID";
            txtBoxSearch.Text= _currentlySelectedPerson.PersonID.ToString();
            
            //line below me
            userCtrlPersonCard1.populatePersonCard(_currentlySelectedPerson.PersonID);

            
        }

        private void editUserScreen()
        {
            currentMode = enMode.Update;

            tabPersonalInfo.Enabled = false;
            label1.Text = "Update User";



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
        private void disableEntriesAfterSaving()
        { 
            tabPersonalInfo.Enabled = false;
            tabLoginInfo.Enabled = false;
            //tabAddUser.Enabled = false;
        }
        private bool isUserLinkedToPerson()
        { 
            //business that calls dataaaccess that checks if exist

            if (clsUser.isExist(_currentPersonId))
            {
                MessageBox.Show("Selected person is already a user! Choose another user!","Error!",
                    MessageBoxButtons.OK,MessageBoxIcon.Stop);

                return true;
            }
            else
            {
                return false; 
            }
        }
        private bool isUserNameExist()
        {
            if (clsUser.isUserNameExist(txtBoxUserName.Text))
            { 
            MessageBox.Show("UserName already exists!","Error!",MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }
            else
                return false;
        }
        private bool isOkToSave()
        {
            bool isOk = false;

            if (_currentlySelectedPerson != null && _currentPersonId != -1)
            {
                if (!string.IsNullOrWhiteSpace(txtBoxUserName.Text)
                    && !string.IsNullOrWhiteSpace(txtBoxPass.Text) &&
                    txtBoxPass.Text == txtBoxConfirmPass.Text)
                { 
                isOk = true;
                }    
            }
            return isOk;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtBoxSearch.Text))
            {
                MessageBox.Show("Search bar cant be empty!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (cbFilters.Text == "Person ID")
            {
                if (clsPerson.isExist(Convert.ToInt32(txtBoxSearch.Text)))
                {
                    //clsPerson person1 = clsPerson.loadPersonInfo(Convert.ToInt32(txtBoxSearch.Text));
                    //userCtrlPersonCard1.populatePersonCard(person1.PersonID);
                    _currentlySelectedPerson = clsPerson.loadPersonInfo(Convert.ToInt32(txtBoxSearch.Text));
                    _currentPersonId = _currentlySelectedPerson.PersonID;
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

                    //clsPerson person1 = clsPerson.loadPersonInfo(txtBoxSearch.Text);
                    //userCtrlPersonCard1.populatePersonCard(person1.PersonID);

                    _currentlySelectedPerson = clsPerson.loadPersonInfo(txtBoxSearch.Text);
                    _currentPersonId = _currentlySelectedPerson.PersonID;
                    userCtrlPersonCard1.populatePersonCard(_currentlySelectedPerson.PersonID);
                }
                else
                {
                    MessageBox.Show($"Can't find National No. ID=[{txtBoxSearch.Text}]");
                }
            }

            if (cbFilters.Text == "Full Name")
            {
                if (clsPerson.isExistFullName(txtBoxSearch.Text))
                {
                    _currentlySelectedPerson = clsPerson.loadPersonInfoByFullName(txtBoxSearch.Text);
                    _currentPersonId = _currentlySelectedPerson.PersonID;
                    userCtrlPersonCard1.populatePersonCard(_currentlySelectedPerson.PersonID);
                }
                else
                {
                    MessageBox.Show($"Can't find Name=[{txtBoxSearch.Text}]");
                }
            }


            if (_currentlySelectedPerson != null|| _currentPersonId != -1)
            {
                lnkLblDeselectPerson.Visible = true;
            }
            else
            {
                lnkLblDeselectPerson.Visible = false;

            }

        }

        private void txtBoxSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbFilters.Text))
            {
                e.Cancel = true;
                txtBoxSearch.Focus();
                errorProvider1.SetError(txtBoxSearch, "Cannot be empty!");
                canProceed = false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxSearch,"");
                canProceed = true;
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!canProceed || _currentlySelectedPerson==null || _currentPersonId == -1)
            {
                MessageBox.Show("Save failed, enter info correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //MessageBox.Show("Success");
            tabAddUser.SelectedTab=tabLoginInfo;

        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            lnkLblDeselectPerson.Visible = false;
            
        }

        private void lnkLblDeselectPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             _currentPersonId= -1;
            userCtrlPersonCard1.populatePersonCard(-1);
            lnkLblDeselectPerson.Visible=false;
            txtBoxSearch.Text= string.Empty;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

            frmAddPerson frmAddPerson1= new frmAddPerson();
            //frmAddPerson1.personIDBack += frmAddPerson_personIDBack;
            frmAddPerson1.ShowDialog();

            _currentlySelectedPerson = clsPerson.loadPersonInfo(frmAddPerson1.obtainedPersonID);
            _currentPersonId = _currentlySelectedPerson.PersonID;
            userCtrlPersonCard1.populatePersonCard(frmAddPerson1.obtainedPersonID);
        }

        private void frmAddPerson_personIDBack(object sender, int personID)
        { 
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMode == enMode.Update)
            {
                //call metod from dataaaccess that updates user
                //show message showing that user has been updated

                clsUser userToUpdate = new clsUser(Convert.ToInt32(lblUserID.Text),
                    _currentlySelectedUser.personID,txtBoxUserName.Text, txtBoxPass.Text, chkBoxIsActive.Checked);

                if (userToUpdate.Update())
                {
                    MessageBox.Show("User updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("User update FAILED", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (isUserLinkedToPerson())
            {
                return;
            }

            if (isUserNameExist())
            {
                return;
            }

            if (isOkToSave())
            {

                //access datalayer and add new user 
                int newUserID = -1;
                clsUser user1 = new clsUser(_currentPersonId, txtBoxUserName.Text, txtBoxPass.Text,
                    chkBoxIsActive.Checked);

                 newUserID = user1.Add();
                lblUserID.Text=newUserID.ToString();

                MessageBox.Show("User added successfully.","User Added",MessageBoxButtons.OK,MessageBoxIcon.Information);
                disableEntriesAfterSaving();
            }
            else
            {
                MessageBox.Show("Info entered is incomplete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void userCtrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
