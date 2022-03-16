using DWC_VoiceAssistent.manager;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Windows.Input;

namespace DWC_VoiceAssistent.handler.projects.login
{
    class WindowControlerRegisterConfirm
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public WindowControlerRegisterConfirm()
        {
            loadDB();

            Login.loginWindow.CancelRegistration.MouseLeftButtonDown += CancelRegistration_Click;
            Login.loginWindow.ResendCode.MouseLeftButtonDown += ResendCode_Click;
            Login.loginWindow.Confirm_Button.MouseLeftButtonDown += ConfirmRegister;
        }

        private void loadDB()
        {
            Login.loginWindow.CancelRegistration.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegisterConfirm("CancelRegistration");
            Login.loginWindow.ResendCode.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegisterConfirm("ResendCode");
            Login.loginWindow.Email_Info.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegisterConfirm("Email_Info");
            Login.loginWindow.Confirm_ButtonText.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegisterConfirm("Confirm_ButtonText");
            Login.loginWindow.Code_Info.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegisterConfirm("Code_Info");
            Login.loginWindow.RegisterConfirm_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegisterConfirm("RegisterConfirm_Text");

        }

        private void CancelRegistration_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.DWC_ConfirmRegister.Visibility = System.Windows.Visibility.Hidden;
            Login.loginWindow.DWC_Login.Visibility = System.Windows.Visibility.Visible;
        }

        private void ResendCode_Click(object sender, MouseButtonEventArgs e)
        {
            SocketManager.Send("resent_register_code", Login.loginWindow.Email_Register.Text);
        }

        private void ConfirmRegister(object sender, MouseButtonEventArgs e)
        {
            SocketManager.Send("confirm_register", Login.loginWindow.Email_Register.Text + "," + Login.loginWindow.Code.Text);
        }

    }
}
