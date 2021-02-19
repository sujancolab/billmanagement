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
    public partial class AmtRptFrm : Form
    {
        public AmtRptFrm()
        {
            InitializeComponent();
        }
        public string mno;
        private void AmtRptFrm_Load(object sender, EventArgs e)
        {
            DataSet amountsheet = SBGhadgev1.majordal.getClaimedAmt(mno);

            Crp.AmtRpt rpt = new AmtRpt();
            rpt.SetDataSource(amountsheet);
            this.crystalReportViewer1.ReportSource = rpt;
            rpt.Refresh();
        }
    }
}
