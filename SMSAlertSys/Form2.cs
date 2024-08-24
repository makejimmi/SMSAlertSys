using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using System.Threading;

namespace SMSAlertSys
{
    class timePicker : Form
    {
        #region Vom Windows Form-Designer generierter Code
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private ComboBox startTimeBox;
        private ComboBox endTimeBox;
        private RichTextBox notesRichBox;
        private Button saveBtn;

        #endregion
        //-------------------------------------------------------
        DateTime selectedDate = DateTime.MinValue;

        string _title = "";
        int _passed = 0;
        private DateTime startTime = DateTime.MinValue;
        private DateTime endTime = DateTime.MinValue;
        private DateTime _date = DateTime.MinValue;
        string _notes = "";
        string _email = "";
        string _phonenr = "";

        public string getTitle { get { return _title; } set { } }
        public int getPassed { get { return _passed; } set { } }
        public DateTime getStartTime { get { return startTime; } set { } }
        public DateTime getEndTime { get { return endTime; } set { } }
        public DateTime getDate { get { return _date; } set { } }
        public string getNotes { get { return _notes; } set { } }
        public string getEmail{ get { return _email; } set { } }
        public string getPhoneNr { get { return _phonenr; } set { } }


        private RichTextBox titleRichBox;
        private RichTextBox phoneNrRichBox;
        private RichTextBox emailRichBox;

        List<RichTextBox> richBoxList = new List<RichTextBox>();
        private Button cancelBtn;
        private Button configAlarmBtn;
        private Button button1;
        List<string> boxStrings = new List<string> {
            "Notes which will be included in the notification...",
            "Title",
            "Phone Number (MUST)",
            "E-Mail Address (Optional)"
        };

        public timePicker()
        {
            try
            {
                //MessageBox.Show("Pick a date and then, in a new window, the time on and at which you want " +
                //    "to be notified for the event that you will have to describe in notes.");
                InitializeComponent();
                config();
                configToolTips();
                this.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }
        private void config()
        {
            try
            {
                titleRichBox.Text = "Title";
                notesRichBox.Text = "Notes which will be included in the notification...";
                phoneNrRichBox.Text = "Phone Number (MUST)";
                emailRichBox.Text = "E-Mail Address (Optional)";

                this.richBoxList.Add(this.titleRichBox);
                this.richBoxList.Add(this.notesRichBox);
                this.richBoxList.Add(this.phoneNrRichBox);
                this.richBoxList.Add(this.emailRichBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void showSelectedDay(DateTime selectedDate)
        {
            if (selectedDate != null) this.selectedDate = selectedDate;
            else
            {
                throw new ArgumentNullException();
            }
            createTT4Boxes();
        }

        private void configToolTips()
        {
            try
            {
                ToolTip toolTip = new ToolTip();
                toolTip.AutoPopDelay = 0;
                toolTip.InitialDelay = 100;
                toolTip.ReshowDelay = 100;
                toolTip.ToolTipIcon = ToolTipIcon.Info;
                toolTip.ToolTipTitle = "Choose Time:";
                toolTip.SetToolTip(this.startTimeBox, "Please let me know when I should notify you (Start).");
                toolTip.SetToolTip(this.endTimeBox, "You can leave this blank or fill it out.");
                toolTip.SetToolTip(this.configAlarmBtn, "Configuration of when you should be notified.\n");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");    
            }
        }

        private void InitializeComponent()
        {
            this.startTimeBox = new System.Windows.Forms.ComboBox();
            this.endTimeBox = new System.Windows.Forms.ComboBox();
            this.notesRichBox = new System.Windows.Forms.RichTextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.titleRichBox = new System.Windows.Forms.RichTextBox();
            this.phoneNrRichBox = new System.Windows.Forms.RichTextBox();
            this.emailRichBox = new System.Windows.Forms.RichTextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.configAlarmBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startTimeBox
            // 
            this.startTimeBox.FormattingEnabled = true;
            this.startTimeBox.Location = new System.Drawing.Point(21, 103);
            this.startTimeBox.Margin = new System.Windows.Forms.Padding(5);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(349, 32);
            this.startTimeBox.TabIndex = 1;
            this.startTimeBox.Text = "Start";
            this.startTimeBox.SelectedIndexChanged += new System.EventHandler(this.startTimeBox_SelectedIndexChanged);
            // 
            // endTimeBox
            // 
            this.endTimeBox.FormattingEnabled = true;
            this.endTimeBox.Location = new System.Drawing.Point(399, 103);
            this.endTimeBox.Margin = new System.Windows.Forms.Padding(5);
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(349, 32);
            this.endTimeBox.TabIndex = 2;
            this.endTimeBox.Text = "End";
            this.endTimeBox.SelectedIndexChanged += new System.EventHandler(this.endTimeBox_SelectedIndexChanged);
            // 
            // notesRichBox
            // 
            this.notesRichBox.Location = new System.Drawing.Point(21, 145);
            this.notesRichBox.Margin = new System.Windows.Forms.Padding(5);
            this.notesRichBox.Name = "notesRichBox";
            this.notesRichBox.Size = new System.Drawing.Size(732, 188);
            this.notesRichBox.TabIndex = 4;
            this.notesRichBox.Text = "Notes which will be included in the notification...";
            this.notesRichBox.Click += new System.EventHandler(this.selectAll);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(383, 401);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(182, 40);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // titleRichBox
            // 
            this.titleRichBox.Location = new System.Drawing.Point(21, 29);
            this.titleRichBox.Margin = new System.Windows.Forms.Padding(5);
            this.titleRichBox.Name = "titleRichBox";
            this.titleRichBox.Size = new System.Drawing.Size(732, 64);
            this.titleRichBox.TabIndex = 0;
            this.titleRichBox.Text = "Title";
            this.titleRichBox.Click += new System.EventHandler(this.selectAll);
            // 
            // phoneNrRichBox
            // 
            this.phoneNrRichBox.Location = new System.Drawing.Point(21, 346);
            this.phoneNrRichBox.Margin = new System.Windows.Forms.Padding(5);
            this.phoneNrRichBox.Name = "phoneNrRichBox";
            this.phoneNrRichBox.Size = new System.Drawing.Size(349, 39);
            this.phoneNrRichBox.TabIndex = 5;
            this.phoneNrRichBox.Text = "Phone Number (MUST)";
            this.phoneNrRichBox.Click += new System.EventHandler(this.selectAll);
            // 
            // emailRichBox
            // 
            this.emailRichBox.Location = new System.Drawing.Point(383, 348);
            this.emailRichBox.Margin = new System.Windows.Forms.Padding(5);
            this.emailRichBox.Name = "emailRichBox";
            this.emailRichBox.Size = new System.Drawing.Size(364, 37);
            this.emailRichBox.TabIndex = 6;
            this.emailRichBox.Text = "E-Mail Address (Optional)";
            this.emailRichBox.Click += new System.EventHandler(this.selectAll);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(576, 401);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(175, 40);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // configAlarmBtn
            // 
            this.configAlarmBtn.Location = new System.Drawing.Point(191, 401);
            this.configAlarmBtn.Margin = new System.Windows.Forms.Padding(5);
            this.configAlarmBtn.Name = "configAlarmBtn";
            this.configAlarmBtn.Size = new System.Drawing.Size(182, 40);
            this.configAlarmBtn.TabIndex = 9;
            this.configAlarmBtn.Text = "Alarm Conf";
            this.configAlarmBtn.UseVisualStyleBackColor = true;
            this.configAlarmBtn.Click += new System.EventHandler(this.configAlarmBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(777, 462);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.configAlarmBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.emailRichBox);
            this.Controls.Add(this.phoneNrRichBox);
            this.Controls.Add(this.titleRichBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.notesRichBox);
            this.Controls.Add(this.endTimeBox);
            this.Controls.Add(this.startTimeBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "timePicker";
            this.ResumeLayout(false);

        }
        private void createTT4Boxes()
        {
            try
            {
                DateTime dateTime = this.selectedDate;
                List<string> timeTable = new List<string>();

                string ccHour = ""; string ccMinute = "";

                for (int i = 0; i < 24 * 2; i++)
                {
                    int hour = dateTime.Hour;
                    int minute = dateTime.Minute;

                    if (hour <= 9) ccHour = "0";
                    else ccHour = "";

                    if (minute != 30) ccMinute = "0";
                    else ccMinute = "";

                    timeTable.Add(ccHour + dateTime.Hour + ":" + dateTime.Minute + ccMinute);
                    dateTime = dateTime.AddMinutes(30);
                }
                string[] arr = timeTable.ToArray();
                this.startTimeBox.Items.AddRange(arr);
                this.endTimeBox.Items.AddRange(arr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        //private ComboBox comboBox1;
        private void endTimeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            string selectedItem = (sender as ComboBox).SelectedItem.ToString();

            int count = 0;
            foreach (string item in endTimeBox.Items)
            {
                if (item != selectedItem) count++;
                else break;
            }

            this.endTime = stringToDateTimeConv(count);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void startTimeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = (sender as ComboBox).SelectedItem.ToString();

                int count = 0;
                foreach (string item in startTimeBox.Items)
                {
                    if (item != selectedItem) count++;
                    else break;
                }

                this.startTime = stringToDateTimeConv(count);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private DateTime stringToDateTimeConv(int count)
        {
            try
            {
                DateTime newDateTime = selectedDate;

                for (int i = 0; i < count; i++)
                {
                    newDateTime = newDateTime.AddMinutes(30);
                }

                return newDateTime;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
                return DateTime.MinValue;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                string[] texts = { this.notesRichBox.Text, this.titleRichBox.Text, this.phoneNrRichBox.Text , this.emailRichBox.Text };
                foreach (string boxString in boxStrings)
                {
                    if (boxString == texts[i])
                    {
                        MessageBox.Show("Please fill out every fiield or leave empty");
                        return;
                    }
                    i++;
                }
                this._title = this.titleRichBox.Text;
                this._passed = 0;
                this._date = selectedDate;
                this._notes = this.notesRichBox.Text;
                this._email = this.emailRichBox.Text;
                this._phonenr = this.phoneNrRichBox.Text;

                if (selectedDate < DateTime.Now) this._passed = 1;

                // Works on a similar basis as the git commit and then with "insert()" it pushes it to the table
                GlobalVars.sc.addData(this._title, this._passed, this._date,
                           this.startTime, this.endTime, GlobalVars.chosenTrigger.ToString(),
                           this._notes, this._email, this._phonenr);

                GlobalVars.connection.Open();
                GlobalVars.sc.insert(GlobalVars.connection); // inserts all the given data from "addData" in to the table
                GlobalVars.connection.Close();

                GlobalVars.TasksClass.modAddTask(GlobalVars.task_path, GlobalVars.chosenTrigger, GlobalVars.execAction,
                    GlobalVars.task_userId, GlobalVars.task_password, GlobalVars.task_description);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                this.Close();
            }
        }
        private void selectAll(object sender, EventArgs e)
        {
            //string text = (sender as RichTextBox).Text;
            //MessageBox.Show((sender as RichTextBox).Name);
            //foreach (string match in boxStrings)
            //{
            //    if (match == text) (sender as RichTextBox).Text = "";
            //    else if (text.Contains("'")) 
            //    {
            //        (sender as RichTextBox).Text = text.Remove(text.Length-1);
            //        text = (sender as RichTextBox).Text;

            //        MessageBox.Show("Use of special character -> ' <- is prohibited.\n" +
            //            "It is due to programming conventions.\n\n" +
            //            text);
            //    }
            //}

            //string text = (sender as RichTextBox).Text;

            try
            {

                if ((sender as RichTextBox).Text.Contains("'"))
                {
                    (sender as RichTextBox).Text = (sender as RichTextBox).Text.Remove((sender as RichTextBox).Text.Length - 1);
                    MessageBox.Show("Use of special character -> ' <- is prohibited.");
                }

                // Ich möchte, dass der Text in der jeweiligen Box verschwindet, sobald ich etwas hineintippe.
                // Die Box nennt sich (sender as RichTextBox).Text und dieser bleibt immer gleich.
                // Nun brauche ich eine Zeichenkette, die dem der Box gleicht und gleiche sie miteinander ab.
                // Falls sie gleich sind, dann weiß ich: "Aha, du bist mir gleich und darum sollst du gelöscht werden".
                // Da genau das das Ziel ist, weiß ich, dass ich eine Zeichenkette brauche, die sich dem des Senders gleicht.
                foreach (string boxString in boxStrings)
                {
                    if (boxString == (sender as RichTextBox).Text) (sender as RichTextBox).Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configAlarmBtn_Click(object sender, EventArgs e)
        {
            AlarmConfigForm alarmConfigForm = new AlarmConfigForm();
            alarmConfigForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private static void ThreadStart()
        {
            Application.Run(new BackgroundProcess());
        }
    }
}
