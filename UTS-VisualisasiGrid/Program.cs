using System;
using System.Windows.Forms;

namespace project_UTS_Visualisasi_grid_and_pixel_editor
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

            // Di sini kita panggil Form1 dengan namespace yang sudah sinkron
            Application.Run(new Form1());
        }
    }
}