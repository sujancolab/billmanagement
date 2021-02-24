using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
//using Microsoft.Office.Core;
using Excel=Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace SBGhadgev1
{
    public partial class AmountSheet : Form
    {
        public AmountSheet()
        {
            InitializeComponent();
            SectionSeq = new string[10];
            SectionSeq[0] = "Fabrication & Erection";
            SectionSeq[1] = "Only Dismantling";
            SectionSeq[2]="Labour Supply";
            SectionSeq[3] = "Dismantling & Refitting";
            SectionSeq[4] = "EQ Erection";
            SectionSeq[5] = "EQ Dismantling";
            SectionSeq[6] = "EQ Shifting";
            SectionSeq[7] = "EQ Loading";
            SectionSeq[8] = "EQ Unloading";
            SectionSeq[9] = "A.C. Sheet";
        }

        private void AmountSheet_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            this.Height = 700;
            tabControl1.Height = 700;

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
                        return 1; }
                    else {
                        return -1; }
                }

            }
            else
            {
                cmp = string.Compare(st1[0], st2[0]);
                return cmp / Math.Abs(cmp);

            }

            }
            catch (Exception ex)
            {

              
            }
            return 0;
        }
        //public int compitemcode(string code1, string code2)
        //{
            
        //    if (code1 == code2)
        //    { return 0; }
        //    if (code1 == "")
        //    {
        //        return 1;
        //    }
        //    if (code2 == "")
        //    {
        //        return -1;
        //    }
        //    int i = 0;
        //    if (code1.Contains("&") || code2.Contains("&"))
        //    {
        //        if (code1.Contains("&") && !code2.Contains("&"))
        //        {
        //            int m = code1[0].CompareTo(code2[0]);
        //            if (m == 0)
        //            {
        //                //char[] ch1 = { '-', '&' };
        //                //string[] cs1 = code1.Split(ch1);
        //                //string[] cs2 = code2.Split(ch1);

        //                //if (Convert.ToInt32(cs1[1]) > Convert.ToInt32(cs2[1]))
        //                //{return  }
        //                return 1;
        //            }
        //            else { return m; }
        //        }
        //        if (!code1.Contains("&") && code2.Contains("&"))
        //        {
        //            int m = code1[0].CompareTo(code2[0]);
        //            if (m == 0)
        //            {
        //                return -1;
        //            }
        //            else { return m; }
        //        }
        //        if (code1.Contains("&") && code2.Contains("&"))
        //        {
        //            int m = code1[0].CompareTo(code2[0]);
        //            if (m == 0)
        //            {
        //                m = code1[code1.Length - 1].CompareTo(code2[code2.Length - 1]);
        //                return m;
        //            }
        //            else { return m; }
        //        }

        //    }
        //    else
        //    {
        //        char[] ch = { '-' };
        //        string[] sx1 = code1.Split(ch);
        //        string[] sx2 = code2.Split(ch);
        //        i = string.Compare(sx1[0], sx2[0]);

        //        if (i != 0) { return i; }
        //        if (!char.IsLetter(sx1[1][sx1[1].Length - 1]))
        //        {
        //            if (char.IsLetter(sx2[1][sx2[1].Length - 1]))
        //            {
        //                //i = string.Compare(sx1[1].Substring(0, sx1[1].Length - 1), sx2[1].Substring(0, sx2[1].Length - 1));
        //                string s1 = sx1[1]; ;
        //                // s1 = s1.Remove(s1.Length - 1);
        //                string s2 = sx2[1];
        //                s2 = s2.Remove(s2.Length - 1);
        //                if (Convert.ToInt32(s1) > Convert.ToInt32(s2))
        //                { return 1; }
        //                if (Convert.ToInt32(s1) < Convert.ToInt32(s2))
        //                { return -1; }
        //            }
        //            else
        //            {
        //                string s1 = sx1[1]; ;
        //                // s1 = s1.Remove(s1.Length - 1);
        //                string s2 = sx2[1];
        //                // s2 = s2.Remove(s2.Length - 1);
        //                if (Convert.ToInt32(s1) > Convert.ToInt32(s2))
        //                { return 1; }
        //                if (Convert.ToInt32(s1) < Convert.ToInt32(s2))
        //                { return -1; }

        //            }

        //        }
        //        if (!char.IsLetter(sx2[1][sx2[1].Length - 1]))
        //        {

        //            if (char.IsLetter(sx1[1][sx1[1].Length - 1]))
        //            {
        //                //i = string.Compare(sx1[1].Substring(0, sx1[1].Length - 1), sx2[1].Substring(0, sx2[1].Length - 1));
        //                string s1 = sx1[1]; ;
        //                s1 = s1.Remove(s1.Length - 1);
        //                string s2 = sx2[1];
        //                //s2 = s2.Remove(s2.Length - 1);
        //                if (Convert.ToInt32(s1) > Convert.ToInt32(s2))
        //                { return 1; }
        //                if (Convert.ToInt32(s1) < Convert.ToInt32(s2))
        //                { return -1; }
        //            }
        //            else
        //            {
        //                string s1 = sx1[1]; ;
        //                // s1 = s1.Remove(s1.Length - 1);
        //                string s2 = sx2[1];
        //                // s2 = s2.Remove(s2.Length - 1);
        //                if (Convert.ToInt32(s1) > Convert.ToInt32(s2))
        //                { return 1; }
        //                if (Convert.ToInt32(s1) < Convert.ToInt32(s2))
        //                { return -1; }

        //            }



        //        }
        //        string s11 = code1.Remove(0, 2);
        //        s11 = s11.Remove(s11.Length - 1);
        //        string s12 = code2.Remove(0, 2);
        //        s12 = s12.Remove(s12.Length - 1);
        //        if (Convert.ToInt32(s11) > Convert.ToInt32(s12))
        //        { return 1; }
        //        if (Convert.ToInt32(s11) < Convert.ToInt32(s12))
        //        { return -1; }
        //        i = string.Compare(code1.Substring(code1.Length - 1), code2.Substring(code2.Length - 1));
        //    }
        //    return i;
        //}
        public DataSet Sortitems(DataSet ds)
        {
            DataSet ds2 = new DataSet();
            System.Data.DataTable ds1 = new System.Data.DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            ds1.Columns.Add("pageno");
            ds1.Columns.Add("qty");
            ds1.Columns.Add("unitrate");
            ds1.Columns.Add("amount");
            int[] rownum = new int[ds.Tables[0].Rows.Count];
            int min = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                min = 0;
                string itemcode = Convert.ToString(ds.Tables[0].Rows[i][0]);                
                for (int j = i; j < ds.Tables[0].Rows.Count; j++)
                {
                    string i2 = Convert.ToString(ds.Tables[0].Rows[j][0]);
                    //if (itemcode.Contains("E-13"))
                    //{
                    //    int nl = 0;
                    //}
                    int p = compitemcode(itemcode, i2);
                    if (p == 1)
                    {
                        itemcode = Convert.ToString(ds.Tables[0].Rows[j][0]);
                        min = j;
                        DataRow dr = ds1.NewRow();
                        dr[0] = ds.Tables[0].Rows[i][0].ToString();
                        dr[1] = ds.Tables[0].Rows[i][1].ToString();
                        dr[2] = ds.Tables[0].Rows[i][2].ToString();
                        dr[3] = ds.Tables[0].Rows[i][3].ToString();
                        dr[4] = ds.Tables[0].Rows[i][4].ToString();
                        try
                        {
                           dr[5] = ds.Tables[0].Rows[i][5].ToString();
                           dr[6] = ds.Tables[0].Rows[i][6].ToString();
                           dr[7] = ds.Tables[0].Rows[i][7].ToString();
                           dr[8] = ds.Tables[0].Rows[i][8].ToString();
                        }
                        catch (Exception ex)
                        {
                            
                           
                        }
                        ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                        ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                        ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                        ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                        ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                        try
                        {
                             ds.Tables[0].Rows[i][5] = ds.Tables[0].Rows[j][5];
                             ds.Tables[0].Rows[i][6] = ds.Tables[0].Rows[j][6];
                             ds.Tables[0].Rows[i][7] = ds.Tables[0].Rows[j][7];
                             ds.Tables[0].Rows[i][8] = ds.Tables[0].Rows[j][8];

                        }
                        catch (Exception ex)
                        {
                            
                            
                        }
                        ds.Tables[0].Rows[j][0] = dr[0];
                        ds.Tables[0].Rows[j][1] = dr[1];
                        ds.Tables[0].Rows[j][2] = dr[2];
                        ds.Tables[0].Rows[j][3] = dr[3];
                        ds.Tables[0].Rows[j][4] = dr[4];
                        try
                        {
                            ds.Tables[0].Rows[j][5] = dr[5];
                            ds.Tables[0].Rows[j][6] = dr[6];
                            ds.Tables[0].Rows[j][7] = dr[7];
                            ds.Tables[0].Rows[j][8] = dr[8];
                        }
                        catch (Exception ex)
                        {
                            
                            
                        }
                    }
                }

            }
            ds2.Tables.Add(ds1);
            return ds;
        }
        public DataSet Sortitems1(DataSet ds)
        {
            DataSet ds2 = new DataSet();
            System.Data.DataTable ds1 = new System.Data.DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
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
                       // dr[4] = ds.Tables[0].Rows[i][4].ToString();
                        ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                        ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                        //ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                        //ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                        //ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                        ds.Tables[0].Rows[j][0] = dr[0];
                        ds.Tables[0].Rows[j][1] = dr[1];
                        //ds.Tables[0].Rows[j][2] = dr[2];
                        //ds.Tables[0].Rows[j][3] = dr[3];
                      //  ds.Tables[0].Rows[j][4] = dr[4];
                    }
                }

            }
            ds2.Tables.Add(ds1);
            return ds;
        }
         public DataSet Sortitems11(DataSet ds)
        {
            DataSet ds2 = new DataSet();
            System.Data.DataTable ds1 = new System.Data.DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
           
            ds1.Columns.Add("unit");
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
                        dr[2] = ds.Tables[0].Rows[i][2].ToString();
                        dr[3] = ds.Tables[0].Rows[i][3].ToString();
                       // dr[4] = ds.Tables[0].Rows[i][4].ToString();
                        ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                        ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                        ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                        ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                        //ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                        ds.Tables[0].Rows[j][0] = dr[0];
                        ds.Tables[0].Rows[j][1] = dr[1];
                        ds.Tables[0].Rows[j][2] = dr[2];
                        ds.Tables[0].Rows[j][3] = dr[3];
                      //  ds.Tables[0].Rows[j][4] = dr[4];
                    }
                }

            }
            ds2.Tables.Add(ds1);
            return ds;
        }
         public DataSet Sortitems12(DataSet ds)
         {
             DataSet ds2 = new DataSet();
             System.Data.DataTable ds1 = new System.Data.DataTable();
             ds1.Columns.Add("itemcode");
             ds1.Columns.Add("subcat");
             ds1.Columns.Add("size");
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
                         dr[2] = ds.Tables[0].Rows[i][2].ToString();
                           dr[3] = ds.Tables[0].Rows[i][3].ToString();
                          dr[4] = ds.Tables[0].Rows[i][4].ToString();
                         ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                         ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                         ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                         ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                         ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                         ds.Tables[0].Rows[j][0] = dr[0];
                         ds.Tables[0].Rows[j][1] = dr[1];
                         ds.Tables[0].Rows[j][2] = dr[2];
                         ds.Tables[0].Rows[j][3] = dr[3];
                           ds.Tables[0].Rows[j][4] = dr[4];
                     }
                 }

             }
             ds2.Tables.Add(ds1);
             return ds;
         }
        public DataSet Composeitems1(DataSet ds,string mno, string cat)
        {
            DataSet ds2 = new DataSet();
            System.Data.DataTable ds1 = new System.Data.DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("unit");
            ds1.Columns.Add("Desc2");
            int[] rownum = new int[ds.Tables[0].Rows.Count];
            int min = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                min = 0;
                string itemcode = Convert.ToString(ds.Tables[0].Rows[i][0]);
                string itemname;
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
                        // dr[4] = ds.Tables[0].Rows[i][4].ToString();
                        ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                        ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                        //ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                        //ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                        //ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                        ds.Tables[0].Rows[j][0] = dr[0];
                        ds.Tables[0].Rows[j][1] = dr[1];
                        //ds.Tables[0].Rows[j][2] = dr[2];
                        //ds.Tables[0].Rows[j][3] = dr[3];
                        //  ds.Tables[0].Rows[j][4] = dr[4];
                    }
                }

            }
            ds2.Tables.Add(ds1);
            return ds;
        }
        string[] SectionSeq;

        public int getseqno(int startIndex, DataGridView d)
        {
            if (startIndex >= d.Rows.Count-1 )
            { return 1; }
            int rows = startIndex + 1;
            for (int i = startIndex + 1; i < d.Rows.Count; i++)
            {
                rows = i;
                int k = 0;
                if (int.TryParse(Convert.ToString(d.Rows[i].Cells[0].Value), out k))
                {
                    return (rows - startIndex);
                }
            }
            return (rows - startIndex);
        }
        public void changetotalpage()
        {
            int xp = tabControl1.TabPages.Count;
            for (int i = xp-1; i >= lasttabcount; i--)
            {
                tabControl1.TabPages.RemoveAt(i); 
            }
            Amount x = new Amount();
            double sum = 0;
            for (int i = 0; i < lasttabcount; i++)
            {
               
                //if (n1 == 1)
                //{break; }
                if (i % 10 == 0)
                {
                    x = new Amount();
                    tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                }
                Amount c = (Amount)tabControl1.TabPages[i].Controls[0];
                x.dataGridView1.Rows[0].Cells[2].Value = "Amount Page No";
                x.dataGridView1.Rows[((i * 2) + 1) % 20].Cells[2].Value = i + 1;
                sum += Convert.ToDouble(c.lblpageTotal.Text);
                x.dataGridView1.Rows[((i * 2) + 1) % 20].Cells[6].Value = RoundAmount(c.lblpageTotal.Text);
                x.txtBillno.Text = txtmno.Text;
                x.txtpono.Text = txtPo.Text;
                x.txtdate.Text = dtpdate.Text;
                x.txtPageno.Text = "0";
                x.lblpageTotal.Text = RoundAmount(sum.ToString());


            }

            //try
            //{
            //if (tabControl1.TabPages.Count > 1)
            //{
            //    Amount x = (Amount)tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls[0];
            //    for (int i = 0; i < (tabControl1.TabPages.Count - 1) * 2; i += 2)
            //    {
            //        x.dataGridView1.Rows[i].Cells[6].Value = ((Amount)tabControl1.TabPages[(i - 1) / 2].Controls[0]).lblpageTotal.Text;
            //    }
            //    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Clear();
            //    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
            //}
            //}
            //catch (Exception ex)
            //{ 
            //    MessageBox.Show(ex.Message);
            //}


        }
        public string RoundAmount(string s)
        {

            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(s);
                d = Math.Round(d, 2);
                int i = s.IndexOf('.');
                if (i == -1)
                { s += ".00"; return s; }
                if (s.Length - i == 2)
                { s += "0"; return s; }
                if (s.Length - i > 3)
                { s = s.Substring(0, i + 3); }

            }
            catch (Exception ex)
            { }

            return d.ToString(); ;
        }
        public void TRIMCODEs()
        {
            string[] lst = { "O-14", "O-15", "O-16", "O-17", "O-18", "O-19", "O-20", "O-21", "O-22", "O-23" , "O-24"};
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                try
                {

                    for (int j = 0; j < ((Amount)tabControl1.TabPages[i].Controls[0]).dataGridView1.Rows.Count; j++)
                    {
                        for (int k = 0; k < lst.Length; k++)
                        {


                            if (Convert.ToString(((Amount)tabControl1.TabPages[i].Controls[0]).dataGridView1.Rows[j].Cells[1]).StartsWith(lst[k]))
                            {
                                ((Amount)tabControl1.TabPages[i].Controls[0]).dataGridView1.Rows[j].Cells[1].Value = Convert.ToString(((Amount)tabControl1.TabPages[i].Controls[0]).dataGridView1.Rows[j].Cells[1]).Replace(lst[k], "O-13");


                            }


                        }

                    }

                }
                catch (Exception ex)
                { }
            }
        
        
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
        string[] ocodes = { "O-14", "O-15", "O-16", "O-17", "O-18", "O-19", "O-20", "O-21", "O-22", "O-23", "O-24" };
        public void repOCodes(ref DataGridView d)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                for (int j = 0; j < ocodes.Length; j++)
                {
                    if (Convert.ToString(d.Rows[i].Cells[1].Value) == ocodes[j])
                    { d.Rows[i].Cells[1].Value = "O-13";
                      break;
                    }
                    
                }
                if (Convert.ToString(d.Rows[i].Cells[1].Value).StartsWith("I-3"))
                { d.Rows[i].Cells[1].Value = "I-3"; }
                if (Convert.ToString(d.Rows[i].Cells[1].Value).StartsWith("I-6"))
                { d.Rows[i].Cells[1].Value = "I-6"; }
                if (Convert.ToString(d.Rows[i].Cells[1].Value).StartsWith("H-3"))
                { d.Rows[i].Cells[1].Value = "H-3"; }
                if (Convert.ToString(d.Rows[i].Cells[1].Value).ToLower().Contains("z"))
                { d.Rows[i].Cells[1].Value = ""; }
            }
        
        }
        public int getseqnoeq(int startIndex,DataGridView d)
        {
            if (startIndex >= d.Rows.Count-1 )
            { return 0; }
            int rows = startIndex +1;
           if (majordal.iscat(Convert.ToString(d.Rows[startIndex].Cells[2].Value)) != "")
            { rows = startIndex + 2; }
            for (int i = rows; i < d.Rows.Count; i++)
            {
                rows = i;
                //int k = 0;
                if (Convert.ToString(d.Rows[i].Cells[1].Value) != "" || Convert.ToString(d.Rows[i].Cells[6].Value) != "")
                {
                    return (rows - startIndex); 
                }
                 

            }
            return (rows - startIndex);
        }
        public static int lasttabcount, sumcount;
        private void btnload_Click(object sender, EventArgs e)
        {
            //try
            //{
                Amount a = new Amount();
                a.dataGridView1.Rows.Clear();
                DataGridView d = a.dataGridView1;
                int seq = 0;
                string subcat = "", cat = "",testsubcat="";
               // majordal.insertDupsum(txtmno.Text);
                Measure m3 = new Measure();
                DataSet clamedamt = majordal.getClaimedAmt(txtmno.Text);
                if (clamedamt.Tables[0].Rows.Count > 0)
                {
                    string pagno = "";
                    this.tabControl1.TabPages.Clear();
                    Amount x2 = new Amount();
                    for (int i = 0; i < clamedamt.Tables[0].Rows.Count; i++)
                    {
                        this.Text = "AmountSheet Loading " + (i + 1).ToString() + "/" + clamedamt.Tables[0].Rows.Count.ToString();
                        if (pagno != Convert.ToString(clamedamt.Tables[0].Rows[i][5]))
                        {
                            pagno = Convert.ToString(clamedamt.Tables[0].Rows[i][5]);
                            x2 = new Amount();
                            x2.txtBillno.Text = txtmno.Text;
                            x2.txtdate.Text = dtpdate.Text;
                            x2.txtPageno.Text = pagno;
                            x2.txtpono.Text = txtPo.Text;
                            x2.lblpageTotal.Text = RoundAmount( Convert.ToString(clamedamt.Tables[0].Rows[i][12]));
                            x2.dataGridView1.Rows.Clear();
                            this.tabControl1.TabPages.Add("Page" + (tabControl1.TabCount + 1).ToString());
                            this.tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(x2);
                        }
                        int j = x2.dataGridView1.Rows.Add();
                        x2.dataGridView1.Rows[j].Cells[0].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][1]);
                        x2.dataGridView1.Rows[j].Cells[1].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][6]);
                        x2.dataGridView1.Rows[j].Cells[2].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][7]);
                        x2.dataGridView1.Rows[j].Cells[3].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][8]);
                        x2.dataGridView1.Rows[j].Cells[4].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][9]);
                        x2.dataGridView1.Rows[j].Cells[5].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][10]);
                        x2.dataGridView1.Rows[j].Cells[6].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][11]);
                        x2.dataGridView1.Rows[j].Cells[7].Value = Convert.ToString(clamedamt.Tables[0].Rows[i][13]);

                    }
                    double sum1 = 0;
                    int mn = tabControl1.TabPages.Count - 1;
                    lasttabcount = mn;
                    if (mn > 1)
                    {
                        for (int i = mn; i >= 0; i--)
                        {
                            if (i == tabControl1.TabPages.Count - 1)
                            {
                                x2 = new Amount();
                                tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x2);
                            }
                           
                            Amount c = (Amount)tabControl1.TabPages[i].Controls[0];
                            if (mn >= 10)
                            {
                                x2.dataGridView1.Rows[0].Cells[2].Value = "Amount Page No";
                                x2.dataGridView1.Rows[(i * 1) % 20 + 1].Cells[2].Value = i + 1;

                                sum1 += Convert.ToDouble(c.lblpageTotal.Text);
                                x2.dataGridView1.Rows[(i * 1) % 20 + 1].Cells[6].Value = RoundAmount(c.lblpageTotal.Text);
                                x2.txtBillno.Text = txtmno.Text;
                                x2.txtpono.Text = txtPo.Text;
                                x2.txtdate.Text = dtpdate.Text;
                                x2.txtPageno.Text = (i).ToString();
                                x2.lblpageTotal.Text = RoundAmount(sum1.ToString());
                            }
                            else
                            {
                                x2.dataGridView1.Rows[0].Cells[2].Value = "Amount Page No";
                                x2.dataGridView1.Rows[(i * 2) % 20 + 1].Cells[2].Value = i + 1;

                                sum1 += Convert.ToDouble(c.lblpageTotal.Text);
                                x2.dataGridView1.Rows[(i * 2) % 20 + 1].Cells[6].Value = RoundAmount(c.lblpageTotal.Text);
                                x2.txtBillno.Text = txtmno.Text;
                                x2.txtpono.Text = txtPo.Text;
                                x2.txtdate.Text = dtpdate.Text;
                                x2.txtPageno.Text = (i).ToString();
                                x2.lblpageTotal.Text = RoundAmount(sum1.ToString());
                            }

                        }
                    }
                    this.Text = "AmountSheet";
                    return;

                }

                ////////////////
                majordal.InitSummary(txtmno.Text);
                for (int i = 0; i < SectionSeq.Length; i++)
                {
                    this.Text = "AmountSheet Preprocessing...";
                    DataSet ds = new DataSet();
                    int eqFlag = 0;
                    if (i == 8)
                    {
                        int fx = 0;
                    }
                    if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading" || SectionSeq[i] == "EQ Shifting")
                    {
                        ds = majordal.getdupmeasureSum(txtmno.Text, SectionSeq[i]);
                        ds = Sortitems(ds);
                        eqFlag = 1;
                        int k = 0;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            k = d.Rows.Add();
                            if (isSeqsec(SectionSeq[i]))
                            {
                                seq++;
                                d.Rows[k].Cells[0].Value = seq;
                            }
                            if (SectionSeq[i] == "EQ Shifting")
                            {
                                d.Rows[k].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[0][0]);
                            }
                            d.Rows[k].Cells[2].Value = SectionSeq[i];
                            d.Rows[k].Cells[2].Style.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                        }
                        string itemcode2 = "",str1="";
                        for (int b = 0; b < ds.Tables[0].Rows.Count; b++)
                        {
                            if (seq == 39)
                            {
                                int k5 = 5;
                            }
                            
                            if (itemcode2 != Convert.ToString(ds.Tables[0].Rows[b][0]) )
                            {
                                str1 = "";
                               
                                if (SectionSeq[i] == "EQ Shifting")
                                {
                                    //itemcode2 = Convert.ToString(ds.Tables[0].Rows[b][0]);

                                    k = d.Rows.Add();
                                    d.Rows[k].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[b][1]);

                                    d.Rows[k].Cells[3].Value = Convert.ToString(ds.Tables[0].Rows[b][6]);
                                    d.Rows[k].Cells[4].Value = Convert.ToString(ds.Tables[0].Rows[b][3]);
                                    d.Rows[k].Cells[5].Value = Convert.ToString(ds.Tables[0].Rows[b][7]);
                                    //Modified Round Amount
                                    d.Rows[k].Cells[6].Value = RoundAmount(Convert.ToString(ds.Tables[0].Rows[b][8]));
                                    continue;

                                }
                                if (str1 != Convert.ToString(ds.Tables[0].Rows[b][1]) )
                                {
                                    str1 = Convert.ToString(ds.Tables[0].Rows[b][1]);
                                }
                                itemcode2 = Convert.ToString(ds.Tables[0].Rows[b][0]);
                                
                                k = d.Rows.Add();
                                d.Rows[k].Cells[1].Value = itemcode2;
                                if (cat != "Lasbour Supply"||cat!="EQ Shifting")
                                {
                                    d.Rows[k].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[b][1]);
                                    k = d.Rows.Add();
                                }
                                d.Rows[k].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[b][4]);

                                d.Rows[k].Cells[3].Value = Convert.ToString(ds.Tables[0].Rows[b][6]);
                                d.Rows[k].Cells[4].Value = Convert.ToString(ds.Tables[0].Rows[b][3]);
                                d.Rows[k].Cells[5].Value = Convert.ToString(ds.Tables[0].Rows[b][7]);
                                //Modified Round Amount
                                d.Rows[k].Cells[6].Value = RoundAmount(Convert.ToString(ds.Tables[0].Rows[b][8]));




                            }
                            else
                            {
                                if (str1 != Convert.ToString(ds.Tables[0].Rows[b][1])&&cat!="EQ Shifting")
                                {
                                    str1 = Convert.ToString(ds.Tables[0].Rows[b][1]);
                                    k = d.Rows.Add();
                                    d.Rows[k].Cells[1].Value = Convert.ToString(ds.Tables[0].Rows[b][0]);

                                    d.Rows[k].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[b][1]);
                                }
                                k = d.Rows.Add();
                                d.Rows[k].Cells[2].Value = Convert.ToString(ds.Tables[0].Rows[b][4]);

                                d.Rows[k].Cells[3].Value = Convert.ToString(ds.Tables[0].Rows[b][6]);
                                d.Rows[k].Cells[4].Value = Convert.ToString(ds.Tables[0].Rows[b][3]);
                                d.Rows[k].Cells[5].Value = Convert.ToString(ds.Tables[0].Rows[b][7]);
                                //Modified Round Amount
                                d.Rows[k].Cells[6].Value = RoundAmount(Convert.ToString(ds.Tables[0].Rows[b][8]));
                            }

                        }

                   
                    }///eq items
                    else
                    {
                        ds = majordal.getmeasureSumSeq(txtmno.Text, SectionSeq[i]);
                        ds = Sortitems1(ds);
                        int k = 0;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            k = d.Rows.Add();
                            if (isSeqsec(SectionSeq[i]))
                            {
                                seq++;
                                d.Rows[k].Cells[0].Value = seq;
                            }
                            d.Rows[k].Cells[2].Value = SectionSeq[i];
                            d.Rows[k].Cells[2].Style.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                        }
                        k = 0;
                        if (seq == 19)
                        { 
                            int zx = 0;
                        }
                        double qtysum = 0, amtsum = 0;

                        List<string> lst = new List<string>();
                        for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
                        {///
                            int foundflag = 0;
                            if (n == 10)
                            {
                                int g = 0;
                            }
                            for (int p = 0; p < lst.Count; p++)
                            {
                                string str = ds.Tables[0].Rows[n][1].ToString();
                                if (lst[p] == ds.Tables[0].Rows[n][1].ToString())
                                { foundflag = 1; break; }

                            }
                            if (foundflag == 0)
                            {
                                lst.Add(ds.Tables[0].Rows[n][1].ToString());
                                DataSet ds6 = majordal.getdupmeasureSumFabSeq1(txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n][1].ToString());
                                ds6 = Sortitems11(ds6);
                                for (int m = 0; m < ds6.Tables[0].Rows.Count; m++)
                                {
                                    DataSet ds7 = majordal.getdupmeasureSumFabSeq2(txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds6.Tables[0].Rows[m][2]));
                                    string x1 = ds6.Tables[0].Rows[m][0].ToString(); ;
                                    string icode = "";
                                    if (subcat != ds6.Tables[0].Rows[m][1].ToString())
                                    {
                                        subcat = ds6.Tables[0].Rows[m][1].ToString();
                                        
                                        k = d.Rows.Add();

                                        d.Rows[k].Cells[2].Value = ds6.Tables[0].Rows[m][1].ToString();
                                        x1 = ds6.Tables[0].Rows[m][0].ToString();
                                        if (ds6.Tables[0].Rows[m][2].ToString() == "")

                                        { d.Rows[k].Cells[1].Value = x1;
                                            
                                        }
                                        else
                                        {
                                            int l = 0;
                                            for (l = x1.Length - 1; l > 0; l--)
                                            {
                                                if (char.IsDigit(Convert.ToChar(x1[l])))
                                                { break; }

                                            }
                                            d.Rows[k].Cells[1].Value = x1.Substring(0, l + 1);
                                            if (subcat.Contains("Reducer") && !subcat.Contains("Joint"))
                                            { d.Rows[k].Cells[1].Value = ""; }
                                            icode = d.Rows[k].Cells[1].Value.ToString();
                                        }
                                       
                                        if (!isSeqsec(SectionSeq[i]))
                                        {
                                            seq++;
                                            d.Rows[k].Cells[0].Value = seq.ToString();
                                        }
                                        if (subcat == "Drilling Hole Dia")
                                        { d.Rows[k].Cells[1].Value = x1[0].ToString(); ; }
                                    }
                                    d.Rows[k].Cells[2].Style.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                                    //if (!isSeqsec(SectionSeq[i]))
                                    //{
                                    //    if (majordal.issubcat(SectionSeq[i], ds6.Tables[0].Rows[m][1].ToString()) != "")
                                    //    {
                                    //        seq++;
                                    //        d.Rows[k].Cells[0].Value = seq.ToString();
                                    //    }
                                    //}
                                    if (seq == 19)
                                    {
                                        int zx3 = 0;
                                    }
                                    string size = Convert.ToString(ds6.Tables[0].Rows[m][2]);// +Convert.ToString(ds6.Tables[0].Rows[m][3]);

                                    if (size == "")
                                    {
                                        //d.Rows[k].Cells[1].Value = x1;
                                        if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading" || SectionSeq[i] == "EQ Shifting")
                                        {
                                            d.Rows[k].Cells[2].Value = ds.Tables[0].Rows[n][4].ToString();
                                        }

                                    }
                                    else
                                    {
                                        k = d.Rows.Add();
                                        int l = 0;
                                        for (l = x1.Length - 1; l > 0; l--)
                                        {
                                            if (char.IsDigit(Convert.ToChar(x1[l])))
                                            { break; }

                                        }
                                        //d.Rows[k].Cells[1].Value = x1.Substring(l);
                                        d.Rows[k].Cells[1].Value = x1.Substring(l + 1).ToLower();
                                        if (subcat == "Drilling Hole Dia")
                                        { d.Rows[k].Cells[1].Value = x1; ; }
                                    
                                        if (subcat.Contains("Reducer") && !subcat.Contains("Joint"))
                                        { d.Rows[k].Cells[1].Value = x1; }
                                            d.Rows[k].Cells[2].Value = size;
                                    }
                                    //DataSet ds1 = majordal.getmeasureSum22(txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][2]));//, Convert.ToString(ds.Tables[0].Rows[n][4])
                                    qtysum = Convert.ToDouble(ds7.Tables[0].Rows[0][0]);
                                    x1 = Convert.ToString(ds7.Tables[0].Rows[0][2]);
                                    d.Rows[k].Cells[3].Value = qtysum;
                                    d.Rows[k].Cells[4].Value = ds6.Tables[0].Rows[m][3].ToString();
                                    d.Rows[k].Cells[5].Value = ds7.Tables[0].Rows[0][1].ToString();
                                    //Modified Round Amount
                                    ///
                                    amtsum = Convert.ToDouble(x1);
                                    string amtstr = RoundAmount(amtsum.ToString());
                                    //int so = amtstr.IndexOf('.');
                                    //if (so != -1 && so + 3 < amtstr.Length)
                                    //{
                                    //    amtstr = amtstr.Substring(0, so + 3);
                                    //}
                                    d.Rows[k].Cells[6].Value = amtstr;
                                    if (amtsum == 0)
                                    {
                                        DataSet dat = majordal.getRate(SectionSeq[i], subcat, d.Rows[k].Cells[2].Value.ToString());
                                        if (Convert.ToString(dat.Tables[0].Rows[0][1]) != "")
                                        {
                                            decimal rt = Convert.ToDecimal(Convert.ToString(dat.Tables[0].Rows[0][1]));
                                            d.Rows[k].Cells[1].Value = Convert.ToString(dat.Tables[0].Rows[0][0]);
                                            d.Rows[k].Cells[5].Value = Convert.ToString(dat.Tables[0].Rows[0][1]);
                                            d.Rows[k].Cells[6].Value = Decimal.Round(Convert.ToDecimal(d.Rows[k].Cells[3].Value) * rt, 2).ToString();
                                        }
                                        for (int j = 0; j < d.ColumnCount; j++)
                                        {
                                            d.Rows[k].Cells[j].Style.BackColor = Color.DarkOrange;
                                        }
                                    }
                                }

                            }
                        }
                    }
                    // ds = Sortitems(ds);

                }//end of sections


                //            if (subcat != ds.Tables[0].Rows[n][1].ToString() || cat != SectionSeq[i])
                //            {
                //                subcat = ds.Tables[0].Rows[n][1].ToString();
                //                k = d.Rows.Add();
                //                d.Rows[k].Cells[2].Value = subcat;
                //                string x1 = ds.Tables[0].Rows[n][0].ToString();
                //                d.Rows[k].Cells[1].Value = x1.Substring(0, x1.Length - 1);
                //                d.Rows[k].Cells[2].Style.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
                //                if (!isSeqsec(SectionSeq[i]))
                //                {
                //                    seq++;
                //                    d.Rows[k].Cells[0].Value = seq.ToString();
                //                }
                //                k = d.Rows.Add();
                //                d.Rows[k].Cells[1].Value = x1.Substring(x1.Length - 1).ToLower();
                //                string size = ds.Tables[0].Rows[n][2].ToString();
                //                if (size == "")
                //                {
                //                    d.Rows[k].Cells[1].Value = x1;
                //                    if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading" || SectionSeq[i] == "EQ Shifting")
                //                    {
                //                        d.Rows[k].Cells[2].Value = ds.Tables[0].Rows[n][4].ToString();
                //                    }
                //                }
                //                else
                //                {
                //                    d.Rows[k].Cells[2].Value = size;
                //                }
                //                DataSet ds1 = majordal.getmeasureSum22(txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][2]));//, Convert.ToString(ds.Tables[0].Rows[n][4])
                //                qtysum = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                //                x1 = Convert.ToString(ds1.Tables[0].Rows[0][1]);
                //                d.Rows[k].Cells[3].Value = qtysum;
                //                d.Rows[k].Cells[4].Value = ds.Tables[0].Rows[n][3].ToString();
                //                d.Rows[k].Cells[5].Value = RoundAmount(ds1.Tables[0].Rows[0][2].ToString());
                //                ///
                //                amtsum = Convert.ToDouble(x1);
                //                string amtstr = RoundAmount(amtsum.ToString());
                //                //int so = amtstr.IndexOf('.');
                //                //if (so != -1 && so + 3 < amtstr.Length)
                //                //{
                //                //    amtstr = amtstr.Substring(0, so + 3);
                //                //}
                //                d.Rows[k].Cells[6].Value = amtstr;
                //                if (amtsum == 0)
                //                {
                //                    for (int j = 0; j < d.ColumnCount; j++)
                //                    {
                //                        d.Rows[k].Cells[j].Style.BackColor = Color.DarkOrange;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                k = d.Rows.Add();
                //                DataSet ds1 = majordal.getmeasureSum22(txtmno.Text, SectionSeq[i], ds.Tables[0].Rows[n][1].ToString(), Convert.ToString(ds.Tables[0].Rows[n][2]));//, Convert.ToString(ds.Tables[0].Rows[n][4])
                //                qtysum = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                //                amtsum = Convert.ToDouble(ds1.Tables[0].Rows[0][1]);
                //                string x1 = ds.Tables[0].Rows[n][0].ToString();
                //                d.Rows[k].Cells[1].Value = x1.Substring(x1.Length - 1).ToLower(); ;
                //                if (ds.Tables[0].Rows[n][2].ToString() != "")
                //                {
                //                    d.Rows[k].Cells[2].Value = ds.Tables[0].Rows[n][2].ToString();
                //                }
                //                // d.Rows[k].Cells[2].Value = ds.Tables[0].Rows[n][2].ToString() + " " + ds.Tables[0].Rows[n][4].ToString();
                //                d.Rows[k].Cells[3].Value = qtysum;
                //                d.Rows[k].Cells[4].Value = ds.Tables[0].Rows[n][3].ToString();
                //                d.Rows[k].Cells[5].Value = RoundAmount(ds1.Tables[0].Rows[0][2].ToString());
                //                string amtstr = RoundAmount(amtsum.ToString());
                //                //int so = amtstr.IndexOf('.');
                //                //if (so != -1 && so + 3 < amtstr.Length)
                //                //{
                //                //    amtstr = amtstr.Substring(0, so + 3);
                //                //}
                //                d.Rows[k].Cells[6].Value = amtstr;
                //                if (amtsum == 0)
                //                {
                //                    for (int j = 0; j < d.ColumnCount; j++)
                //                    {
                //                        d.Rows[k].Cells[j].Style.BackColor = Color.DarkOrange;
                //                    }
                //                }
                //            }//end of if else
                //        }
                //        else 
                //        {
                //            if (subcat != ds.Tables[0].Rows[n][1].ToString() || cat != SectionSeq[i])
                //            {
                //                subcat = ds.Tables[0].Rows[n][1].ToString();
                //                k = d.Rows.Add();
                //                d.Rows[k].Cells[2].Value = subcat;
                //                string x1 = ds.Tables[0].Rows[n][0].ToString();
                //                d.Rows[k].Cells[1].Value = x1.Substring(0, x1.Length - 1);
                //                d.Rows[k].Cells[2].Style.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
                //                if (!isSeqsec(SectionSeq[i]))
                //                { seq++;
                //                d.Rows[k].Cells[0].Value = seq.ToString();
                //                }

                //                k = d.Rows.Add();
                //                d.Rows[k].Cells[1].Value = x1.Substring(x1.Length - 1).ToLower();
                //                string size = ds.Tables[0].Rows[n][2].ToString();
                //                if (size == "")
                //                {
                //                    d.Rows[k].Cells[1].Value = x1;
                //                    if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading" || SectionSeq[i] == "EQ Shifting")
                //                    {
                //                        d.Rows[k].Cells[2].Value = ds.Tables[0].Rows[n][4].ToString();
                //                    }
                //                }
                //                else
                //                {
                //                    d.Rows[k].Cells[2].Value = size;
                //                }
                //                qtysum = Convert.ToDouble(ds.Tables[0].Rows[n][6]);
                //                x1 = Convert.ToString(ds.Tables[0].Rows[n][8]);
                //                d.Rows[k].Cells[3].Value = qtysum;
                //                d.Rows[k].Cells[4].Value = ds.Tables[0].Rows[n][3].ToString();
                //                d.Rows[k].Cells[5].Value = RoundAmount(ds.Tables[0].Rows[n][7].ToString());
                //                ///
                //                amtsum = Convert.ToDouble(x1);
                //                string amtstr = RoundAmount(amtsum.ToString());
                //                //int so = amtstr.IndexOf('.');
                //                //if (so != -1 && so + 3 < amtstr.Length)
                //                //{
                //                //    amtstr = amtstr.Substring(0, so + 3);
                //                //}
                //                d.Rows[k].Cells[6].Value = amtstr;
                //            }
                //            else
                //            {
                //                string x2 = ds.Tables[0].Rows[n][0].ToString();
                //                k = d.Rows.Add();
                //                d.Rows[k].Cells[1].Value = x2.Substring(x2.Length - 1).ToLower();
                //                string size = ds.Tables[0].Rows[n][2].ToString();
                //                if (size == "")
                //                {
                //                    d.Rows[k].Cells[1].Value = x2;
                //                    if (SectionSeq[i] == "EQ Dismantling" || SectionSeq[i] == "EQ Erection" || SectionSeq[i] == "EQ Loading" || SectionSeq[i] == "EQ Unloading" || SectionSeq[i] == "EQ Shifting")
                //                    {
                //                        d.Rows[k].Cells[2].Value = ds.Tables[0].Rows[n][4].ToString();
                //                    }
                //                }
                //                else
                //                {
                //                    d.Rows[k].Cells[2].Value = size;
                //                }
                //                qtysum = Convert.ToDouble(ds.Tables[0].Rows[n][6]);
                //                string x3 = Convert.ToString(ds.Tables[0].Rows[n][8]);
                //                d.Rows[k].Cells[3].Value = qtysum;
                //                d.Rows[k].Cells[4].Value = ds.Tables[0].Rows[n][3].ToString();
                //                d.Rows[k].Cells[5].Value = RoundAmount(ds.Tables[0].Rows[n][7].ToString());
                //                ///
                //                amtsum = Convert.ToDouble(x3);
                //                string amtstr = RoundAmount(amtsum.ToString());
                //                //int so = amtstr.IndexOf('.');
                //                //if (so != -1 && so + 3 < amtstr.Length)
                //                //{
                //                //    amtstr = amtstr.Substring(0, so + 3);
                //                //}
                //                d.Rows[k].Cells[6].Value = amtstr;
                //            }
                //        }

                //        if (cat != SectionSeq[i])
                //        {
                //            cat = SectionSeq[i];
                //        }
                //    }//second for n
                //}// frist for i
                ////
                ////Remove blank Subcat
                //for (int i = d.Rows.Count-1; i > 0; i--)
                //{if(Convert.ToString(d.Rows[i].Cells[2].Value)=="")
                //  {
                //      d.Rows[i - 1].Cells[1].Value = d.Rows[i].Cells[1].Value;
                //      d.Rows[i - 1].Cells[3].Value = d.Rows[i].Cells[3].Value;
                //      d.Rows[i - 1].Cells[4].Value = d.Rows[i].Cells[4].Value;
                //      d.Rows[i - 1].Cells[5].Value = d.Rows[i].Cells[5].Value;
                //      d.Rows[i - 1].Cells[6].Value = d.Rows[i].Cells[6].Value;
                //      try
                //      {
                //          d.Rows.Remove(d.Rows[i]);
                //      }
                //      catch (Exception ex)
                //      { }

                //  }

                //}
                //

               // repOCodes(ref d);
                int cntt = (d.Rows.Count - 1 / 21) + 1;
                tabControl1.TabPages.Clear();
                Amount x = null;
                double sum = 0;
                int flag = 0, temp = 0;
                // string cat = "";
                int curpage=0;
                for (int i = 0; i < d.Rows.Count; i++)
                {

                    int k1 = 0;
                    if (tabControl1.TabCount == 5)
                    {
                        int nx = 0;
                    }
                    if (i == 0)
                    {
                        x = new Amount();
                      
                      
                        sum = 0;
                        tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                        this.Text = "AmountSheet Loading  " + tabControl1.TabPages.Count.ToString();
                    }
                    if (i == d.Rows.Count-1)
                    { 
                        int p = 0;
                    }
                    if(m3.istestsubcat(Convert.ToString(d.Rows[i].Cells[2].Value)))
                    {testsubcat=Convert.ToString(d.Rows[i].Cells[2].Value);}
                    if (majordal.iscat(Convert.ToString(d.Rows[i].Cells[2].Value)) != "")
                    {
                        cat = Convert.ToString(d.Rows[i].Cells[2].Value);
                       
                        if (cat == "EQ Dismantling")
                        {
                            int mnp = 0;
                        }
                        flag = getseqno(i + 1, d);
                        if (((temp + flag+1) / 20) == 1)
                        {
                            x.txtBillno.Text = txtmno.Text;
                            x.txtpono.Text = txtPo.Text;
                            x.txtdate.Text = dtpdate.Text;
                            x.txtPageno.Text = (tabControl1.TabPages.Count).ToString();
                            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                           
                            x = new Amount();

                            sum = 0;
                            tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                            this.Text = "AmountSheet Loading  " + tabControl1.TabPages.Count.ToString();
                            flag = 0; temp = 0;
                            if (cat != "" )
                            {
                                if (cat != Convert.ToString(d.Rows[i].Cells[2].Value))
                                {
                                    x.dataGridView1.Rows[temp].Cells[2].Value = cat;
                                    temp++;
                                }
                                x.dataGridView1.Rows[temp].Cells[0].Value = Convert.ToString(d.Rows[i].Cells[0].Value);
                                x.dataGridView1.Rows[temp].Cells[1].Value = Convert.ToString(d.Rows[i].Cells[1].Value);
                                x.dataGridView1.Rows[temp].Cells[2].Value = Convert.ToString(d.Rows[i].Cells[2].Value);
                                x.dataGridView1.Rows[temp].Cells[3].Value = Convert.ToString(d.Rows[i].Cells[3].Value);
                                x.dataGridView1.Rows[temp].Cells[4].Value = Convert.ToString(d.Rows[i].Cells[4].Value);
                                x.dataGridView1.Rows[temp].Cells[5].Value = Convert.ToString(d.Rows[i].Cells[5].Value);
                                x.dataGridView1.Rows[temp].Cells[6].Value = Convert.ToString(d.Rows[i].Cells[6].Value);
                                try
                                {
                                    sum += Convert.ToDouble(d.Rows[i].Cells[6].Value);
                                }
                                catch (Exception ex) { }
                                temp++;
                                
                            }
                           continue;
                        }
                    }
                    if (isSeqsec(cat))
                    {
                        //if (Convert.ToString(d.Rows[i].Cells[1].Value) != "")
                        //{
                            flag = getseqnoeq(i, d);
                            if (((temp + flag + 1) / 20) == 1)
                            {
                                x.txtBillno.Text = txtmno.Text;
                                x.txtpono.Text = txtPo.Text;
                                x.txtdate.Text = dtpdate.Text;
                                x.txtPageno.Text = (tabControl1.TabPages.Count).ToString();
                                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                                x = new Amount();

                                sum = 0;
                                tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                                this.Text = "AmountSheet Loading  " + tabControl1.TabPages.Count.ToString();
                                flag = 0; temp = 0;
                                if (cat != ""  )
                                {
                                    if (cat != Convert.ToString(d.Rows[i].Cells[2].Value))
                                    {
                                        x.dataGridView1.Rows[temp].Cells[2].Value = cat;
                                        temp++;
                                    }
                                    if (testsubcat != Convert.ToString(d.Rows[i].Cells[2].Value)&&cat!="EQ Shifting"&&cat!="Labour Supply")
                                    {
                                        x.dataGridView1.Rows[temp].Cells[2].Value = testsubcat;
                                        temp++;
                                    }
                                    x.dataGridView1.Rows[temp].Cells[0].Value = Convert.ToString(d.Rows[i].Cells[0].Value);
                                    x.dataGridView1.Rows[temp].Cells[1].Value = Convert.ToString(d.Rows[i].Cells[1].Value);
                                    x.dataGridView1.Rows[temp].Cells[2].Value = Convert.ToString(d.Rows[i].Cells[2].Value);
                                    x.dataGridView1.Rows[temp].Cells[3].Value = Convert.ToString(d.Rows[i].Cells[3].Value);
                                    x.dataGridView1.Rows[temp].Cells[4].Value = Convert.ToString(d.Rows[i].Cells[4].Value);
                                    x.dataGridView1.Rows[temp].Cells[5].Value = Convert.ToString(d.Rows[i].Cells[5].Value);
                                    x.dataGridView1.Rows[temp].Cells[6].Value = Convert.ToString(d.Rows[i].Cells[6].Value);
                                    try
                                    {
                                        sum += Convert.ToDouble(d.Rows[i].Cells[6].Value);
                                    }
                                    catch (Exception ex) { }
                                    temp++;
                                   
                                }
                                continue;
                            }
                        //}
                    }
                    else
                    {
                        if (int.TryParse(Convert.ToString(d.Rows[i].Cells[0].Value), out k1))
                        {
                            k1 = int.Parse(Convert.ToString(d.Rows[i].Cells[0].Value));

                            flag = getseqno(i, d);
                        }
                    }
                    //if ((Convert.ToString(d.Rows[i].Cells[0].Value) == "" && Convert.ToString(d.Rows[i].Cells[1].Value) == ""))
                    //{
                    //    flag = getseqno(i + 1, d);
                    //}
                    if (((temp + flag) / 20) == 1)
                    {
                        x.txtBillno.Text = txtmno.Text;
                        x.txtpono.Text = txtPo.Text;
                        x.txtdate.Text = dtpdate.Text;
                        x.txtPageno.Text = (tabControl1.TabPages.Count).ToString();
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                        x = new Amount();

                        sum = 0;
                        tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                        this.Text = "AmountSheet Loading  " + tabControl1.TabPages.Count.ToString();
                        flag = 0; temp = 0;
                        if (cat != "" && cat != Convert.ToString(d.Rows[i].Cells[2].Value))
                        {
                            x.dataGridView1.Rows[temp].Cells[2].Value = cat;
                            temp++;
                            x.dataGridView1.Rows[temp].Cells[0].Value = Convert.ToString(d.Rows[i].Cells[0].Value);
                            x.dataGridView1.Rows[temp].Cells[1].Value = Convert.ToString(d.Rows[i].Cells[1].Value);
                            x.dataGridView1.Rows[temp].Cells[2].Value = Convert.ToString(d.Rows[i].Cells[2].Value);
                            x.dataGridView1.Rows[temp].Cells[3].Value = Convert.ToString(d.Rows[i].Cells[3].Value);
                            x.dataGridView1.Rows[temp].Cells[4].Value = Convert.ToString(d.Rows[i].Cells[4].Value);
                            x.dataGridView1.Rows[temp].Cells[5].Value = Convert.ToString(d.Rows[i].Cells[5].Value);
                            x.dataGridView1.Rows[temp].Cells[6].Value = Convert.ToString(d.Rows[i].Cells[6].Value);
                            try
                            {
                                sum += Convert.ToDouble(d.Rows[i].Cells[6].Value);
                            }
                            catch (Exception ex) { }
                            temp++;
                            if (i == 19||i==d.RowCount-1)
                            {
                                x.txtBillno.Text = txtmno.Text;
                                x.txtpono.Text = txtPo.Text;
                                x.txtdate.Text = dtpdate.Text;
                                x.txtPageno.Text = (tabControl1.TabPages.Count).ToString();
                                string amtstr1 = RoundAmount(sum.ToString());

                                x.lblpageTotal.Text = amtstr1;
                                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                            }
                            continue;
                        }
                    }
                    else
                    { flag = 0; }
                    if ((temp % 21 == 20) || (i == (d.Rows.Count - 1)))
                    {
                        x.txtBillno.Text = txtmno.Text;
                        x.txtpono.Text = txtPo.Text;
                        x.txtdate.Text = dtpdate.Text;
                        x.txtPageno.Text = (tabControl1.TabPages.Count).ToString();
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                    }

                    x.dataGridView1.Rows[temp].Cells[0].Value = d.Rows[i].Cells[0].Value;
                    x.dataGridView1.Rows[temp].Cells[1].Value = d.Rows[i].Cells[1].Value;
                    x.dataGridView1.Rows[temp].Cells[2].Value = d.Rows[i].Cells[2].Value;
                    x.dataGridView1.Rows[temp].Cells[3].Value = d.Rows[i].Cells[3].Value;
                    x.dataGridView1.Rows[temp].Cells[4].Value = d.Rows[i].Cells[4].Value;
                    x.dataGridView1.Rows[temp].Cells[5].Value = d.Rows[i].Cells[5].Value;
                    x.dataGridView1.Rows[temp].Cells[6].Value = d.Rows[i].Cells[6].Value;
                    if (Convert.ToString(x.dataGridView1.Rows[temp].Cells[6].Value) == "0.00" || Convert.ToString(x.dataGridView1.Rows[temp].Cells[5].Value) == "0.00" || Convert.ToString(x.dataGridView1.Rows[temp].Cells[1].Value).Contains("Ref"))
                    {
                        x.dataGridView1.Rows[temp].Cells[6].Style.BackColor = Color.Orange;
                        x.dataGridView1.Rows[temp].Cells[5].Style.BackColor = Color.Orange;
                    }
                    try
                    {
                        sum += Convert.ToDouble(d.Rows[i].Cells[6].Value);
                    }
                    catch (Exception ex) { }
                    string amtstr = RoundAmount(sum.ToString());
                    //int so = amtstr.IndexOf('.');
                    //if (so != -1 && so + 3 < amtstr.Length)
                    //{
                    //    amtstr = amtstr.Substring(0, so + 3);
                    //}
                    temp++;
                    x.lblpageTotal.Text = amtstr;
                }
                x = new Amount();
                int n1 = tabControl1.TabPages.Count;
                lasttabcount = n1;
                sumcount = lasttabcount / 10 + 1;
                //double pagesum = 0;
                if (n1 == 1)
                { return; }
                for (int i = 0; i < n1; i++)
                {
                    //if (n1 == 1)
                    //{break; }
                    try
                    {
                        if (i  == 0)
                        {
                            x = new Amount();
                            tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1).ToString());
                            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(x);
                            sum = 0;
                            this.Text = "AmountSheet Loading  " + tabControl1.TabPages.Count.ToString();
                        }
                        Amount c = (Amount)tabControl1.TabPages[i].Controls[0];
                        if (lasttabcount > 10)
                        {
                            x.dataGridView1.Rows[0].Cells[2].Value = "Amount Page No";
                            x.dataGridView1.Rows[((i * 1) + 1) % 20].Cells[2].Value = i + 1;
                            sum += Convert.ToDouble(c.lblpageTotal.Text);
                            x.dataGridView1.Rows[((i * 1) + 1) % 20].Cells[6].Value = RoundAmount(c.lblpageTotal.Text);
                            x.txtBillno.Text = txtmno.Text;
                            x.txtpono.Text = txtPo.Text;
                            x.txtdate.Text = dtpdate.Text;
                            x.txtPageno.Text = "0";
                            x.lblpageTotal.Text = RoundAmount(sum.ToString());
                        }
                        else
                        {
                            x.dataGridView1.Rows[0].Cells[2].Value = "Amount Page No";
                            x.dataGridView1.Rows[((i * 2) + 1) % 20].Cells[2].Value = i + 1;
                            sum += Convert.ToDouble(c.lblpageTotal.Text);
                            x.dataGridView1.Rows[((i * 2) + 1) % 20].Cells[6].Value = RoundAmount(c.lblpageTotal.Text);
                            x.txtBillno.Text = txtmno.Text;
                            x.txtpono.Text = txtPo.Text;
                            x.txtdate.Text = dtpdate.Text;
                            x.txtPageno.Text = "0";
                            x.lblpageTotal.Text = RoundAmount(sum.ToString());

                        }
                          }
                    catch (Exception ex)
                        { }

                    TRIMCODEs();
                  
                }

                this.Text = "AmountSheet";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = majordal.getClaimedAmt(txtmno.Text);
                if (ds.Tables[0].Rows.Count > 0)
                { MessageBox.Show("Record Already Saved"); return; }
                if (tabControl1.TabPages.Count > 1)
                {
                    for (int i = 0; i < lasttabcount; i++)
                    {
                        Amount c = (Amount)tabControl1.TabPages[i].Controls[0];
                        for (int j = 0; j < c.dataGridView1.Rows.Count; j++)
                        {
                            majordal.insertamount(Convert.ToString(c.dataGridView1.Rows[j].Cells[0].Value), Convert.ToString(c.txtBillno.Text), Convert.ToString(c.txtpono.Text), Convert.ToString(c.txtdate.Text), Convert.ToString(c.txtPageno.Text), Convert.ToString(c.dataGridView1.Rows[j].Cells[1].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[2].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[3].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[4].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[5].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[6].Value), Convert.ToString(c.lblpageTotal.Text), "");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        Amount c = (Amount)tabControl1.TabPages[i].Controls[0];
                        for (int j = 0; j < c.dataGridView1.Rows.Count; j++)
                        {
                            majordal.insertamount(Convert.ToString(c.dataGridView1.Rows[j].Cells[0].Value), Convert.ToString(c.txtBillno.Text), Convert.ToString(c.txtpono.Text), Convert.ToString(c.txtdate.Text), Convert.ToString(c.txtPageno.Text), Convert.ToString(c.dataGridView1.Rows[j].Cells[1].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[2].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[3].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[4].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[5].Value), Convert.ToString(c.dataGridView1.Rows[j].Cells[6].Value), Convert.ToString(c.lblpageTotal.Text), "");
                        }
                    }
                }
                MessageBox.Show(" Record Inserted");
            }
            catch (Exception ex)
            { }
        }
    
        private void btnprint_Click(object sender, EventArgs e)
        {
            //Bitmap b = new Bitmap(750, 1250);

            //b.Save("c:\\xyz.bmp");
            //SBGhadge1.Crp.AmtRptFrm fx = new SBGhadge1.Crp.AmtRptFrm();
            //fx.mno = txtmno.Text;
            //fx.Show();
            //return;
            try{
            string path1 = Application.StartupPath + "\\Images\\amount.jpg";
            path1 = path1.Replace("\\bin\\Debug", "");
            Image img1 = Image.FromFile(path1);
          
            printAmount pa = new printAmount();
            PrintAmountSheet ps = new PrintAmountSheet();
            ps.tabControl1.TabPages.Clear();
            double totalSum = 0;
            int RowStart = 330;
            int rowheight = 32;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                // totalSum = 0;
              
                img1 = Image.FromFile(path1);
               
                Graphics g = null;
                //DataSet ds = majordal.getAmount(txtmno.Text,txtbillno.Text);
                g = Graphics.FromImage(img1);
                Amount a = (Amount)tabControl1.TabPages[i].Controls[0];
                if (i == 13)
                { 
                    int jm = 0;
                }
                for (int j = 0; j < a.dataGridView1.Rows.Count; j++)
                {
                    if (j > 34)
                    { continue;  }
                    Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value) == "")
                    {
                        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[0].Value), f, Brushes.Black, new System.Drawing.Point(10, RowStart + j * rowheight));
                    SizeF sz1 = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value), f);
                    g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value), f, Brushes.Black, new System.Drawing.Point(95 - (int)(sz1.Width / 2), RowStart + j * rowheight));
                    string desc=Convert.ToString(a.dataGridView1.Rows[j].Cells[2].Value);
                    SizeF sz = g.MeasureString(desc, f);
                    int f2 = 14;
                    if(300+sz.Width/2>450)
                    {
                        
                        while (300+((int)sz.Width/2)>450)
                        {
                            f = new System.Drawing.Font("Times New Roman", f2--, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                  
                            sz = g.MeasureString(desc, f);
                        }
                        //f = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                   
                    g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[2].Value), f, Brushes.Black, new System.Drawing.Point(300-(int)(sz.Width/2), RowStart + j * rowheight));
                    f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value), f);
                     f2 = 14;
                    while (485 + ((int)sz.Width / 2) > 530)
                    {
                        f2--;
                        f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value), f);
                    }
                    g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value), f, Brushes.Black, new System.Drawing.Point(485 - (int)(sz.Width / 2), RowStart + j * rowheight));
                   //column 4
                    f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value), f);
                     f2 = 14;
                    while (565 + ((int)sz.Width / 2) > 600)
                    {f2--;
                        f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value), f);
                    }
                    
                    g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value), f, Brushes.Black, new System.Drawing.Point(565- (int)(sz.Width / 2), RowStart + j * rowheight));
                    //colomn 5
                    f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value), f);
                     f2 = 14;
                    while (630 + ((int)sz.Width / 2) > 670)
                    {
                        f2--;
                        f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value), f);
                    }

                    g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value), f, Brushes.Black, new System.Drawing.Point(630 - (int)(sz.Width / 2), RowStart + j * rowheight));

                    //column 6
                    f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    sz = g.MeasureString(amounInWord.mk_Currancy( Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value)), f);
                     f2 = 14;
                    while (705 + ((int)sz.Width / 2) > 740)
                    {
                        f2--;
                        f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        sz = g.MeasureString(amounInWord.mk_Currancy( Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value)), f);
                    }

                    g.DrawString(amounInWord.mk_Currancy( Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value)), f, Brushes.Black, new System.Drawing.Point(705 - (int)(sz.Width / 2), RowStart + j * rowheight));
                   // g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[7].Value), f, Brushes.Black, new System.Drawing.Point(680, RowStart + j * rowheight));
                }
                System.Drawing.Font f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                // g.DrawString(a.lblpageTotal.Text, f1, Brushes.Brown, new System.Drawing.Point(1020, 2210));
                string path = "";
                if (i == tabControl1.TabPages.Count - 1 && tabControl1.TabPages.Count!=1)
                {
                    path = System.Windows.Forms.Application.StartupPath + "\\Amount Sheet\\" + (i + 1) + ".jpg";
                    a.lblpageTotal.Text =  RoundAmount( totalSum.ToString());
                    f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                   SizeF sz = g.MeasureString(a.lblpageTotal.Text, f1);
                   
                    g.DrawString(amounInWord.mk_Currancy( a.lblpageTotal.Text), f1, Brushes.Black, new System.Drawing.Point(670-(int)sz.Width/2, 970));
               
                }
                else
                {
                    path = System.Windows.Forms.Application.StartupPath + "\\Amount Sheet\\" + (i+1)  + ".jpg";
                    f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    SizeF sz = g.MeasureString(a.lblpageTotal.Text, f1);

                    g.DrawString(amounInWord.mk_Currancy( a.lblpageTotal.Text), f1, Brushes.Black, new System.Drawing.Point(670 - (int)sz.Width / 2, 970));
                   
                    
                    if (i <= lasttabcount)
                    {
                        totalSum += Convert.ToDouble(a.lblpageTotal.Text);
                    }
                }
                for (int ki = 0; ki < a.richTextBox1.Lines.Length; ki++)
                {
                    g.DrawString(a.richTextBox1.Lines[ki], f1, Brushes.Black, new System.Drawing.Point(35, 185 + (ki * 32)));
                }
                g.DrawString(a.txtPageno.Text, f1, Brushes.Black, new System.Drawing.Point(585, 155));
                g.DrawString(a.txtBillno.Text, f1, Brushes.Black, new System.Drawing.Point(585, 155 + (32)));
                //g.DrawString(a.txtdate.Text.Replace("/","."), f1, Brushes.Black, new System.Drawing.Point(585, 155 + (64)));
                f1 = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                g.DrawString(a.txtpono.Text, f1, Brushes.Black, new System.Drawing.Point(530, 155 + (96)));
                //path = path.Replace("\\bin\\x86\\Debug", "");
                //g.Save();
                img1.Save(path);
            }
         
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
               
                path1 = Application.StartupPath +"\\Amount Sheet\\"+i.ToString()+".jpg";
                //if (tabControl1.TabPages.Count == 1)
                //{ 
                    path1 = Application.StartupPath + "\\Amount Sheet\\" + (i+1).ToString() + ".jpg"; //}
                //path1 = path1.Replace("\\bin\\Debug", "");
                pa = new printAmount();
                pa.pictureBox1.Image = Image.FromFile(path1);
                pa.pictureBox1.ImageLocation = path1;
              
                ps.tabControl1.TabPages.Add("Page"+(i+1).ToString());
                ps.tabControl1.TabPages[i].Controls.Add(pa);
            }
            ps.ShowDialog();
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + "\\Images\\sbgexcl.xlsx";
                path = path.Replace("\\bin\\Debug", "");
                OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "; Extended Properties=Excel 12.0;");
                OleDbCommand oconn = new OleDbCommand("select * from [Measurement$]", cnn);
                cnn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                cnn.Close();
                Excel.Workbook MyBook = null;
                Excel.Application MyApp = null;
                Excel.Worksheet MySheet = null;
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                //MyBook = MyApp.Workbooks.Open(path);
                //object missing = null;

                MyBook = MyApp.Workbooks.Open(path,
       Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //Measuarment sheet
                MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                // int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                DataSet ds = majordal.get(txtmno.Text);
                int rowfact = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (i % 25 == 0)
                    {
                        rowfact += 4;
                        //MySheet.Cells[i + rowfact - 5, 1]= Excel.XlPageBreak;//
                        //MySheet.Cells[i + rowfact, 1] = MySheet.Cells[1, 1];
                        //MySheet.Cells[i + rowfact , 2] = MySheet.Cells[1, 2];
                        //MySheet.Cells[i + rowfact, 3] = MySheet.Cells[1, 3];
                        //MySheet.Cells[i + rowfact, 4] = MySheet.Cells[1, 4];
                        ////MySheet.Range[MySheet.Cells[i + rowfact - 5, 1], MySheet.Cells[i + rowfact - 5, 4]].Merge();
                        ////MySheet.Range[MySheet.Cells[i + rowfact - 5, 1], MySheet.Cells[i + rowfact - 5, 4]].RowHeight = MySheet.Range[MySheet.Cells[1, 1], MySheet.Cells[1, 4]].Height;
                        //MySheet.Cells[i + rowfact - 5, 1].Font.Bold = false;
                        //MySheet.Cells[i + rowfact - 5, 1].Font.Name = "Algerian";
                        //MySheet.Cells[i + rowfact - 5, 1].Font.Size = 40;
                        //MySheet.Cells[i + rowfact - 5, 1].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //MySheet.Cells[i + rowfact - 5, 1].Style.Interior.Color = NumberFromColor(Color.Yellow);
                        //MySheet.Cells[(i + 7), 1] = MySheet.Cells[2, 1];
                        //  MySheet.Cells[(i + 7), 2] = MySheet.Cells[2, 2];
                        // MySheet.Cells[(i + ((i / 25) * 5)) + 1, 3] = MySheet.Cells[2, 3];
                        //  MySheet.Cells[(i + 7), 4] = MySheet.Cells[2, 4];
                        //MySheet.Cells[(i + ((i / 25) * 5)) + 2, 1] = MySheet.Cells[3, 1];
                        //  MySheet.Cells[(i + 8), 2] = MySheet.Cells[3, 2];
                        //MySheet.Cells[(i + ((i / 25) * 5)) + 2, 3] = MySheet.Cells[3, 3];
                        // MySheet.Cells[(i + 8), 4] = MySheet.Cells[3, 4];
                        //MySheet.Cells[(i + ((i / 25) * 5)) + 3, 1] = MySheet.Cells[4, 1];
                        //MySheet.Cells[(i + ((i / 25) * 5)) + 3, 2] = MySheet.Cells[4, 2];
                        //MySheet.Cells[(i + ((i / 25) * 5)) + 3, 3] = MySheet.Cells[4, 3];
                        //MySheet.Cells[(i + ((i / 25) * 5)) + 3, 4] = MySheet.Cells[4, 4];
                        ////MySheet.Range[MySheet.Cells[(i + ((i / 25) * 5) + 3), 1], MySheet.Cells[(i + ((i / 25) * 5) + 3), 4]].Merge();
                        MySheet.Cells[i + rowfact + 1, 2] = Convert.ToString(ds.Tables[0].Rows[i][2]).Replace("~", " ");
                    }
                    else
                    {
                        ////MySheet.Range[MySheet.Cells[i + rowfact - (rowfact / 5), 2], MySheet.Cells[i + rowfact - (rowfact / 5), 4]].Merge();
                        MySheet.Cells[i + rowfact + 1, 2] = Convert.ToString(ds.Tables[0].Rows[i][2]).Replace("~", "    ");
                    }
                }
                //Summary Sheet
                MySheet = (Excel.Worksheet)MyBook.Sheets[2]; // Explicit cast is not required here
                // lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                SummarySheet sums = new SummarySheet();
                sums.txtmno.Text = txtmno.Text;
                sums.btnload_Click(sender, e);
                for (int i = 0; i < sums.dataGridView1.Rows.Count; i++)
                {
                    rowfact = ((i / 29) + 1) * 5;
                    if (i % 29 == 0 && i != 0)
                    {
                        MySheet.Cells[1, 5] = sums.lblPageNo.Text;
                        MySheet.Cells[1, 11] = sums.dateTimePicker1.Text;
                    }
                    else
                    {
                        int k = i + rowfact - (rowfact / 5);
                        for (int c = 0; c < 12; c++)
                        {
                            string s = Convert.ToString(sums.dataGridView1.Rows[i].Cells[c].Value);
                            MySheet.Cells[k, c + 1] = s;
                        }
                        string d = "";
                        try { Convert.ToDouble(sums.dataGridView1.Rows[i].Cells[2].Value); }
                        catch (Exception ex)
                        { d = Convert.ToString(sums.dataGridView1.Rows[i].Cells[2].Value); }
                        if (Convert.ToString(sums.dataGridView1.Rows[i].Cells[0].Value) != "" || d != "")
                        {
                            //string s1 = Convert.ToString(sums.dataGridView1.Rows[i].Cells[0].Value);
                            //string s2 = Convert.ToString(sums.dataGridView1.Rows[i].Cells[1].Value);
                            //string s3 = Convert.ToString(sums.dataGridView1.Rows[i].Cells[2].Value);
                            MySheet.get_Range(MySheet.Cells[k, 2], MySheet.Cells[k, 12]).Merge(Missing.Value);
                            //[MySheet.Cells[k, 1], MySheet.Cells[k, 13]].Merge(); 
                        }

                    }
                }

                //amount Sheet
                MySheet = (Excel.Worksheet)MyBook.Sheets[3];
                if (tabControl1.TabPages.Count > 0)
                {
                    Amount a = (Amount)tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls[0];
                    MySheet.Cells[4, 6] = a.txtPageno.Text;
                    MySheet.Cells[5, 6] = a.txtBillno.Text;
                    MySheet.Cells[6, 6] = a.txtdate.Text;
                    MySheet.Cells[7, 6] = a.txtpono.Text;
                    for (int j = 0; j < a.dataGridView1.Rows.Count; j++)
                    {
                        MySheet.Cells[j + 11, 1] = Convert.ToString(a.dataGridView1.Rows[j].Cells[0].Value);
                        MySheet.Cells[j + 11, 2] = Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value);
                        MySheet.Cells[j + 11, 3] = Convert.ToString(a.dataGridView1.Rows[j].Cells[2].Value);
                        MySheet.Cells[j + 11, 4] = Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value);
                        MySheet.Cells[j + 11, 5] = Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value);
                        MySheet.Cells[j + 11, 6] = Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value);
                        MySheet.Cells[j + 11, 7] = Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value);
                        MySheet.Cells[j + 11, 8] = Convert.ToString(a.dataGridView1.Rows[j].Cells[7].Value);

                    }

                }
                for (int i = 0; i < tabControl1.TabPages.Count - 1; i++)
                {
                    Amount a = (Amount)tabControl1.TabPages[i].Controls[0];
                    MySheet.Cells[(i + 1) * 50 + 4, 6] = a.txtPageno.Text;
                    MySheet.Cells[(i + 1) * 50 + 5, 6] = a.txtBillno.Text;
                    MySheet.Cells[(i + 1) * 50 + 6, 6] = a.txtdate.Text;
                    MySheet.Cells[(i + 1) * 50 + 7, 6] = a.txtpono.Text;
                    for (int j = 0; j < a.dataGridView1.Rows.Count; j++)
                    {
                        MySheet.Cells[(i + 1) * 50 + j + 11, 1] = Convert.ToString(a.dataGridView1.Rows[j].Cells[0].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 2] = Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 3] = Convert.ToString(a.dataGridView1.Rows[j].Cells[2].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 4] = Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 5] = Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 6] = Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 7] = Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value);
                        MySheet.Cells[(i + 1) * 50 + j + 11, 8] = Convert.ToString(a.dataGridView1.Rows[j].Cells[7].Value);

                    }
                    MySheet.Cells[(i + 1) * 50 + 50, 7] = Convert.ToString(a.lblpageTotal.Text);
                }//amoun sheet ends

                // Billno
                MySheet = (Excel.Worksheet)MyBook.Sheets[4];
                DataSet billamt = majordal.getmeasureAmount(txtmno.Text);
                double total = 0;
                if (double.TryParse(Convert.ToString(billamt.Tables[0].Rows[0][0]), out total))
                { total = Convert.ToDouble(Convert.ToString(billamt.Tables[0].Rows[0][0])); }
                double Service = (12 * total) / 100;
                double totalserv = total + Service;
                double edu = (2 * totalserv) / 100;
                double hesu = (1 * totalserv) / 100;
                double net = totalserv + edu + hesu;
                amounInWord a2 = new amounInWord();
                int m = net.ToString().IndexOf(".");
                if (m != -1 && m + 3 < net.ToString().Length)
                { net = Convert.ToDouble(net.ToString().Substring(0, m + 3)); }
                string amtwds = a2.Toword(net);
                DataSet measure = majordal.get(txtmno.Text);
                string billdate = "";
                string plantno = "";
                string stno = "ADXPG6342BSD001";
                string panno = "ADXPG6342B";
                if (measure.Tables[0].Rows.Count > 1)
                {
                    billdate = Convert.ToString(measure.Tables[0].Rows[0][3]);
                    plantno = Convert.ToString(measure.Tables[0].Rows[0][4]);
                }
                MySheet.Cells[5, 7] = billdate;
                MySheet.Cells[8, 3] = billdate;
                MySheet.Cells[7, 3] = txtmno.Text;
                MySheet.Cells[10, 3] = panno;
                MySheet.Cells[11, 3] = stno;

                MySheet.Cells[27, 7] = total.ToString();
                MySheet.Cells[28, 7] = Service.ToString();
                MySheet.Cells[29, 7] = edu.ToString();
                MySheet.Cells[30, 7] = hesu.ToString();
                MySheet.Cells[31, 7] = net.ToString();
                if (amtwds.Length / 60 > 0)
                {
                    MySheet.Cells[32, 3] = amtwds.Substring(0, 60);
                    MySheet.Cells[33, 3] = amtwds.Substring(61);
                }
                else { MySheet.Cells[32, 3] = amtwds; }
                //billno ends
                MyApp.Visible = true;
            }
            catch (Exception ex)
            { }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintMeasurmentSheet pm = new PrintMeasurmentSheet();
                pm.tabControl1.TabPages.Clear();
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    this.Text = "MeasurementSheet Printing" + (i + 1).ToString() + "/" + tabControl1.TabPages.Count.ToString();
                    Amount mm = (Amount)tabControl1.TabPages[i].Controls[0];//(Measure)tabControl1.TabPages[i].Controls[0];
                    string _sourceFile = Application.StartupPath + "\\Images\\measurement1.jpg";
                    _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                    Image img1 = System.Drawing.Image.FromFile(_sourceFile);
                    Graphics g = Graphics.FromImage(img1);
                    Font f = new System.Drawing.Font("Times New Roman", 14F);
                    string pgno = (i + 1).ToString();
                    
                    DataSet ds = majordal.getPlantNo(txtmno.Text);

                    string str = Convert.ToString(ds.Tables[0].Rows[0][0]);
                    

                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                    // changing the name of active sheet  
                    worksheet.Name = "sheet" + i.ToString();
                    // storing header part in Excel  
                    for (int j = 1; j < mm.dataGridView1.Columns.Count + 1; j++)
                    {
                        worksheet.Cells[1, j] = mm.dataGridView1.Columns[j - 1].HeaderText;
                    }
                    // storing Each row and column value to excel sheet  
                    for (int j = 0; j < mm.dataGridView1.Rows.Count - 1; j++)
                    {
                        for (int k = 0; k < mm.dataGridView1.Columns.Count; k++)
                        {
                            if (mm.dataGridView1.Rows[j].Cells[k].Value == null)
                            {
                                worksheet.Cells[j + 2, k + 1] = "";
                            }
                            else
                            {

                                worksheet.Cells[j + 2, k + 1] = mm.dataGridView1.Rows[j].Cells[k].Value.ToString();
                            }
                        }
                    }
                    // save the application  

                    workbook.Sheets.Add(worksheet);
                }
                workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();  

                //printAmount pa = new printAmount();
                //PrintAmountSheet ps = new PrintAmountSheet();
                //ps.tabControl1.TabPages.Clear();
                //double totalSum = 0;
                //int RowStart = 330;
                //int rowheight = 32;
                //for (int i = 0; i < tabControl1.TabPages.Count; i++)
                //{
                //    // totalSum = 0;

                //    //img1 = Image.FromFile(path1);

                //    //Graphics g = null;
                //    //DataSet ds = majordal.getAmount(txtmno.Text,txtbillno.Text);
                //    //g = Graphics.FromImage(img1);
                //    Amount a = (Amount)tabControl1.TabPages[i].Controls[0];
                //    if (i == 13)
                //    {
                //        int jm = 0;
                //    }
                //    ExtractDataToCSV(a.dataGridView1);
                //    //    for (int j = 0; j < a.dataGridView1.Rows.Count; j++)
                //    //    {
                //    //        if (j > 34)
                //    //        { continue; }
                //    //        Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        if (Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value) == "")
                //    //        {
                //    //            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        }
                //    //        g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[0].Value), f, Brushes.Black, new System.Drawing.Point(10, RowStart + j * rowheight));
                //    //        SizeF sz1 = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value), f);
                //    //        g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[1].Value), f, Brushes.Black, new System.Drawing.Point(95 - (int)(sz1.Width / 2), RowStart + j * rowheight));
                //    //        string desc = Convert.ToString(a.dataGridView1.Rows[j].Cells[2].Value);
                //    //        SizeF sz = g.MeasureString(desc, f);
                //    //        int f2 = 14;
                //    //        if (300 + sz.Width / 2 > 450)
                //    //        {

                //    //            while (300 + ((int)sz.Width / 2) > 450)
                //    //            {
                //    //                f = new System.Drawing.Font("Times New Roman", f2--, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    //                sz = g.MeasureString(desc, f);
                //    //            }
                //    //            //f = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        }

                //    //        g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[2].Value), f, Brushes.Black, new System.Drawing.Point(300 - (int)(sz.Width / 2), RowStart + j * rowheight));
                //    //        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value), f);
                //    //        f2 = 14;
                //    //        while (485 + ((int)sz.Width / 2) > 530)
                //    //        {
                //    //            f2--;
                //    //            f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    //            sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value), f);
                //    //        }
                //    //        g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[3].Value), f, Brushes.Black, new System.Drawing.Point(485 - (int)(sz.Width / 2), RowStart + j * rowheight));
                //    //        //column 4
                //    //        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value), f);
                //    //        f2 = 14;
                //    //        while (565 + ((int)sz.Width / 2) > 600)
                //    //        {
                //    //            f2--;
                //    //            f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    //            sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value), f);
                //    //        }

                //    //        g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[4].Value), f, Brushes.Black, new System.Drawing.Point(565 - (int)(sz.Width / 2), RowStart + j * rowheight));
                //    //        //colomn 5
                //    //        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value), f);
                //    //        f2 = 14;
                //    //        while (630 + ((int)sz.Width / 2) > 670)
                //    //        {
                //    //            f2--;
                //    //            f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    //            sz = g.MeasureString(Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value), f);
                //    //        }

                //    //        g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[5].Value), f, Brushes.Black, new System.Drawing.Point(630 - (int)(sz.Width / 2), RowStart + j * rowheight));

                //    //        //column 6
                //    //        f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        sz = g.MeasureString(amounInWord.mk_Currancy(Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value)), f);
                //    //        f2 = 14;
                //    //        while (705 + ((int)sz.Width / 2) > 740)
                //    //        {
                //    //            f2--;
                //    //            f = new System.Drawing.Font("Times New Roman", f2, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    //            sz = g.MeasureString(amounInWord.mk_Currancy(Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value)), f);
                //    //        }

                //    //        g.DrawString(amounInWord.mk_Currancy(Convert.ToString(a.dataGridView1.Rows[j].Cells[6].Value)), f, Brushes.Black, new System.Drawing.Point(705 - (int)(sz.Width / 2), RowStart + j * rowheight));
                //    //        // g.DrawString(Convert.ToString(a.dataGridView1.Rows[j].Cells[7].Value), f, Brushes.Black, new System.Drawing.Point(680, RowStart + j * rowheight));
                //    //    }
                //    //    System.Drawing.Font f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    //    // g.DrawString(a.lblpageTotal.Text, f1, Brushes.Brown, new System.Drawing.Point(1020, 2210));
                //    //    string path = "";
                //    //    if (i == tabControl1.TabPages.Count - 1 && tabControl1.TabPages.Count != 1)
                //    //    {
                //    //        path = System.Windows.Forms.Application.StartupPath + "\\Amount Sheet\\" + (i + 1) + ".jpg";
                //    //        a.lblpageTotal.Text = RoundAmount(totalSum.ToString());
                //    //        f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        SizeF sz = g.MeasureString(a.lblpageTotal.Text, f1);

                //    //        g.DrawString(amounInWord.mk_Currancy(a.lblpageTotal.Text), f1, Brushes.Black, new System.Drawing.Point(670 - (int)sz.Width / 2, 970));

                //    //    }
                //    //    else
                //    //    {
                //    //        path = System.Windows.Forms.Application.StartupPath + "\\Amount Sheet\\" + (i + 1) + ".jpg";
                //    //        f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //        SizeF sz = g.MeasureString(a.lblpageTotal.Text, f1);

                //    //        g.DrawString(amounInWord.mk_Currancy(a.lblpageTotal.Text), f1, Brushes.Black, new System.Drawing.Point(670 - (int)sz.Width / 2, 970));


                //    //        if (i <= lasttabcount)
                //    //        {
                //    //            totalSum += Convert.ToDouble(a.lblpageTotal.Text);
                //    //        }
                //    //    }
                //    //    for (int ki = 0; ki < a.richTextBox1.Lines.Length; ki++)
                //    //    {
                //    //        g.DrawString(a.richTextBox1.Lines[ki], f1, Brushes.Black, new System.Drawing.Point(35, 185 + (ki * 32)));
                //    //    }
                //    //    g.DrawString(a.txtPageno.Text, f1, Brushes.Black, new System.Drawing.Point(585, 155));
                //    //    g.DrawString(a.txtBillno.Text, f1, Brushes.Black, new System.Drawing.Point(585, 155 + (32)));
                //    //    //g.DrawString(a.txtdate.Text.Replace("/","."), f1, Brushes.Black, new System.Drawing.Point(585, 155 + (64)));
                //    //    f1 = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    //    g.DrawString(a.txtpono.Text, f1, Brushes.Black, new System.Drawing.Point(530, 155 + (96)));
                //    //    //path = path.Replace("\\bin\\x86\\Debug", "");
                //    //    //g.Save();
                //    //    img1.Save(path);
                //    //}

                //    //for (int i = 0; i < tabControl1.TabPages.Count; i++)
                //    //{

                //    //    path1 = Application.StartupPath + "\\Amount Sheet\\" + i.ToString() + ".jpg";
                //    //    //if (tabControl1.TabPages.Count == 1)
                //    //    //{ 
                //    //    path1 = Application.StartupPath + "\\Amount Sheet\\" + (i + 1).ToString() + ".jpg"; //}
                //    //    //path1 = path1.Replace("\\bin\\Debug", "");
                //    //    pa = new printAmount();
                //    //    pa.pictureBox1.Image = Image.FromFile(path1);
                //    //    pa.pictureBox1.ImageLocation = path1;

                //    //    ps.tabControl1.TabPages.Add("Page" + (i + 1).ToString());
                //    //    ps.tabControl1.TabPages[i].Controls.Add(pa);
                //    //}
                //}
                //ps.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ExtractDataToCSV(DataGridView dgv)
        {

            // Don't save if no data is returned
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                columnsHeader += dgv.Columns[i].Name + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If they've selected a save location...
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());
                }
            }
            // Confirm to the user it has been completed.
            MessageBox.Show("CSV file saved.");
        }

       
    }
}
