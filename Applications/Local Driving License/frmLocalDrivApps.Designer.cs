namespace My_DVLD.Screens_People
{
    partial class frmLocalDrivApps
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmShowApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.cmVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmIssueDrvLic = new System.Windows.Forms.ToolStripMenuItem();
            this.cmShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewApp = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 227);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 328);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmShowApplication,
            this.toolStripSeparator1,
            this.cmEditApplication,
            this.cmDeleteApp,
            this.toolStripSeparator2,
            this.cmCancelApp,
            this.toolStripSeparator3,
            this.cmScheduleTests,
            this.toolStripSeparator4,
            this.cmIssueDrvLic,
            this.cmShowLicense,
            this.toolStripSeparator5,
            this.cmShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(308, 264);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cmShowApplication
            // 
            this.cmShowApplication.Image = global::My_DVLD.Properties.Resources.showIcon;
            this.cmShowApplication.Name = "cmShowApplication";
            this.cmShowApplication.Size = new System.Drawing.Size(307, 26);
            this.cmShowApplication.Text = "Show Application Details";
            this.cmShowApplication.Click += new System.EventHandler(this.cmShowApplication_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(304, 6);
            // 
            // cmEditApplication
            // 
            this.cmEditApplication.Image = global::My_DVLD.Properties.Resources.editIcon;
            this.cmEditApplication.Name = "cmEditApplication";
            this.cmEditApplication.Size = new System.Drawing.Size(307, 26);
            this.cmEditApplication.Text = "Edit Application";
            this.cmEditApplication.Click += new System.EventHandler(this.cmEditApplication_Click);
            // 
            // cmDeleteApp
            // 
            this.cmDeleteApp.Image = global::My_DVLD.Properties.Resources.deleteIcon;
            this.cmDeleteApp.Name = "cmDeleteApp";
            this.cmDeleteApp.Size = new System.Drawing.Size(307, 26);
            this.cmDeleteApp.Text = "Delete Application";
            this.cmDeleteApp.Click += new System.EventHandler(this.cmDeleteApp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(304, 6);
            // 
            // cmCancelApp
            // 
            this.cmCancelApp.Image = global::My_DVLD.Properties.Resources.cancelIcon;
            this.cmCancelApp.Name = "cmCancelApp";
            this.cmCancelApp.Size = new System.Drawing.Size(307, 26);
            this.cmCancelApp.Text = "Cancel Application";
            this.cmCancelApp.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(304, 6);
            // 
            // cmScheduleTests
            // 
            this.cmScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmVisionTest,
            this.cmWrittenTest,
            this.cmStreetTest});
            this.cmScheduleTests.Image = global::My_DVLD.Properties.Resources.plusIcon;
            this.cmScheduleTests.Name = "cmScheduleTests";
            this.cmScheduleTests.Size = new System.Drawing.Size(307, 26);
            this.cmScheduleTests.Text = "Schedule Tests";
            this.cmScheduleTests.Click += new System.EventHandler(this.scheduleTestsToolStripMenuItem_Click);
            // 
            // cmVisionTest
            // 
            this.cmVisionTest.Image = global::My_DVLD.Properties.Resources.eyeIcon;
            this.cmVisionTest.Name = "cmVisionTest";
            this.cmVisionTest.Size = new System.Drawing.Size(162, 26);
            this.cmVisionTest.Text = "Vision Test";
            this.cmVisionTest.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // cmWrittenTest
            // 
            this.cmWrittenTest.Image = global::My_DVLD.Properties.Resources.writtenTest;
            this.cmWrittenTest.Name = "cmWrittenTest";
            this.cmWrittenTest.Size = new System.Drawing.Size(162, 26);
            this.cmWrittenTest.Text = "Written Test";
            this.cmWrittenTest.Click += new System.EventHandler(this.cmWrittenTest_Click);
            // 
            // cmStreetTest
            // 
            this.cmStreetTest.Image = global::My_DVLD.Properties.Resources.carIcon;
            this.cmStreetTest.Name = "cmStreetTest";
            this.cmStreetTest.Size = new System.Drawing.Size(162, 26);
            this.cmStreetTest.Text = "Street Test";
            this.cmStreetTest.Click += new System.EventHandler(this.cmStreetTest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(304, 6);
            // 
            // cmIssueDrvLic
            // 
            this.cmIssueDrvLic.Image = global::My_DVLD.Properties.Resources.issueNew;
            this.cmIssueDrvLic.Name = "cmIssueDrvLic";
            this.cmIssueDrvLic.Size = new System.Drawing.Size(307, 26);
            this.cmIssueDrvLic.Text = "Issue Driving License (First Time)";
            this.cmIssueDrvLic.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // cmShowLicense
            // 
            this.cmShowLicense.Image = global::My_DVLD.Properties.Resources.licenseBgger;
            this.cmShowLicense.Name = "cmShowLicense";
            this.cmShowLicense.Size = new System.Drawing.Size(307, 26);
            this.cmShowLicense.Text = "Show License";
            this.cmShowLicense.Click += new System.EventHandler(this.cmShowLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(304, 6);
            // 
            // cmShowPersonLicenseHistory
            // 
            this.cmShowPersonLicenseHistory.Image = global::My_DVLD.Properties.Resources.licenseHistory;
            this.cmShowPersonLicenseHistory.Name = "cmShowPersonLicenseHistory";
            this.cmShowPersonLicenseHistory.Size = new System.Drawing.Size(307, 26);
            this.cmShowPersonLicenseHistory.Text = "Show Person License History";
            this.cmShowPersonLicenseHistory.Click += new System.EventHandler(this.cmShowPersonLicenseHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 591);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(107, 591);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(39, 16);
            this.lblRecordsCount.TabIndex = 2;
            this.lblRecordsCount.Text = "count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Filter By:";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilters.Location = new System.Drawing.Point(110, 184);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(121, 21);
            this.cbFilters.TabIndex = 4;
            this.cbFilters.SelectedValueChanged += new System.EventHandler(this.cbFilters_SelectedValueChanged);
            this.cbFilters.TextChanged += new System.EventHandler(this.cbFilters_TextChanged);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(268, 185);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(158, 20);
            this.txtBoxSearch.TabIndex = 5;
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(261, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Local Driving License Applications";
            // 
            // btnAddNewApp
            // 
            this.btnAddNewApp.Location = new System.Drawing.Point(893, 174);
            this.btnAddNewApp.Name = "btnAddNewApp";
            this.btnAddNewApp.Size = new System.Drawing.Size(167, 39);
            this.btnAddNewApp.TabIndex = 7;
            this.btnAddNewApp.Text = "Add Application";
            this.btnAddNewApp.UseVisualStyleBackColor = true;
            this.btnAddNewApp.Click += new System.EventHandler(this.btnAddNewApp_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(268, 185);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 8;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::My_DVLD.Properties.Resources.applications;
            this.pictureBox1.Location = new System.Drawing.Point(463, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmLocalDrivApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 631);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnAddNewApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLocalDrivApps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmLocalDrivApps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewApp;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmShowApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmEditApplication;
        private System.Windows.Forms.ToolStripMenuItem cmDeleteApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmCancelApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmScheduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmIssueDrvLic;
        private System.Windows.Forms.ToolStripMenuItem cmShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cmShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem cmVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmStreetTest;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}