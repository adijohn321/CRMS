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
using CAPSTONEPROJ.Transaction;

namespace CAPSTONEPROJ.File_Management
{
    public partial class List_of_Register_Patient : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        MySqlDataReader dr;

        public List_of_Register_Patient()
        {
            InitializeComponent();
            setData();
        }
        public void setData() {

                string searchQuery = "SELECT id as 'Patient ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name', status FROM patienttbl UNION SELECT newbornid as 'Patient ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name',status From newbornpatient_tbl";
                MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                datagridViewAllRegisterPatient.DataSource = table;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string patientID;
        string patientValue; 
        string patientStatus;
        private void btnAdmission_Click(object sender, EventArgs e)
        {
            TransactionPatientAdmissionfrm patientAdmissionfrm = new TransactionPatientAdmissionfrm(patientID, patientValue);
            patientAdmissionfrm.Show();
        }
        int selectedRowIndex = 0;

        private void datagridViewAllRegisterPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            patientStatus = datagridViewAllRegisterPatient.Rows[e.RowIndex].Cells[4].Value.ToString();
            patientID = datagridViewAllRegisterPatient.Rows[e.RowIndex].Cells[0].Value.ToString();
            patientValue = datagridViewAllRegisterPatient.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + datagridViewAllRegisterPatient.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + datagridViewAllRegisterPatient.Rows[e.RowIndex].Cells[3].Value.ToString();
            selectedRowIndex = e.RowIndex;
            if (patientStatus == "0")
            {
                btnAdmission.Enabled = true;
                btnConsultation.Enabled = true;
                btnPrenatal.Enabled = true;
            }
            else {
                btnAdmission.Enabled = false;
                btnConsultation.Enabled = false;
                btnPrenatal.Enabled = false;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void List_of_Register_Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void List_of_Register_Patient_Load(object sender, EventArgs e)
        {
            notecontent.Text = datagridViewAllRegisterPatient.Rows.Count.ToString();
        }

        private void datagridViewAllRegisterPatient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
    }
}
