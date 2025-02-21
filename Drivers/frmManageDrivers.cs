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
    public partial class frmManageDrivers : Form
    {
        private DataTable _dt = new DataTable();
        private DataView _dv = new DataView();

        public frmManageDrivers()
        {
            InitializeComponent();

            _dt =clsDriver.getAllDriversRecords();
            _dv=_dt.DefaultView;
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtBoxSearch.Visible = false;
            dataGridView1.DataSource = _dv;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCount.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void changeSearchBoxAndActiveComboBoxVisibility()
        {
            if (cbFilter.Text == "None")
            {
                txtBoxSearch.Visible = false;
                return;
            }
            else
            {
                txtBoxSearch.Visible = true;
            }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                _dv.RowFilter = string.Empty;
            }

            if (cbFilter.Text == "DriverID")
            {
                _dv.RowFilter = $"CONVERT(DriverID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilter.Text == "PersonID")
            {

                _dv.RowFilter = $"CONVERT(PersonID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilter.Text == "National No.")
            {
                _dv.RowFilter = $"[NationalNo] like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilter.Text == "Full Name")
            {
                _dv.RowFilter = $"[FullName] like '{txtBoxSearch.Text}%' ";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeSearchBoxAndActiveComboBoxVisibility();
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "PersonID" || cbFilter.Text == "DriverID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                {
                    e.Handled = true;
                }
            }
        }
    }
}
