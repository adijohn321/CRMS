using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPSTONEPROJ.Inquiry
{
    public partial class InquiryMotherProfile : Form
    {
        public InquiryMotherProfile()
        {
            InitializeComponent();
        }
        Database db = new Database();
        string id, name;
        public InquiryMotherProfile(string id, string name)
        {
            this.name = name;
            this.id = id;
            InitializeComponent();
            lblIDNo.Text = id;
            lblName.Text = name;
            dataGridViewMotherHistory.DataSource = db.getHistory(id);
        }

        private void InquiryMotherProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfileFRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
