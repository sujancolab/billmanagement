using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadgev1
{
    public partial class PrintMeasure : UserControl
    {
        public static string s;
        public PrintMeasure()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(s);
            pictureBox1.ImageLocation = s;
        }

        private void PrintMeasure_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
            //pictureBox1.Image = Image.FromFile(s);
            //pictureBox1.ImageLocation = s;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
