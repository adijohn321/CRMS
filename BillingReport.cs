using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
namespace CAPSTONEPROJ
{
    public partial class BillingReport : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        MySqlCommand cmd;
        MySqlDataReader dr;
        Database db = new Database();
        string invoiceno, id;
        public BillingReport(string invoiceno, string id)
        {
            InitializeComponent();
            this.invoiceno = invoiceno;
            this.id = id;
        }

        private void BillingReport_Load(object sender, EventArgs e)
        {
            //get date admitted
            //get the days-in
            //update total
            DateTime dateAdmitted = DateTime.Parse(db.getAdmissionDate(id));
            int days =(int) DateTime.Now.Subtract(dateAdmitted).TotalDays + 1;
            double total = calculateDaysTotal(days);
            db.updateDayAndTotal(days+"",total+"",invoiceno,itemId);
            db.updateWhatFromWhere("grand_total",calculateTotal().ToString(),"bills","invoiceNumber",invoiceno);
            Print();

        }

        void Print()
        {
            conn.Close();
            conn.Open();
            string query = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, medicine_tbl.name AS 'description', medicine_tbl.id as 'itemId', medicine_tbl.price AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM medicine_tbl INNER JOIN patienttbl ON patienttbl.id ='" + id+ "' INNER JOIN invoicetbl ON medicine_tbl.id = invoicetbl.itemId AND invoicetbl.invoiceNo = '" + invoiceno+"' INNER JOIN bills WHERE bills.invoiceNumber = '"+invoiceno+ "' AND invoicetbl.itemId BETWEEN '9999' AND '99999'";
            cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "DataTable1");
            conn.Close();

            conn.Open();
            string query1 = "SELECT * From bills WHERE invoiceNumber = '"+invoiceno+"'";
            cmd = new MySqlCommand(query1, conn);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "DataTable2");
            conn.Close();

            conn.Open();
            string query2= "SELECT invoicetbl.invoiceNo as 'invoiceId', medicine_tbl.id AS 'medId', medicine_tbl.name AS 'medDescription', invoicetbl.total, invoicetbl.quantity As 'qty', medicine_tbl.price as 'unitPrice' FROM medicine_tbl INNER JOIN invoicetbl ON medicine_tbl.id = invoicetbl.itemId Where invoicetbl.invoiceNo = '" + invoiceno+"'";
            cmd = new MySqlCommand(query2, conn);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            da.Fill(ds2, "medicineInfo");
            conn.Close();


            conn.Open();
            string query3 = "SELECT `id`, `firstname`, `middlename`, `lastname` FROM `patienttbl` WHERE id='"+id+"'";
            cmd = new MySqlCommand(query3, conn);
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "patientInfo");
            conn.Close();


            conn.Open();
            string query4 = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, servicetbl.service_Type AS 'description', servicetbl.serviceId as 'itemId', servicetbl.servicefee AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM servicetbl INNER JOIN patienttbl ON patienttbl.id ='" + id + "' INNER JOIN invoicetbl ON servicetbl.serviceId = invoicetbl.itemId AND invoicetbl.invoiceNo = '" + invoiceno + "' INNER JOIN bills WHERE bills.invoiceNumber = '" + invoiceno + "' AND invoicetbl.itemId BETWEEN '0' AND '999'";
            //string query4 = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, servicetbl.service_Type AS 'description', servicetbl.serviceId as 'itemId', servicetbl.servicefee AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM servicetbl INNER JOIN patienttbl INNER JOIN invoicetbl ON servicetbl.serviceId = invoicetbl.itemId INNER JOIN bills WHERE invoicetbl.itemId BETWEEN '0' AND '999';";
            cmd = new MySqlCommand(query4, conn);
            MySqlDataAdapter da4 = new MySqlDataAdapter(cmd);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "DataTable11");
            conn.Close();

            conn.Open();
            string query5 = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, roombed_tbl.roomName AS 'description',roombed_tbl.bedNo AS 'description1', roombed_tbl.roomBed_Id as 'itemId', roombed_tbl.price AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM roombed_tbl INNER JOIN patienttbl ON patienttbl.id ='" + id + "' INNER JOIN invoicetbl ON roombed_tbl.roomBed_Id = invoicetbl.itemId AND invoicetbl.invoiceNo = '" + invoiceno + "' INNER JOIN bills WHERE bills.invoiceNumber = '" + invoiceno + "' AND invoicetbl.itemId BETWEEN '999999' AND '9999999'";
            //string query4 = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, servicetbl.service_Type AS 'description', servicetbl.serviceId as 'itemId', servicetbl.servicefee AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM servicetbl INNER JOIN patienttbl INNER JOIN invoicetbl ON servicetbl.serviceId = invoicetbl.itemId INNER JOIN bills WHERE invoicetbl.itemId BETWEEN '0' AND '999';";
            cmd = new MySqlCommand(query5, conn);
            MySqlDataAdapter da5 = new MySqlDataAdapter(cmd);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5, "DataTable111");
            conn.Close();

            conn.Open();
            string query6 = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, nondrugs_tbl.name AS 'description', nondrugs_tbl.id as 'itemId', nondrugs_tbl.price AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM nondrugs_tbl INNER JOIN patienttbl ON patienttbl.id ='" + id + "' INNER JOIN invoicetbl ON nondrugs_tbl.id = invoicetbl.itemId AND invoicetbl.invoiceNo = '" + invoiceno + "' INNER JOIN bills WHERE bills.invoiceNumber = '" + invoiceno + "' AND invoicetbl.itemId BETWEEN '99999' AND '999999'";
            //string query4 = "SELECT patienttbl.firstname AS 'pateintName', invoicetbl.invoiceNo AS 'invoice_no', patienttbl.id AS pateintId, invoicetbl.quantity, servicetbl.service_Type AS 'description', servicetbl.serviceId as 'itemId', servicetbl.servicefee AS 'unitPrice', invoicetbl.total AS total, bills.grand_total FROM servicetbl INNER JOIN patienttbl INNER JOIN invoicetbl ON servicetbl.serviceId = invoicetbl.itemId INNER JOIN bills WHERE invoicetbl.itemId BETWEEN '0' AND '999';";
            cmd = new MySqlCommand(query6, conn);
            MySqlDataAdapter da6 = new MySqlDataAdapter(cmd);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6, "DataTable1111");
            conn.Close();


            BillingCrystalReport cr1 = new BillingCrystalReport();
            cr1.SetDataSource(ds);
            cr1.SetDataSource(ds1);
            cr1.SetDataSource(ds2);
            cr1.SetDataSource(ds3);
            cr1.SetDataSource(ds4);
            cr1.SetDataSource(ds5);
            cr1.SetDataSource(ds6);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();

        }
        double calculateTotal()
        {
            double ret = 0;
            conn.Open();
            cmd = new MySqlCommand("select total from invoicetbl WHERE invoiceNo = '"+invoiceno+"'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ret += Double.Parse(dr.GetString(0).Trim().Replace("₱","").Replace(",",""));
            }
            dr.Close();
            conn.Close();
            return ret;
        }
        string itemId;
        double calculateDaysTotal(int days) {
            double ret = 0;
            conn.Open();
            cmd = new MySqlCommand("select itemId from invoicetbl WHERE invoiceNo = '" + invoiceno + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                itemId = dr.GetString(0).Trim();
                ret  =days*  Double.Parse(db.getWhatFromWhere("price", "roombed_tbl", "roomBed_Id", dr.GetString(0).Trim()).Replace("₱","").Replace(",",""));
            }
            dr.Close();
            conn.Close();
            return ret;
        }
    }
}
