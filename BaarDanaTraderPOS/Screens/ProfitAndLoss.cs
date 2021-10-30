using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaarDanaTraderPOS.Screens
{
    public partial class ProfitAndLoss : Form
    {
        SqlConnection con;
        DataTable dt, dt2;
        double total,expense;
        String fromdate;
        String todate;

        public ProfitAndLoss()
        {
            InitializeComponent();
        }

        private void ProfitAndLoss_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(Connection.c);
            con.Open();
            from.Value = DateTime.Now;
            to.Value = DateTime.Now;

            fromdate = DateTime.Now.ToString("yyyy-MM-dd");
            todate = DateTime.Now.ToString("yyyy-MM-dd");


            dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {


                dgvSalesProfit.Refresh();
                cmd.CommandText = "select * from Sales_report WHERE Date between @first And @second";
                cmd.Parameters.AddWithValue("@first", Convert.ToDateTime(fromdate));
                cmd.Parameters.AddWithValue("@second", Convert.ToDateTime(todate));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dt.Clear();
                ad.Fill(dt);
                dgvSalesProfit.DataSource = dt;

                dgvSalesProfit.Refresh();

            }
            catch
            {


            }

            try
            {
                dt2 = new DataTable();
                dgvOtherProfit.Refresh();
                cmd.CommandText = "select * from Other_income WHERE date between @first2 And @second2";
                cmd.Parameters.AddWithValue("@first2", Convert.ToDateTime(fromdate));
                cmd.Parameters.AddWithValue("@second2", Convert.ToDateTime(todate));
                SqlDataAdapter ad2 = new SqlDataAdapter(cmd);
                // DataTable viewhistory = new DataTable();
                cmd.ExecuteNonQuery();
                dt2.Clear();
                ad2.Fill(dt2);
                dgvOtherProfit.DataSource = dt2;

                dgvOtherProfit.Refresh();

            }
            catch { }

            dgvSalesProfit.Columns["Sale_id"].Visible = false;
            dgvSalesProfit.Columns["Price"].Visible = false;
            dgvSalesProfit.Columns["Customer_name"].Visible = false;
            dgvSalesProfit.Columns["Product_id"].Visible = false;


            calculateTotal();
            calculateExpense();


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

           dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = con;
           String fromdate = from.Value.ToString("yyyy-MM-dd");
           String todate = to.Value.ToString("yyyy-MM-dd");

                try
                {


                dgvSalesProfit.Refresh();
                cmd.CommandText = "select * from Sales_report WHERE Date between @first And @second";
                cmd.Parameters.AddWithValue("@first", Convert.ToDateTime(fromdate));
                cmd.Parameters.AddWithValue("@second", Convert.ToDateTime(todate));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                // DataTable viewhistory = new DataTable();
                cmd.ExecuteNonQuery();
                dt.Clear();
                ad.Fill(dt);
                dgvSalesProfit.DataSource = dt;

                dgvSalesProfit.Refresh();

                }
                catch
                {


                }


            dt2 = new DataTable();


                dgvOtherProfit.Refresh();
                cmd.CommandText = "select * from Other_income WHERE date between @first2 And @second2";
                cmd.Parameters.AddWithValue("@first2", Convert.ToDateTime(fromdate));
                cmd.Parameters.AddWithValue("@second2", Convert.ToDateTime(todate));
                SqlDataAdapter ad2 = new SqlDataAdapter(cmd);
                // DataTable viewhistory = new DataTable();
                cmd.ExecuteNonQuery();
                dt2.Clear();
                ad2.Fill(dt2);
                dgvOtherProfit.DataSource = dt2;

                dgvOtherProfit.Refresh();

            calculateTotal();

            calculateExpense();
          
/*
            if(expense > total)
                lblLoss.Text = expense.ToString();
            else
                lblLoss.Text = "0";*/

        }

        void calculateExpense()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT SUM(amount) FROM Expenses where date  between @first3 And @second3";
                cmd.Parameters.AddWithValue("@first3", Convert.ToDateTime(fromdate));
                cmd.Parameters.AddWithValue("@second3", Convert.ToDateTime(todate));

                expense = (int)cmd.ExecuteScalar();
            }
            catch
            {
                expense = 0;

            }

            lblExpenses.Text = expense.ToString();

            double loss = total - expense;


            if (loss < 0)
            {
                loss = loss * -1;
                MessageBox.Show(loss.ToString());
                total = 0;
                lblTotalProfit.Text = total.ToString();
                lblLoss.Text = loss.ToString();

            }
            else
            {
                lblTotalProfit.Text = loss.ToString();
            }
        }

        void calculateTotal()
        {
            total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += double.Parse(row[9].ToString());
            }
            foreach (DataRow row in dt2.Rows)
            {
                total += double.Parse(row[2].ToString());
            }
            lblProfit.Text = total.ToString();
        }
    }


}
