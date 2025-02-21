using DVLD_Business;
using My_DVLD.Properties;
using My_DVLD.Screens_People;
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
    public partial class userCtrlPersonCard : UserControl
    {
        private int _personID = -1;
        public int personID
        {
            get { return _personID; }
        }

        private clsPerson _person;
        public clsPerson selectedPersonInfo
        {
            get { return _person; }
        }

        //clsPerson person1 = clsPerson.loadPersonInfo(frmPersonCard.PersonID);

        public userCtrlPersonCard()
        {
            InitializeComponent();
        }

        private void updatePersonCard()
        {
            _person = clsPerson.loadPersonInfo(personID);//refresh info

            lblName.Text = _person._FirstName + " " + _person._SecondName + " " + _person._ThirdName +
                " " + _person._LastName;

            lblAddress.Text = _person._Address;
            lblEmail.Text = _person._Email;
            lblPhone.Text = _person._Phone;
            lblNationalNo.Text = _person._NationalNum;
            lblCountry.Text = clsBusinessInfo.getCountryNameByID(_person._NationalityCountryID);
            lblDateOfBirth.Text = _person._DateOfBirth.ToString();
            if (_person._Gendor == 0)
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";

            pbPersonImage.ImageLocation = _person._ImagePath;
        }
        private void lnkLblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_person == null)
                return;
            Form frmEditPerson = new frmUpdatePerson(_person.PersonID);
            frmEditPerson.ShowDialog();

            updatePersonCard();
            populatePersonCard(_person.PersonID);
        }

        public void populatePersonCard(string nationalNo)
        { 
            _person = clsPerson.loadPersonInfo(nationalNo);
            _personID = _person.PersonID;

            if (_personID == -1)
            {
                _fillEmptyPerson();
                return;
            }

            _fillPersonInfo();
        }

        public void populatePersonCard(int personID)
        {
            _person = clsPerson.loadPersonInfo(personID);
            _personID = _person.PersonID;

            if (_personID == -1)
            {
                _fillEmptyPerson();
                return;
            }
            
            _fillPersonInfo();
        }

        private void _fillPersonInfo()
        {
            lblName.Text = _person._FirstName + " " + _person._SecondName +
        " " + _person._ThirdName + " " + _person._LastName;

            lblCountry.Text = clsBusinessInfo.getCountryNameByID(_person._NationalityCountryID);

            lblPersonID.Text = _person.PersonID.ToString();
            lblNationalNo.Text = _person._NationalNum.ToString();
            lblAddress.Text = _person._Address;
            lblEmail.Text = _person._Email;
            lblPhone.Text = _person._Phone;
            lblDateOfBirth.Text=_person._DateOfBirth.ToShortDateString();

            lblGender.Text = _person._Gendor == 0 ? "Male" : "Female";

            if (string.IsNullOrEmpty(_person._ImagePath))
            {
                if (lblGender.Text == "Male")
                    pbPersonImage.Image = Resources.man;
                else
                    pbPersonImage.Image=Resources.woman;
            }
            else
                pbPersonImage.ImageLocation = _person._ImagePath;
        }

        private void _fillEmptyPerson()
        {

                lblName.Text = "[???]";
                lblCountry.Text = "[???]";
                lblPersonID.Text = "[???]";
                lblNationalNo.Text = "[???]";
                lblAddress.Text = "[???]";
                lblEmail.Text = "[???]";
                lblPhone.Text = "[???]";
                lblDateOfBirth.Text = "[???]";
                lblGender.Text = "[???]";
                pbPersonImage.Image = Resources.man;
            

        }

        private void userCtrlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
