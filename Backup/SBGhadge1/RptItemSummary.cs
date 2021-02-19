using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
namespace SBGhadgev1
{
    public partial class RptItemSummary : Form
    {
        DataSet ds;
        public RptItemSummary()
        {
            InitializeComponent();
        }

        private void RptItemSummary_Load(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            this.Text = "Loading...";
            if (textBox1.Text == "")
            {
                ds = majordal.getItemSumRpt(dtp1.Text, dtp2.Text);
                textBox1.Text = Convert.ToString(ds.Tables[1].Rows[0][0]);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                List<string> l = new List<string>();
                char[] ch = { ' ', ',' };
                string[] st = textBox1.Text.Split(ch);
                for (int i = 0; i < st.Length; i++)
                {
                    if (st[i].Contains("-"))
                    {
                        char[] ch1 = { '-' };
                        string[] st1 = st[i].Split(ch1);
                        int x1 = 0, x2 = 0;
                        if (st1.Length == 2)
                        {
                            int.TryParse(st1[0], out x1);
                            int.TryParse(st1[1], out x2);
                            if (x1 < x2)
                            {
                                for (int j = x1; j < x2; j++)
                                {
                                    l.Add(j.ToString());
                                }
                            }
                        }
                    }
                    else { l.Add(st[i]); }
                }

                ds = majordal.getItemSumRpt1(l);
                dataGridView1.DataSource = ds.Tables[0];
            }
            this.Text = "RptItemSummary";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Text = "Loading...";
            string path =Application.StartupPath;
            path = path.Replace("bin\\Debug", "");
            path += "\\Images";
            Excel.Workbook MyBook = null;
            Excel.Application MyApp = null;
            Excel.Worksheet MySheet = null;
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            //MyBook = MyApp.Workbooks.Open(path);
            //object missing = null;

            MyBook = MyApp.Workbooks.Open(path + "\\ItemSummary.xlsx",
   Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //Measuarment sheet
            MySheet = (Excel.Worksheet)MyBook.Sheets[1];
            int rowcount = 2;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                // MySheet.Cells[2, 1] = header;
                MySheet.Cells[rowcount, 1] = Convert.ToString(ds.Tables[0].Rows[i][0]);
                MySheet.Cells[rowcount, 2] = Convert.ToString(ds.Tables[0].Rows[i][1]);
                MySheet.Cells[rowcount, 3] = Convert.ToString(ds.Tables[0].Rows[i][2]);
                MySheet.Cells[rowcount, 4] = Convert.ToString(ds.Tables[0].Rows[i][3]);
                MySheet.Cells[rowcount, 5] = Convert.ToString(ds.Tables[0].Rows[i][4]);
                for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
                {
                    MySheet.Cells[rowcount, j+1] = Convert.ToString(ds.Tables[0].Rows[i][j]);
                    MySheet.Cells[1, j+1] = Convert.ToString(ds.Tables[0].Columns[j].ColumnName); 
                }
               
                rowcount++;
            }
            MyApp.Visible = true;
            this.Text = "RptItemSummary";
        }
    }
}
