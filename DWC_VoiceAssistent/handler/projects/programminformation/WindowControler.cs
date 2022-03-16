using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.projects.programminformation
{
    class WindowControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private ProgrammInformation programmInformationWindow = ProgrammInformation.programmInformationWindow;

        public WindowControler()
        {
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(ProgrammInformation.programmInformationWindow.BackgroundImage);

            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", ProgrammInformation.programmInformationWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", ProgrammInformation.programmInformationWindow.Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", ProgrammInformation.programmInformationWindow.Window_Minimize);


            loadDB();
            loadColor();

            programmInformationWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            programmInformationWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            programmInformationWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

        }

        private void loadDB()
        {
            programmInformationWindow.ProductName_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("ProductName_Heading");
            programmInformationWindow.ProductName_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("ProductName_Content");
            programmInformationWindow.Version_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("Version_Heading");
            programmInformationWindow.Version_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("Version_Content");
            programmInformationWindow.CopyRight_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("CopyRight_Heading");
            programmInformationWindow.CopyRight_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("CopyRight_Content");
            programmInformationWindow.Company_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("Company_Heading");
            programmInformationWindow.Company_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("Company_Content");
            programmInformationWindow.Description_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("Description_Heading");
            programmInformationWindow.Description_Content.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueProgrammInformation("Description_Content");
        }

        private void loadColor()
        {
            SolidColorBrush mainColor = new SolidColorBrush(Color.FromArgb(255, 15, 127, 238));

            programmInformationWindow.ProductName_Heading.Foreground = mainColor;
            programmInformationWindow.Version_Heading.Foreground = mainColor;
            programmInformationWindow.CopyRight_Heading.Foreground = mainColor;
            programmInformationWindow.Company_Heading.Foreground = mainColor;
            programmInformationWindow.Description_Heading.Foreground = mainColor;
        }

        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ProgrammInformation.programmInformationWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ProgrammInformation.programmInformationWindow.DWC_Window.WindowState == System.Windows.WindowState.Normal)
            {
                ProgrammInformation.programmInformationWindow.DWC_Window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                ProgrammInformation.programmInformationWindow.DWC_Window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ProgrammInformation.programmInformationWindow.DWC_Window.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        private void setGridColor()
        {

            programmInformationWindow.BackgroundImage.Background = ProjectVariables.Theme_MiddleDark;

            programmInformationWindow.Product_Background.Fill = ProjectVariables.Theme_LighterDark;
            programmInformationWindow.Version_Background.Fill = ProjectVariables.Theme_LighterDark;
            programmInformationWindow.CopyRight_Background.Fill = ProjectVariables.Theme_LighterDark;
            programmInformationWindow.Company_Background.Fill = ProjectVariables.Theme_LighterDark;
            programmInformationWindow.Description_Background.Fill = ProjectVariables.Theme_LighterDark;

        }

    }
}
