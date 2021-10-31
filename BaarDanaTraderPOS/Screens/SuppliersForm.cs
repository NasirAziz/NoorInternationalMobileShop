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
    public partial class SuppliersForm : Form
    {
        SqlConnection con = new SqlConnection();
        public double id, balance;
        public String name, address, phno;

        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            DataTable suppliers = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_supplier";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(suppliers);
            dgvSuppliers.DataSource = suppliers;
            cmd.ExecuteNonQuery();

        }

        public void ResetTextFields()
        {
            tbAddress.Text = "";
            tbBalance.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Add_supplier values(@name,@phone,@address,@balance)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbName.Text);
            cmd.Parameters.AddWithValue("@phone", tbPhone.Text);
            cmd.Parameters.AddWithValue("@address", tbAddress.Text);
            cmd.Parameters.AddWithValue("@balance", tbBalance.Text);
            try
            {
                if (tbBalance.Text.Length>0 && tbPhone.Text.Length > 0 && tbName.Text.Length > 0)
                {
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Supplier Added Successfully");
                        LoadSuppliers();
                        ResetTextFields();
                    }
                    else
                    {
                        MessageBox.Show("Error Could Not Add");
                    }
                }

                else
                    MessageBox.Show("Please Fill the required fields!");
               
            }
            catch
            {
                MessageBox.Show("Please Fill the required fields!");
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String name = tbSearch.Text;
            SearchForSupplier(name);
        }

        private void SearchForSupplier(String name)
        {
            if (name.Length == 0)
            {
                MessageBox.Show("Please enter name to search!");
            }
            else if (name.Length > 0)
            {
                DataTable Supplier = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Add_supplier where Name Like @name +'%'";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(Supplier);
                dgvSuppliers.DataSource = Supplier;
                cmd.ExecuteNonQuery();

            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            String name = tbName.Text;
            DeleteSupplier(id);

        }

        private void DeleteSupplier(double id)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from Add_supplier where Supplier_id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            LoadSuppliers();
            ResetTextFields();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                name = tbName.Text;
                phno = tbPhone.Text;
                try
                {
                    balance = Convert.ToDouble(tbBalance.Text);
                }
                catch
                {
                    balance = 0;
                }

                address = tbAddress.Text;
            }
            catch
            {
                MessageBox.Show("Please fill the requiered field");
            }

            UpdateSupplier(id, name, address, phno, balance);



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadSuppliers();
            tbSearch.Text = "";
        }


        private void UpdateSupplier(double id, String name, String address, String phone, double balance)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Add_supplier SET Name=@name, Phone_no=@phone, Address=@address, Balance=@balance WHERE Supplier_id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@balance", balance);
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("Updated");
                ResetTextFields();
            }
            LoadSuppliers();


        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

            DataTable Supplier = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_supplier where Name Like @name + '%'";

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbSearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Supplier);
            dgvSuppliers.DataSource = Supplier;
            cmd.ExecuteNonQuery();
        }

        private void dgvSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToDouble(dgvSuppliers.CurrentRow.Cells[0].Value.ToString());
                name = dgvSuppliers.CurrentRow.Cells[1].Value.ToString();
                phno = dgvSuppliers.CurrentRow.Cells[2].Value.ToString();
                address = dgvSuppliers.CurrentRow.Cells[3].Value.ToString();
                balance = Convert.ToDouble(dgvSuppliers.CurrentRow.Cells[4].Value.ToString());
                tbName.Text = name;
                tbPhone.Text = phno.ToString();
                tbBalance.Text = balance.ToString();
                tbAddress.Text = address;
            }
            catch
            {

            }

        }
    }
}
