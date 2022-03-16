using DWC_VoiceAssistent.projects.system;
using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.register
{
    class RegisterRequestSuccess
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public RegisterRequestSuccess()
        {
            Login.loginWindow.Register_Step2.Visibility = Visibility.Hidden;
            Login.loginWindow.DWC_ConfirmRegister.Visibility = Visibility.Visible;
        }

    }
}
