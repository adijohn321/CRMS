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
    public partial class TransactionPatientPrenatalfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection con = new Database().getConnection();
        public TransactionPatientPrenatalfrm()
        {
            InitializeComponent();
            LoadAttendant();
            dataGridViewPrenatal.DataSource = db.getPrenatal();
        }
        string id, name, attendant;
        public TransactionPatientPrenatalfrm(string id, string name, string attendant)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
            this.attendant = attendant;
            LoadAttendant();
            lblIDNo.Text = id;
            lblName.Text = name;
            cbAttendant.SelectedItem = attendant;
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToShortDateString();
            lblTime.Text = date.ToString("HH:mm:ss");
        }
        public TransactionPatientPrenatalfrm(string id, string name)
        {
            this.id = id;
            InitializeComponent();
            LoadAttendant();
            lblIDNo.Text = id;
            lblName.Text = name;
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToShortDateString();
            lblTime.Text = date.ToString("HH:mm:ss");
        }
        public bool validateEntry(string p_id, string name, string datetime)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from prenataltbl where p_id='" + p_id + "' and p_name='" + name + "' and p_DT='" + datetime + "'";
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
            private void TransactionPatientPrenatalfrm_Load(object sender, EventArgs e)
        {
            txtlmp.MaxDate = DateTime.Now;
            txtlmp.MinDate = DateTime.Now.AddMonths(-11);
            dataGridViewPrenatal.DataSource = db.getPrenatal();
            if (id != null) {
                string res = db.getLmp(id);
                if(res!= null)
                    txtlmp.Value = DateTime.Parse(res);
                
            }
        }

        private void txtlmp_ValueChanged(object sender, EventArgs e)
        {
            int month = (int)DateTime.Now.Subtract(txtlmp.Value).TotalDays / 30;
            if (month < 3)
                rd1st.Checked = true;
            else if (month < 6 && month > 2)
                rd2nd.Checked = true;
            else if (month > 5)
                rd3rd.Checked = true;
            if (month == 0||month==3||month==6)
            {
                rdm1st.Checked = true;
            }
            else if (month == 1||month==4||month==7)
                rdm2nd.Checked = true;
            else if (month == 2||month == 5||month==8)
                rdm3rd.Checked = true;
            txtpal.Text = ((int)DateTime.Now.Subtract(txtlmp.Value).TotalDays/7)+" week/s and " + ((int)DateTime.Now.Subtract(txtlmp.Value).TotalDays % 7)+" day/s";
            txtedc.Text = (txtlmp.Value.AddMonths(9)).ToString("yyyy-MM-dd");
            txtfollowup.Text = (DateTime.Parse(lblDate.Text).AddMonths(1)).ToString("yyyy-MM-dd");
        }

        private void rd3rd_CheckedChanged(object sender, EventArgs e)
        {
            if (rd3rd.Checked)
            {
                group3rd.Visible = true;
            }
            else
                group3rd.Visible = false;
        }

        private void btnAdmit_Click(object sender, EventArgs e)
        {
            if (db.insertPrenatal(generateCaseNumber(), DateTime.Now.ToString("yyyy-MM-dd"), txtlmp.Value.ToString("yyyy-MM-dd"), lblTime.Text, lblIDNo.Text, txtbp.Text, txtwt.Text, richTextBoxFinalDiag.Text, cbAttendant.SelectedItem.ToString()))
                MessageBox.Show("Data saved...");
            dataGridViewPrenatal.DataSource = db.getPrenatal();
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
                ret += "PREN"+dateTime.Year + "00000";
                for (int a = 0; a < 5; a++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from prenatal where  caseNumber ='" + ret + "'";
                cmd.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        void LoadAttendant()
        {
            conn.Open();
            cmd = new MySqlCommand("select firstname, middlename, lastname from employeetbl WHERE title = 'Midwife'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbAttendant.Items.Add(dr.GetValue(0).ToString() + " " + dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString());
            }
            dr.Close();
            conn.Close();
        }
    }
}
