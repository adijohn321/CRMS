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
    public partial class ManageAddEditDeleteEmployeefrm : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        MySqlDataReader dataReader;
        string updateId;
        string EmployeeId;
        string id;

        public ManageAddEditDeleteEmployeefrm()
        {
            InitializeComponent();
            dataGridViewEmployee.DataSource = db.getEmployee();
        }
        public void searchEmployee(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Employee ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name', `title` as 'Title' FROM employeetbl WHERE CONCAT (firstname, middlename, lastname, title) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewEmployee.DataSource = table;
        }
        void enableitems()
        {
            txtfirst.Enabled = true;
            txtmiddle.Enabled = true;
            txtlast.Enabled = true;
            txtdateofbirth.Enabled = true;
            txtage.Enabled = false;
            combotitle.Enabled = true;
            //txtlicense.Enabled = true;
            comboreligion.Enabled = true;
            txtlicense.Enabled = true;
            txtcontactnum.Enabled = true;
            comboprovince.Enabled = true;
            combocitymun.Enabled = true;
            combobarangay.Enabled = true;
            txtstreet.Enabled = true;
            txthouseno.Enabled = true;
        }
        void disableitems()
        {
            txtfirst.Enabled = false;
            txtmiddle.Enabled = false;
            txtlast.Enabled = false;
            txtdateofbirth.Enabled = false;
            txtage.Enabled = false;
            combotitle.Enabled = false;
            txtlicense.Enabled = false;
            comboreligion.Enabled = false;
            txtlicense.Enabled = false;
            comboprovince.Enabled = false;
            combocitymun.Enabled = false;
            combobarangay.Enabled = false;
            txtstreet.Enabled = false;
            txthouseno.Enabled = false;
        }
        private void ManageAddEditDeleteEmployeefrm_Load(object sender, EventArgs e)
        {
            txtdateofbirth.MaxDate = DateTime.Now.AddYears(-18);//Minimum age
            txtdateofbirth.MinDate = DateTime.Now.AddYears(-65);//Maximum age
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            txtage.Text = "";
            searchEmployee("");
            bindreligion();
            bindprovince();
            bindtitle();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            txtlicense.Enabled = false;
            disableitems();
            txtcontactnum.Text = "+63";
            notecontent.Text = dataGridViewEmployee.Rows.Count.ToString();

        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchEmployee(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
                searchResult.Text = dataGridViewEmployee.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        public bool validateEntry(string firstname, string middlename, string lastname)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employeetbl where firstname='" + firstname + "' and middlename='" + middlename + "' and lastname='" + lastname + "'";
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
            dataGridViewEmployee.Enabled = false;
            enableitems();
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtlicense.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (!(txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || txtage.Text == "" || comboreligion.Text == "" || txtcontactnum.Text == "" || comboprovince.Text == "" || combocitymun.Text == "" || combobarangay.Text == ""))
            {
                if (combotitle.SelectedItem.ToString() != "Intern" && txtlicense.Text == "") {
                    MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (validateEntry(txtfirst.Text, txtmiddle.Text, txtlast.Text))
                {
                    MessageBox.Show("Employee with the same name already exists.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string id = generateUniqueID();
                if (db.insertEmployee(id,txtfirst.Text, txtmiddle.Text, txtlast.Text, txtdateofbirth.Text, txtage.Text, combotitle.Text, txtlicense.Text, comboreligion.Text, txtcontactnum.Text, comboprovince.Text, combocitymun.Text, combobarangay.Text, txthouseno.Text, txtstreet.Text))
                {
                    MessageBox.Show("Employee Information successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEmployee.DataSource = db.getEmployee();
                    btnAdd.Enabled = true;
                    disableitems();
                    asteriskLicense.Visible = false;
                    txtlicense.Enabled = false;
                    clear();
                    dataGridViewEmployee.Enabled = true;
                    txtsearch.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtcontactnum.Text = "+63";
                    notecontent.Text = dataGridViewEmployee.Rows.Count.ToString();
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

        int selectedRowIndex;
        string v1, v2, v3;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                return;
            }
            dataGridViewEmployee.Enabled = false;
            txtsearch.Enabled = false;
            enableitems();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            lbladdedit.Text = "Update Employee";
            DataGridViewRow dtr = new DataGridViewRow();
            dtr = dataGridViewEmployee.Rows[selectedRowIndex];
            id = dataGridViewEmployee.Rows[selectedRowIndex].Cells[0].Value.ToString();
            MySqlDataReader dr = db.editEmployee(dataGridViewEmployee.Rows[selectedRowIndex].Cells[0].Value.ToString());
            if (dr.Read())
            {
                v1= dr.GetValue(1).ToString();
                v2 = dr.GetValue(2).ToString();
                v3 = dr.GetValue(3).ToString();
                txtfirst.Text = dr.GetValue(1).ToString();
                txtmiddle.Text = dr.GetValue(2).ToString();
                txtlast.Text = dr.GetValue(3).ToString();
                txtdateofbirth.Value = DateTime.Parse(dr.GetValue(4).ToString());
                txtage.Text = dr.GetValue(5).ToString();
                combotitle.Text = dr.GetValue(6).ToString();
                txtlicense.Text = dr.GetValue(7).ToString();
                comboreligion.Text = dr.GetValue(8).ToString();
                txtcontactnum.Text = dr.GetValue(9).ToString();
                comboprovince.Text = dr.GetValue(10).ToString();
                combocitymun.Text = dr.GetValue(11).ToString();
                combobarangay.Text = dr.GetValue(12).ToString();
                txthouseno.Text = dr.GetValue(13).ToString();
                txtstreet.Text = dr.GetValue(14).ToString();
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnUpdate.Enabled = true;
            }
            db.closeConnection();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(v1.ToLower().Equals(txtfirst.Text.ToLower()) && v2.ToLower().Equals(txtmiddle.Text.ToLower()) && v3.ToLower().Equals(txtlast.Text.ToLower())))
            {
                connection.Open();
                cmd = new MySqlCommand("SELECT * FROM employeetbl WHERE firstname = '" + txtfirst.Text.ToLower() + "' AND middlename = '" + txtmiddle.Text.ToLower() + "' AND lastname = '" + txtlast.Text.ToLower() + "'", connection);
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
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want to change this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.updateEmployee(updateId, txtfirst.Text, txtmiddle.Text, txtlast.Text, txtdateofbirth.Text, txtage.Text, combotitle.Text, txtlicense.Text, comboreligion.Text, txtcontactnum.Text, comboprovince.Text, combocitymun.Text, combobarangay.Text, txthouseno.Text, txtstreet.Text))
                {
                    MessageBox.Show("Successfully Updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEmployee.DataSource = db.getEmployee();
                    disableitems();
                    btnSave.Enabled = false;
                    btnCancel.Enabled = true;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnUpdate.Enabled = false;
                    txtcontactnum.Text = "+63";
                    lbladdedit.Text = "Register Employee";
                    dataGridViewEmployee.Enabled = true;
                    clear();
                }
                else
                {
                    MessageBox.Show("An error occured in save");

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lbladdedit.Text = "Register Employee";
            clear();
            disableitems();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewEmployee.Refresh();
            dataGridViewEmployee.Enabled = true;
            txtsearch.Enabled = true;
            txtcontactnum.Text = "+63";
        }

        void clear()
        {
            txtfirst.Text = "";
            txtmiddle.Text = "";
            txtlast.Text = "";
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            txtage.Text = "";
            combotitle.SelectedIndex = -1;
            txtlicense.Text = "";
            comboreligion.SelectedIndex = -1;
            txtcontactnum.Text = "+63";
            comboprovince.SelectedIndex = -1;
            combocitymun.SelectedIndex = -1;
            combobarangay.SelectedIndex = -1;
            txtstreet.Text = "";
            txthouseno.Text = "";
        }

        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            //btnAdd.Enabled = true;
            updateId = dataGridViewEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
            EmployeeId = dataGridViewEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            selectedRowIndex = e.RowIndex;


        }
        public void bindtitle()
        {
            combotitle.Items.Clear();
            connection.Open();
            cmd = new MySqlCommand("select distinct(employeetitle) from employeetitletbl", connection);
            dataReader = cmd.ExecuteReader();
            combotitle.Items.Add("Add");
            while (dataReader.Read())
            {
                combotitle.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }
        public void bindreligion()
        {
            comboreligion.Items.Clear();
            connection.Open();
            cmd = new MySqlCommand("select distinct(religion) from religiontbl", connection);
            dataReader = cmd.ExecuteReader();
            comboreligion.Items.Add("Add");
            while (dataReader.Read())
            {
                comboreligion.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        public void bindprovince()
        {
            comboprovince.Items.Clear();
            connection.Open();
            cmd = new MySqlCommand("select distinct(province) from philippinelocaltbl", connection);
            dataReader = cmd.ExecuteReader();
            comboprovince.Items.Add("Add");
            while (dataReader.Read())
            {
                comboprovince.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        private void comboprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboprovince.SelectedIndex == 0)
            {
                new ManageAddEditDeleteProvincefrm().Show();
                comboprovince.SelectedIndex = -1;
                return;
            }
            combocitymun.Items.Clear();
            connection.Close();
            connection.Open();
            cmd = new MySqlCommand("select distinct(citymunicipality) from philippinelocaltbl where province = '" + comboprovince.Text + "'", connection);
            dataReader = cmd.ExecuteReader();
            combocitymun.Items.Add("Add");
            while (dataReader.Read())
            {
                combocitymun.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }

        private void combocitymun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combocitymun.SelectedIndex == 0)
            {
                new ManageAddEditDeleteCityMunicipalityfrm(comboprovince.SelectedItem.ToString()).Show();
                combocitymun.SelectedIndex = -1;
                return;
            }
            combobarangay.Items.Clear();
            connection.Open();
            cmd = new MySqlCommand("select distinct(barangay) from philippinelocaltbl where citymunicipality = '" + combocitymun.Text + "'", connection);
            dataReader = cmd.ExecuteReader();
            combobarangay.Items.Add("Add");
            while (dataReader.Read())
            {
                combobarangay.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }
        private void txtfirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtfirst.Text.Length == 0 && e.KeyChar == ' ') && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar != Convert.ToChar(Keys.Back) || e.KeyChar != Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }
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

        private void txtmiddle_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtmiddle.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtlast_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtlast.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtstreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtstreet.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void txtlicense_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtlicense.SelectionStart == 0)
            {
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && txtcontactnum.Text.Length == 0) 
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
        private void txtdateofbirth_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = txtdateofbirth.Value;
            DateTime to = DateTime.Now;
            TimeSpan span = to - from;
            double days = span.TotalDays;
            txtage.Text = (days / 365).ToString("0");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want ot delete this record?", "Delete Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteEmployee(updateId))
                {
                    MessageBox.Show("Employee " + updateId + " is successfully deleted.","System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEmployee.DataSource = db.getEmployee();
                    dataGridViewEmployee.Enabled = true;
                    txtsearch.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    txtcontactnum.Text = "+63";
                    notecontent.Text = dataGridViewEmployee.Rows.Count.ToString();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void txtmiddle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtmiddle.Text.Length == 0 && e.KeyChar == ' ') && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtlast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtlast.Text.Length == 0 && e.KeyChar == ' ') && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
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


        private void combotitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combotitle.SelectedIndex == -1)
                return;
            if (combotitle.SelectedIndex == 0)
            {
                ManageAddEditDeleteEmployeeTitlefrm  frm = new ManageAddEditDeleteEmployeeTitlefrm();
                frm.Show();
                bindtitle();
                combotitle.SelectedIndex = -1;
                return;
            }
            if (combotitle.SelectedItem.ToString() == "Intern")
                {
                    txtlicense.Enabled = false;
                    asteriskLicense.Visible = false;
                }
                else
                {
                    txtlicense.Enabled = true;
                    asteriskLicense.Visible = true;
                }
        
        }

        private void ManageAddEditDeleteEmployeefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void txtlicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Delete))
            {
                e.Handled = true;
            }

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
            dataReader.Close();
            connection.Close();
        }

        private void txtcontactnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewEmployee_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void txtcontactnum_KeyDown(object sender, KeyEventArgs e)
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


        private void combobarangay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (combobarangay.SelectedIndex == 0) {
                //show mo form
                new ManageAddEditDeleteBarangayfrm(comboprovince.SelectedItem.ToString(),combocitymun.SelectedItem.ToString()).Show();
                combobarangay.SelectedIndex = -1;
                return;
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
                ret = year + "50000";
                for (int i = 0; i < 1; i++)
                {
                    ret += rand.Next(9);
                }
                cmd.CommandText = "select * from employeetbl where  id ='" + ret + "'";
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
