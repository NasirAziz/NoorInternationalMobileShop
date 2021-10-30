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
    public partial class Comapany : Form
    {
        SqlConnection con = new SqlConnection();
        
        public Comapany()
        {
            InitializeComponent();
        }

        private void Comapany_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Company values(@name)";
            cmd.Parameters.AddWithValue("@name",tbCompanyName.Text);
            if(cmd.ExecuteNonQuery()>0)
            {
               // MessageBox.Show("Comapny Added");
               // AddItemForm ad = new AddItemForm();
               // ad.LoadCompany();
                this.Close();

            }
            else
            {

            }
            
        }
    }
}
