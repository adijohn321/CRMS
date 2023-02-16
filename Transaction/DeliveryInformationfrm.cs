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

namespace CAPSTONEPROJ.Transaction
{
    public partial class DeliveryInformationfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlDataReader dr;
        MySqlCommand cmd;
        string id, name, address;
        int age;
        public DeliveryInformationfrm(string id, string name)
        {
            this.id = id;
            this.name = name;
            
            MySqlDataReader reader =  db.getAddress(db.getWhatFromWhere("addressId", "patienttbl", "id", id));

            if (reader.Read()) {
                address = reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3);
            }
            db.closeConnection();
             age = (int) (DateTime.Now.Subtract(DateTime.Parse(db.getWhatFromWhere("dateofbirth", "patienttbl", "id", id))).TotalDays) / 365;
            MessageBox.Show(age+"");
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeliveryInformationfrm_Load(object sender, EventArgs e)
        {

            connection.Close();
            connection.Open();

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            cmd.CommandText = "select * from delivery_tbl where  patientId ='" + id + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            if (table.Rows.Count != 0)
            {
                MessageBox.Show("This patient already given birth.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            
            bindEmployee();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation
            db.insertDelivery(generateUniqueID(),id,txtGravida.Text,txtPara.Text,DateTime.Now.ToString("yyyy-MM-dd"),DateTime.Now.ToString("h:mm:ss")
                ,DateTime.Now.ToString("t"),rdlive.Checked?"Alive":"Dead",rdMale.Checked?"Male":"Female",txtbirthwt.Text,txtht.Text,txthc.Text,txtcc.Text,
                txtac.Text,hepab.Checked?"Completed":"",comboAttendant.SelectedItem.ToString(),textBox1.Text,richTextBox1.Text,name,address,age+"");
        }
        MySqlConnection con = new NewbornDB().getConnection();
        string generateUniqueID()
        {
            string ret = "";
            int year = DateTime.Now.Year;
            Random rand = new Random();
            con.Close();
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
                cmd.CommandText = "select * from delivery_tbl where  patientId ='" + ret + "'";
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
        public void bindEmployee()
        {
            connection.Close();
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
    }
}
