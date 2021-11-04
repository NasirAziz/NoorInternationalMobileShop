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
    public partial class AddItemForm : Form
    {
        DataTable Item = new DataTable();
        DataTable dtSupplier = new DataTable();

        String dateOfExpiry;
        String supplier;

        SqlConnection con = new SqlConnection();
        public int id, price, purchase, quantity;
        public String name, company, barcode;
        public static int totalBill, supplierID;

        public static DataTable dtOrder;
          
        public AddItemForm()
        {
            InitializeComponent();
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            dgvItems.DataSource = dtOrder;

            if (tbItemName.Text.Length != 0 && tbItemPrice.Text.Length != 0 && tbItemQuantity.Text.Length != 0)
            {
                String barcode = tbBarCode.Text;
                bool contains = dtOrder.AsEnumerable().Any(row => barcode == row.Field<String>("BarCode"));
                if (contains)
                {
                    MessageBox.Show("Error! Item With SAME BARCODE already exists");
                    return;
                }
                dtOrder.Rows.Add(
                    tbItemName.Text, 
                    tbItemPrice.Text, 
                    tbItemQuantity.Text, 
                    tbBarCode.Text, 
                    DateOfExpiry.Value.Date.ToString("dd-MM-yyyy"), 
                    cbCompany.GetItemText(cbCompany.SelectedItem), 
                    tbPurchasePrice.Text, 
                    cbSupplier.GetItemText(cbSupplier.SelectedItem));

               
                CalculateTotalPrice();

                
               /* SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Add_item values(@name,@price,@quantity,@barcode,@company,@purchase,@DateOFExpiry)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", tbItemName.Text);
                cmd.Parameters.AddWithValue("@price", tbItemPrice.Text);
                cmd.Parameters.AddWithValue("@quantity", tbItemQuantity.Text);
                cmd.Parameters.AddWithValue("@barcode", tbBarCode.Text);
                cmd.Parameters.AddWithValue("@company", cbCompany.GetItemText(cbCompany.SelectedItem));
                cmd.Parameters.AddWithValue("@purchase", tbPurchasePrice.Text);
                cmd.Parameters.AddWithValue("DateOfExpiry", DateOfExpiry.Value.Date);

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Item Added Successfully");
                        Resettext();

                    }
                    else
                    {
                        MessageBox.Show("Item Not Added");
                    }
                }
                catch
                {
                    MessageBox.Show("Please add valid data!");
                }
                LoadItems();*/
            }
            else
            {
                MessageBox.Show("Please Fill the required fields!");
            }

        }
        private void UpdateItem(int id, String name, int price, int quantity)
        {

            if (dgvItems.DataSource == Item) { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Add_item SET Name=@name, Price=@price, Quantity=@quantity, Purchase_price=@purchase WHERE Item_id=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@purchase", tbPurchasePrice.Text);


            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("Updated");
                LoadItems();
                Resettext();

                }

            }
            else
            {

                String barcode = tbBarCode.Text;
                DataRow dr = dtOrder.Select($"BarCode={barcode}").FirstOrDefault(); // finds all rows with thta barcode and selects first or null if haven't found any
                if (dr != null)
                {
                    dr["Name"] = tbItemName.Text; //changes the Product_name
                    dr["Price"] = tbItemPrice.Text;
                    dr["Quantity"] = tbItemQuantity.Text;
                    dr["BarCode"] = barcode;
                    dr["DateOfExpiry"] = DateOfExpiry.Value.Date.ToString("dd-MM-yyyy");
                    dr["Company"] = cbCompany.GetItemText(cbCompany.SelectedItem) ;
                    dr["Purchase_price"] = tbPurchasePrice.Text;
                    dr["Supplier"] = cbSupplier.GetItemText(cbSupplier.SelectedItem) ;

                    Resettext();

                }

            }

        }
        private void LoadItems()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            Item.Clear();
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();

        }

        private void CalculateTotalPrice()
        {
          
            totalBill = 0;
            foreach (DataRow row in dtOrder.Rows)
            {
                int qty = int.Parse(row["Quantity"].ToString());
                int purchase = int.Parse(row["Purchase_price"].ToString());
                totalBill += qty * purchase;
            }
            lblTotalBill.Text = totalBill.ToString();
           // FinalPrice = (grandTotal + Balance);
            //lblFinal.Text = FinalPrice.ToString();
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

            dtOrder = new DataTable();
            dtOrder.Columns.Add("Name");
            dtOrder.Columns.Add("Price", typeof(int));
            dtOrder.Columns.Add("Quantity", typeof(int));
            dtOrder.Columns.Add("BarCode");
            dtOrder.Columns.Add("DateOfExpiry");
            dtOrder.Columns.Add("Company");
            dtOrder.Columns.Add("Purchase_price", typeof(int));
            dtOrder.Columns.Add("Supplier");

            LoadItems();
            LoadSupplier();
            LoadCompany();

        }

        private void btnAISearch_Click(object sender, EventArgs e)
        {
            DataTable Item = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item where Name Like @name +'%'  ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbAISearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();
        }
        private void DeleteItem(int id)
        {
            if (dgvItems.DataSource == Item)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Add_item where Item_id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                LoadItems();
                Resettext();
            }
            else
            {

                String barcode = tbBarCode.Text;
                DataRow dr = dtOrder.Select($"BarCode={barcode}").FirstOrDefault(); // finds all rows with thta barcode and selects first or null if haven't found any
                if (dr != null)
                {
                    dtOrder.Rows.Remove(dr);
                    Resettext();

                }

            }


        }
        public void LoadCompany()
        {
            try
            {
                DataTable company = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Company";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(company);

                //Insert the Default Item to DataTable.
                DataRow row = company.NewRow();
                row[0] = 0;
                row[1] = "Default";
                company.Rows.InsertAt(row, 0);
                cbCompany.DataSource = company;
                cbCompany.DisplayMember = "CompanyName";
                cbCompany.ValueMember = "id";
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading Companies or No Companies to load");
            }

        }
        public void LoadSupplier()
        {
/*            try
            {*/
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Add_supplier";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dtSupplier);
                //dgvItems.DataSource = supplier;
                //dgvItems.Refresh();
                cmd.ExecuteNonQuery();

                //Insert the Default Item to DataTable.
                DataRow row = dtSupplier.NewRow();
                row[0] = 0;
                row[1] = "Default";
                dtSupplier.Rows.InsertAt(row, 0);
                cbSupplier.DataSource = dtSupplier;
                cbSupplier.DisplayMember = "Name";
                //cbSupplier.ValueMember = "Supplier_ID";

                

/*            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading Suppliers");
            }*/

        }
        private void btnItemUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                name = tbItemName.Text;
                price = Convert.ToInt32(tbItemPrice.Text);
                quantity = Convert.ToInt32(tbItemQuantity.Text);
                UpdateItem(id, name, price, quantity);
                Resettext();


            }
            catch
            {

            }
        }
        private void Resettext()
        {
            tbItemName.Text = "";
            tbItemPrice.Text = "";
            tbItemQuantity.Text = "";
            tbPurchasePrice.Text = "";
            tbBarCode.Text = "";
            cbCompany.SelectedIndex = 0;
            
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            DeleteItem(id);
            //LoadItems();
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadItems();
            Resettext();
            tbAISearch.Text = "";
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            AddItemFinishForm f = new AddItemFinishForm();
            f.Show();
        }

        private void cbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                supplierID = int.Parse(dtSupplier.Rows[cbSupplier.SelectedIndex]["Supplier_id"].ToString());
                //MessageBox.Show(supplierID.ToString());
            }
            catch
            {

            }
           
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            Comapany cm = new Comapany
                ();
            cm.Show();
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCompany_Click(object sender, EventArgs e)
        {
            LoadCompany();
        }

        private void tbAISearch_TextChanged(object sender, EventArgs e)
        {
            DataTable Item = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Add_item where Name Like @name + '%'";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", tbAISearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Item);
            dgvItems.DataSource = Item;
            cmd.ExecuteNonQuery();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                id = Convert.ToInt32(dgvItems.CurrentRow.Cells[0].Value.ToString());
                name = dgvItems.CurrentRow.Cells[1].Value.ToString();
                price = Convert.ToInt32(dgvItems.CurrentRow.Cells[2].Value.ToString());
                quantity = Convert.ToInt32(dgvItems.CurrentRow.Cells[3].Value.ToString());
                purchase = Convert.ToInt32(dgvItems.CurrentRow.Cells[6].Value.ToString());
                barcode = dgvItems.CurrentRow.Cells[4].Value.ToString();
                company = dgvItems.CurrentRow.Cells[7].Value.ToString();
                dateOfExpiry = dgvItems.CurrentRow.Cells[5].Value.ToString();

                //MessageBox.Show(company);
                tbItemName.Text = name;
                tbItemPrice.Text = price.ToString();
                tbItemQuantity.Text = quantity.ToString();
                tbPurchasePrice.Text = purchase.ToString();
                tbBarCode.Text = barcode;
                cbCompany.SelectedIndex = cbCompany.Items.IndexOf(company);
                DateOfExpiry.Value = DateTime.Parse(dateOfExpiry);

            }
            catch
            {
               // id = Convert.ToInt32(dgvItems.CurrentRow.Cells[0].Value.ToString());
                name = dgvItems.CurrentRow.Cells[0].Value.ToString();
                price = Convert.ToInt32(dgvItems.CurrentRow.Cells[1].Value.ToString());

                purchase = Convert.ToInt32(dgvItems.CurrentRow.Cells[6].Value.ToString());
                quantity = Convert.ToInt32(dgvItems.CurrentRow.Cells[2].Value.ToString());
                barcode = dgvItems.CurrentRow.Cells[3].Value.ToString();
                dateOfExpiry =  dgvItems.CurrentRow.Cells[4].Value.ToString();
                company = dgvItems.CurrentRow.Cells[5].Value.ToString();
                supplier = dgvItems.CurrentRow.Cells[7].Value.ToString();

                tbItemName.Text = name;
                tbItemPrice.Text = price.ToString();
                tbPurchasePrice.Text = purchase.ToString();
                tbItemQuantity.Text = quantity.ToString();
                tbBarCode.Text = barcode;
                DateOfExpiry.Value = DateTime.Parse(dateOfExpiry);
                cbCompany.SelectedIndex = cbCompany.Items.IndexOf(company);
            }
/*            catch
            {
                MessageBox.Show("Error");
            }*/
        }
    }
}
