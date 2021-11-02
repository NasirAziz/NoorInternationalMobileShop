
namespace BaarDanaTraderPOS.Screens
{
    partial class AddItemFinishForm
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
            this.tbPayment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPaynow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPayment
            // 
            this.tbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPayment.Location = new System.Drawing.Point(292, 174);
            this.tbPayment.Name = "tbPayment";
            this.tbPayment.Size = new System.Drawing.Size(208, 30);
            this.tbPayment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TotaL Bill:";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.Location = new System.Drawing.Point(287, 90);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(56, 25);
            this.lblTotalBill.TabIndex = 2;
            this.lblTotalBill.Text = "0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Payment:";
            // 
            // btnPaynow
            // 
            this.btnPaynow.BackColor = System.Drawing.Color.Lime;
            this.btnPaynow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaynow.Location = new System.Drawing.Point(377, 260);
            this.btnPaynow.Name = "btnPaynow";
            this.btnPaynow.Size = new System.Drawing.Size(123, 54);
            this.btnPaynow.TabIndex = 4;
            this.btnPaynow.Text = "Pay Now";
            this.btnPaynow.UseVisualStyleBackColor = false;
            this.btnPaynow.Click += new System.EventHandler(this.btnPaynow_Click);
            // 
            // AddItemFinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 455);
            this.Controls.Add(this.btnPaynow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPayment);
            this.Name = "AddItemFinishForm";
            this.Text = "AddItemFinishForm";
            this.Load += new System.EventHandler(this.AddItemFinishForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPaynow;
    }
}