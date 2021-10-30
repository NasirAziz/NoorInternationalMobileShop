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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection();
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Users where Name = @a and Password = @b";
            cmd.Parameters.AddWithValue("@a", tbName.Text);
            cmd.Parameters.AddWithValue("@b", tbPassword.Text);

            SqlDataAdapter a = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            a.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Check your password and username");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

        }
    }
}
