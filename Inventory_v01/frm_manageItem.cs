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

        private void frm_manageItem_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            cls_connection.open_connection();
            //MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM `item` WHERE item_name like '%' + @searchTerm + '%'", cls_connection.con);
            //// cmd1.Parameters.AddWithValue("id", txt_search.Text);
            //cmd1.Parameters.AddWithValue("@searchTerm", txt_search.Text);

            //MySqlDataReader reader1;
            //reader1 = cmd1.ExecuteReader();

            //if (reader1.Read())
            //{
            //    //txt_itemCode.Text = reader1["item_id"].ToString();
            //    txt_itemName.Text = reader1["item_name"].ToString();
            //    cmb_category.Text = reader1["category"].ToString();
            //    txt_unitPrice.Text = reader1["item_price"].ToString();




            //}
            //else
            //{
            //    MessageBox.Show("No data found");
            //}

    //        try
    //        {
    //            cls_connection.open_connection();
    //            // Open the database connection


    //            // Prepare the SQL query with a parameterized query to prevent SQL injection
    //            string sqlQuery = "SELECT item_name, category,item_price FROM item WHERE item_name LIKE '%' + @searchTerm  + '%'";
    //            MySqlCommand cmd = new MySqlCommand(sqlQuery, cls_connection.con);

    //            // Replace "txtSearch" with the name of your search TextBox
    //            cmd.Parameters.AddWithValue("@searchTerm", txt_search.Text);

    //            // Execute the query and populate the DataGridView with the search results
    //            MySqlDataReader reader = cmd.ExecuteReader();
    //            DataTable dataTable = new DataTable();
    //            dataTable.Load(reader);
    //            dgv_item.DataSource = dataTable;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Error: " + ex.Message);
    //        }
            cls_connection.close_connection();
       }
   }
}
