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

namespace CAPSTONEPROJ.Inquiry
{
    public partial class PatientRecordFileFRM : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        string id;
        public PatientRecordFileFRM()
        {
            InitializeComponent();
            dataGridViewPatient.DataSource = db.getPatient();
        }
        public void searchPatient(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM patienttbl WHERE CONCAT (firstname, middlename, lastname) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewPatient.DataSource = table;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchPatient(txtsearch.Text);
        }
        private void PatientRecordFileFRM_Load(object sender, EventArgs e)
        {
            searchPatient("");
        }
        int selectedRowIndex;
   
        private void btnView_Click(object sender, EventArgs e)
        {
            using (InquiryMotherProfile frm = new InquiryMotherProfile())
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
                    frm.lblReligion.Text = dr.GetValue(6).ToString();
                    frm.lblContact.Text = dr.GetValue(7).ToString();
                    frm.lblAddress.Text = dr.GetValue(11).ToString() + " " + dr.GetValue(12).ToString() + " " + dr.GetValue(10).ToString() + " " + dr.GetValue(9).ToString() + " " + dr.GetValue(8).ToString();
                }
                db.closeConnection();
                frm.ShowDialog();
            }
        }

        private void PatientRecordFileFRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
