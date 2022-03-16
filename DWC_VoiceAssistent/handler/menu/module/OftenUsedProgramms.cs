using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.menu.module
{
    class OftenUsedProgramms
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private MainWindow mainWindow = MainWindow.mainWindow;
        private static readonly string save_path = MainWindow.Save_Path + "OftenUsedProgramms.dwc";
        private static string[] content;

        public OftenUsedProgramms()
        {
            loadDB();
            mainWindow.AddOftenUserPrograms.MouseLeftButtonDown += addNewProgramm;

            if (File.Exists(save_path))
            {
                content = File.ReadAllLines(save_path);

                for (int i = 0; i < content.Length; i++)
                {
                    if (content[i] == "")
                    {
                        content[i] = null;
                    }
                }

                if (content.Length > 0)
                {
                    loadOftenUsedProgramms();
                }

            }

        }

        private void loadDB()
        {
            mainWindow.AddFavoritApp.Content = db.DBManager.loadDBValue("AddFavoritApp");
            mainWindow.FavoritApps.Content = db.DBManager.loadDBValue("FavoritApps");
        }

        private void loadOftenUsedProgramms()
        {

            mainWindow.OftenUsedProgramms.Children.Clear();

            for (int i = 0; i < content.Length; i++)
            {

                if (!string.IsNullOrEmpty(content[i]))
                {
                    Grid grid = new Grid
                    {
                        Height = 40,
                        Name = "OftenInUse_" + i.ToString()//get index or name
                    };
                    //grid.Height = 100;
                    //grid.Width = 300;
                    grid.MouseLeftButtonDown += openProgrammOnClick;

                    Label label = new Label();
                    string[] test = content[i].Replace(@"\", "/").Split('/');
                    string result = test[test.Length - 1];
                    label.Content = result.Replace(".exe", "");//replace path
                    label.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    label.Margin = new Thickness(50, 7, 0, 0);

                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 32;
                    rectangle.Height = 32;
                    rectangle.Margin = new Thickness(0, 7, 160, 0);
                    System.Drawing.Icon appIcon = System.Drawing.Icon.ExtractAssociatedIcon(content[i]);
                    ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(appIcon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(imageSource);

                    grid.Children.Add(rectangle);
                    grid.Children.Add(label);

                    mainWindow.OftenUsedProgramms.Children.Add(grid);
                }
            }

        }

        private void addNewProgramm(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "exe files (*.exe)|*.exe";
            openFileDialog.ShowDialog();

            //if (!File.Exists(save_path))
            //    File.Create(save_path);

            File.AppendAllText(save_path, openFileDialog.FileName + "\n");

            content = File.ReadAllLines(save_path);

            loadOftenUsedProgramms();
        }

        private void openProgrammOnClick(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = content[Convert.ToInt32(grid.Name.Replace("OftenInUse_", ""))];
            Process proc = Process.Start(processStartInfo);
        }

    }
}
