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
    public partial class ManageAddEditDeleteMedicinefrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        public ManageAddEditDeleteMedicinefrm()
        {
            InitializeComponent();
            //dgvMedicine.DataSource = db.getMedicinewithPrice();
        }
        string updateId;
        private void ManageAddEditDeleteMedicinefrm_Load(object sender, EventArgs e)
        {
            loadMed();
            txtdesc.Enabled = false;
            txtdosage.Enabled = false;
            txtname.Enabled = false;
            txtprice.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            notecontent.Text = dgvMedicine.Rows.Count.ToString();
            searchMedicineService("");
        }
        public string sql;
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        public void loadMed() {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from brand_tbl WHERE type = 'medicine'", conn);
            dr = cmd.ExecuteReader();
            comboBrand.Items.Clear();
            while (dr.Read())
            {
                comboBrand.Items.Add(dr.GetString("name").ToString());
            }


            dr.Close();
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            loadMed();
            dgvMedicine.Enabled = false;
            txtdesc.Enabled = true;
            txtdosage.Enabled = true;
            txtname.Enabled = true;
            txtprice.Enabled = true;

            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            txtsearch.Enabled = false;
        }
        void clear()
        {
            txtdesc.Text = "";
            txtdosage.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
        }
        public bool validateEntry(string brand, string name)
        {
            try
            {
                connection.Close();
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from medicine_tbl where brand='" + brand + "' and name='" + name + "'";
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBrand.SelectedIndex == -1|| txtname.Text == "" || txtprice.Text == "" || txtdosage.Text == "" || txtdesc.Text =="")
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (txtprice.Text.Equals("₱0.00")) {
                    MessageBox.Show("Price cannot be zero.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (validateEntry(comboBrand.SelectedItem.ToString(), txtname.Text))
                {
                    MessageBox.Show("Item already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = generateUniqueID();
                if (db.insertMedicine(id, comboBrand.SelectedItem.ToString(), txtname.Text,  txtdosage.Text,txtprice.Text, txtdesc.Text))
                {
                    MessageBox.Show("New item successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMedicine.DataSource = db.getMedicinewithPrice();
                    txtdesc.Enabled = false;
                    txtdosage.Enabled = false;
                    txtname.Enabled = false;
                    txtprice.Enabled = false;
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    dgvMedicine.Enabled = true;
                    txtsearch.Enabled = true;
                    notecontent.Text = dgvMedicine.Rows.Count.ToString();
                    clear();
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        Database data = new Database();
        private void dgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dgvMedicine.Rows[e.RowIndex].Cells[0].Value.ToString();


            MySqlDataReader reader = data.getData("medicine_tbl", updateId);
            reader.Read();

            comboBrand.SelectedItem = reader.GetValue(1).ToString();
            txtname.Text = reader.GetValue(2).ToString();
            txtdosage.Text = reader.GetValue(3).ToString();
            txtprice.Text = reader.GetValue(4).ToString();
            txtdesc.Text = reader.GetValue(5).ToString();

            data.closeConnection();

            /*updateId = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateServiceMed = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[1].Value.ToString();
            updatePrice = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[2].Value.ToString();
            updateType = dataGridViewServiceMedicine.Rows[e.RowIndex].Cells[3].Value.ToString();*/
        }
    

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = data.getmed(updateId);
            reader.Read();

            comboBrand.SelectedItem = reader.GetValue(1).ToString();
            txtname.Text = reader.GetValue(2).ToString();
            txtdosage.Text = reader.GetValue(3).ToString();
            txtprice.Text = reader.GetValue(4).ToString();
            txtdesc.Text = reader.GetValue(5).ToString();

            data.closeConnection();

            dgvMedicine.Enabled = false;
            txtsearch.Enabled = false;
            txtdesc.Enabled = true;
            txtdosage.Enabled = true;
            txtname.Enabled = true;
            txtprice.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateMedicine(updateId, comboBrand.Text, txtname.Text,txtprice.Text, txtdosage.Text, txtdesc.Text))
                {
                    MessageBox.Show("Item successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMedicine.DataSource = db.getMedicinewithPrice();
                    clear();
                    txtdesc.Enabled = false;
                    txtdosage.Enabled = false;
                    txtname.Enabled = false;
                    txtprice.Enabled = false;
                    txtsearch.Enabled = true;
                    dgvMedicine.Enabled = true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadMed();
            clear();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dgvMedicine.Refresh();
            dgvMedicine.Enabled = true;
            txtsearch.Enabled = true;
            txtdesc.Enabled = false;
            txtdosage.Enabled = false;
            txtname.Enabled = false;
            txtprice.Enabled = false;
        }
        public void searchMedicineService(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Item ID', `brand` as 'Medicine Brand', `name` as 'Medicine Name', `dosage` as 'Dosage', `price` as 'Price', `description` as 'Prescription' FROM `medicine_tbl` WHERE CONCAT(id, brand, name, price, dosage, description) LIKE '%" + searchValue+"%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvMedicine.DataSource = table;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchMedicineService(txtsearch.Text);
            btnEdit.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dgvMedicine.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
           
        }

        private void dgvMedicine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void ManageAddEditDeleteMedicinefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        string input = "";
        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;


            if (!(char.IsNumber(e.KeyChar) || ((e.KeyChar == '.')) || e.KeyChar == (char)Keys.Back))
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Back && (input.Length != 0))
            {
                input = input.Remove(input.Length - 1);
            }
            else if (e.KeyChar == (char)Keys.Back && (input.Length == 0))
            {

                return;
            }
            else if (((e.KeyChar == '.')) && input.Length == 0)
            {
                input = "0.";
            }
            else
            {
                input += e.KeyChar;
            }
            if (input.Length == 0)
            {
                txtprice.Text = (0).ToString("C");
            }
            else
                txtprice.Text = Double.Parse(input).ToString("C");
        }
        MySqlConnection con = new Database().getConnection();
        string generateUniqueID()
        {
            string ret = "";
            Random rand = new Random();

            connection.Close();
            connection.Open();

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            while (true)
            {
                ret = "2";
                for (int i = 0; i < 4; i++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from medicine_tbl where  id ='" + ret + "'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                MessageBox.Show(ret + "");
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            loadMed();
            txtdesc.Enabled = false;
            txtdosage.Enabled = false;
            txtname.Enabled = false;
            txtprice.Enabled = false;
            clear();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            notecontent.Text = dgvMedicine.Rows.Count.ToString();
            searchMedicineService("");
        }
    }
}
