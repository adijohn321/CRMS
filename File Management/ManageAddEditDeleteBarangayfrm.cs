using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CAPSTONEPROJ.File_Management
{
    public partial class ManageAddEditDeleteBarangayfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        MySqlDataReader dr;
        MySqlCommand cmd;

        public ManageAddEditDeleteBarangayfrm()
        {
            InitializeComponent();
            dataGridViewLocation.DataSource = db.getBarangay();
        }
        string province = null, city = null;
        public ManageAddEditDeleteBarangayfrm(string province, string city)
        {
            InitializeComponent();
            dataGridViewLocation.DataSource = db.getBarangay();
            this.province = province;
            this.city = city;
        }
        public void searchBarangay(string searchValue)
        {
            string searchQuery = "SELECT `addressId` as 'Barangay ID', `province` as 'Province', `citymunicipality` as 'City/Municipality', `barangay` as 'Barangay' FROM `philippinelocaltbl` WHERE CONCAT (barangay,citymunicipality, province) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewLocation.DataSource = table;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchBarangay(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewLocation.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        public bool validateEntry(string barangay)
        {
            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select barangay from philippinelocaltbl where barangay='" + barangay + "'";
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
            cmd = new MySqlCommand("select distinct(province) from municipalitytbl", connection);
            dr = cmd.ExecuteReader();
            comboProvince.Items.Clear();
            while (dr.Read())
            {
                comboProvince.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            connection.Close();
        }
        private void comboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(municipality) from municipalitytbl where province = '" + comboProvince.Text + "'", connection);
            dr = cmd.ExecuteReader();
            comboCityMun.Items.Clear();
            while (dr.Read())
            {
                comboCityMun.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            connection.Close();
        }
        void disableItems() 
        {
            txtBarangay.Enabled = false;
            comboCityMun.Enabled = false;
            comboProvince.Enabled = false;
        }
        void enableItems()
        {
            txtBarangay.Enabled = true;
            comboCityMun.Enabled = true;
            comboProvince.Enabled = true;
        }
        void enableItem()
        {
            txtBarangay.Enabled = true;
            comboProvince.Enabled = false;
            comboProvince.SelectedItem = province;
            comboCityMun.Enabled = false ;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            comboCityMun.SelectedItem = city;
        }
        private void ManageAddEditDeleteBarangayfrm_Load(object sender, EventArgs e)
        {
            bindprovince();
            searchBarangay("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            disableItems();
            notecontent.Text = dataGridViewLocation.Rows.Count.ToString();
            if (city != null)
                enableItem();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewLocation.Enabled = false;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
            txtBarangay.Enabled = true;
            comboProvince.Enabled = true;
            comboCityMun.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBarangay.Text == "")
            {
                MessageBox.Show("Please enter Barangay name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (validateEntry(txtBarangay.Text))
                {
                    MessageBox.Show(txtBarangay.Text + " Barangay name already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarangay.Text = "";
                    comboProvince.SelectedIndex = -1;
                    return;
                }
                if (db.insertBarangay(comboProvince.Text, comboCityMun.Text, txtBarangay.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show(txtBarangay.Text + " successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewLocation.DataSource = db.getBarangay();
                        btnAdd.Enabled = true;
                        txtBarangay.Text = "";
                        comboProvince.SelectedIndex = -1;
                        comboCityMun.SelectedIndex = -1;
                        disableItems();
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        txtsearch.Enabled = true;
                        dataGridViewLocation.Enabled = true;
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        string updateId, updateProvince, updateCity, updateBarangay;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridViewLocation.Enabled = false;
            txtsearch.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            comboProvince.SelectedItem = updateProvince;
            comboCityMun.SelectedItem = updateCity;
            txtBarangay.Text = updateBarangay;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateBarangay(updateId, comboProvince.Text, comboCityMun.Text, txtBarangay.Text))
                {
                    MessageBox.Show("Barangay name successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewLocation.DataSource = db.getBarangay();
                    txtBarangay.Text = "";
                    comboProvince.SelectedIndex = -1;
                    comboCityMun.SelectedIndex = -1;
                    txtBarangay.Enabled = false;
                    comboProvince.Enabled = false;
                    comboCityMun.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewLocation.Enabled = true;
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
            txtBarangay.Text = "";
            comboProvince.SelectedIndex = -1;
            comboCityMun.SelectedIndex = -1;
            disableItems();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewLocation.Refresh();
            dataGridViewLocation.Enabled = true;
            txtsearch.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteBarangay(updateId))
                {
                    MessageBox.Show("Barangay with " + updateId + " is successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewLocation.DataSource = db.getBarangay();
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

        private void ManageAddEditDeleteBarangayfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridViewLocation_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridViewLocation_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dataGridViewLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            updateId = dataGridViewLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateProvince = dataGridViewLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
            updateCity = dataGridViewLocation.Rows[e.RowIndex].Cells[2].Value.ToString();
            updateBarangay = dataGridViewLocation.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void txtBarangay_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBarangay.SelectionStart == 1)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtBarangay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBarangay.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

    }
}
