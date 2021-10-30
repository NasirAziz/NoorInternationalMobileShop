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
using BaarDanaTraderPOS.Screens;
namespace BaarDanaTraderPOS
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        int cashSale, cashOther,countSales;
        int profitSales;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             con.ConnectionString = Connection.c;
            con.Open();
/*            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("Error! Database not found.");
            }*/
            
        }

        private void btnCreateOrder(object sender, EventArgs e)
        {
            CreateOrderForm cof = new CreateOrderForm();
            cof.Show();
        }

        private void btnViewHistory(object sender, EventArgs e)
        {

            ViewHistoryForm vhf = new ViewHistoryForm();
            vhf.Show();

        }

        private void btnAddItem(object sender, EventArgs e)
        {
            AddItemForm aif = new AddItemForm();
            aif.Show();

        }

        private void btnAddCustomer(object sender, EventArgs e)
        {
            CashInCashOut cash = new CashInCashOut();
            cash.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Expenses exp = new Expenses();
            exp.Show();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            OtherIncome c = new  OtherIncome();
            c.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProfitAndLoss pf = new ProfitAndLoss();
            pf.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            cashthroughsale();
            cashthroughotherincome();
            ProfitFromSales();
            profitSales += cashOther;
           // CountSales();
            int total = cashSale + cashOther;
            lblTotalCashIn.Text = total.ToString();
            lblTotalSales.Text = countSales.ToString();
            lblTotalProfit.Text = profitSales.ToString();
        }

        public void cashthroughsale()
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT SUM(price) FROM Sales_report where date=@d1";
                cmd.Parameters.AddWithValue("@d1", DateTime.Now.ToString("yyyy-MMM-dd"));
                cashSale = (int)cmd.ExecuteScalar();

            } catch {
                cashSale = 0;
            }
          

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
        }

        public void ProfitFromSales()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT SUM(Profit) FROM Sales_report where date=@d1";
                cmd.Parameters.AddWithValue("@d1", DateTime.Now.ToString("yyyy-MMM-dd"));
                profitSales = (int)cmd.ExecuteScalar();

            }
            catch
            {
                profitSales = 0;
            }


        }

        /*        public void CountSales()
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT Invoide_id FROM Invoice_id";
                        int id = (int)cmd.ExecuteScalar();



                    }
                    catch
                    {
                        countSales = 0;
                    }


                }
        */
        public void cashthroughotherincome()
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select SUM(amount) from Other_income where Date=@date";
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MMM-dd"));
                cashOther = (int)cmd.ExecuteScalar();

            } catch {
                cashOther = 0;
            }
          
        }
    }
}
