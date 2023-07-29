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




//using System;
//using System.Collections.Generic;

namespace Inventory_v01
{
    public partial class frm_sale : Form
    {




        public frm_sale()
        {
            InitializeComponent();
        }
        public void fndataLoad()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from item", cls_connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "dgv_item");
            dgv_item.DataSource = ds.Tables["dgv_item"].DefaultView;

        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_item item = new frm_item();
            //this.Hide();
            item.Show();
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_configuration config = new frm_configuration();
           // this.Hide();
            config.Show();
        }
        private void load_items()
        {

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from item", cls_connection.con);

            DataTable dt1 = new DataTable();

            da1.Fill(dt1);

            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                cmb_itemName.Items.Add(dt1.Rows[x]["item_name"]);
            }
        }

        private void frm_sale_Load(object sender, EventArgs e)
        {
            fndataLoad();
            load_items();

            //dgv_item.Columns[0].Name = "item_code";
            //dgv_item.Columns[1].Name = "item_name";
            //dgv_item.Columns[2].Name = "category";
            //dgv_item.Columns[0].Name = "selling_price";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
          
           





        } 

        private void dgv_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvrow = dgv_item.Rows[e.RowIndex];
                txt_itemCode.Text = dgvrow.Cells[0].Value.ToString();
                cmb_itemName.Text = dgvrow.Cells[1].Value.ToString();
                txt_sellingPrice.Text = dgvrow.Cells[5].Value.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void manageItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_manageItem manageItem = new frm_manageItem();
           // this.Hide();
            manageItem.Show();

        }

        private void viewAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_allItem allItem = new frm_allItem();
            allItem.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_customer customer = new frm_customer();
            customer.Show();
        }

        private void addPurchasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_purchasing purchasing = new frm_purchasing();
            purchasing.Show();
        }

        private void btn_remove1_Click(object sender, EventArgs e)
        {
           
        }      

    }
    
}
