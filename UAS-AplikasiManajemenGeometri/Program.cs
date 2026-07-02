using System;
using System.Windows.Forms;

namespace Project_UAS_Manajemen_Bangun_Geometri
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); 
        }
    }
}