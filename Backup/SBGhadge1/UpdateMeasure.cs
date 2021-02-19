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
    public partial class UpdateMeasure : Form
    {
        public UpdateMeasure()
        {
            InitializeComponent();
        }

        private void UpdateMeasure_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            //TabPage p = new TabPage();
            Measure m = new Measure();
          //  p.Controls.Add(m);
           // p.Text = "Page1";
           // tabControl1.TabPages.Add(p);
            //Measure.msl = new List<majoritems>();
            DataSet ds = new DataSet();
            ds = majordal.getmeasurebymno(txtmno.Text);
            string cat = "";
            string pageno = "1";
            if (ds.Tables[0].Rows.Count > 0)
            {
                int ronno = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (pageno != ds.Tables[0].Rows[i][6].ToString())
                    {
                        tabControl1.TabPages.Add("Page" + pageno);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(m);
                        m = new Measure();
                        pageno = ds.Tables[0].Rows[i][6].ToString();
                        ronno = 0;
                    }
                    if (ds.Tables[0].Rows[i][5].ToString()=="subject")
                    {
                        m.dataGridView1.Rows[ronno].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                        m.dataGridView1.Rows[ronno].Cells[0].Style.ForeColor = Color.Green;
                    }
                    if (ds.Tables[0].Rows[i][5].ToString() == "cat")
                    {
                        cat = ds.Tables[0].Rows[i][0].ToString();
                        m.dataGridView1.Rows[ronno].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                        m.dataGridView1.Rows[ronno].Cells[0].Style.ForeColor = Color.DarkViolet;
                    }
                    if (ds.Tables[0].Rows[i][5].ToString() == "subcat")
                    {
                        m.dataGridView1.Rows[ronno].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();

                        m.dataGridView1.Rows[ronno].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                        m.dataGridView1.Rows[ronno].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                        m.dataGridView1.Rows[ronno].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();

                        m.dataGridView1.Rows[ronno].Cells[4].Value = ds.Tables[0].Rows[i][4].ToString();

                        if (cat == "EQ Shifting")
                        {
                            m.dataGridView1.Rows[ronno].Cells[0].Style.ForeColor = Color.Firebrick;
                            continue;
                        }
                        if (majordal.isitem(cat, ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString()).Tables[0].Rows.Count > 0)
                        { m.dataGridView1.Rows[ronno].Cells[0].Style.ForeColor = Color.DarkOrange; }
                        else { m.dataGridView1.Rows[ronno].Cells[0].Style.ForeColor = Color.DeepSkyBlue; }

                    }
                    ronno++;
                }
                tabControl1.TabPages.Add("Page" + pageno);
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(m);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            majordal.deleteRecord(txtmno.Text);
             if (majordal.chkmno(txtmno.Text))
            {
                MessageBox.Show("Measurement no already exists!!!! please try new ");
                return;
            }
            Measure.msl=new List<majoritems>();
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Measure m = (Measure)tabControl1.TabPages[i].Controls[0];
                //Measure.msl = new List<majoritems>();
                string suject1 = "";
                string cat = "";                
                for (int j = 0; j < m.dataGridView1.Rows.Count; j++)
                {
                    majoritems m1 = new majoritems();
                    m1.mno = txtmno.Text;
                    m1.pageno = (i + 1).ToString();
                    m1.type = "none";
                   // string s = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value);
                    //majordal.insert(txtmno.Text, s);
                    if (Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) == "")
                    {                       
                        m1.subcat="";
                        m1.type = "none";
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.Green)
                    {
                        suject1 = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        m1.subcat=suject1;
                        m1.type = "subject";
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DarkViolet)
                    {
                        cat = Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value);
                        m1.subcat=cat;
                        m1.type = "cat";
                    }
                    if (m.dataGridView1.Rows[j].Cells[0].Style.ForeColor == Color.DeepSkyBlue)
                    {
                        DataSet ds = majordal.isitem(cat,Convert.ToString( m.dataGridView1.Rows[j].Cells[0].Value).Trim(), m.dataGridView1.Rows[j].Cells[2].EditedFormattedValue.ToString().Trim());
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
                            // m.dece2 = Convert.ToString(dataGridView1.Rows[c.RowIndex].Cells[1].Value);
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
                            string size1 = m1.dece2.ToLower();
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
                    if (m1.type != "none")
                    { Measure.msl.Add(m1); }
                    if (m1.type == "subcat")
                    {
                        majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value) + "  " + Convert.ToString(m.dataGridView1.Rows[j].Cells[1].Value) + "  " + Convert.ToString(m.dataGridView1.Rows[j].Cells[2].Value) + "~" + Convert.ToString(m.dataGridView1.Rows[j].Cells[3].Value) + " " + Convert.ToString(m.dataGridView1.Rows[j].Cells[4].Value),dtp1.Text,txtplantno.Text);
                    }
                    else
                    {
                        majordal.insert(txtmno.Text, Convert.ToString(m.dataGridView1.Rows[j].Cells[0].Value), dtp1.Text, txtplantno.Text);
                    }
                }
            }
            foreach (majoritems m in Measure.msl)
            {
                if (m.subcat.Contains("Strainer") || m.subcat.Contains("N.R.V.") || m.subcat.Contains("Sight Glass") || m.subcat.Contains("Trap") || m.subcat.Contains("Foot Valve"))
                {
                    m.subcat = m.subcat.Replace("Strainer", "Valve");
                    m.subcat = m.subcat.Replace("N.R.V.", "Valve");
                    m.subcat = m.subcat.Replace("Sight Glass", "Valve");
                    m.subcat = m.subcat.Replace("Trap", "Valve");
                    m.subcat = m.subcat.Replace("Foot Valve", "Valve");
                }
                if (m.subcat.Contains("P.T.E.F Bellow Flange"))
                {
                    m.subcat = m.subcat.Replace("P.T.E.F Bellow Flange", "Glass Flange");

                }
                if (m.subcat.Contains("Couppling") || m.subcat.Contains("Connecter") || m.subcat.Contains("Nipple"))
                {
                    m.subcat = "S.S. & M.S. Couppling/Connecter/Nipple";
                }
                majordal.insertsum(m.srno, m.pageno, m.itemcode, m.cat, m.subcat, m.size, m.unit, m.qty, m.unitrate, m.amount, m.type,txtmno.Text,m.dece2);
            }
            MessageBox.Show("Measurement Updated Sucessfully ");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            majordal.deleteRecord(txtmno.Text);
            MessageBox.Show("Measurement Deleted Sucessfully ");
        }

    }
}
