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
using System.IO;

namespace BaarDanaTraderPOS.Screens
{
    public partial class CheckExpiry : Form
    {
        SqlConnection con = new SqlConnection();
        public int count = 0;



        public CheckExpiry()
        {
            InitializeComponent();
        }

        private void CheckExpiry_Load(object sender, EventArgs e)
        {
            con.ConnectionString = Connection.c;
            con.Open();
            LoadITemExpiedInNextTwoWeeks();
            Displaynotify();
        }
        private void LoadITemExpiedInNextTwoWeeks()
        {

            var sb = new System.Text.StringBuilder();
            DataTable dt = new DataTable();
            DateTime dt1 = DateTime.Now;
            DateTime todaydate = dt1.Date;
            todaydate = todaydate.AddDays(14);
            //Console.WriteLine(todaydate);
            //MessageBox.Show(todaydate.Date.ToString("dd-MM-yyyy"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Add_item where DateOfExpiry = @d";
            cmd.Parameters.AddWithValue("@d", todaydate.Date.ToString("dd-MM-yyyy"));
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            Expirygridview.DataSource = dt;
            foreach (DataRow row in dt.Rows)
            {

                sb.AppendLine(row["Name"].ToString());
                count++;
            }
            //MessageBox.Show(sb.ToString());

        }
        protected void Displaynotify()
        {

            alert.Icon = new System.Drawing.Icon(Path.GetFullPath(@"images\alert.ico"));
            alert.Text = "Click To See Message Of items that will expire";
            alert.Visible = true;
            alert.BalloonTipTitle = count.ToString() + " Items will Expired After 14 Days";
            alert.BalloonTipText = "Click Here to see details";
            alert.ShowBalloonTip(100);


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(from.Value.ToString("dd-MM-yyyy"));
            DataTable dt = new DataTable();
            //  DateTime dt1 = DateTime.Now;
            // DateTime todaydate = dt1.Date;
            // todaydate = todaydate.AddDays(15);
            // Console.WriteLine(todaydate);
            // MessageBox.Show(todaydate.Date.ToString("dd-MM-yyyy"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Add_item where DateOfExpiry BETWEEN @from And @to";
            cmd.Parameters.AddWithValue("@from", from.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@to", to.Value.ToString("dd-MM-yyyy"));

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            cmd.ExecuteNonQuery();
            Expirygridview.DataSource = dt;


        }

        private void alert_Click(object sender, EventArgs e)
        {

        }
    }
}
