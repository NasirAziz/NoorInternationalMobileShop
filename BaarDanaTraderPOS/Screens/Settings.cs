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
    public partial class Settings : Form
    {
        String Shop_name, Phno, footer;
        SqlConnection con = new SqlConnection();
       
        public Settings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Settings SET Shop_name = @s, Phone_number =@p,Footer=@f WHERE id = 1 ";
                cmd.Parameters.AddWithValue("@s", tbNameOfShop.Text);
                cmd.Parameters.AddWithValue("@p", tbPhNo.Text);
                cmd.Parameters.AddWithValue("@f", tbFooter.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully");
            }
            catch
            {

            }

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Shop_name from Settings";
            Shop_name = (String)cmd.ExecuteScalar();
            cmd.CommandText = "select Phone_number from Settings";
            Phno = (String)cmd.ExecuteScalar();
            cmd.CommandText = "select Footer from Settings";
            footer = (String)cmd.ExecuteScalar();
            tbFooter.Text = footer;
            tbNameOfShop.Text = Shop_name;
            tbPhNo.Text = Phno;

        }
    }
}
