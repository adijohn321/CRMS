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

namespace CAPSTONEPROJ.Utilities
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        MySqlDataReader dr;

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewCredintial.SelectedRows.Count == 0)
                return;

            UtilityCreatUserfrm frm = new UtilityCreatUserfrm();
            frm.lblname.Text = dataGridViewCredintial.SelectedRows[0].Cells[1].Value.ToString()+" "+ dataGridViewCredintial.SelectedRows[0].Cells[2].Value.ToString()+""+ dataGridViewCredintial.SelectedRows[0].Cells[3].Value.ToString();
            frm.Show();
        }
        public void searchEmployee(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Employee ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name', `title` as 'Title' FROM employeetbl WHERE CONCAT (firstname, middlename, lastname, title) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewCredintial.DataSource = table;
        }
        private void CreateUser_Load(object sender, EventArgs e)
        {
            searchEmployee("");
            dataGridViewCredintial.DataSource = db.getEmployeeCredit();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchEmployee(txtsearch.Text);
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewCredintial.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

        private void dataGridViewCredintial_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
