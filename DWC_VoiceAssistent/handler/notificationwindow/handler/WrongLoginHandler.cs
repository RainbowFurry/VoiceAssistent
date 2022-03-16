using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.notificationwindow.windows;
using System;
using System.Windows.Input;

namespace DWC_VoiceAssistent.handler.notificationwindow.handler
{
    class WrongLoginHandler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private WrongLogin wrongLoginWindow = WrongLogin.wrongLoginWindow;

        public WrongLoginHandler()
        {
            loadDB();
            loadColor();

            wrongLoginWindow.OK_Grid.MouseLeftButtonDown += OK_Click;

        }

        private void loadDB()
        {
            wrongLoginWindow.OK_Text.Content = db.DBManager.loadDBValueWrongLogin("OK_Text");
            wrongLoginWindow.HelpMessage.Text = db.DBManager.loadDBValueWrongLogin("HelpMessage");
            wrongLoginWindow.ErrorMessage.Text = db.DBManager.loadDBValueWrongLogin("ErrorMessage");
        }

        private void loadColor()
        {
            wrongLoginWindow.OK_Text.Foreground = ProjectVariables.MainColor;
            wrongLoginWindow.OK_Rectangle.Stroke = ProjectVariables.MainColor;
        }

        private void OK_Click(object sender, MouseButtonEventArgs e)
        {
            WrongLogin.wrongLoginWindow.Close();
        }

    }
}
