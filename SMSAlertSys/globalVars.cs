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
    static class GlobalVars
    {
        public static DataTable cache = null;
        public static sqlClass sc = null;
        public static MySqlConnection connection = null;
    }
}
