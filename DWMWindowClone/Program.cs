using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace DWMWindowClone
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
            if (!Win32.DwmIsCompositionEnabled())
            {
                MessageBox.Show("Desktop Composition must be enabled to duplicate windows!");
                Application.Exit();
            }
            Application.Run(new CloneWindow());
        }
    }
}
