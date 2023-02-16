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
    public partial class InquiryPatirntInformationfrm : Form
    {
        public InquiryPatirntInformationfrm()
        {
            InitializeComponent();
        }

        private void InquiryPatirntInformationfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnAdmission_Click(object sender, EventArgs e)
        {
            InquiryMotherProfile inquiryMotherProfile = new InquiryMotherProfile(dataGridViewPatientInformation.Rows[row].Cells[0].Value.ToString(),(dataGridViewPatientInformation.Rows[row].Cells[1].Value.ToString()+" "+ dataGridViewPatientInformation.Rows[row].Cells[2].Value.ToString()+" "+ dataGridViewPatientInformation.Rows[row].Cells[3].Value.ToString()));
            inquiryMotherProfile.Show();
        }

        private void InquiryPatirntInformationfrm_Load(object sender, EventArgs e)
        {
            searchPatient("");
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        string id;
        public void searchPatient(string searchValue)
        {
            //string searchQuery = "SELECT `id` as 'Patient ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM patienttbl WHERE CONCAT (firstname, middlename, lastname) LIKE '%" + searchValue + "%'";
            //string searchQuery = "SELECT `id` as 'Patient ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM patienttbl WHERE CONCAT (firstname, middlename, lastname) LIKE '%" + searchValue + "%'";
            string searchQuery = "SELECT id as 'Patient ID',firstname as 'First Name', middlename as 'Middle Name', lastname as 'Last Name' FROM `patienttbl` UNION SELECT newbornid AS 'id',firstname,middlename,lastname FROM newbornpatient_tbl WHERE CONCAT (firstname,middlename,lastname ) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewPatientInformation.DataSource = table;
        }
        int row;
        private void dataGridViewPatientInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
