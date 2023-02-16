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
    public partial class Apgarscorefrm : Form
    {
        string name, id;
        public Apgarscorefrm(string id, string name)
        {
            this.name = name;
            this.id = id;
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;
        }
        public Apgarscorefrm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Apgarscorefrm_Load(object sender, EventArgs e)
        {

        }
        void calculateApgar() {
            int apgar = 0;
            if (txtAppearance.Text.Length != 0)
                apgar += Int32.Parse(txtAppearance.Text);
            if (txtpulse.Text.Length != 0)
                apgar += Int32.Parse(txtpulse.Text);
            if (txtgrimace.Text.Length != 0)
                apgar += Int32.Parse(txtgrimace.Text);
            if (txtactivity.Text.Length != 0)
                apgar += Int32.Parse(txtactivity.Text);
            if (txtrespiration.Text.Length != 0)
                apgar += Int32.Parse(txtrespiration.Text);
            lblScore.Text = apgar + "/10";
        }

        private void rdthan100_CheckedChanged(object sender, EventArgs e)
        {
            if (rdabsentp.Checked)
                txtpulse.Text = "0";
            else if (rdless100.Checked)
                txtpulse.Text = "1";
            else
                txtpulse.Text = "2";

            calculateApgar();

        }

        private void rdFloppy_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdFloppy.Checked)
                txtgrimace.Text = "0";
            else if (rdGrimace.Checked)
                txtgrimace.Text = "1";
            else
                txtgrimace.Text = "2";
            calculateApgar();
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdabsentA.Checked)
                txtactivity.Text = "0";
            else if (radioButton8.Checked)
                txtactivity.Text = "1";
            else
                txtactivity.Text = "2";
            calculateApgar();

        }

        private void rdvigorous_CheckedChanged(object sender, EventArgs e)
        {
            if (rdabsentR.Checked)
                txtrespiration.Text = "0";
            else if (rdslowirreg.Checked)
                txtrespiration.Text = "1";
            else
                txtrespiration.Text = "2";
            calculateApgar();
        }


        private void rdPale_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdPale.Checked)
                txtAppearance.Text = "0";
            else if(rdBlue.Checked)
                txtAppearance.Text = "1";
            else
                txtAppearance.Text = "2";
            calculateApgar();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (db.insertApgar(id, txtAppearance.Text, txtpulse.Text, txtgrimace.Text, txtactivity.Text, txtrespiration.Text, lblScore.Text))
                MessageBox.Show("Successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        Database db = new Database();


    }
}
