using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReflectionSortingThreads
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
            Application.Run(new VisualForm());
        }
    }
}
// Динамічна побудова функціональності аплікації засобами рефлексії
// Dynamic construction of an application's functionality by reflection tools