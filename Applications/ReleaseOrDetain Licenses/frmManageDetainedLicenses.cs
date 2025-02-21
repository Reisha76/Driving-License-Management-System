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
    public partial class frmManageDetainedLicenses: Form
    {
        private DataTable src = new DataTable();
        private DataView dv = new DataView();

        private clsLicense _license = new clsLicense();
        private clsPerson _person = new clsPerson();

        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _refreshDataGrid()
        {
            src = clsDetainedLicenses.getAllDetainedLicenses();
            dv = src.DefaultView;
            dataGridView1.DataSource = dv;
        }

        private void _changeSearchBoxVisibility()
        {

            if (cbFilters.Text == "None")
            {
                txtBoxSearch.Visible = false;
                return;
            }
            else if (cbFilters.Text == "Is Released")
            { 
                cbReleased.Visible = true;
                txtBoxSearch.Visible = false;
            }
            else
            {
                txtBoxSearch.Visible = true;
                cbReleased.Visible = false;
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changeSearchBoxVisibility();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                dv.RowFilter = string.Empty;
            }

            if (cbFilters.Text == "Detain ID")
            {
                dv.RowFilter = $"CONVERT(DetainID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilters.Text == "Is Released")
            {
                dv.RowFilter = string.Empty;
                

                if(cbReleased.Text== "Detained")
                {
                    dv.RowFilter = $"IsReleased = 'False'";
                }
                else if(cbReleased.Text == "Released")
                {
                    dv.RowFilter = $"IsReleased = 'True'";
                }
            }

            if (cbFilters.Text == "Release Application ID")
            {

                dv.RowFilter = $"CONVERT(ReleaseApplicationID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilters.Text == "National No.")
            {
                dv.RowFilter = $"[NationalNo] like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilters.Text == "Full Name")
            {
                dv.RowFilter = $"[FullName] like '{txtBoxSearch.Text}%' ";
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.Text == "Release Application ID" || cbFilters.Text == "Detain ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                {
                    e.Handled = true;
                }
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm1 = new frmReleaseLicense();
            frm1.ShowDialog();
            _refreshDataGrid();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm1 = new frmDetainLicense();
            frm1.ShowDialog();
            _refreshDataGrid();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _refreshDataGrid();
            txtBoxSearch.Visible = false;
            cbReleased.Visible = false;
            cbReleaseLicense.Enabled = false;

            cbFilters.SelectedIndex = 0;
        }

        private bool isDataGridEmpty()
        {
            if (dataGridView1.Rows.Count == 0)
                return true;
            else
                return false;
        }

        private string _getSelectedNationalNo()
        {

            if (isDataGridEmpty())
                return "";

            string nationalNo= Convert.ToString(dataGridView1.SelectedRows[0].Cells[6].Value);
            return nationalNo;
        }

        private int _getSelectedLicenseID()
        {
            if (isDataGridEmpty())
                return -1;

            int licenseID= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            return licenseID;
        }
        private void cbShowPersonDetails_Click(object sender, EventArgs e)
        {
            string nationalNo=_getSelectedNationalNo();

            if (nationalNo == "")
                return;

            frmPersonCard frm1 = new frmPersonCard(nationalNo);
            frm1.ShowDialog();
            _refreshDataGrid();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicense frm1 = new frmShowLicense(_getSelectedLicenseID());
            frm1.ShowDialog();
            _refreshDataGrid();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nationalNo = _getSelectedNationalNo();
            if(nationalNo == "")
                return;

            frmShowPersonLicenseHistory frm1 = new frmShowPersonLicenseHistory(nationalNo);
            frm1.ShowDialog();
            _refreshDataGrid();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //check if lic is detained, enable releaseDetainLicense. 
            //else keep it disabled
            _license = clsLicense.getLicense(_getSelectedLicenseID());

            if (clsLicense.isLicenseDetained(_license.licenseID))
                cbReleaseLicense.Enabled = true;
            else
                cbReleaseLicense.Enabled = false;
        }
    }
}
