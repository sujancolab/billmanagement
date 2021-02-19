using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SBGhadgev1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SBGhadge1.Login());
           //Application.Run(new Form4());
           Application.Run(new Main());
        }
    }
}
