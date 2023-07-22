using MySql.Data.MySqlClient;
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
    public partial class frm_allItem : Form
    {
        public frm_allItem()
        {
            InitializeComponent();
        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sale sale = new frm_sale();
            this.Hide();
            sale.Show();
        }

        private void frm_allItem_Load(object sender, EventArgs e)
        {
            fndataLoad();
        }
        public void fndataLoad()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from item", cls_connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "dgv_item");
            dgv_item.DataSource = ds.Tables["dgv_item"].DefaultView;

        }
    }
}
