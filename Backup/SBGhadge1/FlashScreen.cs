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
    public partial class FlashScreen : Form
    {
        public FlashScreen()
        {
            InitializeComponent();
        }

        private void FlashScreen_Load(object sender, EventArgs e)
        {
            SBGhadgev1.PointCanvas c = new SBGhadgev1.PointCanvas();
            this.panel1.Controls.Add(c);
        }
    }
}
