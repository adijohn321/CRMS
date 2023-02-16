using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPSTONEPROJ
{
    public partial class WelcomeForm : Form
    {
        string name, level;
        public WelcomeForm(string name, string level)
        {
            InitializeComponent();
            this.name = name;
            this.level = level;
            lbllevel.Text = setUserLevel(level);
            lblname.Text = name;
        }
        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
            setTimeDate.Start();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm(name, level);
            frm.Show();
            this.Hide();
        }

        private void setTimeDate_Tick(object sender, EventArgs e)
        {
            DateTime dateTIme = DateTime.Now;
            this.lblTime.Text = dateTIme.ToString("hh:mm tt");
        }

        private void btnSetDateTime_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process time = System.Diagnostics.Process.Start("timedate.cpl");
        }
        public string setUserLevel(string input)
        {
            switch (input)
            {
                case "1":
                    return "Administrator";
                case "0":
                    return "Secretary";
                default:
                    return "Error";
            }
        }


    }
}
