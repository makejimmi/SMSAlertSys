using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAlertSys
{
    public class AlarmConfigForm : Form
    {
        public AlarmConfigForm()
        {
            InitializeComponent();
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
            this.actionBox = new System.Windows.Forms.ComboBox();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.descriptionRichTB = new System.Windows.Forms.RichTextBox();
            this.triggerBoxLabel = new System.Windows.Forms.Label();
            this.actionBoxLabel = new System.Windows.Forms.Label();
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
            this.triggerBox.Text = "Trigger";
            // 
            // actionBox
            // 
            this.actionBox.FormattingEnabled = true;
            this.actionBox.Location = new System.Drawing.Point(158, 94);
            this.actionBox.Margin = new System.Windows.Forms.Padding(6);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(178, 32);
            this.actionBox.TabIndex = 2;
            this.actionBox.Text = "Action";
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
            // actionBoxLabel
            // 
            this.actionBoxLabel.AutoSize = true;
            this.actionBoxLabel.Location = new System.Drawing.Point(81, 98);
            this.actionBoxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.actionBoxLabel.Name = "actionBoxLabel";
            this.actionBoxLabel.Size = new System.Drawing.Size(75, 25);
            this.actionBoxLabel.TabIndex = 7;
            this.actionBoxLabel.Text = "Action*";
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
            this.dayPicker.Location = new System.Drawing.Point(348, 96);
            this.dayPicker.Margin = new System.Windows.Forms.Padding(4);
            this.dayPicker.Name = "dayPicker";
            this.dayPicker.Size = new System.Drawing.Size(174, 29);
            this.dayPicker.TabIndex = 3;
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(534, 96);
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
            this.Controls.Add(this.actionBoxLabel);
            this.Controls.Add(this.triggerBoxLabel);
            this.Controls.Add(this.descriptionRichTB);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userIDTextBox);
            this.Controls.Add(this.actionBox);
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
        private ComboBox actionBox;
        private TextBox userIDTextBox;
        private TextBox passwordTextBox;
        private RichTextBox descriptionRichTB;
        private Label triggerBoxLabel;
        private Label actionBoxLabel;
        private Label userIDTextBoxLabel;
        private Label passwordTextBoxLabel;
        private DateTimePicker dayPicker;
        private DateTimePicker timePicker;
        private Button saveBtn;
        private Button cancelBtn;

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}