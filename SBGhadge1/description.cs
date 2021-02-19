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

namespace SBGhadgev1
{
    public partial class description : Form
    {
        public description()
        {
            InitializeComponent();            
           
        }
        public Image createBlank()
        {
            DataSet ds1 = new DataSet();
            Bitmap b = new Bitmap(750, 1080);
            ds1 = majordal.getbillbymno(txtmno.Text);
            Image img1 = Image.FromHbitmap(b.GetHbitmap());
            Graphics g = null;
            g = Graphics.FromImage(img1);
            g.FillRectangle(Brushes.White, 0, 0, 750, 1080);
            Pen p = new Pen(Brushes.Black, 1);
            Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawRectangle(p,80, 150, 660, 900);
            int rowht = 32;
            for (int i = 1; i < 25; i++)
            {
                g.DrawLine(p, new Point(80, 150 + (i * 32)), new Point(740, 150 + (i * 32)));
            }
            g.DrawLine(p, new Point(180, 150), new Point(180, 278));
            g.DrawLine(p, new Point(80, 1025), new Point(740, 1025));
            g.DrawString("Plant No", f, Brushes.Black, new Point(85, 155));
            g.DrawString("Bill No", f, Brushes.Black, new Point(85, 187));   //<---ADD PLANT NUMBER HERE
           // g.DrawString("Bill Date ", f, Brushes.Black, new Point(85, 219));
            //g.DrawString("Bill Amount", f, Brushes.Black, new Point(85, 252));
            g.DrawString("Checked By", f, Brushes.Black, new Point(85, 1025));
            g.DrawString("S.B. Ghadge & Co.", f, Brushes.Black, new Point(575, 1025));
          /* g.DrawString("BILL Date. ", f, Brushes.Black, new Point(10, 30));
           g.DrawString(": " + ds1.Tables[0].Rows[0][1].ToString(), f, Brushes.Black, new Point(110, 30));
           g.DrawString("BILL Amount. ", f, Brushes.Black, new Point(10, 40));
           g.DrawString(": " + ds1.Tables[0].Rows[0][2].ToString(), f, Brushes.Black, new Point(110, 40));*/
           //string bdate = (ds1.Tables[0].Rows[0][1].ToString()).Replace("/", ".");
           //g.DrawString("BILL DATE ", f, Brushes.Black, new Point(10, 35));
          // g.DrawString(" : " + bdate, f, Brushes.Black, new Point(115, 35));
          // g.DrawString("BILL AMOUNT ", f, Brushes.Black, new Point(10, 50));
          // g.DrawString(" : " + ds1.Tables[0].Rows[0][2].ToString(), f, Brushes.Black, new Point(115, 50));
            //g.DrawLine(p, new Point(0, 65), new Point(750, 65));
            //f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("Description Of Work", f, Brushes.Black, new Point(300, 283));
           // f = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //img1.Save("c:\\Description.jpg", ImageFormat.Jpeg);
            return img1;
        }
        public string[] breaklines(string s, Font f, int pixwidthlimit, Graphics g)
        {
            string[] Final = new string[1];
            Final[0] = s;
            List<string> lst = new List<string>();

            string[] words = s.Split();
            if (g.MeasureString(s, f).Width > pixwidthlimit)
            {
                //Final = new string[0];
                string temp = "";
                while (words.Length > 1)
                {
                    int x = 0;
                    temp = words[x];
                    string temp2=temp;
                    while (g.MeasureString(temp, f).Width < pixwidthlimit)
                    {
                        temp2 = temp;
                        x++;
                        if (x >= words.Length)
                        { break; }
                        temp += " " + words[x];
                    }
                    //string[] temp1 = Final;
                    lst.Add(temp2);
                    //Final = new string[Final.Length + 1];
                    //for (int i = 0; i < temp1.Length; i++)
                    //{
                    //    Final[i] = temp1[i];
                    //}
                    //Final[temp1.Length] = temp;
                    s = s.Replace(temp2, "");
                    words = s.Split();
                }
                Final = lst.ToArray();
            }
            return Final;

        }
     
        private void btnlaod_Click(object sender, EventArgs e)
        {
            try{
            tabControl1.TabPages.Clear();
            DataSet ds = new DataSet();
            ds = majordal.getsubject(txtmno.Text);
            System.Drawing.Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            System.Drawing.Font bullf = new System.Drawing.Font("Times New Roman", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Image img1 = createBlank();
            Graphics g = null;
            g = Graphics.FromImage(img1);
            string path = Application.StartupPath + "\\Description\\";
            path = path.Replace("\\bin\\Debug", "");
            int K = 85;
            int rowht = 32;
            int rowstart = 312;
            int temp=0;
            string billno = txtmno.Text;
            string plantno="";
            string billdate = "";
            string billamount = "";
            int amtflag = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (temp % 19 == 0 &&i!=0 )
                { try 
	                    {
                           plantno = Convert.ToString(majordal.getPlantNo(txtmno.Text).Tables[0].Rows[0][0]);
                          DataSet b= majordal.getbill(txtmno.Text);
                          //billdate=Convert.ToString(b.Tables[0].Rows[0][1]).Replace("/",".");
                          //billamount = Convert.ToString(b.Tables[0].Rows[0][2]);
                          //billamount = amounInWord.mk_Currancy(billamount);
	                    }
	                    catch (Exception)
	                    {
                    		
		                    
	                    }
                g.DrawString(plantno, f, Brushes.Black, new PointF(200, 155));
                g.DrawString(billno, f, Brushes.Black, new PointF(200, 187));
                //g.DrawString(billdate, f, Brushes.Black, new PointF(200, 219));
                if (amtflag == 0)
                {
                   // g.DrawString(billamount, f, Brushes.Black, new PointF(200, 252));
                    amtflag = 1;
                    g.DrawString("Continue..", f, Brushes.Black, new PointF(350, 1030));
                }
                else
                {
                    g.DrawString("Continue..", f, Brushes.Black, new PointF(350, 1030));
                }
                    img1.Save(path + (tabControl1.TabPages.Count + 1) + ".jpg");
                    userSummary.s = path + (tabControl1.TabPages.Count + 1) + ".jpg";
                    userSummary u1 = new userSummary();
                    u1.pictureBox1.ImageLocation = path + (tabControl1.TabPages.Count + 1) + ".jpg";
                    u1.pictureBox1.Image = Image.FromFile(path + (tabControl1.TabPages.Count + 1) + ".jpg");
                    tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1));
                    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(u1);
                    img1 = createBlank();
                    g= Graphics.FromImage(img1);
                    temp=0;
                }
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    try
                    {
                        plantno =Convert.ToString( majordal.getPlantNo(txtmno.Text).Tables[0].Rows[0][0]);
                        DataSet b = majordal.getbill(txtmno.Text);
                       // billdate = Convert.ToString(b.Tables[0].Rows[0][1]).Replace("/", ".");
                        //billamount = Convert.ToString(b.Tables[0].Rows[0][2]);
                        //billamount = amounInWord.mk_Currancy(billamount);
                    }
                    catch (Exception)
                    {


                    }
                    g.DrawString(plantno, f, Brushes.Black, new PointF(200, 155));
                    g.DrawString(billno, f, Brushes.Black, new PointF(200, 187));
                    //g.DrawString(billdate, f, Brushes.Black, new PointF(200, 219));
                    if (amtflag == 0)
                    {
                        //g.DrawString(billamount, f, Brushes.Black, new PointF(200, 252));
                        amtflag = 1;
                    }
                    string[] Final = breaklines(Convert.ToString(ds.Tables[0].Rows[i][0]), f, 620, g);
                    g.DrawString("*", bullf, Brushes.Black, new PointF(75, rowstart - 3 + (temp * 32)));

                    for (int l = 0; l < Final.Length; l++)
                    {
                        g.DrawString(Final[l], f, Brushes.Black, new PointF(100, rowstart + (temp * 32)));
                        temp++;
                    }
                    img1.Save(path + (tabControl1.TabPages.Count + 1) + ".jpg");
                    userSummary.s = path + (tabControl1.TabPages.Count + 1) + ".jpg";
                    userSummary u1 = new userSummary();
                    u1.pictureBox1.ImageLocation = path + (tabControl1.TabPages.Count + 1) + ".jpg";
                    u1.pictureBox1.Image = Image.FromFile(path + (tabControl1.TabPages.Count + 1) + ".jpg");
                    tabControl1.TabPages.Add("Page" + (tabControl1.TabPages.Count + 1));
                    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(u1);
                }
                string[] Final1 = breaklines(Convert.ToString(ds.Tables[0].Rows[i][0]), f, 620, g);
                g.DrawString("*", bullf, Brushes.Black, new PointF(75, rowstart -3+ (temp * 32)));
                  
                for (int l = 0; l < Final1.Length; l++)
                {
                    g.DrawString(Final1[l],f,Brushes.Black,new PointF(100,rowstart+(temp*32)));
                    temp++;
                }
            }
            }
            catch (Exception ex)
            { }
        }

        private void description_Load(object sender, EventArgs e)
        {
            //tabControl1.Height = this.Height - 100;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {try{
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
                    Printing._sourceFile = u.pictureBox1.ImageLocation;
                    Printing.Print();
                }
            }
        }
        catch (Exception ex)
        { }
        }
    }
}
