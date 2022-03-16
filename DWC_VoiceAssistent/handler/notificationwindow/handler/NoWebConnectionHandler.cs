using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.notificationwindow.windows;
using System;
using System.Windows.Input;

namespace DWC_VoiceAssistent.handler.notificationwindow.handler
{
    class NoWebConnectionHandler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        NoWebConnection noWebConnectionWindow = NoWebConnection.noWebConnectionWindow;

        public NoWebConnectionHandler()
        {
            loadDB();
            loadColor();

            noWebConnectionWindow.RetryButton_Text.MouseLeftButtonDown += Retry_Click;

        }

        private void loadDB()
        {
            noWebConnectionWindow.RetryButton_Text.Content = db.DBManager.loadDBValueNoWebConnection("RetryButton_Text");
            noWebConnectionWindow.ServerStatus.Text = db.DBManager.loadDBValueNoWebConnection("ServerStatus");
            noWebConnectionWindow.HelpMessage.Content = db.DBManager.loadDBValueNoWebConnection("HelpMessage");
            noWebConnectionWindow.ErrorMessage.Text = db.DBManager.loadDBValueNoWebConnection("ErrorMessage");
        }

        private void loadColor()
        {
            //LOAD ALL COLORS TO CHANGE THEM LATER...

            noWebConnectionWindow.RetryButton_Text.Foreground = ProjectVariables.MainColor;
            noWebConnectionWindow.RetryButton_Rectangle.Stroke = ProjectVariables.MainColor;
        }

        private void Retry_Click(object sender, MouseButtonEventArgs e)
        {
            //...
        }

    }
}
