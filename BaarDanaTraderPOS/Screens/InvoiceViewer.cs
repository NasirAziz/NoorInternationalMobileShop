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
using Microsoft.Reporting.WinForms;
using System.Threading;

namespace BaarDanaTraderPOS.Screens
{
    public partial class InvoiceViewer : Form
    {
        SqlConnection con = new SqlConnection();
        String Shop_name, Phno, footer;
        public InvoiceViewer()
        {
            InitializeComponent();
        }
        public void SettingsLoader()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Shop_name from Settings";
            Shop_name = (String)cmd.ExecuteScalar();
            cmd.CommandText = "select Phone_number from Settings";
            Phno = (String)cmd.ExecuteScalar();
            cmd.CommandText = "select Footer from Settings";
            footer = (String)cmd.ExecuteScalar();
        }
        private void InvoiceViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            con.ConnectionString = Connection.c;
            con.Open();
/*            var thread = new Thread(() => {
                SettingsLoader();
               
            });
            thread.IsBackground = true;
            thread.Start();*/
            SettingsLoader();
            load();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //load();
        }
        public void load()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Sales_report where Invoice_id=@a";
            cmd.Parameters.AddWithValue("@a",CreateOrderForm.Invoice_id);
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataTable a = new DataTable();

            adapter.Fill(a);

            ReportDataSource datasource = new ReportDataSource("DataSet1", a);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            
            this.reportViewer1.RefreshReport();

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Total", CreateOrderForm.FinalPrice.ToString()));
            reportParameters.Add(new ReportParameter("Paid", CreateOrderForm.Paid.ToString()));
            reportParameters.Add(new ReportParameter("Balance", CreateOrderForm.Balance.ToString()));
            reportParameters.Add(new ReportParameter("ShopName", Shop_name));
            reportParameters.Add(new ReportParameter("Footer", footer));
            reportParameters.Add(new ReportParameter("Phno", Phno));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();


        }
    }
}
