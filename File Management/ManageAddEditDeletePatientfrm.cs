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
using System.Text.RegularExpressions;

namespace CAPSTONEPROJ.File_Management
{
    public partial class ManageAddEditDeletePatientfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        MySqlDataReader dataReader;
        MySqlConnection con = new Database().getConnection();
        string id;
        public ManageAddEditDeletePatientfrm()
        {
            InitializeComponent();
            dataGridViewPatient.DataSource = db.getPatient();
        }
        public void searchPatient(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Patient ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM patienttbl WHERE CONCAT (firstname, middlename, lastname) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewPatient.DataSource = table;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchPatient(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewPatient.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        void enableitems()
        {

            txtfirst.Enabled = true;
            txtmiddle.Enabled = true;
            txtlast.Enabled = true;
            txtdateofbirth.Enabled = true;
            txtage.Enabled = true;
            txtcontactnum.Enabled = true;
            comboreligion.Enabled = true;
            comboprovince.Enabled = true;
            combocitymun.Enabled = true;
            combobarangay.Enabled = true;
            txtstreet.Enabled = true;
            txthouseno.Enabled = true;
            checkmarried.Enabled = true;


        }
        void disableitem()
        {

            txtfirst.Enabled = false;
            txtmiddle.Enabled = false;
            txtlast.Enabled = false;
            txtdateofbirth.Enabled = false;
            txtage.Enabled = false;
            txtcontactnum.Enabled = false;
            comboreligion.Enabled = false;
            comboprovince.Enabled = false;
            combocitymun.Enabled = false;
            combobarangay.Enabled = false;
            txtstreet.Enabled = false;
            txthouseno.Enabled = false;
            txthfirst.Enabled = false;
            txthmiddle.Enabled = false;
            txthlast.Enabled = false;
            txthdateofbirth.Enabled = false;
            txthreligion.Enabled = false;
            checkmarried.Enabled = false;


        }
      
        private void ManageAddEditDeletePatientfrm_Load(object sender, EventArgs e)
        {
            searchPatient("");
            bindreligion();
            bindprovince();
            txtdateofbirth.MaxDate = DateTime.Now.AddYears(-12);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            disableitem();
            txtage.Text = "";
            txtcontactnum.Text = "+63";
            txtage.Text = "";
            checkmarried.Text = "";
            lblmarried.Text = "Married";
            notecontent.Text = dataGridViewPatient.Rows.Count.ToString();
        }
        public bool validateEntry(string firstname, string middlename, string lastname)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from patienttbl where firstname='" + firstname + "' and middlename='" + middlename + "' and lastname='" + lastname + "'";
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
        public void bindreligion()
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(religion) from religiontbl", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboreligion.Items.Add(dataReader.GetValue(0).ToString());
                txthreligion.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        public void bindprovince()
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(province) from philippinelocaltbl", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboprovince.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }
        private void comboprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Close();
            connection.Open();
            cmd = new MySqlCommand("select distinct(citymunicipality) from philippinelocaltbl where province = '" + comboprovince.Text + "'", connection);
            dataReader = cmd.ExecuteReader();
            combocitymun.Items.Clear();
            while (dataReader.Read())
            {
                combocitymun.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        private void combocitymun_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(barangay) from philippinelocaltbl where citymunicipality = '" + combocitymun.Text + "'", connection);
            dataReader = cmd.ExecuteReader();
            combobarangay.Items.Clear();
            while (dataReader.Read())
            {
                combobarangay.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        private void txtdateofbirth_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = txtdateofbirth.Value;
            DateTime to = DateTime.Now;
            TimeSpan span = to - from;
            double days = span.TotalDays;
            txtage.Text = (days / 365).ToString("0");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            lblmarried.Text = "";
            checkmarried.Text = "Married";
            dataGridViewPatient.Enabled = false;
            enableitems();
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;


        }
        Transaction.TransactionOutPatientfrm outPatientfrm = new Transaction.TransactionOutPatientfrm();
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!(txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || txtage.Text == "" || comboreligion.Text == "" || txtcontactnum.Text == "" || comboprovince.Text == "" || combocitymun.Text == "" || combobarangay.Text == ""))
            {
                if (checkmarried.Checked && (txthfirst.Text == "" || txthlast.Text == "" || txthdateofbirth.Text == "" || txthreligion.Text == ""))
                {

                    MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (validateEntry(txtfirst.Text, txtmiddle.Text, txtlast.Text))
                {
                    MessageBox.Show("Patient Information already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string id = generateUniqueID();
                if (db.insertPatient(id, txtfirst.Text, txtmiddle.Text, txtlast.Text, txtdateofbirth.Text, comboreligion.SelectedItem.ToString(), txtcontactnum.Text, addressId.ToString(), txthouseno.Text, txtstreet.Text, checkmarried.Checked ? "1" : "0", txthfirst.Text, txthmiddle.Text, txthlast.Text, txthdateofbirth.Text, txthreligion.SelectedItem.ToString()))
                {
                    MessageBox.Show("Patient Information Successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewPatient.DataSource = db.getPatient();
                    btnAdd.Enabled = true;
                    txtcontactnum.Text = "+63";
                    txtage.Text = "";
                    disableitem();
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtsearch.Enabled = true;
                    dataGridViewPatient.Enabled = true;
                    clear();
                    checkmarried.Checked = false;
                    checkmarried.Text = "";
                    lblmarried.Text = "Married";
                    notecontent.Text = dataGridViewPatient.Rows.Count.ToString();
                    outPatientfrm.dataGridViewPatient.Refresh();
                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }

            }
            else
            {

                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        string updateId;
        string v1, v2, v3;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            checkmarried.Text = "Married";
            lblmarried.Text = "";
            MySqlDataReader reader = data.getPateintInfo(updateId);

            if (reader.Read())
            {

                v1 = reader.GetValue(1).ToString();
                v2 = reader.GetValue(2).ToString();
                v3 = reader.GetValue(3).ToString();
                txtfirst.Text = reader.GetValue(1).ToString();
                txtmiddle.Text = reader.GetValue(2).ToString();
                txtlast.Text = reader.GetValue(3).ToString();
                txtdateofbirth.Value = DateTime.Parse(reader.GetValue(4).ToString());
                comboreligion.SelectedItem = reader.GetValue(5).ToString();
                txtcontactnum.Text = "+" + reader.GetValue(6).ToString();

                //address
                comboprovince.SelectedItem = reader.GetValue(18).ToString();
                combocitymun.SelectedItem = reader.GetValue(19).ToString();
                combobarangay.SelectedItem = reader.GetValue(20).ToString();


                txtstreet.Text = reader.GetValue(8).ToString();
                txthouseno.Text = reader.GetValue(9).ToString();
                if (reader.GetValue(10).ToString() == "1")
                {
                    checkmarried.Checked = true;
                    txthfirst.Text = reader.GetValue(11).ToString();
                    txthmiddle.Text = reader.GetValue(12).ToString();
                    txthlast.Text = reader.GetValue(13).ToString();
                    txthdateofbirth.Value = DateTime.Parse(reader.GetValue(14).ToString());
                    txthreligion.SelectedItem = reader.GetValue(15).ToString();
                }

            }

            data.closeConnection();
            dataGridViewPatient.Enabled = false;
            txtsearch.Enabled = false;
            enableitems();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            lbladdedit.Text = "Update Patient Information";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!(v1.ToLower().Equals(txtfirst.Text.ToLower()) && v2.ToLower().Equals(txtmiddle.Text.ToLower()) && v3.ToLower().Equals(txtlast.Text.ToLower())))
            {
                connection.Open();
                cmd = new MySqlCommand("SELECT * FROM patienttbl WHERE firstname = '" + txtfirst.Text.ToLower() + "' AND middlename = '" + txtmiddle.Text.ToLower() + "' AND lastname = '" + txtlast.Text.ToLower() + "'", connection);
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to change this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                if (!(txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || comboreligion.Text == "" || txtcontactnum.Text == "" || comboprovince.Text == "" || combocitymun.Text == "" || combobarangay.Text == ""))
                {
                    if (checkmarried.Checked && (txthfirst.Text == "" || txthlast.Text == "" || txthdateofbirth.Text == "" || txthreligion.Text == ""))
                    {
                        MessageBox.Show("Please fill all required fields.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (db.updatePateint(updateId, txtfirst.Text, txtmiddle.Text, txtlast.Text, txtdateofbirth.Text, comboreligion.SelectedItem.ToString(), txtcontactnum.Text, addressId.ToString(), txthouseno.Text, txtstreet.Text, ((int)checkmarried.CheckState).ToString(), txthfirst.Text, txthmiddle.Text, txthlast.Text, txthdateofbirth.Text, txthreligion.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Patient Information successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewPatient.DataSource = db.getPatient();
                        dataGridViewPatient.Enabled = true;
                        disableitem();
                        txtage.Text = "";
                        btnSave.Enabled = false;
                        btnCancel.Enabled = true;
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = false;
                        btnEdit.Enabled = false;
                        btnUpdate.Enabled = false;
                        lbladdedit.Text = "Register Patient";
                        clear();
                        txtsearch.Enabled = true;
                        dataGridViewPatient.Enabled = true;
                        checkmarried.Checked = false;
                        checkmarried.Text = "";
                        lblmarried.Text = "Married";
                        txtcontactnum.Text = "+63";


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

        private void btnCancel_Click(object sender, EventArgs e)
        {

            checkmarried.Checked = false;
            lbladdedit.Text = "Register Patient";
            clear();
            disableitem();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewPatient.Refresh();
            dataGridViewPatient.Enabled = true;
            txtsearch.Enabled = true;
            txtage.Text = "";
            txtcontactnum.Text = "+63";
            checkmarried.Text = "";
            lblmarried.Text = "Married";

        }
        int addressId;
        private void combobarangay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobarangay.SelectedIndex == -1)
                return;
            connection.Open();
            cmd = new MySqlCommand("select addressId from philippinelocaltbl WHERE province ='" + comboprovince.SelectedItem.ToString() + "' AND citymunicipality ='" + combocitymun.SelectedItem.ToString() + "' AND barangay ='" + combobarangay.SelectedItem.ToString() + "'", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                addressId = dataReader.GetInt32(0);
            }
            //MessageBox.Show("" + addressId);
            dataReader.Close();
            connection.Close();
        }


        private void dataGridViewPatient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        private void checkmarried_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkmarried.Checked)
            {
                groupBox3.Visible = true;
                txthfirst.Enabled = true;
                txthmiddle.Enabled = true;
                txthlast.Enabled = true;
                txthdateofbirth.Enabled = true;
                txthreligion.Enabled = true;
            }
            else
            {
                groupBox3.Visible = false;
                txthfirst.Enabled = false;
                txthmiddle.Enabled = false;
                txthlast.Enabled = false;
                txthdateofbirth.Enabled = false;
                txthreligion.Enabled = false;
            }
            
        }

        private void txthage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtage_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageAddEditDeletePatientfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deletePatient(updateId))
                {
                    MessageBox.Show("Successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewPatient.DataSource = db.getPatient();
                    dataGridViewPatient.Enabled = true;
                    txtsearch.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    checkmarried.Text = "";
                    txtcontactnum.Text = "+63";
                    lblmarried.Text = "Married";
                    notecontent.Text = dataGridViewPatient.Rows.Count.ToString();

                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        void clear()
        {
            txtfirst.Text = "";
            txtmiddle.Text = "";
            txtlast.Text = "";
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            txtage.Text = "";
            comboreligion.SelectedIndex = -1;
            txtcontactnum.Text = "+63";
            comboprovince.SelectedIndex = -1;
            combocitymun.SelectedIndex = -1;
            combobarangay.SelectedIndex = -1;
            txtstreet.Text = "";
            txthouseno.Text = "";
            txthfirst.Text = "";
            txthmiddle.Text = "";
            txthlast.Text = "";
            txthdateofbirth.Value = txtdateofbirth.MaxDate;
            txthreligion.SelectedIndex = -1;
            
        }
        Database data = new Database();
        private void dataGridViewPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewPatient.Rows[e.RowIndex].Cells[0].Value.ToString();

        }


        private void txtfirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtfirst.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtmiddle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtmiddle.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtlast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtlast.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtstreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtstreet.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtcontactnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthouseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtfirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtfirst.SelectionStart == 0)
            {
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && txtcontactnum.Text.Length == 3)
                {
                    e.SuppressKeyPress = true;
                }

                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        ///SET ID
        ///
        string generateUniqueID()
        {
            string ret = ""; 
            DateTime dateTime = DateTime.Now;
            Random rand = new Random();

            connection.Close();
            connection.Open();




            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            while (true)
            {
                ret += dateTime.Year + "00000";
                for (int i = 0; i < 5; i++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from patienttbl where  id ='" + ret + "'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    //MessageBox.Show(ret+"");
                    return ret;
                }
            }

        }
    }
}
