using DWC_VoiceAssistent.manager;
using DWC_VoiceAssistent.projects.system;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.projects.login
{
    class WindowControlerRegister
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public WindowControlerRegister()
        {
            loadDB();

            Login.loginWindow.User_Password.MouseLeftButtonDown += GetClickedType;
            Login.loginWindow.User_PasswordEqual.MouseLeftButtonDown += GetClickedType;

            Login.loginWindow.User_Password.MouseLeftButtonUp += GetLeftType;
            Login.loginWindow.User_PasswordEqual.MouseLeftButtonUp += GetLeftType;

            Login.loginWindow.Cancel_Registration.MouseLeftButtonDown += CancelRegister;

            Login.loginWindow.User_Password.LostFocus += PasswordChange;
            Login.loginWindow.User_PasswordEqual.LostFocus += PasswordChange;

            Login.loginWindow.Create_Account.MouseLeftButtonDown += CreateAccount_Click;
            Login.loginWindow.Next_Step.MouseLeftButtonDown += NextStep_Click;
            Login.loginWindow.StepBack.MouseLeftButtonDown += StepBack_Click;
            Login.loginWindow.Create_Account_Text.MouseLeftButtonDown += CreateAccount;
        }

        private void CreateAccount(object sender, MouseButtonEventArgs e)
        {
            bool? agb = Login.loginWindow.AGB_Confirmation.IsChecked;
            if (agb.GetValueOrDefault() == false)
                return;

            string email = Login.loginWindow.Email_Register.Text;
            string username = Login.loginWindow.Username.Text;
            string password = CredentialHandler.ComputeSha256Hash(Login.loginWindow.User_Password.Password);
            string prename = Login.loginWindow.Register_Name.Text;
            string postname = Login.loginWindow.Register_NachName.Text;
            string telephone = Login.loginWindow.Register_Telefon.Text;
            string country = Login.loginWindow.Register_Land.Text;
            string street = Login.loginWindow.Register_Street.Text;
            string housenumber = Login.loginWindow.Register_HouseNumber.Text;
            string city = Login.loginWindow.Register_Stadt.Text;
            string plz = Login.loginWindow.Register_PLZ.Text;

            SocketManager.Send("register_request", email + "," + password + "," + username + "," + prename + "," + postname + "," + telephone + "," + country + "," + street + "," + housenumber + "," + city + "," + plz + "," + "," + "," + "," + "," + ",");
        }

        private void loadDB()
        {
            Login.loginWindow.CreateAccount_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("CreateAccount_Text");
            Login.loginWindow.Email_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Email_Description");
            Login.loginWindow.UserName_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("UserName_Description");
            Login.loginWindow.Password_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Password_Description");
            Login.loginWindow.PasswordEqual_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("PasswordEqual_Description");
            Login.loginWindow.Wish_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Wish_Text");
            Login.loginWindow.Cancel_Registration.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Cancel_Registration");
            Login.loginWindow.NextStep_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("NextStep_Text");

            Login.loginWindow.CreateAccount_Text1.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("CreateAccount_Text");
            Login.loginWindow.CreateAccount_Text1.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Wish_Text1");
            Login.loginWindow.Cancel_Registration1.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Cancel_Registration");
            Login.loginWindow.FirstName_description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("FirstName_description");
            Login.loginWindow.SecondName_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("SecondName_Description");
            Login.loginWindow.PhoneNumber_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("PhoneNumber_Description");
            Login.loginWindow.Cuntry_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Land_Description");
            Login.loginWindow.City_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("City_Description");
            Login.loginWindow.PLZ_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("PLZ_Description");
            Login.loginWindow.Street_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Street_Description");
            Login.loginWindow.HouseNumber_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("HouseNumber_Description");
            Login.loginWindow.AGB_Confirmation.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("AGB_Agreement");
            Login.loginWindow.Create_Account_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Create_Account_Text");
            Login.loginWindow.Wish_Text1.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueLoginRegister("Wish_Text");

        }

        /// <summary>
        /// Create the UserAccount if all Values are Correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccount_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {



        }

        /// <summary>
        /// Next register Step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextStep_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.PasswordEqual_Alert.Visibility = Visibility.Hidden;
            Login.loginWindow.Password_Alert.Visibility = Visibility.Hidden;

            bool EmailValid = new EmailAddressAttribute().IsValid(Login.loginWindow.Email_Register.Text);
            if (EmailValid)
            {
                bool PasswordValid = ValidPassword();
                if (PasswordValid)
                {
                    Login.loginWindow.Register_Step1.Visibility = Visibility.Hidden;
                    Login.loginWindow.Register_Step2.Visibility = Visibility.Visible;
                }
            }
            else
            {

            }
        }

        private bool ValidPassword()
        {
            PasswordBox password = Login.loginWindow.User_Password;
            if (!password.Password.Equals(Login.loginWindow.User_PasswordEqual.Password))
            {
                Login.loginWindow.PasswordEqual_Alert.Visibility = Visibility.Visible;
                return false;
            }
            if (password.Password.Length < 8)
            {
                Login.loginWindow.Password_Alert.Visibility = Visibility.Visible;
                return false;
            }
            if (!Regex.IsMatch(password.Password, "[a-z]") ||
                !Regex.IsMatch(password.Password, "[A-Z]") ||
                !Regex.IsMatch(password.Password, @"\d") ||
                !Regex.IsMatch(password.Password, @"[-_.,!§$%&/()=\\<>:?\{\}\[\]]"))
                return false;
            return true;
        }

        /// <summary>
        /// Go one Register Step back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepBack_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.Register_Step1.Visibility = Visibility.Visible;
            Login.loginWindow.Register_Step2.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Cancel the Registration and go back to the Login Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelRegister(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login.loginWindow.DWC_Register.Visibility = Visibility.Hidden;
            Login.loginWindow.DWC_Login.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Get the Clicked Field Type and Change Display Option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetClickedType(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Console.WriteLine(e.Source.GetType());

            if (e.Source.GetType() == typeof(TextBox))
            {
                TextBox textBox = sender as TextBox;

                if (textBox.Name == "User_Email")
                {
                    Login.loginWindow.Email_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 20, 114, 208));
                }

                if (textBox.Name == "User_Name")
                {
                    Login.loginWindow.UserName_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 20, 114, 208));
                }

            }

            if (e.Source.GetType() == typeof(PasswordBox))
            {
                PasswordBox passwordBox = sender as PasswordBox;

                if (passwordBox.Name == "User_Password")
                {
                    Login.loginWindow.Password_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 20, 114, 208));
                }

                if (passwordBox.Name == "User_PasswordEqual")
                {
                    Login.loginWindow.PasswordEqual_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 20, 114, 208));
                }

            }

        }

        /// <summary>
        /// Get the Clicked Field Type and Undo the Display Changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetLeftType(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(TextBox))
            {
                TextBox textBox = sender as TextBox;

                if (textBox.Name == "User_Email")
                {
                    Login.loginWindow.Email_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 85, 85, 87));
                }

                if (textBox.Name == "User_Name")
                {
                    Login.loginWindow.UserName_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 85, 85, 87));
                }

            }

            if (e.Source.GetType() == typeof(PasswordBox))
            {
                PasswordBox passwordBox = sender as PasswordBox;

                if (passwordBox.Name == "User_Password")
                {
                    Login.loginWindow.Password_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 85, 85, 87));
                }

                if (passwordBox.Name == "User_PasswordEqual")
                {
                    Login.loginWindow.PasswordEqual_Background.Stroke = new SolidColorBrush(Color.FromArgb(255, 85, 85, 87));
                }

                if (string.IsNullOrEmpty(passwordBox.Password))
                {
                    passwordBox.Password = "0123";
                }

            }
        }

        private void PasswordChange(object sender, RoutedEventArgs e)
        {

            PasswordBox password = sender as PasswordBox;

            if (password.Password.Equals("0000") || password.Password.Equals("0123"))
            {
                password.Password = "";
            }

            if (Login.loginWindow.PasswordSecurity.Visibility == Visibility.Hidden)
            {
                Login.loginWindow.PasswordSecurity.Visibility = Visibility.Visible;
            }

            if (password.Name == "User_Password")
            {
                if (password.Password != "0000" && password.Password != "0123")
                {

                    if (password.Password.Length < 3)
                    {
                        Login.loginWindow.PasswordSecurity.Fill = new SolidColorBrush(Color.FromArgb(255, 249, 39, 6));
                    }

                    if (password.Password.Length > 3 && password.Password.Length <= 7)
                    {
                        Login.loginWindow.PasswordSecurity.Fill = new SolidColorBrush(Color.FromArgb(255, 249, 116, 6));
                    }

                    if (password.Password.Length > 7)
                    {
                        Login.loginWindow.PasswordSecurity.Fill = new SolidColorBrush(Color.FromArgb(255, 71, 255, 53));
                    }

                }
                else
                {
                    Login.loginWindow.PasswordSecurity.Visibility = Visibility.Hidden;
                }
            }

        }

    }
}
