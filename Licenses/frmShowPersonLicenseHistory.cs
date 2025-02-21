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
    public partial class frmShowPersonLicenseHistory : Form
    {
        private clsPerson _person = new clsPerson();
        private DataView _dvLocal = new DataView();
        private DataTable _dtLocal = new DataTable();

        private DataView _dvIntl = new DataView();
        private DataTable _dtIntl = new DataTable();
        public frmShowPersonLicenseHistory(string nationalNo)
        {
            InitializeComponent();
            userCtrlPersonSelector1.populateCard(nationalNo);
            _person = clsPerson.loadPersonInfo(nationalNo);
        }

        public frmShowPersonLicenseHistory(int personID)
        {
            InitializeComponent();
            _person = clsPerson.loadPersonInfo(personID);
            userCtrlPersonSelector1.populateCard(_person._NationalNum);
        }

        private void _getLocalLicenseHistory()
        {
            _dtLocal = clsLocalDrivingLicenseApplications.getLicenseHistory(_person.PersonID);
            
            //foreach (DataRow dr in _dtLocal.Rows)
            //{
            //    dr[2] = clsBusinessInfo.getLicenseClassName((int)dr[2]);
            //}
            
            _dvLocal = _dtLocal.DefaultView;

            dataGridView1.DataSource = _dvLocal;
        }
        private void _getIntlLicenseHistory()
        {
            _dtIntl = clsIntlLicenses.getIntlLicensesByPersonID(_person.PersonID);
            try
            {
                _dtIntl.Columns[2].ColumnName = "Local LicenseID";

            }
            catch (System.IndexOutOfRangeException ex)
            {

            }
            _dvIntl = _dtIntl.DefaultView;
            

            dataGridView2.DataSource = _dvIntl;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            _getIntlLicenseHistory();
            _getLocalLicenseHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCount.Text=dataGridView1.Rows.Count.ToString();
        }

        private void tabInternational_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void userCtrlPersonSelector1_Load(object sender, EventArgs e)
        {

        }

        private int getSelectedLicID()
        {
            return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }
        private int getSelectedIntlLicID()
        {
            return Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (dataGridView1.Rows.Count == 0)
                return;

            int licenseID = getSelectedLicID();

            frmShowLicense frm1 = new frmShowLicense(licenseID);
            frm1.ShowDialog();
        }

        private void showIntlLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count==0)
                return;

            int intlLicenseID=getSelectedIntlLicID();

            frmShowIntlDrivLic frm1 = new frmShowIntlDrivLic(intlLicenseID);
            frm1 .ShowDialog();
        }
    }
}
