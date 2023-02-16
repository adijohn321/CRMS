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
    public partial class ReportNewbornfrm : Form
    {
        public ReportNewbornfrm()
        {
            InitializeComponent();
        }

        private void ReportNewbornfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ReportNewbornfrm_Load(object sender, EventArgs e)
        {
            dataGridViewNewborn.DataSource = new Database().getDelivery(DateTime.Parse("2000-01-01"), DateTime.Parse("9999-12-31"));
            notecontent.Text = dataGridViewNewborn.Rows.Count.ToString();
        }

        private void dataGridViewNewborn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridViewNewborn.DataSource = new Database().getDelivery(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            new ReportDeliveries(dateTimePicker1.Value, dateTimePicker2.Value).Show();
        }

        private void dataGridViewNewborn_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
