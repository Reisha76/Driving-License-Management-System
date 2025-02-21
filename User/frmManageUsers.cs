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
    public partial class frmManageUsers : Form
    {
        DataTable source= new DataTable();
        DataView dataview1 = new DataView();


        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void refreshDataGridView()
        {
            source = clsBusinessInfo.loadUsersViewFromDB();
            dataview1 = source.DefaultView;
            dataGridView1.DataSource = dataview1;
        }

        private void changeSearchBoxAndActiveComboBoxVisibility()
        {
            if (cbFilter.Text == "Is Active")
            { 
                txtBoxSearch.Visible=false;
                cbIsActive.Visible=true;
                return;
            }

            if (cbFilter.Text == "None")
            {
                txtBoxSearch.Visible = false;
                cbIsActive.Visible = false;
                return;

            }
            else
            { 
                txtBoxSearch.Visible = true;
                cbIsActive.Visible = false;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRecordsCount.Text=dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form frmAddUser = new frmAddUser();
            frmAddUser.ShowDialog();
            refreshDataGridView();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeSearchBoxAndActiveComboBoxVisibility();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtBoxSearch.Text))
            {
                dataview1.RowFilter = string.Empty;
            }

            if (cbFilter.Text == "Person ID")
            { 

                dataview1.RowFilter = $"CONVERT(PersonID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilter.Text == "User ID")
            {
                dataview1.RowFilter = $"CONVERT(UserID,System.String) like '{txtBoxSearch.Text}%' ";
            }

            if (cbFilter.Text == "UserName")
            {
                dataview1.RowFilter = $"UserName like '{txtBoxSearch.Text}%' ";
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);


            frmUserInfo frmUserInfo1 = new frmUserInfo(personID);
            frmUserInfo1.populateUserInfoCard();
            frmUserInfo1.ShowDialog();

            refreshDataGridView();
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "User ID" || cbFilter.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                {
                    e.Handled = true;
                }
            }
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            txtBoxSearch.Visible = false;
            cbIsActive.Visible = false;
            source = clsBusinessInfo.loadUsersViewFromDB();

            dataview1 = source.DefaultView;

            dataGridView1.DataSource = dataview1;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.Text == "All")
            { 
            dataview1.RowFilter=string.Empty;
            }
            if (cbIsActive.Text == "Active")
            {
                dataview1.RowFilter = $"IsActive = True";
            }
            if (cbIsActive.Text == "Inactive")
            {
                dataview1.RowFilter = $"IsActive = False";
            }
        }

        private int getSelectedRowUserID()
        {
            if(dataGridView1.Rows.Count == 0)
                return -1;

            int userID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            return userID;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser frmAddUser = new frmAddUser(getSelectedRowUserID());
            frmAddUser.ShowDialog();
            refreshDataGridView();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword1 = new frmChangePassword(getSelectedRowUserID());
            frmChangePassword1.populateEntireForm();
            frmChangePassword1.ShowDialog();
            refreshDataGridView();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser frmAddUser1 = new frmAddUser();
            frmAddUser1.ShowDialog();
            refreshDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count==0) 
                return;

            clsUser user1 = clsUser.loadUserInfo(getSelectedRowUserID());

            if (user1.canDelete())
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete this user?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    user1.Delete();
                    MessageBox.Show("User deleted successfully", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                    return;
            }
            else
                MessageBox.Show("User has references to different data in system, cannot delete","Failed",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;


            
        }
    }
}
