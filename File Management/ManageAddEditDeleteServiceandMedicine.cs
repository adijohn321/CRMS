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
    public partial class ManageAddEditDeleteServiceandMedicine : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        //MySqlDataReader dataReader;
        public ManageAddEditDeleteServiceandMedicine()
        {
            InitializeComponent();
            dataGridViewServiceMedicine.DataSource = db.getmedicineServicePrice();
        }
      
        public void searchMedicineService(string searchValue)
        {
            string searchQuery = "SELECT `itemId` as 'Item ID', `itemName` as 'Item Name', `itemPrice` as 'Price', `itemType` as 'Type' FROM `pricetbl` WHERE CONCAT(itemName,itemPrice,itemType)LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewServiceMedicine.DataSource = table;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchMedicineService(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        void disableItems()
        {
            txtPrice.Enabled = false;
            txtSerMedName.Enabled = false;
        }
        private void ManageAddEditDeleteServiceandMedicine_Load(object sender, EventArgs e)
        {
            searchMedicineService("");
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            notecontent.Text = dataGridViewServiceMedicine.Rows.Count.ToString();
            disableItems();
        }
        public bool validateEntry(string itemname)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from pricetbl where itemName='" + itemname + "'";
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
            txtPrice.Text = "";
            txtSerMedName.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewServiceMedicine.Enabled = false;
            txtSerMedName.Enabled = true;
            txtPrice.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSerMedName.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (txtPrice.Text.Equals("₱0.00"))
                {
                    MessageBox.Show("Price cannot be zero.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (validateEntry(txtSerMedName.Text))
                {
                    MessageBox.Show("Service already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (db.insertmedicineServicePrice(txtSerMedName.Text, txtPrice.Text,  lbltype.Text))
                {
                    MessageBox.Show("Service successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewServiceMedicine.DataSource = db.getmedicineServicePrice();
                    btnAdd.Enabled = true;
                    disableItems();
                    clear();
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    dataGridViewServiceMedicine.Enabled = true;
                    txtsearch.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

            MySqlDataReader reader = data.getServiceMed(updateId);
            reader.Read();

            v1 = reader.GetValue(1).ToString();
            v2 = reader.GetValue(2).ToString();
            v3 = reader.GetValue(3).ToString();

            data.closeConnection();

            dataGridViewServiceMedicine.Enabled = false;
            txtsearch.Enabled = false;
            txtPrice.Enabled = true;
            txtSerMedName.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            txtSerMedName.Text = v1;
            txtPrice.Text = v2;
          /*  if (v3.ToLower().Equals("service"))
            {
                rdService.Checked = true;
            }
            else
            {
                rdMedicine.Checked = true;
            }*/
        }
        string v1, v2, v3;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            disableItems();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewServiceMedicine.Refresh();
            dataGridViewServiceMedicine.Enabled = true;
            txtsearch.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deletemedicineServicePrice(updateId))
                {
                    MessageBox.Show("Successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewServiceMedicine.DataSource = db.getmedicineServicePrice();
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
        Database data = new Database();
        private void dataGridViewServiceMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[0].Value.ToString();


            MySqlDataReader reader = data.getData("pricetbl", updateId);
            reader.Read();

            v1 = reader.GetValue(1).ToString();
            v2 = reader.GetValue(2).ToString();
            v3 = reader.GetValue(3).ToString();

            data.closeConnection();

        }

        private void txtSerMedName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSerMedName.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPrice.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
          /*  if (!char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void txtSerMedName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSerMedName.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void ManageAddEditDeleteServiceandMedicine_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewServiceMedicine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridViewServiceMedicine_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }
        string updateId, updateServiceMed, updatePrice, updateType;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewServiceMedicine_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            updateId = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateServiceMed = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[1].Value.ToString();
            updatePrice = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[2].Value.ToString();
            updateType = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updatemedService(updateId, txtSerMedName.Text, txtPrice.Text,lbltype.Text))
                {
                    MessageBox.Show("Item successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewServiceMedicine.DataSource = db.getmedicineServicePrice();
                    clear();
                    disableItems();
                    txtsearch.Enabled = true;
                    dataGridViewServiceMedicine.Enabled = true;
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
            Database data = new Database();
        }
    }
}
