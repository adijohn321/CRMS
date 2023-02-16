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
    public partial class ManageAddEditDeleteReligionfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        public ManageAddEditDeleteReligionfrm()
        {
            InitializeComponent();
            dataGridViewReligion.DataSource = db.getReligion();
        }
        public void searchReligion(string searchValue)
        {
            string searchQuery = "SELECT * FROM `religiontbl` WHERE religion LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewReligion.DataSource = table;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchReligion(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewReligion.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

        private void Religionfrm_Load(object sender, EventArgs e)
        {
            searchReligion("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            txtreligion.Enabled = false;
            notecontent.Text = dataGridViewReligion.Rows.Count.ToString();
           
        }
        public bool validateEntry(string religion)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from religiontbl where religion='" + religion + "'";
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
            dataGridViewReligion.Enabled = false;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
            txtreligion.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtreligion.Text == "")
            {
                MessageBox.Show("Please enter religion sector.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (validateEntry(txtreligion.Text))
                {
                    MessageBox.Show(txtreligion.Text + " religion sector already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtreligion.Text = "";
                    return;
                }
                if (db.insertReligion(txtreligion.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show(txtreligion.Text + " religion sector successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewReligion.DataSource = db.getReligion();
                        btnAdd.Enabled = true;
                        txtreligion.Text = "";
                        txtreligion.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        txtsearch.Enabled = true;
                        dataGridViewReligion.Enabled = true;
                    }
                    else
                    {

                    }
                }

            }
        }
        string updateId;
        string religionValue;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridViewReligion.Enabled = false;
            txtsearch.Enabled = false;
            txtreligion.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            txtreligion.Text = religionValue;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateReligion(updateId, txtreligion.Text))
                {
                    MessageBox.Show("Religion sector successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewReligion.DataSource = db.getReligion();
                    txtreligion.Text = "";
                    txtreligion.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewReligion.Enabled = true;
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
            txtreligion.Text = "";
            txtreligion.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewReligion.Refresh();
            dataGridViewReligion.Enabled = true;
            txtsearch.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteReligion(updateId))
                {
                    MessageBox.Show("Religion with " + updateId + " is successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewReligion.DataSource = db.getReligion();
                    txtsearch.Enabled = true;
                    dataGridViewReligion.Enabled = true;
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

        private void dataGridViewReligion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewReligion.Rows[e.RowIndex].Cells[0].Value.ToString();
            religionValue = dataGridViewReligion.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void txtreligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtreligion.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }


        private void ManageAddEditDeleteReligionfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridViewReligion_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridViewReligion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            notecontent.Text = "Total Number of Religion List :  " + dataGridViewReligion.Rows.Count.ToString() + ".";
        }
    }
}
