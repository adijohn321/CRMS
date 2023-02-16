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

namespace CAPSTONEPROJ
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        MySqlConnection con = new Database().getConnection();
        Database data = new Database();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from users where username='" + txtboxusername.Text.Trim() + "' and password='" + txtboxpassword.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Incorect username and/or password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtboxusername.Text = "";
                    txtboxpassword.Text = "";
                    btnLogin.Enabled = false;
                }
                else
                {

                    MySqlDataReader reader = data.getUserLevel(txtboxusername.Text.Trim(), txtboxpassword.Text);
                    reader.Read();
                    WelcomeForm frm = new WelcomeForm(reader.GetValue(4).ToString(), reader.GetValue(3).ToString());
                    data.closeConnection();
                    frm.Show();
                    this.Hide();
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtboxusername_TextChanged(object sender, EventArgs e)
        {
            if (txtboxusername.Text == "")
            {
                btnLogin.Enabled = false;
                txtboxpassword.Enabled = false;
            }
            else
            {
                txtboxpassword.Enabled = true;
            }
        }

        private void txtboxpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtboxpassword.Text == "")
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }

        private void txtboxusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtboxusername.SelectionStart == 0)
            {
                if (e.KeyValue == 32)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (txtboxusername.Text == "")
            {
                btnLogin.Enabled = false;
                txtboxpassword.Enabled = false;
            }
            else
            {
                txtboxpassword.Enabled = true;
            }
            txtboxpassword.Enabled = false;
            btnLogin.Enabled = false;
        }

        private void BTNEXIT_Click_1(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Close the application.", "System Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.Cancel)
            {

            }
        }
    }
}
