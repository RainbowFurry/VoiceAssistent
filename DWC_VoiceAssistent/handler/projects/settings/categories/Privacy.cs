using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Privacy
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Privacy()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Privacy);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Privacy_Chat_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_Heading");
            settingsWindow.Privacy_Chat_Content.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_Content");
            settingsWindow.Privacy_Chat_WritingPermission_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_WritingPermission_Heading");
            settingsWindow.Privacy_Chat_Status_Everybody_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_Status_Everybody_Label");
            settingsWindow.Privacy_Chat_Status_Friends_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_Status_Friends_Label");
            settingsWindow.Privacy_Chat_Status_Label_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_Status_Label_Label");
            settingsWindow.Privacy_Chat_ShowStatus_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_ShowStatus_Heading");
            settingsWindow.Privacy_Chat_LastOnline_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_LastOnline_Heading");
            settingsWindow.Privacy_Chat_LastOnline_Everybody_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_LastOnline_Everybody_Label");
            settingsWindow.Privacy_Chat_LastOnline_Friends_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_LastOnline_Friends_Label");
            settingsWindow.Privacy_Chat_LastOnline_Nobody_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_LastOnline_Nobody_Label");
            settingsWindow.Privacy_Chat_AddFriendPermission_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_AddFriendPermission_Heading");
            settingsWindow.Privacy_Chat_AddFriendPermission_Everybody_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_AddFriendPermission_Everybody_Label");
            settingsWindow.Privacy_Chat_AddFriendPermission_Friends_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_AddFriendPermission_Friends_Label");
            settingsWindow.Privacy_Chat_AddFriendPermission_Request_Label.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Chat_AddFriendPermission_Request_Label");
            settingsWindow.Privacy_Infotext1.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Privacy_Infotext1");
        }

        private void loadColors()
        {
            settingsWindow.Privacy.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Privacy_Chat_Status_Everybody_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_Status_Friends_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_Status_Label_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_LastOnline_Everybody_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_LastOnline_Friends_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_LastOnline_Friends_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_AddFriendPermission_Everybody_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_AddFriendPermission_Friends_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Chat_AddFriendPermission_Request_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Privacy_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;

        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", settingsWindow.Privacy_Chat_HeadingImage);
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
