﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_v01
{
    public partial class frm_manageItem : Form
    {
        public frm_manageItem()
        {
            InitializeComponent();
        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sale sale = new frm_sale();
            this.Hide();
            sale.Show();
        }
    }
}
