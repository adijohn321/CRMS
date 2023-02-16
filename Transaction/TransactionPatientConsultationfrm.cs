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
    public partial class TransactionPatientConsultationfrm : Form
    {
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection con = new Database().getConnection();
        Database db = new Database();
        string id, name;
        public TransactionPatientConsultationfrm(string id, string name)
        {
            this.id = id;
            this.name = name;
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToString("yyyy-MM-dd");
            lblTime.Text = date.ToString("HH:mm:ss");
            txttemp.LostFocus += lostFocus;
           
        }
        private void lostFocus(object sender, EventArgs e)
        {
            if (Double.Parse(txttemp.Text) < 36)
                txttemp.Text = "36.0";
            else if (Double.Parse(txttemp.Text) >= 37.5)
                txttemp.Text = "37.5";
        }
        
        private void PatientConsultation_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void PatientConsultation_Load(object sender, EventArgs e)
        {
            LoadAttendant();
            dataGridViewConsultation.DataSource = db.getConsultation();
        }
        public bool validateEntry(string p_id, string name, string datetime)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from consultationtbl where p_id='" + p_id + "' and p_name='" + name + "' and p_DT='" + datetime + "'";
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return false;
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
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

        private void txttemp_KeyPress(object sender, KeyPressEventArgs e)
        {
             
            if (char.IsDigit(e.KeyChar)||(char.IsControl(e.KeyChar) && e.KeyChar == Convert.ToChar(Keys.Back))||e.KeyChar=='.') {
                return;
            }
            e.Handled = true;
        }

        private void txttemp_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (symptomsOption.Visible)
            {
                symptomsOption.Visible = false;
                if (checksymptoms.CheckedItems.Count == 0) {
                    return;
                }
                string s = "";
                for (int i = 0; i < checksymptoms.CheckedItems.Count; i++) {
                    s += checksymptoms.CheckedItems[i].ToString() + ", ";
                }
                txtSysmptoms.Text = s.Substring(0, s.Length - 2);

            }
            else {
                symptomsOption.Visible = true;
            }
        }

        private void dataGridViewadmittedPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rdPregnant_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPregnant.Checked)
            {
                richTextBoxFinalDiag.Text = "Pregnant";
            }
            else
                richTextBoxFinalDiag.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save sa database
            if (db.insertConsultation(generateCaseNumber(), lblIDNo.Text, lblDate.Text, lblTime.Text, comboAttendant.SelectedItem.ToString(), txtbp.Text, txtwt.Text, txttemp.Text, txtSysmptoms.Text, rdPregnant.Checked? "Pregnant" : "Not Pregnant", richTextBoxFinalDiag.Text))
                MessageBox.Show("Successfully saved.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblName.Text = "";
            lblIDNo.Text = "";
            lblDate.Text = "";
            lblTime.Text = "";
            comboAttendant.SelectedIndex = -1;
            txtbp.Text = "";
            txttemp.Text = "";
            txtwt.Text = "";
            txtSysmptoms.Text = "";
            rdPregnant.Checked = false;
            radioButton2.Checked = false;
            richTextBoxFinalDiag.Text = "";
             dataGridViewConsultation.DataSource = db.getConsultation();
            if (rdPregnant.Checked) {
                new TransactionPatientPrenatalfrm(id,name,comboAttendant.SelectedItem.ToString()).Show();
            }
        }

        private void txtbp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (char.IsControl(e.KeyChar) && e.KeyChar == Convert.ToChar(Keys.Back)) || e.KeyChar == '/')
            {
                return;
            }
            e.Handled = true;
        }

        private void txtwt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtwt_Validated(object sender, EventArgs e)
        {

        }

        private void txtwt_Validating(object sender, CancelEventArgs e)
        {
           /* TextBox txt = sender as TextBox;
            if (txt != null)
            {
                int i;
                if (int.TryParse(txt.Text, out i))
                {
                    if (i >= 40 && i <= 80)
                        return;
                }
                e.Cancel = true;
            }*/
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
                ret += "CONS"+dateTime.Year + "000000";
                for (int a = 0; a < 5; a++)
                {
                    ret += rand.Next(10);
                }
                cmd.CommandText = "select * from consultationtbl where  caseNumber ='" + ret + "'";
                cmd.ExecuteNonQuery();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }
        }
    }
}
