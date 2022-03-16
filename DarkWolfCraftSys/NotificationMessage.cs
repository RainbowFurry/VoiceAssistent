using Notification.Wpf;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace DarkWolfCraftSys
{
    public class NotificationMessage
    {

        /*
         * Creator: Jason H.
         * Date: -
         * Comment: -
         */

        public static IContainer components = new Container();
        public static NotifyIcon notifyIcon1 = new NotifyIcon(components);

        private static readonly NotificationManager notificationManager = new NotificationManager();

        /// <summary>
        /// Create an Windows Push Message with the default and given Values
        /// </summary>
        public static void Notification(string title, string message)
        {

            if (ConfigManager.desktopNotification)
            {
                //components = new System.ComponentModel.Container();
                //notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);

                notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

                notifyIcon1.Text = "DarkWolfCraft VoiceAssistent";
                notifyIcon1.Visible = true;

                // notification
                notifyIcon1.BalloonTipText = message;
                notifyIcon1.BalloonTipTitle = title;
                notifyIcon1.ShowBalloonTip(1000);

                LogFileManager.createLogEntrence("DWC_VoiceAssistent has Created and Sent a new PushNotification");

            }

        }

        /// <summary>
        /// Create an Windows Push Message with the default and given Values
        /// </summary>
        public static void Notification(string title, string message, int showtimer)
        {

            if (ConfigManager.desktopNotification)
            {
                //components = new System.ComponentModel.Container();
                //notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);

                notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

                notifyIcon1.Text = "DarkWolfCraft VoiceAssistent";
                notifyIcon1.Visible = true;

                // notification
                notifyIcon1.BalloonTipText = message;
                notifyIcon1.BalloonTipTitle = title;
                notifyIcon1.ShowBalloonTip(showtimer);

                LogFileManager.createLogEntrence("DWC_VoiceAssistent has Created and Sent a new PushNotification");

            }

        }


        #region WPF Addon Notification
        //https://github.com/Platonenkov/Notifications.Wpf

        public static void successNotification(string title, string message)
        {
            notificationManager.Show(title, message, NotificationType.Success);
        }

        public static void errorNotification(string title, string message)
        {
            notificationManager.Show(title, message, NotificationType.Error);
        }

        public static void warningNotification(string title, string message)
        {
            notificationManager.Show(title, message, NotificationType.Warning);
        }

        public static void infoNotification(string title, string message)
        {
            notificationManager.Show(title, message, NotificationType.Information);

        }



        public static void yesNoNotification(string title, string message)
        {
            //LANGUAGE TRANSLATE NEEDED
            notificationManager.Show(title, message, "", TimeSpan.MaxValue,
            (o, args) => notificationManager.Show("You selected YES", "", TimeSpan.FromSeconds(10)), "Yes",
            (o, args) => notificationManager.Show("You selected NO", "", TimeSpan.FromSeconds(10)), "No");
        }

        public static void textFieldNotification()
        {
            //mit einem Textfeld um Nachrichten zu senden

            var grid = new Grid();

            grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255,255,255,255));
            var text_block = new System.Windows.Controls.TextBox
            {
                Text = "Write your Friend a Message",
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                SelectionBrush = null,
                BorderThickness = new Thickness(0)
            };


            var panelBTN = new StackPanel { Height = 100, Margin = new Thickness(0, 40, 0, 0) };
            var btn1 = new System.Windows.Controls.Button { Width = 100, Height = 20, Content = "Send" };
            panelBTN.VerticalAlignment = VerticalAlignment.Bottom;
            panelBTN.Children.Add(btn1);

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());


            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            grid.Children.Add(text_block);
            grid.Children.Add(panelBTN);

            Grid.SetRow(panelBTN, 1);
            Grid.SetRow(text_block, 0);

            object content = grid;

            notificationManager.Show(content, null, TimeSpan.MaxValue);
        }

        public static void ratingNotification()
        {
            //um zu bewerten
        }

        public static void customNotification()
        {
            var grid = new Grid();
            var text_block = new TextBlock { Text = "Some Text", Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = System.Windows.HorizontalAlignment.Center };


            var panelBTN = new StackPanel { Height = 100, Margin = new Thickness(0, 40, 0, 0) };
            var btn1 = new System.Windows.Controls.Button { Width = 200, Height = 40, Content = "Cancel" };
            panelBTN.VerticalAlignment = VerticalAlignment.Bottom;
            panelBTN.Children.Add(btn1);

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());


            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            grid.Children.Add(text_block);
            grid.Children.Add(panelBTN);

            Grid.SetRow(panelBTN, 1);
            Grid.SetRow(text_block, 0);

            object content = grid;

            notificationManager.Show(content, null, TimeSpan.MaxValue);
        }
        #endregion

    }
}
