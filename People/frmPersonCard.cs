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
    public partial class frmPersonCard : Form
    {
        private int _personID { get; set; }
        private clsPerson _person {  get; set; }
        public frmPersonCard(int personID)
        {
            InitializeComponent();
            _personID = personID;

        }

        public frmPersonCard(string nationalNo)
        {
            InitializeComponent();
            _person = clsPerson.loadPersonInfo(nationalNo);
            _personID = _person.PersonID;
        }

        private void userCtrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void frmPersonCard_Load(object sender, EventArgs e)
        {
            _person = clsPerson.loadPersonInfo(_personID);
            if (!clsPerson.isExist(_person.PersonID))
            {
                MessageBox.Show($"Person with ID {_person.PersonID} doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            userCtrlPersonCard1.populatePersonCard(_person.PersonID);

        }
    }
}
