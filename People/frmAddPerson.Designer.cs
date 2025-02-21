namespace My_DVLD
{
    partial class frmAddPerson
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
            this.ctrlAddPerson1 = new My_DVLD.ctrlAddPerson();
            this.SuspendLayout();
            // 
            // ctrlAddPerson1
            // 
            this.ctrlAddPerson1.Location = new System.Drawing.Point(9, 13);
            this.ctrlAddPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlAddPerson1.Name = "ctrlAddPerson1";
            this.ctrlAddPerson1.Size = new System.Drawing.Size(895, 492);
            this.ctrlAddPerson1.TabIndex = 0;
            // 
            // frmAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 517);
            this.Controls.Add(this.ctrlAddPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Person";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddPerson_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAddPerson ctrlAddPerson1;
    }
}