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
    public partial class ManageAddEditPediatricPatient : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataReader dataReader;
        public ManageAddEditPediatricPatient()
        {
            InitializeComponent();
        }
        public void searchChildren(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Patient ID', `firstname` as 'First name', `middlename` as 'Middle name', `lastname` as 'Last name', `age` as 'Age', `sex` as 'Sex' FROM `childrentbl` WHERE CONCAT (firstname,middlename,lastname,age,sex) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewPediatric.DataSource = table;
        }
        void enableitems()
        {
            txtfirst.Enabled = true;
            txtmiddle.Enabled = true;
            txtlast.Enabled = true;
            txtdateofbirth.Enabled = true;
            //txtage.Enabled = true;
            rdFemale.Enabled = true;
            rdMale.Enabled = true;
            comboreligion.Enabled = true;
            txtmother.Enabled = true;
            txtfather.Enabled = true;
            comboProvince.Enabled = true;
            comboCityMun.Enabled = true;
            comboBarangay.Enabled = true;
            txtStreet.Enabled = true;
            txthouseno.Enabled = true;
        }
        void disableitems()
        {
            txtfirst.Enabled = false;
            txtmiddle.Enabled = false;
            txtlast.Enabled = false;
            txtdateofbirth.Enabled = false;
            txtage.Enabled = false;
            rdFemale.Enabled = false;
            rdMale.Enabled = false;
            comboreligion.Enabled = false;
            txtmother.Enabled = false;
            txtfather.Enabled = false;
            comboProvince.Enabled = false;
            comboCityMun.Enabled = false;
            comboBarangay.Enabled = false;
            txtStreet.Enabled = false;
            txthouseno.Enabled = false;
        }
        private void ManageAddEditPediatricPatient_Load(object sender, EventArgs e)
        {
            
            searchChildren("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            disableitems();
            txtage.Text = "";
            txtdateofbirth.MaxDate = DateTime.Now.AddYears(-0);//Minimum age
            txtdateofbirth.MinDate = DateTime.Now.AddYears(-12);//Maximum age
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            bindreligion();
            bindprovince();
            notecontent.Text = dataGridViewPediatric.Rows.Count.ToString();
        }
        public void bindprovince()
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(province) from philippinelocaltbl", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboProvince.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }
        private void comboprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Close();
            connection.Open();
            cmd = new MySqlCommand("select distinct(citymunicipality) from philippinelocaltbl where province = '" + comboProvince.Text + "'", connection);
            dataReader = cmd.ExecuteReader();
            comboCityMun.Items.Clear();
            while (dataReader.Read())
            {
                comboCityMun.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        private void combocitymun_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(barangay) from philippinelocaltbl where citymunicipality = '" + comboCityMun.Text + "'", connection);
            dataReader = cmd.ExecuteReader();
            comboBarangay.Items.Clear();
            while (dataReader.Read())
            {
                comboBarangay.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchChildren(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewPediatric.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }

        public void bindreligion()
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(religion) from religiontbl", connection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboreligion.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            connection.Close();
        }

        public bool validateEntry(string firstname, string middlename, string lastname)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from childrentbl where firstname='" + firstname + "' and middlename='" + middlename + "' and lastname='" + lastname + "'";
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
            txtfirst.Text = "";
            txtmiddle.Text = "";
            txtlast.Text = "";
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            txtage.Text = "";
            rdMale.Checked = false;
            rdFemale.Checked = false;
            comboreligion.SelectedIndex = -1;
            comboProvince.SelectedIndex = -1;
            comboCityMun.SelectedIndex = -1;
            comboBarangay.SelectedIndex = -1;
            txtStreet.Text = "";
            txthouseno.Text = "";
            txtmother.Text = "";
            txtfather.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewPediatric.Enabled = false;
            enableitems();
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || txtage.Text == "" || !(rdMale.Checked || rdFemale.Checked) || comboreligion.Text == "" || txtmother.Text == "" || comboProvince.Text == "" || comboCityMun.Text == "" || comboCityMun.Text == "")
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (validateEntry(txtfirst.Text, txtmiddle.Text, txtlast.Text))
                {
                    MessageBox.Show("Child with the same name already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = generateUniqueID();
                if (db.insertChildren(id,txtfirst.Text, txtmiddle.Text, txtlast.Text, txtdateofbirth.Text, txtage.Text, rdMale.Checked ? "Male" : "Female", comboreligion.Text, txtmother.Text, txtfather.Text, addressId.ToString(), txtStreet.Text, txthouseno.Text))
                {
                    MessageBox.Show("Child Information successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAdd.Enabled = true;
                    disableitems();
                    clear();
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    dataGridViewPediatric.Enabled = true;
                    txtsearch.Enabled = true;
                    notecontent.Text = dataGridViewPediatric.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }
        string updateId;
        string v1, v2, v3, v4, v5, v6, v7, v8, v9;
        private void btnEdit_Click(object sender, EventArgs e)
        {

            MySqlDataReader reader = data.getPediatricInfo(updateId);
            reader.Read();

            v1 = reader.GetValue(1).ToString();
            v2 = reader.GetValue(2).ToString();
            v3 = reader.GetValue(3).ToString();
            v4 = reader.GetValue(4).ToString();
            v5 = reader.GetValue(5).ToString();
            v6 = reader.GetValue(6).ToString();
            v7 = reader.GetValue(7).ToString();
            v8 = reader.GetValue(8).ToString();
            v9 = reader.GetValue(9).ToString();
            //MessageBox.Show(reader.GetValue(14).ToString());
            comboProvince.SelectedItem = reader.GetValue(14).ToString();
            comboCityMun.SelectedItem = reader.GetValue(15).ToString();
            comboBarangay.SelectedItem = reader.GetValue(16).ToString();
            txtStreet.Text = reader.GetValue(11).ToString();
            txthouseno.Text = reader.GetValue(12).ToString();

            data.closeConnection();


            dataGridViewPediatric.Enabled = false;
            txtsearch.Enabled = false;
            enableitems();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            lbladdedit.Text = "Update Child Information";
            txtfirst.Text = v1;
            txtmiddle.Text = v2;
            txtlast.Text = v3;
            txtdateofbirth.Value = DateTime.Parse(v4);
            txtage.Text = v5;
            if (v6.ToLower().Equals("male"))
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
            comboreligion.Text = v7;
            txtmother.Text = v8;
            txtfather.Text = v9;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(v1.ToLower().Equals(txtfirst.Text.ToLower()) && v2.ToLower().Equals(txtmiddle.Text.ToLower()) && v3.ToLower().Equals(txtlast.Text.ToLower())))
            {
                connection.Open();
                cmd = new MySqlCommand("SELECT * FROM childrentbl WHERE firstname = '" + txtfirst.Text.ToLower() + "' AND middlename = '" + txtmiddle.Text.ToLower() + "' AND lastname = '" + txtlast.Text.ToLower() + "'", connection);
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Close();
                    connection.Close();
                    MessageBox.Show("Cannot update information already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                dataReader.Close();
                connection.Close();
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (!(txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || comboreligion.Text == "" || comboProvince.Text == "" || comboCityMun.Text == "" || comboBarangay.Text == ""))
                {
                    if (db.updateChildren(updateId, txtfirst.Text, txtmiddle.Text, txtlast.Text, txtdateofbirth.Text, txtage.Text, rdMale.Checked ? "Male" : "Female", comboreligion.SelectedItem.ToString(), txtmother.Text, txtfather.Text, addressId.ToString(), txtStreet.Text, txthouseno.Text))
                    {
                        MessageBox.Show("Child Information successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        lbladdedit.Text = "Register Child";
                        disableitems();
                        txtsearch.Enabled = true;
                        dataGridViewPediatric.Enabled = true;
                        btnCancel.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("An error occured in save");

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        Database data = new Database();
        private void dataGridViewPediatric_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewPediatric.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void ManageAddEditPediatricPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            searchChildren("");
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            disableitems();
            txtage.Text = "";
            txtdateofbirth.MaxDate = DateTime.Now.AddYears(-0);//Minimum age
            txtdateofbirth.MinDate = DateTime.Now.AddYears(-12);//Maximum age
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            
        }
        int addressId;
        private void comboBarangay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBarangay.SelectedIndex == -1)
                return;
            connection.Open();
            cmd = new MySqlCommand("select addressId from philippinelocaltbl WHERE province ='" + comboProvince.SelectedItem.ToString() + "' AND citymunicipality ='" + comboCityMun.SelectedItem.ToString() + "' AND barangay ='" + comboBarangay.SelectedItem.ToString() + "'", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                addressId = dataReader.GetInt32(0);
            }
            //MessageBox.Show("" + addressId);
            dataReader.Close();
            connection.Close();
        }

        private void dataGridViewPediatric_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridViewPediatric_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            notecontent.Text = "Total Number of Patient (Pediatric) List :  " + dataGridViewPediatric.Rows.Count.ToString() + ".";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lbladdedit.Text = "Register Patient";
            clear();
            disableitems();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewPediatric.Refresh();
            dataGridViewPediatric.Enabled = true;
            txtsearch.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteChildren(updateId))
                {
                    MessageBox.Show("Child Information with " + updateId + " is successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsearch.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    notecontent.Text = dataGridViewPediatric.Rows.Count.ToString();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void txtdateofbirth_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = txtdateofbirth.Value;
            DateTime to = DateTime.Now;
            TimeSpan span = to - from;
            double days = span.TotalDays;
            txtage.Text = (days / 365).ToString("0");
        }

        private void txtfirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtfirst.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtfirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtmiddle.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar != Convert.ToChar(Keys.Back) || e.KeyChar != Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }
        }

        private void txthouseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar != Convert.ToChar(Keys.Back) || e.KeyChar != Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }
        }
        MySqlConnection con = new Database().getConnection();
        string generateUniqueID()
        {
            string ret = "";
            int year = DateTime.Now.Year;
            Random rand = new Random();

            connection.Close();
            connection.Open();




            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            while (true)
            {
                ret = year + "1600";
                for (int i = 0; i < 1; i++)
                {
                    ret += rand.Next(9);
                }
                cmd.CommandText = "select * from childrentbl where  id ='" + ret + "'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    //MessageBox.Show(ret + "");
                    return ret;
                }
            }

        }
    }
}
