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
            frm_sale sale = new frm_sale();
            this.Hide();
            sale.Show();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_item item = new frm_item();
            this.Hide();
            item.Show();
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_configuration config = new frm_configuration();
            this.Hide();
            config.Show();
        }

        private void frm_sale_Load(object sender, EventArgs e)
        {
            fndataLoad();


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


        //        using System;
        //using System.Collections.Generic;

        //public class Item
        //    {
        //        public string Name { get; set; }
        //        public double Price { get; set; }
        //        public int Quantity { get; set; }

        //        public Item(string name, double price, int quantity)
        //        {
        //            Name = name;
        //            Price = price;
        //            Quantity = quantity;
        //        }
        //    }

        //    public class Program
        //    {
        //        public static void Main(string[] args)
        //        {
        //            LinkedList<Item> items = new LinkedList<Item>();

        //            // Create a new item
        //            Item newItem = new Item("Item 1", 10.99, 2);

        //            // Add the item to the linked list
        //            items.AddLast(newItem);

        //            Console.WriteLine("Item added to the linked list.");

        //            Console.ReadKey();
        //        }
        //    }

    }
    
}
