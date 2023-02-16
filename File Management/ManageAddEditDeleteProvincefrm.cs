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
    public partial class ManageAddEditDeleteProvincefrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        public ManageAddEditDeleteProvincefrm()
        {
            InitializeComponent();
            dataGridViewProvince.DataSource = db.getProvince();
        }
        public void searchProvince(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Province ID', `province` as 'Province' FROM `provincetbl` WHERE province LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewProvince.DataSource = table;
        }
        private void Provincefrm_Load(object sender, EventArgs e)
        {
            searchProvince("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            txtprovince.Enabled = false;
            notecontent.Text = dataGridViewProvince.Rows.Count.ToString();
        }
        public bool validateEntry(string province)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from provincetbl where province='" + province + "'";
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
            dataGridViewProvince.Enabled = false;
            txtprovince.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtprovince.Text == "")
            {
                MessageBox.Show("Please enter province name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (validateEntry(txtprovince.Text))
                {
                    MessageBox.Show(txtprovince.Text + " Province name already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtprovince.Text = "";
                    return;
                }
                if (db.insertProvince(txtprovince.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show(txtprovince.Text + " Province name successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewProvince.DataSource = db.getProvince();
                        btnAdd.Enabled = true;
                        txtprovince.Text = "";
                        txtprovince.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        txtsearch.Enabled = true;
                        dataGridViewProvince.Enabled = true;
                    }
                    else
                    {
                        
                    }
                }
                
            }
        }
        string updateId;
        string provinceValue;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridViewProvince.Enabled = false;
            txtsearch.Enabled = false;
            txtprovince.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            txtprovince.Text = provinceValue;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateProvince(updateId, txtprovince.Text))
                {
                    MessageBox.Show("Province name successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewProvince.DataSource = db.getProvince();
                    txtprovince.Text = "";
                    txtprovince.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewProvince.Enabled = true;
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
            txtprovince.Text = "";
            txtprovince.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewProvince.Refresh();
            dataGridViewProvince.Enabled = true;
            txtsearch.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteProvince(updateId))
                {
                    MessageBox.Show("Province name with " + updateId + " is successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewProvince.DataSource = db.getProvince();
                    txtsearch.Enabled = true;
                    dataGridViewProvince.Enabled = true;
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

        private void dataGridViewProvince_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId =  dataGridViewProvince.Rows[e.RowIndex].Cells[0].Value.ToString();
            provinceValue = dataGridViewProvince.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
        private void txtprovince_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtprovince_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtprovince.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchProvince(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewProvince.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

        private void txtprovince_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (txtprovince.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void ManageAddEditDeleteProvincefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridViewProvince_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridViewProvince_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            notecontent.Text = "Total Number of Province List :  " + dataGridViewProvince.Rows.Count.ToString() + ".";
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

