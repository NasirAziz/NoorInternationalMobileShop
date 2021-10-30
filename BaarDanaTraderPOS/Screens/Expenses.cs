using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaarDanaTraderPOS.Screens
{
    public partial class Expenses : Form
    {
        String desc, amount;
        DateTime date;

        SqlConnection con = new SqlConnection();

        public Expenses()
        {
            InitializeComponent();
        }
        public void cashout()
        {

        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Expenses values(@desc,@amount,@date)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@desc", tbDesc.Text);
            cmd.Parameters.AddWithValue("@amount", tbExpense.Text);
            cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);

            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Expense Added Successfully");
                    //Resettext();

                }
                else
                {
                    MessageBox.Show("Expense Not Added");
                }
            }
            catch
            {
                MessageBox.Show("Please add valid data!");
            }

        }
    }
}
