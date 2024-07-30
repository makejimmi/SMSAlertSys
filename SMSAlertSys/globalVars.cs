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
    // I am not entirely sure if this should be common practice especialy because all of these are public. Although the "internal" keyword should make up for it in a small way.
    internal static class GlobalVars
    {
        // Cache is the "Zwischenspeicher" or rather the first instance of the download actual database table 
        // It will be and is being used as a temporary placeholder as well.
        public static DataTable cache = null; 
        public static sqlClass sc = null; // Class instance as to be able to access all the methods needed for connection, database table retrieval and queries.
        public static MySqlConnection connection = null;  // Instance of MySqlConnection which will be opened, reopened and always closed in response to it opening.

        public static List<int> idxOfRemovedRows = new List<int>(); // Keeps track of all the indices of the rows that are deleted manually by the user.
    }
}
