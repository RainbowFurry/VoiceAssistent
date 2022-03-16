using DWC_VoiceAssistent.handler.projects.login;
using DWC_VoiceAssistent.projects.system;
using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.register
{
    class RegisterSuccess
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public RegisterSuccess()
        {
            Login.loginWindow.DWC_ConfirmRegister.Visibility = Visibility.Hidden;
            Login.loginWindow.DWC_Login.Visibility = Visibility.Visible;
            CredentialHandler.CreateUserCredentials(Login.loginWindow.Email_Register.Text, Login.loginWindow.User_Password.Password);
        }

    }
}
