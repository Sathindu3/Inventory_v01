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
        private LinkedList<string> linkedList;
      //  public partial class Form1 : Form
     
                  

         
    
           private void addButton_Click(object sender, EventArgs e)
        {
           
        }
        private void UpdateListBox()
        {
            //listBox.Items.Clear();
            //foreach (var item in linkedList)
            //{
            //    listBox.Items.Add(item);
            //}
        }
        public frm_sale()
        {
            InitializeComponent();
            linkedList = new LinkedList<string>();
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
            //string item = cmb_itemName.Text;
            //linkedList.AddLast(item);
            //UpdateListBox();
            //label3.Text = item;

            //inputTextBox.Clear();

            string item = cmb_itemName.Text;
            linkedList.AddLast(item);
            UpdateLabels();

            string qty = txt_quantity.Text;
            linkedList.AddLast(qty);
            Update_qty_Labels();

        }
        private void UpdateLabels()
        {
            int labelIndex = 1;
            foreach (var item in linkedList)
            {
                Label name = Controls.Find("lbl_item" + labelIndex, true)[0] as Label;
                name.Text = item;
                labelIndex++;

              
            }
            //for (int i = labelIndex; i <= 3; i++)
            //{
            //    Label label = Controls.Find("label" + i, true)[0] as Label;
            //    label.Text = string.Empty;
            //}
        }
        private void Update_qty_Labels()
        {
            int labelIndex = 1;
            foreach (var item in linkedList)
            {
               

                Label qty = Controls.Find("lbl_qty" + labelIndex, true)[0] as Label;
                qty.Text = item;
                labelIndex++;
            }
            //for (int i = labelIndex; i <= 3; i++)
            //{
            //    Label label = Controls.Find("label" + i, true)[0] as Label;
            //    label.Text = string.Empty;
            //}
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (linkedList.Count > 0)
            {
                linkedList.RemoveLast();
                UpdateLabels();
            }
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
