using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaarDanaTraderPOS.Screens;
using System.Data.SqlClient;
namespace BaarDanaTraderPOS
{
    public partial class Product_Key : Form
    {
        SqlConnection con = new SqlConnection();
        Form1 _f;
        public String productkey = "NHTECH-0317-0312-0508-0828-334-136";
        public Product_Key(Form1 f)
        {
            InitializeComponent();
            _f = f;
            
        }

        private void Product_Key_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (License.Text == productkey)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into ProductKey values(@a)";
                cmd.Parameters.AddWithValue("@a", License.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Now your License holder of NHTechPOS.......Thanks");


                _f.Enabled = true;
                this.Close()
;            }

            else
            {
                MessageBox.Show("You Entered Wron Product Key Contact NHTech");
                
            }
        }
    }
}
