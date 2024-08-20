using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAlertSys
{
    public class AlarmConfigForm : Form
    {
        private string[] triggers = { "Time (Standard)", "Daily", "Weekly", "Monthly", "Boot", "Idle", "Logon", "Registration" };
        private int triggerSetting;

        public AlarmConfigForm()
        {
            InitializeComponent();
            initTriggerBox();
            GlobalVars.TasksClass = new TasksClass();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskNameTBLabel = new System.Windows.Forms.Label();
            this.taskNameTB = new System.Windows.Forms.TextBox();
            this.triggerBox = new System.Windows.Forms.ComboBox();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.descriptionRichTB = new System.Windows.Forms.RichTextBox();
            this.triggerBoxLabel = new System.Windows.Forms.Label();
            this.userIDTextBoxLabel = new System.Windows.Forms.Label();
            this.passwordTextBoxLabel = new System.Windows.Forms.Label();
            this.dayPicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taskNameTBLabel
            // 
            this.taskNameTBLabel.AutoSize = true;
            this.taskNameTBLabel.Location = new System.Drawing.Point(81, 18);
            this.taskNameTBLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.taskNameTBLabel.Name = "taskNameTBLabel";
            this.taskNameTBLabel.Size = new System.Drawing.Size(72, 25);
            this.taskNameTBLabel.TabIndex = 9;
            this.taskNameTBLabel.Text = "Name*";
            // 
            // taskNameTB
            // 
            this.taskNameTB.Location = new System.Drawing.Point(158, 15);
            this.taskNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.taskNameTB.Name = "taskNameTB";
            this.taskNameTB.Size = new System.Drawing.Size(560, 29);
            this.taskNameTB.TabIndex = 0;
            // 
            // triggerBox
            // 
            this.triggerBox.FormattingEnabled = true;
            this.triggerBox.Location = new System.Drawing.Point(158, 54);
            this.triggerBox.Margin = new System.Windows.Forms.Padding(6);
            this.triggerBox.Name = "triggerBox";
            this.triggerBox.Size = new System.Drawing.Size(560, 32);
            this.triggerBox.TabIndex = 1;
            this.triggerBox.Text = "Time (Standard)";
            this.triggerBox.SelectedIndexChanged += new System.EventHandler(this.triggerBox_SelectedIndexChanged);
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Location = new System.Drawing.Point(158, 135);
            this.userIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(560, 29);
            this.userIDTextBox.TabIndex = 5;
            this.userIDTextBox.Text = "(Optional)";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(158, 174);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(560, 29);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.Text = "(Optional)";
            // 
            // descriptionRichTB
            // 
            this.descriptionRichTB.Location = new System.Drawing.Point(11, 220);
            this.descriptionRichTB.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionRichTB.Name = "descriptionRichTB";
            this.descriptionRichTB.Size = new System.Drawing.Size(706, 227);
            this.descriptionRichTB.TabIndex = 7;
            this.descriptionRichTB.Text = "Description (Optional)";
            // 
            // triggerBoxLabel
            // 
            this.triggerBoxLabel.AutoSize = true;
            this.triggerBoxLabel.Location = new System.Drawing.Point(73, 57);
            this.triggerBoxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.triggerBoxLabel.Name = "triggerBoxLabel";
            this.triggerBoxLabel.Size = new System.Drawing.Size(82, 25);
            this.triggerBoxLabel.TabIndex = 8;
            this.triggerBoxLabel.Text = "Trigger*";
            // 
            // userIDTextBoxLabel
            // 
            this.userIDTextBoxLabel.AutoSize = true;
            this.userIDTextBoxLabel.Location = new System.Drawing.Point(76, 135);
            this.userIDTextBoxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.userIDTextBoxLabel.Name = "userIDTextBoxLabel";
            this.userIDTextBoxLabel.Size = new System.Drawing.Size(72, 25);
            this.userIDTextBoxLabel.TabIndex = 6;
            this.userIDTextBoxLabel.Text = "UserID";
            // 
            // passwordTextBoxLabel
            // 
            this.passwordTextBoxLabel.AutoSize = true;
            this.passwordTextBoxLabel.Location = new System.Drawing.Point(50, 175);
            this.passwordTextBoxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.passwordTextBoxLabel.Name = "passwordTextBoxLabel";
            this.passwordTextBoxLabel.Size = new System.Drawing.Size(98, 25);
            this.passwordTextBoxLabel.TabIndex = 5;
            this.passwordTextBoxLabel.Text = "Password";
            // 
            // dayPicker
            // 
            this.dayPicker.Location = new System.Drawing.Point(158, 98);
            this.dayPicker.Margin = new System.Windows.Forms.Padding(4);
            this.dayPicker.Name = "dayPicker";
            this.dayPicker.Size = new System.Drawing.Size(368, 29);
            this.dayPicker.TabIndex = 3;
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(534, 98);
            this.timePicker.Margin = new System.Windows.Forms.Padding(4);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(184, 29);
            this.timePicker.TabIndex = 4;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(511, 455);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(102, 37);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(619, 455);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(102, 37);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AlarmConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 504);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.dayPicker);
            this.Controls.Add(this.passwordTextBoxLabel);
            this.Controls.Add(this.userIDTextBoxLabel);
            this.Controls.Add(this.triggerBoxLabel);
            this.Controls.Add(this.descriptionRichTB);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userIDTextBox);
            this.Controls.Add(this.triggerBox);
            this.Controls.Add(this.taskNameTB);
            this.Controls.Add(this.taskNameTBLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AlarmConfigForm";
            this.Text = "AlarmConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label taskNameTBLabel;
        private TextBox taskNameTB;
        private ComboBox triggerBox;
        private TextBox userIDTextBox;
        private TextBox passwordTextBox;
        private RichTextBox descriptionRichTB;
        private Label triggerBoxLabel;
        private Label userIDTextBoxLabel;
        private Label passwordTextBoxLabel;
        private DateTimePicker dayPicker;
        private DateTimePicker timePicker;
        private Button saveBtn;
        private Button cancelBtn;
        private ComboBox delayBox;

        private void initTriggerBox()
        {
            foreach (string trigger in triggers)
            {
                this.triggerBox.Items.Add(trigger);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //int triggerSetting = 0;

            //foreach (string trigger in triggers)
            //{
            //    if (trigger != this.triggerBox.Text) triggerSetting++;
            //    else break;
            //}

            GlobalVars.chosenTrigger = GlobalVars.TasksClass.createTrigger(triggerSetting, this.timePicker, this.dayPicker);
            MessageBox.Show(GlobalVars.chosenTrigger.ToString());

            GlobalVars.execAction = GlobalVars.TasksClass.createAction();

            GlobalVars.task_path = this.taskNameTB.Text;

            if (this.userIDTextBox.Text == null || this.userIDTextBox.Text == "(Optional)")
                GlobalVars.task_userId = null;
            else GlobalVars.task_userId = this.userIDTextBox.Text;

            if (this.passwordTextBox.Text == null || this.passwordTextBox.Text == "(Optional)")
                GlobalVars.task_password= null;
            else GlobalVars.task_password = this.passwordTextBox.Text;

            if (this.descriptionRichTB.Text == null || this.descriptionRichTB.Text == "Description (Optional)")
                GlobalVars.task_description= null;
            else GlobalVars.task_description = this.descriptionRichTB.Text;

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void triggerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = (sender as ComboBox).Text;

            int standardLocX = 158;
            int standardLocY = 98;
            int standardLength = 368;
            int standardHeight = 29;
            int maxLength = standardLength + standardLength / 2 + 8;
            int tabIdx = 3;
 
            switch (option) 
            {
                case "Time (Standard)":
                    this.triggerSetting = 0;
                    removeUIComps();

                    addDayPicker(standardLocX, standardLocY, standardLength, standardHeight, tabIdx);

                    // prev. timepicker LocX = 534, prev. timepicker LocY = 98
                    // timepicker is principally smaller in length than daypicker by 184 (half of 368)

                    // 158 + 368 = 534 - x
                    // x = 534 - 158 - 368 = 8
                    addTimePicker(standardLocX+standardLength+8, 98, standardLength/2, 29, tabIdx+1);

                    this.Controls.Add(this.dayPicker);
                    this.Controls.Add(this.timePicker);

                    resAperf();
                    break;

                //case "Daily":
                //    this.triggerSetting = 1;
                //    removeUIComps();

                //    int firstLength = (maxLength - 30) / 2;
                //    addDayPicker(standardLocX, standardLocY, firstLength, standardHeight, tabIdx);
                //    addDayPicker(standardLocX + 8 + firstLength, standardLocY, firstLength, standardHeight, tabIdx + 1);
                //    add

                //     continue when you have more time lmao TBDDDDDDDDDDDDDDDd

                //    resAperf();
                //    break;

                //case "Weekly":
                //    this.triggerSetting = 2;
                //    removeUIComps();
                //    resAperf();


                //    break;

                //case "Monthly":
                //    this.triggerSetting = 3;
                //    removeUIComps();
                //    resAperf();


                //    break;

                case "Boot":
                    this.triggerSetting = 4;
                    removeUIComps();

                    this.delayBox = new System.Windows.Forms.ComboBox();
                    this.delayBox.FormattingEnabled = true;
                    this.delayBox.Location = new System.Drawing.Point(standardLocX, standardLocY);
                    this.delayBox.Margin = new System.Windows.Forms.Padding(6);
                    this.delayBox.Name = "delayBox";
                    this.delayBox.Size = new System.Drawing.Size(standardLength, standardHeight);
                    this.delayBox.TabIndex = 3;
                    this.delayBox.Text = "Delay in minutes (Optional)";

                    for(int i  = 0; i < 1439; i++)
                    {
                        this.delayBox.Items.Add(i);
                    }

                    resAperf();
                    break;

                //case "Idle":
                //    this.triggerSetting = 5;
                //    removeUIComps();
                //    resAperf();


                //    break;

                //case "Logon":
                //    this.triggerSetting = 6;
                //    removeUIComps();
                //    resAperf();


                //    break;

                //case "Registration":
                //    this.triggerSetting = 7;
                //    removeUIComps();
                //    resAperf();


                //    break;
            }
        }

        private void removeUIComps()
        {
            this.SuspendLayout();
            this.Controls.Remove(this.dayPicker);
            this.Controls.Remove(this.timePicker);
            this.Controls.Remove(this.delayBox);
        }

        private void addDayPicker(int x, int y, int length, int height, int tabIdx)
        {
            this.dayPicker = new System.Windows.Forms.DateTimePicker();
            this.dayPicker.Location = new System.Drawing.Point(x, y);
            this.dayPicker.Margin = new System.Windows.Forms.Padding(4);
            this.dayPicker.Name = "dayPicker";
            this.dayPicker.Size = new System.Drawing.Size(length, height);
            this.dayPicker.TabIndex = tabIdx;
        }

        private void addTimePicker(int x, int y, int length, int height, int tabIdx) 
        {
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(x, y);
            this.timePicker.Margin = new System.Windows.Forms.Padding(4);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(length, height);
            this.timePicker.TabIndex = tabIdx;
        }

        private void resAperf()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 504);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}