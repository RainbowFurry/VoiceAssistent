using DWC_VoiceAssistent.manager;
using DWC_VoiceAssistent.projects.system;
using System.Windows;

namespace DWC_VoiceAssistent.handler.projects.login
{
    class WindowControlerLogin
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public WindowControlerLogin()
        {
            loadDB();

            Login.loginWindow.Register.MouseLeftButtonDown += Register_Click;

            Login.loginWindow.Login_Button.MouseLeftButtonDown += Login_Click;

            Login.loginWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            Login.loginWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            Login.loginWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

        }

        private void loadDB()
        {
            Login.loginWindow.Register.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLogin("Register");
            Login.loginWindow.Login_Text_Button.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLogin("Login_Text_Button");
            Login.loginWindow.Login_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLogin("Login_Text");
        }

        /// <summary>
        /// Open the Registration Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.DWC_Login.Visibility = System.Windows.Visibility.Hidden;
            Login.loginWindow.DWC_Register.Visibility = System.Windows.Visibility.Visible;
        }

        private void Login_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string email = Login.loginWindow.Login_Email.Text;
            string password = Login.loginWindow.Login_Password.Password;
            SocketManager.Send("login_request", email + "," + CredentialHandler.ComputeSha256Hash(password));
        }


        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Login.loginWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                Login.loginWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                Login.loginWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

    }
}
