using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class ResetSettings
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public ResetSettings()
        {
            loadDB();
            loadImages();
            loadColors();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.ResetSettings);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.ResetSettings_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ResetSettings_Heading");
            settingsWindow.ResetSettings_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ResetSettings_Description");
            settingsWindow.ResetSettings_Options_AllSettings.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ResetSettings_Options_AllSettings");
            settingsWindow.ResetSettings_Options_Design.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Design_Text");
            settingsWindow.ResetSettings_Options_Language.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Language_Text");
            settingsWindow.ResetSettings_Options_Notification.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Messages_Text");
            settingsWindow.ResetSettings_Options_InGameOverlay.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_InGameOverlay_Text");
            settingsWindow.ResetSettings_Options_ClientStart.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_ProgrammStart_Text");
            settingsWindow.ResetSettings_Options_Updates.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("DWC_Menu_Updates_Text");

        }

        private void loadColors()
        {
            settingsWindow.ResetSettings.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.ResetSettings_Spacer_7.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Spacer_6.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Spacer_5.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Spacer_4.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Spacer_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Spacer_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_4.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_5.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_6.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ResetSettings_Rectangle_7.Fill = ProjectVariables.Theme_DarkRectangleAccent;
        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_1);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_2);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_3);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_4);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_5);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_6);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.ResetSettings_Image_7);
        }

        #endregion

    }
}
