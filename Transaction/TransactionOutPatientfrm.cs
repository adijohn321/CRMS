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

namespace CAPSTONEPROJ.Transaction
{
    public partial class TransactionOutPatientfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlConnection con = new Database().getConnection();
        int selectedRowIndex = 0;
        string id;
        public TransactionOutPatientfrm()
        {
            InitializeComponent();
            dataGridViewPatient.DataSource = db.getOutPatient(id);
        }

        public void searchPatient(string searchValue)
        {
            /*string searchQuery = "select id, fristname, middlename, lastname from patienttbl inner join newbornpatient_tbl on patienttbl.id = newbornpatient_tbl.newbornid AS 'id',    ";*/
            string searchQuery = "SELECT `id` as 'ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM patienttbl WHERE CONCAT (firstname, middlename, lastname) LIKE '%" + searchValue + "%' AND status = '0'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewPatient.DataSource = table;
        }
        private void OutPatientFRM_Load(object sender, EventArgs e)
        {
            searchPatient("");
            notecontent.Text = dataGridViewPatient.Rows.Count.ToString();
            btnAdmission.Enabled = false;
            btnConsultation.Enabled = false;
            btnPrenatal.Enabled = false;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchPatient(txtsearch.Text);
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewPatient.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

      /*  private void btnConsultation_Click(object sender, EventArgs e)
        {
            using (Consultation frm = new Consultation())
            {
                if (selectedRowIndex == -1)
                {
                    return;
                }
                id = dataGridViewPatient.Rows[selectedRowIndex].Cells[0].Value.ToString();
                MySqlDataReader dr = db.editPatient(dataGridViewPatient.Rows[selectedRowIndex].Cells[0].Value.ToString());
                if (dr.Read())
                {
                    frm.lblIDNo.Text = dr.GetValue(0).ToString();
                    frm.lblName.Text = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString();
                    frm.lblDOB.Text = DateTime.Parse(dr.GetValue(4).ToString()).ToString("yyyy-MM-dd");
                    frm.lblAge.Text = dr.GetValue(5).ToString() + " years old";
                    //frm.lblattendant.Text = dr.GetValue(11).ToString() + " " + dr.GetValue(12).ToString() + " " + dr.GetValue(10).ToString() + " " + dr.GetValue(9).ToString() + " " + dr.GetValue(8).ToString();
                }
                db.closeConnection();
                frm.ShowDialog();
            }

        }

        private void btnPrenatal_Click(object sender, EventArgs e)
        {
            using (Prenatal frm = new Prenatal())
            {
                DataGridViewRow dtr = new DataGridViewRow();
                dtr = dataGridViewPatient.Rows[selectedRowIndex];
                if (selectedRowIndex == -1)
                {
                    return;
                }
                id = dataGridViewPatient.Rows[selectedRowIndex].Cells[0].Value.ToString();
                MySqlDataReader dr = db.editPatient(dataGridViewPatient.Rows[selectedRowIndex].Cells[0].Value.ToString());
                if (dr.Read())
                {
                    frm.lblIDNo.Text = dr.GetValue(0).ToString();
                    frm.lblName.Text = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString();
                    frm.lblDOB.Text = DateTime.Parse(dr.GetValue(4).ToString()).ToString("yyyy-MM-dd");
                    frm.lblAge.Text = dr.GetValue(5).ToString() + " years old";
                 //   frm.lblAddress.Text = dr.GetValue(11).ToString() + " " + dr.GetValue(12).ToString() + " " + dr.GetValue(10).ToString() + " " + dr.GetValue(9).ToString() + " " + dr.GetValue(8).ToString();
                }
                db.closeConnection();
                frm.ShowDialog();
            }
        }

       *//* private void btnAdmission_Click(object sender, EventArgs e)
        {
            using (PatientAdmission frm = new Admission())
            {
                DataGridViewRow dtr = new DataGridViewRow();
                dtr = dataGridViewPatient.Rows[selectedRowIndex];
                if (selectedRowIndex == -1)
                {
                    return;
                }
                id = dataGridViewPatient.Rows[selectedRowIndex].Cells[0].Value.ToString();
                MySqlDataReader dr = db.editPatient(dataGridViewPatient.Rows[selectedRowIndex].Cells[0].Value.ToString());
                if (dr.Read())
                {
                    frm.lblIDNo.Text = dr.GetValue(0).ToString();
                    frm.lblName.Text = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString();
                    frm.lblDOB.Text = DateTime.Parse(dr.GetValue(4).ToString()).ToString("yyyy-MM-dd");
                    frm.lblAge.Text = dr.GetValue(5).ToString() + " years old";
                    frm.lblAddress.Text = dr.GetValue(11).ToString() + " " + dr.GetValue(12).ToString() + " " + dr.GetValue(10).ToString() + " " + dr.GetValue(9).ToString() + " " + dr.GetValue(8).ToString();
                }
                db.closeConnection();
                frm.ShowDialog();
            }

        }
*//*
        private void dataGridViewPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }*/

        private void OutPatientFRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            TransactionPatientConsultationfrm patientConsultation = new TransactionPatientConsultationfrm(patientID, patientValue);
            patientConsultation.Show();

            
        }
        private void btnAdmission_Click(object sender, EventArgs e)
        {
            TransactionPatientAdmissionfrm patientAdmission = new TransactionPatientAdmissionfrm(patientID, patientValue);
            patientAdmission.Show();
        }

        private void btnPrenatal_Click(object sender, EventArgs e)
        {
            TransactionPatientPrenatalfrm patientPrenatal = new TransactionPatientPrenatalfrm(patientID, patientValue);
            patientPrenatal.Show();
        }

        private void dataGridViewPatient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        string patientID;
        string patientValue;
        private void dataGridViewPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            patientID = dataGridViewPatient.Rows[e.RowIndex].Cells[0].Value.ToString();
            patientValue = dataGridViewPatient.Rows[e.RowIndex].Cells[1].Value.ToString()+" "+ dataGridViewPatient.Rows[e.RowIndex].Cells[2].Value.ToString()+" "+ dataGridViewPatient.Rows[e.RowIndex].Cells[3].Value.ToString();
            selectedRowIndex = e.RowIndex;
            btnAdmission.Enabled = true;
            btnConsultation.Enabled = true;
            btnPrenatal.Enabled = true;
        }

        private void dataGridViewPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
