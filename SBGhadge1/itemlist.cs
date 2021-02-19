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
    public partial class itemlist : Form
    {
        public itemlist()
        {
            InitializeComponent();
        }

        private void itemlist_KeyPress(object sender, KeyPressEventArgs e)
        {
               if (Application.OpenForms["MeasurementSheet"] != null)
                {
                    if (SBGhadgev1.Measure.curcell == null)
                { return; }
                  ///  DataGridViewEditingControlShowingEventArgs de = new DataGridViewEditingControlShowingEventArgs(SBGhadgev1.Measure.curcell, SBGhadgev1.Measure.curcell.Style);
                  //((SBGhadgev1.Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[SBGhadgev1.Measure.curpageno - 1].Controls[0]).dataGridView1_EditingControlShowing(SBGhadgev1.Measure.curcell,de);
               }
               this.Hide();
        }
    }
}
