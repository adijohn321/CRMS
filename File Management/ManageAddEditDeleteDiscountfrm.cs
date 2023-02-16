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

namespace CAPSTONEPROJ.File_Management
{
    public partial class ManageAddEditDeleteDiscountfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        MySqlDataReader dr;
        MySqlCommand cmd;
        public ManageAddEditDeleteDiscountfrm()
        {
            InitializeComponent();
            dataGridViewDiscount.DataSource = db.getDiscount();
        }
        string updateId, v1, v2;
        public void searchDiscount(string searchValue)
        {
            string searchQuery = "SELECT `discountId` as 'Discount ID', `discountType` as 'Discount Type', `discountrate` as 'Discount Rate' FROM `discount_tbl` WHERE CONCAT(discountType, discountrate)LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewDiscount.DataSource = table;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchDiscount(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewDiscount.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        private void ManageAddEditDeleteDiscountfrm_Load(object sender, EventArgs e)
        {
            notecontent.Text = dataGridViewDiscount.Rows.Count.ToString();
            searchDiscount("");
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtdiscountRate.Enabled = false;
            txtdiscountType.Enabled = false;
        }
        public bool validateEntry(string discountType)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from discount_tbl where discountId='" + discountType + "'";
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    connection.Close();
                    return false;
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        void clear()
        {
            txtdiscountType.Text = "";
            txtdiscountRate.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewDiscount.Enabled = false;
            txtdiscountRate.Enabled = true;
            txtdiscountType.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtdiscountType.Text == "" || txtdiscountRate.Text == "")
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (validateEntry(txtdiscountType.Text))
                {
                    MessageBox.Show("Discount Type name already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (db.insertDiscount(txtdiscountType.Text, txtdiscountRate.Text))
                {
                    MessageBox.Show("New discount successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewDiscount.DataSource = db.getDiscount();
                    btnAdd.Enabled = true;
                    txtdiscountRate.Enabled = false;
                    txtdiscountType.Enabled = false;
                    clear();
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = db.getDiscountRate(updateId);
            reader.Read();

            v1 = reader.GetValue(1).ToString();
            v2 = reader.GetValue(2).ToString();

            db.closeConnection();

            dataGridViewDiscount.Enabled = false;
            txtsearch.Enabled = false;
            txtdiscountRate.Enabled = true;
            txtdiscountType.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            txtdiscountType.Text = v1;
            txtdiscountRate.Text = v2;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateDiscount(updateId, txtdiscountType.Text, txtdiscountRate.Text))
                {
                    MessageBox.Show("Discount successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewDiscount.DataSource = db.getDiscount();
                    clear();
                    txtdiscountRate.Enabled = false;
                    txtdiscountType.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewDiscount.Enabled = true;
                    btnCancel.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnAdd.Enabled = true;
                }
                else
                {
                    MessageBox.Show("An error occured in save");

                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            txtdiscountType.Enabled = false;
            txtdiscountRate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewDiscount.Refresh();
            dataGridViewDiscount.Enabled = true;
            txtsearch.Enabled = true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteDiscount(updateId))
                {
                    MessageBox.Show("Discount with " + updateId + " is successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewDiscount.DataSource = db.getDiscount();
                    txtsearch.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        string discountType, discountRate;
        private void dataGridViewDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            updateId = dataGridViewDiscount.Rows[e.RowIndex].Cells[0].Value.ToString();
            discountType = dataGridViewDiscount.Rows[e.RowIndex].Cells[1].Value.ToString();
            discountRate = dataGridViewDiscount.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void txtdiscountType_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtdiscountRate.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void txtdiscountRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtdiscountRate.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void txtdiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar != Convert.ToChar(Keys.Back) || e.KeyChar != Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }

            // only allow one decimal point 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtdiscountType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtdiscountType.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void ManageAddEditDeleteDiscountfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void dataGridViewDiscount_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
