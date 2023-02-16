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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace CAPSTONEPROJ.Transaction
{
    public partial class TransactionBillingfrm : Form
    {
       public string sql;
       public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
       public MySqlCommand cmd;
        MySqlDataReader dr;

        MySqlConnection con = new Database().getConnection();

        public TransactionBillingfrm()
        {
            InitializeComponent();
        }

        void LoadService()
        {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from priceTBL WHERE itemType = 'Service'", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbService.Items.Add(dr.GetString("itemName").ToString());
            }


            dr.Close();
            conn.Close();
        }

        void LoadMedicine()
        {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from priceTBL WHERE itemType = 'Medicine'", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbMedicine.Items.Add(dr.GetString("itemName").ToString());
            }


            dr.Close();
            conn.Close();
        }
        private void BillingTransaction_Load(object sender, EventArgs e)
        {
            //loadList();
            LoadService();
            LoadMedicine();
            lbldate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblinvoiceno.Text = (generateInvoiceNo());

        }
        string generateInvoiceNo() {
            string ret;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            Random rand = new Random();

            conn.Close();
            conn.Open();
                



            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            while (true)
            {
                ret = year + "" + month + "" + day + "00";
                for (int i = 0; i < 5; i++)
                {
                    ret += rand.Next(9);
                }
                cmd.CommandText = "select * from invoicetbl where  invoiceNo ='" + ret + "'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    con.Close();
                    return ret;
                }
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Print_Enter(object sender, EventArgs e)
        {

        }

        private void cbService_SelectedValueChanged(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from priceTBL where itemName = '" + cbService.SelectedItem + "'", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtservicefee.Text = dr.GetString("itemPrice");
                txtServiceTotal.Text = dr.GetString("itemPrice");
                itemNumber = dr.GetString("itemId");
            }


            dr.Close();
            conn.Close();
        }
        string itemNumber;
        private void cbMedicine_SelectedValueChanged(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            cmd = new MySqlCommand("Select * from priceTBL where itemName = '" + cbMedicine.SelectedItem + "'", conn);
            dr = cmd.ExecuteReader();
           

            while (dr.Read())
            {
                txtunitprice.Text = dr.GetString("itemPrice");
                itemNumber = dr.GetString("itemId");
            }


            dr.Close();
            conn.Close();
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(txtunitprice.Text);
                int qty = Convert.ToInt32(txtqty.Text);

                int totalprice = price * qty;

                txttotal.Text = totalprice.ToString();

            }
            catch (Exception) {

            }

        }
        void addService()
        {
            conn.Close();
            conn.Open();
            sql = "INSERT INTO add_to_list(description,qty,unit_price,total,invoice_no,invoice_date) VALUES( '"+ cbService.Text + "','" + "" + "', '" + txtservicefee.Text + "','" + txtServiceTotal.Text + "', '" + lblinvoiceno.Text + "', '" + lbldate.Text + "')";
            cmd = new MySqlCommand(sql, conn);
            int i;
            i = cmd.ExecuteNonQuery();
            conn.Close();
            loadList();
        }

        void addMedicine()
        {
            conn.Close();
            conn.Open();
            sql = "INSERT INTO add_to_list(description,qty,unit_price,total,invoice_no,invoice_date) VALUES( '" + cbMedicine.Text + "','" + txtqty.Text + "', '" + txtunitprice.Text + "','" + txttotal.Text + "', '" + lblinvoiceno.Text + "', '" + lbldate.Text + "')";
            cmd = new MySqlCommand(sql, conn);
            int i;
            i = cmd.ExecuteNonQuery();
            conn.Close();
            loadList();
        }

        public void loadList()
        {
            conn.Close();
            conn.Open();
            
            string query = "SELECT * FROM add_to_list WHERE invoice_no = '" + lblinvoiceno.Text + "' ";
            cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            var dt = new DataTable();
            da.Fill(dt);
            dataGridViewAddedItems.DataSource = dt;
            conn.Close();
        }




        /*private void button1_Click(object sender, EventArgs e)
        {
            addMedicine();
            clearMedicine();
        }
         private void btnaddlist_Click(object sender, EventArgs e)
        {
            addService();
            clearMedicine();
        }*/
         
         




        private void button1_Click(object sender, EventArgs e)
        {
            if (cbMedicine.SelectedIndex == -1)
                return;
            if (txtqty.Text == "")
            {
                txtqty.Select();
                return;
            }
            dataGridViewAddedItems.Rows.Add(new Object[] { itemNumber, cbMedicine.SelectedItem.ToString(), txtqty.Text, txtunitprice.Text, txttotal.Text });
            total += Double.Parse(txttotal.Text);
            txtTotalAmount.Text = "" + total.ToString("F");
            clearMedicine();

        }
        private double total = 0;

        private void btnaddlist_Click(object sender, EventArgs e)
        {
            if (cbService.SelectedIndex == -1)
                return;
            dataGridViewAddedItems.Rows.Add(new Object[] { itemNumber, cbService.SelectedItem.ToString(), 1, txtservicefee.Text, txtservicefee.Text });
            total += Double.Parse(txtServiceTotal.Text);
            txtTotalAmount.Text = "" + total.ToString("F");
            clearService();

        }

        void clearService() {
            cbService.SelectedIndex = -1;
            txtservicefee.Text = "";
            txtServiceTotal.Text = "";
        }
        void clearMedicine()
        {
            cbMedicine.SelectedIndex = -1;
            txtqty.Text = "";
            txtunitprice.Text = "";
            txttotal.Text = "";
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

            txtVAT.Text = (Double.Parse(txtTotalAmount.Text) * 0.11).ToString("F");

            txtSubTotal.Text = (Double.Parse(txtTotalAmount.Text) - Double.Parse(txtVAT.Text)).ToString("F");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtTotalAmount.Text) <= 0)
                return;

                conn.Close();
                conn.Open();
            DateTime date = DateTime.Now;
            for (int range = dataGridViewAddedItems.Rows.Count; range > 0; range--) {
                sql = "INSERT INTO invoicetbl(invoiceNo,pateintId,itemId,quantity,date) VALUES( '" + lblinvoiceno.Text + "','" + lblid.Text + "', '" + dataGridViewAddedItems.Rows[range-1].Cells[0].Value.ToString() + "','" + dataGridViewAddedItems.Rows[range-1].Cells[2].Value.ToString() + "', '" + date + "')";
                cmd = new MySqlCommand(sql, conn);
                int i;
                i = cmd.ExecuteNonQuery();
            }

            conn.Close();

            TransactionPaymentfrm frm = new TransactionPaymentfrm(lblid.Text, lblpatientname.Text, lblinvoiceno.Text);
            frm.txtAmountDue.Text = txtTotalAmount.Text;
            frm.ShowDialog(); 

        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serviceMedicineBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
