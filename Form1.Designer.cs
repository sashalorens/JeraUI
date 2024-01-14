using JeraKeyboard;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JeraUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon trayIcon = new System.Windows.Forms.NotifyIcon();
        public readonly IJeraKB jeraKB;

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

        private void InitializeLanguages()
        {
            bool hasDefaultValue = false;
            foreach (InputLanguage c in System.Windows.Forms.InputLanguage.InstalledInputLanguages)
            {
                comboBox1.Items.Add(c.Culture.EnglishName);
                comboBox2.Items.Add(c.Culture.EnglishName);

                if (!hasDefaultValue)
                {
                    comboBox1.SelectedItem = c.Culture.EnglishName;
                    comboBox2.SelectedItem = c.Culture.EnglishName;
                    hasDefaultValue = true;
                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            trayIcon = new NotifyIcon(components);
            trayMenu = new ContextMenuStrip(components);
            settingsMenuItem = new ToolStripMenuItem();
            startMenuItem = new ToolStripMenuItem();
            pauseMenuItem = new ToolStripMenuItem();
            restartMenuItem = new ToolStripMenuItem();
            closeMenuItem = new ToolStripMenuItem();
            comboBox1 = new ComboBox();
            labelFrom = new Label();
            labelTo = new Label();
            comboBox2 = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            browseButton = new Button();
            trayMenu.SuspendLayout();
            SuspendLayout();
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Text = "notifyIcon1";
            trayIcon.Visible = true;
            // 
            // trayMenu
            // 
            trayMenu.Items.AddRange(new ToolStripItem[] { settingsMenuItem, startMenuItem, pauseMenuItem, restartMenuItem, closeMenuItem });
            trayMenu.Name = "contextMenuStrip1";
            trayMenu.Size = new Size(117, 114);
            trayMenu.Text = "Foo";
            trayMenu.Opening += contextMenuStrip1_Opening;
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Size = new Size(116, 22);
            settingsMenuItem.Text = "Settings";
            settingsMenuItem.Click += onSettingsClick;
            // 
            // startMenuItem
            // 
            startMenuItem.Name = "startMenuItem";
            startMenuItem.Size = new Size(116, 22);
            startMenuItem.Text = "Start";
            startMenuItem.Click += onStartClick;
            // 
            // pauseMenuItem
            // 
            pauseMenuItem.Name = "pauseMenuItem";
            pauseMenuItem.Size = new Size(116, 22);
            pauseMenuItem.Text = "Pause";
            pauseMenuItem.Click += onPauseClick;
            // 
            // restartMenuItem
            // 
            restartMenuItem.Name = "restartMenuItem";
            restartMenuItem.Size = new Size(116, 22);
            restartMenuItem.Text = "Restart";
            restartMenuItem.Click += onRestartClick;
            // 
            // closeMenuItem
            // 
            closeMenuItem.Name = "closeMenuItem";
            closeMenuItem.Size = new Size(116, 22);
            closeMenuItem.Text = "Close";
            closeMenuItem.Click += onCloseClick;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(26, 49);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 23);
            comboBox1.TabIndex = 1;
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(26, 22);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(134, 15);
            labelFrom.TabIndex = 2;
            labelFrom.Text = "Use transliteration from:";
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Location = new Point(26, 96);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(23, 15);
            labelTo.TabIndex = 3;
            labelTo.Text = "To:";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(26, 123);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(180, 23);
            comboBox2.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.ShowHiddenFiles = true;
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(550, 95);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 23);
            browseButton.TabIndex = 5;
            browseButton.Text = "button1";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += onBrowseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2776, 619);
            Controls.Add(browseButton);
            Controls.Add(comboBox2);
            Controls.Add(labelTo);
            Controls.Add(labelFrom);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            trayMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void onSettingsClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            jeraKB.IsConfigExists();
            InitializeLanguages();
        }

        private void onStartClick(object sender, EventArgs e)
        {
            trayIcon.Icon = new Icon("../../../logoOn.ico");
        }

        private void onPauseClick(object sender, EventArgs e)
        {
            trayIcon.Icon = new Icon("../../../logoIdle.ico");
        }

        private void onRestartClick(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
            Process.GetCurrentProcess().Kill();
        }

        private void onCloseClick(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void onBrowseClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menuItemToolStripMenuItem;
        private ComboBox comboBox1;
        private Label labelFrom;
        private Label labelTo;
        private ComboBox comboBox2;
        private OpenFileDialog openFileDialog1;
        private Button browseButton;
    }
}

