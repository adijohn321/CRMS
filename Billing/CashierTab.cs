using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPSTONEPROJ.Transaction;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CAPSTONEPROJ.Billing
{
    public partial class CashierTab : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();

        public CashierTab()
        {
            InitializeComponent();
        }
        public void searchEmployee(string searchValue)
        {
            string searchQuery = "SELECT `invoiceNumber` as 'Invoice No.', `pateintId` as 'Patient ID', `status` as 'Status', `discountType` as 'Discount', `grand_total` as 'Total' FROM bills WHERE CONCAT (invoiceNumber, pateintId, discountType, grand_total) LIKE '%" + searchValue + "%' AND status ='2'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void CashierTab_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.getToCasheir();
            button1.Enabled = false;
            notecontent.Text = dataGridView1.Rows.Count.ToString();
            searchEmployee("");
        }
        string id, patientId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            patientId = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransactionPayBillfrm pay = new TransactionPayBillfrm(id, patientId);
            pay.Show();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchEmployee(textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
