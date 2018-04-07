using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace GAsplund_s_WynnPack_Manager
{
    public class MainProgram
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ManagerForm form1 = new ManagerForm();
            Application.Run(form1);


            //Application.Run(new ManagerForm());

            //Check for already downloaded files

            //Compare hashes from list and downloaded files

            //
        }
    }
}
