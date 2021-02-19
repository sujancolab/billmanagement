using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadgev1
{
    public partial class PrintMeasurmentSheet : Form
    {
        public PrintMeasurmentSheet()
        {
            InitializeComponent();
        }

        private void PrintMeasurmentSheet_Load(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            pDialog.AllowSelection = true;
            pDialog.AllowSomePages = true;
            pDialog.AllowCurrentPage = true;
            Printing.pds = new System.Drawing.Printing.PrintDocument();
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                Printing.pds.PrinterSettings = pDialog.PrinterSettings;
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    if (pDialog.PrinterSettings.ToPage > 0)
                    {
                        if (i > pDialog.PrinterSettings.ToPage - 1 || i < pDialog.PrinterSettings.FromPage - 1)
                        { continue; }
                    }
                    PrintMeasure u = (PrintMeasure)tabControl1.TabPages[i].Controls[0];
                    Printing._sourceFile = u.pictureBox1.ImageLocation;
                    Printing.Print();
                }
            }
        }
    }
}
