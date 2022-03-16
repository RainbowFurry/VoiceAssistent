using DarkWolfCraftSys;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace DWC_VoiceAssistent.handler.voice
{
    class VoiceRecognitionListeningAnimation
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static MainWindow mainWindow = MainWindow.mainWindow;

        public static void startListeningAnimation()
        {
            Task.Run(() =>
            {

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    mainWindow.DWC_Mainwindow_Talk_Active_1.Visibility = Visibility.Visible;
                    mainWindow.DWC_Mainwindow_Talk_Active_2.Visibility = Visibility.Visible;
                    mainWindow.DWC_Mainwindow_Talk_Active_3.Visibility = Visibility.Visible;
                    mainWindow.DWC_Mainwindow_Talk_Active_4.Visibility = Visibility.Visible;
                }), DispatcherPriority.Render);
                Thread.Sleep(100);

            });
        }

        public static void stopListeningAnimation()
        {
            Task.Run(() =>
            {

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    mainWindow.DWC_Mainwindow_Talk_Active_1.Visibility = Visibility.Hidden;
                    mainWindow.DWC_Mainwindow_Talk_Active_2.Visibility = Visibility.Hidden;
                    mainWindow.DWC_Mainwindow_Talk_Active_3.Visibility = Visibility.Hidden;
                    mainWindow.DWC_Mainwindow_Talk_Active_4.Visibility = Visibility.Hidden;
                }), DispatcherPriority.Render);
                Thread.Sleep(100);

            });
        }

    }
}
