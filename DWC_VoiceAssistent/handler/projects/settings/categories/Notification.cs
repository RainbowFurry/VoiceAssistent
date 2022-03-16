using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Notification
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Notification()
        {
            loadDB();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.Account);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Notification_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_Heading");
            settingsWindow.Notification_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_Description");
            settingsWindow.Notification_DesktopNotification_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_DesktopNotification_Heading");
            settingsWindow.Notification_DesktopNotification_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_DesktopNotification_Description");
            settingsWindow.Notification_ShowTextNotification_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_ShowTextNotification_Heading");
            settingsWindow.Notification_ShowTextNotification_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_ShowTextNotification_Description");
            settingsWindow.Notification_ShowFriendOnline_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_ShowFriendOnline_Heading");
            settingsWindow.Notification_SystemNotification_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_SystemNotification_Heading");
            settingsWindow.Notification_SystemNotification_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_SystemNotification_Description");
            settingsWindow.Notification_DescropSecurityNotification_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_DescropSecurityNotification_Heading");
            settingsWindow.Notification_DescropSecurityNotification_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_DescropSecurityNotification_Description");
            settingsWindow.Notification_EmailNotification_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_Heading");
            settingsWindow.Notification_EmailNotification_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_Description");
            settingsWindow.Notification_EmailNotification_UpdateEmail_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_UpdateEmail_Heading");
            settingsWindow.Notification_EmailNotification_PrimeEmail_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_PrimeEmail_Heading");
            settingsWindow.Notification_EmailNotification_PrimeEmail_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_PrimeEmail_Description");
            settingsWindow.Notification_EmailNotification_ShopCardEmail_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_ShopCardEmail_Heading");
            settingsWindow.Notification_EmailNotification_ShopCardEmail_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_ShopCardEmail_Description");
            settingsWindow.Notification_EmailNotification_StoreEmail_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_StoreEmail_Heading");
            settingsWindow.Notification_EmailNotification_StoreEmail_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Notification_EmailNotification_StoreEmail_Description");

        }

        private void loadColors()
        {
            settingsWindow.Notification.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Notification_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Notification_Spacer_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Notification_Spacer_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
        }

        private void loadSettings()
        {
            settingsWindow.Notification_DesktopNotification_Slider.isActive = ConfigManager.desktopNotification;
            settingsWindow.Notification_ShowTextNotification_Slider.isActive = ConfigManager.textMessageNotification;
            settingsWindow.Notification_ShowFriendOnline_Slider.isActive = ConfigManager.friendIsOnline;
            settingsWindow.Notification_SystemNotification_Slider.isActive = ConfigManager.systemNotification;
            settingsWindow.Notification_DescropSecurityNotification_Slider.isActive = ConfigManager.securityNotification;
            settingsWindow.Notification_EmailNotification_UpdateEmail_Slider.isActive = ConfigManager.updateEmailNotification;
            settingsWindow.Notification_EmailNotification_PrimeEmail_Slider.isActive = ConfigManager.eventEmialNotification;
            settingsWindow.Notification_EmailNotification_ShopCardEmail_Slider.isActive = ConfigManager.shoppingCardEmailNotification;
            settingsWindow.Notification_EmailNotification_StoreEmail_Slider.isActive = ConfigManager.storeUpdateEmailNotification;
        }

        public static void saveSettings()
        {
            ConfigManager.desktopNotification = settingsWindow.Notification_DesktopNotification_Slider.isActive;
            ConfigManager.textMessageNotification = settingsWindow.Notification_ShowTextNotification_Slider.isActive;
            ConfigManager.friendIsOnline = settingsWindow.Notification_ShowFriendOnline_Slider.isActive;
            ConfigManager.systemNotification = settingsWindow.Notification_SystemNotification_Slider.isActive;
            ConfigManager.securityNotification = settingsWindow.Notification_DescropSecurityNotification_Slider.isActive;
            ConfigManager.updateEmailNotification = settingsWindow.Notification_EmailNotification_UpdateEmail_Slider.isActive;
            ConfigManager.eventEmialNotification = settingsWindow.Notification_EmailNotification_PrimeEmail_Slider.isActive;
            ConfigManager.shoppingCardEmailNotification = settingsWindow.Notification_EmailNotification_ShopCardEmail_Slider.isActive;
            ConfigManager.storeUpdateEmailNotification = settingsWindow.Notification_EmailNotification_StoreEmail_Slider.isActive;
        }
        #endregion

    }
}
