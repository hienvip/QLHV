using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSL
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
            //SQLConnector.SetConnectionInfo(@"(LocalDB)\MSSQLLocalDB", @"D:\Visual studio\C#\SofwareProject\PSL\QLHVdb.mdf");
            SQLConnector.SetConnectionInfo(@"DESKTOP-V2SC0F7\SQLEXPRESS", "QLHV");
            Application.Run(new FormLogin());
            //check login
            if (SQLConnector.is_login == true)
            {
                frmMenu frm = new frmMenu();
                frm.ShowDialog();
            }
        }
    }
}
