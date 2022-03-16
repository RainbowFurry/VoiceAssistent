using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Security
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Security()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Security);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Security_YourAccountActivity.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_YourAccountActivity");
            settingsWindow.Security_LastActivity.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_LastActivity");
            settingsWindow.Security_AllAktivities.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_AllAktivities");
            settingsWindow.Security_ConnectedEmail_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_ConnectedEmail_Heading");
            settingsWindow.Security_ConnectedEmail_Check.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_ConnectedEmail_Check");
            settingsWindow.Security_ConnectedEmail_ViewAccount.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_ConnectedEmail_ViewAccount");
            settingsWindow.Security_ConnectedEmail_ChangeAccount.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_ConnectedEmail_ChangeAccount");
            settingsWindow.Security_TwoFaktor_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_TwoFaktor_Heading");
            settingsWindow.Security_TwoFaktor_Check.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_TwoFaktor_Check");
            settingsWindow.Security_TwoFaktor_ChangeNumber.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_TwoFaktor_ChangeNumber");
            settingsWindow.Security_TwoFaktor_DisableTwoFaktor.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_TwoFaktor_DisableTwoFaktor");
            settingsWindow.Security_RecoveryEmail_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_RecoveryEmail_Heading");
            settingsWindow.Security_RecoveryEmail_Check.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_RecoveryEmail_Check");
            settingsWindow.Security_RecoveryEmail_ViewAccount.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_RecoveryEmail_ViewAccount");
            settingsWindow.Security_RecoveryEmail_ChangeAccount.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_RecoveryEmail_ChangeAccount");
            settingsWindow.Security_BackupCode_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_BackupCode_Heading");
            settingsWindow.Security_BackupCode_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_BackupCode_Description");
            settingsWindow.Security_BackupCode_View.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_BackupCode_View");
            settingsWindow.Security_BackupCode_Download.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Security_BackupCode_Download");
        }

        private void loadColors()
        {
            settingsWindow.Security.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Security_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Security_Rectangle_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Security_Rectangle_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Security_Rectangle_4.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Security_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Security_Spacer_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Security_Spacer_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.Security_ChangeProfile_Rectangle.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_ViewProfile_Rectangle.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_2FAStatus_Rectangle.Stroke = ProjectVariables.Red;
            settingsWindow.Security_ChangeNumber_Rectangle.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_ChangeProfile_Rectangle1.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_ViewProfile_Rectangle1.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_ShowBackupCode_Rectangle.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_DownloadBackupCode_Rectangle.Stroke = ProjectVariables.MainColor;
            settingsWindow.Security_StatusBackupCode_Rectangle.Stroke = ProjectVariables.Red;

        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Security_RecoveryEmail_Image);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Security_PhoneNumer_Image);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Security_ConnectedEmail_Image); 
                
        }

        private void loadSettings()
        {

        }

        public static void saveSettings()
        {

        }
        #endregion

    }
}
