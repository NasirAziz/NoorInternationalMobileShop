namespace BaarDanaTraderPOS.Screens

{

    partial class CheckExpiry

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

            this.components = new System.ComponentModel.Container();

            this.Expirygridview = new System.Windows.Forms.DataGridView();

            this.btnSearch = new System.Windows.Forms.Button();

            this.btnShowall = new System.Windows.Forms.Button();

            this.label1 = new System.Windows.Forms.Label();

            this.from = new System.Windows.Forms.DateTimePicker();

            this.to = new System.Windows.Forms.DateTimePicker();

            this.panel1 = new System.Windows.Forms.Panel();

            this.label3 = new System.Windows.Forms.Label();

            this.label2 = new System.Windows.Forms.Label();

            this.alert = new System.Windows.Forms.NotifyIcon(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.Expirygridview)).BeginInit();

            this.panel1.SuspendLayout();

            this.SuspendLayout();

            // 

            // Expirygridview

            // 

            this.Expirygridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.Expirygridview.Location = new System.Drawing.Point(12, 117);

            this.Expirygridview.Name = "Expirygridview";

            this.Expirygridview.Size = new System.Drawing.Size(813, 388);

            this.Expirygridview.TabIndex = 0;

            // 

            // btnSearch

            // 

            this.btnSearch.Location = new System.Drawing.Point(554, 14);

            this.btnSearch.Name = "btnSearch";

            this.btnSearch.Size = new System.Drawing.Size(117, 23);

            this.btnSearch.TabIndex = 2;

            this.btnSearch.Text = "Search";

            this.btnSearch.UseVisualStyleBackColor = true;

            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 

            // btnShowall

            // 

            this.btnShowall.Location = new System.Drawing.Point(687, 14);

            this.btnShowall.Name = "btnShowall";

            this.btnShowall.Size = new System.Drawing.Size(117, 23);

            this.btnShowall.TabIndex = 3;

            this.btnShowall.Text = "Show All";

            this.btnShowall.UseVisualStyleBackColor = true;

            // 

            // label1

            // 

            this.label1.AutoSize = true;

            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.label1.Location = new System.Drawing.Point(277, 19);

            this.label1.Name = "label1";

            this.label1.Size = new System.Drawing.Size(248, 25);

            this.label1.TabIndex = 4;

            this.label1.Text = "Check Expired Inventory";

            // 

            // from

            // 

            this.from.Location = new System.Drawing.Point(60, 17);

            this.from.Name = "from";

            this.from.Size = new System.Drawing.Size(200, 20);

            this.from.TabIndex = 5;

            // 

            // to

            // 

            this.to.Location = new System.Drawing.Point(313, 17);

            this.to.Name = "to";

            this.to.Size = new System.Drawing.Size(200, 20);

            this.to.TabIndex = 6;

            // 

            // panel1

            // 

            this.panel1.Controls.Add(this.label3);

            this.panel1.Controls.Add(this.label2);

            this.panel1.Controls.Add(this.to);

            this.panel1.Controls.Add(this.btnSearch);

            this.panel1.Controls.Add(this.from);

            this.panel1.Controls.Add(this.btnShowall);

            this.panel1.Location = new System.Drawing.Point(12, 47);

            this.panel1.Name = "panel1";

            this.panel1.Size = new System.Drawing.Size(813, 56);

            this.panel1.TabIndex = 7;

            // 

            // label3

            // 

            this.label3.AutoSize = true;

            this.label3.Location = new System.Drawing.Point(277, 19);

            this.label3.Name = "label3";

            this.label3.Size = new System.Drawing.Size(20, 13);

            this.label3.TabIndex = 8;

            this.label3.Text = "To";

            // 

            // label2

            // 

            this.label2.AutoSize = true;

            this.label2.Location = new System.Drawing.Point(15, 19);

            this.label2.Name = "label2";

            this.label2.Size = new System.Drawing.Size(30, 13);

            this.label2.TabIndex = 7;

            this.label2.Text = "From";

            // 

            // alert

            // 

            this.alert.Text = "notifyIcon1";

            this.alert.Visible = true;

            this.alert.Click += new System.EventHandler(this.alert_Click);

            // 

            // CheckExpiry

            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(828, 517);

            this.Controls.Add(this.panel1);

            this.Controls.Add(this.label1);

            this.Controls.Add(this.Expirygridview);

            this.Name = "CheckExpiry";

            this.Text = "CheckExpiry";

            this.Load += new System.EventHandler(this.CheckExpiry_Load);

            ((System.ComponentModel.ISupportInitialize)(this.Expirygridview)).EndInit();

            this.panel1.ResumeLayout(false);

            this.panel1.PerformLayout();

            this.ResumeLayout(false);

            this.PerformLayout();



        }



        #endregion



        private System.Windows.Forms.DataGridView Expirygridview;

        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Button btnShowall;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DateTimePicker from;

        private System.Windows.Forms.DateTimePicker to;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.NotifyIcon alert;

    }

}