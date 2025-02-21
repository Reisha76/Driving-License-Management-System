using DVLD_Business;
using My_DVLD.Screens_People;
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
    public partial class frmManageTestTypes : Form
    {
        DataTable source=new DataTable();
        DataView dataview1=new DataView();

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCounter.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCounter.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            refreshTestTypes();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[3].HeaderText = "Fees";

        }

        public void refreshTestTypes()
        {
            source = clsTestTypes.loadTestTypes();
            dataview1 = source.DefaultView;
            dataGridView1.DataSource = dataview1;
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testTypeID= Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);

            frmEditTestTypes frm1=new frmEditTestTypes(testTypeID);
            frm1.populateTestTypeCard();
            frm1.ShowDialog();
            refreshTestTypes();
        }
    }
}
