using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.AccessControl;
namespace SBGhadgev1
{
    public partial class SummarySheet : Form
    {
        public string[] SectionSeq = { "Fabrication & Erection", "Only Dismantling","Labour Supply",
                                         "Dismantling & Refitting", "EQ Erection", "EQ Dismantling",
                                         "EQ Shifting","EQ Loading","EQ Unloading","A.C. Sheet" };
        public SummarySheet()
        {
            InitializeComponent();
        }

        private void SummarySheet_Load(object sender, EventArgs e)
        {
            //SectionSeq = new string[8];
            //SectionSeq[0] = "Fabrication & Erection";
            //SectionSeq[1] = "Only Dismantling";
            //SectionSeq[2] = "Dismantling & Refitting";
            //SectionSeq[3] = "EQ Erection";
            //SectionSeq[4] = "EQ Dismantling";
            //SectionSeq[5] = "EQ Shifting";
            //SectionSeq[6] = "EQ Loading";
            //SectionSeq[7] = "A.C. Sheet";
            // int p = compitemcode("A-12A", "A-12D");

        }
        public DataTable getSameitems(DataSet ds, string itemcode)
        {
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("ID");
            ds1.Columns.Add("srno");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("cat");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("qty");
            ds1.Columns.Add("unitrate");
            ds1.Columns.Add("amount");
            ds1.Columns.Add("type");
            ds1.Columns.Add("mno");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToString(ds.Tables[0].Rows[i][3]) == itemcode)
                {
                    DataRow r = ds1.NewRow();
                    r[0] = ds.Tables[0].Rows[i][0].ToString();
                    r[1] = ds.Tables[0].Rows[i][1].ToString();
                    r[2] = ds.Tables[0].Rows[i][2].ToString();
                    r[3] = ds.Tables[0].Rows[i][3].ToString();
                    r[4] = ds.Tables[0].Rows[i][4].ToString();
                    r[5] = ds.Tables[0].Rows[i][5].ToString();
                    r[6] = ds.Tables[0].Rows[i][6].ToString();
                    r[7] = ds.Tables[0].Rows[i][7].ToString();
                    r[8] = ds.Tables[0].Rows[i][8].ToString();
                    r[9] = ds.Tables[0].Rows[i][9].ToString();
                    r[10] = ds.Tables[0].Rows[i][10].ToString();
                    r[11] = ds.Tables[0].Rows[i][11].ToString();
                    r[12] = ds.Tables[0].Rows[i][12].ToString();
                    ds1.Rows.Add(r);
                }
            }
            return ds1;
        }
        public static string[] trimitemcode(string code)
        {
            List<string> lst = new List<string>();
            string temp = "";
            // int Carflag = 0;
            int digflag = 0;
            foreach (char c in code)
            {
                if (char.IsLetter(c))
                {
                    if (digflag == 1)
                    { }
                    digflag = 0;
                    if (temp != "")
                    { lst.Add(temp); temp = ""; }

                    temp += c.ToString();
                }
                if (char.IsDigit(c))
                {
                    if (digflag == 0)
                    {
                        lst.Add(temp);
                        temp = "";
                        temp += c.ToString();
                        digflag = 1;
                    }
                    else { temp += c.ToString(); }

                }

            }
            if (temp != "")
            { lst.Add(temp); temp = ""; }
            if (lst.Count > 3)
            {
                int mp = 0;

            }
            return lst.ToArray();
        }
        public int compitemcode(string code1, string code2)
        {
            //if (code1.Contains("E-14"))
            //{

            //    int kl = 0;
            //}
            try
            {
                if (code1 == code2)
                { return 0; }
                string[] st1 = trimitemcode(code1);
                string[] st2 = trimitemcode(code2);
                int cmp = 0;
                //if(st1.Length>3||st2.Length>3)
                //{


                //}
                if (st1[0] == st2[0])
                {
                    if (Convert.ToInt32(st1[1]) == Convert.ToInt32(st2[1]))
                    {
                        if (st1[2] == st2[2])
                        {
                            return 0;
                        }
                        else
                        {
                            cmp = string.Compare(st1[2], st2[2]);
                            return cmp / Math.Abs(cmp);
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(st1[1]) > Convert.ToInt32(st2[1]))
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                }
                else
                {
                    cmp = string.Compare(st1[0], st2[0]);
                    return cmp / Math.Abs(cmp);

                }
            }
            catch (Exception ex)
            { }

            return 0;
        }

        public bool ischecked(int[] ar, int x)
        {
            if (ar[x] == 1) { return true; }
            return false;
        }
        public int Getsize(string size1)
        {
            string[] sizes = new string[10];
            sizes[0] = string.Format("1/2{0}", '"');
            sizes[1] = string.Format("3/4{0}", '"');
            sizes[2] = string.Format("1{0}", '"');
            sizes[3] = string.Format("1 1/2{0}", '"');
            sizes[4] = string.Format("2{0}", '"');
            sizes[5] = string.Format("2 1/2{0}", '"');
            sizes[6] = string.Format("3{0}", '"');
            sizes[7] = string.Format("4{0}", '"');
            sizes[8] = string.Format("6{0}", '"');
            sizes[9] = string.Format("8{0}", '"');
            int k = -1;
            for (int i = 0; i < sizes.Length; i++)
            {
                if (size1 == sizes[i])
                { k = i; break; }
            }
            return k;
        }
        public int Getsize(string size1, DataSet ds)
        {
            string[] sizes = new string[10];
            sizes[0] = string.Format("1/2{0}", '"');
            sizes[1] = string.Format("3/4{0}", '"');
            sizes[2] = string.Format("1{0}", '"');
            sizes[3] = string.Format("1 1/2{0}", '"');
            sizes[4] = string.Format("2{0}", '"');
            sizes[5] = string.Format("2 1/2{0}", '"');
            sizes[6] = string.Format("3{0}", '"');
            sizes[7] = string.Format("4{0}", '"');
            sizes[8] = string.Format("6{0}", '"');
            sizes[9] = string.Format("8{0}", '"');
            int k = -1;
            if (ds.Tables[0].Rows.Count < 10)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (size1 == Convert.ToString(ds.Tables[0].Rows[i][0]))
                    { k = i; break; }
                }
            }
            return k;
        }
        public DataSet Sortitems(DataSet ds)
        {
            DataSet ds2 = new DataSet();
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            int[] rownum = new int[ds.Tables[0].Rows.Count];
            int min = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                min = 0;
                string itemcode = Convert.ToString(ds.Tables[0].Rows[i][0]);
                for (int j = i; j < ds.Tables[0].Rows.Count; j++)
                {                    
                     int p = compitemcode(itemcode, Convert.ToString(ds.Tables[0].Rows[j][0]));
                    if (p == 1)
                    {
                        itemcode = Convert.ToString(ds.Tables[0].Rows[j][0]);
                        min = j;
                        DataRow dr = ds1.NewRow();
                        dr[0] = ds.Tables[0].Rows[i][0].ToString();
                        dr[1] = ds.Tables[0].Rows[i][1].ToString();
                        //dr[2] = ds.Tables[0].Rows[i][2].ToString();
                        //dr[3] = ds.Tables[0].Rows[i][3].ToString();
                        //dr[4] = ds.Tables[0].Rows[i][4].ToString();
                        //dr[5] = ds.Tables[0].Rows[i][5].ToString();
                        ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                        ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                        //ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                        //ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                        //ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                        //ds.Tables[0].Rows[i][5] = ds.Tables[0].Rows[j][5];
                        ds.Tables[0].Rows[j][0] = dr[0];
                        ds.Tables[0].Rows[j][1] = dr[1];
                        //ds.Tables[0].Rows[j][2] = dr[2];
                        //ds.Tables[0].Rows[j][3] = dr[3];
                        //ds.Tables[0].Rows[j][4] = dr[4];
                        //ds.Tables[0].Rows[j][5] = dr[5];
                    }
                }
            }
            ds2.Tables.Add(ds1);
            return ds;
        }
        public DataSet Composeitems(DataSet ds,string cat,string mno)
        {
            DataSet ds2 = new DataSet();
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            int[] rownum = new int[ds.Tables[0].Rows.Count];
            int min = 0;
            List<string> lst = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                min = 0;
                string itemcode = Convert.ToString(ds.Tables[0].Rows[i][0]);
                string subcat=Convert.ToString(ds.Tables[0].Rows[i][1]);
                int presentflag = 0;
                for (int k = 0; k < lst.Count; k++)
                {
                    if (subcat == lst[k])
                    { presentflag = 1;break; } 
                }
                if (presentflag == 1)
                { continue; }
                lst.Add(subcat);
                DataSet dx = majordal.getmeasureSumSeq1(mno, cat, subcat);
                for (int j = 0; j < dx.Tables[0].Rows.Count; j++)
                {
                    
                        DataRow dr = ds1.NewRow();
                        dr[0] = itemcode;
                        dr[1] = subcat;
                        dr[2] = dx.Tables[0].Rows[j][2].ToString();
                        dr[3] = dx.Tables[0].Rows[j][3].ToString();
                        dr[4] = dx.Tables[0].Rows[j][4].ToString();
                        dr[5] = dx.Tables[0].Rows[j][5].ToString();
                        ds1.Rows.Add(dr);
                      
                    
                }
            }
            ds2.Tables.Add(ds1);
            return ds2;
        }
        public DataSet Orderitems(DataSet ds)
        {
            DataSet ds2 = new DataSet();
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            int[] rownum = new int[ds.Tables[0].Rows.Count];
            int min = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                min = 0;
                string itemcode = Convert.ToString(ds.Tables[0].Rows[i]["itemcode"]);
                string pageno = Convert.ToString(ds.Tables[0].Rows[i]["pageno"]);
                int z = i;
                while (Convert.ToString(ds.Tables[0].Rows[z]["itemcode"]) == itemcode)
                {
                    z++;
                    if (z >= ds.Tables[0].Rows.Count)
                    { break; }
                }
                for (int m = i; m < z; m++)
                {
                    min = m;
                    pageno = Convert.ToString(ds.Tables[0].Rows[m]["pageno"]);
                    for (int j = m; j < z; j++)
                    {
                        int p = Convert.ToInt32(ds.Tables[0].Rows[j]["pageno"]);
                        if (p < Convert.ToInt32(pageno))
                        {
                            itemcode = Convert.ToString(ds.Tables[0].Rows[j]["itemcode"]);
                            min = j;
                            pageno = Convert.ToString(ds.Tables[0].Rows[min]["pageno"]);                           
                            DataRow dr = ds1.NewRow();
                            dr[0] = ds.Tables[0].Rows[m][0].ToString();
                            dr[1] = ds.Tables[0].Rows[m][1].ToString();
                            dr[2] = ds.Tables[0].Rows[m][2].ToString();
                            dr[3] = ds.Tables[0].Rows[m][3].ToString();
                            dr[4] = ds.Tables[0].Rows[m][4].ToString();
                            dr[5] = ds.Tables[0].Rows[m][5].ToString();                            
                            ds.Tables[0].Rows[m][0] = ds.Tables[0].Rows[j][0];
                            ds.Tables[0].Rows[m][1] = ds.Tables[0].Rows[j][1];
                            ds.Tables[0].Rows[m][2] = ds.Tables[0].Rows[j][2];
                            ds.Tables[0].Rows[m][3] = ds.Tables[0].Rows[j][3];
                            ds.Tables[0].Rows[m][4] = ds.Tables[0].Rows[j][4];
                            ds.Tables[0].Rows[m][5] = ds.Tables[0].Rows[j][5];                            
                            ds.Tables[0].Rows[j][0] = dr[0];
                            ds.Tables[0].Rows[j][1] = dr[1];
                            ds.Tables[0].Rows[j][2] = dr[2];
                            ds.Tables[0].Rows[j][3] = dr[3];
                            ds.Tables[0].Rows[j][4] = dr[4];
                            ds.Tables[0].Rows[j][5] = dr[5];                           
                        }
                    }
                } i = z-1;
            }
            ds2.Tables.Add(ds1);
            return ds;
        }
        public DataGridView Del_dup(DataGridView d)
        {
            for (int i = d.Rows.Count-1; i >=1;  i--)
            {
                int flag = 0;
                for (int j = 3; j < 12; j++)
                {
                    string s1 = Convert.ToString(d.Rows[i].Cells[j].Value);
                    if (Convert.ToString(d.Rows[i].Cells[j].Value) != Convert.ToString(d.Rows[i-1].Cells[j].Value))
                    { flag = 1; break; }
                }
                if (flag == 0)
                { d.Rows.Remove(d.Rows[i]); }
            }
            return d;
        
        }
        public DataGridView getnormalGrid(DataSet ds, int startindex, string cat, string mno, int seqno, out int last)
        {
            Summary s = new Summary();
            DataGridView d = s.dataGridView1;
            DataTable ds1 = new DataTable();  
           // int fristflg=0;
            ds1.Columns.Add("itemcode");         
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            d.Rows.Clear();
            int lastindex = startindex;
            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);
            while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
            {
                lastindex++;
                if (lastindex >= ds.Tables[0].Rows.Count)
                { break; }

            }
            last = lastindex;
            string pageno = "";
            int k = d.Rows.Add();
            d.Rows[k].Cells[2].Value = itemname;
           // d.Rows[k].Cells[0].Value = seqno.ToString();
            for (int n = startindex; n < lastindex; n++)
            {
                if (pageno != Convert.ToString(ds.Tables[0].Rows[n][3]))
                {
                    pageno = Convert.ToString(ds.Tables[0].Rows[n][3]);
                    k = d.Rows.Add();
                    d.Rows[k].Cells[1].Value = pageno;
                    int l = Getsize(ds.Tables[0].Rows[n][2].ToString());
                    if (l != -1)
                    {
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                        d.Rows[k].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        DataRow dr = ds1.NewRow();
                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n][0]);
                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n][1]);
                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n][2]);
                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n][3]);
                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n][4]);
                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n][5]);
                        ds1.Rows.Add(dr);
                    }
                }
                else
                {
                    int l = Getsize(ds.Tables[0].Rows[n][2].ToString());
                    if (l != -1)
                    {
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                        d.Rows[k].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        DataRow dr = ds1.NewRow();
                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n][0]);
                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n][1]);
                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n][2]);
                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n][3]);
                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n][4]);
                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n][5]);
                        ds1.Rows.Add(dr);
                    }
                }//end of if eles of pgno

            }//end of for loop
          
            if (d.Rows.Count >2)
            {
                k = d.Rows.Add();
                for (int j = 2; j < 12; j++)
                {
                    double sum = 0;
                    for (int i = 1; i < d.Rows.Count - 1; i++)
                    {
                        //MessageBox.Show(Convert.ToString(d.Rows[i].Cells[j].Value));
                        double no = 0;
                        if (double.TryParse(Convert.ToString(d.Rows[i].Cells[j].Value), out no))
                        { no = double.Parse(Convert.ToString(d.Rows[i].Cells[j].Value)); }
                        sum += no;
                    }
                    if (sum != 0)
                    {
                        d.Rows[k].Cells[j].Value = sum.ToString();
                    }
                }
                d.Rows[k].Cells[1].Value = "Total";
                // k = d.Rows.Add();
            }
            d = Del_dup(d);
            // out of size items
            for (int i = 0; i < ds1.Rows.Count; i++)
            {
                k = d.Rows.Add();
                DataSet ds2 = majordal.getmeasureSumwithDesc2(mno, cat, ds1.Rows[i][1].ToString(), Convert.ToString(ds1.Rows[i][3]), Convert.ToString(ds1.Rows[i][2]), Convert.ToString(ds1.Rows[i][5]));
                d.Rows[k].Cells[1].Value = Convert.ToString(ds1.Rows[i][3]);
                d.Rows[k].Cells[2].Value = Convert.ToString(ds1.Rows[i][5]) + Convert.ToString(ds1.Rows[i][2]) + "     " + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "  " + Convert.ToString(ds1.Rows[i][4]);
            }
            return d;
        }
        public DataGridView getShiftingGrid(DataSet ds, int startindex, string cat, string mno, int seqno, out int last)
        {
            Summary s = new Summary();
            ds = Orderitems(ds);
            DataGridView d = s.dataGridView1;
            DataTable ds1 = new DataTable();
            // int fristflg=0;
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            d.Rows.Clear();
            int lastindex = startindex;
            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);
            while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
            {
                lastindex++;
                if (lastindex >= ds.Tables[0].Rows.Count)
                { break; }

            }
            last = ds.Tables[0].Rows.Count;
            string pageno = "";

            for (int n = startindex; n < ds.Tables[0].Rows.Count; n++)
            {
                int k = d.Rows.Add();
                d.Rows[k].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[n][3]);
                DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                d.Rows[k].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[n][1]) + "     " + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "  " + Convert.ToString(ds.Tables[0].Rows[n][4]);
                //d.Rows[k].Cells[0].Value = seqno.ToString();
               // seqno++;
            }//end of for loop

           
            return d;
        }
      
        
        public DataGridView getfabGrid(DataSet ds, int startindex, string cat, string mno, int seqno, out int last)
        {
            int  fristflg=0;//flagSize = 0 ,
            //if (seqno == 32)
            //{ 
            //    int p = 0;
            //}
            Summary s = new Summary();
            DataGridView d = s.dataGridView1;
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            d.Rows.Clear();
            int lastindex = startindex;
            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);
            while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
            {
                lastindex++;
                if (lastindex >= ds.Tables[0].Rows.Count)
                { break; }

            }
            last = lastindex;
            string pageno = "";
            int k = d.Rows.Add();
            d.Rows[k].Cells[2].Value = itemname;
            d.Rows[k].Cells[0].Value = seqno.ToString();
            if (seqno == 31)
            {
                int cy = 0;
            }
            for (int n = startindex; n < lastindex; n++)
            {
                if (pageno != Convert.ToString(ds.Tables[0].Rows[n][3]))
                {
                    pageno = Convert.ToString(ds.Tables[0].Rows[n][3]);
                    k = d.Rows.Add();
                    d.Rows[k].Cells[1].Value = pageno;
                    int l = Getsize(ds.Tables[0].Rows[n][2].ToString());
                    if (l != -1 )
                    {
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                        d.Rows[k].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        DataRow dr = ds1.NewRow();
                        d.Rows.RemoveAt(k);
                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n][0]);
                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n][1]);
                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n][2]);
                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n][3]);
                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n][4]);
                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n][5]);
                        ds1.Rows.Add(dr);
                        //if (Convert.ToString(ds.Tables[0].Rows[n][2])!="")
                        //{
                        //    flagSize = 1;
                        //}
                        //fristflg = 1; (Corrected on 12/10/16)
                    }
                }
                else
                {
                    int l = Getsize(ds.Tables[0].Rows[n][2].ToString());
                    if (l != -1)
                    {
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                        if (k >= d.Rows.Count)
                        { k = d.Rows.Add();
                         d.Rows[k].Cells[1].Value = pageno;
                        }
                        d.Rows[k].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        if (fristflg == 0)
                        {
                            DataRow dr = ds1.NewRow();
                            //d.Rows.RemoveAt(k);
                            dr[0] = Convert.ToString(ds.Tables[0].Rows[n][0]);
                            dr[1] = Convert.ToString(ds.Tables[0].Rows[n][1]);
                            dr[2] = Convert.ToString(ds.Tables[0].Rows[n][2]);
                            dr[3] = Convert.ToString(ds.Tables[0].Rows[n][3]);
                            dr[4] = Convert.ToString(ds.Tables[0].Rows[n][4]);
                            dr[5] = Convert.ToString(ds.Tables[0].Rows[n][5]);
                            ds1.Rows.Add(dr);
                            if (Convert.ToString(ds.Tables[0].Rows[n][2]) != "")
                            {
                              //  flagSize = 1;
                            }
                        }
                    }
                }//end of if eles of pgno

            }//end of for loop
            //d = Del_dup(d);
            if (d.Rows.Count>2)
            {
              
               
                k = d.Rows.Add();
                for (int j = 2; j < 12; j++)
                {
                    double sum = 0;
                    for (int i = 1; i < d.Rows.Count - 1; i++)
                    {
                        double no = 0;
                        if (double.TryParse(Convert.ToString(d.Rows[i].Cells[j].Value), out no))
                        { no = double.Parse(Convert.ToString(d.Rows[i].Cells[j].Value)); }
                        sum += no;
                    }
                    if (sum != 0)
                    {
                        d.Rows[k].Cells[j].Value = sum.ToString();
                    }
                }
                d.Rows[k].Cells[1].Value = "Total";
            }
           // d = Del_dup(d);
            // out of size items
            int pgno1 = -1;
            double sum3 = 0;
            for (int i = 0; i < ds1.Rows.Count; i++)
            {
                if (ds1.Rows[i][2].ToString()!="")
                {
                    
                        pgno1 = Convert.ToInt32(ds1.Rows[i][3]);
                        k = d.Rows.Add();
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds1.Rows[i][1].ToString(), Convert.ToString(ds1.Rows[i][3]), Convert.ToString(ds1.Rows[i][2]));
                        d.Rows[k].Cells[1].Value = Convert.ToString(ds1.Rows[i][3]);
                        d.Rows[k].Cells[2].Value = Convert.ToString(ds1.Rows[i][2]) + "     " + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "   " + Convert.ToString(ds1.Rows[i][4]);
                     
                 
                    
                  }
                else
                {
                    if (pgno1 != Convert.ToInt32(ds1.Rows[i][3]))
                    {
                        pgno1 = Convert.ToInt32(ds1.Rows[i][3]);
                        k = d.Rows.Add();
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds1.Rows[i][1].ToString(), Convert.ToString(ds1.Rows[i][3]), Convert.ToString(ds1.Rows[i][2]));
                        d.Rows[k].Cells[1].Value = Convert.ToString(ds1.Rows[i][3]);
                        d.Rows[k].Cells[2].Value = Convert.ToString(ds1.Rows[i][2]);// +" " + Convert.ToString(ds1.Rows[i][5]);
                        d.Rows[k].Cells[3].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                        double t = 0;
                        if (double.TryParse(Convert.ToString(ds2.Tables[0].Rows[0][0]), out t))
                        { sum3 += Convert.ToDouble(ds2.Tables[0].Rows[0][0]); }

                        d.Rows[k].Cells[4].Value = Convert.ToString(ds1.Rows[i][4]);
                    }
                    else { }
                    if (i == ds1.Rows.Count - 1)
                    {
                        if (ds1.Rows.Count > 1)
                        {
                            k = d.Rows.Add();
                            d.Rows[k].Cells[3].Value = Convert.ToString(sum3);
                            d.Rows[k].Cells[1].Value = "Total";
                            d.Rows[k].Cells[4].Value = Convert.ToString(ds1.Rows[i][4]);
                        }
                    }
                }
                
            }
           // d = Del_dup(d);
            return d;
        }
        public int Getsize(string s, List<string> lst)
        {
            int f = -1;
            for (int i = 0; i < lst.Count; i++)
            {
                if (s == lst[i])
                    return i;
            }
            return f;
        }
        public DataGridView getReducerGrid(DataSet ds, int startindex, string cat, string mno, int seqno, out int last)
        {
            Summary s = new Summary();
            DataGridView d = s.dataGridView1;
            DataTable ds1 = new DataTable();        
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            d.Rows.Clear();
            int lastindex = startindex;
            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);
            DataSet ds5 = majordal.getReducersize(mno, cat, itemname);
            while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
            {
                lastindex++;
                if (lastindex >= ds.Tables[0].Rows.Count)
                { break; }
            }
            last = lastindex;
            string pageno = "";
            int k = d.Rows.Add();
            d.Rows[k].Cells[2].Value = itemname;
            d.Rows[k].Cells[0].Value = seqno.ToString();
            k = d.Rows.Add();
            List<string> lstgrid = new List<string>();
            if (ds5.Tables[0].Rows.Count < 10)
            {
                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    d.Rows[k].Cells[2 + i].Value = Convert.ToString(ds5.Tables[0].Rows[i][0]);
                    lstgrid.Add(d.Rows[k].Cells[2 + i].Value.ToString());
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    d.Rows[k].Cells[2 + i].Value = Convert.ToString(ds5.Tables[0].Rows[i][0]);
                    lstgrid.Add(d.Rows[k].Cells[2 + i].Value.ToString());
                }
            }
            for (int n = startindex; n < lastindex; n++)
            {
                if (pageno != Convert.ToString(ds.Tables[0].Rows[n][3]))
                {
                    pageno = Convert.ToString(ds.Tables[0].Rows[n][3]);
                    k = d.Rows.Add();
                    d.Rows[k].Cells[1].Value = pageno;
                    int l = Getsize(ds.Tables[0].Rows[n][2].ToString(), lstgrid);
                    if (l != -1)
                    {
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                        d.Rows[k].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        DataRow dr = ds1.NewRow();
                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n][0]);
                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n][1]);
                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n][2]);
                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n][3]);
                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n][4]);
                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n][5]);
                        ds1.Rows.Add(dr);
                    }
                }
                else
                {
                    int l = Getsize(ds.Tables[0].Rows[n][2].ToString(), lstgrid);
                    if (l != -1)
                    {
                        DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                        d.Rows[k].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        DataRow dr = ds1.NewRow();
                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n][0]);
                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n][1]);
                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n][2]);
                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n][3]);
                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n][4]);
                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n][5]);
                        ds1.Rows.Add(dr);
                    }
                }//end of if eles of pgno

            }//end of for loop
            if (d.Rows.Count > 3)
            {
                k = d.Rows.Add();
                for (int j = 2; j < 12; j++)
                {
                    double sum = 0;

                    for (int i = 1; i < d.Rows.Count - 1; i++)
                    {
                        double no = 0;
                        if (double.TryParse(Convert.ToString(d.Rows[i].Cells[j].Value), out no))
                        { no = double.Parse(Convert.ToString(d.Rows[i].Cells[j].Value)); }
                        sum += no;
                    }
                    if (sum != 0)
                    {
                        d.Rows[k].Cells[j].Value = sum.ToString();
                    }
                }
                d.Rows[k].Cells[1].Value = "Total";
            }
            // out of size items
            for (int i = 0; i < ds1.Rows.Count; i++)
            {
                k = d.Rows.Add();
                DataSet ds2 = majordal.getmeasureSum1(mno, cat, ds1.Rows[i][1].ToString(), Convert.ToString(ds1.Rows[i][3]), Convert.ToString(ds1.Rows[i][2]));
                d.Rows[k].Cells[1].Value = Convert.ToString(ds1.Rows[i][3]);
                d.Rows[k].Cells[2].Value = Convert.ToString(ds1.Rows[i][2])  + "     " + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "  " + Convert.ToString(ds1.Rows[i][4]);
            }
            return d;
        }
        public DataGridView getDrillingGrid(DataSet ds, int startindex, string cat, string mno, int seqno, out int last)
        {
            Summary s = new Summary();
            DataGridView d = s.dataGridView1;
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            d.Rows.Clear();
            int lastindex = startindex;
            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);

           // last = ds.Tables[0].Rows.Count;
            while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
            {
                lastindex++;
                if (lastindex >= ds.Tables[0].Rows.Count)
                { break; }
            }
            last = lastindex;
            DataSet dxt = majordal.getDistinctDrill(mno);

            int k = d.Rows.Add();
            d.Rows[k].Cells[0].Value = seqno;
            d.Rows[k].Cells[2].Value = "Drilling Hole Dia";
            k = d.Rows.Add();
            for (int i = 0; i < dxt.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "1/2\"")
                { d.Rows[k].Cells[2].Value = "1/2\""; }
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "3/4\"")
                { d.Rows[k].Cells[3].Value = "3/4\""; }
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "5/8\"")
                { d.Rows[k].Cells[4].Value = "5/8\""; } 
            }
            string pageno = "";
            for (int n = startindex; n < last; n++)
            {
                if (pageno != Convert.ToString(ds.Tables[0].Rows[n][3]))
                {
                    pageno = Convert.ToString(ds.Tables[0].Rows[n][3]);
                    k = d.Rows.Add();
                    d.Rows[k].Cells[1].Value = pageno;
                    DataSet ds2 = majordal.getmeasureSum1(mno, cat, itemname, Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][2]) == "1/2\"")
                    { d.Rows[k].Cells[2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]); }
                    ds2 = majordal.getmeasureSum1(mno, cat, itemname, Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));

                    if (Convert.ToString(ds.Tables[0].Rows[n][2]) == "3/4\"")
                    { d.Rows[k].Cells[3].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]); }
                    ds2 = majordal.getmeasureSum1(mno, cat, itemname, Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));

                    if (Convert.ToString(ds.Tables[0].Rows[n][2]) == "5/8\"")
                    { d.Rows[k].Cells[4].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]); }
                  

                }
                else
                {
                    DataSet ds2 = majordal.getmeasureSum1(mno, cat, itemname, Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][2]) == "1/2\"")
                    { d.Rows[k].Cells[2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]); }
                    ds2 = majordal.getmeasureSum1(mno, cat, itemname, Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));

                    if (Convert.ToString(ds.Tables[0].Rows[n][2]) == "3/4\"")
                    { d.Rows[k].Cells[3].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]); }
                    ds2 = majordal.getmeasureSum1(mno, cat, itemname, Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));

                    if (Convert.ToString(ds.Tables[0].Rows[n][2]) == "5/8\"")
                    { d.Rows[k].Cells[4].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]); }
                  
                }

            }
            if (d.Rows.Count > 2)
            {
                k = d.Rows.Add();
                for (int j = 2; j < 12; j++)
                {
                    double sum = 0;

                    for (int i = 1; i < d.Rows.Count - 1; i++)
                    {
                        double no = 0;
                        if (double.TryParse(Convert.ToString(d.Rows[i].Cells[j].Value), out no))
                        { no = double.Parse(Convert.ToString(d.Rows[i].Cells[j].Value)); }
                        sum += no;
                    }
                    if (sum != 0)
                    {
                        d.Rows[k].Cells[j].Value = sum.ToString();
                    }
                    d.Rows[k].Cells[1].Value = "Total";
                }
            }

            return d;
        }
        public DataGridView getLabourGrid(DataSet ds, int startindex, string cat, string mno, int seqno, out int last)
        {
            Summary s = new Summary();
            DataGridView d = s.dataGridView1;
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            d.Rows.Clear();
            int lastindex = startindex;
            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);

            last = ds.Tables[0].Rows.Count;
            DataSet dxt = majordal.getDistinctLabour(mno);

            int k = d.Rows.Add();
            // d.Rows[k].Cells[0].Value = seqno;
            double fi = 0, he = 0, ri = 0, sup = 0, we = 0;
            for (int i = 0; i < dxt.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "Fitter")
                { d.Rows[k].Cells[4].Value = "Fitter"; }
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "Helper")
                { d.Rows[k].Cells[7].Value = "Helper"; }
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "Rigger")
                { d.Rows[k].Cells[6].Value = "Rigger"; }
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "Supervisor")
                { d.Rows[k].Cells[2].Value = "Supervisor"; }
                if (Convert.ToString(dxt.Tables[0].Rows[i][0]) == "Welder")
                { d.Rows[k].Cells[5].Value = "Welder"; }
            }

            //d.Rows[k].Cells[3].Value = "Helper";
            //d.Rows[k].Cells[4].Value = "Rigger";
            //d.Rows[k].Cells[5].Value = "Supervisor";
            //d.Rows[k].Cells[6].Value = "Welder";
            string pageno = "";
            string subcat = "";
            ds = majordal.getLabourSumSeq1(mno, "Labour Supply");
            for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
            {
                if (subcat == Convert.ToString(ds.Tables[0].Rows[n][1]) && pageno == Convert.ToString(ds.Tables[0].Rows[n][3]))
                {
                    continue;

                }
               
                if (pageno != Convert.ToString(ds.Tables[0].Rows[n][3]))
                {
                    subcat = Convert.ToString(ds.Tables[0].Rows[n][1]);
                    pageno = Convert.ToString(ds.Tables[0].Rows[n][3]);
                    k = d.Rows.Add();
                    d.Rows[k].Cells[1].Value = pageno;

                    DataSet ds2 = majordal.getmeasureSum1(mno, cat, "Fitter", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Fitter")
                    { d.Rows[k].Cells[4].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    fi += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Helper", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Helper")
                    { d.Rows[k].Cells[7].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    he += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Rigger", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Rigger")
                    { d.Rows[k].Cells[6].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                      ri += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Supervisor", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Supervisor")
                    { d.Rows[k].Cells[2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    sup += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Welder", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Welder")
                    { d.Rows[k].Cells[5].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    we += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                }
                else
                {
                    DataSet ds2 = majordal.getmeasureSum1(mno, cat, "Fitter", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Fitter")
                    { d.Rows[k].Cells[4].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                      fi += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Helper", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Helper")
                    { d.Rows[k].Cells[7].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    he += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Rigger", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Rigger")
                    { d.Rows[k].Cells[6].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    ri += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Supervisor", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Supervisor")
                    { d.Rows[k].Cells[2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    sup += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                    ds2 = majordal.getmeasureSum1(mno, cat, "Welder", Convert.ToString(ds.Tables[0].Rows[n][3]), Convert.ToString(ds.Tables[0].Rows[n][2]));
                    if (Convert.ToString(ds.Tables[0].Rows[n][1]) == "Welder")
                    { d.Rows[k].Cells[5].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                    we += Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                    }

                }


            }
            k = d.Rows.Add();
            d.Rows[k].Cells[1].Value = "Total";
            if (fi != 0)
            {
                d.Rows[k].Cells[4].Value = fi.ToString();
            }
            if (he != 0)
            {
                d.Rows[k].Cells[7].Value = he.ToString();
           }
            if (ri != 0)
            {
            d.Rows[k].Cells[6].Value = ri.ToString();
                }
            if (sup != 0)
            {
            d.Rows[k].Cells[2].Value = sup.ToString();
               }
            if (we != 0)
            {
                d.Rows[k].Cells[5].Value = we.ToString();
            }
            return d;
        }
        void m_oWorker_LoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //panel2.Controls.Clear();
            //panel2.Visible = false;
        }
        public string[] seqsections ={"Labour Supply",
                                          "EQ Erection", "EQ Dismantling",
                                         "EQ Shifting","EQ Loading","EQ Unloading" };
        public bool isSeqsec(string s)
        {
            for (int i = 0; i < seqsections.Length; i++)
            {
                if (s == seqsections[i])
                { return true; }
            }
            return false;
        
        }
        public void m_oWorker_Load(object sender, DoWorkEventArgs e)
        {
            Smsh = new SummarySheet();
            Smsh.txtmno.Text = smno;
            int seq = 0;
            Smsh.dataGridView1.Rows.Clear();

            DataSet ds10 = majordal.get(Smsh.txtmno.Text);
            if (ds10.Tables[0].Rows.Count > 0)
            { //dateTimePicker1.Text = Convert.ToString(ds10.Tables[0].Rows[0][3]);
            }
            for (int i = 0; i < Smsh.SectionSeq.Length; i++)
            {
                if (i == 2)
                {
                    //int l = 1;
                }
                DataSet ds = majordal.getmeasureSumSeq(Smsh.txtmno.Text, SectionSeq[i]); // majordal.getmeasureSummary(txtmno.Text, SectionSeq[i]);
                ds = Smsh.Sortitems(ds);
                ds = Smsh.Composeitems(ds, Smsh.SectionSeq[i], Smsh.txtmno.Text);
                // ds = Orderitems(ds);
                int pages = (ds.Tables[0].Rows.Count / 25) + 1;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int k = Smsh.dataGridView1.Rows.Add();
                    if (isSeqsec(Smsh.SectionSeq[i]))
                    {
                        seq++;
                        Smsh.dataGridView1.Rows[k].Cells[0].Value = seq;

                    }
                    Smsh.dataGridView1.Rows[k].Cells[2].Value = SectionSeq[i];
                    Smsh.dataGridView1.Rows[k].Cells[2].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                    for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
                    {
                        int last;
                        if (!isSeqsec(Smsh.SectionSeq[i]))
                        {
                            seq++;
                        }
                        DataGridView d1;
                        if (seq == 47)
                        {
                            int mn = 0;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[n][1]).Contains("Drilling Hole Dia"))
                        {
                            d1 = Smsh.getDrillingGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[n][1]).ToLower().Contains("reducer") && !Convert.ToString(ds.Tables[0].Rows[n][1]).ToLower().Contains("joint"))
                        {
                           // d1 = Smsh.getReducerGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                            Summary s = new Summary();
                            DataGridView d = s.dataGridView1;
                            DataTable ds1 = new DataTable();
                            ds1.Columns.Add("itemcode");
                            ds1.Columns.Add("subcat");
                            ds1.Columns.Add("size");
                            ds1.Columns.Add("pageno");
                            ds1.Columns.Add("unit");
                            ds1.Columns.Add("Desc2");
                            d.Rows.Clear();
                            int startindex = n;
                            int lastindex = startindex;
                            string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);
                            DataSet ds5 = majordal.getReducersize(Smsh.txtmno.Text, SectionSeq[i], itemname);
                            while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
                            {
                                lastindex++;
                                if (lastindex >= ds.Tables[0].Rows.Count)
                                { break; }
                            }
                            last = lastindex;
                            string pageno = "";
                            int k2 = d.Rows.Add();
                            d.Rows[k2].Cells[2].Value = itemname;
                            d.Rows[k2].Cells[0].Value = seq.ToString();
                            k2 = d.Rows.Add();
                            List<string> lstgrid = new List<string>();
                            if (ds5.Tables[0].Rows.Count < 10)
                            {
                                for (int ii = 0; ii < ds5.Tables[0].Rows.Count; ii++)
                                {
                                    d.Rows[k2].Cells[2 + ii].Value = Convert.ToString(ds5.Tables[0].Rows[ii][0]);
                                    lstgrid.Add(d.Rows[k2].Cells[2 + ii].Value.ToString());
                                }
                            }
                            else
                            {
                                for (int ii = 0; ii < 10; ii++)
                                {
                                    d.Rows[k2].Cells[2 + ii].Value = Convert.ToString(ds5.Tables[0].Rows[ii][0]);
                                    lstgrid.Add(d.Rows[k2].Cells[2 + ii].Value.ToString());
                                }
                            }
                            for (int n2 = startindex; n2 < lastindex; n2++)
                            {
                                if (pageno != Convert.ToString(ds.Tables[0].Rows[n2][3]))
                                {
                                    pageno = Convert.ToString(ds.Tables[0].Rows[n2][3]);
                                    k2 = d.Rows.Add();
                                    d.Rows[k2].Cells[1].Value = pageno;
                                    int l = Getsize(ds.Tables[0].Rows[n2][2].ToString(), lstgrid);
                                    if (l != -1)
                                    {
                                        DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n2][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n2][3]), Convert.ToString(ds.Tables[0].Rows[n2][2]));
                                        d.Rows[k2].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                                    }
                                    else
                                    {
                                        DataRow dr = ds1.NewRow();
                                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n2][0]);
                                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n2][1]);
                                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n2][2]);
                                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n2][3]);
                                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n2][4]);
                                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n2][5]);
                                        ds1.Rows.Add(dr);
                                    }
                                }
                                else
                                {
                                    int l = Getsize(ds.Tables[0].Rows[n2][2].ToString(), lstgrid);
                                    if (l != -1)
                                    {
                                        DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n2][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n2][3]), Convert.ToString(ds.Tables[0].Rows[n2][2]));
                                        d.Rows[k2].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                                    }
                                    else
                                    {
                                        DataRow dr = ds1.NewRow();
                                        dr[0] = Convert.ToString(ds.Tables[0].Rows[n2][0]);
                                        dr[1] = Convert.ToString(ds.Tables[0].Rows[n2][1]);
                                        dr[2] = Convert.ToString(ds.Tables[0].Rows[n2][2]);
                                        dr[3] = Convert.ToString(ds.Tables[0].Rows[n2][3]);
                                        dr[4] = Convert.ToString(ds.Tables[0].Rows[n2][4]);
                                        dr[5] = Convert.ToString(ds.Tables[0].Rows[n2][5]);
                                        ds1.Rows.Add(dr);
                                    }
                                }//end of if eles of pgno

                            }//end of for loop
                            if (d.Rows.Count > 3)
                            {
                                k2 = d.Rows.Add();
                                for (int j = 2; j < 12; j++)
                                {
                                    double sum = 0;

                                    for (int ii = 1; ii < d.Rows.Count - 1; ii++)
                                    {
                                        double no = 0;
                                        if (double.TryParse(Convert.ToString(d.Rows[ii].Cells[j].Value), out no))
                                        { no = double.Parse(Convert.ToString(d.Rows[ii].Cells[j].Value)); }
                                        sum += no;
                                    }
                                    if (sum != 0)
                                    {
                                        d.Rows[k2].Cells[j].Value = sum.ToString();
                                    }
                                }
                                d.Rows[k2].Cells[1].Value = "Total";
                            }
                            // out of size items
                            for (int ii = 0; ii < ds1.Rows.Count; ii++)
                            {
                                k2 = d.Rows.Add();
                                DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, SectionSeq[i], ds1.Rows[ii][1].ToString(), Convert.ToString(ds1.Rows[ii][3]), Convert.ToString(ds1.Rows[ii][2]));
                                d.Rows[k2].Cells[1].Value = Convert.ToString(ds1.Rows[ii][3]);
                                d.Rows[k2].Cells[2].Value = Convert.ToString(ds1.Rows[ii][2]) + "     " + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "  " + Convert.ToString(ds1.Rows[ii][4]);
                            }
                            d1 = d;
                        
                        }//reducer grid ends
                        else
                        {

                            if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading")
                            {
                                d1 = Smsh.getnormalGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);

                            }
                            else if (SectionSeq[i] == "Labour Supply")
                            {
                                d1 = getLabourGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last); }
                            else if (SectionSeq[i] == "EQ Shifting")
                            {
                                d1 = Smsh.getShiftingGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                            }

                            else
                            {
                                //d1 = Smsh.getfabGrid(ds, n, Smsh.SectionSeq[i], txtmno.Text, seq, out last);
                                  //fabgrid calc
                                int fristflg = 0;//flagSize = 0 ,
                                Summary s = new Summary();
                                DataGridView d = s.dataGridView1;
                                DataTable ds1 = new DataTable();
                                ds1.Columns.Add("itemcode");
                                ds1.Columns.Add("subcat");
                                ds1.Columns.Add("size");
                                ds1.Columns.Add("pageno");
                                ds1.Columns.Add("unit");
                                ds1.Columns.Add("Desc2");
                                d.Rows.Clear();
                                int startindex = n;
                                int lastindex = n;
                                string itemname = Convert.ToString(ds.Tables[0].Rows[startindex][1]);
                                while (itemname == Convert.ToString(ds.Tables[0].Rows[lastindex][1]))
                                {
                                    lastindex++;
                                    if (lastindex >= ds.Tables[0].Rows.Count)
                                    { break; }

                                }
                                last = lastindex;
                                string pageno = "";
                                int k2 = d.Rows.Add();
                                d.Rows[k2].Cells[2].Value = itemname;
                                d.Rows[k2].Cells[0].Value = seq.ToString();
                                if (seq == 31)
                                {
                                    int cy = 0;
                                }
                                for (int n3 = startindex; n3 < lastindex; n3++)
                                {
                                    if (pageno != Convert.ToString(ds.Tables[0].Rows[n3][3]))
                                    {
                                        pageno = Convert.ToString(ds.Tables[0].Rows[n3][3]);
                                        k2 = d.Rows.Add();
                                        d.Rows[k2].Cells[1].Value = pageno;
                                        int l = Getsize(ds.Tables[0].Rows[n3][2].ToString());
                                        if (l != -1)
                                        {
                                            DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, seqsections[i], ds.Tables[0].Rows[n3][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n3][3]), Convert.ToString(ds.Tables[0].Rows[n3][2]));
                                            d.Rows[k2].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                                        }
                                        else
                                        {
                                            DataRow dr = ds1.NewRow();
                                            d.Rows.RemoveAt(k2);
                                            dr[0] = Convert.ToString(ds.Tables[0].Rows[n3][0]);
                                            dr[1] = Convert.ToString(ds.Tables[0].Rows[n3][1]);
                                            dr[2] = Convert.ToString(ds.Tables[0].Rows[n3][2]);
                                            dr[3] = Convert.ToString(ds.Tables[0].Rows[n3][3]);
                                            dr[4] = Convert.ToString(ds.Tables[0].Rows[n3][4]);
                                            dr[5] = Convert.ToString(ds.Tables[0].Rows[n3][5]);
                                            ds1.Rows.Add(dr);
                                            //if (Convert.ToString(ds.Tables[0].Rows[n][2])!="")
                                            //{
                                            //    flagSize = 1;
                                            //}
                                            fristflg = 1;
                                        }
                                    }
                                    else
                                    {
                                        int l = Getsize(ds.Tables[0].Rows[n3][2].ToString());
                                        if (l != -1)
                                        {
                                            DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, seqsections[i], ds.Tables[0].Rows[n3][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n3][3]), Convert.ToString(ds.Tables[0].Rows[n3][2]));
                                            if (k2 >= d.Rows.Count)
                                            { k2 = d.Rows.Add(); }
                                            d.Rows[k2].Cells[l + 2].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                                        }
                                        else
                                        {
                                            if (fristflg == 0)
                                            {
                                                DataRow dr = ds1.NewRow();
                                                //d.Rows.RemoveAt(k);
                                                dr[0] = Convert.ToString(ds.Tables[0].Rows[n3][0]);
                                                dr[1] = Convert.ToString(ds.Tables[0].Rows[n3][1]);
                                                dr[2] = Convert.ToString(ds.Tables[0].Rows[n3][2]);
                                                dr[3] = Convert.ToString(ds.Tables[0].Rows[n3][3]);
                                                dr[4] = Convert.ToString(ds.Tables[0].Rows[n3][4]);
                                                dr[5] = Convert.ToString(ds.Tables[0].Rows[n3][5]);
                                                ds1.Rows.Add(dr);
                                                if (Convert.ToString(ds.Tables[0].Rows[n3][2]) != "")
                                                {
                                                    //  flagSize = 1;
                                                }
                                            }
                                        }
                                    }//end of if eles of pgno

                                }//end of for loop
                                //d = Del_dup(d);
                                if (d.Rows.Count > 2)
                                {


                                    k2 = d.Rows.Add();
                                    for (int j = 2; j < 12; j++)
                                    {
                                        double sum = 0;
                                        for (int ii = 1; ii < d.Rows.Count - 1; ii++)
                                        {
                                            double no = 0;
                                            if (double.TryParse(Convert.ToString(d.Rows[ii].Cells[j].Value), out no))
                                            { no = double.Parse(Convert.ToString(d.Rows[ii].Cells[j].Value)); }
                                            sum += no;
                                        }
                                        if (sum != 0)
                                        {
                                            d.Rows[k2].Cells[j].Value = sum.ToString();
                                        }
                                    }
                                    d.Rows[k2].Cells[1].Value = "Total";
                                }
                                // d = Del_dup(d);
                                // out of size items
                                int pgno1 = -1;
                                double sum3 = 0;
                                for (int ii = 0; ii < ds1.Rows.Count; i++)
                                {
                                    if (ds1.Rows[ii][2].ToString() != "")
                                    {

                                        pgno1 = Convert.ToInt32(ds1.Rows[ii][3]);
                                        k = d.Rows.Add();
                                        DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, seqsections[i], ds1.Rows[i][1].ToString(), Convert.ToString(ds1.Rows[i][3]), Convert.ToString(ds1.Rows[i][2]));
                                        d.Rows[k2].Cells[1].Value = Convert.ToString(ds1.Rows[i][3]);
                                        d.Rows[k2].Cells[2].Value = Convert.ToString(ds1.Rows[i][2]) + "     " + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "   " + Convert.ToString(ds1.Rows[i][4]);



                                    }
                                    else
                                    {
                                        if (pgno1 != Convert.ToInt32(ds1.Rows[ii][3]))
                                        {
                                            pgno1 = Convert.ToInt32(ds1.Rows[ii][3]);
                                            k2 = d.Rows.Add();
                                            DataSet ds2 = majordal.getmeasureSum1(Smsh.txtmno.Text, seqsections[i], ds1.Rows[i][1].ToString(), Convert.ToString(ds1.Rows[i][3]), Convert.ToString(ds1.Rows[i][2]));
                                            d.Rows[k2].Cells[1].Value = Convert.ToString(ds1.Rows[ii][3]);
                                            d.Rows[k2].Cells[2].Value = Convert.ToString(ds1.Rows[ii][2]);// +" " + Convert.ToString(ds1.Rows[i][5]);
                                            d.Rows[k2].Cells[3].Value = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                                            double t = 0;
                                            if (double.TryParse(Convert.ToString(ds2.Tables[0].Rows[0][0]), out t))
                                            { sum3 += Convert.ToDouble(ds2.Tables[0].Rows[0][0]); }

                                            d.Rows[k2].Cells[4].Value = Convert.ToString(ds1.Rows[ii][4]);
                                        }
                                        else { }
                                        if (ii == ds1.Rows.Count - 1)
                                        {
                                            if (ds1.Rows.Count > 1)
                                            {
                                                k2 = d.Rows.Add();
                                                d.Rows[k2].Cells[3].Value = Convert.ToString(sum3);
                                                d.Rows[k2].Cells[1].Value = "Total";
                                                d.Rows[k2].Cells[4].Value = Convert.ToString(ds1.Rows[ii][4]);
                                            }
                                        }
                                    }

                                }
                                // d = Del_dup(d);
                                d1 = d;
                            
                            }
                        }
                        for (int ii = 0; ii < d1.Rows.Count; ii++)
                        {
                            k = Smsh.dataGridView1.Rows.Add();
                            for (int ij = 0; ij < 12; ij++)
                            {
                                Smsh.dataGridView1.Rows[k].Cells[ij].Value = d1.Rows[ii].Cells[ij].Value;
                            }
                        }
                        n = last - 1;
                    }
                }
            }
        }

        public static SummarySheet Smsh;
        public static string smno;
        public static bool isCompleted;
        public void m_oWorker_Load_Completed(object sender, RunWorkerCompletedEventArgs e)
        { isCompleted = true; }
        public void btnload_Click(object sender, EventArgs e)
        {
            //smno = txtmno.Text;
            //BackgroundWorker b = new BackgroundWorker();
            //isCompleted = false;
            //b.DoWork += m_oWorker_Load;
            //b.RunWorkerCompleted += m_oWorker_Load_Completed;
            //isCompleted = false;
            ////this.Hide();
            //SBGhadge1.FlashScreen fsc = new SBGhadge1.FlashScreen();
            //fsc.Show();
            //b.RunWorkerAsync();
            //while (isCompleted==false)
            //{
                
            //}
            //this.dataGridView1 = Smsh.dataGridView1;
            //fsc.Close();
            ////this.Show();
            //return;

            //SBGhadgev1.PointCanvas p = new PointCanvas();
            //panel2.Controls.Add(p);
            //panel2.Visible = true;
            //b.RunWorkerAsync();
            //b.RunWorkerCompleted += m_oWorker_LoadCompleted;


            // btnExpoToExcel.Visible = true;

            //SBGhadge1.FlashScreen fsc = new SBGhadge1.FlashScreen();
            //fsc.Show();

            //this.Hide();
            //try
            //{
                int seq = 0;
                dataGridView1.Rows.Clear();
                majordal.InitSummary(txtmno.Text);
                DataSet ds10 = majordal.get(txtmno.Text);
                if (ds10.Tables[0].Rows.Count > 0)
                { //dateTimePicker1.Text = Convert.ToString(ds10.Tables[0].Rows[0][3]);
                }
                for (int i = 0; i < SectionSeq.Length; i++)
                {
                    if (SectionSeq[i] == "EQ Shifting")
                    {
                        int l = 1;
                    }
                    DataSet ds = majordal.getmeasureSumSeq(txtmno.Text, SectionSeq[i]); // majordal.getmeasureSummary(txtmno.Text, SectionSeq[i]);
                    ds = Sortitems(ds);
                    ds = Composeitems(ds, SectionSeq[i], txtmno.Text);
                    // ds = Orderitems(ds);
                    int pages = (ds.Tables[0].Rows.Count / 25) + 1;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int k = dataGridView1.Rows.Add();
                        if (isSeqsec(SectionSeq[i]))
                        {
                            seq++;
                            dataGridView1.Rows[k].Cells[0].Value = seq;

                        }
                        dataGridView1.Rows[k].Cells[2].Value = SectionSeq[i];
                        dataGridView1.Rows[k].Cells[2].Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
                        {
                            int last;
                            if (!isSeqsec(SectionSeq[i]))
                            {
                                seq++;
                            }
                            DataGridView d1;
                            if (seq == 19)
                            {
                                int mn = 0;
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[n][1]).Contains("Drilling Hole Dia"))
                            {
                                d1 = getDrillingGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                            }
                            else if (Convert.ToString(ds.Tables[0].Rows[n][1]).ToLower().Contains("reducer") && !Convert.ToString(ds.Tables[0].Rows[n][1]).ToLower().Contains("joint"))
                            {
                                d1 = getReducerGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                            }
                            else
                            {

                                if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading")
                                {
                                    d1 = getnormalGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);

                                }
                                else if (SectionSeq[i] == "Labour Supply")
                                {
                                    d1 = getLabourGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                                }
                                else if (SectionSeq[i] == "EQ Shifting")
                                {
                                    d1 = getShiftingGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                                }

                                else
                                {
                                    d1 = getfabGrid(ds, n, SectionSeq[i], txtmno.Text, seq, out last);
                                }
                            }
                            for (int ii = 0; ii < d1.Rows.Count; ii++)
                            {
                                k = dataGridView1.Rows.Add();
                                for (int ij = 0; ij < 12; ij++)
                                {
                                    dataGridView1.Rows[k].Cells[ij].Value = d1.Rows[ii].Cells[ij].Value;
                                }
                            }
                            n = last - 1;
                        }
                    }
                }
                //Application.OpenForms["FlashScreen"].Close();
                // this.Show();
            //}
            //catch (Exception ex)
            //{ }
            }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    majordal.insertsumarysheet(txtmno.Text, Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), Convert.ToString(dataGridView1.Rows[i].Cells[3].Value), Convert.ToString(dataGridView1.Rows[i].Cells[4].Value), Convert.ToString(dataGridView1.Rows[i].Cells[5].Value), Convert.ToString(dataGridView1.Rows[i].Cells[6].Value), Convert.ToString(dataGridView1.Rows[i].Cells[7].Value), Convert.ToString(dataGridView1.Rows[i].Cells[8].Value), Convert.ToString(dataGridView1.Rows[i].Cells[9].Value), Convert.ToString(dataGridView1.Rows[i].Cells[10].Value), Convert.ToString(dataGridView1.Rows[i].Cells[11].Value));
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {        }
        public int getseqno(int startIndex)
        {
            int rows = startIndex + 1;
            for (int i = startIndex + 1; i < dataGridView1.Rows.Count; i++)
            {
                rows = i;
                int k = 0;
                //Measure M1 = new Measure();
                //if (M1.istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value)))
                //{
                //    i++;
                //    rows = i;
                //}
                if (int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), out k))
                {
                    return (rows - startIndex);
                }

            }
            return (rows - startIndex);
        }
        public int getseqnoeq(int startIndex)
        {
            int rows = startIndex + 1;
            if(majordal.iscat(Convert.ToString(dataGridView1.Rows[startIndex].Cells[1].Value))!="")
            {rows = startIndex + 2;}
            for (int i = startIndex + 1; i < dataGridView1.Rows.Count; i++)
            {
                rows = i;
                int k = 0;
                
                if (int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), out k))
                {
                   
                }
                else { return (rows - startIndex); }

            }
            return (rows - startIndex);
        }
        
        //public Graphics GridWrite(DataGridView datagridview1, int rowno, Graphics g ,out int j)
        //{ 
        //        System.Drawing.Font  f = new System.Drawing.Font("Times New Roman", 11F);
        //        string y1 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
        //        int fact1 = y1.Length / 2;
        //        if (majordal.iscat(y1.ToLower()) != "")
        //        {
        //            flag = getseqno(i + 1);
        //            if (((j + flag-1) / 29) == 1)
        //            {
        //                string _sourceFile = Application.StartupPath + "\\Images\\summary.jpg";
        //                _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
        //                string path = Application.StartupPath + "\\Summary\\";
        //                path = path.Replace("\\bin\\Debug", "");
        //                img1.Save(path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg");
        //                userSummary.s = path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg";
        //                userSummary m = new userSummary();
        //                ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Add(m);
        //                img1 = System.Drawing.Image.FromFile(_sourceFile);
        //                g = Graphics.FromImage(img1);
        //                ps.tabControl1.TabPages.Add("Page" + ((ps.tabControl1.TabPages.Count) + 1).ToString());
        //                page++;
        //                g.DrawString(page.ToString(), f, Brushes.Black, new Point(150, 85));
        //                g.DrawString(dateTimePicker1.Text, f, Brushes.Black, new Point(620, 75));
        //                flag = 0; j = 0;
        //                f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                g.DrawString(y1, f, Brushes.Black, new Point(367 - fact1 * 7, (152 + ((j % 29) * 25))));
        //                j++; continue;
        //            }
        //            else
        //            {
        //                flag = 0;
        //                f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                g.DrawString(y1, f, Brushes.Black, new Point(367 - fact1 * 7, (152 + ((j % 29) * 25))));
        //                j++; continue;
        //            }
        //        }
        //        if (majordal.issubcat(y1.ToLower()) != "")
        //        {
        //            f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            g.DrawString(y1, f, Brushes.Black, new Point(367 - fact1 * 7, (152 + ((j % 29) * 25))));
        //            y1 = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
        //             g.DrawString(y1, f, Brushes.Black, new Point(10, (152 + ((j % 29) * 25)))); 
        //            j++; continue;
        //        }
        //        if (Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == "")
        //        {
        //            string s = "";
        //            for (int p = 2; p < 12; p++)
        //            {
        //                s = Convert.ToString(dataGridView1.Rows[i].Cells[p].Value);
        //                int k = 120;
        //                f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                g.DrawString(s, f, Brushes.Black, new Point(k + ((p - 2) * 63), (152 + ((j % 29) * 25))));
        //            }
        //            s = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
        //            if (s.Length == 1)
        //            { s = "0" + s; }
        //            g.DrawString(s, f, Brushes.Black, new Point(10, (152 + ((j % 29) * 25))));
        //            f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            j++;
        //            continue;
        //        }
        //        for (int j1 = 0; j1 < dataGridView1.ColumnCount; j1++)
        //        {
        //            if (j1 ==2)
        //            {
        //                int k = 120 + ((j1 - 2) * 63);
        //                y1 = Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value);
        //                int z = y1.IndexOf("     ");
        //                if (z != -1)
        //                {
        //                    g.DrawString(y1.Substring(0, z) + "     ", f, Brushes.Black, new Point(k, (152 + ((j % 29) * 25))));
        //                    Pen p1 = new Pen(Color.Black, 2);
        //                    g.DrawLine(p1, new Point(k + (y1.Substring(0, z).Length + 3) * 7, (160 + ((j % 29) * 25))), new Point(k + 15 + (y1.Substring(0, z).Length + 3) * 7, (160 + ((j % 29) * 25))));
        //                    g.DrawString(y1.Substring( z+5) , f, Brushes.Black, new  Point(k + 20 + (y1.Substring(0, z).Length + 3) * 7, (152 + ((j % 29) * 25))));
        //                }
        //                else
        //                {
        //                    g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (152 + ((j % 29) * 25))));
        //                }
        //            }
        //            if (j1 > 2)
        //            {
        //                int k =120 + ((j1 - 2) * 63);
                       
        //               g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (152 + ((j % 29) * 25))));
                        
        //             }
        //            if (j1 == 0)
        //            {
        //                int k = 10;
        //                g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (152 + ((j % 29) * 25))));
        //            }
        //            if (j1 == 1)
        //            {
        //                int k = 60;
        //                g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (152 + ((j % 29) * 25))));
        //            }
        //        }
        //        j++;
        //        return g;
        //    }
        public static int getUppercase(string s)
        {
            int count = 0;
            foreach (char item in s)
            {
                if (char.IsUpper(item))
                { count++; }

            }

            return count;
        }
        Image sign;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            GC.Collect();
            try{
            userSummary.s = null;
            printsumarysheet ps = new printsumarysheet();
            ps.tabControl1.TabPages.Clear();
            Graphics g = null;
            Image img1 = null;
            string cat="";
                string path1 = Application.StartupPath + "\\Summary\\";
                    path1 = path1.Replace("\\bin\\Debug", "");
          //          DirectoryInfo di = new DirectoryInfo(path1);
          //FileInfo[] fi=     di.GetFiles();

          //     for (int i = 0; i < fi.Length; i++)
          //     {
          //         File.SetAccessControl(fi[i].FullName, new FileSecurity(fi[i].FullName,AccessControlSections.Access));
                
          //         File.Delete(fi[i].FullName);
          //         //File.SetAccessControl(fi[i].FullName, new FileSecurity(fi[i].FullName,AccessControlSections.Access);
          //     }
               //byte[] data = (byte[])Main.user.Tables[0].Rows[0][4];
               //MemoryStream ms = new MemoryStream(data);
               //sign = System.Drawing.Image.FromStream(ms);
              
           
            //Bitmap b = new Bitmap(1500, 2500);
            int flag = 0, j = 0;
            Font f = new System.Drawing.Font("Times New Roman", 14F);
            int page = 0;
            int reduflag = 0;
            int Rowheight = 32;
            int RowStart = 255;
            int RowCenter = 430;
            int Col1Center = 10;
            int seqno = 0;
            DataSet d123 = majordal.getPlantNo(txtmno.Text);
            string plantno = Convert.ToString(d123.Tables[0].Rows[0][0]);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) == "Static Equipment")
                {

                    int p = 0;
                }
                //if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == "119")
                //{
                //    int sl = 0;
                //}
                int k1 = 0;
                if (seqno == 12)
                { 
                    int lt = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) != "")
                {
                    if(int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),out seqno))
                    { seqno = int.Parse(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                    }
                }
                if (i == 0)
                {
                    string _sourceFile = Application.StartupPath + "\\Images\\summary.jpg";
                    _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                    img1 = System.Drawing.Image.FromFile(_sourceFile);
                    //  img1 = new Bitmap(750, 1000);
                    ps.tabControl1.TabPages.Add("Page" + (ps.tabControl1.TabCount+ 1).ToString());
                    page++;
                    g = Graphics.FromImage(img1);
                    g.DrawString(page.ToString(), f, Brushes.Black, new Point(150, 165));
                    //g.DrawString(dateTimePicker1.Text.Replace("/", "."), f, Brushes.Black, new Point(630, 165));
                    g.DrawString(plantno, f, Brushes.Black, new Point(330, 165));
                    flag = 0; j = 0;
                    //img1 = System.Drawing.Image.FromFile(_sourceFile);


                }
#region Reducerif
                if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value).Contains("Reducer") && !Convert.ToString(dataGridView1.Rows[i].Cells[2].Value).Contains("Joint"))
                {
                    reduflag = 1;
                    flag = getseqno(i);
                    if (((j + flag) / 23) > 0)
                    {
                        
                        string _sourceFile = Application.StartupPath + "\\Images\\summary.jpg";
                        _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                        string path = Application.StartupPath + "\\Summary\\";
                        path = path.Replace("\\bin\\Debug", "");

                        img1.Save(path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg");
                        userSummary.s = path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg";
                        userSummary m = new userSummary();
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Clear();
                        ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Add(m);
                        img1 = System.Drawing.Image.FromFile(_sourceFile);
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count-1].Controls.Add(m);
                        g = Graphics.FromImage(img1);
                        ps.tabControl1.TabPages.Add("Page" + ((ps.tabControl1.TabPages.Count) + 1).ToString());
                        //m = new userSummary();
                        //m.pictureBox1.Image = img1;
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count-1].Controls.Add(m);
                        page++;
                        g.DrawString(page.ToString(), f, Brushes.Black, new Point(150, 165));
                        g.DrawString(dateTimePicker1.Text.Replace("/", "."), f, Brushes.Black, new Point(620, 165));
                        g.DrawString(plantno, f, Brushes.Black, new Point(330, 165));
                        flag = 0; j = 0;
                        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        if (majordal.iscat(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value)) == "")
                        {
                            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            SizeF sz = g.MeasureString(cat, f);
                            int k = RowCenter - (int)sz.Width / 2;
                            g.FillRectangle(Brushes.White, new Rectangle(112, (RowStart - 4 + ((j % 29) * Rowheight)), 628, Rowheight - 1));
                            g.DrawString(cat, f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            if (isSeqsec(cat))
                            {
                                sz = g.MeasureString(Convert.ToString(seqno), f);

                                k = 25 - (int)sz.Width / 2;
                                g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            }
                            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            j++;

                        }
                    }

                    g.FillRectangle(Brushes.White, new Rectangle(112, (RowStart - 4 + ((j % 29) * Rowheight)), 628, Rowheight - 1));
                        SizeF sz1 = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f);
                        int k22 = RowCenter - (int)sz1.Width / 2;
                        g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f, Brushes.Black, new Point(k22, (RowStart + ((j % 29) * Rowheight))));
                        k22 = 70 - (int)sz1.Width / 2;
                        g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f, Brushes.Black, new Point(k22, (RowStart + ((j % 29) * Rowheight))));
                        flag = 0;
                        j++; continue;
                  
                    
                }

                    
                else
                {
                    //flag = 0;
                    if (reduflag == 0)
                    {
                        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    else
                    {
                       // reduflag = 0;
                        f = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    
                }
                #endregion
                string y1 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                int fact1 = y1.Length / 2;
                if (majordal.iscat(y1) != "")
                {
                    cat = y1;
                    flag = getseqno(i + 1);
                    if (isSeqsec(y1))
                    {
                       flag = getseqnoeq(i);
                    }
                    if (((j + flag+1) /24) > 0)
                    {
                        string _sourceFile = Application.StartupPath + "\\Images\\summary.jpg";
                        _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                        string path = Application.StartupPath + "\\Summary\\";
                        path = path.Replace("\\bin\\Debug", "");

                        img1.Save(path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg");
                        userSummary.s = path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg";
                        userSummary m = new userSummary();
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Clear();
                        ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Add(m);
                        img1 = System.Drawing.Image.FromFile(_sourceFile);
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count-1].Controls.Add(m);
                        g = Graphics.FromImage(img1);
                        ps.tabControl1.TabPages.Add("Page" + ((ps.tabControl1.TabPages.Count) + 1).ToString());
                        //m = new userSummary();
                        //m.pictureBox1.Image = img1;
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count-1].Controls.Add(m);
                        page++;
                        g.DrawString(page.ToString(), f, Brushes.Black, new Point(150, 165));
                        //g.DrawString(dateTimePicker1.Text.Replace("/", "."), f, Brushes.Black, new Point(630, 165));
                        g.DrawString(plantno, f, Brushes.Black, new Point(330, 165));
                        flag = 0; j = 0;
                        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        if (majordal.iscat(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value)) == "")
                        {
                            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                 
                            SizeF sz = g.MeasureString(cat, f);
                            int k = RowCenter - (int)sz.Width / 2;
                            g.DrawString(cat, f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            if (isSeqsec(cat))
                            {
                                 sz = g.MeasureString(Convert.ToString(seqno), f);

                                 k = 25 - (int)sz.Width / 2;
                                g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            }
                            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                 
                            j++;
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f);
                            //k = RowCenter - (int)sz.Width / 2;
                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f);
                           
                            //k = 25 - (int)sz.Width / 2;
                           
                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            //if (isSeqsec(cat))
                            //{
                            //    g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            //}
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f);

                            //k = 70 - (int)sz.Width / 2;

                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                           
                            //j++;
                        }
                        else
                        {
                             //int k = RowCenter - (int)sz.Width / 2;
                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f);

                           
                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            if (isSeqsec(cat))
                            {
                                SizeF sz = g.MeasureString(Convert.ToString(seqno), f);
                          
                                int k = 25 - (int)sz.Width / 2;
                                g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            }
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f);

                            //k = 70 - (int)sz.Width / 2;

                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                   

                            //j++;
                        }
                        //continue;
                    } 
                    //else
                    //{
                    //    flag = 0;
                    //    f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //    g.DrawString(y1, f, Brushes.Black, new Point(367 - fact1 * 7, (152 + ((j % 29) * 25))));
                    //    j++; continue;
                    //}
                }
                else
                {
                    int px = 0; ;
                    if(int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),out px))
                    {
                     flag = getseqno(i);
                    }
                    if (isSeqsec(cat))
                    {
                        flag = getseqnoeq(i);
                    }
                    if (((j + flag) /24) > 0)
                    {
                        string _sourceFile = Application.StartupPath + "\\Images\\summary.jpg";
                        _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                        string path = Application.StartupPath + "\\Summary\\";
                        path = path.Replace("\\bin\\Debug", "");

                        img1.Save(path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg");
                        userSummary.s = path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg";
                        userSummary m = new userSummary();
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Clear();
                        ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Add(m);
                        img1 = System.Drawing.Image.FromFile(_sourceFile);
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count-1].Controls.Add(m);
                        g = Graphics.FromImage(img1);
                        ps.tabControl1.TabPages.Add("Page" + ((ps.tabControl1.TabPages.Count) + 1).ToString());
                        //m = new userSummary();
                        //m.pictureBox1.Image = img1;
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count-1].Controls.Add(m);
                        page++;
                        g.DrawString(page.ToString(), f, Brushes.Black, new Point(150, 165));
                       // g.DrawString(dateTimePicker1.Text.Replace("/", "."), f, Brushes.Black, new Point(630, 165));
                        g.DrawString(plantno, f, Brushes.Black, new Point(330, 165));
                        flag = 0; j = 0;
                        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        if (majordal.iscat(Convert.ToString(dataGridView1.Rows[i ].Cells[2].Value)) == "")
                        {
                            SizeF sz = g.MeasureString(cat, f);
                            int k = RowCenter - (int)sz.Width / 2;
                            g.FillRectangle(Brushes.White, new Rectangle(112, (RowStart - 4 + ((j % 29) * Rowheight)), 628, Rowheight - 1));
                            g.DrawString(cat, f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            if (isSeqsec(cat))
                            {
                                 sz = g.MeasureString(Convert.ToString(seqno), f);

                                 k = 25 - (int)sz.Width / 2;
                                g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            }
                            j++;

                           //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f);
                           //k = RowCenter - (int)sz.Width / 2;
                           //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                           // sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f);

                           // k = 25 - (int)sz.Width / 2;
                           // g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                           // if (isSeqsec(cat))
                           // {
                           //     g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                           // }
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f);

                            //k = 70 - (int)sz.Width / 2;

                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                   

                            //j++;
                        }
                        else
                        {
                            if (isSeqsec(cat))
                            {
                                SizeF sz = g.MeasureString(Convert.ToString(seqno), f);

                                int k = 25 - (int)sz.Width / 2;
                                g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            }
                            //SizeF sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f);
                            //int k = RowCenter - (int)sz.Width / 2;
                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f);

                            //k = 25 - (int)sz.Width / 2;
                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            //if (isSeqsec(cat))
                            //{
                            //    g.DrawString(Convert.ToString(seqno), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            //}
                            //sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f);

                            //k = 70 - (int)sz.Width / 2;

                            //g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                   

                            //j++;
                        }
                        
                       //continue;
                    }
                    
                }
                //if (majordal.issubcat(y1.ToLower()) != "")
                //{
                //    f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    g.DrawString(y1, f, Brushes.Black, new Point(367 - fact1 * 7, (152 + ((j % 29) * 25))));
                //    y1 = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                //     g.DrawString(y1, f, Brushes.Black, new Point(10, (152 + ((j % 29) * 25)))); 
                //    j++; continue;
                //}
                //if (Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == "")
                //{
                //    string s = "";
                //    for (int p = 2; p < 12; p++)
                //    {
                //        s = Convert.ToString(dataGridView1.Rows[i].Cells[p].Value);
                //        int k = 120;
                //        f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //        g.DrawString(s, f, Brushes.Black, new Point(k + ((p - 2) * 63), (152 + ((j % 29) * 25))));
                //    }
                //    s = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                //    if (s == "119")
                //    {
                //        int lt = 0;
                //    }
                //    if (s.Length == 1)
                //    { s = "0" + s; }
                //    g.DrawString(s, f, Brushes.Black, new Point(10, (152 + ((j % 29) * 25))));
                //    f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    j++;
                //    if (i == dataGridView1.Rows.Count - 1)
                //    {
                //        string path = Application.StartupPath + "\\Summary\\";
                //        path = path.Replace("\\bin\\Debug", "");
                //        g.DrawImage(sign, new Point(510, 875));
                //        img1.Save(path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg");
                //        userSummary.s = path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg";
                //        userSummary m = new userSummary();
                //        //ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Clear();
                //        ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Add(m);
                //    }
                //    continue;
                //}
                for (int j1 = 0; j1 < dataGridView1.ColumnCount; j1++)
                {
                  //string xp=  majordal.iscat(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value).ToLower());
                    //if (xp != "" && j != 0)
                    //{

                    //    break;
                    //}
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) == "0nly Dismantling")
                    {
                        int mlt = 0;
                    }
                    if (((j + flag) / 24) > 0)
                    { break; }
                    
                    if (j1 == 2)
                    {
                        int k = 120 + ((j1 - 2) * 63);

                        y1 = Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value);
                        if (y1.Length > 8&&(y1.Contains('"')==false))
                        { g.FillRectangle(Brushes.White, new Rectangle(112, (RowStart - 4 + ((j % 29) * Rowheight)), 628, Rowheight-1)); }
                        int z = y1.IndexOf("     ");
                        int fact2 = y1.Length / 2;
                        if (y1.Length > 5)
                        { k = 467 - fact2 * 5; }
                        if (z != -1)
                        {
                            SizeF sz = g.MeasureString(y1.Substring(0, z), f);
                            SizeF sz1 = g.MeasureString(y1.Substring(z), f);
                            k = RowCenter - (int)((sz.Width + sz1.Width + 35) / 2);
                            g.DrawString(y1.Substring(0, z), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                            Pen p1 = new Pen(Color.Black, 2);
                            int up = getUppercase(y1.Substring(0, z));
                            int pts = 0; 
                            //(up * 11) + Convert.ToInt32((y1.Substring(0, z).Length - up) * 9); //- Convert.ToInt32((y1.Substring(0, z).Length - up) * 0.3);
                           
                            //if (pts > 250 && up == 0)
                            //{ pts -= Convert.ToInt32(pts * 0.1); }
                            pts = Convert.ToInt32(sz.Width);
                            g.DrawLine(p1, new Point(k + pts + 3, (RowStart + 12 + ((j % 29) * Rowheight))), new Point(k + 15 + pts + 3, (RowStart + 12 + ((j % 29) * Rowheight))));
                            g.DrawString(y1.Substring(z), f, Brushes.Black, new Point(k + pts , (RowStart + ((j % 29) * Rowheight))));

                        }
                        else
                        {
                            if (reduflag == 0)
                            {
                                if (majordal.iscat(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value).ToLower()) != "")
                                {
                                    f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                }
                                if (y1.Length > 8)
                                {
                                    SizeF sz = g.MeasureString(y1, f);
                                    k = RowCenter - (int)sz.Width / 2;
                                    g.DrawString(y1, f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                                }
                                else
                                {
                                    k = 125;
                                    g.DrawString(y1, f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                                }
                                f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                 
                            }
                            else
                            {
                               
                                k = 115;
                                g.DrawString(y1, f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight)))); 
                           
                            }
                        }
                    }
                    if (j1 > 2)
                    {
                        if (reduflag == 0)
                        {
                            int k = 120 + ((j1 - 2) * 63);
                            g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                        }
                        else
                        {
                            int k = 115 + ((j1 - 2) * 63);
                            g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                        }
                    }
                        if (j1 == 0)
                        {
                            SizeF sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f);
                          int  k = 25 - (int)sz.Width / 2;
                            g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                        }
                        if (j1 == 1)
                        {
                            SizeF sz = g.MeasureString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f);
                            int k = 70 - (int)sz.Width / 2;
                            g.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[j1].Value), f, Brushes.Black, new Point(k, (RowStart + ((j % 29) * Rowheight))));
                        }
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == "Total")
                {
                    g.DrawRectangle(new Pen(Brushes.DodgerBlue, 2), new Rectangle(110, (RowStart-5 + ((j % 29) * Rowheight)) , 635,  Rowheight));
                }
                    j++;
                    if (i == dataGridView1.Rows.Count - 1)
                    {
                        string path = Application.StartupPath + "\\Summary\\";
                        path = path.Replace("\\bin\\Debug", "");
                        //g.DrawImage(sign, new Point(510, 875));
                        img1.Save(path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg");
                        userSummary.s = path + (ps.tabControl1.TabPages.Count).ToString() + ".jpg";
                        userSummary m = new userSummary();
                        // ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Clear();
                        ps.tabControl1.TabPages[ps.tabControl1.TabPages.Count - 1].Controls.Add(m);
                    }
                    if (reduflag == 1)
                    { reduflag = 0; }

                    flag = 0;
                }
            
            ps.Show();
            }
            catch (Exception ex)
            { }

        }

        private void btnExpoToExcel_Click(object sender, EventArgs e)
        {
            //string path = System.Windows.Forms.Application.StartupPath + "\\Images\\sbgexcl.xlsx";
            //path = path.Replace("\\bin\\Debug", "");
            //Excel.Workbook MyBook = null;
            //Excel.Application MyApp = null;
            //Excel.Worksheet MySheet = null;
            //MyApp = new Excel.Application();
            //MyApp.Visible = true;
            //MyBook = MyApp.Workbooks.Open(path);
            //MySheet = (Excel.Worksheet)MyBook.Sheets[2]; // Explicit cast is not required here
            ////int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    int rowfact = ((i / 29) + 1) * 5;
            //    if (i % 29 == 0 && i != 0)
            //    {
            //        MySheet.Cells[1, 5] = lblPageNo.Text;
            //        MySheet.Cells[1, 11] = dateTimePicker1.Text;
            //    }
            //    else
            //    {
            //        int k = i + rowfact - (rowfact / 5);
            //        for (int c = 0; c < 12; c++)
            //        {
            //            string s = Convert.ToString(dataGridView1.Rows[i].Cells[c].Value);

            //            MySheet.Cells[k, c + 1] = s;
            //        }

            //    }
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
