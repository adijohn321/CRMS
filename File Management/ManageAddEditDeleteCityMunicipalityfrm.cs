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
    public partial class ManageAddEditDeleteCityMunicipalityfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        MySqlDataReader dr;
        string province = null;

        public ManageAddEditDeleteCityMunicipalityfrm()
        {
            InitializeComponent();
            dataGridViewCityMunicipality.DataSource = db.getMunicipality();
        }
        public ManageAddEditDeleteCityMunicipalityfrm(string province)
        {
            InitializeComponent();
            dataGridViewCityMunicipality.DataSource = db.getMunicipality();
            this.province = province;
        }

        public void searchMunicipality(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'City/Municipality ID', `province` as 'Province', `municipality` as 'City/Municipality' FROM municipalitytbl WHERE CONCAT (municipality, province) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewCityMunicipality.DataSource = table;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchMunicipality(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewCityMunicipality.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        public bool validateEntry(string municipality)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) {
                    connection.Open();
                }
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select municipality from municipalitytbl where municipality='" + municipality + "'";
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
        public void bindprovince()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from provincetbl", connection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboProvince.Items.Add(dr.GetValue(1).ToString());
            }
            dr.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewCityMunicipality.Enabled = false;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
            txtmunicipality.Enabled = true;
            comboProvince.Enabled = true;

        }

        private void addingOn()
        {
            dataGridViewCityMunicipality.Enabled = false;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
            txtmunicipality.Enabled = true;
            comboProvince.Enabled = false;
            comboProvince.SelectedItem = province;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtmunicipality.Text == "")
            {
                MessageBox.Show("Please enter City or Municipality name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                if (validateEntry(txtmunicipality.Text))
                {
                    MessageBox.Show(txtmunicipality.Text + "Cannot update information already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmunicipality.Text = "";
                    comboProvince.SelectedIndex = -1;
                    return;
                }
                if (db.insertMunicipality(comboProvince.Text, txtmunicipality.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show(txtmunicipality.Text + " successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewCityMunicipality.DataSource = db.getMunicipality();
                        btnAdd.Enabled = true;
                        txtmunicipality.Text = "";
                        comboProvince.SelectedIndex = -1;
                        txtmunicipality.Enabled = false;
                        comboProvince.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        txtsearch.Enabled = true;
                        dataGridViewCityMunicipality.Enabled = true;
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        string updateId, updateProvince, updateCity;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridViewCityMunicipality.Enabled = false;
            txtsearch.Enabled = false;
            txtmunicipality.Enabled = true;
            comboProvince.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            comboProvince.Text = updateProvince;
            txtmunicipality.Text = updateCity;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateMunicipality(updateId,comboProvince.Text, txtmunicipality.Text))
                {
                    MessageBox.Show("Successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewCityMunicipality.DataSource = db.getMunicipality();
                    txtmunicipality.Text = "";
                    comboProvince.SelectedIndex = -1;
                    txtmunicipality.Enabled = false;
                    comboProvince.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewCityMunicipality.Enabled = true;
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
            txtmunicipality.Text = "";
            comboProvince.SelectedIndex = -1;
            txtmunicipality.Enabled = false;
            comboProvince.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewCityMunicipality.Refresh();
            dataGridViewCityMunicipality.Enabled = true;
            txtsearch.Enabled = true;
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteMunicipality(updateId))
                {
                    MessageBox.Show("Successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewCityMunicipality.DataSource = db.getMunicipality();
                    dataGridViewCityMunicipality.Enabled = true;
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

        private void dataGridViewCityMunicipality_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            updateId = dataGridViewCityMunicipality.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateProvince = dataGridViewCityMunicipality.Rows[e.RowIndex].Cells[1].Value.ToString();
            updateCity = dataGridViewCityMunicipality.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void ManageAddEditDeleteCityMunicipalityfrm_Load(object sender, EventArgs e)
        {
            searchMunicipality("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            txtmunicipality.Enabled = false;
            comboProvince.Enabled = false;
            bindprovince();
            notecontent.Text = dataGridViewCityMunicipality.Rows.Count.ToString();
            if (province != null)
                addingOn();
        }

        private void ManageAddEditDeleteCityMunicipalityfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridViewCityMunicipality_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmunicipality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtmunicipality.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
          /*  if (!System.Text.RegularExpressions.Regex.IsMatch(txtmunicipality.Text, "^[a-zA-Z ]"))
            {
                txtmunicipality.Text.Remove(txtmunicipality.Text.Length - 1);
            }*/
        }
        private void txtmunicipality_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtmunicipality.SelectionStart == 1)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
