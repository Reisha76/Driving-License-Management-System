using DVLD_Business;
using My_DVLD.Screens_People.formModes;
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
    public partial class frmWrittenTestAppointments : Form
    {
        private DataView dataView1 = new DataView();
        private DataTable dataTable1 = new DataTable();
        private int _LDLAppID;
        private int _appID;

        public frmWrittenTestAppointments(int LDLAppID,int appID)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;
            _appID = appID;

            userCtrlDrivingLicenseApp1.populateLDLAppInfo(_LDLAppID);
            userCtrlAppBasicInfo1.populateBasicInfoCard(_appID);

            dataTable1 = clsWrittenTestAppointments.getWrittenApptInfo(LDLAppID);
            dataView1 = dataTable1.DefaultView;

            dataGridView1.DataSource = dataView1;
        }

        private void _refreshDataGridView()
        {
            dataTable1 = clsWrittenTestAppointments.getWrittenApptInfo(_LDLAppID);
            dataView1 = dataTable1.DefaultView;
            dataGridView1.DataSource = dataView1;
        }

        private bool _validateNewAppointment()
        {
            if (dataView1.Count == 0)
                return true;

            foreach (DataRowView drv in dataView1)
            {
                DataRow row = drv.Row;

                if ((bool)row[3] == false || ((bool)row[3] == true && clsTest.isTestPassed((int)row[0])))
                {
                    return false;
                }
            }

            return true;
        }
        private bool _isNeedToRetakeTest()
        {
            foreach (DataRowView drv in dataView1)
            {
                DataRow row = drv.Row;

                if (clsTest.isTestPassed((int)row[0]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool _validateIsDatagridEmpty()
        {
            if (dataGridView1.Rows.Count == 0)
                return true;
            else
                return false;
        }

        private int getSelectedRowID()
        {
            int appointmentID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            return appointmentID;
        }

        private void btnAddWrittenTestAppointment_Click(object sender, EventArgs e)
        {
            if (!_validateNewAppointment())
            {
                MessageBox.Show("Applicant either has active appointment OR has passed this test!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                frmScheduleTest frm = new frmScheduleTest(_LDLAppID, frmMode.AddNewWrittenAppointment);
                frm.ShowDialog();

            }
            else if (_isNeedToRetakeTest())
            {
                frmScheduleTest frm = new frmScheduleTest(_LDLAppID, frmMode.RetakeTest,
                    getSelectedRowID());
                frm.ShowDialog();
            }
            else
            {
                frmScheduleTest frm = new frmScheduleTest(_LDLAppID, frmMode.AddNewWrittenAppointment,
                    getSelectedRowID());
                frm.ShowDialog();
            }

            _refreshDataGridView();
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            if (_validateIsDatagridEmpty())
                return;

            int selectedTestAppID = getSelectedRowID();

            clsTestAppointments testApp1 =
                clsTestAppointments.getTestAppointment(selectedTestAppID);

            if (testApp1.isLocked == true)
            {
                MessageBox.Show("Person already sat for this test, appointment is locked.",
                    "Appointment locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(_LDLAppID, selectedTestAppID);
            frm.ShowDialog();
            _refreshDataGridView();
        }

        private void cmTakeTest_Click(object sender, EventArgs e)
        {
            if (_validateIsDatagridEmpty())
                return;

            int selectedTestAppID = getSelectedRowID();

            clsTestAppointments testApp1 =
                clsTestAppointments.getTestAppointment(selectedTestAppID);

            if (testApp1.isLocked == true)
            {
                MessageBox.Show("Person already sat for this test, appointment is locked.",
                    "Appointment locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmTakeTest frm1 = new frmTakeTest(selectedTestAppID);

            frm1.ShowDialog();

            _refreshDataGridView();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCount.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
