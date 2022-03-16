using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shell;

namespace DWC_VoiceAssistent.handler.menu.taskbar
{
    class ThumbnailToolbar
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static string save_path_onlinestate = Assembly.GetEntryAssembly().Location.Replace("DWC_VoiceAssistent.exe", "") + @"src\onlinestate\";
        private static TaskbarItemInfo taskbarItemInfo;

        /// <summary>
        /// Initialize and Create Thumbnail Entrie Options
        /// </summary>
        public static void createThumbnailToolbar()
        {
            taskbarItemInfo = new TaskbarItemInfo();
            //createTaskbarThumbnail();

            ThumbnailToolBarButton status_online = new ThumbnailToolBarButton(createThumbnailImage("Online"), db.DBManager.loadDBValueThumbnailToolbar("Online"));
            status_online.Click += changeOnlineState;
            ThumbnailToolBarButton status_afk = new ThumbnailToolBarButton(createThumbnailImage("Abwesend"), db.DBManager.loadDBValueThumbnailToolbar("AFK"));
            status_afk.Click += changeOnlineState;
            ThumbnailToolBarButton status_busy = new ThumbnailToolBarButton(createThumbnailImage("Beschäftigt"), db.DBManager.loadDBValueThumbnailToolbar("Busy"));
            status_busy.Click += changeOnlineState;
            ThumbnailToolBarButton status_offline = new ThumbnailToolBarButton(createThumbnailImage("Offline"), db.DBManager.loadDBValueThumbnailToolbar("Offline"));
            status_offline.Click += changeOnlineState;

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(new WindowInteropHelper(MainWindow.mainWindow).Handle, status_online, status_afk, status_busy, status_offline);
            
        }

        /// <summary>
        /// Create TaskBar Thumbnail
        /// </summary>
        public static void createTaskbarThumbnail()
        {

            taskbarItemInfo.Overlay = ToImageSource(createThumbnailImage("Online"));
            MainWindow.mainWindow.TaskbarItemInfo = taskbarItemInfo;

        }

        private static void changeOnlineState(object sender, ThumbnailButtonClickedEventArgs e)
        {

            if(e.ThumbnailButton.Tooltip == db.DBManager.loadDBValueThumbnailToolbar("Online"))
            {
                taskbarItemInfo.Overlay = ToImageSource(createThumbnailImage("Online"));
                MainWindow.mainWindow.TaskbarItemInfo = taskbarItemInfo;
            }

            if(e.ThumbnailButton.Tooltip == db.DBManager.loadDBValueThumbnailToolbar("AFK"))
            {
                taskbarItemInfo.Overlay = ToImageSource(createThumbnailImage("Abwesend"));
                MainWindow.mainWindow.TaskbarItemInfo = taskbarItemInfo;
            }

            if (e.ThumbnailButton.Tooltip == db.DBManager.loadDBValueThumbnailToolbar("Busy"))
            {
                taskbarItemInfo.Overlay = ToImageSource(createThumbnailImage("Beschäftigt"));
                MainWindow.mainWindow.TaskbarItemInfo = taskbarItemInfo;
            }

            if (e.ThumbnailButton.Tooltip == db.DBManager.loadDBValueThumbnailToolbar("Offline"))
            {
                taskbarItemInfo.Overlay = ToImageSource(createThumbnailImage("Offline"));
                MainWindow.mainWindow.TaskbarItemInfo = taskbarItemInfo;
            }

        }

        /// <summary>
        /// Create Thumbnail Icon Image
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        private static Icon createThumbnailImage(String iconName)
        {
            Icon icon = new Icon(save_path_onlinestate + iconName + ".ico");
            return icon;
        }

        /// <summary>
        /// Convert Icon to ImageSource
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static ImageSource ToImageSource(Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }

    }
}
