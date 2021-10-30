﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BaarDanaTraderPOS.Screens
{
    public partial class AddItemForm : Form
    {
        DataTable Item = new DataTable();
        SqlConnection con = new SqlConnection();
        public int id, price, purchase, quantity;
        public String name, company, barcode;
        public AddItemForm()
        {
            InitializeComponent();
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            if (tbItemName.Text.Length != 0 && tbItemPrice.Text.Length != 0 && tbItemQuantity.Text.Length != 0)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Add_item values(@name,@price,@quantity,@barcode,@company,@purchase)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", tbItemName.Text);
                cmd.Parameters.AddWithValue("@price", tbItemPrice.Text);
                cmd.Parameters.AddWithValue("@quantity", tbItemQuantity.Text);
                cmd.Parameters.AddWithValue("@barcode", tbBarCode.Text);
                cmd.Parameters.AddWithValue("@company", cbCompany.GetItemText(cbCompany.SelectedItem));
                cmd.Parameters.AddWithValue("@purchase", tbPurchasePrice.Text);

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Item Added Successfully");
                        Resettext();

                    }
                    else
                    {
                        MessageBox.Show("Item Not Added");
                    }
                }
                catch
                {
                    MessageBox.Show("Please add valid data!");
                }
                LoadItems();
            }
            else
            {
                MessageBox.Show("Please Fill the required fields!");
            }

        }
        private void UpdateItem(int id, String name, int price, int quantity)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Add_item SET Name=@name, Price=@price, Quantity=@quantity, Purchase_price=@purchase WHERE Item_id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@purchase", tbPurchasePrice.Text);


            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("Updated");
            }



        }
        private void LoadItems()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            Item.Clear();
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();

        }



        private void AddItemForm_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

            LoadItems();
            LoadCompany();

        }

        private void btnAISearch_Click(object sender, EventArgs e)
        {
            DataTable Item = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item where Name Like @name +'%'  ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbAISearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();
        }
        private void DeleteItem(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from Add_item where Item_id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            //LoadItems();


        }
        public void LoadCompany()
        {
            try
            {
                DataTable company = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Company";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(company);

                //Insert the Default Item to DataTable.
                DataRow row = company.NewRow();
                row[0] = 0;
                row[1] = "Default";
                company.Rows.InsertAt(row, 0);
                cbCompany.DataSource = company;
                cbCompany.DisplayMember = "CompanyName";
                cbCompany.ValueMember = "id";
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }

        }
        private void btnItemUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                name = tbItemName.Text;
                price = Convert.ToInt32(tbItemPrice.Text);
                quantity = Convert.ToInt32(tbItemQuantity.Text);
                UpdateItem(id, name, price, quantity);
                LoadItems();
                Resettext();


            }
            catch
            {

            }
        }
        private void Resettext()
        {
            tbItemName.Text = "";
            tbItemPrice.Text = "";
            tbItemQuantity.Text = "";
            tbPurchasePrice.Text = "";
            tbBarCode.Text = "";
            cbCompany.SelectedIndex = 0;
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            DeleteItem(id);
            LoadItems();
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadItems();
            tbAISearch.Text = "";
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            Comapany cm = new Comapany
                ();
            cm.Show();
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCompany_Click(object sender, EventArgs e)
        {
            LoadCompany();
        }

        private void tbAISearch_TextChanged(object sender, EventArgs e)
        {
            DataTable Item = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item where Name Like @name + '%'";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbAISearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                id = Convert.ToInt32(dgvItems.CurrentRow.Cells[0].Value.ToString());
                name = dgvItems.CurrentRow.Cells[1].Value.ToString();
                price = Convert.ToInt32(dgvItems.CurrentRow.Cells[2].Value.ToString());
                quantity = Convert.ToInt32(dgvItems.CurrentRow.Cells[3].Value.ToString());
                purchase = Convert.ToInt32(dgvItems.CurrentRow.Cells[6].Value.ToString());
                barcode = dgvItems.CurrentRow.Cells[4].Value.ToString();
                company = dgvItems.CurrentRow.Cells[5].Value.ToString();
                tbItemName.Text = name;
                tbItemPrice.Text = price.ToString();
                tbItemQuantity.Text = quantity.ToString();
                tbPurchasePrice.Text = purchase.ToString();
                tbBarCode.Text = barcode;
                cbCompany.SelectedIndex = cbCompany.Items.IndexOf(company);

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
