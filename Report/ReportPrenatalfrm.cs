using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPSTONEPROJ.Report
{
    public partial class ReportPrenatalfrm : Form
    {
        public ReportPrenatalfrm()
        {
            InitializeComponent();
        }

        private void ReportPrenatalfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            new ReportDeliveries(dateTimePicker1.Value, dateTimePicker2.Value).Show();
        }
    }
}
