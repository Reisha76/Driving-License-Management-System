using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DVLD_Business;
namespace My_DVLD
{
    public partial class frmManagePeople : Form
    {
        DataView dataView1=new DataView();
        DataTable source=new DataTable();
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void genderSearch()
        {
            if (cbGender.SelectedItem.ToString() == "Male")
            {
                dataView1.RowFilter = "Gender = 'Male'";
            }
            else
            {
                dataView1.RowFilter = "Gender = 'Female'";

            }
        }

        private void searchFilter()
        {
            if (string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                dataView1.RowFilter = string.Empty;
            }

            if (cbSearch.Text == "PersonID")
            {
                dataView1.RowFilter = $"CONVERT(PersonID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Phone")
            {
                dataView1.RowFilter = $"CONVERT(Phone,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "National No.")
            {
                dataView1.RowFilter = $"NationalNo like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Nationality")
            {
                dataView1.RowFilter = $"Nationality like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Email")
            {
                dataView1.RowFilter = $"Email like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Gendor")
            {
                genderSearch();
            }

            if (cbSearch.Text == "First Name")
            {
                dataView1.RowFilter = $"FirstName like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Second Name")
            {
                dataView1.RowFilter = $"SecondName like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Third Name")
            {
                dataView1.RowFilter = $"ThirdName like '{txtBoxSearch.Text}%' ";
            }

            if (cbSearch.Text == "Last Name")
            {
                dataView1.RowFilter = $"LastName like '{txtBoxSearch.Text}%' ";
            }
        }

        private void refreshDataGridView()
        {
            source = clsBusinessInfo.loadPeopleViewFromDB();
            dataView1 = source.DefaultView;
            dataGridView1.DataSource = dataView1;
        }

        private void changeMask()
        {
            if (cbSearch.Text == "Gendor")
            {
                txtBoxSearch.Visible = false;
                cbGender.Visible = true;
                return;
            }

            if (cbSearch.Text == "None")
            {
                dataView1.RowFilter = string.Empty;
                txtBoxSearch.Text = string.Empty;
                txtBoxSearch.Visible = false;

            }
            else
            {
                txtBoxSearch.Visible = true;
                cbGender.Visible = false;
            }

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            source = clsBusinessInfo.loadPeopleViewFromDB();
            dataView1 = source.DefaultView;
            dataGridView1.DataSource = dataView1;
            txtBoxSearch.Visible = false;
            cbGender.Visible = false;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        { 
            changeMask();
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearch.Text == "PersonID" || cbSearch.Text=="Phone")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                {
                    e.Handled = true;
                }
            }

        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchFilter();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCounter.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCounter.Text = dataGridView1.Rows.Count.ToString();
            
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            //clsPerson p1= clsPerson.loadPersonInfo(dataGridView1.SelectedCells)
            int ID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            Form frmPersonInfo = new frmPersonCard(ID);
            frmPersonInfo.ShowDialog();

            refreshDataGridView();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frm=new frmAddPerson();
            frm.ShowDialog();

            refreshDataGridView();
        }

        private void cmRecordOptions_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsmEditPerson_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            Form frmUpdatePerson = new frmUpdatePerson(ID);
            frmUpdatePerson.ShowDialog();

            refreshDataGridView();
        }

        private void cbGender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchFilter();
        }

        private void managePeopleBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddPerson frm1 = new frmAddPerson();
            frm1.ShowDialog();
            refreshDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Call feature is not available in this version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email feature is not available in this version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
