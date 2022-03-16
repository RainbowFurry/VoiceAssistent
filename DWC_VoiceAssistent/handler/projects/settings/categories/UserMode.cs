using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class UserMode
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public UserMode()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.EditrosMode);

            settingsWindow.EditorsMode_NormalMode_Rectangle.MouseLeftButtonDown += userModeChange;
            settingsWindow.EditorsMode_EditorsMode_Rectangle.MouseLeftButtonDown += userModeChange;
            settingsWindow.EditorsMode_DeveloperMode_Rectangle.MouseLeftButtonDown += userModeChange;

        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.EditorsMode_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_Heading");
            settingsWindow.EditorsMode_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_Description");
            settingsWindow.EditorsMode_NormalMode_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_NormalMode_Heading");
            settingsWindow.EditorsMode_NormalMode_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_NormalMode_Description");
            settingsWindow.EditorsMode_EditorsMode_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_EditorsMode_Heading");
            settingsWindow.EditorsMode_EditorsMode_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_EditorsMode_Description");
            settingsWindow.EditorsMode_DeveloperMode_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_DeveloperMode_Heading");
            settingsWindow.EditorsMode_DeveloperMode_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_DeveloperMode_Description");
            settingsWindow.EditorsMode_InfoHeading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_InfoHeading");
            settingsWindow.EditorsMode_InfoDescription.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("EditorsMode_InfoDescription");

        }

        private void loadColors()
        {
            settingsWindow.EditrosMode.Background = ProjectVariables.Theme_LighterDark;

            settingsWindow.EditorsMode_NormalMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.EditorsMode_EditorsMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.EditorsMode_DeveloperMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.EditorsMode_MoreInfoButton_Rectangle.Stroke = ProjectVariables.MainColor;

        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.EditorsMode_NormalMode_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.EditorsMode_EditorMode_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.EditorsMode_DeveloperMode_Image);

        }

        private void loadSettings()
        {

            if (ConfigManager.editorsMode == "min")
            {
                settingsWindow.EditorsMode_NormalMode_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.EditorsMode_NormalMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            }
            else if (ConfigManager.editorsMode == "none")
            {
                settingsWindow.EditorsMode_EditorMode_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.EditorsMode_EditorsMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            }
            else if (ConfigManager.editorsMode == "max")
            {
                settingsWindow.EditorsMode_DeveloperMode_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.EditorsMode_DeveloperMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            }

        }

        public static void saveSettings()
        {

            if (settingsWindow.EditorsMode_NormalMode_Rectangle.Fill == ProjectVariables.Theme_DarkRectangleAccent)
            {
                ConfigManager.editorsMode = "min";
            }
            else if (settingsWindow.EditorsMode_EditorsMode_Rectangle.Fill == ProjectVariables.Theme_DarkRectangleAccent)
            {
                ConfigManager.editorsMode = "none";
            }
            else if (settingsWindow.EditorsMode_DeveloperMode_Rectangle.Fill == ProjectVariables.Theme_DarkRectangleAccent)
            {
                ConfigManager.editorsMode = "max";
            }

        }
        #endregion

        private void userModeChange(object sender, MouseButtonEventArgs e)
        {

            Rectangle rectangle = sender as Rectangle;

            settingsWindow.EditorsMode_NormalMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.EditorsMode_EditorsMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.EditorsMode_DeveloperMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.EditorsMode_NormalMode_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.EditorsMode_EditorMode_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.EditorsMode_DeveloperMode_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "EditorsMode_NormalMode_Rectangle")
            {
                settingsWindow.EditorsMode_NormalMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
                settingsWindow.EditorsMode_NormalMode_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "EditorsMode_EditorsMode_Rectangle")
            {
                settingsWindow.EditorsMode_EditorsMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
                settingsWindow.EditorsMode_EditorMode_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "EditorsMode_DeveloperMode_Rectangle")
            {
                settingsWindow.EditorsMode_DeveloperMode_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
                settingsWindow.EditorsMode_DeveloperMode_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

    }
}
