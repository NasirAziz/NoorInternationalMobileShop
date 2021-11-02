using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaarDanaTraderPOS.Screens
{
    public partial class AddItemFinishForm : Form
    {
        int totalBill, payment;

        SqlConnection con = new SqlConnection();
        public AddItemFinishForm()
        {
            InitializeComponent();
        }

        private void AddItemFinishForm_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

            totalBill = AddItemForm.totalBill;
            lblTotalBill.Text = totalBill.ToString();
        }

        private void btnPaynow_Click(object sender, EventArgs e)
        {
            payment = int.Parse( tbPayment.Text );
            
            if (payment < totalBill) {
                DialogResult dialogResult = MessageBox.Show("Entered Amount is LESS than Total Bill!\nDo you want to add to Balance", "Payment Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MoveOrderToAddItemTable();
                    AddItemForm.dtOrder = null;

                    int bal = totalBill - payment;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandText = "UPDATE Add_supplier SET Balance=Balance+@q WHERE Supplier_id=@id"
                    };
                    cmd.Parameters.AddWithValue("@id", AddItemForm.supplierID);
                    cmd.Parameters.AddWithValue("@q", bal);
                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                    {
                        MessageBox.Show("Products Added Successfully.");
                        this.Close();
                    }

                    // startCheckoutFlow();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }else if (payment > totalBill)
            {
                DialogResult dialogResult = MessageBox.Show("Entered Amount is MORE than Total Bill!\nDo you want to add to Balance", "Payment Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MoveOrderToAddItemTable();
                    AddItemForm.dtOrder = null;

                    int bal = totalBill - payment;
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandText = "UPDATE Add_supplier SET Balance=Balance+@q WHERE Supplier_id=@id"
                    };
                    cmd.Parameters.AddWithValue("@id", AddItemForm.supplierID);
                    cmd.Parameters.AddWithValue("@q", bal);
                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                    {
                        MessageBox.Show("Products Added Successfully.");
                        this.Close();
                    }

                    // startCheckoutFlow();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MoveOrderToAddItemTable();
                AddItemForm.dtOrder = null;
                this.Close();

            }
        }

        public void MoveOrderToAddItemTable()
        {
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Add_item";

            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("DateOfExpiry", "DateOfExpiry");
            objbulk.ColumnMappings.Add("Quantity", "Quantity");
            objbulk.ColumnMappings.Add("Purchase_price", "Purchase_price");
            objbulk.ColumnMappings.Add("Price", "Price");
            objbulk.ColumnMappings.Add("Supplier", "Supplier");
            objbulk.ColumnMappings.Add("Company", "Company");
            objbulk.ColumnMappings.Add("BarCode", "BarCode");
            /*objbulk.ColumnMappings.Add("Profit", "Profit");*/
            objbulk.WriteToServer(AddItemForm.dtOrder);

        }
    }
}
