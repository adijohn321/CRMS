using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace CAPSTONEPROJ.Transaction
{
    public partial class TransactionPaymentfrm : Form
    {
        public TransactionPaymentfrm()
        {
            InitializeComponent();
        }
        string name, id, invoice;
        public TransactionPaymentfrm(string id, string name, string invoice)
        {
            this.invoice = invoice;
            this.name = name;
            this.id = id;

            InitializeComponent();
        }

        private void txtAmountTender_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = (Double.Parse(txtAmountTender.Text) - Double.Parse(txtAmountDue.Text)).ToString("F");

        }

        private void PaymentFRM_Load(object sender, EventArgs e)
        {
           // BillingTransaction bt = new BillingTransaction();
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            BillingCrystalReport frm1 = new BillingCrystalReport();
            BillingReport breport = new BillingReport(invoice, id);
            ParameterField pf = new ParameterField();
            pf.ParameterFieldName = "name";
            ParameterDiscreteValue pd = new ParameterDiscreteValue();
            pd.Value = id;
            pf.CurrentValues.Add(pd);

            
            breport.crystalReportViewer1.ReportSource = frm1;

            frm1.SetParameterValue("id", id);
            frm1.SetParameterValue("name", name);
            breport.crystalReportViewer1.Refresh();
           


            breport.ShowDialog();
            //  BillingReport br = new BillingReport();
            //  br.ShowDialog();       


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
