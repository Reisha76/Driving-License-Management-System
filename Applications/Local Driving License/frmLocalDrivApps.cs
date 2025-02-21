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
    public partial class frmLocalDrivApps : Form
    {
        DataTable source;
        DataView dataView1;

        private int _currentlySelectedLocalAppID = -1;
        private int _currentlySelectedAppID = -1;
        public frmLocalDrivApps()
        {
            InitializeComponent();
        }

        private void frmLocalDrivApps_Load(object sender, EventArgs e)
        {
            refreshDataGrid();

            dataGridView1.Columns[0].HeaderText = "L.D.L.AppID";
            dataGridView1.Columns[1].HeaderText = "Driving Class";
            dataGridView1.Columns[2].HeaderText = "National No.";
            dataGridView1.Columns[3].HeaderText = "Full Name";
            dataGridView1.Columns[4].HeaderText = "Application Date";
            dataGridView1.Columns[5].HeaderText = "Passed Tests";
            dataGridView1.Columns[6].HeaderText = "Status";

            cbFilters.Text = "None";

            changeMask();
            txtBoxSearch.Visible = false;
        }

        private void refreshDataGrid()
        {
            source = clsMisc.loadLocalAppsView();
            dataView1 = source.DefaultView;
            dataGridView1.DataSource = dataView1;
        }

        private void changeMask()
        {
            if (cbFilters.Text == "None")
            {
                txtBoxSearch.Visible = false;
                cbStatus.Visible= false;
                txtBoxSearch.Text = string.Empty;
                return;
            }
            if (cbFilters.Text == "Status")
            {
                txtBoxSearch.Visible = false;
                cbStatus.Visible = true;
                return;
            }

            else
            {
                txtBoxSearch.Visible = true;
                cbStatus.Visible = false;
                txtBoxSearch.Text=string.Empty;
                dataView1.RowFilter = string.Empty;
                return;

            }
        }

        private int getSelectedLocalApplicationID()
        {
            int LDLAppID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            return LDLAppID;
        }

        private int getSelectedApplicationID()
        {
           return clsApplication.getAppIDUsingLDLAppID(getSelectedLocalApplicationID());
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCount.Text=dataGridView1.Rows.Count.ToString();
        }

        private void btnAddNewApp_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivLic frm1=new frmAddNewLocalDrivLic();
            frm1.ShowDialog();

            refreshDataGrid();
        }

        private void searchFilter()
        {
            if (string.IsNullOrWhiteSpace(cbFilters.Text))
            {
                dataView1.RowFilter = string.Empty;
            }

            if (cbFilters.Text == "L.D.L.AppID")
            {
                dataView1.RowFilter = $"CONVERT(LocalDrivingLicenseApplicationID,System.String) Like '{txtBoxSearch.Text}%'";
            }

            if (cbFilters.Text == "National No.")
            {
                dataView1.RowFilter = $"NationalNo Like '{txtBoxSearch.Text}%'";
            }

            if (cbFilters.Text == "Full Name")
            {
                dataView1.RowFilter = $"FullName Like '{txtBoxSearch.Text}%'";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchFilter();
        }

        private void cbFilters_TextChanged(object sender, EventArgs e)
        {
            changeMask();

        }

        private void cbFilters_SelectedValueChanged(object sender, EventArgs e)
        {
            changeMask();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.Text == "Status")
            {
                if (cbStatus.Text == "Completed")
                {
                    dataView1.RowFilter = $"Status = 'Completed'";
                }
                else if (cbStatus.Text == "New")
                {
                    dataView1.RowFilter = $"Status = 'New'";
                }
                else if (cbStatus.Text == "Cancelled")
                {
                    dataView1.RowFilter = $"Status = 'Cancelled'";
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dialogResult == DialogResult.No)
                return;

            int LDLAppID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            int appID = -1;
            //load application object THEN cancel it
            clsApplication app1= new clsApplication();
            appID = clsApplication.getAppIDUsingLDLAppID(LDLAppID);

            app1=app1.loadApplication(appID);

            if (app1.Cancel())
            {
                MessageBox.Show("Application cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataGrid();
                return;
            }
            else
            {
                MessageBox.Show("Application was NOT cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentlySelectedLocalAppID = getSelectedLocalApplicationID();
            _currentlySelectedAppID=getSelectedApplicationID();

            frmVisionTestAppointment frm1 = new frmVisionTestAppointment(_currentlySelectedLocalAppID,_currentlySelectedAppID);
            frm1.ShowDialog();
            
        refreshDataGrid();
        }

        private int _getPassedTestsCountForSelectedRow()
        {
            return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void scheduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void _enableAllowedCMs()
        {
            cmEditApplication.Enabled = true;
            cmDeleteApp.Enabled = true;
            cmCancelApp.Enabled = true;
            cmIssueDrvLic.Enabled = false;
            cmShowLicense.Enabled = false;
            cmShowPersonLicenseHistory.Enabled = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //prevent cancelled from schedulign tests
            if(dataGridView1.Rows.Count==0)
            {
                cmEditApplication.Enabled = false;
                cmDeleteApp.Enabled = false;
                cmCancelApp.Enabled = false;
                cmScheduleTests.Enabled = false;
                cmIssueDrvLic.Enabled = false;
                cmShowLicense.Enabled = false;
                cmShowPersonLicenseHistory.Enabled = false;
                return;
            }

            if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Cancelled")
            {
                //cmSched
                cmEditApplication.Enabled = false;
                cmCancelApp.Enabled = false;
                cmScheduleTests.Enabled = false;
                cmIssueDrvLic.Enabled = false;
                cmShowLicense.Enabled = false;
                cmShowPersonLicenseHistory.Enabled = false;
                return;
            }

            cmIssueDrvLic.Enabled = false;
            //cmScheduleTests.Enabled = true;
            cmShowLicense.Enabled = false;
            cmShowPersonLicenseHistory.Enabled = false;

            if ((string)dataGridView1.SelectedRows[0].Cells[6].Value == "Completed")
            { 
                cmEditApplication.Enabled = false;
                cmDeleteApp.Enabled = false;
                cmCancelApp.Enabled = false;
                cmScheduleTests.Enabled=false;
                cmIssueDrvLic.Enabled=false;
                
                cmShowLicense.Enabled = true;
                cmShowPersonLicenseHistory.Enabled = true;
            }

            else if (_getPassedTestsCountForSelectedRow() == 0)
            {
                cmScheduleTests.Enabled = true;
                cmVisionTest.Enabled = true;
                cmWrittenTest.Enabled = false;
                cmStreetTest.Enabled = false;
                _enableAllowedCMs();
            }
            else if (_getPassedTestsCountForSelectedRow() == 1)
            {
                cmScheduleTests.Enabled = true;
                cmVisionTest.Enabled = false;
                cmWrittenTest.Enabled = true;
                cmStreetTest.Enabled = false;

                _enableAllowedCMs();
            }
            else if (_getPassedTestsCountForSelectedRow() == 2)
            {
                cmScheduleTests.Enabled = true;
                cmVisionTest.Enabled = false;
                cmWrittenTest.Enabled = false;
                cmStreetTest.Enabled = true;

                _enableAllowedCMs();

            }
            else if (_getPassedTestsCountForSelectedRow() == 3)
            {
                cmScheduleTests.Enabled = false;
                cmIssueDrvLic.Enabled = true;

            }

        }

        private bool _canIssueDrivingLicense()
        {
            if (((int)dataGridView1.SelectedRows[0].Cells[5].Value == 3) &&
                ((string)dataGridView1.SelectedRows[0].Cells[6].Value != "Cancelled"))
            {
                return true;
            }
            else
                return false;
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentlySelectedLocalAppID = getSelectedLocalApplicationID();
            _currentlySelectedAppID = getSelectedApplicationID();

            if (_canIssueDrivingLicense())
            {
                frmIssueDrivLicFirstTime frm1 = new
                    frmIssueDrivLicFirstTime(_currentlySelectedLocalAppID,
                    _currentlySelectedAppID);
                frm1.ShowDialog();
                refreshDataGrid();
            }
            else
                return;
        }

        private void cmWrittenTest_Click(object sender, EventArgs e)
        {
            _currentlySelectedLocalAppID = getSelectedLocalApplicationID();
            _currentlySelectedAppID = getSelectedApplicationID();

            frmWrittenTestAppointments frm1 = new frmWrittenTestAppointments(_currentlySelectedLocalAppID, _currentlySelectedAppID);
            frm1.ShowDialog();

            refreshDataGrid();
        }

        private void cmStreetTest_Click(object sender, EventArgs e)
        {
            _currentlySelectedLocalAppID = getSelectedLocalApplicationID();
            _currentlySelectedAppID = getSelectedApplicationID();

            frmStreetTestAppointments frm1 = new frmStreetTestAppointments(_currentlySelectedLocalAppID, _currentlySelectedAppID);
            frm1.ShowDialog();

            refreshDataGrid();
        }

        private void cmShowLicense_Click(object sender, EventArgs e)
        {

            _currentlySelectedAppID = getSelectedApplicationID();

            frmShowLicense frm1 = new 
                frmShowLicense(clsLicense.getLicenseID(_currentlySelectedAppID));
            frm1.ShowDialog();
        }

        private string getSelectedNationalNo()
        {
            return dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void cmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {


            frmShowPersonLicenseHistory frm1 = new frmShowPersonLicenseHistory(getSelectedNationalNo());
            frm1.ShowDialog();
            refreshDataGrid();
        }

        private void cmEditApplication_Click(object sender, EventArgs e)
        {
            //frmAddNewLocalDrivLic frm1 = new frmAddNewLocalDrivLic(getSelectedNationalNo());
            //frm1.ShowDialog();
        }

        private void cmShowApplication_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivLic frm1 = new frmAddNewLocalDrivLic(getSelectedNationalNo());
            frm1.ShowDialog();
        }

        private void cmDeleteApp_Click(object sender, EventArgs e)
        {
            //drop from LDLApps table and LDLAppsView table
            if (dataGridView1.Rows.Count == 0)
                return;
            if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Completed")
                return;
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this application?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                if (result == DialogResult.No)
                    return;
                else
                {
                    clsLocalDrivingLicenseApplications app1 = clsLocalDrivingLicenseApplications.getLocalAppInfo(getSelectedLocalApplicationID());

                    if (app1.Delete())
                    {
                        MessageBox.Show("Application deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshDataGrid();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Application was NOT deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }

        }
    }
}
