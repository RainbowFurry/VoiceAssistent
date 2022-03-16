using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class InGameOverlay
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public InGameOverlay()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.InGameOverlay);

            settingsWindow.InGameOverlay_ShownPosition_Left_Top.MouseLeftButtonDown += inGameOverlayChange;
            settingsWindow.InGameOverlay_ShownPosition_Right_Top.MouseLeftButtonDown += inGameOverlayChange;
            settingsWindow.InGameOverlay_ShownPosition_Left_Bottom.MouseLeftButtonDown += inGameOverlayChange;
            settingsWindow.InGameOverlay_ShownPosition_Right_Bottom.MouseLeftButtonDown += inGameOverlayChange;

        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.InGameOverlay_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_Heading");
            settingsWindow.InGameOverlay_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_Description");
            settingsWindow.InGameOverlay_AktivateIngameOverlay.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_AktivateIngameOverlay");
            settingsWindow.InGameOverlay_Show_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_Show_Heading");
            settingsWindow.InGameOverlay_ShowWhileTalking_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_ShowWhileTalking_Heading");
            settingsWindow.InGameOverlay_ShowWhileTalking_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_ShowWhileTalking_Content");
            settingsWindow.InGameOverlay_ShowProfilePicture_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_ShowProfilePicture_Heading");
            settingsWindow.InGameOverlay_ShowProfilePicture_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_ShowProfilePicture_Content");
            settingsWindow.InGameOverlay_ShowMusik_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_ShowMusik_Heading");
            settingsWindow.InGameOverlay_ShowMusik_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("InGameOverlay_ShowMusik_Content");

        }

        private void loadColors()
        {

            settingsWindow.InGameOverlay.Background = ProjectVariables.Theme_LighterDark;

            settingsWindow.InGameOverlay_ShownPosition_Left_Top.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_ShownPosition_Right_Top.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_ShownPosition_Right_Bottom.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_ShownPosition_Left_Bottom.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_MainRectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.InGameOverlay_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;

        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/own/Checked_DarkAccent.svg", settingsWindow.InGameOverlay_ShownPosition_Left_Top_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked_DarkAccent.svg", settingsWindow.InGameOverlay_ShownPosition_Left_Bottom_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked_DarkAccent.svg", settingsWindow.InGameOverlay_ShownPosition_Right_Top_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked_DarkAccent.svg", settingsWindow.InGameOverlay_ShownPosition_Right_Bottom_Image);

        }

        private void loadSettings()
        {
            settingsWindow.InGameOverlay_AktivateIngameOverlay_Toggle.isActive = ConfigManager.aktivateIngameOverlay;
            settingsWindow.InGameOverlay_ShowWhileTalking_Toggle.isActive = ConfigManager.showOverlayIfTalking;
            settingsWindow.InGameOverlay_ShowProfilePicture_Toggle.isActive = ConfigManager.hideProfilePicture;
            settingsWindow.InGameOverlay_ShowMusik_Toggle.isActive = ConfigManager.showMusicBot;

            //Position
            if (ConfigManager.positionInGameOverlay == "top-left")
            {
                settingsWindow.InGameOverlay_ShownPosition_Left_Top.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Left_Top_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (ConfigManager.positionInGameOverlay == "top-right")
            {
                settingsWindow.InGameOverlay_ShownPosition_Right_Top.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Right_Top_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (ConfigManager.positionInGameOverlay == "bottom-left")
            {
                settingsWindow.InGameOverlay_ShownPosition_Left_Bottom.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Left_Bottom_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (ConfigManager.positionInGameOverlay == "bottom-right")
            {
                settingsWindow.InGameOverlay_ShownPosition_Right_Bottom.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Right_Bottom_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

        public static void saveSettings()
        {
            ConfigManager.aktivateIngameOverlay = settingsWindow.InGameOverlay_AktivateIngameOverlay_Toggle.isActive;
            ConfigManager.showOverlayIfTalking = settingsWindow.InGameOverlay_ShowWhileTalking_Toggle.isActive;
            ConfigManager.hideProfilePicture = settingsWindow.InGameOverlay_ShowProfilePicture_Toggle.isActive;
            ConfigManager.showMusicBot = settingsWindow.InGameOverlay_ShowMusik_Toggle.isActive;

            if (settingsWindow.InGameOverlay_ShownPosition_Left_Top.Fill == ProjectVariables.Green)
            {
                ConfigManager.positionInGameOverlay = "top-left";
            }
            else if (settingsWindow.InGameOverlay_ShownPosition_Right_Top.Fill == ProjectVariables.Green)
            {
                ConfigManager.positionInGameOverlay = "top-right";
            }
            else if (settingsWindow.InGameOverlay_ShownPosition_Left_Bottom.Fill == ProjectVariables.Green)
            {
                ConfigManager.positionInGameOverlay = "bottom-left";
            }
            else if (settingsWindow.InGameOverlay_ShownPosition_Right_Bottom.Fill == ProjectVariables.Green)
            {
                ConfigManager.positionInGameOverlay = "bottom-right";
            }

        }
        #endregion

        private void inGameOverlayChange(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;

            settingsWindow.InGameOverlay_ShownPosition_Left_Top.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_ShownPosition_Right_Top.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_ShownPosition_Left_Bottom.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.InGameOverlay_ShownPosition_Right_Bottom.Fill = ProjectVariables.Theme_LighterDark;

            settingsWindow.InGameOverlay_ShownPosition_Left_Top_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.InGameOverlay_ShownPosition_Right_Top_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.InGameOverlay_ShownPosition_Left_Bottom_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.InGameOverlay_ShownPosition_Right_Bottom_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "InGameOverlay_ShownPosition_Left_Top")
            {
                settingsWindow.InGameOverlay_ShownPosition_Left_Top.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Left_Top_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "InGameOverlay_ShownPosition_Right_Top")
            {
                settingsWindow.InGameOverlay_ShownPosition_Right_Top.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Right_Top_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "InGameOverlay_ShownPosition_Left_Bottom")
            {
                settingsWindow.InGameOverlay_ShownPosition_Left_Bottom.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Left_Bottom_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "InGameOverlay_ShownPosition_Right_Bottom")
            {
                settingsWindow.InGameOverlay_ShownPosition_Right_Bottom.Fill = ProjectVariables.Green;
                settingsWindow.InGameOverlay_ShownPosition_Right_Bottom_Image.Visibility = System.Windows.Visibility.Visible;
            }
        }

    }
}
