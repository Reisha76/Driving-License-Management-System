namespace My_DVLD.Screens_People
{
    partial class frmReplaceLostAndDamagedLicense
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
            this.userCtrlDriverLicenseSelector1 = new My_DVLD.Screens_People.userCtrlDriverLicenseSelector();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLic = new System.Windows.Forms.RadioButton();
            this.rbDamagedLic = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOldLicID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblNewLicID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblReplaceAppID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.lnkLblShowLicHistory = new System.Windows.Forms.LinkLabel();
            this.lnkLblShowNewLic = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // userCtrlDriverLicenseSelector1
            // 
            this.userCtrlDriverLicenseSelector1.Location = new System.Drawing.Point(5, 100);
            this.userCtrlDriverLicenseSelector1.Name = "userCtrlDriverLicenseSelector1";
            this.userCtrlDriverLicenseSelector1.Size = new System.Drawing.Size(767, 426);
            this.userCtrlDriverLicenseSelector1.TabIndex = 0;
            this.userCtrlDriverLicenseSelector1.OnPersonSelected += new System.Action<int>(this.userCtrlDriverLicenseSelector1_OnPersonSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLostLic);
            this.groupBox1.Controls.Add(this.rbDamagedLic);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(441, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For:";
            // 
            // rbLostLic
            // 
            this.rbLostLic.AutoSize = true;
            this.rbLostLic.Location = new System.Drawing.Point(193, 20);
            this.rbLostLic.Name = "rbLostLic";
            this.rbLostLic.Size = new System.Drawing.Size(94, 19);
            this.rbLostLic.TabIndex = 1;
            this.rbLostLic.TabStop = true;
            this.rbLostLic.Text = "Lost License";
            this.rbLostLic.UseVisualStyleBackColor = true;
            this.rbLostLic.CheckedChanged += new System.EventHandler(this.rbLostLic_CheckedChanged);
            // 
            // rbDamagedLic
            // 
            this.rbDamagedLic.AutoSize = true;
            this.rbDamagedLic.Checked = true;
            this.rbDamagedLic.Location = new System.Drawing.Point(23, 20);
            this.rbDamagedLic.Name = "rbDamagedLic";
            this.rbDamagedLic.Size = new System.Drawing.Size(126, 19);
            this.rbDamagedLic.TabIndex = 0;
            this.rbDamagedLic.TabStop = true;
            this.rbDamagedLic.Text = "Damaged License";
            this.rbDamagedLic.UseVisualStyleBackColor = true;
            this.rbDamagedLic.CheckedChanged += new System.EventHandler(this.rbDamagedLic_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOldLicID);
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblNewLicID);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblAppFees);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblAppDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblReplaceAppID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 532);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 121);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For License Replacement";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblOldLicID
            // 
            this.lblOldLicID.AutoSize = true;
            this.lblOldLicID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicID.Location = new System.Drawing.Point(530, 60);
            this.lblOldLicID.Name = "lblOldLicID";
            this.lblOldLicID.Size = new System.Drawing.Size(39, 15);
            this.lblOldLicID.TabIndex = 4;
            this.lblOldLicID.Text = "[???]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(530, 94);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(34, 15);
            this.lblCreatedBy.TabIndex = 6;
            this.lblCreatedBy.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(359, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Old License ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(359, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Created By:";
            // 
            // lblNewLicID
            // 
            this.lblNewLicID.AutoSize = true;
            this.lblNewLicID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewLicID.Location = new System.Drawing.Point(530, 26);
            this.lblNewLicID.Name = "lblNewLicID";
            this.lblNewLicID.Size = new System.Drawing.Size(39, 15);
            this.lblNewLicID.TabIndex = 7;
            this.lblNewLicID.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Replaced License ID:";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(160, 94);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(34, 15);
            this.lblAppFees.TabIndex = 5;
            this.lblAppFees.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Application Fees:";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(160, 60);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(34, 15);
            this.lblAppDate.TabIndex = 3;
            this.lblAppDate.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Application Date:";
            // 
            // lblReplaceAppID
            // 
            this.lblReplaceAppID.AutoSize = true;
            this.lblReplaceAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceAppID.Location = new System.Drawing.Point(160, 26);
            this.lblReplaceAppID.Name = "lblReplaceAppID";
            this.lblReplaceAppID.Size = new System.Drawing.Size(39, 15);
            this.lblReplaceAppID.TabIndex = 1;
            this.lblReplaceAppID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "L.R.Application ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(151, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Replace Lost/Damaged License";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::My_DVLD.Properties.Resources.closeSmall;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(456, 659);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 43);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = global::My_DVLD.Properties.Resources.issueLicense;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(613, 659);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(151, 43);
            this.btnIssueReplacement.TabIndex = 5;
            this.btnIssueReplacement.Text = " Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // lnkLblShowLicHistory
            // 
            this.lnkLblShowLicHistory.AutoSize = true;
            this.lnkLblShowLicHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLblShowLicHistory.Location = new System.Drawing.Point(65, 674);
            this.lnkLblShowLicHistory.Name = "lnkLblShowLicHistory";
            this.lnkLblShowLicHistory.Size = new System.Drawing.Size(124, 15);
            this.lnkLblShowLicHistory.TabIndex = 6;
            this.lnkLblShowLicHistory.TabStop = true;
            this.lnkLblShowLicHistory.Text = "Show License History";
            this.lnkLblShowLicHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblShowLicHistory_LinkClicked);
            // 
            // lnkLblShowNewLic
            // 
            this.lnkLblShowNewLic.AutoSize = true;
            this.lnkLblShowNewLic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLblShowNewLic.Location = new System.Drawing.Point(205, 674);
            this.lnkLblShowNewLic.Name = "lnkLblShowNewLic";
            this.lnkLblShowNewLic.Size = new System.Drawing.Size(135, 15);
            this.lnkLblShowNewLic.TabIndex = 7;
            this.lnkLblShowNewLic.TabStop = true;
            this.lnkLblShowNewLic.Text = "Show New License Info";
            this.lnkLblShowNewLic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblShowNewLic_LinkClicked);
            // 
            // frmReplaceLostAndDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 712);
            this.Controls.Add(this.lnkLblShowNewLic);
            this.Controls.Add(this.lnkLblShowLicHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userCtrlDriverLicenseSelector1);
            this.Name = "frmReplaceLostAndDamagedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Lost/Damaged License";
            this.Load += new System.EventHandler(this.frmReplaceLostAndDamagedLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private userCtrlDriverLicenseSelector userCtrlDriverLicenseSelector1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLic;
        private System.Windows.Forms.RadioButton rbDamagedLic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOldLicID;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNewLicID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblReplaceAppID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.LinkLabel lnkLblShowLicHistory;
        private System.Windows.Forms.LinkLabel lnkLblShowNewLic;
    }
}