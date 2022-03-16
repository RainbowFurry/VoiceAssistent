using DarkWolfCraftSys;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace DWC_Gasoline
{

   public partial class MainWindow : Window
   {

        /*API KEY: 225eb269-08f1-90c8-6aa2-d580b7f0fe95
  Werbung: tankerkoenig.de
       URL: https://creativecommons.tankerkoenig.de/json/list.php?lat=52.52099975265203&lng=13.43803882598877&rad=4&sort=price&type=diesel&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95 
       Docs: https://creativecommons.tankerkoenig.de/?page=info
       */

        public static MainWindow mainWindow;
        public static String Save_Path = Assembly.GetExecutingAssembly().Location.Replace("DWC_GasolinCurse.exe", "");

        /// <summary>
        /// Initialize Main Window
        /// </summary>
        public MainWindow()
        {
            try
            {

                if (!Directory.Exists(Save_Path + @"DWC_GasolinCurse"))
                {
                    Directory.CreateDirectory(Save_Path + @"DWC_GasolinCurse");
                }

                InitializeComponent();
                mainWindow = this;

                MainWindow.mainWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
                MainWindow.mainWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
                MainWindow.mainWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

                WindowOverlayManager.updateAllWindowContent(this.DWC_Gasoline);

                // manager.JsonManager.loadGasolinPrices();
                manager.JsonManager.loadGasolinPostcode();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace + "\n" + e.Source + "\n" + e.Data);
                MessageBox.Show(e.Message + "\n" + e.Source);
            }

        }

        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MainWindow.mainWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                MainWindow.mainWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                MainWindow.mainWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

    }
}
