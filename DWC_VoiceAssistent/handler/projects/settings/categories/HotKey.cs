using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.backgroundtasks;
using DWC_VoiceAssistent.projects.system;
using System.Windows.Controls;
using System.Windows.Input;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class HotKey
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        private Label hashLabel;
        private bool editinig = false;

        public HotKey()
        {
            loadDB();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.HotKeys);

            settingsWindow.HotKeys_Option_PushToTalk_Value.MouseLeftButtonDown += hotKeyChange;
            settingsWindow.HotKeys_Option_VoiceAssistent_Value.MouseLeftButtonDown += hotKeyChange;
            settingsWindow.HotKeys_Option_Mute_Value.MouseLeftButtonDown += hotKeyChange;
            settingsWindow.HotKeys_Option_Musikbot_Value.MouseLeftButtonDown += hotKeyChange;

            settingsWindow.HotKeys.KeyDown += hotkeyDetect;

        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.HotKeys_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_Heading");
            settingsWindow.HotKeys_EnableAllHotkeys.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_EnableAllHotkeys");
            settingsWindow.HotKeys_ResetAllHotKeys.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_ResetAllHotKeys");
            settingsWindow.HotKeys_Info.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_Info");
            settingsWindow.HotKeys_CreateNewHotKey.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_CreateNewHotKey");
            settingsWindow.HotKeys_Option_PushToTalk.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_Option_PushToTalk");
            settingsWindow.HotKeys_Option_VoiceAssistent.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_Option_VoiceAssistent");
            settingsWindow.HotKeys_Option_Mute.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_Option_Mute");
            settingsWindow.HotKeys_Option_Musikbot.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_Option_Musikbot");
            settingsWindow.HotKeys_EnableOwnHotkeys.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("HotKeys_EnableOwnHotkeys");

        }

        private void loadColors()
        {
            settingsWindow.HotKeys.Background = ProjectVariables.Theme_LighterDark;

            settingsWindow.HotKey_Rectangle_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.HotKey_Rectangle_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.HotKey_Rectangle_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.HotKey_Rectangle_4.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.HotKey_Rectangle_5.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.HotKey_Spacer.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.HotKey_Rectangle_1_1.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.HotKey_Rectangle_1_2.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.HotKey_Rectangle_1_3.Fill = ProjectVariables.Theme_LighterDark;
            settingsWindow.HotKey_Rectangle_1_4.Fill = ProjectVariables.Theme_LighterDark;

            settingsWindow.HotKey_CreateNewHotKey_Rectangle.Stroke = ProjectVariables.MainColor;

        }

        private void loadSettings()
        {
            settingsWindow.HotKeys_EnableAllHotkeys_Toggle.isActive = ConfigManager.enableHotKeys;
            settingsWindow.HotKeys_EnableOwnHotkeys_Toggle.isActive = ConfigManager.enableOwnHotKeys;

            //Hot Keys
            settingsWindow.HotKeys_Option_PushToTalk_Value.Content = ShortCut.pushToTalk;
            settingsWindow.HotKeys_Option_VoiceAssistent_Value.Content = ShortCut.voiceassistentTrigger;
            settingsWindow.HotKeys_Option_Mute_Value.Content = ShortCut.muteStatus;
            settingsWindow.HotKeys_Option_Musikbot_Value.Content = ShortCut.musikBotStatus;

        }

        public static void saveSettings()
        {
            ConfigManager.enableHotKeys = settingsWindow.HotKeys_EnableAllHotkeys_Toggle.isActive;
            ConfigManager.enableOwnHotKeys = settingsWindow.HotKeys_EnableOwnHotkeys_Toggle.isActive;

            //Hot Keys
            ShortCut.pushToTalk = settingsWindow.HotKeys_Option_PushToTalk_Value.Content.ToString();
            ShortCut.voiceassistentTrigger = settingsWindow.HotKeys_Option_VoiceAssistent_Value.Content.ToString();
            ShortCut.muteStatus = settingsWindow.HotKeys_Option_Mute_Value.Content.ToString();
            ShortCut.musikBotStatus = settingsWindow.HotKeys_Option_Musikbot_Value.Content.ToString();

        }
        #endregion

        private void hotKeyChange(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;

            label.Content = "NEW";
            hashLabel = label;

        }

        private void hotkeyDetect(object sender, KeyEventArgs e)
        {
            if(hashLabel != null)
            {
                
                if (editinig == false)
                {
                    hashLabel.Content = e.Key.ToString();

                    if (e.Key == Key.LeftCtrl || e.Key == Key.LeftAlt)
                    {
                        editinig = true;
                        hashLabel.Content += " + ";
                    }

                }
                else
                {
                    hashLabel.Content += e.Key.ToString();
                    editinig = false;
                }

            }
        }

    }
}
