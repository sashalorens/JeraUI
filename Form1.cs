using JeraKeyboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeraUI
{
    public partial class Form1 : Form
    {
        public Form1(IJeraKB jeraKB)
        {
            this.jeraKB = jeraKB;
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            // start minimized
            this.WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            // Set up how the form should be displayed.
            // this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Jera Settings";

            // Create the NotifyIcon.
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            trayIcon.Icon = new Icon("../../../logoIdle.ico");

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            trayIcon.Text = "Form1 (NotifyIcon example)";
            trayIcon.Visible = true;
            trayIcon.ContextMenuStrip = trayMenu;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("button1 was clicked");
        }
    }
}
