using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace GCam_Mi_A1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
           Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
           Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
    }
}
