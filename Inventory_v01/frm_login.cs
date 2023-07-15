using System;
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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void cb_show_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_show.Checked == true)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            frm_sale sale = new frm_sale();
            this.Hide();
            sale.Show();
            
        }
    }
}
