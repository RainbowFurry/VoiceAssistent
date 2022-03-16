using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.handler.backgroundtasks.infoicon
{
    class InfoIcon
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private NotifyIcon notifyIcon1 = NotificationMessage.notifyIcon1;
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        public static MenuItem plugins;
        private MenuItem games;
        // private System.Windows.Forms.MenuItem menuItem5;

        private System.ComponentModel.IContainer components = NotificationMessage.components;

        /// <summary>
        /// Initialize Programm Icon in Windows Task Bar
        /// </summary>
        public InfoIcon()
        {
            
           // this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new ContextMenu();
            this.menuItem1 = new MenuItem();
            this.menuItem2 = new MenuItem();
            this.menuItem3 = new MenuItem();
            this.menuItem4 = new MenuItem();
            this.games = new MenuItem();
            plugins = new MenuItem();
            // this.menuItem5 = new System.Windows.Forms.MenuItem();


            // Initialize contextMenu1
            this.contextMenu1.MenuItems.AddRange(
                           new MenuItem[] { this.menuItem1 });
            this.contextMenu1.MenuItems.AddRange(
                        new MenuItem[] { this.menuItem2 });
            this.contextMenu1.MenuItems.AddRange(
                      new MenuItem[] { this.menuItem3 });
            this.contextMenu1.MenuItems.AddRange(
                     new MenuItem[] { this.menuItem4 });
            this.contextMenu1.MenuItems.AddRange(
                      new MenuItem[] { plugins });
            this.contextMenu1.MenuItems.AddRange(
                new MenuItem[] { this.games });
            // this.contextMenu1.MenuItems.AddRange(
            //            new System.Windows.Forms.MenuItem[] { this.menuItem5 });

            // Initialize menuItem1
            this.menuItem1.Index = 5;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            // Initialize Settings
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "S&ettings";
            this.menuItem2.Click += new EventHandler(this.Settings_Click);

            // Initialize Menu
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "M&enu";
            this.menuItem3.Click += new EventHandler(this.Menu_Click);

            //DWC CATEGORY!!! TODO | start own programms...

            // Initialize Open
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "O&pen";
            //this.menuItem4.Click += new EventHandler(this.Open_Click);

            //menuItem4.MenuItems.Add("Explorer").Click += new EventHandler(this.Explorer_Click);
            //menuItem4.MenuItems.Add("Calculator").Click += new EventHandler(this.Calculator_Click);

            // Initialize Plugins
            plugins.Index = 1;
            plugins.Text = "Plugins";
            plugins.Click += new EventHandler(this.Plugins_Click);

            //for (int i = 0; i < plugin.PluginManager.pluginNameInfoIcon.Count; i++)
            //{
            //    plugins.MenuItems.Add(plugin.PluginManager.pluginNameInfoIcon[i]).Click += new EventHandler(DWC_VoiceAssistent.plugin.PluginManager.pluginRightClickEventHandler);
            //}

            // Initialize Games
            this.games.Index = 0;
            this.games.Text = "Games";
            this.games.Click += new EventHandler(this.Games_Click);

            games.MenuItems.Add("Games").Click += new EventHandler(this.Games_Click);

            // Create the NotifyIcon.
            //this.notifyIcon1 = new NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon1.Icon = SystemIcons.Application;

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenu = this.contextMenu1;
            String projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            projectPath = projectPath.Replace("DWC_VoiceAssistent.exe", "");
            projectPath += "src/icon.ico";
            notifyIcon1.Icon = new System.Drawing.Icon(projectPath);

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon1.Text = "DarkWolfCraft VoiceAssistent";
            notifyIcon1.Visible = true;

            LogFileManager.createLogEntrence("DWC_VoiceAssistent Info Icon was successfully Created");

        }

        /// <summary>
        /// Clean up any Component from being used
        /// </summary>
        protected void Dispose(bool disposing)
        {
            if (disposing)
                if (components != null)
                    components.Dispose();

            Dispose(disposing);
        }

        #region Programm Icon Buttons
        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            MainWindow.mainWindow.Close();
        }

        private void Plugins_Click(object Sender, EventArgs e)
        {

        }

        private void Games_Click(object Sender, EventArgs e)
        {

        }

        private void Settings_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            DWC_VoiceAssistent.projects.system.Settings settings = new DWC_VoiceAssistent.projects.system.Settings();
            settings.Show();
        }

        private void Menu_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            MainWindow.mainWindow.WindowState = WindowState.Normal;
        }
        #endregion

    }
}
