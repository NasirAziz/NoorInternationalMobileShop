using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaarDanaTraderPOS.Screens
{
    public partial class OtherIncome : Form
    {
        String desc, amount;
        DateTime date;

        SqlConnection con = new SqlConnection();
        public OtherIncome()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Other_income values(@desc,@amount,@date)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@desc", tbDesc.Text);
            cmd.Parameters.AddWithValue("@amount", tbExpense.Text);
            cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
             
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("OtherIncome Added Successfully");
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

        private void OtherIncome_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
        }
    }
}
