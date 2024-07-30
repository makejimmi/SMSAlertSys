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
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;

namespace SMSAlertSys
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // new instance of sqlClass which establishes new connection as well -> refer to code in "sqlClass" - method SqlSetting()
                GlobalVars.sc = new sqlClass();

                // diagram step 1, "Datenabfrage, SELECT * FROM ..."

                GlobalVars.connection.Open();
                //Datenabfrage und das in einem Datatable speichern.

                GlobalVars.cache = GlobalVars.sc.retrieveDbTbl();
                GlobalVars.connection.Close();

                // Kalendarübersicht anzeigen und die Datentabelle bereithalten.
                Form calendarForm = new datePicker();
                Application.Run(calendarForm);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please restart or check if your connection to your SQL Server is available.\n" + ex.Message);
            }

            // Zwei Optionen nun "All Events" oder "New Event"
            // ...


            // so it looks like I do not really need a method to get the text of textBox1 & textBox2
            // I only need an eventListener which is the button1_Click
        }
        
    }
}
