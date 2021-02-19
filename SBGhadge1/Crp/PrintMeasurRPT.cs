using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadge1.Crp
{
    public partial class PrintMeasurRPT : Form
    {
        public PrintMeasurRPT()
        {
            InitializeComponent();
        }
        public string Mno;
        private void PrintMeasurRPT_Load(object sender, EventArgs e)
        {
            SBGhadge1.Crp.MreasureRpt rpt = new SBGhadge1.Crp.MreasureRpt();
            DataSet DSMeasure= SBGhadgev1.majordal.get(Mno);
            rpt.SetDataSource(DSMeasure);
            crystalReportViewer1.ReportSource = rpt;
            rpt.Refresh();
        }
    }
}
