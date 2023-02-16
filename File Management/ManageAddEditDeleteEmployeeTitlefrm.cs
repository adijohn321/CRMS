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
    public partial class ManageAddEditDeleteEmployeeTitlefrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        public ManageAddEditDeleteEmployeeTitlefrm()
        {
            InitializeComponent();
            dataGridViewEmployeeType.DataSource = db.getEmployeeType();
        }
        public void searchEmpTitle(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Employee Title ID', `employeetitle` as 'Employee Title' FROM `employeetitletbl` WHERE employeetitle LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewEmployeeType.DataSource = table;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchEmpTitle(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewEmployeeType.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

        private void EmployeeTitlefrm_Load(object sender, EventArgs e)
        {
            searchEmpTitle("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            txtemployeetype.Enabled = false;
            notecontent.Text = dataGridViewEmployeeType.Rows.Count.ToString();
        }
        public bool validateEntry(string employeetitle)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employeetitletbl where employeetitle='" + employeetitle + "'";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewEmployeeType.Enabled = false;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
            txtemployeetype.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtemployeetype.Text == "")
            {
                MessageBox.Show("Please enter employee title.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (validateEntry(txtemployeetype.Text))
                {
                    MessageBox.Show(txtemployeetype.Text + " employee title already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtemployeetype.Text = "";
                    return;
                }
                if (db.insertEmployeeType(txtemployeetype.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show(txtemployeetype.Text + " employee title successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewEmployeeType.DataSource = db.getEmployeeType();
                        btnAdd.Enabled = true;
                        txtemployeetype.Text = "";
                        txtemployeetype.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        txtsearch.Enabled = true;
                        dataGridViewEmployeeType.Enabled = true;
                    }
                    else
                    {

                    }
                }

            }
        }
        string updateId;
        string employeetypeValue;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridViewEmployeeType.Enabled = false;
            txtsearch.Enabled = false;
            txtemployeetype.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            txtemployeetype.Text = employeetypeValue;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateReligion(updateId, txtemployeetype.Text))
                {
                    MessageBox.Show("Employee title successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEmployeeType.DataSource = db.getEmployeeType();
                    txtemployeetype.Text = "";
                    txtemployeetype.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewEmployeeType.Enabled = true;
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
            txtemployeetype.Text = "";
            txtemployeetype.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewEmployeeType.Refresh();
            dataGridViewEmployeeType.Enabled = true;
            txtsearch.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteEmployeeType(updateId))
                {
                    MessageBox.Show("Employee title with " + updateId + " is successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEmployeeType.DataSource = db.getEmployeeType();
                    txtsearch.Enabled = true;
                    dataGridViewEmployeeType.Enabled = true;
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

        private void dataGridViewEmployeeType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewEmployeeType.Rows[e.RowIndex].Cells[0].Value.ToString();
            employeetypeValue = dataGridViewEmployeeType.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void txtemployeetype_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtemployeetype_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtemployeetype.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtemployeetype_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (txtemployeetype.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void ManageAddEditDeleteEmployeeTitlefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridViewEmployeeType_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridViewEmployeeType_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            notecontent.Text = "Total Number of Employee Title List :  " + dataGridViewEmployeeType.Rows.Count.ToString() + ".";
        }
    }
}
