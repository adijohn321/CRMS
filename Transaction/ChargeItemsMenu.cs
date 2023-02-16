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
    public partial class ChargeItemsMenu : Form
    {
        public ChargeItemsMenu()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveMed giveMed = new GiveMed();
            giveMed.TopLevel = false;
            giveMed.AutoScroll = true;
            viewPanel.Controls.Add(giveMed);
            giveMed.Show();
        }

        private void nondrugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveNonDrugs giveNonDrugs = new GiveNonDrugs();
            giveNonDrugs.TopLevel = false;
            giveNonDrugs.AutoScroll = true;
            viewPanel.Controls.Add(giveNonDrugs);
            giveNonDrugs.Show();
        }
    }
}
