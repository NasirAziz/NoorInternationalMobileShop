
namespace BaarDanaTraderPOS.Screens
{
    partial class AddCustomerForm
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
            this.btnCustomerAdd = new System.Windows.Forms.Button();
            this.btnCustomerCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.tbCustomerPhone = new System.Windows.Forms.TextBox();
            this.tbCustomerAddress = new System.Windows.Forms.TextBox();
            this.dgvAddCustomers = new System.Windows.Forms.DataGridView();
            this.btnCustomerUpdate = new System.Windows.Forms.Button();
            this.btnCustomerDelete = new System.Windows.Forms.Button();
            this.btnACSearch = new System.Windows.Forms.Button();
            this.tbACSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCustomerBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCustomerAdd
            // 
            this.btnCustomerAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCustomerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCustomerAdd.ForeColor = System.Drawing.Color.White;
            this.btnCustomerAdd.Location = new System.Drawing.Point(190, 304);
            this.btnCustomerAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerAdd.Name = "btnCustomerAdd";
            this.btnCustomerAdd.Size = new System.Drawing.Size(73, 45);
            this.btnCustomerAdd.TabIndex = 0;
            this.btnCustomerAdd.Text = "Add";
            this.btnCustomerAdd.UseVisualStyleBackColor = false;
            this.btnCustomerAdd.Click += new System.EventHandler(this.btnCustomerAdd_Click);
            // 
            // btnCustomerCancel
            // 
            this.btnCustomerCancel.BackColor = System.Drawing.Color.White;
            this.btnCustomerCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCustomerCancel.Location = new System.Drawing.Point(35, 304);
            this.btnCustomerCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerCancel.Name = "btnCustomerCancel";
            this.btnCustomerCancel.Size = new System.Drawing.Size(73, 45);
            this.btnCustomerCancel.TabIndex = 1;
            this.btnCustomerCancel.Text = "Close";
            this.btnCustomerCancel.UseVisualStyleBackColor = false;
            this.btnCustomerCancel.Click += new System.EventHandler(this.btnCustomerCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name: *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phone No. *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 214);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address:";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerName.Location = new System.Drawing.Point(163, 110);
            this.tbCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(179, 23);
            this.tbCustomerName.TabIndex = 7;
            // 
            // tbCustomerPhone
            // 
            this.tbCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerPhone.Location = new System.Drawing.Point(163, 161);
            this.tbCustomerPhone.Margin = new System.Windows.Forms.Padding(2);
            this.tbCustomerPhone.Name = "tbCustomerPhone";
            this.tbCustomerPhone.Size = new System.Drawing.Size(179, 23);
            this.tbCustomerPhone.TabIndex = 8;
            // 
            // tbCustomerAddress
            // 
            this.tbCustomerAddress.AcceptsTab = true;
            this.tbCustomerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerAddress.Location = new System.Drawing.Point(163, 211);
            this.tbCustomerAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tbCustomerAddress.Name = "tbCustomerAddress";
            this.tbCustomerAddress.Size = new System.Drawing.Size(179, 23);
            this.tbCustomerAddress.TabIndex = 9;
            // 
            // dgvAddCustomers
            // 
            this.dgvAddCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAddCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAddCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvAddCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddCustomers.Location = new System.Drawing.Point(367, 94);
            this.dgvAddCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAddCustomers.Name = "dgvAddCustomers";
            this.dgvAddCustomers.ReadOnly = true;
            this.dgvAddCustomers.RowHeadersWidth = 62;
            this.dgvAddCustomers.RowTemplate.Height = 28;
            this.dgvAddCustomers.Size = new System.Drawing.Size(479, 326);
            this.dgvAddCustomers.TabIndex = 10;
            this.dgvAddCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddCustomers_CellDoubleClick);
            // 
            // btnCustomerUpdate
            // 
            this.btnCustomerUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCustomerUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCustomerUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnCustomerUpdate.Location = new System.Drawing.Point(113, 304);
            this.btnCustomerUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerUpdate.Name = "btnCustomerUpdate";
            this.btnCustomerUpdate.Size = new System.Drawing.Size(73, 45);
            this.btnCustomerUpdate.TabIndex = 11;
            this.btnCustomerUpdate.Text = "Update";
            this.btnCustomerUpdate.UseVisualStyleBackColor = false;
            this.btnCustomerUpdate.Click += new System.EventHandler(this.btnCustomerUpdate_Click);
            // 
            // btnCustomerDelete
            // 
            this.btnCustomerDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCustomerDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCustomerDelete.ForeColor = System.Drawing.Color.White;
            this.btnCustomerDelete.Location = new System.Drawing.Point(268, 304);
            this.btnCustomerDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerDelete.Name = "btnCustomerDelete";
            this.btnCustomerDelete.Size = new System.Drawing.Size(73, 45);
            this.btnCustomerDelete.TabIndex = 12;
            this.btnCustomerDelete.Text = "Delete";
            this.btnCustomerDelete.UseVisualStyleBackColor = false;
            this.btnCustomerDelete.Click += new System.EventHandler(this.btnCustomerDelete_Click);
            // 
            // btnACSearch
            // 
            this.btnACSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnACSearch.Location = new System.Drawing.Point(722, 59);
            this.btnACSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnACSearch.Name = "btnACSearch";
            this.btnACSearch.Size = new System.Drawing.Size(60, 23);
            this.btnACSearch.TabIndex = 13;
            this.btnACSearch.Text = "Search";
            this.btnACSearch.UseVisualStyleBackColor = true;
            this.btnACSearch.Click += new System.EventHandler(this.btnACSearch_Click);
            // 
            // tbACSearch
            // 
            this.tbACSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbACSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbACSearch.Location = new System.Drawing.Point(477, 59);
            this.tbACSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbACSearch.Name = "tbACSearch";
            this.tbACSearch.Size = new System.Drawing.Size(232, 23);
            this.tbACSearch.TabIndex = 15;
            this.tbACSearch.TextChanged += new System.EventHandler(this.tbACSearch_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(363, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Search by Name:";
            // 
            // tbCustomerBalance
            // 
            this.tbCustomerBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerBalance.Location = new System.Drawing.Point(163, 252);
            this.tbCustomerBalance.Margin = new System.Windows.Forms.Padding(2);
            this.tbCustomerBalance.Name = "tbCustomerBalance";
            this.tbCustomerBalance.Size = new System.Drawing.Size(179, 23);
            this.tbCustomerBalance.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Current Balance: *";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAll.Location = new System.Drawing.Point(786, 59);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(60, 23);
            this.btnShowAll.TabIndex = 20;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 448);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.tbCustomerBalance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbACSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnACSearch);
            this.Controls.Add(this.btnCustomerDelete);
            this.Controls.Add(this.btnCustomerUpdate);
            this.Controls.Add(this.dgvAddCustomers);
            this.Controls.Add(this.tbCustomerAddress);
            this.Controls.Add(this.tbCustomerPhone);
            this.Controls.Add(this.tbCustomerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCustomerCancel);
            this.Controls.Add(this.btnCustomerAdd);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddCustomerForm";
            this.Text = "AddCustomerForm";
            this.Load += new System.EventHandler(this.AddCustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCustomerAdd;
        private System.Windows.Forms.Button btnCustomerCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.TextBox tbCustomerPhone;
        private System.Windows.Forms.TextBox tbCustomerAddress;
        private System.Windows.Forms.DataGridView dgvAddCustomers;
        private System.Windows.Forms.Button btnCustomerUpdate;
        private System.Windows.Forms.Button btnCustomerDelete;
        private System.Windows.Forms.Button btnACSearch;
        private System.Windows.Forms.TextBox tbACSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCustomerBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShowAll;
    }
}