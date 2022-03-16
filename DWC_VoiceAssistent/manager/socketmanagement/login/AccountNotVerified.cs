using DWC_VoiceAssistent.projects.system;
using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.login
{
    class AccountNotVerified
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public AccountNotVerified(string response)
        {
            if (Login.loginWindow == null || Login.loginWindow.Visibility == Visibility.Hidden)
                new Login().Show();
            MessageBox.Show("Dieser Account ist nicht verifiziert! (" + response + ")");
        }

    }
}
