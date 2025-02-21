namespace My_DVLD.Screens_People
{
    partial class frmUserInfo
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
            this.userCtrlPersonCard1 = new My_DVLD.userCtrlPersonCard();
            this.userCtrlLoginInfo1 = new My_DVLD.userCtrlLoginInfo();
            this.SuspendLayout();
            // 
            // userCtrlPersonCard1
            // 
            this.userCtrlPersonCard1.Location = new System.Drawing.Point(12, 3);
            this.userCtrlPersonCard1.Name = "userCtrlPersonCard1";
            this.userCtrlPersonCard1.Size = new System.Drawing.Size(764, 310);
            this.userCtrlPersonCard1.TabIndex = 0;
            // 
            // userCtrlLoginInfo1
            // 
            this.userCtrlLoginInfo1.Location = new System.Drawing.Point(24, 298);
            this.userCtrlLoginInfo1.Name = "userCtrlLoginInfo1";
            this.userCtrlLoginInfo1.Size = new System.Drawing.Size(738, 128);
            this.userCtrlLoginInfo1.TabIndex = 1;
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 442);
            this.Controls.Add(this.userCtrlLoginInfo1);
            this.Controls.Add(this.userCtrlPersonCard1);
            this.Name = "frmUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.ResumeLayout(false);

        }

        #endregion

        private userCtrlPersonCard userCtrlPersonCard1;
        private userCtrlLoginInfo userCtrlLoginInfo1;
    }
}