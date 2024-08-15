using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


// KALENDARÜBERSICHT

namespace SMSAlertSys
{
    // Define a class named datePicker that inherits from Form
    class datePicker : Form
    {
        #region Vom Windows Form-Designer generierter Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, False.</param>
        protected override void Dispose(bool disposing)
        {
            // Dispose of components if disposing is true
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        //-------------------------------------------------------
        // Declare a timePicker instance
        timePicker tP = null;

        private Button showAllEvents;
        private Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        private int secondsCounter = 0;


        // Constructor for the datePicker class
        public datePicker()
        {
            try
            {
                InitializeComponent(); // Initialize UI components
                //this.timer1.Interval = 1000;
                //this.timer1.Enabled = true;
                boldUpDates(); // bolds the font of the days with calendar entries
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        // Event handler for date selection in monthCalendar1
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                // Instantiate timePicker and show selected day
                this.tP = new timePicker();
                tP.showSelectedDay(e.Start);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Required method for designer support.
        /// The contents of this method should not be changed with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.runBtn = new System.Windows.Forms.Button();
            this.showAllEvents = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 2);
            this.monthCalendar1.Location = new System.Drawing.Point(0, -1);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.Blue;
            this.monthCalendar1.TitleForeColor = System.Drawing.Color.Yellow;
            this.monthCalendar1.TrailingForeColor = System.Drawing.Color.Red;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(706, 322);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(92, 21);
            this.runBtn.TabIndex = 1;
            this.runBtn.Text = "Just Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // showAllEvents
            // 
            this.showAllEvents.Location = new System.Drawing.Point(625, 322);
            this.showAllEvents.Name = "showAllEvents";
            this.showAllEvents.Size = new System.Drawing.Size(75, 23);
            this.showAllEvents.TabIndex = 2;
            this.showAllEvents.Text = "All Events";
            this.showAllEvents.UseVisualStyleBackColor = true;
            this.showAllEvents.Click += new System.EventHandler(this.showAllEvents_Click);
            // 
            // timer1
            // 
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // datePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(810, 352);
            this.Controls.Add(this.showAllEvents);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "datePicker";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        // Declaration of UI elements
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button runBtn;

        // Event handler for runBtn click
        private void runBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Event handler for showAllEvents click
        private void showAllEvents_Click(object sender, EventArgs e)
        {
            try
            {
                //GlobalVars.sc.retrieveDbTbl(); // Read data from database
                GlobalVars.sc.showDataTable(); // show data in a grid view
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error"); // Show error message in case of exception
            }
        }

        // Method to make fonts bold
        private void boldUpDates()
        {
            try
            {
                foreach (DataRow row in GlobalVars.cache.Rows)
                {
                    this.monthCalendar1.AddBoldedDate(row.Field<DateTime>("Date"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Show error message in case of exception
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    Console.WriteLine(secondsCounter + " second/s has/have elapsed");
        //    this.secondsCounter++;
        //    if (secondsCounter > 10)
        //    {
        //        secondsCounter = 0;
        //        this.timer1.Stop();
        //        this.timer1.Dispose();
        //        this.Close();
        //    }
        //}

        // it seems as though the ticking timer is bad practice which is why I will use a task in conjunction
        // with a task scheduler.
        //
        // The task should be able to open the software or if it is already up and running then
        // it ought to read the data from the sql server and compare the value of the dates on which alarms should go off
        // to the current date.
        //
        // If there is an overlap of dates then -> send email/sms.
        // Otherwise -> close the app and wait for defined amount of time.
        //
        // The frequency of the task should be 6 hours with no good reason. "Daumen mal pi"
        //
        // This step should be doable by using the "Task Class" with the "TaskScheduler Class":
        // (https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-tasks-task)

        // Planänderung: Quartz-Scheduler wird benutzt, um die Aufgaben zu geplanten Zeiten durchzuführen.
        // Dabei bleibt die Aufgabe gleich und es wird bloß eine einfache SQL Anfrage gemacht und diese Tabelle soll dann auch
        // lokal gespeichert werden, damit, falls der Server abgestürzt ist oder die Verbindung einfach nicht zustandekommt,
        // die zuletzt aktualisierten Daten genommen werden und abgeglichen werden.
    }
}