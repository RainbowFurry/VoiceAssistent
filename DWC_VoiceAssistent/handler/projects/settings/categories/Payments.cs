using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Payments
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static readonly Settings settingsWindow = Settings.SettingsWindow;

        public Payments()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();
            WindowOverlayManager.updateAllWindowContent(settingsWindow.PaymentMehtodes);
        }

        #region Load on Initialization
        private void loadDB()
        {
            settingsWindow.Payments_YourPayments.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_YourPayments");
            settingsWindow.Payments_AddPayment.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_AddPayment");
            settingsWindow.Payments_Payments_InfoHeading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_Payments_InfoHeading");
            settingsWindow.Payments_Payments_Info.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_Payments_Info");
            settingsWindow.Payments_QuickPay_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_QuickPay_Heading");
            settingsWindow.Payments_QuickPay_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_QuickPay_Description");
            settingsWindow.Payments_QuickPay_QuickPayHeading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_QuickPay_QuickPayHeading");
            settingsWindow.Payments_QuickPay_QuickPayContent.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_QuickPay_QuickPayContent");
            settingsWindow.Payments_SecurePay_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_SecurePay_Heading");
            settingsWindow.Payments_SecurePay_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_SecurePay_Description");
            settingsWindow.Payments_SecurePay_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Payments_SecurePay_Content");
        }

        private void loadColors()
        {
            settingsWindow.PaymentMehtodes.Background = ProjectVariables.Theme_LighterDark;
            settingsWindow.Payments_Payments_Info_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_PayPal_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_Mastercard_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_ECCard_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_Sepa_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_PaySafeCard_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_DirectPayment_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Payments_Payments_Bitcoin_Background.Fill = ProjectVariables.Theme_DarkRectangleAccent;

        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/payments/PayPal.svg", Settings.SettingsWindow.Payments_Payments_PayPal_Image);
            ProjectVariables.LoadSvgImage("src/payments/MasterCard.svg", Settings.SettingsWindow.Payments_Payments_Mastercard_Image);
            ProjectVariables.LoadSvgImage("src/payments/EC.svg", Settings.SettingsWindow.Payments_Payments_ECCard_Image);
            ProjectVariables.LoadSvgImage("src/payments/Sepa.svg", Settings.SettingsWindow.Payments_Payments_Sepa_Image);
            ProjectVariables.LoadSvgImage("src/payments/Paysafecard.svg", Settings.SettingsWindow.Payments_Payments_PaySafeCard_Image);
            ProjectVariables.LoadSvgImage("src/payments/DirectPay.svg", Settings.SettingsWindow.Payments_Payments_DirectPayment_Image);
            ProjectVariables.LoadSvgImage("src/payments/Bitcoin.svg", Settings.SettingsWindow.Payments_Payments_Bitcoin_Image);
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
