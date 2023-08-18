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
    public partial class frm_purchasing : Form
    {
        public frm_purchasing()
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

            MySqlDataAdapter da = new MySqlDataAdapter("Select * from purchasing", cls_connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "purchasing");
           // DataGridView1.DataSource = ds.Tables["purchasing"].DefaultView;

        }
        public void addToStock()
        {

            cls_connection.open_connection();
            string sqlqry4 = "update  stock set quantity =quantity +  " + txt_quantity.Text + " where item_name = '" + cmb_itemName.Text + "'";


            MySqlCommand cmd4 = new MySqlCommand(sqlqry4, cls_connection.con);

            cmd4.ExecuteNonQuery();
            cls_connection.close_connection();
            fndataLoad();
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            cls_connection.open_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `purchasing` (item_code,`item_name`,`quantity`,`customer_name`,invoiced_date) VALUES (@item_code,@item_name,@quantity,@customer_name,@invoiced_date)", cls_connection.con);
            cmd.Parameters.Clear();

           
            cmd.Parameters.AddWithValue("@item_code", txt_itemCode.Text);
            cmd.Parameters.AddWithValue("@item_name", cmb_itemName.Text);
            cmd.Parameters.AddWithValue("@quantity", txt_quantity.Text);
            cmd.Parameters.AddWithValue("@customer_name", cmb_customer.Text);
            cmd.Parameters.AddWithValue("@invoiced_date", dtp_purchDate.Text);
          //  cmd.Parameters.AddWithValue("@total_value", dtp_purchDate.Text);

            cmd.ExecuteNonQuery();
            cls_connection.close_connection();

            MessageBox.Show("Order Added Successfully!");
            addToStock();
            fndataLoad();
        }

        private void frm_purchasing_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from item", cls_connection.con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmb_itemName.Items.Add(dt.Rows[i]["item_name"]);
              


            }
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from customer", cls_connection.con);

            DataTable dt1 = new DataTable();

            da1.Fill(dt1);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                
                cmb_customer.Items.Add(dt1.Rows[i]["cus_name"]);


            }

        }
      
    }
}
