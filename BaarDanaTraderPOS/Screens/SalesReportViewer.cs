using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaarDanaTraderPOS.Screens
{
    public partial class SalesReportViewer : Form
    {
        String Shop_name, Phno, footer;
        SqlConnection con = new SqlConnection();
        public SalesReportViewer()
        {
            InitializeComponent();
        }

        private void SalesReportViewer_Load(object sender, EventArgs e)
        {
            SettingsLoader();
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            this.reportViewer1.RefreshReport();
            reportParameters.Add(new ReportParameter("ShopName", Shop_name));
            reportParameters.Add(new ReportParameter("Footer", footer));
            reportParameters.Add(new ReportParameter("Phno", Phno));
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
    }
}
