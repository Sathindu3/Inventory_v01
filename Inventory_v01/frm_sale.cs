﻿using MySql.Data.MySqlClient;
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
    public partial class frm_sale : Form
    {


        DataTable table = new DataTable("table");
        int index;

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

            table.Columns.Add("Item name", Type.GetType("System.String"));
            table.Columns.Add("Unit Price", Type.GetType("System.String"));
            table.Columns.Add("Quantity ", Type.GetType("System.String"));
            table.Columns.Add("Total ", Type.GetType("System.String"));
            dgv_billpreview.DataSource = table;



        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            table.Rows.Add(cmb_itemName.Text, txt_sellingPrice.Text, txt_quantity.Text,lbl_total.Text);

           


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

        private void dgv_billpreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_billpreview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //index = e.RowIndex;
            //DataGridViewRow row = dgv_billpreview.Rows[index];
            //txt_quantity.Text = row.Cells[0].Value.ToString();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dgv_billpreview.Rows[index];
            newdata.Cells[0].Value = cmb_itemName.Text;
            newdata.Cells[1].Value = txt_sellingPrice.Text;
            newdata.Cells[2].Value = txt_quantity.Text;
            newdata.Cells[3].Value = lbl_total.Text;
            //newdata.Cells[3].Value = cmb_itemName.Text;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            index = dgv_billpreview.CurrentCell.RowIndex;
            dgv_billpreview.Rows.RemoveAt(index);
        }

        private void txt_sellingPrice_TextChanged(object sender, EventArgs e)
        {
          
           
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_quantity.Text == "")
            {
                MessageBox.Show("Please enter a quantity");

            }
            else
            {
                lbl_total.Text = (Convert.ToInt32(txt_quantity.Text) * Convert.ToInt32(txt_sellingPrice.Text)).ToString();
            }
        }

        private void btn_calSum_Click(object sender, EventArgs e)
        {
            lbl_Amount.Text = "0";
            for(int i = 0; i < dgv_billpreview.Rows.Count;  i++)
            {
                lbl_Amount.Text = Convert.ToString(double.Parse(lbl_Amount.Text) + double.Parse(dgv_billpreview.Rows[i].Cells[3].Value.ToString()));
            }
        }
    }
    
}
