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
    public class BackgroundProcess : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        private void InitializeComponent()
        {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Resources.TrayIcon";

            Icon icon = Icon.ExtractAssociatedIcon("C:\\Study\\all I know about SQL\\SMSAlertSys\\SMSAlertSys\\Properties\\exampleIcon.png");

            trayIcon.Icon = new Icon(icon,icon.Size);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        public BackgroundProcess()
        {
            InitializeComponent();
            MessageBox.Show("Background process running.\nContinuously checking date time...");
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            // Release the icon resource.
            trayIcon.Dispose();
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }
            base.Dispose(isDisposing);
        }
    }
}
