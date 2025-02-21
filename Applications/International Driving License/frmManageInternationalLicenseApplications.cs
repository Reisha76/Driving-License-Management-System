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
    public partial class frmManageInternationalLicenseApplications : Form
    {
        private DataTable _src=new DataTable();
        private DataView _dv=new DataView();

        public frmManageInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordCount.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void getIntlLicenses()
        { 
            _src = clsIntlLicenses.getAllIntlLicenses();
            _dv = _src.DefaultView;

            dataGridView1.DataSource = _dv;
        }

        private void frmInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            getIntlLicenses();
        }

        private void btnAddIntlLicApp_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication frm1=
                new frmInternationalLicenseApplication();
            frm1.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getSelectedPersonID()
        {
            if (isDataGridEmpty())
                return -1;

            int driverID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            clsDriver driver1 = clsDriver.getDriverInfo(driverID);

            return driver1.personID;
        }
        private bool isDataGridEmpty()
        {
            return dataGridView1.Rows.Count == 0 ? true : false;
        }
        private int getSelectedLocalLicenseID()
        {
            if(isDataGridEmpty())
                return -1;

            int driverID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            return driverID;
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = getSelectedPersonID();

            if ( personID == -1) 
                return;

            frmPersonCard frm1 = new frmPersonCard(personID);
            frm1.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = getSelectedLocalLicenseID();

            if (licenseID == -1)
                return;

            frmShowLicense frm1 = new frmShowLicense(licenseID);
            frm1.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = getSelectedPersonID();

            if (personID == -1)
                return;

            clsPerson p1 = clsPerson.loadPersonInfo(personID);


            frmShowPersonLicenseHistory frm1 = new frmShowPersonLicenseHistory(p1._NationalNum);
            frm1.ShowDialog();
        }
        private int getSelectedIntlLicenseID()
        { 
        if (isDataGridEmpty())
                return -1;

            return (int) dataGridView1.SelectedRows[0].Cells[0].Value;
        }
        private void deleteLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDataGridEmpty())
                return;
            
            clsIntlLicenses license = clsIntlLicenses.getIntlLicense(getSelectedIntlLicenseID());
            if (license.Delete())
            {
                MessageBox.Show("License deleted successfully","Success",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                getIntlLicenses();
            }
            else
                MessageBox.Show("This license is referenced elsewhere in the system, cannot delete"
                    ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
