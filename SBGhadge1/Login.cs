using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadge1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SBGhadgev1.Main.user = SBGhadgev1.majordal.getuser(txtname.Text, txtpassword.Text);
            if (SBGhadgev1.Main.user.Tables[0].Rows.Count > 0)
            {
                SBGhadgev1.Main m = new SBGhadgev1.Main();
                m.Show();
                this.Hide();

            }
            else { MessageBox.Show("Incorrect username or Password");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
