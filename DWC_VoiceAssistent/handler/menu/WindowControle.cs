using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Windows.Input;

namespace DWC_VoiceAssistent.handler.menu
{
    class WindowControle
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /// <summary>
        /// Register Controler
        /// </summary>
        public WindowControle()
        {

            MainWindow.mainWindow.DWC_MainMenu_Topbar_Plugins.MouseLeftButtonDown += DWC_MainMenu_Topbar_Plugins_Click;
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Extras.MouseLeftButtonDown += DWC_MainMenu_Topbar_Extras_Click;
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Settings.MouseLeftButtonDown += DWC_MainMenu_Topbar_Settings_Click;
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Report.MouseLeftButtonDown += DWC_MainMenu_Topbar_Report_Click;

            //Window Options
            MainWindow.mainWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            MainWindow.mainWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;
            MainWindow.mainWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;

            MainWindow.mainWindow.DWC_ActionBar.MouseLeftButtonDown += WindowDragandDrop;
            MainWindow.mainWindow.HomeImage.MouseLeftButtonDown += HomeClick;

            //load Window Timer Ticker
            myTimer.Tick += timer_Tick;
            myTimer.Start();

            //load Window DB
            loadMainWindowDBValues();

        }

        private void HomeClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_OpenProgrammTitle.Content = "Home";
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", MainWindow.mainWindow.DWC_OpenProgrammIcon);
            MainWindow.mainWindow.DWC_MainWindow_AppContent.Children.Clear();
        }

        #region Timer
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void timer_Tick(object sender, EventArgs e)
        {
            MainWindow.mainWindow.DWC_MainMenu_Date.Text = DateTime.Now.ToLongDateString();
            MainWindow.mainWindow.DWC_MainMenu_Time.Content = DateTime.Now.ToLongTimeString();
        }
        #endregion

        #region TopBarClick
        /// <summary>
        /// Open up the Webside of oure Company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DWC_MainMenu_Topbar_Webside_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();

            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://darkwolfcraft.net/DWC_VoiceAssistent/VoiceAssistent.html";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void DWC_MainMenu_Topbar_Settings_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Settings.SettingsWindow.Show();
        }

        private void DWC_MainMenu_Topbar_Plugins_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PluginStore pluginStore = new PluginStore();
            pluginStore.Show();
        }

        private void DWC_MainMenu_Topbar_Extras_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void DWC_MainMenu_Topbar_Commands_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void DWC_MainMenu_Topbar_Report_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Report reportWindow = new Report();
            reportWindow.Show();
        }
        #endregion

        #region DB
        /// <summary>
        /// Load the Language DB Values for the MainWindow
        /// </summary>
        private void loadMainWindowDBValues()
        {
            MainWindow.mainWindow.DWC_MainMenu_Navigator_Home.Content = db.DBManager.loadDBValue("DWC_MainMenu_Navigator_Home");
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Extras.Content = db.DBManager.loadDBValue("DWC_MainMenu_Topbar_Extras");
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Help.Content = db.DBManager.loadDBValue("DWC_MainMenu_Topbar_Help");
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Plugins.Content = db.DBManager.loadDBValue("DWC_MainMenu_Topbar_Plugins");
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Settings.Content = db.DBManager.loadDBValue("DWC_MainMenu_Topbar_Settings");

        }
        #endregion

        /// <summary>
        /// Load the Short Cuts for the Functions
        /// </summary>
        private void DWC_ShortCut(object sender, System.Windows.Input.KeyEventArgs e)
        {
            handler.backgroundtasks.ShortCut.DWC_ShortCut(sender, e);//register all known Shortcuts for this Window
        }

        /// <summary>
        /// Window Drag and Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowDragandDrop(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.DragMove();
        }

        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MainWindow.mainWindow.DWC_Window.WindowState == System.Windows.WindowState.Normal)
            {
                MainWindow.mainWindow.DWC_Window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                MainWindow.mainWindow.DWC_Window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

    }
}
