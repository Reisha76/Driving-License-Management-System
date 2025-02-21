namespace My_DVLD
{
    partial class frmPersonCard
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
            this.label1 = new System.Windows.Forms.Label();
            this.userCtrlPersonCard1 = new My_DVLD.userCtrlPersonCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(261, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Details";
            // 
            // userCtrlPersonCard1
            // 
            this.userCtrlPersonCard1.Location = new System.Drawing.Point(3, 91);
            this.userCtrlPersonCard1.Name = "userCtrlPersonCard1";
            this.userCtrlPersonCard1.Size = new System.Drawing.Size(775, 312);
            this.userCtrlPersonCard1.TabIndex = 0;
            this.userCtrlPersonCard1.Load += new System.EventHandler(this.userCtrlPersonCard1_Load);
            // 
            // frmPersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userCtrlPersonCard1);
            this.Name = "frmPersonCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Card";
            this.Load += new System.EventHandler(this.frmPersonCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private userCtrlPersonCard ctrlPersonCard1;
        private userCtrlPersonCard userCtrlPersonCard1;
        private System.Windows.Forms.Label label1;
    }
}