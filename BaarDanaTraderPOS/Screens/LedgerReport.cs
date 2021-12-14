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
    
    public partial class LedgerReport : Form
    {
        SqlConnection con = new SqlConnection();
        public static DataTable dt = new DataTable();
        

        public LedgerReport()
        {
            InitializeComponent();
        }
        public void LoadCustomer()
        {
            DataTable dtcustomer = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_customer";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dtcustomer);
            //dgvItems.DataSource = supplier;
            //dgvItems.Refresh();
            cmd.ExecuteNonQuery();

            //Insert the Default Item to DataTable.
            
            
           
            cbcustomername.DataSource = dtcustomer;
            cbcustomername.DisplayMember = "Name";
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Ledger_report where Date between @a and @b and Customer_name=@c";
            cmd.Parameters.AddWithValue("@a", fromdate.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@b", todate.Value.ToString("dd-MM-yyyy").ToString());
            cmd.Parameters.AddWithValue("@c", cbcustomername.GetItemText(cbcustomername.SelectedItem));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda =new  SqlDataAdapter(cmd);
            sda.Fill(dt);
            showitem.DataSource = dt;
            

            

        }

        private void LedgerReport_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
            dt.Rows.Clear();
            LoadCustomer();
        }

        private void cbcustomername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addRecovery_Click(object sender, EventArgs e)
        {
            AddRecovery rc = new AddRecovery();
            rc.Show();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            LedgerReportViewer a = new LedgerReportViewer();
            a.Show();
        }
    }
}
