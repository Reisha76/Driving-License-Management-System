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
    public partial class frmUpdatePerson : Form
    {
       public static int PersonID { get; set; }
        public frmUpdatePerson(int personID)
        {
            if (!clsPerson.isExist(personID))
            {
                MessageBox.Show($"Person with ID {personID} doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PersonID = personID;

            InitializeComponent();
        }
    }
}
