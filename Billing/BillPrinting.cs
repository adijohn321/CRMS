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

namespace CAPSTONEPROJ.Billing
{
    public partial class BillPrinting : Form
    {
        public BillPrinting()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        MySqlCommand cmd;
        MySqlDataReader dr;
        Database db = new Database();
        string invoiceno, id;
        public BillPrinting(string invoiceno, string id)
        {
            InitializeComponent();
            this.invoiceno = invoiceno;
            this.id = id;
        }

        private void BillPrinting_Load(object sender, EventArgs e)
        {
            Print();
        }

        void Print()
        {
            MessageBox.Show("");
            conn.Close();

            conn.Open();
            string query = "SELECT invoicetbl.invoiceNo as 'invoiceId', medicine_tbl.id AS 'medId', medicine_tbl.name AS 'medDescription', invoicetbl.total, invoicetbl.quantity As 'qty', medicine_tbl.price as 'unitPrice' FROM invoicetbl INNER JOIN medicine_tbl Where invoicetbl.invoiceNo = '20221130036204'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "medicineInfo");
            conn.Close();

            conn.Open();
            string query1 = "Select id, firstname, middlename, lastname From patienttbl WHERE  id ='" + id + "'";
            cmd = new MySqlCommand(query1, conn);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "patientInfo");
            conn.Close();


            billsReport cr1 = new billsReport();
            //cr1.ParameterFields.
            cr1.SetDataSource(ds1);
            cr1.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();

        }
    }
}
