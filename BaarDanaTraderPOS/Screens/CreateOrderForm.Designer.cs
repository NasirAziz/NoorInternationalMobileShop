
namespace BaarDanaTraderPOS.Screens
{
    partial class CreateOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCOConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCORemoveProduct = new System.Windows.Forms.Button();
            this.btnCOAddProduct = new System.Windows.Forms.Button();
            this.btnCOCancel = new System.Windows.Forms.Button();
            this.tbOrderProductID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.tbPaidAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblChange = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(23, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Current Date:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOrderItems.Location = new System.Drawing.Point(413, 110);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.RowTemplate.Height = 28;
            this.dgvOrderItems.Size = new System.Drawing.Size(796, 247);
            this.dgvOrderItems.TabIndex = 6;
            this.dgvOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellContentClick);
            this.dgvOrderItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellDoubleClick);
            this.dgvOrderItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellValueChanged);
            this.dgvOrderItems.Validated += new System.EventHandler(this.dgvOrderItems_Validated);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 34);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(386, 26);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnCOConfirm
            // 
            this.btnCOConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCOConfirm.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCOConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCOConfirm.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOConfirm.ForeColor = System.Drawing.Color.White;
            this.btnCOConfirm.Location = new System.Drawing.Point(3524, 374);
            this.btnCOConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCOConfirm.Name = "btnCOConfirm";
            this.btnCOConfirm.Size = new System.Drawing.Size(124, 78);
            this.btnCOConfirm.TabIndex = 16;
            this.btnCOConfirm.Text = "Confirm and\r\nGenerate Reciept";
            this.btnCOConfirm.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "Total (Rs):";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.Red;
            this.lblGrandTotal.Location = new System.Drawing.Point(171, 15);
            this.lblGrandTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(20, 24);
            this.lblGrandTotal.TabIndex = 18;
            this.lblGrandTotal.Text = "0";
            this.lblGrandTotal.Click += new System.EventHandler(this.lblGrandTotal_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(71, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 31);
            this.label8.TabIndex = 19;
            this.label8.Text = "Create Order";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(25, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 78);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCORemoveProduct);
            this.panel2.Controls.Add(this.btnCOAddProduct);
            this.panel2.Controls.Add(this.btnCOCancel);
            this.panel2.Controls.Add(this.tbOrderProductID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(25, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 247);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnCORemoveProduct
            // 
            this.btnCORemoveProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCORemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCORemoveProduct.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCORemoveProduct.ForeColor = System.Drawing.Color.White;
            this.btnCORemoveProduct.Location = new System.Drawing.Point(113, 120);
            this.btnCORemoveProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCORemoveProduct.Name = "btnCORemoveProduct";
            this.btnCORemoveProduct.Size = new System.Drawing.Size(80, 52);
            this.btnCORemoveProduct.TabIndex = 26;
            this.btnCORemoveProduct.Text = "Remove Product";
            this.btnCORemoveProduct.UseVisualStyleBackColor = false;
            this.btnCORemoveProduct.Click += new System.EventHandler(this.btnCORemoveProduct_Click_1);
            // 
            // btnCOAddProduct
            // 
            this.btnCOAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCOAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCOAddProduct.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnCOAddProduct.Location = new System.Drawing.Point(211, 120);
            this.btnCOAddProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCOAddProduct.Name = "btnCOAddProduct";
            this.btnCOAddProduct.Size = new System.Drawing.Size(80, 52);
            this.btnCOAddProduct.TabIndex = 5;
            this.btnCOAddProduct.Text = "Add Product";
            this.btnCOAddProduct.UseVisualStyleBackColor = false;
            this.btnCOAddProduct.Click += new System.EventHandler(this.btnCOAddProduct_Click_1);
            // 
            // btnCOCancel
            // 
            this.btnCOCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCOCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCOCancel.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOCancel.Location = new System.Drawing.Point(13, 120);
            this.btnCOCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCOCancel.Name = "btnCOCancel";
            this.btnCOCancel.Size = new System.Drawing.Size(80, 52);
            this.btnCOCancel.TabIndex = 24;
            this.btnCOCancel.Text = "Cancel";
            this.btnCOCancel.UseVisualStyleBackColor = false;
            this.btnCOCancel.Click += new System.EventHandler(this.btnCOCancel_Click_1);
            // 
            // tbOrderProductID
            // 
            this.tbOrderProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderProductID.Location = new System.Drawing.Point(154, 21);
            this.tbOrderProductID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbOrderProductID.MaxLength = 0;
            this.tbOrderProductID.Name = "tbOrderProductID";
            this.tbOrderProductID.Size = new System.Drawing.Size(140, 22);
            this.tbOrderProductID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Product ID:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Location = new System.Drawing.Point(413, 20);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 73);
            this.panel3.TabIndex = 21;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Confirm.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Confirm.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirm.ForeColor = System.Drawing.Color.White;
            this.btn_Confirm.Location = new System.Drawing.Point(895, 439);
            this.btn_Confirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(289, 38);
            this.btn_Confirm.TabIndex = 27;
            this.btn_Confirm.Text = "Generate Slip";
            this.btn_Confirm.UseVisualStyleBackColor = false;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // tbPaidAmount
            // 
            this.tbPaidAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPaidAmount.Location = new System.Drawing.Point(1019, 385);
            this.tbPaidAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPaidAmount.MaxLength = 0;
            this.tbPaidAmount.Name = "tbPaidAmount";
            this.tbPaidAmount.Size = new System.Drawing.Size(166, 29);
            this.tbPaidAmount.TabIndex = 29;
            this.tbPaidAmount.TextChanged += new System.EventHandler(this.tbPaidAmount_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(891, 391);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 24);
            this.label9.TabIndex = 28;
            this.label9.Text = "Paid Amount:";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.lblChange);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lblGrandTotal);
            this.panel4.Location = new System.Drawing.Point(590, 376);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 109);
            this.panel4.TabIndex = 30;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.Red;
            this.lblChange.Location = new System.Drawing.Point(171, 64);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(20, 24);
            this.lblChange.TabIndex = 35;
            this.lblChange.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 64);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 24);
            this.label14.TabIndex = 34;
            this.label14.Text = "Change:";
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1212, 487);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCOConfirm);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPaidAmount);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(913, 442);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateOrderForm_FormClosing);
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCOConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCORemoveProduct;
        private System.Windows.Forms.Button btnCOAddProduct;
        private System.Windows.Forms.Button btnCOCancel;
        private System.Windows.Forms.TextBox tbOrderProductID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.TextBox tbPaidAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label14;
    }
}