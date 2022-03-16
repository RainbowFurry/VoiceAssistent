using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.reports
{
    class WindowControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static Report reportWindow = Report.reportWindow;
        private SolidColorBrush deselectColor = new SolidColorBrush(Color.FromArgb(255, 107, 107, 107));

        /// <summary>
        /// Initialize the Report Window Controler
        /// </summary>
        public WindowControler()
        {
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(reportWindow.BackgroundImage);

            loadDB();
            reportWindow.DWC_Report_CrashAnswer_Yes.MouseLeftButtonDown += changeSelection;

            reportWindow.DWC_Report_CrashAnswer_No.MouseLeftButtonDown += changeSelection;
            reportWindow.DWC_Report_CrashsOften_Yes.MouseLeftButtonDown += changeSelection;
            reportWindow.DWC_Report_CrashsOften_No.MouseLeftButtonDown += changeSelection;
            reportWindow.DWC_Report_Plugin_Button.MouseLeftButtonDown += changeSelection;
            reportWindow.DWC_Report_Assistent_Button.MouseLeftButtonDown += changeSelection;
            reportWindow.DWC_Report_CrashAnswer_Yes.MouseLeftButtonDown += changeSelection;
            reportWindow.DWC_Report_Other_Button.MouseLeftButtonDown += changeSelection;

            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", Report.reportWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", Report.reportWindow.Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", Report.reportWindow.Window_Minimize);

            reportWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            reportWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            reportWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

        }

        /// <summary>
        /// Send the mail with the report after klicking ok
        /// </summary>
        private void DWC_Send_Button_Click(object sender, RoutedEventArgs e)
        {

            if (reportWindow.DWC_MailContent.SelectedText != null && reportWindow.DWC_MailContent.Text.Length >= 100)
            {

                //GET MESSAGE CONTENT TO SEND WITH MAIL...

                if (reportWindow.DWC_Report_AddLatestLog_CheckBox.IsChecked == true)
                {
                    functions.MailManager.sendMailWithLog(functions.MailManager.MailHeading.report, reportWindow.DWC_MailContent.Text);
                }
                else
                {
                    functions.MailManager.sendMail(functions.MailManager.MailHeading.report, reportWindow.DWC_MailContent.Text);
                }

                Alert alertWindow = new Alert();
                alertWindow.Content = "Die Nachricht wurde erfolgreich gesendet.\n\nVielen Dank für deine Nachricht.\nWir schauen sie uns zeitnahe an.";
                alertWindow.loadText();
                alertWindow.Show();
                reportWindow.Close();

            }
            else
            {
                reportWindow.DWC_AlertText.Content = "Bitte gebe einen Text mit mindestens 100 Zeichen ein.";
                reportWindow.DWC_AlertText.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// Change the Selected Button State
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeSelection(object sender, MouseButtonEventArgs e)
        {

            Grid grid = (Grid)sender;
            Rectangle rectangle = (Rectangle)grid.Children[0];
            Label label = (Label)grid.Children[1];

            if (grid.Name == "DWC_Report_CrashAnswer_Yes" || grid.Name == "DWC_Report_CrashAnswer_No")
            {
                reportWindow.DWC_Report_CrashAnswer_No_Text.Foreground = deselectColor;
                reportWindow.DWC_Report_CrashAnswer_Yes_Text.Foreground = deselectColor;
            }

            if (grid.Name == "DWC_Report_CrashsOften_Yes" || grid.Name == "DWC_Report_CrashsOften_No")
            {
                reportWindow.DWC_Report_CrashsOften_No_Text.Foreground = deselectColor;
                reportWindow.DWC_Report_CrashsOften_Yes_Text.Foreground = deselectColor;
            }

            if (grid.Name == "DWC_Report_Other_Button" || grid.Name == "DWC_Report_Chat_Button" || grid.Name == "DWC_Report_Assistent_Button" || grid.Name == "DWC_Report_Plugin_Button")
            {
                reportWindow.DWC_Report_Plugin_Button_Text.Foreground = deselectColor;
                reportWindow.DWC_Report_Assistent_Button_Text.Foreground = deselectColor;
                reportWindow.DWC_Report_Chat_Button_Text.Foreground = deselectColor;
                reportWindow.DWC_Report_Other_Button_Text.Foreground = deselectColor;
            }

            //Aktivate Clicked one
            label.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        }

        /// <summary>
        /// Load the DB for the Window Report
        /// </summary>
        private void loadDB()
        {
            reportWindow.DWC_Report_CrashAnswer_Yes_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Yes");
            reportWindow.DWC_Report_CrashsOften_Yes_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Yes");
            reportWindow.DWC_Report_CrashAnswer_No_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("No");
            reportWindow.DWC_Report_CrashsOften_No_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("No");

            reportWindow.DWC_ReportWinow_Question1.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Question_1");
            reportWindow.DWC_ReportWinow_Question2.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Question_2");
            reportWindow.DWC_ReportWinow_Question3.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Question_3");

            reportWindow.DWC_MailContent.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("TextFieldDescription");
            reportWindow.DWC_Report_AddLatestLog_CheckBox.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Add_Latest_log");

            reportWindow.DWC_SendButton_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Send");
            reportWindow.DWC_SupportButton_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Support");
            reportWindow.DWC_CancelButton_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Cancle");

            reportWindow.DWC_Report_Plugin_Button_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Categor_Plugin");
            reportWindow.DWC_Report_Assistent_Button_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Categor_Assistent");
            reportWindow.DWC_Report_Chat_Button_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Categor_Chat");
            reportWindow.DWC_Report_Other_Button_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueReport("Categor_Other");
        }


        #region Window Options
        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Report.reportWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, MouseButtonEventArgs e)
        {
            if (Report.reportWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                Report.reportWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                Report.reportWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, MouseButtonEventArgs e)
        {
            Report.reportWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

        private static void setGridColor()
        {

            reportWindow.BackgroundImage.Background = ProjectVariables.Theme_MiddleDark;
            reportWindow.Support_Background.Fill = ProjectVariables.Theme_LighterDark;
            reportWindow.Cancel_Background.Fill = ProjectVariables.Theme_LighterDark;
            reportWindow.Send_Background.Fill = ProjectVariables.Theme_LighterDark;

        }

    }
}
