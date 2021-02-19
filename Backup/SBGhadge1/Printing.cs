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
namespace SBGhadgev1
{
    class Printing
    {
        public static string _sourceFile;
        public static PrintDocument pds;
        public static void Print()
        {
            //_sourceFile = Application.StartupPath + "\\Images\\bill1.jpg";
            //_sourceFile = _sourceFile.Replace("\\bin\\Debug", "");
            PrintDocument pd = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            

           // pd.PrinterSettings.PrinterName = ps.PrinterName;
        
           // pd.DocumentName = "bill";
           // string path = Application.StartupPath + "\\bill\\bill.jpg";
            //path = path.Replace("\\bin\\Debug", "");
            //using (Image img = Image.FromFile(_sourceFile))
            //{
            //    if (img.Width > img.Height)
            //    {
            //        pd.DefaultPageSettings.Landscape = true;
            //    }
                
            //}
            pd.PrintPage += PrintPage;
           
          
            pd.PrinterSettings = pds.PrinterSettings;
            pd.Print();
        }
        public static void PrintPage(object o, PrintPageEventArgs e)
        {
           
            using (System.Drawing.Image img = Image.FromFile(_sourceFile))
            {
                Point loc = new Point(0, 0);
                e.Graphics.DrawImage(img, loc);
            }
        }
    }
}
