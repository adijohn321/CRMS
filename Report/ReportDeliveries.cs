using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPSTONEPROJ.Report
{
    public partial class ReportDeliveries : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        MySqlCommand cmd;
        MySqlDataReader dr;
        Database db = new Database();
        string invoiceno, id;
        string from, to;
        public ReportDeliveries(DateTime from, DateTime to)
        {
            this.from = from.ToString("yyyyy-MM-dd");
            this.to = to.ToString("yyyyy-MM-dd");
            InitializeComponent();
        }

        private void ReportDeliveries_Load(object sender, EventArgs e)
        {
            Print();
        }


        void Print()
        {
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            CrystalDecisions.CrystalReports.Engine.TextObject toDate;
            CrystalDecisions.CrystalReports.Engine.TextObject deliverCount;

            conn.Close();
            conn.Open();
            string query = "SELECT * FROM delivery_tbl WHERE dateDeliver BETWEEN '"+from.Substring(1,10)+"' AND '"+to.Substring(1,10)+"'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "deliverTbl");
            int count = ds.Tables[0].Rows.Count;
            conn.Close();




            ReportNewborn cr1 = new ReportNewborn();
            cr1.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr1;
            txtReportHeader = cr1.ReportDefinition.ReportObjects["txtFrom"] as TextObject;
            toDate = cr1.ReportDefinition.ReportObjects["txtTo"] as TextObject;
            deliverCount = cr1.ReportDefinition.ReportObjects["txtCount"] as TextObject;
            deliverCount.Text = "" + count;
            txtReportHeader.Text = ""+ from.Substring(1, 10);
            toDate.Text = ""+ to.Substring(1, 10);
            crystalReportViewer1.Refresh();

        }
    }
}
