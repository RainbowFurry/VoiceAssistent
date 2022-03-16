using DarkWolfCraftSys;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.music.menu
{
    class WindowControler
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public WindowControler()
        {
            MainWindow.mainWindow.DWC_Music_Menu_Toggle.MouseLeftButtonDown += DWC_Music_Menu_Toggle_Click;
            MainWindow.mainWindow.DWC_Music_Menu_Skip_Forward.MouseLeftButtonDown += DWC_Music_Menu_Skip_Forward_Click;
            MainWindow.mainWindow.DWC_Music_Menu_Play.MouseLeftButtonDown += DWC_Music_Menu_Play_Click;
            MainWindow.mainWindow.DWC_Music_Menu_Skip_Backward.MouseLeftButtonDown += DWC_Music_Menu_Skip_Backward_Click;
        }


        private void DWC_Music_Menu_Toggle_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SlideObject slide = new SlideObject();
            Image image = sender as Image;
            Grid grid = image.Parent as Grid;
            if (grid.Width != 30)
            {
                slide.Slide(grid, Convert.ToInt32(grid.Width), 30, new TimeSpan(0, 0, 0, 1), FrameworkElement.WidthProperty, image, new Thickness(0, 30, 0, 0), new RotateTransform(360));
            }
            else
            {
                slide.UnSlide(grid, 30, 375, new TimeSpan(0, 0, 0, 1), FrameworkElement.WidthProperty, image, new Thickness(340, 30, 0, 0), new RotateTransform(180));
            }
        }

        private void DWC_Music_Menu_Skip_Forward_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void DWC_Music_Menu_Play_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void DWC_Music_Menu_Skip_Backward_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

    }
}
