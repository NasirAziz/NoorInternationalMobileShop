using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using System.Data.SqlClient;


namespace BaarDanaTraderPOS.Screens
{
    public partial class Signin : Form
    {
        SqlConnection con = new SqlConnection();
        public static String name, pass;

        public Signin()
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
                
                Form1 f = new Form1();
                this.Hide();
                name = tbName.Text;
                pass = tbPassword.Text;
                f.Show();

            }
            else
            {
                MessageBox.Show("Check your password and username");
            }
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
