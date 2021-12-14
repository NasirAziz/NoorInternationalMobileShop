
namespace BaarDanaTraderPOS.Screens
{
    partial class LedgerReport
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
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addRecovery = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbcustomername = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.showitem = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showitem)).BeginInit();
            this.SuspendLayout();
            // 
            // fromdate
            // 
            this.fromdate.Location = new System.Drawing.Point(93, 23);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(200, 20);
            this.fromdate.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Print);
            this.panel1.Controls.Add(this.addRecovery);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbcustomername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.todate);
            this.panel1.Controls.Add(this.fromdate);
            this.panel1.Location = new System.Drawing.Point(31, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 93);
            this.panel1.TabIndex = 1;
            // 
            // addRecovery
            // 
            this.addRecovery.Location = new System.Drawing.Point(34, 57);
            this.addRecovery.Name = "addRecovery";
            this.addRecovery.Size = new System.Drawing.Size(122, 23);
            this.addRecovery.TabIndex = 7;
            this.addRecovery.Text = "Add Recovery";
            this.addRecovery.UseVisualStyleBackColor = true;
            this.addRecovery.Click += new System.EventHandler(this.addRecovery_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(725, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Customer Name";
            // 
            // cbcustomername
            // 
            this.cbcustomername.FormattingEnabled = true;
            this.cbcustomername.Location = new System.Drawing.Point(640, 21);
            this.cbcustomername.Name = "cbcustomername";
            this.cbcustomername.Size = new System.Drawing.Size(185, 21);
            this.cbcustomername.TabIndex = 4;
            this.cbcustomername.SelectedIndexChanged += new System.EventHandler(this.cbcustomername_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // todate
            // 
            this.todate.Location = new System.Drawing.Point(339, 23);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(200, 20);
            this.todate.TabIndex = 1;
            // 
            // showitem
            // 
            this.showitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showitem.Location = new System.Drawing.Point(31, 144);
            this.showitem.Name = "showitem";
            this.showitem.Size = new System.Drawing.Size(841, 384);
            this.showitem.TabIndex = 2;
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(187, 57);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(122, 23);
            this.Print.TabIndex = 8;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // LedgerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 568);
            this.Controls.Add(this.showitem);
            this.Controls.Add(this.panel1);
            this.Name = "LedgerReport";
            this.Text = "LedgerReport";
            this.Load += new System.EventHandler(this.LedgerReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showitem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbcustomername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.DataGridView showitem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button addRecovery;
        private System.Windows.Forms.Button Print;
    }
}