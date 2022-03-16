
using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class ClientStart
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public ClientStart()
        {
            loadDB();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.ClientStart);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.ClientStart_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ClientStart_Heading");
            settingsWindow.ClientStart_Autostart.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ClientStart_Autostart");
            settingsWindow.ClientStart_MinimizedStart.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ClientStart_MinimizedStart");

        }

        private void loadColors()
        {
            settingsWindow.ClientStart.Background = ProjectVariables.Theme_LighterDark;
        }

        private void loadSettings()
        {
            settingsWindow.ClientStart_Autostart_Toggle.isActive = ConfigManager.autostartClient;
            settingsWindow.ClientStart_MinimizedStart_Toggle.isActive = ConfigManager.startMinimized;
        }

        public static void saveSettings()
        {
            ConfigManager.autostartClient = settingsWindow.ClientStart_Autostart_Toggle.isActive;
            ConfigManager.startMinimized = settingsWindow.ClientStart_MinimizedStart_Toggle.isActive;
        }
        #endregion

    }
}
