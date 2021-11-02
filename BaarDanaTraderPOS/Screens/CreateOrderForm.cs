using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;

using System.Windows.Forms;

namespace BaarDanaTraderPOS.Screens
{
    public partial class CreateOrderForm : Form
    {
        private DataTable order = new DataTable();

        SqlConnection con = new SqlConnection();

        private String productName;
        private String customerName = "Waling Customer";
        private int price, id;
        public static int Invoice_id = 0;
        int inventory_quantity;
        private int quantity=0,chagne,purchase;
        // int timesEnterPressed = 0;
        public static int Balance, Paid;
        public int totalPrice, profit=0;
        public static int FinalPrice;
        public int grandTotal = 0;
        public bool flag = false, invoiceFlag = false;

        public CreateOrderForm()
        {
            InitializeComponent();

            con.ConnectionString = Connection.c;
            con.Open();

            order.Columns.Add("Product_id", typeof(int));
            order.Columns.Add("Product");
            order.Columns.Add("Quantity", typeof(int));
            order.Columns.Add("Price", typeof(int));
            order.Columns.Add("Total", typeof(int));
            order.Columns.Add("Date",typeof(DateTime));
            order.Columns.Add("Customer_name");
            order.Columns.Add("Invoice_id", typeof(int));            
            order.Columns.Add("Profit", typeof(int));

            /*            loaddataincategory();
            */
            flag = true;
            dgvOrderItems.DataSource = order;
            dgvOrderItems.Columns["Date"].Visible = false;
            dgvOrderItems.Columns["Invoice_id"].Visible = false;
            dgvOrderItems.Columns["Customer_name"].Visible = false;
            dgvOrderItems.Columns["Profit"].Visible = false;
        }

        void ResetTextBoxes()
        {
            tbOrderProductID.Text = String.Empty;
            /*tbOrderProductName.Text = String.Empty;
            tbOrderProductPrice.Text = String.Empty;
            tbOrderProductQuantity.Text = String.Empty;*/
            /* id = new int();
             price = new int();
             Balance
             quantity
             chagne
                 FinalPrice
                 grandTotal
             MessageBox.Show(id.ToString());
             productName = "";
             customerName = "";*/


        }

        /*        public void loaddataincategory()
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Add_customer";
                    //Fill the DataTable with records from Table.
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Walkin Customer";
                    dt.Rows.InsertAt(row, 0);
                    cbCustomername.DataSource = dt;
                    cbCustomername.DisplayMember = "Name";
                    cbCustomername.ValueMember = "Customer_id";
                    cbCustomername.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbCustomername.AutoCompleteSource = AutoCompleteSource.ListItems;
                    ///////////////////////////////


                }
        */
        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            dgvOrderItems.DataSource = order;
            this.dgvOrderItems.Columns["Product_id"].ReadOnly = true;
            this.dgvOrderItems.Columns["Product"].ReadOnly = true;
            this.dgvOrderItems.Columns["Price"].ReadOnly = true;
            this.dgvOrderItems.Columns["Total"].ReadOnly = true;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";


            this.tbOrderProductID.KeyDown += new KeyEventHandler(this.OnKeyDownHandler);
            /*    this.tbOrderProductName.KeyDown += new KeyEventHandler(this.OnKeyDownHandler);*/
            Invoice_id = InvoiceIdGenerator();
            // MessageBox.Show(Invoice_id.ToString());
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductFlow();
            }


        }

        private void AddProductFlow()
        {
            GetValuesFromDatabase();
            AddItemToDatatable();
            /*timesEnterPressed++;

            if (timesEnterPressed != 2)
            {
                GetValuesFromDatabase();
            }
            else if (timesEnterPressed == 2)
            {
                AddItemToDatatable();
                timesEnterPressed = 0;
            }*/
        }

        private void GetValuesFromDatabase()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                ///get id
                cmd.CommandText = "select Item_id from Add_item where Item_id=@id OR BarCode=@id"; //OR Name LIKE @name +'%'
                cmd.Parameters.AddWithValue("@id", tbOrderProductID.Text);
                /*  cmd.Parameters.AddWithValue("@name", tbOrderProductName.Text);*/
                int? id2 = (int?)cmd.ExecuteScalar();
                if (id2 != null)
                {
                    id = (int)id2;
                    // tbOrderProductID.Text = id.ToString();
                }
                else
                {
                    MessageBox.Show("Product does not exist!");
                    ResetTextBoxes();
                    //  timesEnterPressed = 0;

                    return;
                }

            }
            catch
            {
                MessageBox.Show("Product does not exist!");
                ResetTextBoxes();
                //timesEnterPressed = 0;
                return;
            }


            ///  NameOR Name=@name
            cmd.CommandText = "select Name from Add_item where Item_id=@id1 OR BarCode=@id";
            cmd.Parameters.AddWithValue("@id1", tbOrderProductID.Text);
            /* cmd.Parameters.AddWithValue("@name1", tbOrderProductName.Text);*/
            productName = (String)cmd.ExecuteScalar();
            /*  tbOrderProductName.Text = productName;*/

            ////// Price
            cmd.CommandText = "select Price from Add_item where Item_id=@id2 OR BarCode=@id";
            cmd.Parameters.AddWithValue("@id2", tbOrderProductID.Text);
            /* cmd.Parameters.AddWithValue("@name2", tbOrderProductName.Text);*/
            price = (int)cmd.ExecuteScalar();
            /*  tbOrderProductPrice.Text = price.ToString();*/

            ///quantity   
            cmd.CommandText = "select Quantity from Add_item where Item_id=@id3 OR BarCode=@id";
            cmd.Parameters.AddWithValue("@id3", tbOrderProductID.Text);
            /* cmd.Parameters.AddWithValue("@name3", tbOrderProductName.Text);*/
            inventory_quantity = (int)cmd.ExecuteScalar();

            if (inventory_quantity > 0)
                quantity = 1;

            ///purchase  
            ///

            cmd.CommandText = "select Purchase_price from Add_item where Item_id=@id4 OR BarCode=@id";
            cmd.Parameters.AddWithValue("@id4", tbOrderProductID.Text);
            /* cmd.Parameters.AddWithValue("@name3", tbOrderProductName.Text);*/
            purchase = (int)cmd.ExecuteScalar();

            /*  tbOrderProductQuantity.Text = quantity.ToString();*/
        }


        private void btnCORemoveProduct_Click(object sender, EventArgs e)
        {
            String name = tbOrderProductID.Text;
            foreach (DataRow row in order.Rows)
            {
                if (name == row["ID"].ToString())
                {
                    order.Rows.Remove(row);
                }
            }

            dgvOrderItems.DataSource = order;
            ResetTextBoxes();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel2.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbOrderCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel3.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);

        }

        private void lblGrandTotal_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCOAddProduct_Click_1(object sender, EventArgs e)
        {
            // timesEnterPressed = 0;
            // GetValuesFromDatabase();
            // AddItemToDatatable();
            AddProductFlow();
        }

        private void AddItemToDatatable()
        {
            try
            {
                //  timesEnterPressed = 0;
                //productName = tbOrderProductName.Text;
                /*                customerName = cbCustomername.GetItemText(cbCustomername.SelectedItem);
                /               / price = int.Parse(tbOrderProductPrice.Text);
                                quantity = int.Parse(tbOrderProductQuantity.Text);*/
                totalPrice = price * quantity;
                DateTime currentdate = dateTimePicker1.Value.Date;

                bool contains = order.AsEnumerable().Any(row => id == row.Field<Int32>("Product_id"));
                if (quantity == 0)
                {
                    MessageBox.Show("Product is out of stock!");
                    ResetTextBoxes();
                    return;
                }
                if (!contains)
                {
                    profit = (price - purchase) * quantity;
                    order.Rows.Add(id, productName, quantity, price, totalPrice, currentdate, customerName, Invoice_id,profit);
                }
                else
                {
                    MessageBox.Show("Product already exists! Please change its values using the Grid.");
                }

                //calculate total price
                CalculateTotalPrice();
                ResetTextBoxes();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void CalculateTotalPrice()
        {
            profit = (price - purchase) * quantity;
            grandTotal = 0;
            foreach (DataRow row in order.Rows)
            {
                grandTotal += int.Parse(row["Total"].ToString());
            }
            lblGrandTotal.Text = grandTotal.ToString();
            FinalPrice = (grandTotal + Balance);
            //lblFinal.Text = FinalPrice.ToString();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel4.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);

        }

        private void dgvOrderItems_Validated(object sender, EventArgs e)
        {
            // MessageBox.Show(e.ToString());
        }

        private void dgvOrderItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            int rowIndex = e.RowIndex;
            //int columnIndex = e.ColumnIndex;
            int? productQuantityAtIndex = null;
            int? productPriceAtIndex = null;


            if (dgvOrderItems.Rows[rowIndex].Cells["Price"].Value.ToString().Length != 0)
            {
                productPriceAtIndex = int.Parse(order.Rows[rowIndex]["Price"].ToString());
            }
            if (dgvOrderItems.Rows[rowIndex].Cells["Quantity"].Value.ToString().Length != 0)
            {
                productQuantityAtIndex = int.Parse(order.Rows[rowIndex]["Quantity"].ToString());
                quantity = (int)productQuantityAtIndex;
                profit = (price - purchase) * quantity;

            }
            if (productPriceAtIndex != null && productQuantityAtIndex != null)
            {
                totalPrice = (int)(productPriceAtIndex * productQuantityAtIndex);
            }
            else
            {
                MessageBox.Show("Please Enter valid values in cells");
                return;
            }
            if (productQuantityAtIndex > inventory_quantity)
            {
                dgvOrderItems.Rows[rowIndex].Cells["Quantity"].Value = quantity;
                MessageBox.Show("Entered Quantity is greater than product in stock!\nCurrent Stock: " + inventory_quantity);
                return;
            }
            //update datatable with new values from grid view
            order.Rows[rowIndex]["Total"] = totalPrice;
            order.Rows[rowIndex]["Price"] = productPriceAtIndex;
            order.Rows[rowIndex]["Quantity"] = productQuantityAtIndex;
            order.Rows[rowIndex]["Profit"] = profit;

            CalculateTotalPrice();

            // MessageBox.Show(order.Rows[rowIndex]["Product"].ToString() + order.Rows[rowIndex]["Quantity"].ToString() + order.Rows[rowIndex]["Total"].ToString());
            // String value = dgvOrderItems.Rows[rowIndex].Cells["Quantity"].Value.ToString();
            // MessageBox.Show(value);
            // MessageBox.Show(productPriceAtIndex.ToString() + rowIndex.ToString());
        }

        private void cbCustomername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*        private void cbCustomername_SelectedValueChanged(object sender, EventArgs e)
                {

                    if (flag && cbCustomername.GetItemText(cbCustomername.SelectedItem) != "Walkin Customer")
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "select Balance from Add_customer where Name=@name";
                        cmd.Parameters.AddWithValue("@name", cbCustomername.GetItemText(cbCustomername.SelectedItem));
                        Balance = (int)cmd.ExecuteScalar();
                        lblBalance.Text = Balance.ToString();
                        CalculateTotalPrice();
                        // label10.Text = (grandTotal + Balance).ToString();

                    }
                    else if (cbCustomername.GetItemText(cbCustomername.SelectedItem) == "Walkin Customer")
                    {
                        Balance = 0;
                        lblBalance.Text = Balance.ToString();
                        CalculateTotalPrice();
                    }

                    for (int i = 0; i < order.Rows.Count; i++)
                    {
                        order.Rows[i]["Customer_name"] = cbCustomername.GetItemText(cbCustomername.SelectedItem);
                    }

                }
        */
        public void MoveOrdersToSaleTable()
        {
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Sales_report";

            objbulk.ColumnMappings.Add("Date", "Date");
            objbulk.ColumnMappings.Add("Product", "Product");
            objbulk.ColumnMappings.Add("Quantity", "Quantity");
            objbulk.ColumnMappings.Add("Total", "Total");
            objbulk.ColumnMappings.Add("Price", "Price");
            objbulk.ColumnMappings.Add("Customer_name", "Customer_name");
            objbulk.ColumnMappings.Add("Invoice_id", "Invoice_id");
            objbulk.ColumnMappings.Add("Product_id", "Product_id");
            objbulk.ColumnMappings.Add("Profit", "Profit");
            objbulk.WriteToServer(order);

           // MessageBox.Show("moved");

        }
        public int InvoiceIdGenerator()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Invoice_id from Invoice_id";
            int Invoice_id = (int)cmd.ExecuteScalar();
            Invoice_id++;
            cmd.CommandText = "update Invoice_id set Invoice_id = @invoiceid where id = @id ";
            cmd.Parameters.AddWithValue("@invoiceid", Invoice_id);
            cmd.Parameters.AddWithValue("@id", 1);
            cmd.ExecuteNonQuery();
            return Invoice_id;
        }
        public void InvoiceIdInverter()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            Invoice_id--;
            cmd.CommandText = "update Invoice_id set Invoice_id = @invoiceid where id = @id ";
            cmd.Parameters.AddWithValue("@invoiceid", Invoice_id);
            cmd.Parameters.AddWithValue("@id", 1);
            cmd.ExecuteNonQuery();

        }

        private void tbPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //TODO
                chagne = -Convert.ToInt32(FinalPrice) + Convert.ToInt32(tbPaidAmount.Text);
                lblChange.Text = (chagne).ToString();

            }
            catch
            {
                lblChange.Text = "0";
            }

        }

        private void btnCOCancel_Click_1(object sender, EventArgs e)
        {
            ResetTextBoxes();
            // timesEnterPressed = 0;
        }

        private void btnCORemoveProduct_Click_1(object sender, EventArgs e)
        {

            for (int i = order.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = order.Rows[i];
                if (dr["ID"].ToString() == tbOrderProductID.Text)
                    dr.Delete();
            }
            order.AcceptChanges();
            ResetTextBoxes();
        }

        private void CreateOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (invoiceFlag == false)
            {
                InvoiceIdInverter();
            }
        }

        private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrderItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvOrderItems.CurrentRow.Cells[0].Value.ToString());
                productName = dgvOrderItems.CurrentRow.Cells[1].Value.ToString();
                price = Convert.ToInt32(dgvOrderItems.CurrentRow.Cells[3].Value.ToString());
                quantity = Convert.ToInt32(dgvOrderItems.CurrentRow.Cells[2].Value.ToString());
                tbOrderProductID.Text = id.ToString();
                /* tbOrderProductName.Text = productName;
                 tbOrderProductPrice.Text = price.ToString();
                 tbOrderProductQuantity.Text = quantity.ToString();*/

            }
            catch
            {

            }
        }

        private void ReductProductQuantity(int id, int quantity, int size)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "update Add_item set Quantity = Quantity - @a where Item_id = @b";
            cmd.Parameters.AddWithValue("@a", quantity);
            cmd.Parameters.AddWithValue("@b", id);
            cmd.ExecuteNonQuery();

        }

        /*        private void ChangeBalanceFromServer()
                {
                    int newbalance = -Convert.ToInt32(tbPaidAmount.Text) + FinalPrice;
                    if (newbalance < 0)
                    {
                        newbalance = 0;
                    }
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = "update Add_customer set Balance=@b where Name=@c";
                    cmd1.Parameters.AddWithValue("@b", newbalance);
                    cmd1.Parameters.AddWithValue("@c", customerName);
                    cmd1.ExecuteNonQuery();
                }
        */
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (order.Rows.Count == 0)
            {
                MessageBox.Show("Please Select Alteast One Item", "Empty Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tbPaidAmount.Text.Length != 0)
            {
                if (int.Parse(tbPaidAmount.Text) < FinalPrice)
                {
                    DialogResult dialogResult = MessageBox.Show("Entered Amount is less than total bill!\nDo you want to add to Balance", "Payment Warning!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        startCheckoutFlow();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (int.Parse(tbPaidAmount.Text) >= FinalPrice)
                {
                    startCheckoutFlow();
                }

            }
            else
            {
                MessageBox.Show("Please Enter Amount to Continue");
                return;
            }

        }

        void startCheckoutFlow()
        {
            int paymentAmount;
            
                paymentAmount = int.Parse(tbPaidAmount.Text);
                // ChangeBalanceFromServer();

          Paid = int.Parse(tbPaidAmount.Text);
               // Balance = -Convert.ToInt32(tbPaidAmount.Text) + FinalPrice;
                invoiceFlag = true;

            var thread = new Thread(()=> {

                //  MessageBox.Show("inside thread");
                int[] ids = new int[order.Rows.Count];
                int[] quantity = new int[order.Rows.Count];

                for (int i = 0; i < order.Rows.Count; i++)
                {
                    ids[i] = int.Parse(order.Rows[i]["Product_id"].ToString());
                    quantity[i] = int.Parse(order.Rows[i]["Quantity"].ToString());
                    ReductProductQuantity(ids[i], quantity[i], order.Rows.Count);

                }

                MoveOrdersToSaleTable();

            });
            //MessageBox.Show("out side thread");
            thread.IsBackground = true;
            thread.Start();
            //MessageBox.Show("started");

            ResetTextBoxes();
                dgvOrderItems.DataSource = null;


                InvoiceViewer a = new InvoiceViewer();
                a.Show();

                CreateOrderForm NewForm = new CreateOrderForm();
                NewForm.Show();

                a.BringToFront();

                this.Dispose(false);
            }
            
        }
    }
