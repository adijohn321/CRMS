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
    public partial class DischargeIinformationfrm : Form
    {
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection con = new Database().getConnection();
        Database db = new Database();
        string id, name, dischargeID;
        int age;
        public DischargeIinformationfrm(string id, string name)
        {
            this.id = id;
            this.name = name;
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;

        }
        public DischargeIinformationfrm()
        {
            InitializeComponent();
        }
        public DischargeIinformationfrm(string dischargeID, string name, string id)
        {

            this.id = id;
            this.name = name;
            this.dischargeID = dischargeID;
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*  db.inse(generateUniqueID(), id, txtGravida.Text, txtPara.Text, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("h:mm:ss")
                 , DateTime.Now.ToString("t"), rdlive.Checked ? "Alive" : "Dead", rdMale.Checked ? "Male" : "Female", txtbirthwt.Text, txtht.Text, txthc.Text, txtcc.Text,
                 txtac.Text, hepab.Checked ? "Completed" : "", comboAttendant.SelectedItem.ToString(), textBox1.Text, richTextBox1.Text, name, address, age + "");*/
            if ((dateDischarge.Text == "" || timeDischarge.Text == "" || comboAttendant.Text == "" || txtbp.Text == "" || txtwt.Text == "" || txttemp.Text == "" || txtFinalDiag.Text == "" || txtMedicine.Text == "" || txtDisposition.Text == ""))
            {
                MessageBox.Show("Please fill all required fields.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                db.insertdischarge(generateCaseNumber(), id, age + "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("h:mm:ss"), comboAttendant.SelectedItem.ToString(), txtbp.Text, txtwt.Text, txttemp.Text, txtFinalDiag.Text, txtMedicine.Text, txtDisposition.Text);
                db.updateWhatFromWhere("status", "2", "bills", "invoiceNumber", (db.getInvoiceNumber(dischargeID)));
                MessageBox.Show("Patient successfully discharge.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        public string generateCaseNumber()
        {
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
            while (true)
            {

                ret = "";
                ret += dateTime.Year + "00000";
                for (int a = 0; a < 5; a++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from discharge_tbl where  caseNumber ='" + ret + "'";
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
        private void DischargeIinformationfrm_Load(object sender, EventArgs e)
        {
            LoadAttendant();
        }
    }
}
