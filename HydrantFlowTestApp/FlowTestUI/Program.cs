using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowTestLibrary;

namespace FlowTestUI
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
            FlowTestLibrary.GlobalConfig.InitializeConnections(DatabaseType.Development);
            Application.Run(new Dashboard());
        }
    }
}
