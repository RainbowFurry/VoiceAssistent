using DarkWolfCraftSys;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DWC_VoiceAssistent.handler.menu.userquickview
{
    class OnlineState
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private MainWindow mainWindow = MainWindow.mainWindow;

        public OnlineState()
        {

            mainWindow.User_Profile_OnlineStatus.MouseLeftButtonDown += OnlineState_Clicked;

        }

        private void OnlineState_Clicked(object sender, MouseButtonEventArgs e)
        {

            Grid grid = new Grid();
            grid.Width = 200;
            grid.Height = 200;
            grid.Margin = new System.Windows.Thickness(0,830,1500,0);

            System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
            rectangle.Fill = ProjectVariables.Theme_MiddleDark;
            rectangle.RadiusX = 15;
            rectangle.RadiusY = 15;
            grid.Children.Add(rectangle);

            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.Height = grid.Height;
            scrollViewer.Width = grid.Width;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Height = grid.Height;
            stackPanel.Width = grid.Width;
            scrollViewer.Content = stackPanel;
            grid.Children.Add(scrollViewer);
            mainWindow.BackgroundImage.Children.Add(grid);


            //----
            Grid grid1 = new Grid();
            grid1.Height = 50;

            Image image = new Image();

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(MainWindow.Save_Path + @"src\onlinestate\Online.png");
            bi3.EndInit();
            image.Source = bi3;

            image.Width = 24;
            image.Height = 24;
            image.Margin = new System.Windows.Thickness(0,0,140,0);
            grid1.Children.Add(image);

            Label label = new Label();
            label.Content = "Online";
            label.Margin = new System.Windows.Thickness(60, 0, 0, 0);
            label.Foreground = ProjectVariables.Theme_LightBackground;
            label.FontSize = 22;
            grid1.Children.Add(label);

            stackPanel.Children.Add(grid1);

            //--
            Grid grid2 = new Grid();
            grid2.Height = 50;

            Image image1 = new Image();

            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri(MainWindow.Save_Path + @"src\onlinestate\Abwesend.png");
            bi4.EndInit();
            image1.Source = bi4;

            image1.Width = 24;
            image1.Height = 24;
            image1.Margin = new System.Windows.Thickness(0, 0, 140, 0);
            grid2.Children.Add(image1);

            Label label2 = new Label();
            label2.Content = "Abwesend";
            label2.Margin = new System.Windows.Thickness(60, 0, 0, 0);
            label2.Foreground = ProjectVariables.Theme_LightBackground;
            label2.FontSize = 22;
            grid2.Children.Add(label2);

            stackPanel.Children.Add(grid2);

            //--
            Grid grid3 = new Grid();
            grid3.Height = 50;

            Image image2 = new Image();

            BitmapImage bi5 = new BitmapImage();
            bi5.BeginInit();
            bi5.UriSource = new Uri(MainWindow.Save_Path + @"src\onlinestate\Beschäftigt.png");
            bi5.EndInit();
            image2.Source = bi5;

            image2.Width = 24;
            image2.Height = 24;
            image2.Margin = new System.Windows.Thickness(0, 0, 140, 0);
            grid3.Children.Add(image2);

            Label label3 = new Label();
            label3.Content = "Beschäftigt";
            label3.Margin = new System.Windows.Thickness(60, 0, 0, 0);
            label3.Foreground = ProjectVariables.Theme_LightBackground;
            label3.FontSize = 22;
            grid3.Children.Add(label3);

            stackPanel.Children.Add(grid3);

            //--
            Grid grid4 = new Grid();
            grid4.Height = 50;

            Image image4 = new Image();

            BitmapImage bi6 = new BitmapImage();
            bi6.BeginInit();
            bi6.UriSource = new Uri(MainWindow.Save_Path + @"src\onlinestate\Offline.png");
            bi6.EndInit();
            image4.Source = bi6;

            image4.Width = 24;
            image4.Height = 24;
            image4.Margin = new System.Windows.Thickness(0, 0, 140, 0);
            grid4.Children.Add(image4);

            Label label5 = new Label();
            label5.Content = "Offline";
            label5.Margin = new System.Windows.Thickness(60, 0, 0, 0);
            label5.Foreground = ProjectVariables.Theme_LightBackground;
            label5.FontSize = 22;
            grid4.Children.Add(label5);

            stackPanel.Children.Add(grid4);

        }

    }
}
