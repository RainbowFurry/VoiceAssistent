using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class ConnectedAccounts
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public ConnectedAccounts()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.ConnectedAccounts);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.ConnectedAccounts_ConnectedAccounts.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ConnectedAccounts_ConnectedAccounts");
            settingsWindow.ConnectedAccounts_AddNewAccount.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ConnectedAccounts_AddNewAccount");
            settingsWindow.ConnectedAccounts_AddNewAccount_ButtonText.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ButtonText_AddAcount");
            settingsWindow.ConnectedAccounts_AddAccountInfo.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ConnectedAccounts_AddAccountInfo");
            settingsWindow.ConnectedAccounts_MainEmail_Info.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("ConnectedAccounts_MainEmail_Info");
        }

        private void loadColors()
        {
            settingsWindow.ConnectedAccounts.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.ConnectedAccounts_MainEmail_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.ConnectedAccounts_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.ConnectedAccounts_Rectangle_2.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_3.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_4.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_5.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_6.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_7.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_8.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_9.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_10.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_11.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_12.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_13.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_14.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_15.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_16.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_17.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_18.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_19.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_20.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
            settingsWindow.ConnectedAccounts_Rectangle_21.Fill = ProjectVariables.Theme_DarkRectangleAccent_Dark;
        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_1);
            ProjectVariables.LoadSvgImage("src/connections/Twitter.svg", settingsWindow.ConnectedAccounts_Image_2);
            ProjectVariables.LoadSvgImage("src/connections/YouTube.svg", settingsWindow.ConnectedAccounts_Image_3);
            ProjectVariables.LoadSvgImage("src/connections/Twitch.svg", settingsWindow.ConnectedAccounts_Image_4);
            ProjectVariables.LoadSvgImage("src/connections/Microsoft.svg", settingsWindow.ConnectedAccounts_Image_5);
            ProjectVariables.LoadSvgImage("src/connections/RockStart.svg", settingsWindow.ConnectedAccounts_Image_6);
            ProjectVariables.LoadSvgImage("src/connections/Ubisoft.svg", settingsWindow.ConnectedAccounts_Image_7);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_8);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_9);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_10);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_11);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_12);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_13);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_14);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_15);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_16);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_17);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_18);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_19);
            ProjectVariables.LoadSvgImage("src/connections/Steam.svg", settingsWindow.ConnectedAccounts_Image_20);
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
