using DVLD_Business;
using My_DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace My_DVLD
{
    public partial class userCtrlUpdatePerson : UserControl
    {
        int errorCounter = 0;
        clsPerson person1 = clsPerson.loadPersonInfo(frmUpdatePerson.PersonID);

        string originalImagePath =""; 
        string currentlySelectedImagePath="";
        string savedImagesDirectory = @"H:\Abu-HadhoudDATA\DVLDUsersImages";
        string personImagePath="";
        public userCtrlUpdatePerson()
        {

            InitializeComponent();
            originalImagePath=person1._ImagePath;
            currentlySelectedImagePath= person1._ImagePath;
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
            cbCountries.Enabled = false;
            dateTimePicker1.Enabled = false;
            lnkLblSetImage.Enabled = false;
            lnkLblRemoveImage.Enabled = false;

        }

        private void saveImageToFolder()
        {
            if (!string.IsNullOrWhiteSpace(currentlySelectedImagePath))
            {
                personImagePath = Path.Combine(savedImagesDirectory, Guid.NewGuid().ToString() + ".png");
                try
                {
                    File.Copy(currentlySelectedImagePath, personImagePath);
                }
                catch (DirectoryNotFoundException)
                {
                    if (person1._Gendor == 0)
                        personImagePath = @"H:\Abu-HadhoudDATA\DVLD_ICONS\man.png";
                    else
                        personImagePath = @"H:\Abu-HadhoudDATA\DVLD_ICONS\woman.png";
                }
            }
        }
        private void setDefaultImageIfEmptyPath()
        {
            if (string.IsNullOrWhiteSpace(currentlySelectedImagePath))
            {
                if (rbFemale.Checked)
                {
                    pictureBox1.Image = Resources.woman;
                }
                if (rbMale.Checked)
                    pictureBox1.Image = Resources.man;
            }
        }
        private void txtBoxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxFirstName.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxFirstName.Focus();
                errorProvider1.SetError(txtBoxFirstName, "FirstName must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;
                errorProvider1.SetError(txtBoxFirstName, "");
            }
        }

        private void txtBoxSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxSecondName.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxSecondName.Focus();
                errorProvider1.SetError(txtBoxSecondName, "SecondName must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;

                errorProvider1.SetError(txtBoxSecondName, "");
            }
        }

        private void txtBoxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLastName.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxLastName.Focus();
                errorProvider1.SetError(txtBoxLastName, "LastName must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;
                errorProvider1.SetError(txtBoxLastName, "");
            }
        }

        private void txtBoxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            //if National no is empty
            if (string.IsNullOrWhiteSpace(txtBoxNationalNo.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxNationalNo.Focus();
                errorProvider2.SetError(txtBoxNationalNo, "National No must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;
                errorProvider2.SetError(txtBoxNationalNo, "");
            }

            //if national no already exists
            if (clsPerson.isExist(txtBoxNationalNo.Text))
            {
                if (txtBoxNationalNo.Text != person1._NationalNum)//allow if nationalnum remains the same
                {
                    e.Cancel = true;
                    errorCounter++;
                    txtBoxNationalNo.Focus();
                    errorProvider1.SetError(txtBoxNationalNo, "National No already exists!");
                }
                else
                {
                    e.Cancel = false;
                    errorCounter--;
                    errorProvider1.SetError(txtBoxNationalNo, "");
                }

            }
            else
            {
                e.Cancel = false;
                errorCounter--;
                errorProvider1.SetError(txtBoxNationalNo, "");
            }
        }

        private void txtBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxPhone.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxPhone.Focus();
                errorProvider1.SetError(txtBoxPhone, "Phone must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;
                errorProvider1.SetError(txtBoxPhone, "");
            }
        }
        private void txtBoxEmail_Validating(object sender, CancelEventArgs e)
        {//CLSVALIDATION BELOW!
            if (!clsMisc.isValidEmail(txtBoxEmail.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxEmail.Focus();
                errorProvider1.SetError(txtBoxEmail, "Invalid Email format!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;
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

        private void txtBoxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxAddress.Text))
            {
                e.Cancel = true;
                errorCounter++;
                txtBoxAddress.Focus();
                errorProvider1.SetError(txtBoxAddress, "Address cannot be empty!");
            }
            else
            {
                e.Cancel = false;
                errorCounter--;
                errorProvider1.SetError(txtBoxAddress, "");
            }
        }

        private void userCtrlUpdatePerson_Load(object sender, EventArgs e)
        {
            cbCountries.ValueMember = "CountryName";
            cbCountries.DataSource = clsBusinessInfo.loadCountriesList();

            //cbCountries.SelectedIndex = person1._NationalityCountryID;
            cbCountries.Text = clsBusinessInfo.getCountryNameByID(person1._NationalityCountryID);
            lblPersonID.Text = person1.PersonID.ToString();
            txtBoxFirstName.Text = person1._FirstName;
            txtBoxSecondName.Text = person1._SecondName;
            txtBoxThirdName.Text = person1._ThirdName;
            txtBoxLastName.Text = person1._LastName;

            txtBoxNationalNo.Text = person1._NationalNum;
            txtBoxAddress.Text=person1._Address;
            txtBoxEmail.Text = person1._Email;
            txtBoxPhone.Text = person1._Phone;

            pictureBox1.ImageLocation = person1._ImagePath;

            dateTimePicker1.Text = person1._DateOfBirth.ToString();

            if (person1._Gendor == 0)
            {
                rbMale.Checked = true;
            }
            else
            { 
            rbFemale.Checked = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int gender = 0;
            if (rbMale.Checked)
            {
                gender = 0;
            }
            else
            {
                gender = 1;
            }

            if (!string.IsNullOrEmpty(originalImagePath))
            {

                if (currentlySelectedImagePath != originalImagePath)
                {

                    try
                    {
                        File.Delete(originalImagePath);
                    }
                    catch (System.IO.DirectoryNotFoundException)
                    {
                        MessageBox.Show("User's image path not found, delete image path from DB!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                }
            }

            saveImageToFolder();

            person1 = new clsPerson(Convert.ToInt32( lblPersonID.Text),
                clsBusinessInfo.getCountryIDByName(cbCountries.Text), gender,
                txtBoxNationalNo.Text, txtBoxFirstName.Text, txtBoxSecondName.Text,
                txtBoxThirdName.Text, txtBoxLastName.Text, txtBoxPhone.Text,
                txtBoxEmail.Text, txtBoxAddress.Text, personImagePath,
                dateTimePicker1.Value);

            if (person1.Update())
            {
                MessageBox.Show("Person Info updated successfully", "Success!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                disableAllFields();
            }
            else
            {
                MessageBox.Show("Could not update person", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lnkLblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            currentlySelectedImagePath = "";
            pictureBox1.ImageLocation = "";
            setDefaultImageIfEmptyPath();
        }

        private void lnkLblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            originalImagePath = person1._ImagePath;

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Set Image";
            openFileDialog1.DefaultExt = "Image Files |*.jpg;*.jpeg,*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentlySelectedImagePath = openFileDialog1.FileName;
                MessageBox.Show(openFileDialog1.FileName);
                pictureBox1.ImageLocation = currentlySelectedImagePath;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            currentlySelectedImagePath = pictureBox1.ImageLocation;

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            setDefaultImageIfEmptyPath();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            setDefaultImageIfEmptyPath();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void grpBoxUpdatePerson_Enter(object sender, EventArgs e)
        {

        }
    }
}
