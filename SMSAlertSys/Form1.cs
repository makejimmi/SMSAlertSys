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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        // Constructor for the datePicker class
        public datePicker()
        {
            try
            {
                InitializeComponent(); // Initialize UI components
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.runBtn = new System.Windows.Forms.Button();
            this.showAllEvents = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
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
            try { 
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

        // Background worker TO BE DONE ----------------------------------------------------------------------------------
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                int arg = (int)e.Argument;

                e.Result = workerStart(bw, arg);

                if (bw.CancellationPending) 
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Background worker RunWorkerCompleted ----------------------------------------------------------------------------------
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    // User cancelled operation
                    MessageBox.Show("Background operation has been cancelled.\nYou won't be notified until restart of the app.");
                }
                else if (e.Error != null)
                {
                    MessageBox.Show($"Error: {e.Error.ToString()}");
                }
                else
                {
                    MessageBox.Show("Result = {0}", e.Result.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Show error message in case of exception
            }
        }

        int workerStart(object bw, int arg) 
        {
            return 0;
        }
    }
}
