﻿using System;
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
    public partial class frmShowIntlDrivLic : Form
    {
        public frmShowIntlDrivLic(int intlLicenseID)
        {
            InitializeComponent();
            userCtrlIntlDrivLicInfo1._populateCard(intlLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
