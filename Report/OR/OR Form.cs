using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPSTONEPROJ.Report.OR;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;

namespace CAPSTONEPROJ.Report.OR
{
    public partial class OR_Form : Form
    {
        string fullName, address, TIN, businessStyle, sum;
        double total;
        public OR_Form(double total, string fullName, string address, string TIN, string businessStyle)
        {
            this.address = address;
            this.fullName = fullName;
            this.TIN = TIN;
            this.total = total;
            this.businessStyle = businessStyle;
            InitializeComponent();
            this.sum = new PesoConverter().ConvertToWords(total + ""); 
        }

        private void OR_Form_Load(object sender, EventArgs e)
        {
            Print();

        }
        void Print() {
            CrystalDecisions.CrystalReports.Engine.TextObject totalAmount;
            CrystalDecisions.CrystalReports.Engine.TextObject txtFullname;
            CrystalDecisions.CrystalReports.Engine.TextObject txtAddress;
            CrystalDecisions.CrystalReports.Engine.TextObject txtSum;



            ORCrystalReport cr1 = new ORCrystalReport();
            crystalReportViewer1.ReportSource = cr1;


            txtFullname = cr1.ReportDefinition.ReportObjects["txtFullname"] as TextObject;
            txtFullname.Text = fullName;
            txtAddress = cr1.ReportDefinition.ReportObjects["txtAddress"] as TextObject;
            txtAddress.Text = address;
            totalAmount = cr1.ReportDefinition.ReportObjects["txtTotal"] as TextObject;
            totalAmount.Text = "" + total;

            txtSum = cr1.ReportDefinition.ReportObjects["txtSum"] as TextObject;
            txtSum.Text = sum;
            crystalReportViewer1.Refresh();

        }
    }
}
