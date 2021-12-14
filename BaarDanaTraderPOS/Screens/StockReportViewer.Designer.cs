
namespace BaarDanaTraderPOS.Screens
{
    partial class StockReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet2 = new BaarDanaTraderPOS.DataSet2();
            this.additemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.add_itemTableAdapter = new BaarDanaTraderPOS.DataSet2TableAdapters.Add_itemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.additemBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "BaarDanaTraderPOS.Screens.Stocklist.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(0, 0);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.ServerReport.BearerToken = null;
            this.reportViewer5.Size = new System.Drawing.Size(800, 450);
            this.reportViewer5.TabIndex = 0;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // additemBindingSource
            // 
            this.additemBindingSource.DataMember = "Add_item";
            this.additemBindingSource.DataSource = this.dataSet2;
            // 
            // add_itemTableAdapter
            // 
            this.add_itemTableAdapter.ClearBeforeFill = true;
            // 
            // StockReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer5);
            this.Name = "StockReportViewer";
            this.Text = "StockReportViewer";
            this.Load += new System.EventHandler(this.StockReportViewer_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource additemBindingSource;
        private DataSet2TableAdapters.Add_itemTableAdapter add_itemTableAdapter;
    }
}