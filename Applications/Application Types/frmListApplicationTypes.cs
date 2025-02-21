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
    public partial class frmListApplicationTypes : Form
    {
        DataTable source=new DataTable();
        DataView dataView1 = new DataView();

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCounter.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCounter.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            source = clsMisc.loadApplicationTypes();

            dataView1 = source.DefaultView;

            dataGridView1.DataSource = dataView1;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Fees";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getSelectedApplicationTypeID()
        {
            int applicationID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            return applicationID;
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationID=getSelectedApplicationTypeID();

            frmEditApplicationType frm1=new frmEditApplicationType(applicationID);
            frm1.populateEditAppCard();
            frm1.ShowDialog();
            refreshDataGridView();
        }

        private void refreshDataGridView()
        {
            source = clsMisc.loadApplicationTypes();
            dataView1 = source.DefaultView;
            dataGridView1.DataSource = dataView1;
        }
    }
}
