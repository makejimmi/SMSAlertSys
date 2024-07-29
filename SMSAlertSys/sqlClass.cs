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

        private string title = "";
        private int passed = 0;
        private DateTime date = DateTime.Now;
        private DateTime startTime = DateTime.Now;
        private DateTime endTime = DateTime.Now;
        private string delay = "";
        private string notes = "";
        private string email = "";
        private string phonenr = "";

        public sqlClass(string title, int passed, DateTime date, DateTime startTime, DateTime endTime, string delay, string notes, string email, string phonenr)
        {
            try
            {
                GlobalVars.connection = new MySqlConnection(SqlSetting());

                this.title = title;
                this.passed = passed;
                this.date = date;
                this.startTime = startTime;
                this.endTime = endTime;
                this.delay = delay;
                this.notes = notes;
                this.email = email;
                this.phonenr = phonenr;

            } catch {
                throw new ArgumentNullException("No Good");
            }
        }

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

        public void reconnect() 
        {
            try
            {
                GlobalVars.connection = new MySqlConnection(SqlSetting());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void addData(string title, int passed, DateTime date, DateTime startTime, DateTime endTime, string delay, string notes, string email, string phonenr)
        {
            try
            {
                this.title = title;
                this.passed = passed;
                this.date = date;
                this.startTime = startTime;
                this.endTime = endTime;
                this.delay = delay;
                this.notes = notes;
                this.email = email;
                this.phonenr = phonenr;

            }
            catch
            {
                throw new ArgumentNullException("No Good");
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
                string queryPt1 = "INSERT INTO tblreminder(Title, Passed, Date, StartTime, EndTime, Delay, Notes, Email, PhoneNr)";
                string queryPt2 = " VALUES (@Title, @Passed, @Date, @StartTime, @EndTime, @Delay, @Notes, @Email, @PhoneNr);";

                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = queryPt1 + queryPt2;
                comm.Parameters.AddWithValue("@Title", title);
                comm.Parameters.AddWithValue("@Passed", passed);
                comm.Parameters.AddWithValue("@Date", date);
                comm.Parameters.AddWithValue("@StartTime", startTime);
                comm.Parameters.AddWithValue("@EndTime", endTime);
                comm.Parameters.AddWithValue("@Delay", delay);
                comm.Parameters.AddWithValue("@Notes", notes);
                comm.Parameters.AddWithValue("@Email", email);
                comm.Parameters.AddWithValue("@PhoneNr", phonenr);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public BindingSource showDataTable() 
        {
            try
            {
                //this.dataTable = retrieveDbTbl();

                BindingSource bs = new BindingSource();
                bs.DataSource = GlobalVars.cache;

                DataGridViewClass dgvs = new DataGridViewClass();
                dgvs.initGrid();
                dgvs.Show();

                return bs;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }

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

        public void updateDbTbl() 
        {

            GlobalVars.connection.Open();
            //delete.ExecuteNonQuery();
            DataTable retrievedtbl = retrieveDbTbl();

            DataTable cache = GlobalVars.cache;
            int i = 0;
            foreach (DataRow row in GlobalVars.cache.AsEnumerable())
            {
                foreach ( DataRow row1 in retrievedtbl.AsEnumerable())
                {
                    if (row1["ReminderID"] == row["ReminderID"]) 
                    {
                        retrievedtbl.Rows.Remove(row1);
                        GlobalVars.cache.Rows.Remove(row);
                        break;
                    } 
                    else 
                    {
                        retrievedtbl.Rows.Remove(row1);
                        // INSTRUCTION TO DELETE IN THE REAL DB TOO
                        // comes heres ...
                        int id = (int) row1["ReminderID"];
                        var delete = new MySqlCommand("DELETE FROM tblreminder WHERE " + id, GlobalVars.connection);
                        delete.ExecuteNonQuery();
                    }
                }
            }

            GlobalVars.connection.Close();
        }
    }
}
