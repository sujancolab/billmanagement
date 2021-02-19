using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
//using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
namespace SBGhadgev1
{
    public partial class MeasurementSheet : Form
    {
        public MeasurementSheet()
        {
            InitializeComponent();
        }

        private void MeasurementSheet_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            TabPage p = new TabPage();
            p.BackColor = Color.Transparent;
            Measure m = new Measure();
            //m.Height = this.Height - 50;
            //m.Width = this.Width;
            //p.Height = m.Height;
            //p.AutoScroll = true;
            //tabControl1.Height = m.Height;
            //m.Dock = DockStyle.Fill;
            //p.Width = this.Width;
            //m.AutoScroll = true;
            //p.AutoScroll = true;
            p.Controls.Add(m);
            p.Text = "Page1";
            tabControl1.TabPages.Add(p);
            Measure.msl = new List<majoritems>();


        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            // tabControl1.Height = this.Height - 50;
            // tabControl1.Width = this.Width;
        }

        private void MeasurementSheet_SizeChanged(object sender, EventArgs e)
        {
            //tabControl1.Height = this.Height - 50;
            tabControl1.Width = this.Width;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].Width = this.Width;
                // tabControl1.TabPages[i].Height = this.Height - 50;
                if (tabControl1.TabPages[i].Controls.Count > 0)
                { //tabControl1.TabPages[i].Controls[0].Height = this.Height - 60;
                    tabControl1.TabPages[i].Controls[0].Width = this.Width;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage p = new TabPage();
            p.BackColor = Color.Transparent;
            Measure m = new Measure();
            m.lblPageNo.Text = Convert.ToString(tabControl1.TabPages.Count + 1);
           // m.Height = this.Height - 50;
           // m.Width = this.Width;
           // p.Height = this.Height - 50;
           // p.Width = this.Width;
           // m.AutoScroll = true;
           // p.AutoScroll = true;
            p.Controls.Add(m);
            p.Text = "Page" + Convert.ToString(tabControl1.TabPages.Count + 1);
            tabControl1.TabPages.Add(p);
        }
        string stestsubcat;
        string[] testsubcat = { "Structural Dismantling & Refitting", "GLMS Rotary First Floor", "GLMS Rotary GR Floor", "GLMS Rotary Second Floor", "GLMS Rotary Terrace Floor", "GLMS Rotary Third Floor", "GLMS Static First Floor", "GLMS Static GR Floor", "GLMS Static Second Floor", "GLMS Static Terrace Floor", "GLMS Static Third Floor", "HDPE/PP Equipment First Floor",
                              "HDPE/PP Equipment GR Floor","HDPE/PP Equipment Second Floor","HDPE/PP Equipment Terrace Floor","HDPE/PP Equipment Third Floor","Rotary Equipment First Floor","Rotary Equipment GR Floor","Rotary Equipment Second Floor","Rotary Equipment Terrace Floor","Rotary Equipment Third Floor","Static Equipment First Floor",
                              "Static Equipment GR Floor","Static Equipment Second Floor","Static Equipment Terrace Floor","Static Equipment Third Floor","GLMS EQ","GLMS Equipment","HDPE/PP Equipment","Rotary Equipment","Static Equipment","Structural Steel Above  5 & below 10 mtr.","Structural Steel Above 10 mtr.","Structural Steel Upto 5 mtr.","Dismantling Structural Steel Above  5 & below 10 mtr.",
                              "Dismantling Structural Steel Above 10 mtr.","Dismantling Structural Steel Upto 5 mtr.","Erection  Structural Steel Above 10 mtr.","Erection  Structural Steel Above 5 & below 10 mtr.","Erection  Structural Steel Upto 5 mtr.","Fabrication Structural Steel Above  5 & below 10 mtr.","Fabrication Structural Steel Above 10 mtr.","Fabrication Structural Steel Upto 5 mtr.","Structural Dismantling & Refitting",
                              "GLMS Tank First Floor","GLMS Tank GR Floor","GLMS Tank Second Floor","GLMS Tank Terrace Floor","GLMS Tank Third Floor"};//,"A.C. Sheet Fitting","A.C. sheet Dismantling"
        public bool istestsubcat(string s)
        {
            bool b = false;
            for (int i = 0; i < testsubcat.Length; i++)
            {
                if (s == testsubcat[i])
                {
                    b = true;
                    return b;
                }
            }
            return b;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            string errormsg = "";
             if (majordal.chkmno(txtmno.Text))
            {
                MessageBox.Show("Measurement no already exists!!!! please try new ");
                return;
            }
             try
             {
            Measure.msl=new List<majoritems>();
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                int stestflag = 0;
                Measure m = (Measure)tabControl1.TabPages[i].Controls[0];
                //Measure.msl = new List<majoritems>();
                string suject1 = "";
                string cat = "";
                this.Text = "MeasurementSheet     Saving   " + i.ToString() + "/" + tabControl1.TabPages.Count.ToString();
                if (i == 1) 
                { 
                    int ml = 0; 
                }    
                for (int j = 0; j < m.dataGridView1.Rows.Count; j++)
                {  
                    errormsg = "error at pageno=" + i + " line no=" + j;
                    majoritems m1 = new majoritems();
                    m1.mno = txtmno.Text;
                    m1.pageno = (i + 1).ToString();
                    m1.type = "none";
                   // string s = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value);
                    //majordal.insert(txtmno.Text, s);
                    DataSet it1=majordal.isitem1(Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value).Trim(), Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value).Trim());
                    if (majordal.GetLabourcat(Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value).Trim()) != "")
                    {
                        it1 = majordal.isitem1(majordal.GetLabourcat(Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value).Trim()), Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value).Trim());
                        if (it1.Tables[0].Rows.Count == 1 && m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DeepSkyBlue)
                        {
                            //m.dataGridView1.Rows[i % 25].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]);
                            //m.dataGridView1.Rows[i % 25].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]);
                            //m.dataGridView1.Rows[i % 25].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]);
                            //m.dataGridView1.Rows[i % 25].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]);
                            m1.cat = Convert.ToString(it1.Tables[0].Rows[0][2]);
                            m1.itemcode = Convert.ToString(it1.Tables[0].Rows[0][1]);
                            m1.subcat = Convert.ToString(it1.Tables[0].Rows[0][3]);
                            m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value);
                            m1.size = Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value);
                            m1.qty = Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value);
                            m1.unit = Convert.ToString(it1.Tables[0].Rows[0][5]);
                            m1.unitrate = Convert.ToString(it1.Tables[0].Rows[0][6]);
                            m1.amount = "0";
                            m1.type = "subcat";
                            try
                            {
                                m1.amount = Convert.ToString(Convert.ToDouble(m1.qty) * Convert.ToDouble(m1.unitrate));
                            }
                            catch (Exception ex)
                            {


                            }
                            // dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                            // cat = Convert.ToString(majordal.isitem(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value).Trim()).Tables[0].Rows[0][2]);
                            // subcat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            if (Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) != "")
                            {
                                majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                            }
                            else
                            {
                                majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "  " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                            }
                            Measure.msl.Add(m1);
                            continue;
                        }
                    
                    
                    }
                    if (it1.Tables[0].Rows.Count == 1&&m.dataGridView1.Rows[j].Cells[0].Style.ForeColor==Color.DeepSkyBlue)
                    {
                        //m.dataGridView1.Rows[i % 25].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]);
                        //m.dataGridView1.Rows[i % 25].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]);
                        //m.dataGridView1.Rows[i % 25].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]);
                        //m.dataGridView1.Rows[i % 25].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]);
                        m1.cat = Convert.ToString(it1.Tables[0].Rows[0][2]);
                        m1.itemcode=Convert.ToString(it1.Tables[0].Rows[0][1]);
                        m1.subcat=Convert.ToString(it1.Tables[0].Rows[0][3]);
                        m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value);
                        m1.size = Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value);
                        m1.qty = Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value);
                        m1.unit = Convert.ToString(it1.Tables[0].Rows[0][5]);
                        m1.unitrate = Convert.ToString(it1.Tables[0].Rows[0][6]);
                        m1.amount = "0";
                        m1.type = "subcat";
                        try
                        {
                            m1.amount = Convert.ToString(Convert.ToDouble(m1.qty) * Convert.ToDouble(m1.unitrate));
                        }
                        catch (Exception ex)
                        {
                            
                            
                        }
                        // dataGridView1.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                       // cat = Convert.ToString(majordal.isitem(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value).Trim(), Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value).Trim()).Tables[0].Rows[0][2]);
                       // subcat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        if (Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) != "")
                        {
                            majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        }
                        else
                        {
                            majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "  " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        }
                        Measure.msl.Add(m1);
                        continue;
                    }
                    if (Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) == "")
                    {                       
                        m1.subcat="";
                        m1.type = "none";
                        majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        continue;
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.Green)
                    {
                        suject1 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        m1.subcat=suject1;
                       // m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        m1.qty = Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value);
                        m1.type = "subject";
                     
                       
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DarkViolet)
                    {
                        cat = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        m1.subcat=cat;
                        m1.type = "cat";
                        
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor != Color.DarkCyan && stestflag == 1)
                    { stestflag = 0; }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DarkGoldenrod&&stestflag==0)
                    {

                        //suject1 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        //m1.subcat = suject1;
                        //m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        //m1.qty = Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value);
                        //m1.type = "subcat";
                        stestsubcat = m.dataGridView1.Rows[j].Cells[0].Value.ToString();
                        if (Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) != "")
                        {
                            majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        }
                        else
                        {
                            majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "  " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        } 
                        stestflag = 1;
                        continue;
                    }
                    
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DarkCyan)
                    {
                        m1.cat = cat;
                        m1.subcat = stestsubcat;
                      //  m1.dece2 = m.dataGridView1.Rows[j].Cells[0].Value.ToString();
                        DataSet ds = majordal.isitem(cat, stestsubcat, "");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            m1.type = "subcat";
                            m1.itemcode = ds.Tables[0].Rows[0][1].ToString();
                            //m1.cat = ds.Tables[0].Rows[0][2].ToString();
                           // m1.subcat = ds.Tables[0].Rows[0][3].ToString();
                            m1.size = ds.Tables[0].Rows[0][4].ToString();
                            m1.unit = ds.Tables[0].Rows[0][5].ToString();
                            m1.unitrate = ds.Tables[0].Rows[0][6].ToString();
                            m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                            double b = 0;
                            if (double.TryParse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value), out b))
                            {
                                b = double.Parse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value));
                            }
                            double b1 = 0;
                            if (double.TryParse(Convert.ToString(m1.unitrate), out b1))
                            {
                                b1 = double.Parse(m1.unitrate);
                            }
                            // m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].Value);
                            m1.amount = (b1 * b).ToString();
                            m1.qty = b.ToString();
                        }

                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DeepSkyBlue)
                    {
                        DataSet ds = new DataSet();
                        if (cat == "Labour Supply")
                        {
                            string[] rig = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value).Split();
                            if (rig.Length >= 1)
                            {
                                ds = majordal.isitem(cat, rig[0].Trim(),"");
                                m1.subcat = rig[0];
                                for (int il = 1; il < rig.Length; il++)
                                {
                                    m1.dece2 += rig[il] + " ";
                                    
                                }
                            }
                        }
                        else
                        {
                            ds = majordal.isitem(cat, m.dataGridView1.Rows[j].Cells[0].Value.ToString().Trim(), m.dataGridView1.Rows[j].Cells[2].EditedFormattedValue.ToString().Trim());
                        }
                            if (ds.Tables[0].Rows.Count > 0)
                        {
                            m1.type = "subcat";
                            m1.itemcode = ds.Tables[0].Rows[0][1].ToString();
                            m1.cat = ds.Tables[0].Rows[0][2].ToString();
                            m1.subcat = ds.Tables[0].Rows[0][3].ToString();
                            m1.size = ds.Tables[0].Rows[0][4].ToString();
                            m1.unit = ds.Tables[0].Rows[0][5].ToString();
                            m1.unitrate = ds.Tables[0].Rows[0][6].ToString();
                            m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value);
                            if (cat == "Labour Supply")
                            { m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value).Replace(m1.subcat,""); }
                            double b = 0;
                            if (double.TryParse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value), out b))
                            {
                                b = double.Parse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value));
                            }
                            double b1 = 0;
                            if (double.TryParse(Convert.ToString(m1.unitrate), out b1))
                            {
                                b1 = double.Parse(m1.unitrate);
                            }
                            // m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].Value);
                            m1.amount = (b1 * b).ToString();
                            m1.qty = b.ToString();
                        }
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DarkOrange)
                    {
                        DataSet ds = majordal.isitem(cat, m.dataGridView1.Rows[j].Cells[0].Value.ToString().Trim());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            m1.type = "subcat";
                            m1.itemcode = ds.Tables[0].Rows[0][1].ToString().Substring(0,ds.Tables[0].Rows[0][1].ToString().Length-1)+"Z";
                            m1.cat = ds.Tables[0].Rows[0][2].ToString();
                            m1.subcat = ds.Tables[0].Rows[0][3].ToString();
                            m1.size = Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value);
                            m1.unit = ds.Tables[0].Rows[0][5].ToString();
                            m1.unitrate = "0";
                            m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value);
                            double b = 0;

                            if (double.TryParse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value), out b))
                            {
                                b = double.Parse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value));
                            }
                            double b1 = 0;

                            if (double.TryParse(Convert.ToString(m1.unitrate), out b1))
                            {
                                b1 = double.Parse(m1.unitrate);
                            }
                            // m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[0].Value);
                            m1.amount = "0";
                            m1.qty = b.ToString();
                        }
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.Firebrick)
                    {
                        DataSet ds = majordal.isitemEQshift("EQ Shifting", "");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            m1.type = "subcat";
                            m1.itemcode = Convert.ToString(ds.Tables[0].Rows[0][1]);
                            m1.cat = "EQ Shifting";
                            m1.subcat =  Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                            m1.size =  Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value);
                            m1.unit =  Convert.ToString(ds.Tables[0].Rows[0][5]);
                            m1.unitrate =  Convert.ToString(ds.Tables[0].Rows[0][6]); ;
                            m1.dece2 = Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value);
                            double b = 0;

                            if (double.TryParse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value), out b))
                            {
                                b = double.Parse(Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value));
                            }
                            string size1 = m1.subcat.ToLower();
                            char[] ch={' '};
                            string[] str = size1.Split(ch);
                            int ind=-1;
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
                                    b2 = double.Parse(str[ind]);
                                    double amt = b * b2 * Convert.ToDouble(m1.unitrate);
                                    m1.amount = amt.ToString();
                                }
                            }
                            m1.qty = b.ToString();
                        }
                    }

                    if (m1.type == "subcat")
                    {
                        errormsg += " while saving summarysheet";
                        if (Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) != "")
                        {
                            majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        }
                        else
                        {
                            majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "  " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                        }
                    }
                    else
                    {
                        errormsg += " while saving summarysheet";
                        m.Mdate.Text = m.Mdate.Value.ToString();
                        majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "    " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value), m.Mdate.Value.ToString(), m.txtplantno.Text);
                    } 
                    if(m1.type!="none")
                    Measure.msl.Add(m1);
                } 
            }
                      int itemcount = 0;
                      AmountSheet sm = new AmountSheet();
                 
            foreach (majoritems m in Measure.msl)
            {
                itemcount++;
                if (sm.isSeqsec(m.cat) == false && m.type != "subject")
                {
                    if (m.subcat.Contains("Strainer") || m.subcat.Contains("N.R.V") || m.subcat.Contains("Sight Glass") || m.subcat.Contains("Trap") || m.subcat.Contains("Foot Valve"))
                    {
                        m.subcat = m.subcat.Replace("Strainer", "Valve");
                        m.subcat = m.subcat.Replace("N.R.V", "Valve");
                        m.subcat = m.subcat.Replace("Sight Glass", "Valve");
                        m.subcat = m.subcat.Replace("Trap", "Valve");
                        m.subcat = m.subcat.Replace("Foot Valve", "Valve");
                    }
                    if (m.subcat.Contains("P.T.F.E Bellow Flange"))
                    {
                        m.subcat = m.subcat.Replace("P.T.F.E Bellow Flange", "Glass Flange");

                    }
                    if (m.subcat.Contains("Reducer Joint"))
                    {
                        m.subcat = m.subcat.Replace("Reducer Joint", "Joint");

                    }
                    if (m.subcat.Contains("Blind Flange"))
                    {
                        m.subcat = m.subcat.Replace("Blind Flange", "Flange");

                    }
                    if ((m.subcat.Contains("Coupling") || m.subcat.Contains("Connecter") || m.subcat.Contains("Nipple")) && !m.subcat.Contains("Guard") && !m.subcat.Contains("By"))
                    {
                        m.subcat = "S.S. & M.S. Coupling/Connecter/Nipple";
                    }
                }
                errormsg = "error saving " + m.subcat + " " + m.size + " " + itemcount.ToString() + "th item in list";
                majordal.insertsum(m.srno, m.pageno, m.itemcode, m.cat, m.subcat, m.size, m.unit, m.qty, m.unitrate, m.amount, m.type,txtmno.Text,m.dece2);
            }
            MessageBox.Show("Measurement Saved Sucessfully ");
            this.Text = "MeasurementSheet";
             }
             catch (Exception ex)
             {
                 MessageBox.Show(errormsg); 
             }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintMeasurmentSheet pm = new PrintMeasurmentSheet();
                pm.tabControl1.TabPages.Clear();
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    this.Text = "MeasurementSheet Printing" + (i + 1).ToString() + "/" + tabControl1.TabPages.Count.ToString();
                    Measure mm = (Measure)tabControl1.TabPages[i].Controls[0];
                    string _sourceFile = Application.StartupPath + "\\Images\\measurement1.jpg";
                    _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                    Image img1 = System.Drawing.Image.FromFile(_sourceFile);
                    Graphics g = Graphics.FromImage(img1);
                    Font f = new System.Drawing.Font("Times New Roman", 14F);
                    string pgno = (i + 1).ToString();
                    g.DrawString(pgno, f, Brushes.Black, new Point(140, 165));
                    g.DrawString(mm.Mdate.Value.Date.ToString().Split()[0].Replace("/", "."), f, Brushes.Black, new Point(630, 165));
                    DataSet ds = majordal.getPlantNo(txtmno.Text);

                    string str = Convert.ToString(ds.Tables[0].Rows[0][0]);
                    g.DrawString(mm.txtplantno.Text, f, Brushes.Black, new Point(330, 165));
                    for (int j = 0; j < mm.dataGridView1.Rows.Count ; j++)
                    {
                        string s = Convert.ToString(mm.dataGridView1.Rows[j].Cells[0].Value);
                        int flag = 0;
                        //if (s.Length > 60)
                        //{
                        //    flag = 1;
                        //    f = new System.Drawing.Font("Times New Roman", 18F);
                        //}
                        //else { f = new System.Drawing.Font("Times New Roman", 18F); }
                        int kk = s.IndexOf('~');
                        int kk1 = s.LastIndexOf('~');
                        int Rowstart = 200;
                        int RowHeight = 26;
                        if (s.Contains("~"))
                        {
                            string s1 = s.Substring(0, kk);
                            char[] ch = { '~' };
                            string[] sub=s.Split(ch);
                            int s1len = s1.Length;
                            for (int k = 0; k < sub.Length; k++)
                            {
                                if (k ==0)
                                { g.DrawString(sub[k], f, Brushes.Black, new Point(130, (Rowstart + (j * RowHeight))));
                                  s1len = 130 + Convert.ToInt32(g.MeasureString(sub[k], f).Width) + 10;
                                }
                                else 
                                {
                                    g.DrawLine(new Pen(Brushes.Black), new Point(s1len, (Rowstart + 12 + (j * RowHeight))), new Point(s1len + 15, (Rowstart + 12 + (j * RowHeight))));
                                    g.DrawString(sub[k], f, Brushes.Black, new Point(s1len + 25, (Rowstart + (j * RowHeight))));
                                    s1len += 25 +Convert.ToInt32( g.MeasureString(sub[k], f).Width) + 10;
                                }
                            }
                            //if (flag == 1)
                            //{
                            //    g.DrawString(s1, f, Brushes.Black, new Point(130, (130 + (j * 50))));
                            //    g.DrawLine(new Pen(Brushes.Black), new Point(900, (250 + (j * 50))), new Point(950, (250 + (j * 50))));
                            //    s1 = s.Substring(kk + 1);
                            //    g.DrawString(s1, f, Brushes.Black, new Point(980, (240 + (j * 50))));
                            //}
                            //else
                            //{
                            //    SizeF sz = g.MeasureString(s1, f);
                            //    g.DrawString(s1, f, Brushes.Black, new Point(130, (Rowstart + (j * RowHeight))));
                            //    g.DrawLine(new Pen(Brushes.Black), new Point(130 + (int)sz.Width, (Rowstart + 12 + (j * RowHeight))), new Point(130 + (int)sz.Width + 25, (Rowstart + 12 + (j * RowHeight))));
                            //    s1 = s.Substring(kk + 1);
                            //    SizeF sz1 = g.MeasureString(s1, f);
                            //    g.DrawString(s1, f, Brushes.Black, new Point(165 + (int)sz.Width, ((Rowstart + (j * RowHeight)))));
                            //}
                        }
                        else
                        {
                            g.DrawString(s, f, Brushes.Black, new Point(130, (Rowstart + (j * RowHeight))));
                        }
                    }
                    string path = Application.StartupPath + "\\Measurment\\";
                    path = path.Replace("\\bin\\Debug", "");
                    img1.Save(path + (i + 1).ToString() + ".jpg");
                    PrintMeasure.s = path + (i + 1).ToString() + ".jpg";
                    PrintMeasure m = new PrintMeasure();
                    TabPage tp = new TabPage("Page" + (i + 1).ToString());
                    tp.Controls.Add(m);
                    pm.tabControl1.TabPages.Add(tp);
                }
                pm.ShowDialog();
                
                this.Text = "MeasurementSheet";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            //SBGhadge1.Crp.PrintMeasurRPT f = new SBGhadge1.Crp.PrintMeasurRPT();
            //f.Mno = txtmno.Text;
            //f.Show();
            //return;
            int rownum = 30;
            
            try{
            DataSet ds = majordal.get(txtmno.Text);
            if (ds.Tables[0].Rows.Count == 0)
            { MessageBox.Show("Record not found");
              return;
            }
            tabControl1.TabPages.Clear();
            Measure m = new Measure();
            int catidex = 0;
          
            //m.dateTimePicker1.Text = ds.Tables[0].Rows[0][3].ToString();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.Text = "MeasurementSheet Loading" + (i + 1).ToString() + "/" + ds.Tables[0].Rows.Count.ToString();
                if (i % rownum == 0 && (i != ds.Tables[0].Rows.Count-1))
                {
                    //m = new Measure();
                    tabControl1.TabPages.Add("Page"+((i/rownum)+1).ToString());
                    m.Mdate.Text = ds.Tables[0].Rows[i][3].ToString();
                    m.txtplantno.Text = ds.Tables[0].Rows[i][4].ToString();
                }               
                m.dataGridView1.Rows[i % rownum].Cells[0].Value = ds.Tables[0].Rows[i][2].ToString();
                if (majordal.iscat(m.dataGridView1.Rows[i % rownum].Cells[0].Value.ToString().ToLower()) != "")
                { catidex = i % rownum; }
                if (m.dataGridView1.Rows[i % rownum].Cells[0].Value.ToString().ToLower().Contains("stuctural steel"))
                { int x=m.dataGridView1.Rows[i % rownum].Cells[0].Value.ToString().IndexOf("    ");
                        if (x == -1)
                        { continue; }
                        string s = m.dataGridView1.Rows[i % rownum].Cells[0].Value.ToString().Substring(0, x + 1);
                        string s2 = m.dataGridView1.Rows[i % rownum].Cells[0].Value.ToString().Substring(x + 4);
                        m.dataGridView1.Rows[i % rownum].Cells[0].Value = s2;
                        m.dataGridView1.Rows[catidex].Cells[0].Value = s;
                }
                if (i % rownum == 29 || (i == ds.Tables[0].Rows.Count - 1))
                {
                    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(m);
                    m = new Measure();
                    m.Mdate.Text = ds.Tables[0].Rows[i][3].ToString();
                    m.txtplantno.Text = ds.Tables[0].Rows[i][4].ToString();
                    catidex = 0;
                }
            }
                 this.Text = "MeasurementSheet";
            }
            catch (Exception Ex)
            { }
        }

        private void MeasurementSheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!majordal.chkmno(txtmno.Text))
            {
                if (MessageBox.Show("Record not saved do you Want to Exit", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { }
                else { e.Cancel = true; }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int pageno = 0, rownum = 0;
            try
            {
                OpenFileDialog o = new OpenFileDialog();
                o.Filter = "Excel Worksheets 2003 (*.xls)|*.xls|Excel Worksheets 2007 (*.xlsx)|*.xlsx;";
                o.ShowDialog();
                // itype = "";
                if (o.FileName != "")
                {

                    //try
                    //{

                    OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + o.FileName + "; Extended Properties=Excel 12.0;");
                    cnn.Open();
                    DataTable dt1 = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //cnn.Close();
                    tabControl1.TabPages.Clear();

                    int noofsheets = dt1.AsEnumerable().Cast<DataRow>().Where(row => row["TABLE_NAME"].ToString().EndsWith("$")).Count();
                    for (int j = 1; j <= dt1.Rows.Count; j++)
                    {
                        pageno=j;
                        this.Text = "MeasurementSheet     Loading   " + j.ToString() + "/" + dt1.Rows.Count.ToString();
                        string iSubcat = "", icat = "";
                        string stestsubcat="", path = o.FileName;
                        int itestsubcat = 0;
                        if (j == 3)
                        {
                            int l = 0;
                        }
                        // string tabname = Convert.ToString(dt1.Rows[j]["TABLE_NAME"]);
                        Measure m = new Measure();
                        //cnn.Close();
                        OleDbCommand oconn = new OleDbCommand("select * from [" + "Sheet" + j.ToString() + "$" + "]", cnn);
                        //cnn.Open();
                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                        DataSet dt = new DataSet();

                        adp.Fill(dt);
                        cnn.Close();
                        int rcnt = 31;
                        if (dt.Tables[0].Rows.Count < 31)
                        { rcnt = dt.Tables[0].Rows.Count; }
                        for (int i = 0; i < rcnt; i++)
                        {
                            if (i >=7 && icat == "Only Dismantling")
                            {
                                int pm = 0;
                            }
                            rownum=i+2;
                            if (icat == "Labour Supply" )
                            {
                                if (majordal.GetLabourcat(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim()) != "")
                                {
                                    m.dataGridView1.Rows[i % 30].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                                   int tr=0;
                               if (int.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim(), out tr))
                               { //
                               }
                               else
                               {
                                   m.dataGridView1.Rows[i % 30].Cells[3].Value = "0"; 
                                   m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange;
                               }
                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                               // DataSet it1 = majordal.isitem1(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim(), Convert.ToString(dt.Tables[0].Rows[i][2]).Trim());
                                m.dataGridView1.Rows[i % 30].Cells[4].Value = "Hrs.";

                                continue;
                                 }
                                
                               
                            }
                           
                            //if (i == 0)
                            //{
                            //    int xp = 0;
                               
                            //}
                           
                            //try
                            //{
                            if (i == 0)
                            {
                                m = new Measure();
                                tabControl1.TabPages.Add("P" + (tabControl1.TabPages.Count + 1).ToString());
                                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(m);
                                if (dt.Tables[0].Columns.Count > 4)
                                {
                                    try
                                    {
                                        //DateTime s = Convert.ToDateTime(dt.Tables[0].Rows[i][4]);
                                        m.Mdate.Text = Convert.ToDateTime(dt.Tables[0].Rows[i][4]).ToString();
                                        m.txtplantno.Text=Convert.ToString(dt.Tables[0].Rows[i][5]);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Date Error page no" + j.ToString());
                                    }
                                }
                            }
                            if (majordal.iscat(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim()) != "")
                            {
                                icat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = icat.Trim();
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkViolet;
                                itestsubcat = 0; stestsubcat = "";
                                continue;

                            }
                           // string labsubcat=majordal.getl
                            if (majordal.isitem1(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim(), Convert.ToString(dt.Tables[0].Rows[i][2]).Trim()).Tables[0].Rows.Count == 1 && (istestsubcat(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim()) == false))
                            {
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                               double tr=0;
                               if (double.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim(), out tr))
                               { //
                               }
                               else
                               {
                                   m.dataGridView1.Rows[i % 30].Cells[3].Value = "0"; 
                                   m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange;
                               }
                                
                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                                DataSet it1 = majordal.isitem1(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim(), Convert.ToString(dt.Tables[0].Rows[i][2]).Trim());
                                m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(it1.Tables[0].Rows[0][5]).Trim();
                                if (m.dataGridView1.Rows[i % 30].Cells[4].Value.ToString() == "Nos." || m.dataGridView1.Rows[i % 30].Cells[4].Value.ToString() == "K.G.")
                                {
                                    int tr1 = 0;
                                    if (int.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim(), out tr1))
                                    { //
                                    }
                                    else
                                    {
                                        m.dataGridView1.Rows[i % 30].Cells[3].Value = "0";
                                        m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange;
                                    }
                                   
                                }
                                continue;
                            }
                            if (istestsubcat(Convert.ToString(dt.Tables[0].Rows[i][0])))
                            {
                                stestsubcat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = stestsubcat;
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkGoldenrod;
                                itestsubcat = 1;
                                continue;
                            }
                            if (itestsubcat == 1)
                            {
                                if (Convert.ToString(dt.Tables[0].Rows[i][0]) == "")
                                { itestsubcat = 0; icat = ""; stestsubcat = ""; continue; }
                                if (majordal.iscat(Convert.ToString(dt.Tables[0].Rows[i][0])) != "")
                                {
                                    icat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[0].Value = icat;
                                    m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                                    m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkViolet;
                                    itestsubcat = 0;
                                    continue;
                                }
                                if (icat != "EQ Shifting" && majordal.issubcat(icat, Convert.ToString(dt.Tables[0].Rows[i][0])) != "")
                                {
                                    itestsubcat = 0;
                                    iSubcat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[0].Value = iSubcat;
                                    m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                                    string size = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                    m.dataGridView1.Rows[i % 30].Cells[2].Value = size;
                                    m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]);
                                    DataSet dx = majordal.isitem(icat, Convert.ToString(dt.Tables[0].Rows[i][0]).Trim(),size);
                                    if (dx.Tables[0].Rows.Count > 0)
                                    {
                                        m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                                        m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(dx.Tables[0].Rows[0][5]).Trim();
                                    }
                                    else
                                    {
                                        m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkOrange;
                                        m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(dx.Tables[0].Rows[0][5]).Trim();
                                    }
                                    double d = 0;
                                    if (double.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim(), out d))
                                    {
                                        d = double.Parse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim());

                                    }
                                    else
                                    {
                                       // m.dataGridView1.Rows[i % 25].Cells[3].Value = "0";
                                        m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange; }
                                    m.dataGridView1.Rows[i % 30].Cells[3].Value = d;
                                    continue;
                                }
                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkCyan;
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();

                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                                double tr = 0;
                                if (double.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim(), out tr))
                                {  }
                                else
                                {
                                    m.dataGridView1.Rows[i % 30].Cells[3].Value = majordal.CalcSteel(Convert.ToString(dt.Tables[0].Rows[i][0]).Trim(),Convert.ToString(dt.Tables[0].Rows[i][1]).Trim());
                                    m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange; 
                                }
                             
                                DataSet dx5 = majordal.isitem(icat, stestsubcat);
                                m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(dx5.Tables[0].Rows[0][5]).Trim();

                                continue;
                            }
                            if (majordal.iscat(Convert.ToString(dt.Tables[0].Rows[i][0])) != "")
                            {
                                icat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = icat.Trim();
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkViolet;
                                continue;

                            }
                            if (icat != "EQ Shifting" && majordal.issubcat(icat, Convert.ToString(dt.Tables[0].Rows[i][0]).Trim()) != "")
                            {

                                iSubcat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = iSubcat;
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                                string size = Convert.ToString(dt.Tables[0].Rows[i][2]);
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = size.Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                                DataSet dx = majordal.isitem(icat, Convert.ToString(dt.Tables[0].Rows[i][0]).Trim(), size);
                                if (dx.Tables[0].Rows.Count > 0)
                                {
                                    m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DeepSkyBlue;
                                    m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(dx.Tables[0].Rows[0][5]).Trim();
                                }
                                else
                                {
                                    if (m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor != Color.DeepSkyBlue)
                                        m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.DarkOrange;
                                    dx = majordal.isitem(icat, Convert.ToString(dt.Tables[0].Rows[i][0]).Trim());
                                    m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(dx.Tables[0].Rows[0][5]).Trim();
                                }
                                double d = 0;
                                if (double.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim(), out d))
                                {
                                    d = double.Parse(Convert.ToString(dt.Tables[0].Rows[i][3]).Trim());

                                }
                                else { m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange; }
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                                m.dataGridView1.Rows[i % 30].Cells[3].Value = d;
                                continue;


                            }
                            if (Convert.ToString(dt.Tables[0].Rows[i][0]) == "")
                            {
                                icat = "";
                                continue;
                            }
                            if (icat == "EQ Shifting")
                            {
                                iSubcat = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                                if (iSubcat == "")
                                { icat = ""; continue; }
                                m.dataGridView1.Rows[i % 30].Cells[0].Value = iSubcat;
                                m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                                m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.Firebrick;
                                string size2 = Convert.ToString(dt.Tables[0].Rows[i][2]);
                                //m.dataGridView1.Rows[i % 25].Cells[1].Value = size2;
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                                double d = 0;
                                if (double.TryParse(Convert.ToString(dt.Tables[0].Rows[i][3]), out d))
                                {
                                    d = double.Parse(Convert.ToString(dt.Tables[0].Rows[i][3]));

                                }
                                else { m.dataGridView1.Rows[i % 30].Cells[3].Style.BackColor = Color.DarkOrange; }
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = d;
                                DataSet sh = majordal.isitemeqshifting(icat);
                                m.dataGridView1.Rows[i % 30].Cells[4].Value = Convert.ToString(sh.Tables[0].Rows[0][5]).Trim();
                                continue;

                            }


                            m.dataGridView1.Rows[i % 30].Cells[0].Style.ForeColor = Color.Green;
                            m.dataGridView1.Rows[i % 30].Cells[0].Value = Convert.ToString(dt.Tables[0].Rows[i][0]).Trim();
                            m.dataGridView1.Rows[i % 30].Cells[1].Value = Convert.ToString(dt.Tables[0].Rows[i][1]).Trim();
                            m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                            m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();

                            string size1 = Convert.ToString(dt.Tables[0].Rows[i][2]);
                            //m.dataGridView1.Rows[i % 25].Cells[1].Value = size1.Trim();
                            m.dataGridView1.Rows[i % 30].Cells[2].Value = Convert.ToString(dt.Tables[0].Rows[i][2]).Trim();
                            m.dataGridView1.Rows[i % 30].Cells[3].Value = Convert.ToString(dt.Tables[0].Rows[i][3]).Trim();
                            if (Convert.ToString(dt.Tables[0].Rows[i][3]).Trim() == "")
                            {
                                m.dataGridView1.Rows[i % 30].Cells[3].Value = "Y"; 
                            }
                            //}
                            //catch (Exception ex1)
                            //{

                            //}
                        }

                    }
                    this.Text = "MeasurementSheet";

                    //}
                    //catch (Exception ex)
                    //{ 


                    //}
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"Error At Page No="+ pageno+"& Row no="+rownum);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {try{
            if (txtmno.Text != "" && MessageBox.Show("Are you Sure To Delete Billno:" + txtmno.Text, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { majordal.deleteRecord(txtmno.Text);
            MessageBox.Show(" Billno:" + txtmno.Text+"Deleted SucessFully", "");
            
            }
            }
        catch (Exception Ex)
        { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PrintMeasurmentSheet pm = new PrintMeasurmentSheet();
                pm.tabControl1.TabPages.Clear();
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    this.Text = "MeasurementSheet Printing" + (i + 1).ToString() + "/" + tabControl1.TabPages.Count.ToString();
                    Measure mm = (Measure)tabControl1.TabPages[i].Controls[0];
                    string _sourceFile = Application.StartupPath + "\\Images\\measurement1.jpg";
                    _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
                    Image img1 = System.Drawing.Image.FromFile(_sourceFile);
                    Graphics g = Graphics.FromImage(img1);
                    Font f = new System.Drawing.Font("Times New Roman", 14F);
                    string pgno = (i + 1).ToString();
                    g.DrawString(pgno, f, Brushes.Black, new Point(140, 165));
                    g.DrawString(mm.Mdate.Value.Date.ToString().Split()[0].Replace("/", "."), f, Brushes.Black, new Point(630, 165));
                    DataSet ds = majordal.getPlantNo(txtmno.Text);

                    string str = Convert.ToString(ds.Tables[0].Rows[0][0]);
                    g.DrawString(mm.txtplantno.Text, f, Brushes.Black, new Point(330, 165));
                    //dgvtocsv(mm.dataGridView1);
                    ExtractDataToCSV(mm.dataGridView1);

                    //    for (int j = 0; j < mm.dataGridView1.Rows.Count; j++)
                    //    {
                    //        string s = Convert.ToString(mm.dataGridView1.Rows[j].Cells[0].Value);
                    //        int flag = 0;
                    //        //if (s.Length > 60)
                    //        //{
                    //        //    flag = 1;
                    //        //    f = new System.Drawing.Font("Times New Roman", 18F);
                    //        //}
                    //        //else { f = new System.Drawing.Font("Times New Roman", 18F); }
                    //        int kk = s.IndexOf('~');
                    //        int kk1 = s.LastIndexOf('~');
                    //        int Rowstart = 200;
                    //        int RowHeight = 26;
                    //        if (s.Contains("~"))
                    //        {
                    //            string s1 = s.Substring(0, kk);
                    //            char[] ch = { '~' };
                    //            string[] sub = s.Split(ch);
                    //            int s1len = s1.Length;
                    //            for (int k = 0; k < sub.Length; k++)
                    //            {
                    //                if (k == 0)
                    //                {
                    //                    g.DrawString(sub[k], f, Brushes.Black, new Point(130, (Rowstart + (j * RowHeight))));
                    //                    s1len = 130 + Convert.ToInt32(g.MeasureString(sub[k], f).Width) + 10;
                    //                }
                    //                else
                    //                {
                    //                    g.DrawLine(new Pen(Brushes.Black), new Point(s1len, (Rowstart + 12 + (j * RowHeight))), new Point(s1len + 15, (Rowstart + 12 + (j * RowHeight))));
                    //                    g.DrawString(sub[k], f, Brushes.Black, new Point(s1len + 25, (Rowstart + (j * RowHeight))));
                    //                    s1len += 25 + Convert.ToInt32(g.MeasureString(sub[k], f).Width) + 10;
                    //                }
                    //            }
                    //            //if (flag == 1)
                    //            //{
                    //            //    g.DrawString(s1, f, Brushes.Black, new Point(130, (130 + (j * 50))));
                    //            //    g.DrawLine(new Pen(Brushes.Black), new Point(900, (250 + (j * 50))), new Point(950, (250 + (j * 50))));
                    //            //    s1 = s.Substring(kk + 1);
                    //            //    g.DrawString(s1, f, Brushes.Black, new Point(980, (240 + (j * 50))));
                    //            //}
                    //            //else
                    //            //{
                    //            //    SizeF sz = g.MeasureString(s1, f);
                    //            //    g.DrawString(s1, f, Brushes.Black, new Point(130, (Rowstart + (j * RowHeight))));
                    //            //    g.DrawLine(new Pen(Brushes.Black), new Point(130 + (int)sz.Width, (Rowstart + 12 + (j * RowHeight))), new Point(130 + (int)sz.Width + 25, (Rowstart + 12 + (j * RowHeight))));
                    //            //    s1 = s.Substring(kk + 1);
                    //            //    SizeF sz1 = g.MeasureString(s1, f);
                    //            //    g.DrawString(s1, f, Brushes.Black, new Point(165 + (int)sz.Width, ((Rowstart + (j * RowHeight)))));
                    //            //}
                    //        }
                    //        else
                    //        {
                    //            g.DrawString(s, f, Brushes.Black, new Point(130, (Rowstart + (j * RowHeight))));
                    //        }
                    //    }
                    //    string path = Application.StartupPath + "\\Measurment\\";
                    //    path = path.Replace("\\bin\\Debug", "");
                    //    img1.Save(path + (i + 1).ToString() + ".jpg");
                    //    PrintMeasure.s = path + (i + 1).ToString() + ".jpg";
                    //    PrintMeasure m = new PrintMeasure();
                    //    TabPage tp = new TabPage("Page" + (i + 1).ToString());
                    //    tp.Controls.Add(m);
                    //    pm.tabControl1.TabPages.Add(tp);
                    //}
                    //pm.ShowDialog();

                    //this.Text = "MeasurementSheet";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        public void dgvtocsv(DataGridView dataGridView1)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
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
