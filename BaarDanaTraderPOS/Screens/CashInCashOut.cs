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
    public partial class CashInCashOut : Form
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection();
        DateTime now = DateTime.Now;
        DateTime fromDate, tillDate;
        double totalCashIn, totalCashOut, totalProfit, totalLoss;

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            fromDate = dtpFrom.Value.Date;
            tillDate = dtpTill.Value.Date;

            try
            {

                Salecash.Refresh();
                cmd.CommandText = "select * from Expenses where Date between @first And @second";
                cmd.Parameters.AddWithValue("@first", fromDate);
                cmd.Parameters.AddWithValue("@second", tillDate);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                dt.Clear();
                ad.Fill(dt);
              /*  dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Detail";
                dt.Columns[2].ColumnName = "CashOUT";*/
                cashoutexpg.DataSource = dt;
                cmd.ExecuteNonQuery();
                Salecash.Refresh();

            }
            catch ( Exception)
            {
                MessageBox.Show(e.ToString());

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void CashIn()
        {
            
            int totalsales, totalotherincome;


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try {
                cmd.CommandText = "SELECT SUM(Total) FROM Sales_report where Date=@d";
                cmd.Parameters.AddWithValue("@d", now.ToString("yyyy-MM-dd"));
                totalsales = (int)cmd.ExecuteScalar();
            } catch
            {
                totalsales = 0;
            }
            try
            {
                cmd.CommandText = "SELECT SUM(amount) FROM Other_income where date=@date";
                cmd.Parameters.AddWithValue("@date", now.ToString("yyyy-MM-dd"));
                totalotherincome = (int)cmd.ExecuteScalar();
        }
            catch
            {
                totalotherincome = 0;
            }


    totalCashIn = totalotherincome + totalsales;
           // MessageBox.Show(cashin.ToString()) ;

        }



        public void CashOut()
        {
            DateTime now = DateTime.Now;
            //int totalExpanse;


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT SUM(amount) FROM Expenses where date=@d";
                cmd.Parameters.AddWithValue("@d", now.ToString("yyyy-MM-dd"));
                totalCashOut = (int)cmd.ExecuteScalar();

            }
            catch 
            {
                totalCashOut = 0;

            }
            try
            {
                cmd.CommandText = "SELECT SUM(price) FROM Sales_return where date=@d1";
                cmd.Parameters.AddWithValue("@d1", now.ToString("yyyy-MM-dd"));
                totalCashOut += (int)cmd.ExecuteScalar();
            }
            catch
            {
                totalCashOut += 0;
            }

            //MessageBox.Show(totalExpanse.ToString());

        }

        public CashInCashOut()
        {
            InitializeComponent();
        }
        public void cashthroughsale()
        {
            DataTable cashsale = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Sales_report where Date=@date";
            cmd.Parameters.AddWithValue("@date", now.ToString("yyyy-MMM-dd"));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(cashsale);
            Salecash.DataSource = cashsale;
           
        }
        public void cashthroughotherincome()
        {
            DataTable cashotherincome = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Other_income where Date=@date";
            cmd.Parameters.AddWithValue("@date", now.ToString("yyyy-MMM-dd"));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(cashotherincome);
            Othercash.DataSource = cashotherincome;
        }
        public void cashoutexp()
        {
            DataTable cashout = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Expenses where Date=@date";
            cmd.Parameters.AddWithValue("@date", now.ToString("yyyy-MMM-dd"));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(cashout);
            cashoutexpg.DataSource = cashout;

        }
        public void cashOutSalesReturn()
        {
            DataTable saleReturn = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Sales_return where date=@date";
            cmd.Parameters.AddWithValue("@date", now.ToString("yyyy-MMM-dd"));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(saleReturn);
            dgvSalesReturn.DataSource = saleReturn;

        }

        private void CashInCashOut_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
            CashIn();
            CashOut();
            lbl_CashIn.Text = totalCashIn.ToString();
            lbl_CashOut.Text = totalCashOut.ToString();
            cashthroughotherincome();
            cashthroughsale();
            cashoutexp();
            cashOutSalesReturn();
            Salecash.Columns["Sale_id"].Visible = false;
            Salecash.Columns["Invoice_id"].Visible = false;
            Salecash.Columns["Customer_name"].Visible = false;
            Salecash.Columns["Profit"].Visible = false;
        }

    }
}
