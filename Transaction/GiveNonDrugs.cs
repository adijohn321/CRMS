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
    public partial class GiveNonDrugs : Form
    {
       
        public string sql;
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        public MySqlCommand cmd;
        MySqlDataReader dr;
        Database db = new Database();
        MySqlConnection con = new Database().getConnection();
        string invoiceNumber, id;
        public GiveNonDrugs()
        {
            InitializeComponent();
        }
        public GiveNonDrugs(string invoiceNumber, string id)
        {
            this.invoiceNumber = invoiceNumber;
            this.id = id;
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < dataGridViewAddedItems.Rows.Count; a++)
            {
                db.insertInvoice(invoiceNumber,id, dataGridViewAddedItems.Rows[a].Cells[0].Value.ToString(), dataGridViewAddedItems.Rows[a].Cells[2].Value.ToString(), dataGridViewAddedItems.Rows[a].Cells[4].Value.ToString());

            }
            MessageBox.Show("Non-drugs already given.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void comboNonDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNonDrugs.SelectedIndex == -1)
                return;
            lblUnitPrice.Text = Double.Parse(db.getWhatFromWhere("itemPrice", "priceTbl", "itemName", comboNonDrugs.SelectedItem.ToString())).ToString("C");
            lblTotal.Text = (Double.Parse(lblUnitPrice.Text.Substring(1)) * Double.Parse(txtQty.Text)).ToString("C");
        }
        void LoadMedicine()
        {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from nondrugs_tbl", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboNonDrugs.Items.Add(dr.GetString("itemName").ToString());
            }


            dr.Close();
            conn.Close();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lblTotal.Text = (Double.Parse(lblUnitPrice.Text.Substring(1)) * Double.Parse(txtQty.Text)).ToString("C");
            }
            catch (FormatException) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "0" || txtQty.Text == "")
                return;
            dataGridViewAddedItems.Rows.Add(new Object[] { db.getWhatFromWhere("itemId", "priceTbl", "itemName", comboNonDrugs.SelectedItem.ToString()), comboNonDrugs.SelectedItem.ToString(), txtQty.Text, lblUnitPrice.Text.Substring(1), lblTotal.Text.Substring(1) });
            txtQty.Text = "1";
            lblUnitPrice.Text = "Unit Price";
            lblTotal.Text = "Total";
            comboNonDrugs.SelectedIndex = -1;
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

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtQty.Text = (Int16.Parse(txtQty.Text) + 1) + "";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Int16.Parse(txtQty.Text) == 1)
                return;
            txtQty.Text = (Int16.Parse(txtQty.Text) - 1) + "";
        }
    }
}
