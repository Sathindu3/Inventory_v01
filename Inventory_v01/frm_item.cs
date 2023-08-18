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
    public partial class frm_item : Form
    {
        public frm_item()
        {
            InitializeComponent();
        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sale sale = new frm_sale();
            this.Hide();
            sale.Show();
        }
        public void fndataLoad()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from item", cls_connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "dgv_item");
            dgv_item.DataSource = ds.Tables["dgv_item"].DefaultView;

        }
        public void Add_itemToStock()
        {
            cls_connection.open_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `stock` (item_name,quantity) VALUES (@item_name,@quantity)", cls_connection.con);
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@item_name", txt_itemName.Text);
            cmd.Parameters.AddWithValue("@quantity", 0);



            cmd.ExecuteNonQuery();
            cls_connection.close_connection();

            MessageBox.Show("Order Added Successfully!");

            fndataLoad();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            cls_connection.open_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `item`( `item_name`, `category`, `supplier`, `unit_price`, `selling_price`) VALUES (@item_name,@category,@supplier,@unit_price,@selling_price)", cls_connection.con);
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@item_name", txt_itemName.Text);
            cmd.Parameters.AddWithValue("@category", cmb_category.Text);
            cmd.Parameters.AddWithValue("@supplier", cmb_supplier.Text);
            cmd.Parameters.AddWithValue("@unit_price", txt_unitPrice.Text);
            cmd.Parameters.AddWithValue("@selling_price", txt_sellingPrice.Text);
           


            cmd.ExecuteNonQuery();
            cls_connection.close_connection();

            MessageBox.Show("Item Added Successfully!");
            fndataLoad();
            Add_itemToStock();



        }

        private void frm_item_Load(object sender, EventArgs e)
        {
         fndataLoad();
        }

        private void cmb_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
