using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPSTONEPROJ.Report.SalesReport;

namespace CAPSTONEPROJ.Report
{
    public partial class ReportSales : Form
    {
        public ReportSales()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewSales_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void SalesReport_Load(object sender, EventArgs e)
        {
            dataGridViewSales.DataSource = new Database().getSales(DateTime.Parse("2000-01-01"), DateTime.Parse("9999-12-31"));
            notecontent.Text = dataGridViewSales.Rows.Count.ToString();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridViewSales.DataSource = new Database().getSales(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            new SalesReports(dateTimePicker1.Value,dateTimePicker2.Value).Show();
        }
    }
}
