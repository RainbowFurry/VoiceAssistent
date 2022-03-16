using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Microphone
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Microphone()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Mikro);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Microphone_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_Heading");
            settingsWindow.Microphone_MicrophoneName.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_MicrophoneName");
            settingsWindow.Microphone_HeadsetName.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_HeadsetName");
            settingsWindow.Microphone_InputText.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_InputText");
            settingsWindow.Microphone_OutputText.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_OutputText");
            settingsWindow.Microphone_VoiceActivation_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_VoiceActivation_Heading");
            settingsWindow.Microphone_VoiceActivation_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_VoiceActivation_Description");
            settingsWindow.Microphone_AutomaticVoiceDetection_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_AutomaticVoiceDetection_Heading");
            settingsWindow.Microphone_AutomaticVoiceDetection_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_AutomaticVoiceDetection_Description");
            settingsWindow.Microphone_AudioHelp_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_AudioHelp_Heading");
            settingsWindow.Microphone_AudioHelp_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_AudioHelp_Description");
            settingsWindow.Microphone_AudioOptimisation_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_AudioOptimisation_Heading");
            settingsWindow.Microphone_AudioOptimisation_Content.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Microphone_AudioOptimisation_Content");

        }

        private void loadColors()
        {
            settingsWindow.Mikro.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Microphone_Spacer.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Microphone_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Microphone_Rectangle_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Microphone_Rectangle_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Microphone_Rectangle_4.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Microphone_Rectangle_5.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Microphone_Rectangle_6.Fill = ProjectVariables.Theme_DarkRectangleAccent;
  
        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Microphone_Image_1);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Microphone_Image_2);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Microphone_Image_3);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Microphone_Image_4);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Microphone_Image_5);

        }

        private void loadSettings()
        {
            settingsWindow.Microphone_VoiceActivation_Toggle.isActive = ConfigManager.speechAktivation;
            settingsWindow.Microphone_AutomaticVoiceDetection_Toggle.isActive = ConfigManager.microphoneSensitivity;
            settingsWindow.Microphone_AudioHelp_Toggle.isActive = ConfigManager.audioHelp;
            settingsWindow.Microphone_AudioOptimisation_Toggle.isActive = ConfigManager.audioOptimisation;
        }

        public static void saveSettings()
        {
            ConfigManager.speechAktivation = settingsWindow.Microphone_VoiceActivation_Toggle.isActive;
            ConfigManager.microphoneSensitivity = settingsWindow.Microphone_AutomaticVoiceDetection_Toggle.isActive;
            ConfigManager.audioHelp = settingsWindow.Microphone_AudioHelp_Toggle.isActive;
            ConfigManager.audioOptimisation = settingsWindow.Microphone_AudioOptimisation_Toggle.isActive;
        }
        #endregion

    }
}
