using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
namespace SBGhadgev1
{
    public class ClassRc
    {
      public string ID;
      public string itemcode;
      public string cat;
      public string subcat;
      public string dece;
      public string unit;
      public string price;
    }
    public class ClassSteel
    {
        public string Title;
        public string Factor;
    }
    public class ClassSummary
    {
        public string ID;
        public string srno;
        public int pageno;
        public string itemcode;
        public string cat;
        public string subcat;
        public string size;
        public string unit;
        public string qty;
        public string unitrate;
        public string amount;
        public string type;
        public string mno;
        public string Desc2;
    }
    class majordal
    {
        public static ClassRc[] RC;
        public static ClassSummary[] summary;
        public static ClassSteel[] steel;
        public static DataTable ratetable;
        public static decimal GetWt(string size)
        {
            decimal final = 0;
            size = size.Trim();
            size=size.Replace('"',' ');
            //size = size.Replace(" ", "");
            char[] ch = {' '};
            string[] st=size.Split(ch);
            for (int i = 0; i < st.Length; i++)
            {
                decimal d = 1;
                if (st[i].Contains("/"))
                {
                    st[i] = st[i].Trim();
                    char[] ch2 = { '/' };
                    string[] st2 = st[i].Split(ch2);
                    final += Convert.ToDecimal(st2[0]) / Convert.ToDecimal(st2[1]);
                }
                else
                { decimal.TryParse(st[i].Trim(), out d);
                      final += d;
                }
                
            }
            return final;
        }
        public static decimal GetWtRed(string size)
        {
            decimal final = 1;
           
            char[] ch = { 'x','X' };
            string[] st = size.Split(ch);
            for (int i = 0; i < st.Length; i++)
            {
                final *= GetWt(st[i]);

            }
            return final;
        }
        public static string GetLabourcat(string subcat)
        {
            if (subcat.Contains("Fitter"))
            { return "Fitter"; }
            if (subcat.Contains("Helper"))
            { return "Helper"; }
            if (subcat.Contains("Rigger"))
            { return "Rigger"; }
            if (subcat.Contains("Supervisor"))
            { return "Supervisor"; }
            if (subcat.Contains("Welder"))
            { return "Welder"; }
            return "";
        
        
        }
        public static DataSet getRate(string cat, string subcat, string size)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Ref");
            dt.Columns.Add("Rate");
            var v = (from r in RC
                     where r.cat == cat && r.subcat == subcat
                     orderby r.itemcode descending
                     select r).Distinct();
            if (cat == "Dismantling & Refitting" && subcat.Contains("Valve"))
            {
                v = (from r in RC
                     where r.cat == cat && r.subcat == subcat && r.dece=="1\""
                     orderby r.itemcode descending
                     select r).Distinct();
            }
            string refsize = "";
            string RefRate = "";
            foreach (var item in v)
            {
                refsize = item.dece;
                RefRate = item.price;
                break;
            }
            if (subcat.Contains("Reducer") && !subcat.Contains("Joint"))
            {
                decimal d1 = 0;
                try
                {
                    d1 = Convert.ToDecimal(RefRate) * GetWtRed(size) / GetWtRed(refsize);
                    RefRate = decimal.Round(d1, 2).ToString();
                    refsize = "Ref-" + refsize;
                }
                catch (Exception ex)
                { }
            
            }
            else
            {
                decimal d = 0;
                try
                {
                   
                    d = Convert.ToDecimal(RefRate)  * GetWt(size)/ GetWt(refsize);
                    if (cat == "Dismantling & Refitting" && subcat.Contains("Valve"))
                    {  }
                    else { RefRate = decimal.Round(d, 2).ToString(); }
                   
                    refsize = "Ref-" + refsize;
                   
                }
                catch (Exception ex)
                { }
            }
            DataRow dr = dt.NewRow();
            dr[0] = refsize;
            dr[1] = RefRate;
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            return ds;

        }
        public static DataSet GetRC()
        {

            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT * FROM rate ORDER BY cat, subcat");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            query = string.Format("SELECT * FROM Steel");
            ocmd = new OleDbCommand(query, ocon);
            oda = new OleDbDataAdapter(ocmd);
            DataSet ds1 = new DataSet();
            oda.Fill(ds1);
            ocon.Close();
            return ds;
        }
        public static void SaveRC(DataGridView d)
        {

            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("delete FROM rate");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                try
                {
                    query = string.Format("insert into rate (itemcode,cat,subcat,dece,unit,price) values('{0}','{1}','{2}','{3}','{4}','{5}')", d.Rows[i].Cells[1].Value, d.Rows[i].Cells[2].Value, d.Rows[i].Cells[3].Value, d.Rows[i].Cells[4].Value, d.Rows[i].Cells[5].Value, d.Rows[i].Cells[6].Value);
                    ocmd = new OleDbCommand(query, ocon);
                    oda = new OleDbDataAdapter(ocmd);
                    ocmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { }
               
            }
           
            ocon.Close();
          
        }
        public static void InitRC()
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT * FROM rate ORDER BY cat, subcat");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            query = string.Format("SELECT * FROM Steel");
             ocmd = new OleDbCommand(query, ocon);
             oda = new OleDbDataAdapter(ocmd);
            DataSet ds1 = new DataSet();
            oda.Fill(ds1);
            ocon.Close();
            RC = new ClassRc[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ClassRc r = new ClassRc();
                r.ID = Convert.ToString(ds.Tables[0].Rows[i]["ID"]);
                r.cat = Convert.ToString(ds.Tables[0].Rows[i]["cat"]);
                r.itemcode = Convert.ToString(ds.Tables[0].Rows[i]["itemcode"]);
                r.subcat = Convert.ToString(ds.Tables[0].Rows[i]["subcat"]);
                r.unit = Convert.ToString(ds.Tables[0].Rows[i]["unit"]);
                r.price = Convert.ToString(ds.Tables[0].Rows[i]["price"]);
                r.dece = Convert.ToString(ds.Tables[0].Rows[i]["dece"]);
                RC[i] = r;
            }
            steel = new ClassSteel[ds1.Tables[0].Rows.Count];
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ClassSteel s = new ClassSteel();
                s.Title = Convert.ToString(ds1.Tables[0].Rows[i][1]);
                s.Factor = Convert.ToString(ds1.Tables[0].Rows[i][2]);
                steel[i] = s;
            }
            ratetable = new DataTable();
            ratetable.Columns.Add("Id");
            ratetable.Columns.Add("itemcode");
            ratetable.Columns.Add("cat");
            ratetable.Columns.Add("subcat");
            ratetable.Columns.Add("dece");
            ratetable.Columns.Add("unit");
            ratetable.Columns.Add("price");
        }
        public static string CalcSteel(string title, string desc)
        {
            string final = "0";

            var v = (from r in steel
                     where  r.Title == title
                     select r).Distinct();
            if (v.Count() > 0)
            {
                decimal fact = Convert.ToDecimal(v.First().Factor);
                char[] ch = { 'x', 'X' };
                string[] st = desc.Split(ch);
                decimal fact2 = 1;
                for (int i = 0; i < st.Length; i++)
                {
                    if (title == "CHQ Plate")
                    {
                        if (st[i].ToLower().Contains("mm"))
                        { continue; }
                        string temp1 = "";
                        foreach (char item in st[i])
                        {
                            if (char.IsDigit(item) || item == '.')
                            { temp1 += item.ToString(); }
                        }
                        decimal d1 = 1;
                        decimal.TryParse(temp1, out d1);
                        fact2 = fact2 * d1;
                    }
                    else
                    {
                        string temp = "";
                        foreach (char item in st[i])
                        {
                            if (char.IsDigit(item) || item == '.')
                            { temp += item.ToString(); }
                        }
                        decimal d = 1;
                        decimal.TryParse(temp, out d);
                        fact2 = fact2 * d;

                    
                    }
                }
                fact2 = fact * fact2;
                fact2=Decimal.Round(fact2,3);
                int mp = fact2.ToString().IndexOf('.');
                int mp1 = fact2.ToString().Length;
                if (mp1- mp > 3)
                {
                    final = Decimal.Round(fact2, 3).ToString().Substring(0, fact2.ToString().Length - 1);
                }
                else { final = fact2.ToString(); }
                }
            return final;

        }
        public static void InitSummary(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from majorsummary where Mno='{0}'", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            summary = new ClassSummary[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ClassSummary r = new ClassSummary();
                r.mno = Convert.ToString(ds.Tables[0].Rows[i]["mno"]);
                r.ID = Convert.ToString(ds.Tables[0].Rows[i]["ID"]);
                try
                {
                    r.pageno = Convert.ToInt32(ds.Tables[0].Rows[i]["pageno"]);
                }
                catch (Exception ex) { }
                r.cat = Convert.ToString(ds.Tables[0].Rows[i]["cat"]);
                r.itemcode = Convert.ToString(ds.Tables[0].Rows[i]["itemcode"]);
                r.subcat = Convert.ToString(ds.Tables[0].Rows[i]["subcat"]);
                r.unit = Convert.ToString(ds.Tables[0].Rows[i]["unit"]);
                r.unitrate = Convert.ToString(ds.Tables[0].Rows[i]["unitrate"]);
                r.size = Convert.ToString(ds.Tables[0].Rows[i]["size"]);
                r.qty = Convert.ToString(ds.Tables[0].Rows[i]["qty"]);
                r.amount = Convert.ToString(ds.Tables[0].Rows[i]["amount"]);
                r.Desc2 = Convert.ToString(ds.Tables[0].Rows[i]["Desc2"]);
                summary[i] = r;
            }
          
        }
        public static string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}\sbghadge.accdb;Jet OLEDB:Database Password=sbg123", Application.StartupPath.Replace("bin\\Debug",""));
        public static string[] Cats = { "Fabrication & Erection", "Only Dismantling", "Dismantling & Refitting", "EQ Erection", "EQ Loading", "EQ Unloading", "EQ Dismantling", "EQ Shifting", "Labour Supply", "A.C. Sheet" };
        public static string issubcat(string cat,string dece)
        {
            string b = "";
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select distinct(subcat) from rate where (LCASE(cat)='{0}') and (LCASE(subcat)='{1}')", cat,dece);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count>0)
            //{
            //    b = ds.Tables[0].Rows[0][0].ToString();
            //}
            //ocon.Close();
            var v = (from r in RC
                     where r.cat==cat && r.subcat==dece
                     select r.subcat).Distinct();
            if (v.Count() > 0)
            {
                b = v.First();
            }
            return b;
        }
        public static void deleteRecord(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Delete from bill where [no]='{0}'", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            query = string.Format("Delete from amountsheet where billno='{0}'", mno);
            ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            query = string.Format("Delete from majorsummary where mno='{0}'", mno);
            ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            query = string.Format("Delete from maeasurmentsheet where mno='{0}'", mno);
            ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            ocon.Close();
        }
        public static DataSet getmeasurebydate(string year,string month)
        {
            
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT DISTINCT mno, mdate, plantno FROM maeasurmentsheet WHERE (datepart('yyyy', mdate) = {0}) AND (datepart('m', mdate) = {1})", year, month);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
           
            ocon.Close();
            return ds;
        }
        public static DataSet getmeasurebymno(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT subcat, Desc2, [size], qty, unit,type,pageno FROM  majorsummary WHERE mno = '{0}' order by ID", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getClaimedAmt(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT * FROM  amountsheet WHERE billno = '{0}' order by ID", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds,"amountsheet");
            ocon.Close();
            return ds;
        }
        public static DataSet getmeasurebydate()
        {

            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT DISTINCT mno, mdate, plantno FROM maeasurmentsheet");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);

            ocon.Close();
            return ds;
        }
        public static string issubcat(string dece)
        {
            string b = "";
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select distinct(subcat) from rate where (LCASE(subcat)='{0}')", dece);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    b = ds.Tables[0].Rows[0][0].ToString();
            //}
            //ocon.Close();
            var v = (from r in RC
                     where r.subcat == dece
                     select r.subcat).Distinct();
            if (v.Count() > 0)
            { b = v.First(); }
            return b;
        }
        public static string isLaboursubcat(string dece)
        {
            string b = "";
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select distinct(subcat) from rate where (LCASE(subcat)='{0}')", dece);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    b = ds.Tables[0].Rows[0][0].ToString();
            //}
            //ocon.Close();
            var v = (from r in RC
                     where dece.Contains(r.subcat) && r.cat == "Labour Supply"
                     select r.subcat).Distinct();
            if (v.Count() > 0)
            { b = v.First(); }
            return b;
        }
        public static string iscat(string dece)
        {
            string b = "";
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select distinct(cat) FROM rate where (LCASE(cat) = '{0}')", dece);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            for (int i = 0; i < Cats.Length; i++)
            {
                if (dece.ToLower() == Cats[i].ToLower())
                { return Cats[i]; }
            }
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    b = ds.Tables[0].Rows[0][0].ToString(); 
            //}
            //ocon.Close();
            return b;
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
        public static int compitemcode(string code1, string code2)
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
        public static DataSet Sortitems(DataSet ds)
        {
            DataSet ds2 = new DataSet();
            DataTable ds1 = new DataTable();
            ds1.Columns.Add("itemcode");
            ds1.Columns.Add("cat");
            ds1.Columns.Add("subcat");
            ds1.Columns.Add("size");
            ds1.Columns.Add("dece");
            ds1.Columns.Add("price");
           // ds1.Columns.Add("amount");
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
                       // dr[5] = ds.Tables[0].Rows[i][5].ToString();
                       // dr[6] = ds.Tables[0].Rows[i][6].ToString();
                        ds.Tables[0].Rows[i][0] = ds.Tables[0].Rows[j][0];
                        ds.Tables[0].Rows[i][1] = ds.Tables[0].Rows[j][1];
                        ds.Tables[0].Rows[i][2] = ds.Tables[0].Rows[j][2];
                        ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[j][3];
                        ds.Tables[0].Rows[i][4] = ds.Tables[0].Rows[j][4];
                       // ds.Tables[0].Rows[i][5] = ds.Tables[0].Rows[j][5];
                       // ds.Tables[0].Rows[i][6] = ds.Tables[0].Rows[j][6];
                        ds.Tables[0].Rows[j][0] = dr[0];
                        ds.Tables[0].Rows[j][1] = dr[1];
                        ds.Tables[0].Rows[j][2] = dr[2];
                        ds.Tables[0].Rows[j][3] = dr[3];
                        ds.Tables[0].Rows[j][4] = dr[4];
                       // ds.Tables[0].Rows[j][5] = dr[5];
                        //ds.Tables[0].Rows[j][6] = dr[6];
                    }
                }
            }
            ds2.Tables.Add(ds1);
            return ds;
        }
        public static DataSet getItemSumRpt(string Date1,string Date2)
        {
            DataSet Final = new DataSet();
            DataTable DT = new DataTable();
            DT.Columns.Add("ITEMCODE");
            DT.Columns.Add("CAT");
            DT.Columns.Add("ITEM");
            DT.Columns.Add("SIZE");
            DT.Columns.Add("QTY");
            DT.Columns.Add("RATE");
            DT.Columns.Add("AMOUNT");
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Billno");

            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            //Between #{1}# and #{2}#
            string query = string.Format("Select  Distinct mno from majorsummary");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            SummarySheet s = new SummarySheet();
            
            DataRow dr = dt1.NewRow();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr[0] += Convert.ToString(ds.Tables[0].Rows[i][0]) + " ";
            }
            dt1.Rows.Add(dr);
            query = string.Format("Select  Distinct itemcode,cat,subcat,dece,price,ID from RC1 Order By ID Asc ");

             ocmd = new OleDbCommand(query, ocon);
             oda = new OleDbDataAdapter(ocmd);
            DataSet ds1 = new DataSet();
            oda.Fill(ds1);
           // ds1 = Sortitems(ds1);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr = DT.NewRow();
                dr[0] = Convert.ToString(ds1.Tables[0].Rows[i][0]);
                dr[1] = Convert.ToString(ds1.Tables[0].Rows[i][1]);
                dr[2] = Convert.ToString(ds1.Tables[0].Rows[i][2]);
                dr[3] = Convert.ToString(ds1.Tables[0].Rows[i][3]);
                dr[5] = Convert.ToString(ds1.Tables[0].Rows[i][4]);
                query = string.Format("Select  sum(qty),sum(amount)  from majorsummary Where itemcode='{0}'", Convert.ToString(ds1.Tables[0].Rows[i][0]));

             ocmd = new OleDbCommand(query, ocon);
             oda = new OleDbDataAdapter(ocmd);
            DataSet ds2 = new DataSet();
            try
            {
                oda.Fill(ds2);
                dr[4] = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                dr[6] = Convert.ToString(ds2.Tables[0].Rows[0][1]);
            }
            catch (Exception ex)
            {
                int xnp = 0;
            }
            DT.Rows.Add(dr);
            }
            Final.Tables.Add(DT);
            Final.Tables.Add(dt1);
            return Final;
        
        }
        public static DataSet getItemSumRpt1(List<string> l)
        {
            DataSet Final = new DataSet();
            DataTable DT = new DataTable();
            DT.Columns.Add("ITEMCODE");
            DT.Columns.Add("CAT");
            DT.Columns.Add("ITEM");
            DT.Columns.Add("SIZE");
            DT.Columns.Add("RATE");
            for (int i = 0; i < l.Count; i++)
            {
                 DT.Columns.Add(l[i]);
            }
            DT.Columns.Add("Total");
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Billno");

            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            //Between #{1}# and #{2}#
            string query = string.Format("Select  Distinct mno from majorsummary");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
          // oda.Fill(ds);
            DataRow dr = dt1.NewRow();
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    dr[0] += Convert.ToString(ds.Tables[0].Rows[i][0]) + " ";
            //}
            //dt1.Rows.Add(dr);
            query = string.Format("Select  Distinct itemcode,cat,subcat,dece,price from rate Order By cat,subcat,dece Asc ");

            ocmd = new OleDbCommand(query, ocon);
            oda = new OleDbDataAdapter(ocmd);
            DataSet ds1 = new DataSet();
            oda.Fill(ds1);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                dr = DT.NewRow();
                dr[0] = Convert.ToString(ds1.Tables[0].Rows[i][0]);
                dr[1] = Convert.ToString(ds1.Tables[0].Rows[i][1]);
                dr[2] = Convert.ToString(ds1.Tables[0].Rows[i][2]);
                dr[3] = Convert.ToString(ds1.Tables[0].Rows[i][3]);
                dr[4] = Convert.ToString(ds1.Tables[0].Rows[i][4]);
                double sum = 0;
                for (int k = 0; k < l.Count; k++)
                {
                    Application.OpenForms["RptItemSummary"].Text = "Loading  " + (k + 1).ToString() + "/" + l.Count.ToString();
                    query = string.Format("Select  sum(qty),sum(amount)  from majorsummary Where itemcode='{0}' and mno='{1}'", Convert.ToString(ds1.Tables[0].Rows[i][0]),l[k]);

                    ocmd = new OleDbCommand(query, ocon);
                    oda = new OleDbDataAdapter(ocmd);
                    DataSet ds2 = new DataSet();
                    try
                    {
                        oda.Fill(ds2);
                        dr[k+5] = Convert.ToString(ds2.Tables[0].Rows[0][0]);
                       // dr[6] = Convert.ToString(ds2.Tables[0].Rows[0][1]);
                        sum += Convert.ToDouble(dr[k + 5]);
                        dr[l.Count + 5] = sum;
                    }
                    catch (Exception ex)
                    {
                        int xnp = 0;
                    }
                  
                }
                DT.Rows.Add(dr); 
               
            }
            ocon.Close();
            Final.Tables.Add(DT);
            Final.Tables.Add(dt1);
            return Final;

        }
        public static DataSet getDistinctDrill(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select Distinct[Size] from majorsummary where mno='{0}'and subcat='{1}'", mno, "Drilling Hole Dia");


            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getDistinctLabour(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select Distinct(Subcat) from majorsummary where mno='{0}'and cat='{1}'", mno, "Labour Supply");


            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet isitem(string cat,string subcat,string dece)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select * from rate where cat='{0}' and subcat&dece='{1}' ", cat, subcat+dece);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();

            //ratetable.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("itemcode");
            dt.Columns.Add("cat");
            dt.Columns.Add("subcat");
            dt.Columns.Add("dece");
            dt.Columns.Add("unit");
            dt.Columns.Add("price");
           // DataTable dt = ratetable;
            var v = (from r in RC
                     where r.cat.ToLower() == cat.Trim().ToLower() && r.subcat.ToLower() == subcat.Trim().ToLower() && r.dece.ToLower() == dece.Trim().ToLower() 
                     select r);
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 1)
            //{// MessageBox.Show(cat + " " + subcat + " " + dece); }
            //ocon.Close();
                foreach (var item in v)
            {
                DataRow dr = dt.NewRow();
               
                  
                dr["ID"] = item.ID;
                dr["cat"] = item.cat;
                dr["itemcode"] = item.itemcode;
                dr["subcat"] = item.subcat;
                dr["dece"] = item.dece;
                dr["unit"] = item.unit;
                dr["price"] = item.price;
                dt.Rows.Add(dr);
            }
            //DataTable dt = ratetable;
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet isitem1(string subcat, string dece)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select * from rate where  subcat&dece='{0}' ", subcat + dece);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
                            DataSet ds = new DataSet();
            //oda.Fill(ds);
            ////if (ds.Tables[0].Rows.Count > 1)
            ////{// MessageBox.Show(cat + " " + subcat + " " + dece); }
            //ocon.Close();
           
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("itemcode");
            dt.Columns.Add("cat");
            dt.Columns.Add("subcat");
            dt.Columns.Add("dece");
            dt.Columns.Add("unit");
            dt.Columns.Add("price");
            if (subcat == "")
            { ds.Tables.Add(dt); return ds; }
            // DataTable dt = ratetable;
            var v = (from r in RC
                     where r.subcat.ToLower() == subcat.Trim().ToLower() && r.dece.ToLower() == dece.Trim().ToLower()
                     select r);
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 1)
            //{// MessageBox.Show(cat + " " + subcat + " " + dece); }
            //ocon.Close();
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();


                dr["ID"] = item.ID;
                dr["cat"] = item.cat;
                dr["itemcode"] = item.itemcode;
                dr["subcat"] = item.subcat;
                dr["dece"] = item.dece;
                dr["unit"] = item.unit;
                dr["price"] = item.price;
                dt.Rows.Add(dr);
            }
            //DataTable dt = ratetable;
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet isitem(string cat, string subcat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select * from rate where cat='{0}' and subcat='{1}' ", cat, subcat);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 1)
            //{ 
            //    //MessageBox.Show(cat + " " + subcat); 
            
            //}
            //ocon.Close();
            DataSet ds = new DataSet();

            //ratetable.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("itemcode");
            dt.Columns.Add("cat");
            dt.Columns.Add("subcat");
            dt.Columns.Add("dece");
            dt.Columns.Add("unit");
            dt.Columns.Add("price");
         
            // DataTable dt = ratetable;
            var v = (from r in RC
                     where r.cat.ToLower() == cat.Trim().ToLower() && r.subcat.ToLower() == subcat.Trim().ToLower() 
                     select r);
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 1)
            //{// MessageBox.Show(cat + " " + subcat + " " + dece); }
            //ocon.Close();
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();


                dr["ID"] = item.ID;
                dr["cat"] = item.cat;
                dr["itemcode"] = item.itemcode;
                dr["subcat"] = item.subcat;
                dr["dece"] = item.dece;
                dr["unit"] = item.unit;
                dr["price"] = item.price;
                dt.Rows.Add(dr);
            }
            //DataTable dt = ratetable;
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet isitemEQshift(string cat, string subcat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select * from rate where cat='{0}'", cat, subcat);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();
            DataSet ds = new DataSet();
            
            //ratetable.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("itemcode");
            dt.Columns.Add("cat");
            dt.Columns.Add("subcat");
            dt.Columns.Add("dece");
            dt.Columns.Add("unit");
            dt.Columns.Add("price");
            if (cat == "" )
            {
                ds.Tables.Add(dt);
                return ds;
            }
            // DataTable dt = ratetable;
            var v = (from r in RC
                     where r.cat.ToLower() == cat.Trim().ToLower() 
                     select r);
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 1)
            //{// MessageBox.Show(cat + " " + subcat + " " + dece); }
            //ocon.Close();
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();


                dr["ID"] = item.ID;
                dr["cat"] = item.cat;
                dr["itemcode"] = item.itemcode;
                dr["subcat"] = item.subcat;
                dr["dece"] = item.dece;
                dr["unit"] = item.unit;
                dr["price"] = item.price;
                dt.Rows.Add(dr);
            }
            //DataTable dt = ratetable;
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet isitemeqshifting(string cat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select * from rate where cat='{0}' ", cat);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();
                    DataSet ds = new DataSet();
            
            //ratetable.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("itemcode");
            dt.Columns.Add("cat");
            dt.Columns.Add("subcat");
            dt.Columns.Add("dece");
            dt.Columns.Add("unit");
            dt.Columns.Add("price");
            // DataTable dt = ratetable;
            if (cat == "")
            { ds.Tables.Add(dt);
              return ds;
            }
            var v = (from r in RC
                     where r.cat.ToLower() == cat.Trim().ToLower()
                     select r);
            //oda.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 1)
            //{// MessageBox.Show(cat + " " + subcat + " " + dece); }
            //ocon.Close();
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();


                dr["ID"] = item.ID;
                dr["cat"] = item.cat;
                dr["itemcode"] = item.itemcode;
                dr["subcat"] = item.subcat;
                dr["dece"] = item.dece;
                dr["unit"] = item.unit;
                dr["price"] = item.price;
                dt.Rows.Add(dr);
            }
            //DataTable dt = ratetable;
            ds.Tables.Add(dt);
            return ds;
        }
        public static bool chkmno(string mno)
        {
            bool b = false;
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from majorsummary where mno='{0}'", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count>0)
            {
                b = true;
            }
            ocon.Close();
            return b;
        }
        public static DataSet getmeasureSum(string mno, string cat,string subcat,string pageno)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select * from majorsummary where mno='{0}'and cat='{1}' and subcat='{2}' and pageno='{3}' ", mno, cat, subcat,pageno);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();

            DataSet ds = new DataSet();
            
            var v = (from r in summary
                     where ((r.cat == cat) && (r.subcat == subcat) && (r.pageno == Convert.ToInt32(pageno)) )
                     select r);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("srno");
            dt.Columns.Add("pageno");
            dt.Columns.Add("itemcode");
            dt.Columns.Add("cat");
            dt.Columns.Add("subcat");
            dt.Columns.Add("size");
            dt.Columns.Add("unit");
            dt.Columns.Add("qty");
            dt.Columns.Add("unitrate");
            dt.Columns.Add("amount");
            dt.Columns.Add("type");
            dt.Columns.Add("mno");
            dt.Columns.Add("Desc2");
            double sm12 = 0;
            foreach (var item in v)
            {

                DataRow dr = dt.NewRow();
                dr["ID"]=item.ID;
                dr["srno"] = item.srno;
                dr["pageno"] = item.pageno;
                dr["itemcode"] = item.itemcode;
                dr["cat"] = item.cat;
                dr["subcat"] = item.subcat;
                dr["size"] = item.size;
                dr["unit"] = item.unit;
                dr["qty"] = item.qty;
                dr["amount"] = item.amount;
                dr["type"] = item.type;
                dr["mno"] = item.mno;
                dr["Desc2"] = item.Desc2;
                dt.Rows.Add(dr);
            }
           

            
            return ds;
        }
        public static DataSet getmeasureSum1(string mno, string cat, string subcat, string pageno,string size)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);                      
            //ocon.Open();
            //string query = string.Format("Select sum(qty) from majorsummary where mno='{0}'and cat='{1}' and subcat='{2}' and pageno='{3}' and [size]='{4}'", mno, cat, subcat, pageno, size);
            //if (size == "" && cat=="Labour Supply")
            //{
            //    query = string.Format("Select sum(qty) from majorsummary where mno='{0}'and cat='{1}' and subcat='{2}' and pageno='{3}' and   ([size] = '')", mno, cat, subcat, pageno, size);
            //}
            
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();

            DataSet ds = new DataSet();
            
            var  v = (from r in summary
                     where( (r.cat == cat) && (r.subcat== subcat)&&(r.pageno==Convert.ToInt32(pageno))&&(r.size==size))
                     select new { qty = r.qty });
            if (size == "" && cat == "Labour Supply")
            {
                v = (from r in summary
                     where r.cat == cat && r.subcat == subcat && r.pageno == Convert.ToInt32(pageno) 
                     select new { qty = r.qty });
            }
           
               
            
            DataTable dt = new DataTable();
            dt.Columns.Add("sum");
            double sm12 = 0;
            foreach (var item in v)
            {
                
                double t = 0;
                double.TryParse(item.qty,out t);
                sm12 += t;
            }
            DataRow dr = dt.NewRow();
            dr["sum"] = sm12.ToString();
           
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet getmeasureSumwithDesc2(string mno, string cat, string subcat,string pageno, string size, string disc2)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select sum(qty),sum(amount),avg(unitrate) from majorsummary where mno='{0}'and cat='{1}' and subcat='{2}' and pageno='{3}' and [size]='{4}' and Desc2='{5}'", mno, cat, subcat,pageno, size, disc2);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();

            DataSet ds = new DataSet();

            var v = (from r in summary
                     where ((r.cat == cat) && (r.subcat == subcat) && (r.pageno == Convert.ToInt32(pageno)) && (r.size == size) && (r.Desc2 == disc2))
                     select new { qty = r.qty,amount=r.amount,unitrate=r.unitrate });
                 



            DataTable dt = new DataTable();
            dt.Columns.Add("qty");
            dt.Columns.Add("amount");
            dt.Columns.Add("unitrate");
            double qt = 0,amt=0,unitrate=0;
            foreach (var item in v)
            {

                double t = 0;
                double.TryParse(item.qty, out t);
                qt += t;
                t = 0;
                double.TryParse(item.amount, out t);
                amt += t;
                t = 0;
                double.TryParse(item.unitrate, out t);
                unitrate = t;
                
            }
            DataRow dr = dt.NewRow();
            dr["qty"] = qt.ToString();
            dr["amount"] = amt.ToString();
            dr["unitrate"] = unitrate.ToString();

            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet getmeasureSum2(string mno, string cat, string subcat, string size,string disc2)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select sum(qty),sum(amount),avg(unitrate) from Dupmajorsummary where mno='{0}'and cat='{1}' and subcat='{2}'  and [size]='{3}' and Desc2='{4}'", mno, cat, subcat, size,disc2);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getmeasureSum22(string mno, string cat, string subcat, string size)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select sum(qty),sum(amount),avg(unitrate) from Dupmajorsummary where mno='{0}'and cat='{1}' and subcat='{2}'  and [size]='{3}'", mno, cat, subcat, size);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getmeasureSummary(string mno, string cat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select DISTINCT itemcode,subcat, [size],Cint(pageno),unit,Desc2 from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}'ORDER BY Cint(pageno) ", mno, cat, "");
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();
            DataSet ds = new DataSet();

            var v = (from r in summary
                     where ((r.cat == cat) && (r.itemcode != ""))
                     orderby r.itemcode ascending
                     select new { itemcode = r.itemcode, subcat = r.subcat, size = r.size, pageno = r.pageno, Desc2 = r.Desc2, unit=r.unit }).Distinct();




            DataTable dt = new DataTable();
            dt.Columns.Add("itemcode");
            dt.Columns.Add("subcat");
            dt.Columns.Add("size");
            dt.Columns.Add("pageno");
            dt.Columns.Add("unit");
            dt.Columns.Add("Desc2");
            double qt = 0, amt = 0, unitrate = 0;
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();
                dr["itemcode"] =item.itemcode.ToString();
                dr["subcat"] = item.subcat.ToString();
                dr["size"] = item.size.ToString();
                dr["pageno"] = item.pageno.ToString();
                dr["unit"] = item.unit.ToString();
                dr["Desc2"] = item.Desc2.ToString();
                dt.Rows.Add(dr);
            }
            

            
            ds.Tables.Add(dt);
            return ds;

            
        }
        public static DataSet getmeasureSumSeq(string mno, string cat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select DISTINCT itemcode,subcat from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}'", mno, cat, "");
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();

            var v = (from r in summary
                     where r.cat == cat && r.itemcode != ""
                     orderby r.itemcode ascending
                     select new {itemcode=r.itemcode,subcat=r.subcat }).Distinct();

            DataTable dt = new DataTable();
            dt.Columns.Add("itemcode");
            dt.Columns.Add("subcat");
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();
                dr["itemcode"] = item.itemcode;
                dr["subcat"] = item.subcat;
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            return ds;
        }
      
        public static DataSet getmeasureSumSeq1(string mno, string cat,string subcat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select DISTINCT itemcode,subcat, [size],Cint(pageno),unit,Desc2 from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' and subcat='{3}'ORDER BY Cint(pageno) ", mno, cat, "",subcat);
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();
            //return ds;
            DataSet ds = new DataSet();

            var v = (from r in summary
                     where ((r.cat == cat)&&(r.subcat==subcat)&&(r.itemcode!=""))
                     orderby r.pageno ascending
                     select new { itemcode = r.itemcode, subcat = r.subcat, size = r.size, pageno = r.pageno, Desc2 = r.Desc2, unit = r.unit }).Distinct();




            DataTable dt = new DataTable();
            dt.Columns.Add("itemcode");
            dt.Columns.Add("subcat");
            dt.Columns.Add("size");
            dt.Columns.Add("pageno");
            dt.Columns.Add("unit");
            dt.Columns.Add("Desc2");
            double qt = 0, amt = 0, unitrate = 0;
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();
                dr["itemcode"] = item.itemcode.ToString();
                dr["subcat"] = item.subcat.ToString();
                dr["size"] = item.size.ToString();
                dr["pageno"] = item.pageno.ToString();
                dr["unit"] = item.unit.ToString();
                dr["Desc2"] = item.Desc2.ToString();
                dt.Rows.Add(dr);
            }



            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet getLabourSumSeq1(string mno, string cat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select DISTINCT itemcode,subcat, [size],Cint(pageno),unit,Desc2 from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' ORDER BY Cint(pageno) ", mno, cat, "");
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();
            DataSet ds = new DataSet();

            var v = (from r in summary
                     where ((r.cat == cat)  && (r.itemcode != ""))
                     orderby r.pageno ascending
                     select new { itemcode = r.itemcode, subcat = r.subcat, pageno = r.pageno }).Distinct();
           
          


            DataTable dt = new DataTable();
            dt.Columns.Add("itemcode");
            dt.Columns.Add("subcat");
            dt.Columns.Add("size");
            dt.Columns.Add("pageno");
            dt.Columns.Add("unit");
            dt.Columns.Add("Desc2");
            double qt = 0, amt = 0, unitrate = 0;
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();
                dr["itemcode"] = item.itemcode.ToString();
                dr["subcat"] = item.subcat.ToString();
                //dr["size"] = item.size.ToString();
                dr["pageno"] = item.pageno.ToString();
                //dr["unit"] = item.unit.ToString();
               // dr["Desc2"] = item.Desc2.ToString();
                dt.Rows.Add(dr);
            }



            ds.Tables.Add(dt);
            return ds;
        }
        public static DataSet getdistinctcat()
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT cat from rate ");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdistinctsubcat(string cat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT subcat from rate where cat='{0}' ",cat);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdistinctsize(string cat,string subcat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT dece from rate where cat='{0}' and subcat='{1}' ", cat,subcat);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static void insertDupsum(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from majorsummary where mno='{0}' and itemcode<>'' ", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                query = string.Format("delete  from Dupmajorsummary ", mno);
                 ocmd = new OleDbCommand(query, ocon);
                 ocmd.ExecuteNonQuery();
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     string subcat = Convert.ToString(ds.Tables[0].Rows[i][5]);
                     if (subcat != "")
                     {
                         if (subcat.Contains("Stainer") || subcat.Contains("N.R.V.") ||subcat.Contains("Sight Glass") || subcat.Contains("Trap"))
                         {

                            subcat= subcat.Replace("Stainer", "Valve");
                            subcat = subcat.Replace("N.R.V", "Valve");
                            subcat =  subcat.Replace("Sight Glass", "Valve");
                            subcat = subcat.Replace("Trap", "Valve");
                         }
                         if (subcat.Contains("Coupling") || subcat.Contains("Connecter") || subcat.Contains("Nipple"))
                         {
                         subcat = "S.S & M.S Couppling/Connecter/Nipple";

                         }
                     }
                     query = string.Format("insert into Dupmajorsummary (srno, pageno, itemcode, cat, subcat, [size], unit, qty, unitrate, amount,type,mno,Desc2) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", Convert.ToString(ds.Tables[0].Rows[i][1]), Convert.ToString(ds.Tables[0].Rows[i][2]), Convert.ToString(ds.Tables[0].Rows[i][3]), Convert.ToString(ds.Tables[0].Rows[i][4]), subcat, Convert.ToString(ds.Tables[0].Rows[i][6]), Convert.ToString(ds.Tables[0].Rows[i][7]), Convert.ToString(ds.Tables[0].Rows[i][8]), Convert.ToString(ds.Tables[0].Rows[i][9]), Convert.ToString(ds.Tables[0].Rows[i][10]), Convert.ToString(ds.Tables[0].Rows[i][11]), mno, Convert.ToString(ds.Tables[0].Rows[i][13]));
                      ocmd = new OleDbCommand(query, ocon);
                     ocmd.ExecuteNonQuery();

                 }
            
            }
            ocon.Close();
        }
        public static DataSet getdupmeasureSum(string mno, string cat)
        {
            //OleDbConnection ocon = new OleDbConnection(constr);
            //ocon.Open();
            //string query = string.Format("Select DISTINCT itemcode,subcat, [size],unit,Desc2,pageno,qty,unitrate,amount from Dupmajorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' ", mno, cat, "");
            //OleDbCommand ocmd = new OleDbCommand(query, ocon);
            //OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            //DataSet ds = new DataSet();
            //oda.Fill(ds);
            //ocon.Close();
            DataSet ds = new DataSet();

            var v = (from r in summary
                     where ((r.cat == cat)  && (r.itemcode != ""))

                     orderby r.pageno ascending
                     select new { itemcode = r.itemcode, subcat = r.subcat, size = r.size, pageno = r.pageno, Desc2 = r.Desc2, unit = r.unit,qty=r.qty,unitrate=r.unitrate,amount=r.amount }).Distinct();




            DataTable dt = new DataTable();
            dt.Columns.Add("itemcode");
            dt.Columns.Add("subcat");
            dt.Columns.Add("size");
           
            dt.Columns.Add("unit");
            dt.Columns.Add("Desc2");
            dt.Columns.Add("pageno");
            dt.Columns.Add("qty");
            dt.Columns.Add("unitrate");
            dt.Columns.Add("amount");
            double qt = 0, amt = 0, unitrate = 0;
            foreach (var item in v)
            {
                DataRow dr = dt.NewRow();
                dr["itemcode"] = item.itemcode.ToString();
                dr["subcat"] = item.subcat.ToString();
                dr["size"] = item.size.ToString();
                dr["pageno"] = item.pageno.ToString();
                dr["unit"] = item.unit.ToString();
                dr["Desc2"] = item.Desc2.ToString();
                dr["unitrate"] = item.unitrate.ToString();
                dr["qty"] = item.qty.ToString();
                dr["amount"] = item.amount.ToString();
                dt.Rows.Add(dr);
            }



            ds.Tables.Add(dt);
            return ds;
            return ds;
        }
        public static DataSet getdupmeasureSumFabSeq(string mno, string cat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT itemcode,subcat from Dupmajorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' ", mno, cat, "");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdupmeasureSumFabSeq1(string mno, string cat,string subcat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT itemcode,subcat,[size],unit from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' and subcat='{3}'  ", mno, cat, "",subcat);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdupmeasureSumEQSeq1(string mno, string cat, string subcat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT itemcode,subcat,[size],unit,Desc2 from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' and subcat='{3}'  ", mno, cat, "", subcat);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdupmeasureSumEQSeq2(string mno, string cat, string subcat, string size,string Desc2)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select Sum(Qty),avg(unitrate),sum(amount) from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' and subcat='{3}' and [size]='{4}' and Desc2='{5}'  ", mno, cat, "", subcat, size,Desc2);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdupmeasureSumFabSeq2(string mno, string cat, string subcat,string size)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select Sum(Qty),sum(amount)/Sum(Qty),sum(amount) from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' and subcat='{3}' and [size]='{4}'   ", mno, cat, "", subcat, size);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getdupmeasureSumFab(string mno, string cat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT itemcode,subcat, [size],unit,Desc2 from Dupmajorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' ", mno, cat, "");
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getReducersize(string mno, string cat,string subcat)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT  [size] from majorsummary where mno='{0}'and cat='{1}' and itemcode<>'{2}' and subcat='{3}'", mno, cat, "", subcat);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getPlantNo(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select DISTINCT  plantno from maeasurmentsheet where mno='{0}'", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            int maxcnt = 0;
            string ptno = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                query = string.Format("Select Count(  plantno) from maeasurmentsheet where mno='{0}' And plantno='{1}'", mno,Convert.ToString(ds.Tables[0].Rows[i][0]));
             ocmd = new OleDbCommand(query, ocon);
             oda = new OleDbDataAdapter(ocmd);
            DataSet ds1 = new DataSet();
            oda.Fill(ds1);
            if (Convert.ToInt32(ds1.Tables[0].Rows[0][0]) > maxcnt)
            { ptno = Convert.ToString(ds.Tables[0].Rows[i][0]);
              maxcnt = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
            }
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("plantno");
            DataRow dr = dt.NewRow();
            dr[0] = ptno;
            dt.Rows.Add(dr);
            DataSet ds3 = new DataSet();
            ds3.Tables.Add(dt);
            ocon.Close();
            return ds3;
        }
        public static DataSet getdupmeasureSum2(string mno, string cat, string subcat, string size)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select sum(qty),sum(amount),avg(unitrate) from Dupmajorsummary where mno='{0}'and cat='{1}' and subcat='{2}'  and [size]='{3}'", mno, cat, subcat, size);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }

        public static DataSet getuser(string name,string password)
        {   
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from userlogin where username='{0}' and passsword='{1}'", name, password);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }

        public static void insertuser(string uname, string PASSWORD, string ROLE,Image photo, Image sign)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
              byte[] imagedata,signdata;
             using (MemoryStream stream = new MemoryStream())
          {
                 photo.Save(stream, ImageFormat.Jpeg);
                imagedata= stream.ToArray();
           }
             using (MemoryStream stream = new MemoryStream())
             {
                 sign.Save(stream, sign.RawFormat);
                 signdata = stream.ToArray();
             }
            string query = string.Format("insert into userlogin  values('{0}','{1}','{2}',@photo,@sign)", uname, PASSWORD, ROLE, imagedata, signdata);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.Parameters.Add("photo",OleDbType.LongVarBinary).Value = imagedata;
            ocmd.Parameters.Add("sign", OleDbType.LongVarBinary).Value = signdata;
            ocmd.ExecuteNonQuery();
            MessageBox.Show("user Added");
            ocon.Close();
        }      
        public static void insertsum(string sr, string pageno, string itemcode, string cat, string subcat, string size, string unit, string qty, string unitprice, string amount, string type, string mno, string Desc2)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("insert into majorsummary (srno, pageno, itemcode, cat, subcat, [size], unit, qty, unitrate, amount,type,mno,Desc2) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", sr, pageno, itemcode, cat, subcat, size, unit, qty, unitprice, amount, type, mno, Desc2);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            ocon.Close();
        }
        public static void insertsumarysheet(string mno,string sr, string pageno, string c1, string c2, string c3, string c4, string c5, string c6, string c7, string c8, string c9, string c10)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("insert into summarry (mno,srno,pageno,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",mno, sr, pageno, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            ocon.Close();
        }
        public static void insert(string sr, string dece,string mdate,string plantno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("insert into maeasurmentsheet (mno,dece,mdate,plantno) values('{0}','{1}','{2}','{3}')", sr, dece, mdate, plantno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            ocon.Close();
        }
        public static void insertbil(string no, string bdate, string amount, string mno, string Code, string PONo)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("insert into bill values('{0}','{1}','{2}','{3}','{4}','{5}')", no, bdate, amount, mno, Code, PONo);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            ocon.Close();
        }
        public static void insertamount(string sr, string billno, string mno, string billdate, string pgno, string itmcode, string dece, string qty, string unit, string unitrate, string amount,string pgtotal, string remark)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("INSERT INTO amountsheet  (sr, billno, mno, billdate,pgno, itemcode, dece, qty, unit, unitrate, amount, pagetotal, remark) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",sr,  billno,  mno,  billdate,  pgno,  itmcode,  dece,  qty,  unit,  unitrate,  amount, pgtotal,  remark);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            ocmd.ExecuteNonQuery();
            ocon.Close();
        }
        
        public static string getbillDate(string billno)
        {
            string s = "";
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from amountsheet where billno='{0}'", billno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            { s = ds.Tables[0].Rows[0][4].ToString(); }
            ocon.Close();
            return s;
        }
        public static string getbillTotal(string billno)
        {
            string s = "";
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select sum(amount) from amountsheet where billno='{0}' and unitrate<>'' and amount<>''", billno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            //double d = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {

                s = ds.Tables[0].Rows[0][0].ToString();
            }
            ocon.Close();
            return s;
        }
        public static string getmno(string billno)
        {
            string s = "";
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select mno from amountsheet where billno='{0}'", billno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                s = ds.Tables[0].Rows[0][0].ToString();
            }
            ocon.Close();
            return s;
        }
        public static DataSet get(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from maeasurmentsheet where mno='{0}' order by ID ", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "maeasurmentsheet");
            ocon.Close();
            return ds;
        }
        public static DataSet getbillbymno(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from bill where mno='{0}' ", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static string getbillno(string billno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string s;
            string query = string.Format("Select [no] from bill where [no]='{0}' ", billno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                s = ds.Tables[0].Rows[0][0].ToString();
            }
            else
                s = "0";
            ocon.Close();
            return s;
        }
        public static DataSet getbill(string billno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from bill where [no]='{0}' ", billno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getmeasureAmount(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select sum(amount) from majorsummary where mno='{0}' AND (type = 'subcat')", mno);
           

            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getmeasureSubject(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("SELECT     subcat FROM         majorsummary WHERE     (mno = '{0}') AND (type = 'subject')", mno);


            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getsubject(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select subcat from majorsummary where mno='{0}' and type='subject' and qty='Y' ORDER BY ID ", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getSummary(string mno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from majorsummary where Mno='{0}'", mno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
        public static DataSet getAmount(string mno,string billno)
        {
            OleDbConnection ocon = new OleDbConnection(constr);
            ocon.Open();
            string query = string.Format("Select * from amountsheet where Mno='{0}'and billno='{1}'", mno,billno);
            OleDbCommand ocmd = new OleDbCommand(query, ocon);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            ocon.Close();
            return ds;
        }
    }
}
