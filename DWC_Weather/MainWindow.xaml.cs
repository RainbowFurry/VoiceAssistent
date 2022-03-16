using DarkWolfCraftSys;
using DWC_Weather.manager;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DWC_Weather
{

    public partial class MainWindow : Window
    {
        //https://openweathermap.org/current

        public static MainWindow mainWindow;
        public static string Save_Path = Assembly.GetExecutingAssembly().Location.Replace(@"DWC_Weather.exe", "");

        public MainWindow()
        {

            try
            {
                InitializeComponent();
                mainWindow = this;

                MainWindow.mainWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
                MainWindow.mainWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
                MainWindow.mainWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

                WindowOverlayManager.updateAllWindowContent(this.DWC_Weather);
                //manager.JsonManager.getWeatherWithZipCode("71691");
                JsonManager.getWeatherWithGeoLocation();
                loadDaylyMainInfo();
                loadDB();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace + "\n" + e.Source + "\n" + e.InnerException);
            }

        }

        /// <summary>
        /// Load the actual dayly Top Info about your Location
        /// </summary>
        private static void loadDaylyMainInfo()
        {

            MainWindow mainWindow = MainWindow.mainWindow;

            mainWindow.DWC_Weather_Date.Content = DateTime.Now.ToLongDateString();
            mainWindow.DWC_Daily_TempMax.Content = db.DatabaseManager.loadDBValue("DWC_Daily_TempMax") + Weather.Info.tempMax + " °C";
            mainWindow.DWC_Daily_TempMin.Content = db.DatabaseManager.loadDBValue("DWC_Daily_TempMin") + Weather.Info.tempMin + " °C";
            mainWindow.DWC_Daily_WeatherDescription.Content = Weather.Info.weather;
            mainWindow.DWC_Daily_WindSpeed.Content = db.DatabaseManager.loadDBValue("DWC_Daily_WindSpeed") + Weather.Info.wind + " m/s";
            mainWindow.DWC_Daily_City.Content = Weather.Info.cityName;
            mainWindow.DWC_Daily_TempActual.Content = Weather.Info.temp + " °C";
            mainWindow.DWC_Daily_Clouds.Content = db.DatabaseManager.loadDBValue("DWC_Daily_Clouds") + Weather.Info.clouds + " %";

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("http://openweathermap.org/img/wn/" + Weather.Info.iconID + "@2x.png");//10 = id | d = tag n = nacht
            bitmapImage.EndInit();
            mainWindow.DWC_Daily_WeatherIcon.Source = bitmapImage;

        }

        private void loadDB()
        {
            mainWindow.DWC_ChangeLocation.Text = db.DatabaseManager.loadDBValue("DWC_ChangeLocation");
            mainWindow.DWC_LocationDescription.Content = db.DatabaseManager.loadDBValue("DWC_LocationDescription");
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
