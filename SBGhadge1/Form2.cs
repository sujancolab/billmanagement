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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Image create_Blank(Image img1)
        {
            Graphics g = null;

            g = Graphics.FromImage(img1);
            g.FillRectangle(Brushes.White, 0, 0,750, 1080);
            Pen p = new Pen(Brushes.Gray, 1);
            string path = Application.StartupPath.Replace("\\bin\\Debug", "") + "\\Images\\logo1.JPG";
         
            //g.DrawImage(Image.FromFile(path), new Point(150, 50));
            g.DrawRectangle(p, new Rectangle(5, 150, 740, 920));
           // g.DrawString("S.B.Ghadge & Co.",  new System.Drawing.Font("Algerian", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),Brushes.DodgerBlue,new Point(175,45));
            System.Drawing.Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //g.DrawString("Address: Thaur Mansion, Bldg. No.2, Room No.3, Mazgaon Road,", f, Brushes.Black, new System.Drawing.Point(100, 100));
           // g.DrawString("Mumbai. Phone No. 9960400803,9850595263", f, Brushes.Black, new System.Drawing.Point(200, 125));
          
             f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            /*.Underline | System.Drawing.FontStyle.Bold*/
            g.DrawString("Plant No :", new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new Point(250, 165));
            g.DrawString("Page No :", f, Brushes.Black, new Point(60, 165));
            //g.DrawString("Date :", f, Brushes.Black, new Point(580, 165));
            f = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            p = new Pen(Brushes.Gray, 1);
            g.DrawLine(p, new Point(6, 200), new Point(744, 200));

            g.DrawString("SR", f, Brushes.Black, new Point(10, 205));
            g.DrawString("NO.", f, Brushes.Black, new Point(10, 225));
            g.DrawString("Page", f, Brushes.Black, new Point(60, 205));
            g.DrawString("No.", f, Brushes.Black, new Point(60, 225));
            g.DrawString("15 NB", f, Brushes.Black, new Point(120, 205));
            g.DrawString("1/2\"", f, Brushes.Black, new Point(120, 225));
            g.DrawString("20 NB", f, Brushes.Black, new Point(180, 205));
            g.DrawString("3/4\"", f, Brushes.Black, new Point(180, 225));
            g.DrawString("25 NB", f, Brushes.Black, new Point(245, 205));
            g.DrawString("1\"", f, Brushes.Black, new Point(255, 225));
            g.DrawString("40 NB", f, Brushes.Black, new Point(310, 205));
            g.DrawString("1 1/2\"", f, Brushes.Black, new Point(312, 225));
            g.DrawString("50 NB", f, Brushes.Black, new Point(372, 205));
            g.DrawString("2\"", f, Brushes.Black, new Point(375, 225));
            g.DrawString("65 NB", f, Brushes.Black, new Point(435, 205));
            g.DrawString("2 1/2\"", f, Brushes.Black, new Point(442, 225));
            g.DrawString("80 NB", f, Brushes.Black, new Point(500, 205));
            g.DrawString("3\"", f, Brushes.Black, new Point(510, 225));
            g.DrawString("100 NB", f, Brushes.Black, new Point(555, 205));
            g.DrawString("4\"", f, Brushes.Black, new Point(565, 225));
            g.DrawString("150 NB", f, Brushes.Black, new Point(615, 205));
            g.DrawString("6\"", f, Brushes.Black, new Point(625, 225));
            g.DrawString("200 NB", f, Brushes.Black, new Point(680, 205));
            g.DrawString("8\"", f, Brushes.Black, new Point(692, 225));

            int k = 250;
            for (int i = 0; i < 24; i++)
            {
                g.DrawLine(p, new Point(6, k), new Point(744, k));
                k += 32;
            }
            k = 110;
            g.DrawLine(p, new Point(50, 200), new Point(50, 986));
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p, new Point(k, 200), new Point(k, 986));
                k += 63;
            }
            //Brush b = Color.FromArgb(224, 224, 224);
            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("Checked By", f, Brushes.Black, new Point(110, 1050));
            g.DrawString("For S.B. Ghadge & Co.", f, Brushes.Black, new Point(510, 1050));
            //g.DrawLine(p, new Point(5, 975), new Point(745, 975));
            img1.Save("c:\\sum.jpg", ImageFormat.Jpeg);
            return img1;
        }
        public Image create_Blankamt(Image img1)
        {
            Graphics g = null;
            g = Graphics.FromImage(img1);
            g.FillRectangle(Brushes.White, 0, 0, 750, 1080);
            Pen p = new Pen(Brushes.Black, 1);
            string path = Application.StartupPath.Replace("\\bin\\Debug", "") + "\\Images\\logo1.JPG";

           // g.DrawImage(Image.FromFile(path), new Point(110, 10));
           // g.Save();
            g.DrawRectangle(p, new System.Drawing.Rectangle(5, 155, 740, 920));
            //g.DrawString("S.B.Ghadge & Co.", new System.Drawing.Font("Algerian", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.DodgerBlue, new Point(175, 45));
            System.Drawing.Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //g.DrawString("Address: Thaur Mansion, Bldg. No.2, Room No.3, Mazgaon Road,", f, Brushes.Black, new System.Drawing.Point(100, 100));
           // g.DrawString("Mumbai. Phone No. 9960400803,9850595263", f, Brushes.Black, new System.Drawing.Point(200, 125));
            //g.DrawLine(p, new System.Drawing.Point(400, 175), new System.Drawing.Point(400, 150));
            g.DrawLine(p, new System.Drawing.Point(400, 275), new System.Drawing.Point(400, 275));
            g.DrawLine(p, new System.Drawing.Point(400, 182), new System.Drawing.Point(745, 182));
            g.DrawLine(p, new System.Drawing.Point(400, 214), new System.Drawing.Point(745, 214));
            g.DrawLine(p, new System.Drawing.Point(400, 246), new System.Drawing.Point(745, 246));
            f = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("PAGE NO", f, Brushes.Black, new System.Drawing.Point(420, 155));
            g.DrawString("BILL NO", f, Brushes.Black, new System.Drawing.Point(420, 187));
            //g.DrawString("BILL Date", f, Brushes.Black, new System.Drawing.Point(420, 219));
            g.DrawString("ARC NO", f, Brushes.Black, new System.Drawing.Point(420, 250));
            g.DrawString("SR", f, Brushes.Black, new System.Drawing.Point(10, 275));
            g.DrawString("NO.", f, Brushes.Black, new System.Drawing.Point(10, 305));
            g.DrawString("ITEM", f, Brushes.Black, new System.Drawing.Point(55, 275));
            g.DrawString("CODE", f, Brushes.Black, new System.Drawing.Point(55, 305));
            g.DrawString("DESCRIPTION", f, Brushes.Black, new System.Drawing.Point(250, 280));
            g.DrawString("QTY", f, Brushes.Black, new System.Drawing.Point(465, 280));
            g.DrawString("UNIT", f, Brushes.Black, new System.Drawing.Point(550, 280));
            g.DrawString("UNIT", f, Brushes.Black, new System.Drawing.Point(605, 275));
            g.DrawString("RATE", f, Brushes.Black, new System.Drawing.Point(605, 305));
            g.DrawString("AMOUNT", f, Brushes.Black, new System.Drawing.Point(665, 280));
            //g.DrawString("REMARK", f, Brushes.Black, new System.Drawing.Point(680, 155));
            //g.DrawString("AMOUNT", f, Brushes.Black, new System.Drawing.Point(680, 175));
            //g.DrawLine(p, new System.Drawing.Point(5, 75), new System.Drawing.Point(745, 75));
            //g.DrawLine(p, new System.Drawing.Point(5, 150), new System.Drawing.Point(745, 150));
            g.DrawLine(p, new System.Drawing.Point(400, 155), new System.Drawing.Point(400, 275));
            g.DrawLine(p, new System.Drawing.Point(5, 275), new System.Drawing.Point(745, 275));
            int k = 325;
            for (int i = 0; i < 22; i++)
            {
                g.DrawLine(p, new System.Drawing.Point(5, k), new System.Drawing.Point(745, k));
                k += 32;
            }
            k = 0;
            g.DrawLine(p, new System.Drawing.Point(50, 275), new System.Drawing.Point(50, 965));
            g.DrawLine(p, new System.Drawing.Point(135, 275), new System.Drawing.Point(135, 965));
            //g.DrawLine(p, new System.Drawing.Point(400, 150), new System.Drawing.Point(400, 1102));
            g.DrawLine(p, new System.Drawing.Point(450, 275), new System.Drawing.Point(450, 998));
            //g.DrawLine(p, new System.Drawing.Point(500, 275), new System.Drawing.Point(500, 968));
            g.DrawLine(p, new System.Drawing.Point(530, 155), new System.Drawing.Point(530, 965));

            g.DrawLine(p, new System.Drawing.Point(600, 275), new System.Drawing.Point(600, 998));
            g.DrawLine(p, new System.Drawing.Point(660, 275), new System.Drawing.Point(660, 965));
            g.DrawString("TOTAL", f, Brushes.Black, new System.Drawing.Point(510, 970));
            //g.DrawLine(p, new System.Drawing.Point(450, 1000), new System.Drawing.Point(745, 1000));
            f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("Checked By", f, Brushes.Black, new Point(110, 1050));
            g.DrawString("For S.B. Ghadge & Co.", f, Brushes.Black, new Point(510, 1050));
            //g.DrawLine(p, new System.Drawing.Point(5, 1055), new System.Drawing.Point(745, 1055));
            img1.Save("c:\\xyz1.jpg", ImageFormat.Jpeg);
            return img1;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(750, 1080);
            Image img1 = Image.FromHbitmap(b.GetHbitmap());
            img1 = create_Blank(img1);
            b = new Bitmap(750, 1080);//1250
            img1 = Image.FromHbitmap(b.GetHbitmap());
            img1 = create_Blankamt(img1);
        }
    }
}
