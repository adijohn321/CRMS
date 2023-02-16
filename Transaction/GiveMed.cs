using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CAPSTONEPROJ.Transaction
{
    public partial class GiveMed : Form
    {

        public string sql;
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;

        MySqlConnection con = new Database().getConnection();
        public GiveMed()
        {
            InitializeComponent();
        } string invoiceNumber, id;
        public GiveMed(string invoiceNumber, string id)
        {
            this.invoiceNumber = invoiceNumber;
            this.id = id;
            InitializeComponent();
        }
        TransactionInpatientsfrm frm = new TransactionInpatientsfrm();
        private void button4_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < dataGridViewAddedItems.Rows.Count; a++) {
                db.insertInvoice(invoiceNumber,id , dataGridViewAddedItems.Rows[a].Cells[0].Value.ToString(), dataGridViewAddedItems.Rows[a].Cells[2].Value.ToString(), dataGridViewAddedItems.Rows[a].Cells[4].Value.ToString().Replace("₱", "").Replace(",",""));
                
            }
            MessageBox.Show("Medicine already given.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void GiveMed_Load(object sender, EventArgs e)
        {
            LoadMedicine();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Int16.Parse(txtQty.Text) == 1)
                return;
            txtQty.Text = (Int16.Parse(txtQty.Text) - 1) + "";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtQty.Text = (Int16.Parse(txtQty.Text) + 1) + "";
        }

        void LoadMedicine()
        {
            lblType.Text = "Medicine";
            label3.Text = "Medicine";
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from medicine_tbl", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboMed.Items.Add(dr.GetString("name").ToString() + "(" + " " + dr.GetString("brand").ToString() + ")" + "(" + " "+ dr.GetString("dosage").ToString()+")");
            }


            dr.Close();
            conn.Close();
        }

        void LoadNonMed()
        {
            lblType.Text = "Non-drugs";
            label3.Text = "Non-drugs";
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from nonDrugs_tbl", conn);
            dr = cmd.ExecuteReader();
            comboMed.Items.Clear();

            while (dr.Read())
            {
                comboMed.Items.Add(dr.GetString("name").ToString() + "(" + dr.GetString("brand").ToString() + ")" + "(" + dr.GetString("usages").ToString() + ")");
            }


            dr.Close();
            conn.Close();
        }

        void LoadServices()
        {
            lblType.Text = "Services";
            label3.Text = "Services";
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from servicetbl", conn);
            dr = cmd.ExecuteReader();
            comboMed.Items.Clear();

            while (dr.Read())
            {
                comboMed.Items.Add(dr.GetString("service_type").ToString());
            }


            dr.Close();
            conn.Close();
        }
        Database db = new Database();

        private void comboMed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMed.SelectedIndex == -1)
                return;
            string price;
            if (lblType.Text.Equals("Medicine"))
            {
                MessageBox.Show(comboMed.SelectedItem.ToString().Remove(comboMed.SelectedItem.ToString().IndexOf('(')));
                string med = comboMed.SelectedItem.ToString().Remove(comboMed.SelectedItem.ToString().IndexOf('('));
                MessageBox.Show(db.getWhatFromWhere("price", "medicine_tbl", "name", med).Replace("₱", "").Replace(",", ""));
                price = Double.Parse(db.getWhatFromWhere("price", "medicine_tbl", "name", med).Replace("₱", "").Replace(",","")).ToString("C");
            }
            else if (lblType.Text.Equals("Non-drugs"))
                price = Double.Parse(db.getWhatFromWhere("price", "nondrugs_tbl", "name", comboMed.SelectedItem.ToString())).ToString("C");
            else
                price = Double.Parse(db.getWhatFromWhere("servicefee", "servicetbl", "service_Type", comboMed.SelectedItem.ToString())).ToString("C");
            lblUnitPrice.Text = price;
            lblTotal.Text = (Double.Parse(lblUnitPrice.Text.Substring(1)) * Double.Parse(txtQty.Text)).ToString("C");
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

            lblTotal.Text = (Double.Parse(lblUnitPrice.Text.Substring(1)) * Double.Parse(txtQty.Text)).ToString("C");
            }
            catch (FormatException) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "0" || txtQty.Text == "")
                return;
            string itemId;
            if (lblType.Text.Equals("Medicine"))
                itemId = db.getWhatFromWhere("id", "medicine_tbl", "name", comboMed.SelectedItem.ToString().Remove(comboMed.SelectedItem.ToString().IndexOf('(')));
            else if (lblType.Text.Equals("Non-drugs"))
                itemId = db.getWhatFromWhere("id", "nondrugs_tbl", "name", comboMed.SelectedItem.ToString());
            else
                itemId = db.getWhatFromWhere("serviceId", "servicetbl", "service_type", comboMed.SelectedItem.ToString());
            dataGridViewAddedItems.Rows.Add(new Object[] { itemId, comboMed.SelectedItem.ToString(), txtQty.Text, lblUnitPrice.Text.Substring(1), lblTotal.Text.Substring(1) });
            txtQty.Text = "1";
            lblUnitPrice.Text = "Unit Price";
            lblTotal.Text = "Total";
            comboMed.SelectedIndex = -1;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Delete))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
                e.Handled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void lblUnitPrice_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAddedItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nondrugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNonMed();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMedicine();
        }
    }
}
