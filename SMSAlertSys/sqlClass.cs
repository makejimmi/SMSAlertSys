using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SMSAlertSys
{
    class sqlClass
    {
        DataTable dataTable = null;

        // Change username, password and database according to one's needs
        // the database options can be ignored if you want to access all of them
        private string datasource = "localhost";
        private string port = "3306";
        private string username = "root";
        private string password = "";
        private string database = "smsalertsys";

        // fields of the sql table, ordered in no particular order
        private string title = "";
        private int passed = 0;
        private DateTime date = DateTime.Now;
        private DateTime startTime = DateTime.Now;
        private DateTime endTime = DateTime.Now;
        private string trigger = "";
        private string notes = "";
        private string email = "";
        private string phonenr = "";

        // this class' constructor which establishes a connection just by instantiation
        public sqlClass(string title, int passed, DateTime date, DateTime startTime, DateTime endTime, string notes, string email, string phonenr)
        {
            try
            {
                GlobalVars.connection = new MySqlConnection(SqlSetting());

                this.title = title;
                this.passed = passed;
                this.date = date;
                this.startTime = startTime;
                this.endTime = endTime;
                this.notes = notes;
                this.email = email;
                this.phonenr = phonenr;

            } catch {
                throw new ArgumentNullException();
            }
        }

        // constructor to only get a new connection with the information needed to connect to database
        public sqlClass() 
        {
            try
            {
                GlobalVars.connection = new MySqlConnection(SqlSetting());
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        // essentially the same thing as the sqlclass but i would not want to instantiate a new class just to reconnect
        public void reconnect() 
        {
            try
            {
                GlobalVars.connection = new MySqlConnection(SqlSetting());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // method that will be used in conjunction with the constructor that has no parameters, both sum up to be what constructor number 1 is
        public void addData(string title, int passed, DateTime date, DateTime startTime, DateTime endTime, string trigger,string notes, string email, string phonenr)
        {
            try
            {
                this.title = title;
                this.passed = passed;
                this.date = date;
                this.startTime = startTime;
                this.endTime = endTime;
                this.trigger = trigger;
                this.notes = notes;
                this.email = email;
                this.phonenr = phonenr;

            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        // declaration and initialization of necessary variables to establish connection to server that contains the to-be-accessed db
        public string SqlSetting()
        {
            //return "datasource=" + this.datasource + "; port=" + this.port +
            //        "; username=" + this.username + "; password=" + this.password + "; database=" + this.database + ";";
            return "datasource=" + this.datasource + ";port=" + this.port +
                    ";username=" + this.username + ";password=" + this.password + ";database=" + this.database + ";";
        }

        // insert query
        public void insert(MySqlConnection conn)
        {
            try
            {
                //string queryPt1 = "INSERT INTO tblreminder(Title, Passed, Date, StartTime, EndTime, Trigger, Notes, Email, PhoneNr)";
                //string queryPt2 = " VALUES (@Title, @Passed, @Date, @StartTime, @EndTime, @Trigger, @Notes, @Email, @PhoneNr);";

                //string queryPt1 = "INSERT INTO tblreminder(Title, Passed, Date, StartTime, EndTime, Notes, Email, PhoneNr)";
                //string queryPt2 = " VALUES (@Title, @Passed, @Date, @StartTime, @EndTime, @Notes, @Email, @PhoneNr);";

                string queryPt1 = "INSERT INTO tblreminder(Title, Passed, Date, StartTime, EndTime, TriggerInfo, Notes, Email, PhoneNr)";
                string queryPt2 = " VALUES (@Title, @Passed, @Date, @StartTime, @EndTime, @TriggerInfo, @Notes, @Email, @PhoneNr);";

                // INSERT INTO tblreminder(Title, Passed, Date, StartTime, EndTime, Trigger, Notes, Email, PhoneNr) VALUES (@Title, @Passed, @Date, @StartTime, @EndTime, @Trigger, @Notes, @Email, @PhoneNr);

                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryPt1 + queryPt2;
                comm.Parameters.AddWithValue("@Title", this.title);
                comm.Parameters.AddWithValue("@Passed", this.passed);
                comm.Parameters.AddWithValue("@Date", this.date);
                comm.Parameters.AddWithValue("@StartTime", this.startTime);
                comm.Parameters.AddWithValue("@EndTime", this.endTime);
                comm.Parameters.AddWithValue("@TriggerInfo", this.trigger);
                comm.Parameters.AddWithValue("@Notes", this.notes);
                comm.Parameters.AddWithValue("@Email", this.email);
                comm.Parameters.AddWithValue("@PhoneNr", this.phonenr);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // method used to bind the global variable "cache" to the datagridview which essentially means that the datagridview mirrors cache.
        // Every operation happening to the datagridview also happens to cache.
        public void showDataTable() 
        {
            try
            {
                // instantiates and initializes datagridview
                DataGridViewClass dgvs = new DataGridViewClass();
                
                // shows what has been initialized just one line of code earlier
                dgvs.Show();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Method used to retrieve the database table.
        // Returns the current datatable that can be found in "http://localhost/phpmyadmin/index.php?route=/sql&db=smsalertsys&table=tblreminder&pos=0" as well.
        public DataTable retrieveDbTbl() 
        {
            try
            {
                var query = new MySqlCommand("SELECT * FROM tblreminder", GlobalVars.connection);
                MySqlDataAdapter ad = new MySqlDataAdapter();
                ad.SelectCommand = query;
                this.dataTable = new DataTable();
                ad.Fill(dataTable);
                return this.dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }

        // Updates the database table according to the form that the cache, with that then also datagridview, has taken.
        public void updateDbTbl() 
        {
            GlobalVars.connection.Open();
            string col = "ReminderID";
            DataTable actualDt = retrieveDbTbl(); // the current database table is being retrieved
            bool check = false;

            // Loop to check whether the modified cache even has rows. If that fails to be true then all the rows in the table in the database get removed.
            foreach (DataRow row in GlobalVars.cache.AsEnumerable()) 
            {
                check = true;
                break;
            }

            // If the previous loop succeeds in being true then:
            if (check)
            {
                // Loop that gets all the removed values' index. The index values are all saved while the rows were in the process of being deleted.
                // With the indices one must remove the not-anymore-existing values from the current db table.
                foreach (int idx in GlobalVars.idxOfRemovedRows) 
                {
                    var row = actualDt.Rows[idx][0];
                    var delete = new MySqlCommand("DELETE FROM tblreminder WHERE " + col + "=" + row , GlobalVars.connection);
                    delete.ExecuteNonQuery();
                }
            }
            else // all rows in the current table get removed
            {
                var deleteAll = new MySqlCommand("DELETE FROM tblreminder;", GlobalVars.connection);
                deleteAll.ExecuteNonQuery();
            }
            GlobalVars.idxOfRemovedRows.Clear(); // index values are being cleared due to all
            GlobalVars.connection.Close();
            MessageBox.Show("Changes have been saved and uploaded!");
        }
    }
}
