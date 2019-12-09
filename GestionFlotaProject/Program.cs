using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFlotaProject.UI;
using WFrms = System.Windows.Forms;

namespace GestionFlotaProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WFrms.Application.Run( new MainWindowController().MainView);
        }
    }
}