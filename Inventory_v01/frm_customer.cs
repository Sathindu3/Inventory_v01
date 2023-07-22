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
    public partial class frm_customer : Form
    {
        public frm_customer()
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
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from customer", cls_connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "dgv_customer");
            dgv_customer.DataSource = ds.Tables["dgv_customer"].DefaultView;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            cls_connection.open_connection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `customer`( `cus_name`, `email`, `mobile_number`, `address`, `type`) VALUES ('cus_name','email','mobile_number','address','type')", cls_connection.con);
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@cus_name", txt_cusName.Text);
            cmd.Parameters.AddWithValue("@email", txt_mail.Text);
            cmd.Parameters.AddWithValue("@mobile_number", txt_mobile.Text);
            cmd.Parameters.AddWithValue("@address", txt_address.Text);
            cmd.Parameters.AddWithValue("@type", cmb_type.Text);



            cmd.ExecuteNonQuery();
            cls_connection.close_connection();

            MessageBox.Show("Item Added Successfully!");
            fndataLoad();
        }

        private void frm_customer_Load(object sender, EventArgs e)
        {
            fndataLoad();
        }
    }
}
