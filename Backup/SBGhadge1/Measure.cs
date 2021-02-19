using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadgev1
{
    public partial class Measure : UserControl
    {
        public static List<majoritems> msl;
        public majoritems[] msl1 = new majoritems[30];
        public Measure()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                int j = dataGridView1.Rows.Add();
                dataGridView1.Rows[j].HeaderCell.Value = (j + 1).ToString();
                msl1[i] = new majoritems();
            }
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
      public  void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            TextBox textBoxCell = e.Control as TextBox;

            if (textBoxCell != null)
            {

                textBoxCell.KeyPress += new KeyPressEventHandler(textBoxCell_KeyPress);

            }

        }

        public  ListBox lt;

        void textBoxCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Subject == null)
            //{ return; }
            //if (e.KeyChar == Convert.ToChar(Keys.Up))
            //{
            //    if (lt != null)
            //    { lt.SelectedIndex--; }
            //}
            //if (e.KeyChar == Convert.ToChar(Keys.Down))
            //{
            //    if (lt != null)
            //    { lt.SelectedIndex++; }
            //}
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    ((TextBox)sender).Text = lt.Items[lt.SelectedIndex].ToString();
            //}
            //List<string> lst = new List<string>();
            //DataSet distinctcat = majordal.getdistinctcat();
            //TextBox t = (TextBox)sender;
            //string s = t.Text + e.KeyChar.ToString();
            //for (int i = 0; i < distinctcat.Tables[0].Rows.Count; i++)
            //{
            //    if (Convert.ToString(distinctcat.Tables[0].Rows[i][0]).ToLower().StartsWith(s.ToLower()))
            //    {
            //        lst.Add(Convert.ToString(distinctcat.Tables[0].Rows[i][0]));
            //    }
            //}
            //if (cat != "")
            //{
            //    DataSet dissub = majordal.getdistinctsubcat(cat);
            //    for (int i = 0; i < dissub.Tables[0].Rows.Count; i++)
            //    {
            //        if (Convert.ToString(dissub.Tables[0].Rows[i][0]).ToLower().StartsWith(s.ToLower()))
            //        {
            //            lst.Add(Convert.ToString(dissub.Tables[0].Rows[i][0]));
            //        }
            //    }
            //}

            //lt = new ListBox();

            //for (int i = 0; i < lst.Count; i++)
            //{
            //    lt.Items.Add(lst[i]);

            //}
            ////lt.Margin = new Padding(10, 10, 0, 0);
            ////this.Controls.Add(lt);
            //if (Application.OpenForms["itemlist"] != null)
            //{ //((SBGhadge1.itemlist)Application.OpenForms["itemlist"]).listBox1 = lt;
            //    ((SBGhadge1.itemlist)Application.OpenForms["itemlist"]).listBox1.Items.Clear();
            //   for (int i = 0; i < lst.Count; i++)
            //   {
            //    ((SBGhadge1.itemlist)Application.OpenForms["itemlist"]).listBox1.Items.Add(lst[i]);

            //   }
            //   ((SBGhadge1.itemlist)Application.OpenForms["itemlist"]).Show();
            //}
            //else{
            //   SBGhadge1.itemlist l = new SBGhadge1.itemlist();
            //   l.Show();
            //    //l.listBox1 = lt;
            //   ((SBGhadge1.itemlist)Application.OpenForms["itemlist"]).listBox1.Items.Clear();
            //   for (int i = 0; i < lst.Count; i++)
            //   {
            //       ((SBGhadge1.itemlist)Application.OpenForms["itemlist"]).listBox1.Items.Add(lst[i]);

            //   }
               
            //}

        }

 

        public string getsubject(int i)
        {
            string s = "";
            while (msl1[i].type != "subject")
            { if (i == 0)break; } i--;
            if (i != 0)
            { s = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value); }

            return s;
        }
        private void Measure_Load(object sender, EventArgs e)
        {

        }
        string type = "";
        string cat = "";
        string Subject = "";
        string subcat = "";
     public   DataGridViewCell c;
        //majoritems m;
        int ITestSubCat = 0;
        string stestsubcat;
        string[] testsubcat = { "Structural Dismantling & Refitting", "GLMS Rotary First Floor", "GLMS Rotary GR Floor", "GLMS Rotary Second Floor", "GLMS Rotary Terrace Floor", "GLMS Rotary Third Floor", "GLMS Static Equipment First Floor", "GLMS Static Equipment GR Floor", "GLMS Static Equipment Second Floor", "GLMS Static Equipment Terrace Floor", "GLMS Static Equipment Third Floor", "HDPE/PP Equipment First Floor",
                              "HDPE/PP Equipment GR Floor","HDPE/PP Equipment Second Floor","HDPE/PP Equipment Terrace Floor","HDPE/PP Equipment Third Floor","Rotary Equipment First Floor","Rotary Equipment GR Floor","Rotary Equipment Second Floor","Rotary Equipment Terrace Floor","Rotary Equipment Third Floor","Static Equipment First Floor",
                              "Static Equipment GR Floor","Static Equipment Second Floor","Static Equipment Terrace Floor","Static Equipment Third Floor","GLMS EQ","GLMS Equipment","HDPE/PP Equipment","Rotary Equipment","Static Equipment","Structural Steel Above  5 & below 10 mtr.","Structural Steel Above 10 mtr.","Structural Steel Upto 5 mtr.","Dismantling Structural Steel Above  5 & below 10 mtr.",
                              "Dismantling Structural Steel Above 10 mtr.","Dismantling Structural Steel Upto 5 mtr.","Erection  Structural Steel Above 10 mtr.","Erection  Structural Steel Above 5 & below 10 mtr.","Erection  Structural Steel Upto 5 mtr.","Fabrication Structural Steel Above  5 & below 10 mtr.","Fabrication Structural Steel Above 10 mtr.","Fabrication Structural Steel Upto 5 mtr.","Structural Dismantling & Refitting"};//,"A.C. Sheet Fitting","A.C. sheet Dismantling"
        public bool istestsubcat(string s)
        {
            bool b = false;
            for (int i = 0; i < testsubcat.Length; i++)
            {
                if (s==testsubcat[i])
                {
                    b = true;
                    return b;
                }
            }
            return b;
        }
        public bool iscat1(string s)
        { bool final = false;
        string[] cats = { "A.C. Sheet", "Dismantling & Refitting", "EQ Dismantling", "EQ Erection", "EQ Loading", "EQ Shifting", "EQ Unloading", "Fabrication & Erection", "Only Dismantling", "Labour Supply" };
       
        for (int i = 0; i < cats.Length; i++)
        {
            string p = cats[i];
                if (cats[i] == s)
                { return true; }


        
             }
        return final;
        }
        public string GetDgCat(DataGridViewCellEventArgs e, out int x)
        {
            string cat = "";
            for (int i = e.RowIndex; i >= 0; i--)
            {
                if (iscat1(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value))  || iscat1(Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)))
                {
                    x = i;
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) != "")
                    {
                        cat = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    }
                    else { cat = Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue); }
                    dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DarkViolet;
                    return cat;
                }

                if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == "" ||Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)=="") 
                {
                    cat = "";
                    type = "none";
                    x = i;
                    return cat;
                }
            }
            x = 0;
            return cat;
        }
        public string issubcat1(DataSet dx,string cat, string s)
        { // = majordal.getdistinctsubcat(cat);
        string final = "";
            if(cat=="EQ Shifting")return final;
        for (int i = 0; i < dx.Tables[0].Rows.Count; i++)
        {
            if (s == Convert.ToString(dx.Tables[0].Rows[i][0]))
            { 
                return Convert.ToString(dx.Tables[0].Rows[i][0]); }

        }
        return final;
        }
        public string GetDgSubCat(string cat,DataGridViewCellEventArgs e,int catindex)
        {
            string scat = "";
            if (cat == "")
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.Green;
                return "";
            
            }
            int i = 0;
            //for ( i = e.RowIndex; i >=0 ; i--)
            //{
            //    if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == cat || Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) == cat)
            //    { break; }
            //}
            DataSet dx = majordal.getdistinctsubcat(cat);
            for ( i =catindex+1; i <= e.RowIndex; i++)
            {
                //if (dataGridView1.Rows[i].Cells[0].Style.ForeColor != Color.Black)
                //{ continue; }
                                    if (cat == "Labour Supply")
                {
                    type = "subcat";
                    string[] rig = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value).Split();
                    if(Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) != "")
                    { rig = Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue).Split(); }
                    if (majordal.issubcat(cat, rig[0]) != "" )
                    {
                        if (dataGridView1.Rows[i].Cells[0].Style.ForeColor == Color.DeepSkyBlue)
                        { continue; }
                        if (Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) != "")
                        {
                            scat = Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue);
                            //dataGridView1.Rows[i].Cells[0].Value = subcat;
                            dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                           // subFlag = 1;
                            continue;
                        }
                        else
                        {
                            scat = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                            //dataGridView1.Rows[i].Cells[0].Value = subcat;
                            dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                            //subFlag = 1;
                            continue;
                        }
                    }
                
                
                }

                if (cat == "EQ Shifting")

                {
                     DataSet ds = majordal.isitemeqshifting(cat);
                     scat = "";
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         type = "subcat";
                         dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[0][5].ToString();
                         string size1 = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                         if (Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) != "")
                         { size1 = Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue); }
                         if (size1 == "")
                         { type = "";
                         cat = "";
                         scat = "";
                         continue;
                         }
                         char[] ch = { ' ' };
                         string[] str = size1.Split(ch);
                         int ind = -1;
                         if (str.Length <= 1)
                         { MessageBox.Show("Enter abc 300 mtr in description"); }
                         for (int i1 = 0; i1 < str.Length; i1++)
                         {
                             if (str[i1].ToLower() == "mtr")
                             {
                                 ind = i1 - 1;
                                 break;
                             }
                         }
                         if (ind != -1)
                         {
                             double b2 = 0;
                             if (double.TryParse(str[ind], out b2))
                             {

                             }
                             else { MessageBox.Show("Enter abc 300 mtr in description"); }
                         }
                         dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Firebrick;
                     }
                
                }
                if (!istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)) || !istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)))
                {
                    if ((issubcat1(dx, cat, Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)) != "" || issubcat1(dx, cat, Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)) != "") && !istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)) && !istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)))
                {
                    if (dataGridView1.Rows[i].Cells[0].Style.ForeColor == Color.DeepSkyBlue)
                    { type = "subcat"; continue; }
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) != "")
                    {
                        scat = Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue);
                        //dataGridView1.Rows[i].Cells[0].Value = subcat;
                        if (dataGridView1.Rows[i].Cells[0].Style.ForeColor != Color.DeepSkyBlue)
                        {
                                                dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DarkOrange;
                        }
                        // subFlag = 1;
                        type = "subcat";
                        continue;
                    }
                    else
                    {
                        scat = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                        //dataGridView1.Rows[i].Cells[0].Value = subcat;
                        if (dataGridView1.Rows[i].Cells[0].Style.ForeColor != Color.DeepSkyBlue)
                        {
                            dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DarkOrange;
                        }
                        // subFlag = 1;
                        type = "subcat";
                        continue;
                    }
                }
                }
                if (istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)) || istestsubcat(Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)))
                {
                    ITestSubCat = 1;
                   if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) != "")
                    {
                        scat = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    }
                    else { scat = Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue); }
                  
                   // stestsubcat = Convert.ToString(c.EditedFormattedValue);
                    dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DarkGoldenrod;
                    type = "subcat";
                    continue;
                }
                if (ITestSubCat == 1&& cat!="EQ Shifting")
                { 
                    if (majordal.iscat(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)) != ""||majordal.iscat(Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)) != "")
                    {ITestSubCat=0;
                        continue;
                    }
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == "" && Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue)=="") 
                     {ITestSubCat=0;
                     type = "none";
                        continue;
                    }
                    if(majordal.issubcat(cat,scat)!="")
                    {
                        dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.DarkCyan;
                        DataSet ds = majordal.isitem(cat, scat,"");
                        if (ds.Tables[0].Rows.Count > 0)
                        { dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[0][5].ToString();
                        
                        }
                    }
                    type = "subcat";
                }
                
                if (Convert.ToString(dataGridView1.Rows[i].Cells[0].Value) == "" && Convert.ToString(dataGridView1.Rows[i].Cells[0].EditedFormattedValue) == "")
                {
                    cat = "";
                    type = "none";
                }
                if (scat == ""&&cat!="EQ Shifting")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.Green;
                    return "";

                }
            }
            return scat;
        }
        public void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int subFlag=0;
            //cat = GetDgCat(e);

            try
            {
                c = dataGridView1.CurrentCell;
                if (Convert.ToString(c.EditedFormattedValue)==""&& c.ColumnIndex==0)
                {
                    cat = ""; Subject = "";
                    type = "none";
                    ITestSubCat = 0;
                }

                if (c.ColumnIndex == 0)
                {int catindex=0;
                if (majordal.isitem1(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value).Trim()).Tables[0].Rows.Count == 1 && (istestsubcat(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Trim())==false))
                {
                    //m.dataGridView1.Rows[i % 25].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]);
                    //m.dataGridView1.Rows[i % 25].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]);
                    //m.dataGridView1.Rows[i % 25].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]);
                    //m.dataGridView1.Rows[i % 25].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]);
                    dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                    cat = Convert.ToString(majordal.isitem1(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value).Trim()).Tables[0].Rows[0][2]);
                    dataGridView1.Rows[e.RowIndex % 25].Cells[4].Value = Convert.ToString(majordal.isitem1(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value).Trim()).Tables[0].Rows[0][5]);
                    subcat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                   // continue;
                }
                else
                {
                    cat = GetDgCat(e, out catindex);
                    subcat = GetDgSubCat(cat, e, catindex);
                } //if (istestsubcat(Convert.ToString(c.EditedFormattedValue)))
                    //{
                    //    ITestSubCat = 1;
                    //    stestsubcat = Convert.ToString(c.EditedFormattedValue);
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkGoldenrod;
                    //    return;
                    //}
                    //if (ITestSubCat==1)
                    //{
                    //    if (majordal.iscat(c.EditedFormattedValue.ToString().ToLower()) != "")
                    //    {

                    //        type = "cat";
                    //        cat = majordal.iscat(c.EditedFormattedValue.ToString().ToLower());
                    //        dataGridView1.Rows[c.RowIndex].Cells[0].Value = cat;
                    //        subcat = "";
                    //        dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkViolet;
                    //        subFlag = 1;
                    //        ITestSubCat = 0;
                    //        return;
                    //    }
                    //    if ((majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower()) != ""))
                    //    {

                    //        type = "subcat";

                    //        subcat = majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower());
                    //        dataGridView1.Rows[c.RowIndex].Cells[0].Value = subcat;
                    //        dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkOrange;
                    //        subFlag = 1;
                    //        ITestSubCat = 0;
                    //        return;
                    //    }
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Value = c.EditedFormattedValue.ToString();
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkCyan;
                    //    DataSet ds = majordal.isitem(cat, stestsubcat,"");
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    { dataGridView1.Rows[c.RowIndex].Cells[4].Value = ds.Tables[0].Rows[0][5].ToString(); }
                    //    return;
                        
                    //}
                    //if (majordal.iscat(c.EditedFormattedValue.ToString().ToLower()) != "")
                    //{
                        
                    //    type = "cat";
                    //    cat = majordal.iscat(c.EditedFormattedValue.ToString().ToLower());
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Value = cat;
                    //    subcat = "";
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkViolet;
                    //    subFlag = 1;
                    //    return;
                    //}
                    //if (cat == "Labour Supply")
                    //{
                    //    string[] rig = c.EditedFormattedValue.ToString().Split();
                    //    if (rig.Length >= 1)
                    //    {
                    //        if ((majordal.issubcat(cat.ToLower(), rig[0].ToLower()) != ""))
                    //        {

                    //            type = "subcat";

                    //            subcat = majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower());
                    //            dataGridView1.Rows[c.RowIndex].Cells[0].Value = subcat;
                    //            dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkOrange;
                    //            subFlag = 1;
                    //        }
                    //    }
                    //    else { MessageBox.Show("Type Description Like 'Rigger 2 x 6 hrs'"); }
                    //}
                    //if ((majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower()) != ""))
                    //{

                    //    type = "subcat";
                       
                    //    subcat = majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower());
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Value = subcat;
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkOrange;
                    //    subFlag = 1;
                    //}

                    //if (dataGridView1.Rows[c.RowIndex].Cells[0].EditedFormattedValue.ToString() == "")
                    //{                      
                    //    return;
                    //}
                    //if (cat != "EQ Shifting" &&subFlag==0) 
                    //{

                    //    type = "subject";
                    //    Subject = dataGridView1.Rows[c.RowIndex].Cells[0].EditedFormattedValue.ToString();
                    //    dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.Green;
               
                    //}
                    //if (cat == "EQ Shifting")
                    //{
                    //    //m = new majoritems();
                    //    //type = "subcat";
                    //    //m.type = "subcat";
                    //    //m.cat = "EQ Shifting";
                    //    DataSet ds = majordal.isitemeqshifting(cat);
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        dataGridView1.Rows[c.RowIndex].Cells[4].Value = ds.Tables[0].Rows[0][5].ToString();
                    //        string size1 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].Value).ToLower();
                    //        char[] ch = { ' ' };
                    //        string[] str = size1.Split(ch);
                    //        int ind = -1;
                    //        for (int i1 = 0; i1 < str.Length; i1++)
                    //        {
                    //            if (str[i1].ToLower() == "mtr")
                    //            {
                    //                ind = i1 - 1;
                    //                break;
                    //            }
                    //        }
                    //        if (ind != -1)
                    //        {
                    //            double b2 = 0;
                    //            if (double.TryParse(str[ind], out b2))
                    //            {

                    //            }
                    //            else { MessageBox.Show("Enter abc 300 mtr in description"); }
                    //        }
                    //        //  m = new majoritems();
                    //        // m.srno = "";
                    //        // m.type = type;
                    //        //m.itemcode = ds.Tables[0].Rows[0][1].ToString();
                    //        ////m.cat = ds.Tables[0].Rows[0][2].ToString();
                    //        //m.subcat = c.EditedFormattedValue.ToString();
                    //        //m.size = "";
                    //        //m.unit = ds.Tables[0].Rows[0][5].ToString();
                    //        //m.unitrate = ds.Tables[0].Rows[0][6].ToString();
                    //        //string size1 = c.EditedFormattedValue.ToString().ToLower();
                    //        //int siz = size1.IndexOf("(");
                    //        //int siz2 = size1.IndexOf("mtr");
                    //        //if (siz != -1 && siz2 != -1)
                    //        //{
                    //        //    size1 = size1.Substring(siz, siz2 - siz);
                    //        //    size1.Trim();
                    //        //    double b = 0;
                    //        //    if (double.TryParse(size1, out b))
                    //        //    {
                    //        //        b = double.Parse(size1);
                    //        //        double amt = b * Convert.ToDouble(m.qty) * Convert.ToDouble(m.unitrate);
                    //        //        m.amount = amt.ToString();
                    //        //    }

                    //        //}
                    //        dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.Firebrick;
                    //    }
                    //    return;
                    //}//eq shifting

                }
                //if (c.ColumnIndex == 1)
                //{
                //    if (dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor == Color.DarkViolet)
                //    { dataGridView1.Rows[c.RowIndex].Cells[0].Value = cat; }
                //}
                if (c.ColumnIndex == 2)
                {
                        if (this.dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor== Color.DarkGoldenrod ||this.dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor== Color.DarkCyan)
                    {
                        return;
                    }
                        if ((this.dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor == Color.Green) && (Convert.ToString(this.dataGridView1.Rows[c.RowIndex].Cells[0].Value)!= "") && ((Convert.ToString(this.dataGridView1.Rows[c.RowIndex].Cells[3].Value) != "Y") && (Convert.ToString(this.dataGridView1.Rows[c.RowIndex].Cells[3]) != "N")))
                    {
                        MessageBox.Show("please Enter Y or N in Qty");
                    }
                    if (type == "none" || type == "")
                    {
                        //return;
                    }
                    else if (type == "cat")
                    {
                        cat = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].EditedFormattedValue);
                        //m = new majoritems();

                        //m.type = type;
                        //m.cat = cat;
                        //msl.Add(m);
                    }
                    else
                    { DataSet ds=new DataSet();
                    if (cat == "Labour Supply")
                    {
                    //        string[] rig = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].Value).Split();
                    //    if (rig.Length >= 1)

                        ds = majordal.isitem(cat,majordal.GetLabourcat( Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].Value)), dataGridView1.Rows[c.RowIndex].Cells[2].EditedFormattedValue.ToString().Trim());
                   
                    }
                    else
                    {
                        ds = majordal.isitem(cat, dataGridView1.Rows[c.RowIndex].Cells[0].Value.ToString().Trim(), dataGridView1.Rows[c.RowIndex].Cells[2].EditedFormattedValue.ToString().Trim());
                    }
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dataGridView1.Rows[c.RowIndex].Cells[4].Value = ds.Tables[0].Rows[0][5].ToString();
                            //m = new majoritems();
                            //m.srno = "";
                            //subcat = ds.Tables[0].Rows[0][3].ToString();
                            //type = "subcat";
                            //m.type = "subcat";
                            //m.itemcode = ds.Tables[0].Rows[0][1].ToString();
                            //m.cat = ds.Tables[0].Rows[0][2].ToString();
                            //m.subcat = ds.Tables[0].Rows[0][3].ToString();
                            //m.size = ds.Tables[0].Rows[0][4].ToString();
                            //m.unit = ds.Tables[0].Rows[0][5].ToString();
                            //m.unitrate = ds.Tables[0].Rows[0][6].ToString();
                            //m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[1].Value);
                            dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                        }
                        else
                        {
                            ds = majordal.isitem(cat, dataGridView1.Rows[c.RowIndex].Cells[0].Value.ToString());
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                dataGridView1.Rows[c.RowIndex].Cells[4].Value = ds.Tables[0].Rows[0][5].ToString();
                                //m = new majoritems();
                                //m.srno = "";
                                //type = "subcat";
                                //m.type = "subcat";
                                //string gh = ds.Tables[0].Rows[0][1].ToString();
                                //m.itemcode = gh.Substring(0, gh.Length - 1) + "z";
                                //m.cat = ds.Tables[0].Rows[0][2].ToString();
                                //m.subcat = ds.Tables[0].Rows[0][3].ToString();
                                //m.size = ds.Tables[0].Rows[0][4].ToString();
                                //m.unit = ds.Tables[0].Rows[0][5].ToString();
                                //m.unitrate = "0";
                                //m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[1].Value);
                                dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor = Color.DarkOrange;
                            }

                            // for (int i = 0; i < 4; i++)
                            //{
                            // //dataGridView1.Rows[c.RowIndex].Cells[i].Style.BackColor = Color.DarkOrange;

                            // }
                        }

                    }
                }
              
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {        }

        public void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            curcell = dataGridView1.CurrentCell; 
            //if (c != null)
            //{
            //    if (c.ColumnIndex == 0)
            //    {

            //        if (majordal.iscat(c.EditedFormattedValue.ToString().ToLower()) != "")
            //        {

            //            type = "cat";
            //            cat = majordal.iscat(c.EditedFormattedValue.ToString().ToLower());
            //           // dataGridView1.Rows[c.RowIndex].Cells[0].Value = cat;
            //            subcat = "";
            //            return;
            //        }
            //    }
            //}
            //int k = e.RowIndex - 1;
            //curpageno = Convert.ToInt32(lblPageNo.Text);
            //if (dataGridView1.CurrentCell.ColumnIndex == 0 && dataGridView1.CurrentCell.RowIndex == 0)
            //{ }
            //else { }
            //string cat1 = "";
            //string subject1 = "";
            //if (e.ColumnIndex > 2)
            //{ return; }
            //while (k > 0)
            //{
            //    if (Convert.ToString(dataGridView1.Rows[k].Cells[0].Value) == "")
            //    {
            //        k--; type = "";
            //        break;
            //    }

            //    if (subject1 == "" && dataGridView1.Rows[k].Cells[0].Style.ForeColor == Color.Green)
            //    {
            //        subject1 = Convert.ToString(dataGridView1.Rows[k].Cells[0].Value);
            //    }
            //    if (cat1 == "" && dataGridView1.Rows[k].Cells[0].Style.ForeColor == Color.DarkViolet)
            //    {
            //        cat1 = Convert.ToString(dataGridView1.Rows[k].Cells[0].Value);
            //    }
            //    k--;
            //}
            //if (cat1 != "")
            //{ cat = cat1; type = "cat"; }

            //if (dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor == Color.DarkOrange || dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor == Color.DeepSkyBlue)
            //{
            //    subcat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            //    type = "subcat";
            //}
            //if (c != null)
            //{
            //    if (c.ColumnIndex == 0)
            //    {
            //        if ((majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower()) != "")&&cat1!="Labour Supply")
            //        {

            //            type = "subcat";
            //            subcat = majordal.issubcat(cat.ToLower(), c.EditedFormattedValue.ToString().ToLower());
            //            //dataGridView1.Rows[c.RowIndex].Cells[0].Value = subcat;

            //        }
            //        if (c.ColumnIndex == 3)
            //        {
            //            if (type == "subcat" && (dataGridView1.Rows[c.RowIndex].Cells[0].Style.ForeColor != Color.DarkOrange))
            //            {
            //                double b = 0;
            //                if (double.TryParse(Convert.ToString(c.EditedFormattedValue), out b))
            //                { b = double.Parse(Convert.ToString(c.EditedFormattedValue)); }
            //                //dataGridView1.Rows[c.RowIndex].Cells[c.ColumnIndex].Value = b;
            //                //m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[1].Value);
            //                //m.amount = (Convert.ToDouble(m.unitrate) * b).ToString();
            //                //m.qty = c.EditedFormattedValue.ToString();
            //                //m.pageno = lblPageNo.Text;
            //                //msl.Add(m);
            //            }
            //        }
            //    }
            //}
        }
        int rowindex;
        public static DataGridViewCell curcell;
        public static int curpageno;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //contextMenuStrip1.Left = e.X;
                //contextMenuStrip1.Top = e.Y;
                //contextMenuStrip1.
                if (copygrid != null)
                { contextMenuStrip1.Items[1].Visible = true; }
                contextMenuStrip1.Show(dataGridView1,e.X, e.Y+(e.RowIndex*20));
            }
            rowindex = e.RowIndex;
        }
        public static DataGridView copygrid;
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text=="Copy")
            {
                copygrid = new DataGridView();
                copygrid.Columns.Add("d1","d1");
                copygrid.Columns.Add("d2", "d2");
                copygrid.Columns.Add("d3", "d3");
                copygrid.Columns.Add("d4", "d4");
                copygrid.Columns.Add("d5", "d5");
                int k = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {if(dataGridView1.Rows[i].Selected)
                 { k = copygrid.Rows.Add();
                    copygrid.Rows[k].Cells[0].Value=  dataGridView1.Rows[i].Cells[0].Value;
                    copygrid.Rows[k].Cells[0].Style.ForeColor = dataGridView1.Rows[i].Cells[0].Style.ForeColor;
                    copygrid.Rows[k].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value;
                    copygrid.Rows[k].Cells[1].Style.ForeColor = dataGridView1.Rows[i].Cells[1].Style.ForeColor;
                    copygrid.Rows[k].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value;
                    copygrid.Rows[k].Cells[2].Style.ForeColor = dataGridView1.Rows[i].Cells[2].Style.ForeColor;
                    copygrid.Rows[k].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value;
                    copygrid.Rows[k].Cells[3].Style.ForeColor = dataGridView1.Rows[i].Cells[3].Style.ForeColor;
                   // copygrid.Rows[k].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value;
                    //copygrid.Rows[k].Cells[4].Style.ForeColor = dataGridView1.Rows[i].Cells[4].Style.ForeColor;
                  }
                }
                contextMenuStrip1.Items[1].Visible = true;
            }
            if (e.ClickedItem.Text == "paste")
            {
                int k = rowindex;
                if (copygrid == null)
                { return; }
                for (int i = 0; i < copygrid.Rows.Count-1; i++)
                {                 
                    dataGridView1.Rows[k].Cells[0].Value = copygrid.Rows[i].Cells[0].Value;
                    dataGridView1.Rows[k].Cells[0].Style.ForeColor = copygrid.Rows[i].Cells[0].Style.ForeColor;
                    dataGridView1.Rows[k].Cells[1].Value = copygrid.Rows[i].Cells[1].Value;
                    dataGridView1.Rows[k].Cells[1].Style.ForeColor = copygrid.Rows[i].Cells[1].Style.ForeColor;
                    dataGridView1.Rows[k].Cells[2].Value = copygrid.Rows[i].Cells[2].Value;
                    dataGridView1.Rows[k].Cells[2].Style.ForeColor = copygrid.Rows[i].Cells[2].Style.ForeColor;
                    dataGridView1.Rows[k].Cells[3].Value = copygrid.Rows[i].Cells[3].Value;
                    dataGridView1.Rows[k].Cells[3].Style.ForeColor = copygrid.Rows[i].Cells[3].Style.ForeColor;
                    //dataGridView1.Rows[k].Cells[4].Value = copygrid.Rows[i].Cells[4].Value;
                    //dataGridView1.Rows[k].Cells[4].Style.ForeColor = copygrid.Rows[i].Cells[4].Style.ForeColor;
                    k++;
                }                
            }          
        }

        public  void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show("hhg");

        }

        private void Copy_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            c = dataGridView1.CurrentCell; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            c = dataGridView1.CurrentCell;
            curcell=dataGridView1.CurrentCell; 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //if (Application.OpenForms["RCSHEET"] != null)
            //{
            //    Application.OpenForms["RCSHEET"].Hide();
            //}
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (Application.OpenForms["RCSHEET"] != null)
            {
                Application.OpenForms["RCSHEET"].Show();
                Application.OpenForms["RCSHEET"].Location = new Point(300, 0);
            }
        }
    }
}
