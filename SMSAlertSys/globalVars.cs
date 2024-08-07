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
using Microsoft.Extensions.Hosting;
using Quartz;

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

        // is adding a method that builds tasks really a good practice? I would have to give the user the option to
        // create reminders that on scheduled days should fire off and then in return delete itself, right?

        // or is it sufficient to just have one task which does all that the software needs. It is to compare the current date
        // with the scheduled alarms.
        // if the scheduled days is the same as the current date and time, then fire off the alarm and check the "passed" bool in sql
        // => it then needs to check the bool value of variable "passed", the current date and the scheduled day.
        //public static async Task JobBuilder()
        //{
        //    var builder = Host.CreateDefaultBuilder()
        //        .ConfigureServices((cxt, services) =>
        //        {
        //            services.AddQuartz(q =>
        //            {
        //                q.UseMicrosoftDependencyInjectionJobFactory();
        //            });
        //            services.AddQuartzHostedService(opt =>
        //            {
        //                opt.WaitForJobsToComplete = true;
        //            });
        //        }).Build();

            // will block until the last running job completes
        //    await builder.RunAsync();
        //}

        // bool value which is set via reading the xml file which should be generated and given
        // within the directory where the program runs
        public static bool JbCheck; 
    }
}
