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

namespace CAPSTONEPROJ.Report.SalesReport
{
    public partial class SalesReports : Form
    {
        public SalesReports()
        {
            InitializeComponent();
        }
        public SalesReports(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.from = from.ToString("yyyyy-MM-dd");
            this.to = to.ToString("yyyyy-MM-dd");
        }

        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        MySqlCommand cmd;
        MySqlDataReader dr;
        Database db = new Database();
        string from, to;

        private void SalesReport_Load(object sender, EventArgs e)
        {
            Print();

        }
        void Print() {


            CrystalDecisions.CrystalReports.Engine.TextObject deliverCount;
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            CrystalDecisions.CrystalReports.Engine.TextObject toDate;

            conn.Close();
            conn.Open();
            string query = "SELECT bills.grand_total, bills.discountType, patienttbl.firstname,patienttbl.middlename, patienttbl.lastname,admittedpateinttbl.date FROM `bills` INNER JOIN patienttbl ON bills.pateintId = patienttbl.id INNER JOIN admittedpateinttbl on bills.caseNumber = admittedpateinttbl.caseNumber WHERE admittedpateinttbl.date BETWEEN '"+from.Substring(1,10)+"' AND '"+to.Substring(1,10)+"'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "DataTable3");
            int count = ds.Tables[0].Rows.Count;
            int total = 0;
            conn.Close();
            
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                total += Int32.Parse(dr.GetString(0));
            }
            conn.Close();


            SalesCrystalReport cr1 = new SalesCrystalReport();
            cr1.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr1;


            txtReportHeader = cr1.ReportDefinition.ReportObjects["txtFrom"] as TextObject;
            toDate = cr1.ReportDefinition.ReportObjects["txtTo"] as TextObject;
            deliverCount = cr1.ReportDefinition.ReportObjects["txtMegaTotal"] as TextObject;
            deliverCount.Text = "" + total;
            txtReportHeader.Text = "" + from.Substring(1, 10);
            toDate.Text = "" + to.Substring(1, 10);
            crystalReportViewer1.Refresh();
        }
    }
}
