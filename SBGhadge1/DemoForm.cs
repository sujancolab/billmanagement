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
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void DemoForm_Load(object sender, EventArgs e)
        {
            SBGhadgev1.PointCanvas p = new SBGhadgev1.PointCanvas();
            p.Location = new Point(50, 0);
            this.Controls.Add(p);
        }
    }
}
