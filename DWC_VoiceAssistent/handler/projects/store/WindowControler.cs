using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.store
{
    class WindowControler
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        private Store storeWindow = Store.storeWindow;

        public WindowControler()
        {
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(storeWindow.BackgroundImage);

            Settings.SettingsWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            Settings.SettingsWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;
            Settings.SettingsWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;

            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", Store.storeWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", Store.storeWindow.Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", Store.storeWindow.Window_Minimize);

        }


        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Store.storeWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Store.storeWindow.DWC_Window.WindowState == System.Windows.WindowState.Normal)
            {
                Store.storeWindow.DWC_Window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                Store.storeWindow.DWC_Window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Store.storeWindow.DWC_Window.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        private void setGridColor()
        {

            storeWindow.BackgroundImage.Background = ProjectVariables.Theme_DarkBackground;

            storeWindow.Standard_Background_1.Fill = ProjectVariables.Theme_LighterDark;
            storeWindow.Standard_Background_2.Fill = ProjectVariables.Theme_LighterDark;

            storeWindow.Premium_Background_1.Fill = ProjectVariables.Theme_LighterDark;
            storeWindow.Premium_Background_2.Fill = ProjectVariables.Theme_LighterDark;

            storeWindow.PremiumPlus_Background_1.Fill = ProjectVariables.Theme_LighterDark;
            storeWindow.PremiumPlus_Background_2.Fill = ProjectVariables.Theme_LighterDark;

        }

    }
}
