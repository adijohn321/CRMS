using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace CAPSTONEPROJ.Inquiry
{
    public partial class RecordsFRM : Form
    {
        Database db = new Database();
        public RecordsFRM()
        {
            InitializeComponent();
            dataGridViewRecord.DataSource = db.getCaseRecord();
        }

        private void RecordsFRM_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RecordsFRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
