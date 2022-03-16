using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using DWC_VoiceAssistent.projects.windows;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.backgroundtasks.programmstartparametercontroler
{
    class WindowsProgrammStartParameterControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //https://docs.microsoft.com/de-de/dotnet/api/system.windows.application.startup?view=netframework-4.8

        public static void programmstartparametercontroler(String startParameter)
        {

            if (startParameter.Contains("/Window:Onlinestatus"))
            {
                //Console.WriteLine("STARTPARAMETER SUCCESS");
            }

            #region WindowState
            if (startParameter.Contains("/windowMinimized"))
            {
                MainWindow.mainWindow.WindowState = WindowState.Minimized;
            }

            if (startParameter.Contains("/windowMaximized"))
            {
                MainWindow.mainWindow.WindowState = WindowState.Maximized;
            }

            if (startParameter.Contains("/windowNormal"))
            {
                MainWindow.mainWindow.WindowState = WindowState.Normal;
            }
            #endregion

            #region Run Mode
            if (startParameter.Contains("--Developer"))
            {
                setRightClick();
            }

            if (startParameter.Contains("--rlldb"))//Reset Local Language DB
            {
                new TranslateLocalLanguageDB();
            }

            if (startParameter.Contains("--Administrator"))
            {
                //force admin rights???
            }

            if (startParameter.Contains("--Clean"))
            {
                
                //ReCreate Configfile
                if (File.Exists(MainWindow.Save_Path + "Config.conf"))
                    File.Delete(MainWindow.Save_Path + "Config.conf");

                if (File.Exists(MainWindow.Save_Path + "OftenUsedProgramms.dwc"))
                    File.Delete(MainWindow.Save_Path + "OftenUsedProgramms.dwc");

                if (Directory.Exists(MainWindow.Save_Path + @"logs\"))
                {
                    foreach (string file in Directory.GetFiles(MainWindow.Save_Path + @"logs\"))
                        File.Delete(file);
                    Directory.Delete(MainWindow.Save_Path + @"logs\");
                }
                //clear src and paste all src files to the right spot

            }
            #endregion

            LogFileManager.createLogEntrence("Programm Start up Commands successfully loaded!");

        }

        #region Developer RightClick

        private static void setRightClick()
        {
            RightClickMenu.context = new ContextMenu();

            MenuItem menuItemColorPicker = new MenuItem
            {
                Header = "Color Picker"
            };
            menuItemColorPicker.Click += colorPicker;

            MenuItem menuItemAlert = new MenuItem
            {
                Header = "Alert"
            };
            menuItemAlert.Click += alert;

            MenuItem menuItemLogin = new MenuItem
            {
                Header = "Login"
            };
            menuItemLogin.Click += login;

            MenuItem menuItemPluginStore = new MenuItem
            {
                Header = "Plugin Store"
            };
            menuItemPluginStore.Click += pluginStore;

            MenuItem menuItemProgrammInfo = new MenuItem
            {
                Header = "Programm Info"
            };
            menuItemProgrammInfo.Click += programmInfo;

            MenuItem menuItemReport = new MenuItem
            {
                Header = "Report"
            };
            menuItemReport.Click += report;

            MenuItem menuItemSettings = new MenuItem
            {
                Header = "Settings"
            };
            menuItemSettings.Click += settings;

            MenuItem menuItemStore = new MenuItem
            {
                Header = "Store"
            };
            menuItemStore.Click += store;

            MenuItem menuItemSystemInfo = new MenuItem
            {
                Header = "System Info"
            };
            menuItemSystemInfo.Click += systemInfo;

            MenuItem menuItemRating = new MenuItem
            {
                Header = "Rating"
            };
            menuItemRating.Click += rating;

            RightClickMenu.context.Items.Clear();
            RightClickMenu.context.Items.Add(menuItemColorPicker);
            RightClickMenu.context.Items.Add(menuItemAlert);
            RightClickMenu.context.Items.Add(menuItemLogin);
            RightClickMenu.context.Items.Add(menuItemPluginStore);
            RightClickMenu.context.Items.Add(menuItemProgrammInfo);
            RightClickMenu.context.Items.Add(menuItemSettings);
            RightClickMenu.context.Items.Add(menuItemStore);
            RightClickMenu.context.Items.Add(menuItemSystemInfo);
            RightClickMenu.context.Items.Add(menuItemRating);

        }

        private static void colorPicker(object Sender, EventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
        }

        private static void alert(object Sender, EventArgs e)
        {
            Alert alertWindow = new Alert();
            alertWindow.Show();
        }

        private static void login(object Sender, EventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
        }

        private static void pluginStore(object Sender, EventArgs e)
        {
            PluginStore pluginStoreWindow = new PluginStore();
            pluginStoreWindow.Show();
        }

        private static void programmInfo(object Sender, EventArgs e)
        {
            ProgrammInformation programmInfoWindow = new ProgrammInformation();
            programmInfoWindow.Show();
        }

        private static void report(object Sender, EventArgs e)
        {
            Report reportWindow = new Report();
            reportWindow.Show();
        }

        private static void settings(object Sender, EventArgs e)
        {
            Settings settingsWindow = new Settings();
            settingsWindow.Show();
        }

        private static void store(object Sender, EventArgs e)
        {
            Store storeWindow = new Store();
            storeWindow.Show();
        }

        private static void systemInfo(object Sender, EventArgs e)
        {
            SystemInformation systemInfoWindow = new SystemInformation();
            systemInfoWindow.Show();
        }

        private static void rating(object Sender, EventArgs e)
        {
            Rating ratingWindow = new Rating();
            ratingWindow.Show();
        }

        #endregion

    }
}
