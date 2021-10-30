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
        public ViewHistoryReport()
        {
            InitializeComponent();
        }

        private void ViewHistoryReport_Load(object sender, EventArgs e)
        {

            
            this.reportViewer1.RefreshReport();
            con.ConnectionString = Connection.c;
            con.Open();
            load();
        }
        private void load()
        {
            ReportDataSource datasource = new ReportDataSource("DataSet1", ViewHistoryForm.viewhistory);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);

            this.reportViewer1.RefreshReport();

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Total", ViewHistoryForm.total.ToString()));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
