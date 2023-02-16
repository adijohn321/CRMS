using CrystalDecisions.Shared;
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
using CAPSTONEPROJ.File_Management;
using CAPSTONEPROJ.Billing;

namespace CAPSTONEPROJ.Transaction
{
    public partial class TransactionInpatientsfrm : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        public TransactionInpatientsfrm()
        {
            InitializeComponent();
        }
        public void searchPatient(string searchValue)
        {
            string searchQuery = "SELECT patienttbl.id as 'ID', patienttbl.firstname as 'First Name', patienttbl.middlename as 'Middle Name', patienttbl.lastname as 'Last Name', admittedpateinttbl.date AS 'Date admitted'," +
                " admittedpateinttbl.roomNumber AS 'Room', admittedpateinttbl.bedNumber AS 'Bed Number' FROM `bills` INNER JOIN patienttbl ON patienttbl.id =bills.pateintId INNER JOIN admittedpateinttbl ON" +
                " bills.caseNumber = admittedpateinttbl.caseNumber WHERE bills.status = 0 AND CONCAT (patienttbl.firstname, patienttbl.middlename, patienttbl.lastname) LIKE '%" + searchValue + "%' AND admittedpateinttbl.status = '1'" +
                "UNION SELECT newbornid as 'ID',firstname as 'First Name',middlename as 'Middle Name', lastname as 'Last Name', admittedpateinttbl.date AS 'Date admitted', admittedpateinttbl.roomNumber" +
                " AS 'Room', admittedpateinttbl.bedNumber AS 'Bed Number' FROM `bills` INNER JOIN newbornpatient_tbl ON newbornpatient_tbl.newbornid =bills.pateintId INNER JOIN admittedpateinttbl ON" +
                " bills.caseNumber = admittedpateinttbl.caseNumber WHERE bills.status='0' AND CONCAT (firstname,middlename, lastname) LIKE '%" + searchValue + "%' AND admittedpateinttbl.status = '1'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewAdmittedPatient.DataSource = table;
        }
        private void TransactionInpatientsfrm_Load(object sender, EventArgs e)
        {
            searchPatient("");
            notecontent.Text = dataGridViewAdmittedPatient.Rows.Count.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchPatient(txtsearch.Text);
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewAdmittedPatient.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        private void btndischarge_Click(object sender, EventArgs e)
        {
            string invoice = db.getInvoiceNumber(dischargeID);
            billsReport frm1 = new billsReport();
            BillingReport breport = new BillingReport(invoice, dischargeID);



            breport.ShowDialog();
        }
        string dischargeID, patientID, patientValue;
        string admittedValue;
        int selectedRowIndex = 0;
        private void dataGridViewAdmittedPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btndischarge.Enabled = true;
            btnPrintBill.Enabled = true;
            btngiveMedicine.Enabled = true;
            if (e.RowIndex == -1)
                return;
            patientID = dataGridViewAdmittedPatient.Rows[e.RowIndex].Cells[0].Value.ToString();
            patientValue = dataGridViewAdmittedPatient.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridViewAdmittedPatient.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataGridViewAdmittedPatient.Rows[e.RowIndex].Cells[3].Value.ToString();
            dischargeID = dataGridViewAdmittedPatient.Rows[e.RowIndex].Cells[0].Value.ToString();
            admittedValue = dataGridViewAdmittedPatient.Rows[e.RowIndex].Cells[1].Value.ToString();
            selectedRowIndex = e.RowIndex;
            if (patientID.Length != 14)
            {
                btnDelivery.Enabled = false;
                btnapgarscore.Enabled = true;
                btnamstleinc.Enabled = true;
            }
            else {
                btnDelivery.Enabled = true;
                btnapgarscore.Enabled = false;
                btnamstleinc.Enabled = false;
            }
        }

        private void dataGridViewAdmittedPatient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void TransactionInpatientsfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btngiveMedicine_Click(object sender, EventArgs e)
        {
            new GiveMed(db.getInvoiceNumber(dischargeID),dischargeID).Show();
        }

        private void btndischarge_Click_1(object sender, EventArgs e)
        {

            DischargeIinformationfrm ds = new DischargeIinformationfrm(dischargeID,dataGridViewAdmittedPatient.Rows[selectedRowIndex].Cells[1].Value.ToString()+""+ dataGridViewAdmittedPatient.Rows[selectedRowIndex].Cells[2].Value.ToString()+""+ dataGridViewAdmittedPatient.Rows[selectedRowIndex].Cells[3].Value.ToString(), dataGridViewAdmittedPatient.Rows[selectedRowIndex].Cells[0].Value.ToString());
            ds.Show();
            dataGridViewAdmittedPatient.Refresh();
            dataGridViewAdmittedPatient.Rows.Count.ToString();
            
        }

        private void btnNewborn_Click(object sender, EventArgs e)
        {
            ManageEditDeleteNewbornfrm manageEditDeleteNewbornfrm = new ManageEditDeleteNewbornfrm();
            manageEditDeleteNewbornfrm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnamstleinc_Click(object sender, EventArgs e)
        {
            AMSTLandEINC aMSTLandEINC = new AMSTLandEINC(patientID, patientValue);
            aMSTLandEINC.Show();
        }

        private void ChargePatient_Click(object sender, EventArgs e)
        {
            GiveMed giveMed = new GiveMed();
            giveMed.Show();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            DeliveryInformationfrm delivery = new DeliveryInformationfrm(patientID, patientValue);
            delivery.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* DeliveryInformationfrm delivery = new DeliveryInformationfrm(patientID, patientValue);
            delivery.Show();*/
        }

        private void TransactionInpatientsfrm_Shown(object sender, EventArgs e)
        {
            searchPatient("");
        }

        private void dataGridViewAdmittedPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnapgarscore_Click(object sender, EventArgs e)
        {
            Apgarscorefrm apgarscorefrm = new Apgarscorefrm(patientID, patientValue);
            apgarscorefrm.Show();
        }

    }
}
