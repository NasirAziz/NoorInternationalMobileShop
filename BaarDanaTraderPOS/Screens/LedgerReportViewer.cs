using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaarDanaTraderPOS.Screens
{
    public partial class LedgerReportViewer : Form
    {
        public LedgerReportViewer()
        {
            InitializeComponent();
        }

        private void LedgerReportViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            load();
        }
        private void load()
        {
            ReportDataSource datasource = new ReportDataSource("DataSet3", LedgerReport.dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);

            this.reportViewer1.RefreshReport();

            
            this.reportViewer1.RefreshReport();
        }
    }
}
