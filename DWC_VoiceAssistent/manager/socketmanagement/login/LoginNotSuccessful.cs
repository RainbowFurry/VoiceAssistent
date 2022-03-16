using DWC_VoiceAssistent.handler.notificationwindow.windows;
using DWC_VoiceAssistent.projects.system;
using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.login
{
    class LoginNotSuccessful
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public LoginNotSuccessful()
        {
            if (Login.loginWindow == null || Login.loginWindow.Visibility == Visibility.Hidden)
                new Login().Show();
            WrongLogin wrongLogin = new WrongLogin();
            wrongLogin.Show();
        }

    }
}
