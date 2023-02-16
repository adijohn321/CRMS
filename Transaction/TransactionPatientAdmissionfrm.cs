using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPSTONEPROJ.File_Management;
using MySql.Data.MySqlClient;

namespace CAPSTONEPROJ.Transaction
{
    public partial class TransactionPatientAdmissionfrm : Form
    {
        string name, id;
        public TransactionPatientAdmissionfrm(string id, string name)
        {
            this.id = id;
            this.name = name;
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;
            DateTime date = DateTime.Now;
            string birthday;
            if(id.Length==14)
                birthday = db.getWhatFromWhere("dateofbirth", "patienttbl","id", id);
            else
                birthday = db.getWhatFromWhere("dob", "newbornpatient_tbl", "newbornid", id);
            DateTime DT = DateTime.Parse(birthday);
            int age = (int)date.Subtract(DT).TotalDays;
            lblAge.Text = calculateAge(age);
            lblDate.Text = date.ToShortDateString();
            lblTime.Text = date.ToString("HH:mm:ss");
        }
        string calculateAge(int age)
        {
            string strAge = "";
            if (age / 365 > 0)
            {
                strAge += (age / 365) + " year(s)";
            }
            if (((age % 365) / 30) != 0)
            {
                if (age / 365 > 0)
                {
                    strAge += ", ";
                }
                strAge += ((age % 365) / 30) + " month(s)";
            }
            if (((age % 365) % 30) != 0)
            {
                if ((age % 365) / 30 != 0 || age / 365 > 0)
                {
                    strAge += ", ";
                }
                strAge += ((age % 365) % 30) + " day(s)";

            }
            strAge += " old";
            return strAge;

        }


        public string sql;
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection con = new Database().getConnection();
        Database db = new Database();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      /*  public void searchPatient(string searchValue)
        {
            string searchQuery = "SELECT patienttbl.id as 'ID', patienttbl.firstname as 'First Name', patienttbl.middlename as 'Middle Name', patienttbl.lastname as 'Last Name', admittedpateinttbl.date AS 'Date admitted', admittedpateinttbl.roomNumber AS 'Room', admittedpateinttbl.bedNumber AS 'Bed Number' FROM `bills` INNER JOIN patienttbl ON patienttbl.id =bills.pateintId INNER JOIN admittedpateinttbl ON bills.caseNumber = admittedpateinttbl.caseNumber WHERE bills.status = 0 AND CONCAT (patienttbl.firstname, patienttbl.middlename, patienttbl.lastname) LIKE '%" + searchValue + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewadmittedPatient.DataSource = table;
        }
*/
        private void PatientAdmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewadmittedPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        Database database = new Database();
        TransactionOutPatientfrm outPatientfrm = new TransactionOutPatientfrm();
        TransactionInpatientsfrm inpatientsfrm = new TransactionInpatientsfrm();
        private void btnAdmit_Click(object sender, EventArgs e)
        {
            if ((comboAttendant.Text == "" || comboRoom.Text == "" || comboBed.Text == "" || txtbp.Text == "" || txtwt.Text == "" || txttemp.Text == "" || richTextBoxAdmiDiag.Text == ""))
            {
                MessageBox.Show("Please fill all required fields.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else {
                if (id.Length == 14)
                    database.updatePateintStatus(id, "1");
                else
                    database.updateWhatFromWhere("status", "1", "newbornpatient_tbl", "newbornid", id);
                string caseNumber = generateCaseNumber();
                string invoiceNumber = generateInvoiceNo();
                database.updateWhatFromWhere("status", "1", "roombed_tbl", "roomBed_Id", database.getbedId(comboRoom.Text, comboBed.Text));

                if (database.insertCaseInfo(caseNumber, id, lblAge.Text, txtbp.Text, txtwt.Text, txttemp.Text, comboRoom.SelectedItem.ToString(), comboBed.SelectedItem.ToString(), comboAttendant.SelectedItem.ToString(), richTextBoxAdmiDiag.Text, DateTime.Now.ToString("HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    outPatientfrm.dataGridViewPatient.Refresh();
                    inpatientsfrm.dataGridViewAdmittedPatient.Refresh();
                    if (database.insertBill(invoiceNumber, id, caseNumber))
                        //insert room sa bill
                        database.insertInvoice(invoiceNumber, id, database.getRoomId("roomBed_Id", comboRoom.SelectedItem.ToString(), comboBed.SelectedItem.ToString()), "0", database.getRoomId("price", comboRoom.SelectedItem.ToString(), comboBed.SelectedItem.ToString()));
                    MessageBox.Show("Successfully Admitted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Something Went Wrong.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //outPatientfrm.dataGridViewPatient.Refresh();
                this.Close();
            }
        }


        string generateInvoiceNo()
        {
            string ret = "";
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            Random rand = new Random();

            conn.Close();
            conn.Open();




            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            while (true)
            {
                ret = year + "" + month + "" + day + "00";
                for (int i = 0; i < 5; i++)
                {
                    ret += rand.Next(9);
                }
                cmd.CommandText = "select * from bills where  invoiceNumber ='" + ret + "'";
                cmd.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }

        }


        //[x]dagdagan ng check if may duplicate na case number
        public string generateCaseNumber() {
            DateTime dateTime = DateTime.Now;
            Random rand = new Random();
            string ret;

            conn.Close();
            conn.Open();




            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            while (true) { 

            ret = "";
            ret += dateTime.Year+"00000";
            for (int a = 0; a < 5; a++) {
                ret += rand.Next(10);
            }
                cmd.CommandText = "select * from admittedpateinttbl where  caseNumber ='" + ret + "'";
                cmd.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }
        }
        void LoadAttendant()
        {
            conn.Open();
            cmd = new MySqlCommand("select firstname, middlename, lastname from employeetbl WHERE title = 'Midwife'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboAttendant.Items.Add(dr.GetValue(0).ToString() + " " + dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString());
            }
            dr.Close();
            conn.Close();
        }
        public void LoadRoom()
        {
            conn.Open();
            cmd = new MySqlCommand("select distinct(roomName) from roombed_tbl", conn);
            dr = cmd.ExecuteReader();
            comboRoom.Items.Add("Add");
            while (dr.Read())
            {
                if (!dr.GetValue(0).ToString().Trim().Equals(""))
                    comboRoom.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            conn.Close();
        }
       
        private void comboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRoom.SelectedIndex == 0)
            {
                bed = new ManageAddEditDeleteRoomBedfrm(1);
                bed.FormClosing += TransactionInpatientsfrm_FormClosingRoom;
                bed.Show();
                comboRoom.SelectedIndex = -1;
                return;
            }
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("select distinct(bedNo) from roombed_tbl where roomName = '" + comboRoom.Text + "' AND status = '0'", conn);
            dr = cmd.ExecuteReader();
            comboBed.Items.Clear();
            comboBed.Items.Add("Add");
            while (dr.Read())
            {
                if(!dr.GetValue(0).ToString().Trim().Equals(""))
                    comboBed.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void TransactionInpatientsfrm_FormClosingRoom(object sender, FormClosingEventArgs e)
        {
            LoadRoom();
            comboRoom.SelectedItem = bed.txtroom.Text;
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("select distinct(bedNo) from roombed_tbl where roomName = '" + comboRoom.Text + "'", conn);
            dr = cmd.ExecuteReader();
            comboBed.Items.Clear();
            comboBed.Items.Add("Add");
            while (dr.Read())
            {
                if (!dr.GetValue(0).ToString().Trim().Equals(""))
                    comboBed.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            conn.Close();

        }
        string bedId;

            ManageAddEditDeleteRoomBedfrm bed;
        private void comboBed_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBed.SelectedIndex == 0)
            {
                bed = new ManageAddEditDeleteRoomBedfrm(comboRoom.SelectedItem.ToString());
                bed.TopLevel = true;
                bed.FormClosing += TransactionInpatientsfrm_FormClosing;
                bed.Show();
                comboBed.SelectedIndex = -1;
                return;
            }
        }
        private void TransactionInpatientsfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Hello");
            
            if (comboRoom.SelectedIndex == 0)
            {
                new ManageAddEditDeleteRoomBedfrm(1).Show();
                comboRoom.SelectedIndex = -1;
                return;
            }
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("select distinct(bedNo) from roombed_tbl where roomName = '" + comboRoom.Text + "'", conn);
            dr = cmd.ExecuteReader();
            comboBed.Items.Clear();
            comboBed.Items.Add("Add");
            while (dr.Read())
            {
                if (!dr.GetValue(0).ToString().Trim().Equals(""))
                    comboBed.Items.Add(dr.GetValue(0).ToString());
            }
            comboBed.SelectedItem = bed.txtbedNum.Text;
            dr.Close();
            conn.Close();


        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TransactionPatientAdmissionfrm_Load(object sender, EventArgs e)
        {
            LoadAttendant();
            LoadRoom();
            //searchPatient("");
        }


    }
}
