using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace NorthwestInventoryManager
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
            bool newCompany = true;

            String server = "";
            String dbase = "";
            String user = "";

            try
            {
                using (StreamReader sr = new StreamReader("config.ini"))
                {
                    server = sr.ReadLine();
                    dbase = sr.ReadLine();
                    user = sr.ReadLine();
                    if(server != null)
                        newCompany = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The file could not be read:");
            }

            if(newCompany)
                Application.Run(new fmCompanyCreation());
            else
                Application.Run(new fmLogin(server, dbase, user));

        }
    }
}
