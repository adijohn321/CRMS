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
    public partial class MAnagenondrugs : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlConnection con = new Database().getConnection();
        public string sql;
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        public MAnagenondrugs()
        {
            InitializeComponent();
            
        }
        public void loadNonM() {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from brand_tbl WHERE type = 'Non-Drugs'", conn);
            dr = cmd.ExecuteReader();
            txtbrand.Items.Clear();

            while (dr.Read())
            {
                txtbrand.Items.Add(dr.GetString("name").ToString());
            }


            dr.Close();
            conn.Close();
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            loadNonM();
            dgvNondrugs.Enabled = false;
            txtbrand.Enabled = true;
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

        private void MAnagenondrugs_Load(object sender, EventArgs e)
        {

            txtbrand.Enabled = false;
            txtdesc.Enabled = false;
            txtdosage.Enabled = false;
            txtname.Enabled = false;
            txtprice.Enabled = false;
            loadNonM();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //.Text = dgvNondrugs.Rows.Count.ToString();
            notecontent.Text = dgvNondrugs.Rows.Count.ToString();
            search("");
        }
        void clear()
        {
            txtbrand.Text = "";
            txtdesc.Text = "";
            txtdosage.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
        }
        public bool validateEntry(string brand, string name, string usage)
        {
            
            try
            {
                connection.Close();
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from nondrugs_tbl where brand='" + brand + "' and name='" + name + "' and usages='" + usage + "'";
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbrand.Text == "" || txtname.Text == "" || txtprice.Text == "" || txtdosage.Text == "" || txtdesc.Text == "")
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (txtprice.Text.Equals("₱0.00"))
                {
                    MessageBox.Show("Price cannot be zero.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (validateEntry(txtbrand.Text, txtname.Text, txtdosage.Text))
                {
                    MessageBox.Show("Item already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtbrand.SelectedIndex = -1;
                    txtname.Text = "";
                    txtdosage.Text = "";
                    txtprice.Text = "";
                    txtdesc.Text = "";
                    return;
                }
                string id = generateUniqueID();
                if (db.insertItems(id, txtbrand.Text, txtname.Text,txtdosage.Text, txtprice.Text, txtdesc.Text))
                {
                    MessageBox.Show("New item successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNondrugs.DataSource = db.getNondrugswithPrice();
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    dgvNondrugs.Enabled = true;
                    txtsearch.Enabled = true;
                    txtbrand.SelectedIndex = -1;
                    txtbrand.Enabled = false;
                    txtname.Enabled = false;
                    txtdosage.Enabled = false;
                    txtprice.Enabled = false;
                    txtdesc.Enabled = false;
                    clear();
                    notecontent.Text = dgvNondrugs.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        string updateId;
        MedicineDB data = new MedicineDB();
        

        private void dgvNondrugs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dgvNondrugs.Rows[e.RowIndex].Cells[0].Value.ToString();


            MySqlDataReader reader = data.getData("nondrugs_tbl", updateId);
            reader.Read();

            txtbrand.SelectedItem = reader.GetValue(1).ToString();
            txtname.Text = reader.GetValue(2).ToString();
            txtdosage.Text = reader.GetValue(3).ToString();
            txtprice.Text = reader.GetValue(4).ToString();
            txtdesc.Text = reader.GetValue(5).ToString();

            data.closeConnection();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = data.getmed(updateId);
            while (reader.Read())
            {

                txtbrand.SelectedItem = reader.GetValue(1).ToString();
                txtname.Text = reader.GetValue(2).ToString();
                txtprice.Text = reader.GetValue(3).ToString();
                txtdosage.Text = reader.GetValue(4).ToString();
                txtdesc.Text = reader.GetValue(5).ToString();
            }

            data.closeConnection();

            dgvNondrugs.Enabled = false;
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
                if (txtprice.Text.Equals("₱0.00"))
                {
                    MessageBox.Show("Price cannot be zero.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (db.updateNondrugs(updateId, txtbrand.SelectedIndex.ToString(), txtname.Text, txtprice.Text, txtdosage.Text, txtdesc.Text))
                {
                    MessageBox.Show("Item successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNondrugs.DataSource = db.getNondrugswithPrice();
                    clear(); ;
                    txtbrand.SelectedIndex = -1;
                    txtsearch.Enabled = true;
                    dgvNondrugs.Enabled = true;
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
                ret = "1";
                for (int i = 0; i < 5; i++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from nondrugs_tbl where  id ='" + ret + "'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }

        }
        public void search(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Item ID', `brand` as  'Brand', `name` as 'Name', `usages` as 'Quantity', `price` as 'Price', `description` as 'Description' FROM `nondrugs_tbl` WHERE CONCAT(id, brand, name) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvNondrugs.DataSource = table;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            search(txtsearch.Text);
            btnEdit.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dgvNondrugs.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }

        }

        private void dgvNondrugs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            loadNonM();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dgvNondrugs.Refresh();
            dgvNondrugs.Enabled = true;
            txtsearch.Enabled = true;
            txtdesc.Enabled = false;
            txtdosage.Enabled = false;
            txtname.Enabled = false;
            txtprice.Enabled = false;
            txtbrand.SelectedIndex = -1;
        }

        private void MAnagenondrugs_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            txtbrand.Enabled = false;
            txtdesc.Enabled = false;
            txtdosage.Enabled = false;
            txtname.Enabled = false;
            txtprice.Enabled = false;
            loadNonM();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            notecontent.Text = dgvNondrugs.Rows.Count.ToString();
            search("");
        }
    }
}
