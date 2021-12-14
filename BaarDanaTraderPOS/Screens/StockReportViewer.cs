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
    public partial class StockReportViewer : Form
    {
        SqlConnection con = new SqlConnection();
        public StockReportViewer()
        {
            InitializeComponent();
        }

        private void StockReportViewer_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();

            this.reportViewer5.RefreshReport();
            DataLoad();
            // TODO: This line of code loads data into the 'dataSet2.Add_item' table. You can move, or remove it, as needed.
           // this.add_itemTableAdapter.Fill(this.dataSet2.Add_item);

        }
        private void DataLoad()
        {
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Add_item";
           
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable a = new DataTable();

            adapter.Fill(a);

            ReportDataSource datasource = new ReportDataSource("DataSet2", a);
            this.reportViewer5.LocalReport.DataSources.Clear();
            this.reportViewer5.LocalReport.DataSources.Add(datasource);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Date", now.ToString("dddd, dd MMMM yyyy")));

            this.reportViewer5.LocalReport.SetParameters(reportParameters);
            this.reportViewer5.RefreshReport();
            this.reportViewer5.RefreshReport();
            


        }

        private void StockReportViewer_Load_1(object sender, EventArgs e)
        {
           
            this.reportViewer5.RefreshReport();
            con.ConnectionString = Connection.c;
            con.Open();

            
            DataLoad();
            // TODO: This line of code loads data into the 'dataSet2.Add_item' table. You can move, or remove it, as needed.
          //  this.add_itemTableAdapter.Fill(this.dataSet2.Add_item);


        }
    }
}
