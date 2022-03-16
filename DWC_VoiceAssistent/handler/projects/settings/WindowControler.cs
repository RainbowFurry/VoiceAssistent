using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.projects.settings.categories;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.settings
{
    class WindowControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public WindowControler()
        {
            loadImages();
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.BackgroundImage);

            loadDB(); //load DB
            loadSettings();//load Settings

            //ADD First Selected Menu to the Change Selected Menu List
            oldHashRectangle = settingsWindow.Selected;
            oldHashColor = settingsWindow.Selected.Fill;

            settingsWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            settingsWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            settingsWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

            //Select Start Point
            settingsWindow.Selected.Fill = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            unloadMenu();
            settingsWindow.Design.Visibility = Visibility.Visible;
            new Desighn();

            //Load Menu Click Events
            for (int i = 0; i < settingsWindow.SettingsMenu.Children.Count; i++)
            {
                Grid grid = settingsWindow.SettingsMenu.Children[i] as Grid;
                grid.MouseLeftButtonDown += loadMenu;
            }

            settingsWindow.Save.MouseLeftButtonDown += DWC_Settings_Save_Button_Click;
            settingsWindow.DWC_Window.KeyDown += DWC_Setttings_Save_ESC;

            // settingsWindow.DWC_ThemeColor_Click.MouseLeftButtonDown += ChangeThemeColor_Click;//Change ThemeColor

            settingsWindow.DWC_AgeSelection_Click.MouseLeftButtonDown += ChangeAge;//Age
            settingsWindow.DWC_GenderSelection_Click.MouseLeftButtonDown += ChangeGender;//Gender

            //Register SEARCH UPDATE ........

        }

        private void loadImages()
        {

            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", Settings.SettingsWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", Settings.SettingsWindow.Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", Settings.SettingsWindow.Window_Minimize);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", Settings.SettingsWindow.IDK);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", Settings.SettingsWindow.IDK2);
            ProjectVariables.LoadSvgImage("src/own/Close_Gray.svg", Settings.SettingsWindow.IDK3);
        }

        private static void setGridColor()
        {

            settingsWindow.SettingsContentGrid.Background = ProjectVariables.Theme_DarkBackground;
            settingsWindow.Menu_Grid.Background = ProjectVariables.Theme_DarkBackground;

        }

        private Brush oldHashColor;
        private Rectangle oldHashRectangle;

        private void loadMenu(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Grid grid = sender as Grid;
            System.Windows.Controls.Label label = grid.Children[1] as System.Windows.Controls.Label;
            Rectangle rectangle = grid.Children[0] as Rectangle;

            if (label.Content.ToString() != DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Logout") &&
                label.Content.ToString() != DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ProgrammFunctions_Text") &&
                label.Content.ToString() != DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ProgrammView_Text") &&
                label.Content.ToString() != DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_UserMode_Text"))
            {

                unloadMenu();

                //Console.WriteLine("Settings-Menu-Point-Clicked - " + label.Content.ToString());

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_InGameOverlay_Text"))
                {
                    settingsWindow.InGameOverlay.Visibility = Visibility.Visible;
                    new InGameOverlay();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Messages_Text"))
                {
                    settingsWindow.Notification.Visibility = Visibility.Visible;
                    new Notification();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_VideoAndAudio_Text"))
                {
                    settingsWindow.Mikro.Visibility = Visibility.Visible;
                    new Microphone();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ResetSettings_Heading"))
                {
                    settingsWindow.ResetSettings.Visibility = Visibility.Visible;
                    new ResetSettings();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Devices_Text"))
                {
                    settingsWindow.Devices.Visibility = Visibility.Visible;
                    new Devices();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ClientStart_Heading"))
                {
                    settingsWindow.ClientStart.Visibility = Visibility.Visible;
                    new ClientStart();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_Heading"))
                {
                    settingsWindow.Updates.Visibility = Visibility.Visible;
                    new Updates();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_EditorsMode_Heading"))
                {
                    settingsWindow.EditrosMode.Visibility = Visibility.Visible;
                    new UserMode();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Account_Text"))
                {
                    settingsWindow.Account.Visibility = Visibility.Visible;
                    new Account();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ConnectedAccount_Text"))
                {
                    settingsWindow.ConnectedAccounts.Visibility = Visibility.Visible;
                    new ConnectedAccounts();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Assistent"))
                {
                    settingsWindow.Assistent.Visibility = Visibility.Visible;
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Desighn"))
                {
                    settingsWindow.Design.Visibility = Visibility.Visible;
                    new Desighn();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Eula"))
                {
                    //?
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_HotKeys_Text"))
                {
                    settingsWindow.HotKeys.Visibility = Visibility.Visible;
                    new HotKey();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Language_Text"))
                {
                    settingsWindow.Language_ContentGrid.Visibility = Visibility.Visible;
                    new Language();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Logout"))
                {
                    //
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Microphone"))
                {
                    settingsWindow.Mikro.Visibility = Visibility.Visible;
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Privacy_Text"))
                {
                    settingsWindow.Privacy.Visibility = Visibility.Visible;
                    new Privacy();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Security"))
                {
                    settingsWindow.Security.Visibility = Visibility.Visible;
                    new Security();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_PaymentMethodes_Text"))
                {
                    settingsWindow.PaymentMehtodes.Visibility = Visibility.Visible;
                    new Payments();
                }

                if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_YourPaments_Text"))
                {
                    settingsWindow.YourPayment.Visibility = Visibility.Visible;
                    new YourPayments();
                }

                if (oldHashColor != null)
                {
                    oldHashRectangle.Fill = oldHashColor;
                }
                else
                {
                    if (oldHashRectangle != null)
                        oldHashRectangle.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }

                oldHashRectangle = rectangle;
                oldHashColor = rectangle.Fill;
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));

            }

        }

        private void unloadMenu()
        {
            for (int i = 2; i < settingsWindow.SettingsContentGrid.Children.Count; i++)
            {
                Grid grid = settingsWindow.SettingsContentGrid.Children[i] as Grid;

                if (grid.Visibility == Visibility.Visible)
                    grid.Visibility = Visibility.Hidden;
            }
        }

        #region DB
        private void loadDB()
        {

            #region Menu
            settingsWindow.DWC_Menu_Reset_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ResetSettings_Heading");
            settingsWindow.DWC_Menu_ProgrammStart_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ClientStart_Heading");
            settingsWindow.DWC_Menu_Language_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Language_Text");
            settingsWindow.DWC_Menu_EditorsMode_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_EditorsMode_Heading");
            settingsWindow.SaveText.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("SaveText");
            settingsWindow.SettingsHeading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("SettingsHeading");
            settingsWindow.DWC_Menu_Account_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Account_Text");
            settingsWindow.DWC_Menu_ConnectedAccount_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ConnectedAccount_Text");
            settingsWindow.DWC_Menu_Security_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Security_Text");
            settingsWindow.DWC_Menu_Devices_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Devices_Text");
            settingsWindow.DWC_Menu_Privacy_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Privacy_Text");
            settingsWindow.DWC_Menu_YourPaments_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_YourPaments_Text");
            settingsWindow.DWC_Menu_UserMode_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_UserMode_Text");
            settingsWindow.DWC_Menu_ProgrammView_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ProgrammView_Text");
            settingsWindow.DWC_Menu_Design_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Desighn");
            settingsWindow.DWC_Menu_Messages_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Messages_Text");
            settingsWindow.DWC_Menu_InGameOverlay_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_InGameOverlay_Text");
            settingsWindow.DWC_Menu_ProgrammFunctions_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ProgrammFunctions_Text");
            settingsWindow.DWC_Menu_ProgrammStart_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ProgrammStart_Text");
            settingsWindow.DWC_Menu_Updates_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Updates_Text");
            settingsWindow.DWC_Menu_VideoAndAudio_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_VideoAndAudio_Text");
            settingsWindow.DWC_Menu_HotKeys_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_HotKeys_Text");
            settingsWindow.DWC_Menu_PaymentMethodes_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_PaymentMethodes_Text");
            settingsWindow.DWC_Settings_Menu_Logout.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Logout");
            #endregion

            #region Assistenet
            //Heading
            settingsWindow.DWC_Grid_Heading_VoiceAssistent_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Menu_Assistent");
            //Gender
            settingsWindow.DWC_VoiceAssistent_Voice_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Chapter_Voice");
            //Age
            settingsWindow.DWC_VoiceAssistent_Age_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Chapter_Voice_Age_Text");
            #endregion

        }
        #endregion

        #region Load/Save Settings
        /// <summary>
        /// Load the Settings from Config
        /// </summary>
        private void loadSettings()
        {
            VoiceAssistent.loadSettings();

            //volum
            //settingsWindow.DWC_Settings_Volum.Value = Convert.ToDouble(ConfigManager.volum);

            //version
            //settingsWindow.DWC_Settings_Version.Content = ConfigManager.pruductversion;

            LogFileManager.createLogEntrence("DWC_VoiceAssistent Settings: has been successfully loaded");

        }

        /// <summary>
        /// Save the Settings to Config and refresh Programm Settings
        /// </summary>
        private void saveSettings()
        {
            Account.saveSettings();
            ClientStart.saveSettings();
            ConnectedAccounts.saveSettings();
            Desighn.saveSettings();
            Devices.saveSettings();
            HotKey.saveSettings();
            InGameOverlay.saveSettings();
            Language.saveSettings();
            Microphone.saveSettings();
            Notification.saveSettings();
            Payments.saveSettings();
            Privacy.saveSettings();
            Security.saveSettings();
            Updates.saveSettings();
            UserMode.saveSettings();
            YourPayments.saveSettings();

            ConfigManager.SaveConfigValues();

            WindowOverlayManager.updateAllWindowContent(MainWindow.mainWindow.BackgroundImage);

            NotificationMessage.successNotification(DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_SaveMessageHeading"), DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_SaveMessage"));
            LogFileManager.createLogEntrence("DWC_VoiceAssistent Settings: Has been successfully saved");

        }

        #endregion


        #region Button Change on Click
        /// <summary>
        /// Change Check Box checked or unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DWC_CheckBox_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle rectangle = (System.Windows.Shapes.Rectangle)sender;

            if (rectangle.Fill == new ImageBrush(new BitmapImage(new Uri(@"src/icons/checked.png"))))
            {
                rectangle.Fill = new ImageBrush(new BitmapImage(new Uri(@"src/icons/checked.png")));
            }
            else
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"src/icons/cross_dark.png", UriKind.Relative));
                rectangle.Fill = imgBrush;
            }
        }

        /// <summary>
        /// Change the selected Age
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeAge(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (settingsWindow.DWC_Age_Selection.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Age_Selection_Adult"))
            {
                settingsWindow.DWC_Age_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Age_Selection_Child");
            }
            else
            {
                settingsWindow.DWC_Age_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Age_Selection_Adult");
            }
        }

        /// <summary>
        /// Change the selected Gender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeGender(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (settingsWindow.DWC_Gender_Selection.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Voice_Selection_Male"))
            {
                settingsWindow.DWC_Gender_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Voice_Selection_Female");
            }
            else
            {
                settingsWindow.DWC_Gender_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Voice_Selection_Male");
            }
        }
        #endregion


        #region SaveButton
        /// <summary>
        /// Save all Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DWC_Settings_Save_Button_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            saveSettings();
            settingsWindow.Hide();
        }

        /// <summary>
        /// Save all Settings by clicking ESC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DWC_Setttings_Save_ESC(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                saveSettings();
                settingsWindow.Hide();
            }
        }
        #endregion

        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            settingsWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (settingsWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                settingsWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                settingsWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            settingsWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

    }
}
