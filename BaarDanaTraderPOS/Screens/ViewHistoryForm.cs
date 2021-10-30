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
    public partial class ViewHistoryForm : Form
    {
        SqlConnection con = new SqlConnection();
        public string fromdate, todate;
        bool flag = false;
        public static DataTable viewhistory = new DataTable();
        public static double total, sale_id, Quantity, Price, Total, Product_id, Profit,Invoice_id;
        public static string Product_name;



        public ViewHistoryForm()
        {
            InitializeComponent();
        }

        void calculateTotal()
        {
            total = 0;
            foreach (DataRow row in viewhistory.Rows)
            {
                total += double.Parse(row["Total"].ToString());
            }
            lblTotal.Text = total.ToString();
        }

        private void ViewHistoryForm_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

            viewhistory.Rows.Clear();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Sales_report";
            cmd.Parameters.AddWithValue("@name", tbCustomerSearch.Text);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(viewhistory);
            cmd.ExecuteNonQuery();
            dgvViewHistory.DataSource = viewhistory;

            dgvViewHistory.Columns["Invoice_id"].DisplayIndex = 0;
            dgvViewHistory.Columns["Customer_name"].DisplayIndex = 2;
            dgvViewHistory.Columns["Product"].DisplayIndex = 3;
            dgvViewHistory.Columns["Date"].DisplayIndex = 7;

            calculateTotal();


        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            fromdate = from.Value.ToString("yyyy-dd-MM");
            todate = to.Value.ToString("yyyy-dd-MM");

            if (flag)
            {
                try
                {


                    dgvViewHistory.Refresh();
                    cmd.CommandText = "select * from Sales_report where Customer_name Like @name + '%' and Date between @first And @second";
                    cmd.Parameters.AddWithValue("@name", tbCustomerSearch.Text);
                    cmd.Parameters.AddWithValue("@first", Convert.ToDateTime(fromdate));
                    cmd.Parameters.AddWithValue("@second", Convert.ToDateTime(todate));
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    // DataTable viewhistory = new DataTable();
                    viewhistory.Clear();
                    ad.Fill(viewhistory);
                    dgvViewHistory.DataSource = viewhistory;
                    cmd.ExecuteNonQuery();
                    dgvViewHistory.Refresh();

                }
                catch
                {


                }
            }
            else
            {

                dgvViewHistory.Refresh();
                cmd.CommandText = "select * from Sales_report where Customer_name Like @name + '%'";
                cmd.Parameters.AddWithValue("@name", tbCustomerSearch.Text);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //DataTable viewhistory = new DataTable();
                viewhistory.Clear();

                ad.Fill(viewhistory);
                cmd.ExecuteNonQuery();
                dgvViewHistory.DataSource = viewhistory;
            }

            try
            {

                dgvViewHistory.Refresh();
                cmd.CommandText = "select * from Sales_report where Invoice_id=@id";
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbCustomerSearch.Text));
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                // DataTable viewhistory = new DataTable();
                viewhistory.Clear();

                ad.Fill(viewhistory);
                cmd.ExecuteNonQuery();
                dgvViewHistory.DataSource = viewhistory;

            }
            catch
            {

            }
            calculateTotal();
        }

        private void from_ValueChanged(object sender, EventArgs e)
        {
            flag = true;
            to.MinDate = from.Value.Date;
        }

        private void btn_print_Click_1(object sender, EventArgs e)
        {
            ViewHistoryReport a = new ViewHistoryReport();
            a.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Show_All_Click(object sender, EventArgs e)
        {
            viewhistory.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Sales_report";
            cmd.Parameters.AddWithValue("@name", tbCustomerSearch.Text);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(viewhistory);
            cmd.ExecuteNonQuery();
            dgvViewHistory.DataSource = viewhistory;

            calculateTotal();
        }

        private void dgvViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvViewHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sale_id = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[0].Value.ToString());
            Product_name = dgvViewHistory.CurrentRow.Cells[5].Value.ToString();
            Quantity = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[2].Value.ToString());
            Price = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[3].Value.ToString());
            Total = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[4].Value.ToString());
            Product_id = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[8].Value.ToString());
            Invoice_id = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[7].Value.ToString());
            Profit = Convert.ToDouble(dgvViewHistory.CurrentRow.Cells[9].Value.ToString());
            SalesReturn salesReturn = new SalesReturn(Price, Quantity, Total, Product_name, sale_id,Product_id, Profit,Invoice_id);
            salesReturn.Show();

        }

        private void to_ValueChanged(object sender, EventArgs e)
        {
            flag = true;
        }
    }
}
