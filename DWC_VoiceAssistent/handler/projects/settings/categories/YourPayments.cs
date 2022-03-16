using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class YourPayments
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public YourPayments()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.YourPayment);
        }

        #region Load on Initialization
        private void loadDB()
        {
           

        }

        private void loadColors()
        {
            settingsWindow.YourPayment.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.YourPayment_Sorting_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            
        }

        private void loadImages()
        {
          
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
