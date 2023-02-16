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

namespace CAPSTONEPROJ.Transaction
{
    public partial class AMSTLandEINC : Form
    {
        string id, name;
        public AMSTLandEINC(string id, string name)
        {
            this.name = name;
            this.id = id;
            InitializeComponent();
            lblName.Text = name;
            lblIDNo.Text = id;


            MySqlConnection con = new Database().getConnection();
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            cmd.CommandText = "select * from amstlandeinc where  newbornid ='" + id + "'";
            cmd.ExecuteNonQuery();
            adapter.Fill(table);
            if (table.Rows.Count != 0)
            {
                string status = db.getWhatFromWhere("amstlEINC", "amstlandeinc", "newbornid", id);
                reverse(status);
                reverse(status);
                btnSave.Text = "Update";
                con.Close();
            }

        }
        Database db = new Database();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eincBox_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
 
            lbleinc.Text = "" + eincBox.CheckedItems.Count;
            if (eincBox.CheckedItems.Count == eincBox.Items.Count)
            {
                lbleinc.Text = "Completed";
                return;
            }
          
        }

        private void eincBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            lbleinc.Text = "" + eincBox.CheckedItems.Count;
            if (eincBox.CheckedItems.Count == eincBox.Items.Count)
            {
                lbleinc.Text = "Completed";
                return;
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AMSTLandEINC_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void eincBox_Click(object sender, EventArgs e)
        {
            lbleinc.Text = "" + eincBox.CheckedItems.Count;
            if (eincBox.CheckedItems.Count == eincBox.Items.Count)
            {
                lbleinc.Text = "Completed";
                return;
            }

        }

        private void eincBox_DoubleClick(object sender, EventArgs e)
        {
            lbleinc.Text = "" + eincBox.CheckedItems.Count;
            if (eincBox.CheckedItems.Count == eincBox.Items.Count)
            {
                lbleinc.Text = "Completed";
                return;
            }
        }

        private void amstlbox_Click(object sender, EventArgs e)
        {
            checkAmstl();
        }
        void checkAmstl() {
            lblamstl.Text = "" + amstlbox.CheckedItems.Count;
            if (amstlbox.CheckedItems.Count == amstlbox.Items.Count)
            {
                lblamstl.Text = "Completed";
                return;
            }
        }

        //first digit is the value of amstl
        string getAMSTLeinc() {
            string ret = "";
            ret += "" + amstlbox.CheckedItems.Count;
                for (int i = 0; i < amstlbox.Items.Count; i++) {
                    if (amstlbox.GetItemChecked(i)) {
                        ret += i;
                    }
                }
            ret += "" + eincBox.CheckedItems.Count;
                for (int i = 0; i < eincBox.Items.Count; i++)
                {
                    if (eincBox.GetItemChecked(i))
                    {
                    ret += i;
                    }
                }

            return ret;
        }
        void reverse(string input) {
            char[] arrayA = input.ToCharArray();
            lblamstl.Text = Int32.Parse(arrayA[0]+"") == 3 ? "Completed" : "" +arrayA[0];
            int i = 1;
            for (i=1; i <= Int32.Parse(arrayA[0]+""); i++) {
                amstlbox.SetItemChecked(Int32.Parse(arrayA[i] + ""), true);
            }
            lbleinc.Text = Int32.Parse(arrayA[i] + "") == 4 ? "Completed" : "" + arrayA[i];
            for (int x = 1; x <= Int32.Parse(arrayA[i] + ""); x++)
            {
                eincBox.SetItemChecked(Int32.Parse(arrayA[x+i]+""), true);
            }
        }

        private void amstlbox_DoubleClick(object sender, EventArgs e)
        {
            checkAmstl();
        }

        private void amstlbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkAmstl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Update")) {
                if (db.updateWhatFromWhere("amstlEINC", getAMSTLeinc(), "amstlandeinc", "newbornid", id)) {
                    MessageBox.Show("Information updated!");
                    return;
                }
            }
            if (db.insertAMSTLeinc(lblIDNo.Text, getAMSTLeinc())) {
                MessageBox.Show("Information saved!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reverse("2023012");
            reverse("2023012");
        }

        private void AMSTLandEINC_Load(object sender, EventArgs e)
        {

        }
    }
}
