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
    public partial class printsumarysheet : Form
    {
        public printsumarysheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    userSummary u = (userSummary)tabControl1.TabPages[i].Controls[0];
                    //tabControl1.TabPages[i].Controls.Clear();
                    //u.Dispose();


                    Printing._sourceFile = u.pictureBox1.ImageLocation;
                    Printing.Print();
                    ////userSummary.s = Printing._sourceFile;
                    //userSummary u1 = new userSummary();
                    //tabControl1.TabPages[i].Controls.Add(u1);

                }

            }
           
        }

        private void printsumarysheet_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            for (int i = 0; i <  tabControl1.TabPages.Count; i++)
            {
                userSummary u = (userSummary)tabControl1.TabPages[i].Controls[0];
              //  u.pictureBox1.Image = null;
                u.Dispose();
                tabControl1.TabPages[i].Controls.Clear();
            }
            tabControl1.TabPages.Clear();
            base.Dispose();
        }

        private void printsumarysheet_Load(object sender, EventArgs e)
        {

        }
    }
}
