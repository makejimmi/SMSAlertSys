using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SMSAlertSys.Properties;

namespace SMSAlertSys
{
    public sealed class BackgroundTask
    {
        private NotifyIcon icon;
        private ContextMenu menu;
        public BackgroundTask()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            menu = new ContextMenu();
            menu.MenuItems.Add("Exit", OnExit);
            icon = new NotifyIcon();
            icon.Text = "Some text";
            icon.Icon =
                new Icon("\\C:\\Study\\all I know about SQL\\SMSAlertSys\\SMSAlertSys\\Resources\\atIcon.png\\", 40, 40);
            MessageBox.Show(SMSAlertSys.Properties.Resources.atIcon.ToString());
            //icon.Icon = new Icon(global::SMSAlertSys.Properties.Resources.testIcon, 40, 40);

            // "C:\Study\all I know about SQL\SMSAlertSys\SMSAlertSys\Resources\atIcon.png"
        }

        private void OnExit(object sender, EventArgs e)
        {
            icon.Dispose();
            Application.Exit();
        }
    }
}
