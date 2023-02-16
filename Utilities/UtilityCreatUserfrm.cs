using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPSTONEPROJ.Utilities
{
    public partial class UtilityCreatUserfrm : Form
    {
        public UtilityCreatUserfrm()
        {
            InitializeComponent();
        }
        public UtilityCreatUserfrm(string name, string id)
        {
            this.name = name;
            this.id = id;
            InitializeComponent();
        }
        Database db = new Database();
        string name, id;

        private void btncreate_Click(object sender, EventArgs e)
        {
            int userlevel = cbType.SelectedIndex == 1? 1: 2;
            db.insertUser(lblname.Text,txtUsername.Text, txtPassword.Text , userlevel+"");
        }
    }
}
