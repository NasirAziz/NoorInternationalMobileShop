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
    public partial class Users : Form
    {
        string name, password;
        string s;
        SqlConnection con;
        int Uid;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Users values(@Name,@Password,@Permissions)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", tbName.Text);
            cmd.Parameters.AddWithValue("@Password", tbPassword.Text);
            cmd.Parameters.AddWithValue("@Permissions", s);

            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("User Added Successfully");
                    UpdateGrid();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch
            {
                MessageBox.Show("Please Fill the required fields!");
            }
        }

        private void permissionsList_Validating(object sender, CancelEventArgs e)
        {
/*            var list = permissionsList.SelectedItems;
            if (list.Contains("Create Order"))
                createOrder = "CreateOrder";
            else
                createOrder = "";
            if (list.Contains("Add Product"))
                addProduct = "AddProduct";
            else
                addProduct = "";

            if (list.Contains("Sales Report"))
                salesReport = "SalesReport";
            else
                salesReport = "";
            if (list.Contains("Cash Report"))
                cashReport = "CashReport";
            else
                cashReport = "";

            if (list.Contains("Add Other Income"))
                addOtherIncome = "AddOtherIncome";
            else
                addOtherIncome = "";
            if (list.Contains("Profit Loss"))
                profitLoss = "ProfitLoss";
            else
                profitLoss = "";

            if (list.Contains("Add Expenses"))
                addExpenses = "AddExpenses";
            else
                addExpenses = "";
            if (list.Contains("Settings"))
                settings = "Settings";
            else
                settings = "";

            if (list.Contains("Users"))
                users = "Users";
            else
                users = "";

            MessageBox.Show(users.ToString() + settings.ToString() + createOrder.ToString());*/

            if (permissionsList.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                s = "";
                for (int x = 0; x < permissionsList.CheckedItems.Count; x++)
                {
                    s = s + permissionsList.CheckedItems[x].ToString() + ",";
                }
               // MessageBox.Show(s);
            }
        }
 

        private void permissionsList_Validated(object sender, EventArgs e)
        {
           
        }


        public Users()
        {
            InitializeComponent();
        }


        private void permissionsList_SelectedValueChanged(object sender, EventArgs e)
        {

           

        }

        private void Users_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(Connection.c);
            con.Open();
            UpdateGrid();

        }
        void UpdateGrid() {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Users";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dgvUsers.DataSource = dt;
        }

        void ResetForm()
        {
            tbName.Text = "";
            tbPassword.Text = "";
            permissionsList.ClearSelected();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Users WHERE Users_id=@id AND Name=@Name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", Uid);
            cmd.Parameters.AddWithValue("@Name", tbName.Text);

            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("User Deleted");
                    UpdateGrid();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch
            {
                MessageBox.Show("Please Fill the required fields!");
            }
        }


        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Uid = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString());
                name = dgvUsers.CurrentRow.Cells[1].Value.ToString();
                password = dgvUsers.CurrentRow.Cells[2].Value.ToString();
                s = dgvUsers.CurrentRow.Cells[3].Value.ToString();
         
                tbName.Text = name;
                tbPassword.Text = password;
                
            }
            catch
            {

            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Users SET Name=@name, Password=@password, Permissions=@s WHERE Users_id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@id", Uid);
                cmd.Parameters.AddWithValue("@password", tbPassword.Text);
                cmd.Parameters.AddWithValue("@s", s);

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("User Updated");
                    ResetForm();
                    UpdateGrid();
                }
            } 
            catch 
            {
                MessageBox.Show("Error");
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void permissionsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
