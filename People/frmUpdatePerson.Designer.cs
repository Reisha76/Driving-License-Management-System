﻿namespace My_DVLD
{
    partial class frmUpdatePerson
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
            this.userCtrlUpdatePerson1 = new My_DVLD.userCtrlUpdatePerson();
            this.SuspendLayout();
            // 
            // userCtrlUpdatePerson1
            // 
            this.userCtrlUpdatePerson1.Location = new System.Drawing.Point(12, 31);
            this.userCtrlUpdatePerson1.Name = "userCtrlUpdatePerson1";
            this.userCtrlUpdatePerson1.Size = new System.Drawing.Size(952, 527);
            this.userCtrlUpdatePerson1.TabIndex = 0;
            // 
            // frmUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 585);
            this.Controls.Add(this.userCtrlUpdatePerson1);
            this.Name = "frmUpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Person";
            this.ResumeLayout(false);

        }

        #endregion

        private userCtrlUpdatePerson userCtrlUpdatePerson1;
    }
}