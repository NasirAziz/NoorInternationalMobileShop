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
    public partial class StockReport : Form
    {
        SqlConnection con = new SqlConnection();
        public static DataTable Item= new DataTable();

        public StockReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item where Name Like @name + '%'";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbSearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
            LoadItems();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadItems();
            
        }
        private void LoadItems()
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item";
            cmd.CommandType = CommandType.Text;
            Item.Clear();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item where Name Like @name + '%'";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbSearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockReportViewer a = new StockReportViewer();
            a.Show();
        }
    }
}
