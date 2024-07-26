using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSAlertSys;
using System.Data.SqlClient;
using MySql.Data.Types;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApp_HelloWorld
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 

        // This is a simple and first test for checking out the built-in GIT functionalities in VS

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form calendarAlertSystem = new datePicker();
            Application.Run(calendarAlertSystem);

            // so it looks like I do not really need a method to get the text of textBox1 & textBox2
            // I only need an eventListener which is the button1_Click
        }
    }
}
