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
using System.IO;

namespace My_DVLD
{
    public partial class ctrlAddPerson : UserControl
    {
        bool errorFlag = true;
        //int errorCounter = 0;
        string userImagesPath = @"H:\Abu-HadhoudDATA\DVLDUsersImages";
        string selectedImagePath = "";
        string addedPersonsImgFolder = "";
        private int _addedPersonID;

        public int addedPersonID { get { return _addedPersonID; } }

        private void setDefaultImageIfEmptyPath()
        {
            if (string.IsNullOrWhiteSpace(selectedImagePath))
            {

                if (rbFemale.Checked)
                {
                    pictureBox1.Image = Resources.woman;
                }
                if (rbMale.Checked)
                    pictureBox1.Image = Resources.man;
            }
        }

        private void disableAllFields()
        {
            btnSave.Enabled = false;
            txtBoxFirstName.Enabled = false;
            txtBoxSecondName.Enabled = false;
            txtBoxThirdName.Enabled = false;
            txtBoxLastName.Enabled = false;
            txtBoxPhone.Enabled = false;
            txtBoxEmail.Enabled = false;
            txtBoxAddress.Enabled = false;
            rbFemale.Enabled = false;
            rbMale.Enabled = false;
            txtBoxNationalNo.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            linkLabel1.Enabled = false;
        }

        public ctrlAddPerson()
        {
            InitializeComponent();
            comboBox1.ValueMember = "CountryName";
            comboBox1.DataSource = clsBusinessInfo.loadCountriesList();
        }

        private void ctrlAddPerson_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 49;//set default country to Egypt
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);
        }

        private void txtBoxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxFirstName.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxFirstName.Focus();
                errorProvider1.SetError(txtBoxFirstName, "FirstName must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;
                errorProvider1.SetError(txtBoxFirstName, "");
            }
        }

        private void txtBoxSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxSecondName.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxSecondName.Focus();
                errorProvider1.SetError(txtBoxSecondName, "SecondName must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;

                errorProvider1.SetError(txtBoxSecondName, "");
            }
        }

        private void txtBoxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLastName.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxLastName.Focus();
                errorProvider1.SetError(txtBoxLastName, "LastName must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;
                errorProvider1.SetError(txtBoxLastName, "");
            }
        }

        private void txtBoxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            //if National no is empty
            if (string.IsNullOrWhiteSpace(txtBoxNationalNo.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxNationalNo.Focus();
                errorProvider2.SetError(txtBoxNationalNo, "National No must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;
                errorProvider2.SetError(txtBoxNationalNo, "");
            }

            //if national no already exists
            if (clsPerson.isExist(txtBoxNationalNo.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxNationalNo.Focus();
                errorProvider1.SetError(txtBoxNationalNo, "National No already exists!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;
                errorProvider1.SetError(txtBoxNationalNo, "");
            }
        }

        private void txtBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxPhone.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxPhone.Focus();
                errorProvider1.SetError(txtBoxPhone, "Phone must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;
                errorProvider1.SetError(txtBoxPhone, "");
            }
        }
        private void txtBoxEmail_Validating(object sender, CancelEventArgs e)
        {//BELOW ME HERE!
            if (!clsMisc.isValidEmail(txtBoxEmail.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxEmail.Focus();
                errorProvider1.SetError(txtBoxEmail, "Invalid Email format!");
            }
            else
            {  
                e.Cancel = false;
                errorFlag = false;
                errorProvider1.SetError(txtBoxEmail, "");
            }
        }

        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            
            setDefaultImageIfEmptyPath();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            setDefaultImageIfEmptyPath();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Set Image";
            openFileDialog1.DefaultExt = "Image Files |*.jpg;*.jpeg,*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog1.FileName;
                //MessageBox.Show(openFileDialog1.FileName);
                pictureBox1.ImageLocation = selectedImagePath;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            selectedImagePath = pictureBox1.ImageLocation;
        }

        private void txtBoxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxAddress.Text))
            {
                e.Cancel = true;
                errorFlag = true;
                txtBoxAddress.Focus();
                errorProvider1.SetError(txtBoxAddress, "Address cannot be empty!");
            }
            else
            {
                e.Cancel = false;
                errorFlag = false;
                errorProvider1.SetError(txtBoxAddress, "");
            }
        }

        private bool isNotOKToSave()
        {
            return errorFlag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isNotOKToSave())
            {
                MessageBox.Show("Invalid input! Make sure all data is entered correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            //find countryID using countryname first
            int countryID = clsBusinessInfo.getCountryIDByName(comboBox1.Text);
            int gender = 0;
            int newPersonID = -1;

            

            if (rbFemale.Checked)
            { 
            gender = 1;
            }
            else
                gender = 0;

            if (!string.IsNullOrWhiteSpace(selectedImagePath))
            {
                addedPersonsImgFolder = Path.Combine(userImagesPath, Guid.NewGuid().ToString() + ".png");

               File.Copy(selectedImagePath,addedPersonsImgFolder);
            }

            clsPerson person1 = new clsPerson(-1, countryID, gender, txtBoxNationalNo.Text,
                txtBoxFirstName.Text, txtBoxSecondName.Text, txtBoxThirdName.Text,
                txtBoxLastName.Text, txtBoxPhone.Text, txtBoxEmail.Text,
                txtBoxAddress.Text, addedPersonsImgFolder,
                dateTimePicker1.Value);

            newPersonID = person1.Add();
            _addedPersonID = newPersonID;
            if ( newPersonID!=-1)
            {
                MessageBox.Show("Person added succesfully!","Added",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Person was NOT added succesfully", "Failed", MessageBoxButtons.OK, MessageBoxIcon.
                    Error);
            }
            lblPersonID.Text=newPersonID.ToString();

            disableAllFields();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void lnkLblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedImagePath = "";
            pictureBox1.ImageLocation = "";
            setDefaultImageIfEmptyPath();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
