using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Updates
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Updates()
        {
            loadDB();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Updates);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Updates_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_Heading");
            settingsWindow.Updates_Description_1.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_Description_1");
            settingsWindow.Updates_Description_2.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_Description_2");
            settingsWindow.Updates_AutoUpdate_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_AutoUpdate_Heading");
            settingsWindow.Updates_AutoUpdate_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_AutoUpdate_Description");
            settingsWindow.Updates_AutoUpdateBlock_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_AutoUpdateBlock_Heading");
            settingsWindow.Updates_AutoUpdateBlock_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Updates_AutoUpdateBlock_Description");

        }

        private void loadColors()
        {
            settingsWindow.Updates.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Updates_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Updates_Spacer_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
                
        }

        private void loadSettings()
        {
            settingsWindow.Updates_AutoUpdate_Toggle.isActive = ConfigManager.automaticUpdate;
            settingsWindow.Updates_AutoUpdateBlock_Toggle.isActive = ConfigManager.blockAutoUpdate;
        }

        public static void saveSettings()
        {
            ConfigManager.automaticUpdate = settingsWindow.Updates_AutoUpdate_Toggle.isActive;
            ConfigManager.blockAutoUpdate = settingsWindow.Updates_AutoUpdateBlock_Toggle.isActive;
        }
        #endregion

    }
}
