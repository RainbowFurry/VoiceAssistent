using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Account
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Account()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Account);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Account_FirstName_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_FirstName_Text");
            settingsWindow.Account_SecondName_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_SecondName_Text");
            settingsWindow.Account_Cuntry_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_Cuntry_Text");
            settingsWindow.Account_City_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_City_Text");
            settingsWindow.Account_Street_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_Street_Text");
            settingsWindow.Account_PLZ_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_PLZ_Text");
            settingsWindow.Account_HouseNumber_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_HouseNumber_Text");
            settingsWindow.Account_PartOfUs_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_PartOfUs_Text");
            settingsWindow.Account_Gender_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_Gender_Text");
            settingsWindow.Account_Birthday_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_Birthday_Text");
            settingsWindow.Account_InfoText.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_InfoText");
            settingsWindow.Account_EditAddress.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_EditAddress");
            settingsWindow.Account_EditPersonalData.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_EditPersonalData");
            settingsWindow.Account_EditProfilePicture.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_EditProfilePicture");
            settingsWindow.Account_ResetProfilePicture.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_ResetProfilePicture");
            settingsWindow.Account_ChangeNickname.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_ChangeNickname");
            settingsWindow.Account_ChangeNickname_Info.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Account_ChangeNickname_Info");
        }

        private void loadColors()
        {
            settingsWindow.Account.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Account_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Account_Spacer_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Account_Spacer_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Account_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Account_ButtonRectangle_1.Stroke = ProjectVariables.MainColor;
            settingsWindow.Account_ButtonRectangle_2.Stroke = ProjectVariables.MainColor;
            settingsWindow.Account_ButtonRectangle_3.Stroke = ProjectVariables.MainColor;
            settingsWindow.Account_ButtonRectangle_4.Stroke = ProjectVariables.MainColor;
            settingsWindow.Account_ButtonRectangle_5.Stroke = ProjectVariables.MainColor;
        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/white/profile_white.svg", Settings.SettingsWindow.Account_ProfilePicture);
        }

        private void loadSettings()
        {
            //
        }

        public static void saveSettings()
        {
            //
        }
        #endregion

    }
}
