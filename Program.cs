using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tourism_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string uid = "";
        public static string oid = "";
        public static string cid = "";
        public static SqlConnection con = new SqlConnection("server=LAPTOP-B9IRCOE6\\SQLEXPRESS;database=tms;Integrated Security=True");

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
