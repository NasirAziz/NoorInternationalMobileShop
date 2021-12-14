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
    public partial class AddRecovery : Form
    {
        SqlConnection con = new SqlConnection();
        public int Balance;
        public AddRecovery()
        {
            InitializeComponent();
        }

        private void AddRecovery_Load(object sender, EventArgs e)
        {
            
            con.ConnectionString = Connection.c;
            con.Open();
            LoadCustomer();


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



            cbCustomerName.DataSource = dtcustomer;
            cbCustomerName.DisplayMember = "Name";
        }
        public void BalanaceGet()
        {
           // MessageBox.Show(cbCustomerName.SelectedItem.ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select Balance from Add_customer where Name=@n";
            cmd.Parameters.AddWithValue("@n", cbCustomerName.GetItemText(cbCustomerName.SelectedItem));
            try
            {


                int? balance =(int?) cmd.ExecuteScalar();
                if (balance == null)
                {
                    Balance = 0;
                }
                else
                {
                    Balance = (int) balance;
                }
            }
            catch(Exception e)
            {

            }
        }

        private void cbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        void UpdateBalance()
        {
            int newBalance = Balance - (Convert.ToInt32(paid.Text));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update Add_customer set Balance=@b where Name =@n";
            cmd.Parameters.AddWithValue("@b", newBalance);
            cmd.Parameters.AddWithValue("@n", cbCustomerName.GetItemText(cbCustomerName.SelectedItem));
            cmd.ExecuteNonQuery();
        }
        void UpdateLedger()
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Ledger_report values(@customername,@prevBalance,@purchase,@total,@paid,@date) ";
            cmd.Parameters.AddWithValue("@customername", cbCustomerName.GetItemText(cbCustomerName.SelectedItem));
            cmd.Parameters.AddWithValue("@prevBalance", Balance);
            cmd.Parameters.AddWithValue("@purchase", 0);
             cmd.Parameters.AddWithValue("@total", 0);
            cmd.Parameters.AddWithValue("@paid", paid.Text);
            cmd.Parameters.AddWithValue("@date", todaydate.Value.ToString("dd-MM-yyyy"));
            cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBalance();
            UpdateLedger();


        }

        private void cbCustomerName_SelectedValueChanged(object sender, EventArgs e)
        {
            BalanaceGet();
            tbBalance.Text = Balance.ToString();
        }
    }
}
