using System;
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
    public partial class SalesReturn : Form
    {
        Double price, Quantity, Total, Sale_id, Product_id, Profit, Invoice_id;
        Double newprice;
        double newqty;
        String Product_name;

        SqlConnection con = new SqlConnection();
        
        public SalesReturn()
        {
            InitializeComponent();

        }
        public void FillTextBox()
        {
            tbProductName.Text = this.Product_name;
            tbPrice.Text = price.ToString();
            tbQuantity.Text = Quantity.ToString();
            tbTotal.Text = Total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteSale();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            update();
        }

        public SalesReturn(Double price, Double Quantity,Double Total, String Product_Name,Double Sale_id,Double Product_id,Double Profit,Double Invoice_id)
        {
            InitializeComponent();

            this.price = price;
            this.Quantity = Quantity;
            this.Total = Total;
            this.Product_name = Product_Name;
            this.Sale_id = Sale_id;
            this.Product_id = Product_id;
            this.Profit = Profit;
            this.Invoice_id = Invoice_id;
            FillTextBox();
            


        }
        public void DeleteSale()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Sales_report where Sale_id=@id";
                cmd.Parameters.AddWithValue("@id", Sale_id);
                int r=cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Sale Successfully Return ");
                    QuantityBack(Quantity);
                    newqty = Quantity;
                    newprice = newqty * price;
                    addSaleReturnToDatabase();
                }
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        public void QuantityBack(Double qty)
        {
            MessageBox.Show(Product_id.ToString());
            SqlCommand cmd = new SqlCommand
            {
                Connection = con,
                CommandText = "UPDATE Add_item SET Quantity=Quantity+@q WHERE Item_id=@id"
            };
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Product_id));
            cmd.Parameters.AddWithValue("@q", Convert.ToInt32(qty));
            int r = cmd.ExecuteNonQuery();
          
            if (r > 0)
            {
                MessageBox.Show("added Quantity");
            }
            

        }


        private void addSaleReturnToDatabase() {

            double qtyReturned = Convert.ToDouble(tbQuantity.Text);
            double nprice = qtyReturned * price;

            SqlCommand cmd = new SqlCommand
            {
                Connection = con,
                CommandText = "INSERT INTO Sales_return VALUES(@invoice, @product, @price, @qty, @date)"
            };
            cmd.Parameters.AddWithValue("@invoice", Invoice_id);
            cmd.Parameters.AddWithValue("@product", Product_name);
            cmd.Parameters.AddWithValue("@price", nprice);
            cmd.Parameters.AddWithValue("@qty", qtyReturned);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("Sales Added");
            }

        }

        public void update()
        {
            double qtyReturned = Convert.ToDouble(tbQuantity.Text);
            newqty = Quantity - qtyReturned;


            if (qtyReturned == 0)
            {
                MessageBox.Show("Please Enter a valid Quantity!");
                return;
            }

            if ( newqty > Quantity )
            {
                MessageBox.Show("You are returning more quantity than you sold.");
            }
            else
            {
                newprice= newqty * price;
                double newprofit = (Profit / Quantity) * newqty;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "update Sales_report set Quantity=@q, Total=@t,Profit=@p where Sale_id=@invoice"
                };
                cmd.Parameters.AddWithValue("@q", newqty);
                cmd.Parameters.AddWithValue("@t", newprice);
                cmd.Parameters.AddWithValue("@id", Product_id);
                cmd.Parameters.AddWithValue("@invoice", Sale_id);
                cmd.Parameters.AddWithValue("@p", newprofit);
                int r=cmd.ExecuteNonQuery();
                if ( r> 0)
                {
                    MessageBox.Show("Partial Sale Return");
                    QuantityBack(newqty);
                    addSaleReturnToDatabase();
                    MessageBox.Show(Product_name);
                }
                else
                {
                    MessageBox.Show("");
                }
                
            }

            


        }
        

        private void SalesReturn_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
        }
    }
}
