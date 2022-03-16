using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Devices
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Devices()
        {
            loadDB();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Devices);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Devices_ConnectedDevicesHeading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Devices_ConnectedDevicesHeading");
            settingsWindow.Devices_ConnectedDevicesInfo.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Devices_ConnectedDevicesInfo");
            settingsWindow.Devices_ConnectedDevicesButton_CurrentDevice.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Devices_ConnectedDevicesButton_CurrentDevice");
        }

        private void loadColors()
        {
            settingsWindow.Devices.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Devices_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
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
