using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using SimpleRecoil.Utilities;

namespace SimpleRecoil
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            MessageBox.Show("you are gay", "sex slave");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TriggerForm());
            MessageBox.Show("you are gay", "sex slave");
        }
    }
}