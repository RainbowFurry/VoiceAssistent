using DarkWolfCraftSys;
using System;
using System.IO;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class VoiceAssistent
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //TODO
        //voiceassistentReactInGame - load - save - db
        //voiceassistentActive - load - save - db

        private static DWC_VoiceAssistent.projects.system.Settings settingsWindow = DWC_VoiceAssistent.projects.system.Settings.SettingsWindow;

        public VoiceAssistent()
        {
            settingsWindow.DWC_VoiceAssistent_UserName.SelectionBrush = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            settingsWindow.DWC_VoiceAssistent_ReactName.SelectionBrush = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
        }

        public static void loadSettings()
        {

            //Names
            settingsWindow.DWC_VoiceAssistent_UserName.Text = ConfigManager.userName;//the user name
            settingsWindow.DWC_VoiceAssistent_ReactName.Text = ConfigManager.voiceReactName;//The Programm listens on this name untill you say it loud

            //VoiceSettings
            if (ConfigManager.voiceGender == "male")
            {
                settingsWindow.DWC_Gender_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Voice_Selection_Male");
            }
            else
            {
                settingsWindow.DWC_Gender_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Voice_Selection_Female");
            }

            //AgeSettings
            if (ConfigManager.voiceAge == "adult")
            {
                settingsWindow.DWC_Age_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Age_Selection_Adult");
            }
            else
            {
                settingsWindow.DWC_Age_Selection.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Age_Selection_Child");
            }

        }

        public static void saveSettings()
        {
            //Voice Gender
            if (settingsWindow.DWC_Gender_Selection.Content.ToString() != DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Voice_Selection_Male"))
            {
                ConfigManager.Set("voiceGender", "female");
            }
            else
            {
                ConfigManager.Set("voiceGender", "male");
            }

            //Voice Age
            if (settingsWindow.DWC_Age_Selection.Content.ToString() != DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Settings_Age_Selection_Adult"))
            {
                ConfigManager.Set("voiceAge", "child");
            }
            else
            {
                ConfigManager.Set("voiceAge", "adult");
            }
        }

    }
}
