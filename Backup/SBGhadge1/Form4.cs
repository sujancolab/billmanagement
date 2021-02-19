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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Image create_Blank(Image img1)
        {
            Graphics g = null;
            int left = 30, right = 730;
            g = Graphics.FromImage(img1);
            g.FillRectangle(Brushes.White, 0, 0, 750, 1000);
            Pen p = new Pen(Brushes.DodgerBlue, 2);
            // g.DrawString("S.B.Ghadge & Co.", new System.Drawing.Font("Algerian", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.DodgerBlue, new Point(260, 20));
            Font f = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font Bf = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            string path = Application.StartupPath.Replace("\\bin\\Debug", "") + "\\Images\\logo1.JPG";
            // g.DrawImage(Image.FromFile(path), new Point(150, 10));
            //g.DrawString("Add.: Thaur Mansion Bldg. No.2, Room No.3, Mazagaon Road, Mumbai-400 009", new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)(( System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.DodgerBlue, new Point(110, 80));
            // g.DrawString("Mobile No.:09960400803, 09850595263, Email-Id: ghadgeengg@yahoo.com", new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.DodgerBlue, new Point(130, 100));
            // g.DrawLine(p, new Point(20, 150), new Point(730, 150));
            // g.DrawString("Ref No :", f, Brushes.Black, new Point(50, 200));
           // g.DrawString("Date :", f, Brushes.Black, new Point(520, 140));
            g.DrawString("TAX INVOICE", new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new Point(320, 140));
            Font f1 = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Pen p1 = new Pen(Brushes.Gray, 1);
            g.DrawRectangle(p1, new Rectangle(left, 170, right-30, 900));
            int k = 195;
            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(p1, new Point(left, k), new Point(right, k));
                k += 25;
            }
            g.DrawLine(p1, new Point(310, 170), new Point(310, 320));
            g.DrawLine(p1, new Point(130, 170), new Point(130, 320));
            g.DrawLine(p1, new Point(450, 170), new Point(450, 320));

            g.DrawLine(p1, new Point(left, 435), new Point(right, 435));
            g.DrawLine(p1, new Point(left, 460), new Point(right, 460));
            //g.DrawLine(p1, new Point(left, 580), new Point(right, 580));

             k = 510;
            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(p1, new Point(left, k), new Point(right, k));
                k += 25;
                //k += 32;
            }
            g.DrawLine(p1, new Point(450, 510), new Point(450, 660));//partition
            g.DrawLine(p1, new Point(left, 780), new Point(right, 780));
            g.DrawLine(p1, new Point(left, 940), new Point(right, 940));
            //g.DrawLine(p1, new Point(right, 170), new Point(right, 790));

            //k = 630;
            //for (int i = 0; i < 6; i++)
            //{
            //    g.DrawLine(p1, new Point(left, k), new Point(right, k));
            //    k += 32;
            //}
            //g.DrawLine(p1, new Point(150, 170), new Point(150, 394));
            //g.DrawLine(p1, new Point(600, 630), new Point(600, 790));
            //g.DrawLine(p1, new Point(left, 550), new Point(right, 550));
            //g.DrawLine(p1, new Point(left, 580), new Point(right, 580));
            //g.DrawLine(p1, new Point(left, 1070), new Point(right, 1070));
            //g.DrawLine(p1, new Point(left, 790), new Point(left, 1070));
            //g.DrawLine(p1, new Point(right, 790), new Point(right, 1070));
            //g.DrawLine(p1, new Point(left, 880), new Point(right, 880));
           
            //COLUMN1
            g.DrawString("Invoice No", f, Brushes.Black, new Point(40, 175));
            g.DrawString("P.O. No", f, Brushes.Black, new Point(40, 200));
            g.DrawString("Code", f, Brushes.Black, new Point(40, 225));
            g.DrawString("GST NO", f, Brushes.Black, new Point(40, 250));
            g.DrawString("State", f, Brushes.Black, new Point(40, 275));
            g.DrawString("SAC Code", f, Brushes.Black, new Point(40, 300));
            //COLUMN2
            g.DrawString("27ADXPG6342B2ZG", f, Brushes.Black, new Point(140, 250));
            g.DrawString("Maharashtra", f, Brushes.Black, new Point(140, 275));
            //COLUMN3
            g.DrawString("Invoice Date", f, Brushes.Black, new Point(320, 175));
            g.DrawString("ARC No", f, Brushes.Black, new Point(320, 200));
            g.DrawString("Reverse charge", f, Brushes.Black, new Point(320, 225));
            g.DrawString("Pan No", f, Brushes.Black, new Point(320, 250));
            g.DrawString("State Code", f, Brushes.Black, new Point(320, 275));
            g.DrawString("Place of Service", f, Brushes.Black, new Point(320, 300));
            //COLUMN4
            g.DrawString("NO", f, Brushes.Black, new Point(460, 225 ));
            g.DrawString("ADXPG6342B", f, Brushes.Black, new Point(460, 250));
            g.DrawString("27", f, Brushes.Black, new Point(460, 275));
            g.DrawString("Maharashtra", f, Brushes.Black, new Point(460, 300));

            //para2
           
           g.DrawString("Details Of Reciever (Billed To )", f, Brushes.Black, new Point(40, 325));
            //g.DrawString("M/s. Sun Pharmaceutical", f, Brushes.Black, new Point(40, 402));
            //g.DrawString("Details Of Reciever (Billed To )", f, Brushes.Black, new Point(40, 434));
            //g.DrawString("Details Of Reciever (Billed To )", f, Brushes.Black, new Point(40, 466));


            ////g.DrawString("", f, Brushes.Black, new Point(390, 605));
            ////Service Tax @ 14% (Rs.)
            ////g.DrawString("", f, Brushes.Black, new Point(395, 635));
            ////Education Cess @ 2% (Rs.)
            //g.DrawString("Total Amount Of Bill (Rs.)", f, Brushes.Black, new Point(390, 635));
            ////Secondary & Higher Secondary Cess @ 1% (Rs.)
            //g.DrawString("Service Tax @ 14% (Rs.)", f, Brushes.Black, new Point(395, 672));
            //g.DrawString("Swach Bharat CESS @ 0.5% (Rs.)", f, Brushes.Black, new Point(330, 704));
            //g.DrawString("Krushi Kalyan CESS @ 0.5% (Rs.)", f, Brushes.Black, new Point(330, 736));
            //g.DrawString("Net Amount (Rs.)", Bf, Brushes.Black, new Point(445, 768));
            g.DrawString("Kind Attn:", f, Brushes.Black, new Point(40, 440));
            g.DrawString("Subject:", f, Brushes.Black, new Point(40, 465));
            
            g.DrawString("Basic Amount ", f, Brushes.Black, new Point(280, 515));

            g.DrawString("Discount @ 3 % ", f, Brushes.Black, new Point(280, 540));
            
            g.DrawString("Total Taxable Value ", f, Brushes.Black, new Point(280, 565));
            g.DrawString("Taxes-IN: Central GST @ 9.00 % ", f, Brushes.Black, new Point(180, 590));
            g.DrawString("Taxes-IN: State    GST @ 9.00 % ", f, Brushes.Black, new Point(180, 615));
            g.DrawString("Total Invoice Value ", f, Brushes.Black, new Point(280, 640));

            g.DrawString("Total Invoice Value In Words :", f, Brushes.Black, new Point(40, 665));
            
            
            g.DrawString("Bank Details :", f, Brushes.Black, new Point(40, 780));
            g.DrawString("Account Holder Name :  S.B. GHADGE  AND  COMPANY", f, Brushes.Black, new Point(40, 810));
            g.DrawString("Bank Name & Branch  :  SARASWAT CO-OPERATIVE BANK LTD", f, Brushes.Black, new Point(40, 840));
            g.DrawString(" M.I.D.C. Ahmednagar", f, Brushes.Black, new Point(223, 865));
            
            g.DrawString("Current Account No    :  400100100000254", f, Brushes.Black, new Point(40, 890));
            g.DrawString("I.F.S.C. CODE           :  SRCB0000400", f, Brushes.Black, new Point(40, 915));

            g.DrawString("For", f, Brushes.Black, new Point(490, 950));
            g.DrawString("S.B. GHADGE & CO.", f1, Brushes.Black, new Point(530, 950));
            g.DrawString("Propritor", f, Brushes.Black, new Point(580, 1035));
            

            img1.Save("c:\\bill1.jpg", ImageFormat.Jpeg);
            return img1;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(1200, 1600);
            b = new Bitmap(750, 1080);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.White, 0, 0, 750, 1080);
               //b.Save("c:\\Bill.jpg", ImageFormat.Jpeg);
            Image img1 = Image.FromHbitmap(b.GetHbitmap());
            img1 = create_Blank(img1);
        }
    }
}
