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
    public partial class RCSHEET : Form
    {
        public RCSHEET()
        {
            InitializeComponent();
        }
        string cat;
        private void RCSHEET_Load(object sender, EventArgs e)
        {
           
            DataSet ds = majordal.getdistinctcat();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static Measure m = new Measure();
        int curtRow =m.dataGridView1.CurrentRow.Index;

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           DataSet ds = majordal.getdistinctsubcat(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
            cat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (Application.OpenForms["MeasurementSheet"] != null)
            {
                if (Measure.curcell == null)
                { return; }
              DataGridViewCellEventArgs de = new DataGridViewCellEventArgs(Measure.curcell.ColumnIndex, Measure.curcell.RowIndex);
                //((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno - 1].Controls[0]).dataGridView1.CommitEdit(DataGridViewDataErrorContexts.LeaveControl);
                ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno ].Controls[0]).dataGridView1.Refresh();
                ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno ].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[0].Value = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
               // ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno - 1].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[0].Style.ForeColor = Color.DarkViolet;
               
            }
        
        }
        public string subcat = "";
        public string strcmp(string m, string n)
        {
            char[] ch = { ' ' };
            double a=0,b=0;
            try
            {
                if (m.Contains("x"))
                {

                }
                else
                {
                    string p = m.Replace("\"", "");
                    string q = n.Replace("\"", "");
                    string[] s1 = p.Split(ch);
                    string[] s2 = q.Split(ch);
                    if (s1.Length > 1)
                    {
                        //char[] ch1={'/'};
                        //    string[] s3=s1[1].Split(ch1);
                        a = Convert.ToDouble(s1[0]) + 0.5;
                    }
                    else
                    {
                        char[] ch1 = { '/' };
                        string[] s3 = s1[0].Split(ch1);
                        if (s3.Length <= 1)
                        {
                            a = Convert.ToDouble(s1[0]);
                        }
                        else
                        {
                            a = Convert.ToDouble(s3[0]) / Convert.ToDouble(s3[1]);
                        }
                    }

                    if (s2.Length > 1)
                    {
                        b = Convert.ToDouble(s2[0]) + 0.5;
                    }
                    else
                    {
                        char[] ch1 = { '/' };
                        string[] s3 = s2[0].Split(ch1);
                        if (s3.Length <= 1)
                        {
                            b = Convert.ToDouble(s2[0]);
                        }
                        else
                        {
                            b = Convert.ToDouble(s3[0]) / Convert.ToDouble(s3[1]);
                        }
                    }
                }
                if (b < a)
                { return n; }
            }
            catch (Exception ex)
            { }
            return m;
        }
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataSet ds = majordal.getdistinctsize(cat, Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[0].Value));
                if (((dataGridView2.Rows[e.RowIndex].Cells[0].Value).ToString().Contains("Reducer")) || ((dataGridView2.Rows[e.RowIndex].Cells[0].Value).ToString().Contains("Structural Steel")))
                {
                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string min = ds.Tables[0].Rows[i][0].ToString();
                        int minloc = i;
                        for (int j = i; j < ds.Tables[0].Rows.Count; j++)
                        {
                            if (strcmp(min, ds.Tables[0].Rows[j][0].ToString()) != min)
                            {
                                string temp = min;
                                min = ds.Tables[0].Rows[j][0].ToString();
                                ds.Tables[0].Rows[j][0] = temp;
                                ds.Tables[0].Rows[minloc][0] = min;
                                // minloc = j;                    
                            }
                        }
                    }

                }
                // cat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                dataGridView3.DataSource = ds.Tables[0];
                dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Application.OpenForms["MeasurementSheet"] != null)
                {
                    subcat = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                    ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno ].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[0].Value = subcat;
                    ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno ].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[0].Style.ForeColor = Color.DarkOrange;

                }
            }
            catch (Exception ex)
            { }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Application.OpenForms["MeasurementSheet"] != null)
            {
                ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno - 1].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[0].Value =subcat;
                ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno - 1].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[0].Style.ForeColor = Color.DarkOrange;
               ((Measure)((TabControl)Application.OpenForms["MeasurementSheet"].Controls["tabControl1"]).TabPages[Measure.curpageno - 1].Controls[0]).dataGridView1.Rows[Measure.curcell.RowIndex].Cells[2].Value = Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells[0].Value);
           }
        }

        private void RCSHEET_MouseLeave(object sender, EventArgs e)
        {
            //this.Hide();
            //int flg = 0;
     
            //foreach (Control item in this.Controls)
            //{
            //    if (item.Focused)
            //    { flg = 1; break;}
                
            //}
            //if (flg == 0)
            //{ this.Hide(); }
        }

        private void RCSHEET_Move(object sender, EventArgs e)
        {
            
        }

        private void RCSHEET_MouseMove(object sender, MouseEventArgs e)
        {
            if (Application.OpenForms["MeasurementSheet"] == null)
            { return; }
            int flg = 0;
        if (e.X - 2 < this.Location.X)
        { 
            flg = 1; }
        if (e.Y - 2 < this.Location.Y)
        { 
            flg = 1; }
        if (e.X+ 2 > this.Location.X+this.Width)
        { 
            flg = 1; }
        if (e.Y + 2 >this.Location.Y+this.Height)
        { 
            flg = 1; 
        }
        if (flg == 1)
        { this.Hide(); }
        }
    }
}
