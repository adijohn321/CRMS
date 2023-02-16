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
    public partial class ManageAddEditDeleteRoomBedfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db = new DropDownAdd();
        MySqlCommand cmd;
        MySqlDataReader dataReader;
        MySqlConnection conn1 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        DropDownAdd db1 = new DropDownAdd();
        MySqlCommand cmd1;
        MySqlDataReader dataReader1;
        string updateId, v1, v2;
        public ManageAddEditDeleteRoomBedfrm()
        {
            InitializeComponent();
            dataGridViewRoomBed.DataSource = db.getRoomBed();
        }
        int b = 0;
        public ManageAddEditDeleteRoomBedfrm(int b)
        {
            this.b = b;
            InitializeComponent();
            rdRoom.Enabled = true;
            rdRoom.Checked = true;
            typeoption.Enabled = true;
            rdBed.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewRoomBed.DataSource = db.getRoomBed();
            dataGridViewRoomBed.Enabled = false;
        }
        string a = null;
        public ManageAddEditDeleteRoomBedfrm(string a)
        {
            this.a = a;
            InitializeComponent();
            room();
            comboRoom.SelectedItem = a;
            rdBed.Checked = true;
            typeoption.Enabled = true;
            rdRoom.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;

            dataGridViewRoomBed.DataSource = db.getRoomBed();
            dataGridViewRoomBed.Enabled = false;
        }

        public void searchRoomBed(string searchValue)
        {
            string searchQuery;
            if (rdRoomFilter.Checked)
                searchQuery = "SELECT `roomBed_Id` as 'Room/Bed ID', `roomName` as 'Room', `capacity` FROM `roombed_tbl` WHERE `type`='room'AND CONCAT(roomBed_Id,roomName)LIKE '%" + searchValue + "%'";
            else if(rdBedFilter.Checked)
                searchQuery = "SELECT `roomBed_Id` as 'Room/Bed ID', `roomName` as 'Room', `bedNo` as 'Bed No.', `price` as 'Price'FROM `roombed_tbl` WHERE `type`='bed' AND CONCAT(roomBed_Id,roomName,bedNo, type, price)LIKE '%" + searchValue + "%'";
            else
                searchQuery = "SELECT `roomBed_Id` as 'Room/Bed ID', `roomName` as 'Room', `bedNo` as 'Bed No.', `roomType` as 'Room Type' , `price` as 'Price' FROM `roombed_tbl` WHERE CONCAT(roomBed_Id,roomName,type, price, bedNo)LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewRoomBed.DataSource = table;
            searchResult.Text = dataGridViewRoomBed.Rows.Count.ToString();
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            searchRoomBed(txtsearch.Text);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (txtsearch.Text.Length != 0)
            {
                searchResult.Visible = true;
                dots.Visible = true;
            }
            else
            {
                searchResult.Visible = false;
                dots.Visible = false;
            }
        }
        private void txtroom_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar) || (e.KeyChar == Convert.ToChar(Keys.Back)) || (e.KeyChar != Convert.ToChar(Keys.Delete)))
            {
                return;
            }
            e.Handled = true;

        }

        private void txtbedNum_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ( char.IsLetter(e.KeyChar) || char.IsLetter(e.KeyChar) || (e.KeyChar == Convert.ToChar(Keys.Back)) || (e.KeyChar != Convert.ToChar(Keys.Delete)))
            {
                return;
            }
            e.Handled = true;

        }

        private void txtroom_KeyDown(object sender, KeyEventArgs e)
        {
           /* if (txtroom.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }*/
            if (txtroom.SelectionStart == 0)
            {
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && txtroom.Text.Length == 3)
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

        private void txtbedNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtbedNum.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void ManageAddEditDeleteRoomBedfrm_Load(object sender, EventArgs e)
        {/*
            if (a != null || b != 0)
            {
                return;
            }
            searchRoomBed("");
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //Components
            txtroom.Visible = false;
            comboRoom.Visible = false;
            txtbedNum.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            label13.Visible = false;
            as3.Visible = false;
            as2.Visible = false;
            as1.Visible = false;
            rdBed.Enabled = false;
            rdRoom.Enabled = false;
            room();
            notecontent.Text = dataGridViewRoomBed.Rows.Count.ToString();

*/
            if (a != null || b != 0)
            {
                return;
            }
            rdAll.Checked = true;
            searchRoomBed("");
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //Components
            rdBed.Enabled = false;
            rdRoom.Enabled = false;
            label4.Visible = true;
            label5.Visible = true;
            label12.Visible = true;
            label6.Visible = true;
            label5.Text = "Type:";
            label12.Text = "Capacity:";
            txtroom.Enabled = false;
            cbType.Enabled = false;
            txtprice.Enabled = false;
            comboRoom.Visible = false;
            room();
            notecontent.Text = dataGridViewRoomBed.Rows.Count.ToString();

        }
        public bool validateEntry(string roomName, string bedNum)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from roombed_tbl where roomName='" + roomName + "' and bedNo = '"+bedNum+"'";
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
        public bool roomEntry(string roomName)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from roombed_tbl where roomName='" + roomName + "'";
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
            txtbedNum.Text = "";
            txtroom.Text = "";
            txtprice.Text = "";
            rdBed.Checked = false;
            rdRoom.Checked = false;
            comboRoom.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            room();
            typeoption.Visible = true;
            label6.Visible = true;
            txtprice.KeyPress -= txtprice_KeyPress;
            dataGridViewRoomBed.Enabled = false;
            rdBed.Enabled = true;
            rdRoom.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtsearch.Enabled = false;
            rdRoom.Checked = true;
            comboRoom.Enabled = true;

            
        }

        private void rdRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRoom.Checked)
            {
                comboRoom.Visible = false;
                txtroom.Enabled = true;
                txtroom.Visible = true;
                label4.Visible = true;
                txtbedNum.Visible = false;
                cbType.Visible = true;
                label5.Text = "Type:";
                label12.Text = "Capacity:";
                txtprice.KeyPress -= txtprice_KeyPress;
                txtprice.Enabled = true;
                cbType.Enabled = true;
                txtprice.Text = "";
                comboRoom.SelectedIndex = -1;
                txtbedNum.Text = "";
                 

            }
        }
        private void rdBed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBed.Checked) 
            {
                comboRoom.Visible = true;
                txtbedNum.Visible = true;
                txtprice.Visible = true;
                label12.Visible = true;
                txtbedNum.Visible = true;
                cbType.Visible = false;
                label5.Text = "Bed No.:";
                label12.Text = "Price:";
                txtroom.Visible = false;
                txtprice.KeyPress += txtprice_KeyPress;
                txtprice.Text = "";
                txtroom.Text = "";
                cbType.SelectedIndex = -1;

            }

        }
        Database data = new Database();
        public void room()
        {
            int count = 0;
            connection.Open();
            cmd = new MySqlCommand("select distinct(roomName) from roombed_tbl", connection);
            dataReader = cmd.ExecuteReader();
            comboRoom.Items.Clear();
            while (dataReader.Read())
            {
                count = 0;

                conn1.Close();
                conn1.Open();
                cmd1 = new MySqlCommand("select distinct(bedNo) from roombed_tbl where roomName = '" + dataReader.GetValue(0).ToString() + "'", conn1);
                dataReader1 = cmd1.ExecuteReader();
                while (dataReader1.Read())
                {
                    count++;
                }
                dataReader1.Close();
                conn1.Close();
                if (count <= Int32.Parse(data.getWhatFromWhere("capacity", "roombed_tbl", "roomBed_Id", (data.getRoomId("roomBed_Id", dataReader.GetValue(0).ToString(), ""))))) { 
                    comboRoom.Items.Add(dataReader.GetValue(0).ToString());
                }
            }
            dataReader.Close();
            connection.Close();
        }
        public void room(int w)
        {
            connection.Open();
            cmd = new MySqlCommand("select distinct(roomName) from roombed_tbl", connection);
            dataReader = cmd.ExecuteReader();
            comboRoom.Items.Clear();
            while (dataReader.Read())
            {
                    comboRoom.Items.Add(dataReader.GetValue(0).ToString());
            }
            dataReader.Close();
            connection.Close();
        }
        private void ManageAddEditDeleteRoomBedfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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
                cmd.CommandText = "select * from roombed_tbl where  roomBed_Id ='" + ret + "'";
                cmd.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdRoom.Checked && txtroom.Text == "")
            {

                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (rdBed.Checked && (comboRoom.Text == "" || txtbedNum.Text == ""))
            {

                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (validateEntry(txtroom.Visible ? txtroom.Text : comboRoom.SelectedItem.ToString(), txtbedNum.Text))
            {
                MessageBox.Show("Already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (roomEntry(txtroom.Visible ? txtroom.Text : null))
            {
                MessageBox.Show("Already exist.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string id = generateId();
            if (db.insertRoomBed(id,txtroom.Visible ? txtroom.Text : comboRoom.SelectedItem.ToString(), txtroom.Visible ? null : txtbedNum.Text,  rdRoom.Checked ? "Room" : "Bed", txtroom.Visible ? null : txtprice.Text,rdBed.Checked? null:txtprice.Text,rdBed.Checked?null:cbType.Text))
            {
                if (a != null || b != 0) {
                    this.Close();
                }
                MessageBox.Show("Room/Bed successfully added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchRoomBed(txtsearch.Text);
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                txtsearch.Enabled = true;
                dataGridViewRoomBed.Enabled = true;
                clear();
                rdBed.Enabled = false;
                rdRoom.Enabled = false;
                label4.Visible = true;
                label5.Visible = true;
                label12.Visible = true;
                label5.Text = "Type:";
                label12.Text = "Capacity:";
                txtroom.Enabled = false;
                cbType.Enabled = false;
                txtprice.Enabled = false;
                comboRoom.Visible = false;
                cbType.SelectedIndex = -1;

                //if BED
                //if ROOM


            }
            else
            {
                MessageBox.Show("Invalid entry.", "System Message");
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            rdBed.Enabled = false;
            rdRoom.Enabled = false;
            label4.Visible = true;
            label5.Visible = true;
            label12.Visible = true;
            label5.Text = "Type:";
            label12.Text = "Capacity:";
            txtroom.Enabled = false;
            cbType.Enabled = false;
            txtprice.Enabled = false;
            comboRoom.Visible = false;
            MySqlDataReader reader = db.getRoomBedType(updateId);

            if (reader.Read())
            {
                typeoption.Visible = false;
                label6.Visible = false;
                if (reader.GetValue(3).ToString() == "Room")
                {
                    as1.Visible = false;
                    as2.Visible = false;
                    as3.Visible = true;
                    rdRoom.Checked = true;
                    v1 = reader.GetValue(1).ToString();
                    txtroom.Text = reader.GetValue(1).ToString();
                }
                if (reader.GetValue(3).ToString() == "Bed")
                {
                    as1.Visible = true;
                    as2.Visible = true;
                    as3.Visible = false;
                    rdBed.Checked = true;
                    v1 = reader.GetValue(1).ToString();
                    comboRoom.Text = reader.GetValue(1).ToString();
                    txtbedNum.Text = reader.GetValue(2).ToString();
                    txtprice.Text = reader.GetValue(4).ToString();
                }
            }
            db.closeConnection();
            dataGridViewRoomBed.Enabled = false;
            txtsearch.Enabled = false;
            txtbedNum.Enabled = true;
            txtroom.Enabled = true;
            comboRoom.Enabled = true;
            rdRoom.Enabled = true;
            rdBed.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            label6.Visible = true;

        }
        private void dataGridViewRoomBed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            updateId = dataGridViewRoomBed.Rows[e.RowIndex].Cells[0].Value.ToString();

            MySqlDataReader reader = db.getRoomBedType(updateId);
            as1.Visible = false;
            as2.Visible = false;
            room(1);
            as3.Visible = false;
            if (reader.Read())
            {
                as1.Visible = false;
                as2.Visible = false;
                typeoption.Visible = false;
                label6.Visible = false;
                if (reader.GetValue(3).ToString() == "Room")
                {
                   
                    rdRoom.Checked = true;
                    v1 = reader.GetValue(1).ToString();
                    txtroom.Text = reader.GetValue(1).ToString();
                    cbType.SelectedItem = reader.GetValue(6).ToString();
                    txtprice.Text = reader.GetValue(7).ToString();
                }
                if (reader.GetValue(3).ToString() == "Bed")
                {
                    as1.Visible = false;
                    as2.Visible = false;
                    rdBed.Checked = true;
                    v1 = reader.GetValue(1).ToString();
                    comboRoom.Text = reader.GetValue(1).ToString();
                    txtbedNum.Text = reader.GetValue(2).ToString();
                    txtprice.Text = reader.GetValue(4).ToString();
                }
            }
            db.closeConnection();
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            typeoption.Visible = true;
            label6.Visible = true;
            if (!(v1.ToLower().Equals(txtroom.Text.ToLower())))
            {
                connection.Open();
                cmd = new MySqlCommand("SELECT * FROM roombed_tbl WHERE roomName = '" + txtroom.Text.ToLower() + "'", connection);
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Close();
                    connection.Close();
                    MessageBox.Show("Already exist..", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                dataReader.Close();
                connection.Close();
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to change this record?", "Update Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                if ((txtbedNum.Text != ""||txtroom.Text!=""))
                {

                    if (rdRoom.Checked && txtroom.Text == "")
                    {
                        MessageBox.Show("Please fill all required fields.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }if (rdBed.Checked && (comboRoom.Text == "" || txtbedNum.Text == "" || txtprice.Text == ""))
                    {
                        MessageBox.Show("Please fill all required fields.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                  /*  if (!(v1.ToLower().Equals(txtroom.Text.ToLower()) && v2.ToLower().Equals(txtbedNum.Text.ToLower())))
                    {
                        connection.Open();
                        cmd = new MySqlCommand("SELECT * FROM roombed_tbl WHERE roomName = '" + txtroom.Text.ToLower() + "' AND bedNo = '" + txtbedNum.Text.ToLower() + "'", connection);
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
                    }*/
                    if (db.updateRoomBed(updateId, txtroom.Visible ? txtroom.Text : comboRoom.SelectedItem.ToString(), txtroom.Visible ? null : txtbedNum.Text, txtprice.Visible ? null : txtprice.Text))
                    {
                        MessageBox.Show("Successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewRoomBed.DataSource = db.getRoomBed();
                        dataGridViewRoomBed.Enabled = true;
                        txtbedNum.Enabled = false;
                        txtroom.Enabled = false;
                        comboRoom.Enabled = false;
                        rdRoom.Enabled = false;
                        rdBed.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = true;
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = false;
                        btnEdit.Enabled = false;
                        btnUpdate.Enabled = false;
                        clear();
                        txtsearch.Enabled = true;
                        dataGridViewRoomBed.Enabled = true;
                        rdBed.Checked = false;
                        rdRoom.Checked = false;
                        rdBed.Text = "";
                        rdRoom.Text = "";
                        lblBed.Text = "Bed";
                        lblRoom.Text = "Room";
                        comboRoom.Visible = false;
                        txtbedNum.Visible = false;
                        label4.Visible = false;
                        //if BED
                        comboRoom.Visible = false;
                        txtbedNum.Visible = false;
                        label12.Visible = false;
                        txtprice.Visible = false;
                        label4.Visible = false;
                        //if ROOM
                        txtroom.Visible = false;
                        label5.Visible = false;
                        label6.Visible = true;
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
            if (a != null|| b!=0)
            {
                this.Hide();
            }

            as1.Visible = true;
            as2.Visible = true;
            as3.Visible = true;
            typeoption.Visible = true;
            label6.Visible = true;
            clear();
            //Visible
            rdBed.Enabled = false;
            rdRoom.Enabled = false;
            label4.Visible = true;
            label5.Visible = true;
            label12.Visible = true;
            label5.Text = "Type:";
            label12.Text = "Capacity:";
            txtroom.Enabled = false;
            cbType.Enabled = false;
            txtprice.Enabled = false;
            comboRoom.Enabled = false;
            /*txtbedNum.Visible = false;
            txtroom.Visible = false;
            comboRoom.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            rdRoom.Enabled = false;
            rdBed.Enabled = false;
            label12.Enabled = false;
            
            txtprice.Enabled = false;*/
            //Buttons
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            dataGridViewRoomBed.Refresh();
            dataGridViewRoomBed.Enabled = true;
            txtsearch.Enabled = true;
            label6.Visible = true;

        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            searchRoomBed(txtsearch.Text);
            notecontent.Text = dataGridViewRoomBed.Rows.Count+"";
        }

        private void comboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == -1)
                return;
            if (cbType.SelectedItem.Equals("Private"))
            {
                txtprice.Text = "1";
                txtprice.Enabled = false;
            }
            else {
                txtprice.Text = "1";
                txtprice.Enabled = true;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewRoomBed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteRoomBed(updateId))
                {
                    MessageBox.Show("Successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewRoomBed.DataSource = db.getRoomBed();
                    dataGridViewRoomBed.Enabled = true;
                    txtsearch.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    rdBed.Text = "";
                    rdRoom.Text = "";
                    lblBed.Text = "Bed";
                    lblRoom.Text = "Room";
                    //Visible
                    as1.Visible = false;
                    as2.Visible = false;
                    label12.Visible = false;
                    txtbedNum.Visible = false;
                    txtprice.Visible = false;
                    txtroom.Visible = false;
                    comboRoom.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    rdRoom.Enabled = false;
                    rdBed.Enabled = false;
                    label6.Visible = true;
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        private void dataGridViewRoomBed_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
