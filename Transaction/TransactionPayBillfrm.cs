using MySql.Data.MySqlClient;
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

namespace CAPSTONEPROJ.Transaction
{
    public partial class TransactionPayBillfrm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
        Database db = new Database();
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataReader dr1;
        public TransactionPayBillfrm()
        {
          
            InitializeComponent();

        }

        double total = 0;
        string invoiceNumber;
        string fullname, address,id;
        public TransactionPayBillfrm(string invoiceNumber, string id)
        {

            /*       this.invoiceNumber = invoiceNumber;
                   InitializeComponent();
                   txtsearchInvoice.Text = invoiceNumber;
                   MySqlDataReader dr = data.getTotalAmount(invoiceNumber);
                   double total = 0;
                   while (dr.Read())
                   {
                       total += Double.Parse(dr.GetValue(0).ToString());
                   }
                   dataTablePane.Visible = false;
                   totalAmout = total + "";
                   amountAfterDiscount = totalAmout;
                   txttotalamount.Text = total.ToString("C");
                   txtdiscountedtotal.Text = total.ToString("C");
                   dr.Close();
                   data.closeConnection();
                   txtsearchInvoice.Enabled = false;*/
            MessageBox.Show(id);
            this.id = id;
            this.fullname = (db.getWhatFromWhere("firstname", "patienttbl", "id", id)+" "+ db.getWhatFromWhere("middlename", "patienttbl", "id", id)+" "+ db.getWhatFromWhere("lastname", "patienttbl", "id", id));
            

            this.invoiceNumber = invoiceNumber;
            InitializeComponent();
            txtsearchInvoice.Text = invoiceNumber;
            MySqlDataReader dr = data.getTotalAmount(invoiceNumber);
            //invoiceNumber = new Database().getInvoiceNumber(motherId);
            while (dr.Read())
            {
                total += Double.Parse(dr.GetValue(0).ToString().Replace("₱",""));
            }
            dataTablePane.Visible = false;
            totalAmout = total + "";
            amountAfterDiscount = totalAmout;
            txttotalamount.Text = total.ToString("C");
            txtdiscountedtotal.Text = total.ToString("C");
            dr.Close();
            data.closeConnection();
            txtsearchInvoice.Enabled = false;

        }

        public void searchInvoice(string searchValue)
        {
            string searchQuery = "SELECT `invoiceNumber` FROM `bills` WHERE invoiceNumber LIKE '%" + searchValue + "%' AND status = '0'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataTableInvoice.DataSource = table;
        }
        string totalAmout, amountAfterDiscount;

        private void TransactionPayBillfrm_Load(object sender, EventArgs e)
        {
            searchInvoice("");
            txtsearchInvoice.GotFocus += OnFocus;
            txtsearchInvoice.LostFocus += OnLostFocus;
            bindDiscount();
        }
        private void OnFocus(object sender, EventArgs e)
        {
            dataTablePane.Visible = true;
        }
        private async void OnLostFocus(object sender, EventArgs e)
        {

            await Task.Delay(1000);

            dataTablePane.Visible = false;
        }
        Database data = new Database();
        private void dataTableInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsearchInvoice.Text = dataTableInvoice.Rows[e.RowIndex].Cells[0].Value.ToString();
            MySqlDataReader dr = data.getTotalAmount(dataTableInvoice.Rows[e.RowIndex].Cells[0].Value.ToString());
            //invoiceNumber = new Database().getInvoiceNumber(motherId);
            double total = 0;
            while (dr.Read()) {
               total += Double.Parse(dr.GetValue(0).ToString());
            }
            dataTablePane.Visible = false;
            txttotalamount.Text = total.ToString("C");
            txtdiscountedtotal.Text = total.ToString("C");
            dr.Close();
            data.closeConnection();
        }
        public void bindDiscount()
        {
            connection.Open();
            cmd = new MySqlCommand("select * from discount_tbl", connection);
            dr = cmd.ExecuteReader();
            txtdiscount.Items.Add("Irregular(0%)");
            while (dr.Read())
            {
                txtdiscount.Items.Add(dr.GetValue(1).ToString()+"(" +dr.GetValue(2).ToString()+"%)");
            }
            dr.Close();
            connection.Close();
        }

        private void txtdiscountedtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtamounttender_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtamounttender_KeyDown(object sender, KeyEventArgs e)
        {
            //dapat integer lang
            
        }
        string input = "";
        private void txtamounttender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;


            if (!(char.IsNumber(e.KeyChar) || ((e.KeyChar == '.'))|| e.KeyChar == (char)Keys.Back)) {
                return;
            }

            if (e.KeyChar == (char)Keys.Back && (input.Length != 0))
            {
                input = input.Remove(input.Length - 1);
            }
            else if (e.KeyChar == (char)Keys.Back && (input.Length == 0))
            {

                return;
            }
            else if (((e.KeyChar == '.')) && input.Length == 0) {
                input = "0.";
            }
            else
            {
                input += e.KeyChar;
            }
            if (input.Length == 0)
            {
                txtamounttender.Text = (0).ToString("C");
            }
            else
                txtamounttender.Text = Double.Parse(input).ToString("C");
            /*
            if (char.IsNumber(e.KeyChar) || ((e.KeyChar == '.')))
            {
                if (txtamounttender.Text.Contains(".")&&e.KeyChar=='.')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.') {
                    
                }
            }
            else
                e.Handled = e.KeyChar != (char)Keys.Back;*/
        }

        private void txtamounttender_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                btnproceed.Enabled = Double.Parse(amountAfterDiscount) < Double.Parse(input);
                if (Double.Parse(amountAfterDiscount) < Double.Parse(input)) 
                    txtchange.Text = (Double.Parse(input) - Double.Parse(amountAfterDiscount )).ToString("C");
                else
                    txtchange.Text = (0).ToString("C");

            }
            catch (FormatException)
            {
                return;
            }
        }
        TransactionInpatientsfrm inpatientsfrm = new TransactionInpatientsfrm();
        DischargeIinformationfrm DischargeIinformationfrm = new DischargeIinformationfrm();

        private void btnproceed_Click(object sender, EventArgs e)
        {
                // MessageBox.Show((Double.Parse(amountAfterDiscount) < Double.Parse(input))+"");

            string pateintId = db.getWhatFromWhere("pateintId","bills","invoiceNumber",invoiceNumber);
            db.updateWhatFromWhere("status", "0", "patienttbl", "id", pateintId);
            db.updateWhatFromWhere("status", "1", "bills", "invoiceNumber", invoiceNumber);
            db.updateWhatFromWhere("status","0","roombed_tbl","roomBed_Id",db.getbedId(db.getWhatFromWhere("roomNumber", "admittedpateinttbl", "caseNumber", db.getcaseNo(pateintId)),db.getWhatFromWhere("bedNumber", "admittedpateinttbl", "caseNumber", db.getcaseNo(pateintId))));
            db.updateWhatFromWhere("discountType",txtdiscount.SelectedItem.ToString(),"bills", "invoiceNumber",invoiceNumber);
            db.updatestatuscasenumber(pateintId);
            //#update room status
            inpatientsfrm.dataGridViewAdmittedPatient.Refresh();
            MessageBox.Show("Paid successfully. Reciept is ready to print.","System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dr1 = db.getAddress(db.getWhatFromWhere("addressId", "patienttbl", "id", id));
            while (dr1.Read()) {
                address = (dr1.GetString(1)+", "+dr1.GetString(2)+","+dr1.GetString(3));
            }
            OR_Form print = new OR_Form(total,"Adil Mabang Laut",address,"111-111-111-111","Student");
            print.Show();

            inpatientsfrm.dataGridViewAdmittedPatient.Refresh();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dr1 = db.getAddress(db.getWhatFromWhere("addressId", "patienttbl", "id", id));

            while (dr1.Read())
            {
                address = (dr1.GetString(1) + ", " + dr1.GetString(1) + "," + dr1.GetString(1));
            }
            OR_Form print = new OR_Form(total, fullname, address, "111-111-111-111", "Student");
            print.Show();
        }

        private void TransactionPayBillfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void txtdiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] edit = txtdiscount.SelectedItem.ToString().ToCharArray();
            string ret;

            for (int a = edit.Length-1; a >= 0; a--) {
                if (edit[a] == '(') {
                    ret = txtdiscount.SelectedItem.ToString().Substring(a+1);
                    ret  = ret.Remove(ret.Length-2);
                    amountAfterDiscount = (Double.Parse(totalAmout) - (Double.Parse(totalAmout) * (Double.Parse(ret) * 0.01))).ToString();
                    txtdiscountedtotal.Text = (Double.Parse(totalAmout) - (Double.Parse(totalAmout) * (Double.Parse(ret) * 0.01))).ToString("C");
                    return;
                }
            }
        }
    }
}
