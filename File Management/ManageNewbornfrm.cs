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
    public partial class ManageNewbornfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        NewbornDB db = new NewbornDB();
        MySqlDataReader dr;
        MySqlCommand cmd;
        string patientId, updateId, v1, v2, v3, v4 ;
        public ManageNewbornfrm()
        {
            InitializeComponent();
           
            dataGridViewNewbornPatient.DataSource = db.getNewborn();
           /* txtbirthwt.LostFocus += lostFocusWeight;
            txtht.LostFocus += lostFocusHeight;
            txthc.LostFocus += lostFocusHeadCir;
            txtcc.LostFocus += lostFocusChestCir;
            txtac.LostFocus += lostFocusAbdomenalCir;*/
        }
        private void lostFocusWeight(object sender, EventArgs e)
        {
            if (Double.Parse(txtbirthwt.Text) < 2)
                txtbirthwt.Text = "2.0";
            else if (Double.Parse(txtbirthwt.Text) >= 4.3)
                txtbirthwt.Text = "4.3";
           
        }
        private void lostFocusHeight(object sender, EventArgs e)
        {
            if (Double.Parse(txtht.Text) < 48)
                txtht.Text = "48.0";
            else if (Double.Parse(txtht.Text) >= 53.4)
                txtht.Text = "53.4";
        }
        private void lostFocusHeadCir(object sender, EventArgs e)
        {
            if (Double.Parse(txthc.Text) < 33)
                txthc.Text = "33.0";
            else if (Double.Parse(txthc.Text) >= 35.0)
                txthc.Text = "35.0";
        }
        private void lostFocusChestCir(object sender, EventArgs e)
        {
            if (Double.Parse(txtcc.Text) < 30)
                txtcc.Text = "30.0";
            else if (Double.Parse(txtcc.Text) >= 33.0)
                txtcc.Text = "33.0";
        }
        private void lostFocusAbdomenalCir(object sender, EventArgs e)
        {
            if (Double.Parse(txtac.Text) < 30)
                txtac.Text = "30.0";
            else if (Double.Parse(txtac.Text) >= 33.0)
                txtac.Text = "33.0";
        }
        public void searchPatient(string searchValue)
        {
            string searchQuery = "SELECT `newbornid` as 'Newborn ID', `firstname` as 'First name', `middlename` as 'Middle name', `lastname` as 'Last name', `suffix` as 'suffix', `sex` as 'Sex' FROM `newbornpatient_tbl` WHERE CONCAT (firstname, middlename, lastname, suffix, sex) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewNewbornPatient.DataSource = table;
        }
        public void searchMother(string searchValue)
        {
            string searchQuery = "SELECT `id` as 'Patient ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM patienttbl WHERE CONCAT (firstname, middlename, lastname) LIKE '%" + searchValue + "%' AND status = '1'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataTableMother.DataSource = table;
        }
        private void OnFocus_txtMid(object sender, EventArgs e)
        {
            SuggesedMNamePanel.Visible = true;
        }
        private async void OnLostFocus_txtMid(object sender, EventArgs e)
        {

            await Task.Delay(100);

            SuggesedMNamePanel.Visible = false;
        }

        private void OnFocus_txtLast(object sender, EventArgs e)
        {
            SuggestedLNamePanel.Visible = true;
        }
        private async void OnLostFocus_txtLast(object sender, EventArgs e)
        {

            await Task.Delay(100);

            SuggestedLNamePanel.Visible = false;
        }

        private void OnFocus(object sender, EventArgs e)
        {
            dataTablePane.Visible = true;
        }
        private async void OnLostFocus(object sender, EventArgs e)
        {

            await Task.Delay(1000);

            dataTablePane.Visible = false;
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
        public void bindEmployee()
        {
            connection.Open();
            cmd = new MySqlCommand("select firstname, middlename, lastname from employeetbl WHERE title = 'Midwife'", connection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboAttendant.Items.Add(dr.GetValue(0).ToString() + " " + dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString());
            }
            dr.Close();
            connection.Close();
        }
        private void ManageNewbornfrm_Load(object sender, EventArgs e)
        {
            searchPatient("");
            notecontent.Text = dataGridViewNewbornPatient.Rows.Count.ToString();
            bindreligion();
            bindEmployee();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            disableitems();
            txtmother.GotFocus += OnFocus;
            txtmother.LostFocus += OnLostFocus;
            txtlast.GotFocus += OnFocus_txtLast;
            txtlast.LostFocus += OnLostFocus_txtLast;
            txtmiddle.GotFocus += OnFocus_txtMid;
            txtmiddle.LostFocus += OnLostFocus_txtMid;
            //txtdateofbirth.MaxDate = DateTime.Now.AddYears(-0);//Minimum age
            txtdateofbirth.MaxDate = DateTime.Now.AddHours(1);//Maximum age
            txtdateofbirth.MinDate = DateTime.Now;//Maximum age
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            searchMother("");
            DateTime date = DateTime.Now;
            lbldate.Text = date.ToString("yyyy-MM-dd");
            lbltime.Text = date.ToString("HH-mm-ss");
           
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
                searchResult.Text = dataGridViewNewbornPatient.Rows.Count.ToString();
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        private void ManageNewbornfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        void enableitems()
        {
            txtfirst.Enabled = true;
            txtmiddle.Enabled = true;
            txtlast.Enabled = true;
            txtdateofbirth.Enabled = true;
            rdFemale.Enabled = true;
            rdMale.Enabled = true;
            comboreligion.Enabled = true;
            txtmother.Enabled = true;
            txtfather.Enabled = true;
            txtbirthwt.Enabled = true;
            txthc.Enabled = true;
            txtht.Enabled = true;
            txtcc.Enabled = true;
            txtac.Enabled = true;
            comboAttendant.Enabled = true;
        }
        void disableitems()
        {
            txtfirst.Enabled = false;
            txtmiddle.Enabled = false;
            txtlast.Enabled = false;
            rdFemale.Enabled = false;
            rdMale.Enabled = false;
            txtdateofbirth.Enabled = false;
            comboreligion.Enabled = false;
            txtmother.Enabled = false;
            txtfather.Enabled = false;
            txtbirthwt.Enabled = false;
            txthc.Enabled = false;
            txtcc.Enabled = false;
            asss.Enabled = false;
            comboAttendant.Enabled = false;
            txtht.Enabled = false;
        }
        public bool validateEntry(string firstname, string middlename, string lastname, string suffix)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from newbornpatient_tbl where firstname='" + firstname + "' and middlename='" + middlename + "' and lastname='" + lastname + "'and suffix='" + suffix + "'";
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
            txtsuffix.Text = "";
            txtdateofbirth.Value = txtdateofbirth.MaxDate;
            rdMale.Checked = false;
            rdFemale.Checked = false;
            comboreligion.SelectedIndex = -1;
            txtmother.Text = "";
            txtfather.Text = "";
            txtbirthwt.Text = "";
            txtht.Text = "";
            txtcc.Text = "";
            txthc.Text = "";
            txtac.Text = "";
            comboAttendant.SelectedIndex = -1;

        }
        NewbornDB data = new NewbornDB();
        MySqlConnection con = new NewbornDB().getConnection();
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
                ret = year + "0000";
                for (int i = 0; i < 5; i++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from newbornpatient_tbl where  newbornid ='" + ret + "'";
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridViewNewbornPatient.Enabled = false;
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
            if (txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || !(rdMale.Checked || rdFemale.Checked) || comboreligion.Text == "" || txtmother.Text == "" || txtbirthwt.Text == "" || txthc.Text == "" || txtcc.Text == "" || txtac.Text == "")
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (validateEntry(txtfirst.Text, txtmiddle.Text, txtlast.Text, txtsuffix.Text))
                {
                    MessageBox.Show("Information already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = generateUniqueID();
                if (db.insertNewborn(id, patientId, txtfirst.Text, txtmiddle.Text, txtlast.Text, txtsuffix.Text, rdMale.Checked ? "Male" : "Female", txtdateofbirth.Text, comboreligion.SelectedItem.ToString(), txtbirthwt.Text,txtht.Text, txthc.Text, txtcc.Text, txtac.Text, comboAttendant.SelectedItem.ToString(), lbldate.Text, lbltime.Text ))
                { 
                    MessageBox.Show("Successfully saved.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewNewbornPatient.DataSource = db.getNewborn();
                    btnAdd.Enabled = true;
                    disableitems();
                    clear();
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    dataGridViewNewbornPatient.Enabled = true;
                    txtsearch.Enabled = true;
                    notecontent.Text = dataGridViewNewbornPatient.Rows.Count.ToString();

                }
                else
                {
                    MessageBox.Show("Invalid entry.", "System Message");
                }
            }
        }

        private void dataTableMother_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            patientId = dataTableMother.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void lblFatherLast_Click(object sender, EventArgs e)
        {
            txtlast.Text = lblFatherLast.Text;
            SuggestedLNamePanel.Visible = false;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtdateofbirth.MinDate = DateTime.Now;//Maximum age
            if (!(v1.ToLower().Equals(txtfirst.Text.ToLower()) && v2.ToLower().Equals(txtmiddle.Text.ToLower()) && v3.ToLower().Equals(txtlast.Text.ToLower())))
            {
                connection.Open();
                cmd = new MySqlCommand("SELECT * FROM newbornpatient_tbl WHERE firstname = '" + txtfirst.Text.ToLower() + "' AND middlename = '" + txtmiddle.Text.ToLower() + "' AND lastname = '" + txtlast.Text.ToLower() + "'", connection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    connection.Close();
                    MessageBox.Show("Information already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                dr.Close();
                connection.Close();
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (!(txtfirst.Text == "" || txtlast.Text == "" || txtdateofbirth.Text == "" || comboreligion.Text == "" || txtbirthwt.Text == "" ||txtht.Text == "" || txthc.Text == "" || txtcc.Text == "" || txtac.Text == "" || comboAttendant.Text == ""))
                {
                    if (db.updateNewborn(updateId, patientId, txtfirst.Text, txtmiddle.Text, txtlast.Text, txtsuffix.Text, rdMale.Checked ? "Male" : "Female", txtdateofbirth.Text, comboreligion.SelectedItem.ToString(), txtbirthwt.Text, txtht.Text, txthc.Text, txtcc.Text, txtac.Text, comboAttendant.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewNewbornPatient.DataSource = db.getNewborn();
                        clear();
                        disableitems();
                        txtsearch.Enabled = true;
                        dataGridViewNewbornPatient.Enabled = true;
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

        private void dataGridViewNewbornPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewNewbornPatient.Rows[e.RowIndex].Cells[0].Value.ToString();

            /*MySqlDataReader reader = data.getNewbornInfo(updateId);

            if (reader.Read())
            {
                v1 = reader.GetValue(1).ToString();
                v2 = reader.GetValue(2).ToString();
                v3 = reader.GetValue(3).ToString();
                txtfirst.Text = reader.GetValue(1).ToString();
                txtmiddle.Text = reader.GetValue(2).ToString();
                txtlast.Text = reader.GetValue(3).ToString();
                txtsuffix.Text = reader.GetValue(4).ToString();
                //Gender
                v4 = reader.GetValue(5).ToString();
                if (v4.ToLower().Equals("male"))
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                txtdateofbirth.MinDate = DateTime.Parse(reader.GetValue(6).ToString());
                txtdateofbirth.Value = DateTime.Parse(reader.GetValue(6).ToString());
                comboreligion.SelectedItem = reader.GetValue(7).ToString();
                txtmother.Text = reader.GetValue(21).ToString() + " " + reader.GetValue(22).ToString() + " " + reader.GetValue(23).ToString();
                txtfather.Text = reader.GetValue(31).ToString() + " " + reader.GetValue(32).ToString() + " " + reader.GetValue(33).ToString();
                patientId = reader.GetValue(8).ToString();
                //txtfather.Text = reader.GetValue(9).ToString();
                txtbirthwt.Text = reader.GetValue(9).ToString();
                txtht.Text = reader.GetValue(10).ToString();
                txthc.Text = reader.GetValue(11).ToString();
                txtcc.Text = reader.GetValue(12).ToString();
                txtac.Text = reader.GetValue(13).ToString();
                comboAttendant.SelectedItem = reader.GetValue(14).ToString();
            }
            data.closeConnection();*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtdateofbirth.MinDate = DateTime.Now;//Maximum age
            clear();
            disableitems();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewNewbornPatient.Refresh();
            dataGridViewNewbornPatient.Enabled = true;
            txtsearch.Enabled = true;
            txtht.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteNewborn(updateId))
                {
                    MessageBox.Show("Successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewNewbornPatient.DataSource = db.getNewborn();
                    txtsearch.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    notecontent.Text = dataGridViewNewbornPatient.Rows.Count.ToString();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMotherMiddle_Click(object sender, EventArgs e)
        {
            txtmiddle.Text = lblMotherMiddle.Text;
            SuggesedMNamePanel.Visible = false;
        }

        private void lblFatherFirst_Click(object sender, EventArgs e)
        {
            txtlast.Text = lblFatherFirst.Text;
            SuggestedLNamePanel.Visible = false;
        }

        private void lblMotherLast_Click(object sender, EventArgs e)
        {
            txtmiddle.Text = lblMotherLast.Text;
            SuggesedMNamePanel.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            data.openConnection();
            MySqlDataReader reader = data.getNewbornInfo(updateId);

            if (reader.Read())
            {
                v1 = reader.GetValue(2).ToString();
                v2 = reader.GetValue(3).ToString();
                v3 = reader.GetValue(4).ToString();
                txtfirst.Text = reader.GetValue(2).ToString();
                txtmiddle.Text = reader.GetValue(3).ToString();
                txtlast.Text = reader.GetValue(4).ToString();
                txtsuffix.Text = reader.GetValue(5).ToString();
                //Gender
                v4 = reader.GetValue(6).ToString();
                if (v4.ToLower().Equals("male"))
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                txtdateofbirth.MinDate = DateTime.Parse(reader.GetValue(7).ToString());
                txtdateofbirth.Value = DateTime.Parse(reader.GetValue(7).ToString());
                comboreligion.SelectedItem = reader.GetValue(8).ToString();
                txtmother.Text = reader.GetValue(18).ToString() + " " + reader.GetValue(19).ToString() + " " + reader.GetValue(20).ToString();
                txtfather.Text = reader.GetValue(28).ToString() + " " + reader.GetValue(29).ToString() + " " + reader.GetValue(30).ToString();
                patientId = reader.GetValue(1).ToString();
                //txtfather.Text = reader.GetValue(9).ToString();*/
                txtbirthwt.Text = reader.GetValue(9).ToString();
                txtht.Text = reader.GetValue(10).ToString();
                txthc.Text = reader.GetValue(11).ToString();
                txtcc.Text = reader.GetValue(12).ToString();
                txtac.Text = reader.GetValue(13).ToString();
                comboAttendant.SelectedItem = reader.GetValue(14).ToString();

            }

            data.closeConnection();


            dataGridViewNewbornPatient.Enabled = false;
            txtsearch.Enabled = false;
            enableitems();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void dataTableMother_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patientId = dataTableMother.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmother.Text = dataTableMother.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataTableMother.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataTableMother.Rows[e.RowIndex].Cells[3].Value.ToString();
            MySqlDataReader dr = data.setChildParents(patientId);
            if (dr.Read())
            {
                txtfather.Text = dr.GetValue(11).ToString() + " " + dr.GetValue(12).ToString() + " " + dr.GetValue(13).ToString();
                comboreligion.SelectedItem = dr.GetValue(15).ToString();
                lblMotherLast.Text = dr.GetValue(3).ToString();
                lblMotherMiddle.Text = dr.GetValue(2).ToString();
                lblFatherLast.Text = dr.GetValue(13).ToString();
                lblFatherFirst.Text = dr.GetValue(11).ToString();
            }
            dr.Close();
            data.closeConnection();
        }
    }
}
