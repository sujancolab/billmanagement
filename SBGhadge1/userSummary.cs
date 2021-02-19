using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Runtime;
namespace SBGhadgev1
{
    public partial class userSummary : UserControl
    {
        public static string s;
        public userSummary()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(s);
            pictureBox1.ImageLocation = s;
        }
        
        private void userSummary_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
