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

namespace BaarDanaTraderPOS.Screens
{
    public partial class ViewHistoryReport : Form
    {
        SqlConnection con = new SqlConnection();
        String Shop_name, Phno, footer;

        public ViewHistoryReport()
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

        private void ViewHistoryReport_Load(object sender, EventArgs e)
        {

/*            
            this.reportViewer1.RefreshReport();
            con.ConnectionString = Connection.c;
            con.Open();
            SettingsLoader();
            load();*/
        }
        private void load()
        {
            ReportDataSource datasource = new ReportDataSource("DataSet1", ViewHistoryForm.viewhistory);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);

            this.reportViewer1.RefreshReport();

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Total", ViewHistoryForm.total.ToString()));
            reportParameters.Add(new ReportParameter("ShopName", Shop_name));
            reportParameters.Add(new ReportParameter("Footer", footer));
            reportParameters.Add(new ReportParameter("Phno", Phno));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            con.ConnectionString = Connection.c;
           
            con.Open();
            SettingsLoader();
            load();
        }
    }
}
