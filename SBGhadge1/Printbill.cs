using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
namespace SBGhadgev1.Images
{
    public partial class Printbill : Form
    {
        public Printbill()
        {
            InitializeComponent();
        }
        string _sourceFile;
        public void Print( )
        {
             _sourceFile = Application.StartupPath + "\\Images\\bill1.jpg" ;
             _sourceFile = _sourceFile.Replace("\\bin\\Debug","");
            PrintDocument pd = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            pd.PrinterSettings.PrinterName =ps.PrinterName;
            pd.DocumentName = "bill";
            string path = Application.StartupPath + "\\bill\\bill.jpg";
            path = path.Replace("\\bin\\Debug", "");
            using (Image img = Image.FromFile(path))
            {
                if (img.Width > img.Height)
                {
                    pd.DefaultPageSettings.Landscape = true;
                }
            }
            pd.PrintPage += PrintPage;
            //foreach (PaperSource ps in pd.PrinterSettings.PaperSources)
            //{
            //    if (ps.RawKind == tray)
            //    {
            //        pd.DefaultPageSettings.PaperSource = ps;
            //    }
            //}
            pd.Print();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            string path = Application.StartupPath + "\\bill\\bill.jpg";
            path = path.Replace("\\bin\\Debug", "");
            using (System.Drawing.Image img = Image.FromFile(path))
            {
                Point loc = new Point(0, 0);
                e.Graphics.DrawImage(img, loc);
            }
        }
        public static string billno, billdate, total, st, edc, hedc, net,to,kindatt,subject,refno,cst,Pan,kk,code,po,sac,disc,taxable;
        public Image img1;
        public string[] breaklines(string s, Font f, int pixwidthlimit,Graphics g)
        {
            string[] Final = new string[1];
            Final[0] = s;
            string[] words = s.Split();
            if (g.MeasureString(s, f).Width > pixwidthlimit)
            {
               Final = new string[0];
               string temp="";
               while (words.Length > 1)
               {
                   int x = 0;
                   temp = words[x];
                   while (g.MeasureString(temp, f).Width < pixwidthlimit)
                   {
                       x++;
                       if (x >= words.Length)
                       { break; }
                       temp += " " + words[x];
                   }
                   string[] temp1 = Final;
                   Final = new string[Final.Length + 1];
                   for (int i = 0; i < temp1.Length; i++)
                   {
                       Final[i] = temp1[i];
                   }
                   Final[temp1.Length] = temp;
                   s = s.Replace(temp, "");
                   words = s.Split();
               }
            }
            return Final;

        }
        private void Printbill_Load(object sender, EventArgs e)
        {
            _sourceFile = Application.StartupPath + "\\Images\\bill1.jpg";
            _sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
             img1 = System.Drawing.Image.FromFile(_sourceFile);
            Graphics g = Graphics.FromImage(img1);
            Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             Font Bf = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           
            //g.DrawString(DateTime.Now.ToShortDateString(), f, Brushes.Black, new Point(900, 220));
            g.DrawString(billno, f, Brushes.Black, new Point(140, 175));
            g.DrawString(po, f, Brushes.Black, new Point(140, 200));
            g.DrawString(code, f, Brushes.Black, new Point(140, 225));
            g.DrawString(sac, f, Brushes.Black, new Point(140, 300));

            g.DrawString(billdate.Replace("/", "."), f, Brushes.Black, new Point(460, 175));
            g.DrawString(refno, f, Brushes.Black, new Point(460, 200));


           // g.DrawString(refno, f, Brushes.Black, new Point(210, 271));
             
           // g.DrawString(cst, f, Brushes.Black, new Point(210, 367));
           // g.DrawString(Pan, f, Brushes.Black, new Point(210, 335));
            char[] sep = { '\n' };
            string[] to1 = to.Split(sep);
            int rowht = 30;

            for (int i = 0; i < to1.Length; i++)
            {
                g.DrawString(to1[i], f, Brushes.Black, new Point(40, 350 + (i * rowht)));

            }
            g.DrawString(kindatt, f, Brushes.Black, new Point(120, 440));
            int l = 110;
            g.DrawString("Bill For Fabrication & Fitting ", f, Brushes.Black, new Point(l, 465));
            l += Convert.ToInt32(g.MeasureString("Bill For Fabrication & Fitting ", f).Width);

            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawString(subject, f, Brushes.Black, new Point(l+10, 465));
            l += Convert.ToInt32(g.MeasureString(subject, f).Width);
            l += 20;
            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (l > 545)
            { g.DrawString("as Per Attachment", f, Brushes.Black, new Point(110, 490)); }
            else { g.DrawString("as Per Attachment", f, Brushes.Black, new Point(l, 465)); }



            g.DrawString(total, f, Brushes.Black, new Point(470, 515));
            g.DrawString(disc, f, Brushes.Black, new Point(470, 540));
            g.DrawString(taxable, f, Brushes.Black, new Point(470, 565));
            g.DrawString(st, f, Brushes.Black, new Point(470, 590));
            g.DrawString(edc, f, Brushes.Black, new Point(470, 615));
            g.DrawString(net, Bf, Brushes.Black, new Point(470, 640));
            
            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            amounInWord a = new amounInWord();
            string s = a.Toword(Convert.ToDouble(net));
            string[] s2 = breaklines(s, f, 400, g);

            for (int i = 0; i < s2.Length; i++)
            {
                g.DrawString(s2[i], f, Brushes.Black, new Point(270, 665 + (i * rowht)));
            }
           
           
            pictureBox1.Image = img1;
            string path = Application.StartupPath + "\\bill\\bill.jpg";
            path = path.Replace("\\bin\\Debug", "");
            img1.Save(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // PrinterSettings s = new PrinterSettings();
            Print();
        }
    }
}
