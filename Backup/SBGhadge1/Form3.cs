using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadgev1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Image create_Blank(Image img1)
        {
            Graphics g = null;

            g = Graphics.FromImage(img1);
            g.FillRectangle(Brushes.White, 0, 0, 750, 1080);
            Pen p = new Pen(Brushes.Black, 2);
            //g.DrawRectangle(p, new Rectangle(10, 10, 1180, 1580));
           // g.DrawString("S.B.Ghadge & Co.", new System.Drawing.Font("Algerian", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.DodgerBlue, new Point(260, 20));
            Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            string path = Application.StartupPath.Replace("\\bin\\Debug", "") + "\\Images\\logo1.JPG";
            //g.DrawImage(Image.FromFile(path), new Point(150, 10));
            g.DrawString("Plant No :", new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)(( System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new Point(250,165));
            g.DrawString("Page No :", f, Brushes.Black, new Point(60, 165));
            g.DrawString("Date :", f, Brushes.Black, new Point(580, 165));
            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Pen p1 = new Pen(Brushes.Gray, 1);
            g.DrawRectangle(p1, new Rectangle(60, 150, 680, 910));
            int k = 200;
            for (int i = 0; i < 31; i++)
            {
                g.DrawLine(p1, new Point(60, k), new Point(740, k));
                //g.DrawString((i + 1).ToString(), f, Brushes.Black, new Point(70, k));
                k += 26;
                
            }
           // g.DrawString("Subject:", f, Brushes.Black, new Point(30, 185));
            g.DrawLine(p1, new Point(120, 200), new Point(120, 980));
            g.DrawString("Checked By :", f, Brushes.Black, new Point(120, 1040));
            //g.DrawString("For", f, Brushes.Black, new Point(600, 920));
            g.DrawString("S.B. Ghadge & Co.", f, Brushes.Black, new Point(550, 1040));
           // g.DrawLine(p1, new Point(60, 980), new Point(740, 980));
            img1.Save("c:\\major1.jpg", ImageFormat.Jpeg);
            return img1;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(750, 1080);
            Image img1 = Image.FromHbitmap(b.GetHbitmap());
            img1 = create_Blank(img1);
        }
    }
}
