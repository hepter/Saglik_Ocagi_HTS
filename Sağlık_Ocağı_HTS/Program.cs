using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nevron.Nov;
using Nevron.Nov.Barcode;
using Nevron.Nov.Diagram;
using Nevron.Nov.Text;
using Nevron.Nov.Windows.Forms;

namespace Sağlık_Ocağı_HTS
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          
            Application.Run(new MainForm());
        }
    }
}
