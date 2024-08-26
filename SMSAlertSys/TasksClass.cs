using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32.TaskScheduler;

namespace SMSAlertSys
{
    internal class TasksClass
    {
        TaskService tS;
        private Trigger trigger;
        public TasksClass()
        {
            Connector();
        }
        private void Connector()
        {
            this.tS = new TaskService();

            if (tS.Connected == false)
            {
                MessageBox.Show("Connection to the task scheduler could not be established.\nTry again or contact developer.");
                return;
            }
            //else MessageBox.Show("Connection to the task scheduler has been established.");

            //foreach (Task task in taskService.AllTasks)
            //{
            //    Console.WriteLine(task.Name);
            //}
        }
        public void modAddTask(String taskName, Trigger trigger, Microsoft.Win32.TaskScheduler.Action action, String optUserID, String optUserPw, String optDescription)
        {
            TaskLogonType taskLogonType = TaskLogonType.InteractiveToken;
            tS.AddTask(taskName, trigger, action, optUserID, optUserPw, taskLogonType, optDescription);

            Task task = tS.FindTask(taskName, true);
            if (task == null)
            {
                MessageBox.Show("Task could not be added.\nCheck input, try again or contact developer.");
                return;
            }

            MessageBox.Show(task.Name + " has been created, added and can be viewed in " + task.Path);
        }

        public Trigger createTrigger(int triggerID, DateTimePicker timePicker, DateTimePicker dayPicker)
        {
            switch (triggerID)
            {
                case 0:

                    // create timetrigger + action based on data from form
                    DateTimePicker tP = timePicker;
                    DateTimePicker dP = dayPicker;
                    DateTime startB = new DateTime(dP.Value.Year, dP.Value.Month, dP.Value.Day,
                        tP.Value.Hour, tP.Value.Minute, tP.Value.Second);

                    TimeTrigger timeT = new TimeTrigger();
                    timeT.StartBoundary = startB;

                    this.trigger = timeT;

                    break;

                case 1:
                    // create daily trigger + action based on data from form

                    // has other options than the time trigger itself, TO BE IMPLEMENTED

                    //DailyTrigger dailyT = new DailyTrigger();
                    //dailyT.StartBoundary = timePicker.Value;

                    //this.trigger = dailyT;
                    break;
                case 2:
                    // create weekly tr + action based on data from form

                    // the weekly trigger has more options, TO BE IMPLEMENTED

                    //WeeklyTrigger weeklyT = new WeeklyTrigger();
                    //weeklyT.StartBoundary = this.timePicker.Value;
                    break;
                case 3:
                    // create monthly tr + action based on data from form

                    // and again, has more options, TO BE IMPLEMENTED

                    //MonthlyTrigger monthlyT = new MonthlyTrigger();
                    //this.trigger = monthlyT;
                    break;
                case 4:
                    // create boot tr + action based on data from form

                    // here too

                    BootTrigger bootT = new BootTrigger();
                    this.trigger = bootT;
                    break;
                case 5:
                    // create idle tr + action based on data from form

                    // here too

                    //IdleTrigger idleT = new IdleTrigger();
                    //this.trigger = idleT;
                    break;
                case 6:
                    // create logon tr + action based on data from form

                    // here too

                    //LogonTrigger logonT = new LogonTrigger();
                    //this.trigger = logonT;
                    break;
                case 7:
                    // create registration + action based on data from form

                    // here too

                    //RegistrationTrigger registrationT = new RegistrationTrigger();
                    //this.trigger = registrationT;
                    break;
                default: this.trigger = new TimeTrigger(); break;
            }
            return this.trigger;
        }

        // simply opens the application which is to be published (made to a standalone exe file)
        public ExecAction createAction()
        {
            return new ExecAction("notiSis.exe");
        }
    }
}