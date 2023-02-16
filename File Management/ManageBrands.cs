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


namespace CAPSTONEPROJ.File_Management
{
    public partial class ManageBrands : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        MySqlCommand cmd;
        MySqlDataReader dataReader;
        public ManageBrands()
        {
            InitializeComponent();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchMedicineService(txtsearch.Text);
            btnEdit.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewBrands.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

        private void ManageBrands_Load(object sender, EventArgs e)
        {
            notecontent.Text = dataGridViewBrands.Rows.Count.ToString();
            txtName.Enabled = false;
            txtDistributor.Enabled = false;
            rdRoom.Enabled = false;
            rdBed.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            searchMedicineService("");
        }
        public bool validateEntry(string brandname, string distributor)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from brand_tbl where name='" + brandname + "' and distributor = '" + distributor + "'";
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
        public string sql;
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        MySqlDataReader dr;
        MySqlConnection con = new Database().getConnection();
        public string generateId()
        {
            Random rand = new Random();
            string ret;

            conn.Close();
            conn.Open();




            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            while (true)
            {

                ret = "3";
                for (int a = 0; a < 6; a++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from brand_tbl where  id ='" + ret + "'";
                cmd.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            txtsearch.Enabled = false;
            txtName.Enabled = true;
            txtDistributor.Enabled = true;
            rdRoom.Enabled = true;
            rdBed.Enabled = true;
            dataGridViewBrands.Enabled = false;
        }
        Database data = new Database();
        MAnagenondrugs nondrugs = new MAnagenondrugs();
        ManageAddEditDeleteMedicinefrm medicine = new ManageAddEditDeleteMedicinefrm();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtDistributor.Text == "" || !(rdRoom.Checked || rdBed.Checked))
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (validateEntry(txtName.Text, txtDistributor.Text))
                {
                    MessageBox.Show("Brand name already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (data.insertBrand(generateId(), rdRoom.Checked ? "Medicine" : "Non-Drugs", txtName.Text, txtDistributor.Text))
                {
                    MessageBox.Show("Successfully save.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewBrands.DataSource = data.getBrands();
                    txtName.Enabled = false;
                    txtDistributor.Enabled = false;
                    rdRoom.Enabled = false;
                    rdBed.Enabled = false;
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    dataGridViewBrands.Enabled = true;
                    txtsearch.Enabled = true;
                    notecontent.Text = dataGridViewBrands.Rows.Count.ToString();
                    txtName.Text = "";
                    txtDistributor.Text = "";
                    rdRoom.Checked = false;
                    rdBed.Checked = false;
                    medicine.comboBrand.Refresh();
                    nondrugs.txtbrand.Refresh();
                    
                }
                else
                {
                    MessageBox.Show("Not Saved.");

                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            notecontent.Text = dataGridViewBrands.Rows.Count.ToString();
            txtName.Enabled = false;
            txtDistributor.Enabled = false;
            rdRoom.Enabled = false;
            rdBed.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void ManageBrands_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public void searchMedicineService(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Item ID', `type` as 'Type', `name` as 'Brand Name', `distributor` as 'Distributor' FROM `brand_tbl` WHERE CONCAT(id, type, name, distributor) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewBrands.DataSource = table;
        }
        string updateId, v1;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = data.getBrand(updateId);
            reader.Read();
            v1 = reader.GetValue(1).ToString();
            if (v1.ToLower().Equals("medicine"))
            {
                rdRoom.Checked = true;
            }
            else
            {
                rdBed.Checked = true;
            }
            txtName.Text = reader.GetValue(2).ToString();
            txtDistributor.Text = reader.GetValue(3).ToString();

            data.closeConnection();

            dataGridViewBrands.Enabled = false;
            txtsearch.Enabled = false;
            txtName.Enabled = true;
            txtDistributor.Enabled = true;
            rdBed.Enabled = true;
            rdRoom.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void dataGridViewBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewBrands.Rows[e.RowIndex].Cells[0].Value.ToString();


            MySqlDataReader reader = data.getData("brand_tbl", updateId);
            reader.Read();

            v1 = reader.GetValue(1).ToString();
            if (v1.ToLower().Equals("medicine"))
            {
                rdRoom.Checked = true;
            }
            else
            {
                rdBed.Checked = true;
            }
            txtName.Text = reader.GetValue(2).ToString();
            txtDistributor.Text = reader.GetValue(3).ToString();

            data.closeConnection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (data.UpdateBrand(updateId, rdRoom.Checked ? "Medicine" : "Non-Drugs", txtName.Text, txtDistributor.Text))
                {
                    MessageBox.Show("Item successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewBrands.DataSource = data.getBrands();
                    txtName.Text = "";
                    txtDistributor.Text = "";
                    rdRoom.Checked = false;
                    rdBed.Checked = false;
                    txtsearch.Enabled = true;
                    dataGridViewBrands.Enabled = true;
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
           // Database data = new Database();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDistributor.Text = "";
            rdRoom.Checked = false;
            rdBed.Checked = false;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewBrands.Refresh();
            dataGridViewBrands.Enabled = true;
            txtsearch.Enabled = true;
            txtDistributor.Enabled = false;
            txtName.Enabled = false;
            rdRoom.Enabled = false;
            rdBed.Enabled = false;
        }

        private void dataGridViewBrands_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
