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
    public partial class frmAddPerson : Form
    {
        private int _obtainedPersonID; 
        public int obtainedPersonID { get { return _obtainedPersonID; } }

        public frmAddPerson()
        {
            InitializeComponent();
        }

        private void frmAddPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            _obtainedPersonID=ctrlAddPerson1.addedPersonID;
        }
    }
}
