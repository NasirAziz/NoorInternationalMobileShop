using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        public void LockSodtware()
        {
            string dateString = "11/27/2021 7:10:24 AM";
            DateTime dateFromString =
                DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            DateTime start, End;
            End = dateFromString.AddDays(365);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Product_key from ProductKey where ID=@i";
            cmd.Parameters.AddWithValue("@i", 1);

            String c = (String) cmd.ExecuteScalar();
            if (c != "NHTECH-0317-0312-0508-0828-334-136")
            {
                if (DateTime.Now >= dateFromString)
                {
                    
                    Product_Key a = new Product_Key(this);
                    this.Enabled = false;
                    a.Show();
                    

                }
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            try
            {
                con.Open();
                notificationalert();
            }
            catch
            {
                MessageBox.Show("Error! Database not found.");
            }
            LockSodtware();

        }

        private void btnCreateOrder(object sender, EventArgs e)
        {
            bool isPermitted = CheckForPermissions("Create Order");
            if (!isPermitted)
            {
                return;
            }
            CreateOrderForm cof = new CreateOrderForm();
            cof.Show();
        }

        private void btnViewHistory(object sender, EventArgs e)
        {
            bool isPermitted = CheckForPermissions("Sales Report");
            if (!isPermitted)
            {
                return;
            }
            ViewHistoryForm vhf = new ViewHistoryForm();
            vhf.Show();

        }

        private void btnAddItem(object sender, EventArgs e)
        {bool isPermitted = CheckForPermissions("Add Product");
            if (!isPermitted)
            {
                return;
            }
            AddItemForm aif = new AddItemForm();
            aif.Show();
         }

        private void btnAddCustomer(object sender, EventArgs e)
        {
            bool isPermitted = CheckForPermissions("Cash Report");
            if (!isPermitted)
            {
                return;
            }
            CashInCashOut cash = new CashInCashOut();
            cash.Show();
         }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            StockReport s = new StockReport();
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            bool isPermitted = CheckForPermissions("Add Expenses");
            if (!isPermitted)
            {
                return;
            }
            Expenses exp = new Expenses();
            exp.Show();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            bool isPermitted = CheckForPermissions("Add Other Income");
            if (!isPermitted)
            {
                return;
            }

            OtherIncome c = new  OtherIncome();
            c.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {bool isPermitted = CheckForPermissions("Profit Loss");
            if (!isPermitted)
            {
                return;
            }
            ProfitAndLoss pf = new ProfitAndLoss();
            pf.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       /* private void Form1_Activated(object sender, EventArgs e)
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
        }*/

       /* public void cashthroughsale()
        {
            *//*try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT SUM(price) FROM Sales_report where date=@d1";
                cmd.Parameters.AddWithValue("@d1", DateTime.Now.ToString("yyyy-MMM-dd"));
                cashSale = (int)cmd.ExecuteScalar();

            } catch {
                cashSale = 0;
            }*//*
          

        }
*/
        private void btnUsers_Click(object sender, EventArgs e)
        {


            CheckExpiry exp = new CheckExpiry();

         
            exp.Show();


        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm supplier = new SuppliersForm();
            supplier.Show();
        }

        bool CheckForPermissions(String btn) {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Permissions from Users WHERE Name=@name AND Password=@password";
            cmd.Parameters.AddWithValue( "@name", Signin.name);
            cmd.Parameters.AddWithValue("@password",Signin.pass);

            String permissions = (String)cmd.ExecuteScalar();

            if (!permissions.Contains(btn))
            {
                MessageBox.Show("You dont have permission to access this field.");
            }

            return permissions.Contains(btn);
           
                 
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
       /* public void cashthroughotherincome()
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
*/
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm adc = new AddCustomerForm();
            adc.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
             LedgerReport a = new LedgerReport();
             a.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {

            bool isPermitted = CheckForPermissions("Users");
            if (!isPermitted) {
                return;
            }

            Users u = new Users();
          
            u.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool isPermitted = CheckForPermissions("Settings");
            if (!isPermitted)
            {
                return;
            }
            Settings s = new Settings();
            s.Show();
        }

        protected void Displaynotify()
        {

            alert.Icon = new Icon(Path.GetFullPath(@"images\alert.ico"));
            alert.Text = "Click To Open Expiry Window";
            alert.Visible = true;
            alert.BalloonTipTitle = "Some Items will Expired After 14 Days";
            alert.BalloonTipText = "Click Here to see details";
            alert.ShowBalloonTip(100);


        }
        public void notificationalert()
        {

            DataTable dt = new DataTable();
            DateTime dt1 = DateTime.Now;
            DateTime todaydate = dt1.Date;
            todaydate = todaydate.AddDays(14);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Add_item where DateOfExpiry = @d";
            cmd.Parameters.AddWithValue("@d", todaydate.Date.ToString("dd-MM-yyyy"));
            cmd.ExecuteNonQuery();
            int r = cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dgvexpiry.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                Displaynotify();

            }
        }

    }
}
