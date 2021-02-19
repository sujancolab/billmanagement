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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text != txtrepass.Text)
            {
                txtpassword.Text = "";
                txtrepass.Text = "";
                lblerror.Text = "*Password Missmatch retype your Password";
            }
        }
        string photopath, signpath;
        private void btnbrowsephoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            photopath = openFileDialog1.FileName;
            pbPhoto.Image = Image.FromFile(photopath);
            pbPhoto.ImageLocation = photopath;
        }

        private void btnbrowseSign_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            signpath = openFileDialog1.FileName;

            pbSign.Image = Image.FromFile(signpath);
            pbSign.ImageLocation = signpath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text!=txtrepass.Text)
            {
                 lblerror.Text = "*Password Missmatch retype your Password";
            }
            else if (pbPhoto.ImageLocation == "1" || pbSign.ImageLocation == "1" )
            {
                lblerror.Text = "*Please select image !";
            }
            else if (comboBox1.Text == "---Select Role---" || txtname.Text == "" || txtpassword.Text == "")
            {
                lblerror.Text = "*Please fill all the fileds!";
            }
            else
            {
                lblerror.Text = "";
                if (pbPhoto.Image == null)
                { pbPhoto.Image = new Bitmap(16, 16); }
                if (pbSign.Image == null)
                { pbSign.Image = new Bitmap(16, 16); }
                SBGhadgev1.majordal.insertuser(txtname.Text, txtpassword.Text, comboBox1.Text, pbPhoto.Image, pbSign.Image);
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            pbSign.ImageLocation = "1";
            pbPhoto.ImageLocation = "1";
        }
    }
}
