using DarkWolfCraftSys;
using DWC_VoiceAssistent.manager;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.projects.pluginstore
{
    class WindowControler
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        private PluginStore pluginStoreWindow = PluginStore.pluginStoreWindow;

        public WindowControler()
        {
            SocketManager.Send("request_plugins_for_store", "all");
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(pluginStoreWindow.BackgroundImage);

            loadColor();
            loadDB();


            pluginStoreWindow.Plugins_ForYou.MouseLeftButtonDown += MenuSwitch;
            pluginStoreWindow.Plugins_Original.MouseLeftButtonDown += MenuSwitch;
            pluginStoreWindow.Plugins_Charts.MouseLeftButtonDown += MenuSwitch;
            pluginStoreWindow.Plugins_Games.MouseLeftButtonDown += MenuSwitch;
            pluginStoreWindow.Plugins_Apps.MouseLeftButtonDown += MenuSwitch;

            pluginStoreWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            pluginStoreWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            pluginStoreWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", PluginStore.pluginStoreWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", PluginStore.pluginStoreWindow.Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", PluginStore.pluginStoreWindow.Window_Minimize);

        }

        private void loadDB()
        {
            pluginStoreWindow.Welcome_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Welcome_Text");
            pluginStoreWindow.Search_Text.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Search_Text");
            pluginStoreWindow.LookAround_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("LookAround_Text");
            pluginStoreWindow.Plugins_ForYou.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_ForYou");
            pluginStoreWindow.Plugins_Original.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Original");
            pluginStoreWindow.Plugins_Charts.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Charts");
            pluginStoreWindow.Plugins_Games.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Games");
            pluginStoreWindow.Plugins_Apps.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Apps");
        }

        private void loadColor()
        {
            pluginStoreWindow.Search_Text.Foreground = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            pluginStoreWindow.LookAround_Text.Foreground = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            pluginStoreWindow.Plugins_ForYou.Foreground = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            pluginStoreWindow.Plugins_ForYou.BorderBrush = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
        }

        private void MenuSwitch(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.Label label = sender as System.Windows.Controls.Label;

            if (label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_ForYou") ||
                label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Original") ||
                label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Charts") ||
                label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Games") ||
                label.Content.ToString() == DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValuePluginStore("Plugins_Apps"))
            {
                pluginStoreWindow.Plugins_ForYou.Foreground = new SolidColorBrush(Color.FromArgb(255, 120, 121, 122));
                pluginStoreWindow.Plugins_ForYou.BorderThickness = new System.Windows.Thickness(0);
                pluginStoreWindow.Plugins_Original.Foreground = new SolidColorBrush(Color.FromArgb(255, 120, 121, 122));
                pluginStoreWindow.Plugins_Original.BorderThickness = new System.Windows.Thickness(0);
                pluginStoreWindow.Plugins_Charts.Foreground = new SolidColorBrush(Color.FromArgb(255, 120, 121, 122));
                pluginStoreWindow.Plugins_Charts.BorderThickness = new System.Windows.Thickness(0);
                pluginStoreWindow.Plugins_Games.Foreground = new SolidColorBrush(Color.FromArgb(255, 120, 121, 122));
                pluginStoreWindow.Plugins_Games.BorderThickness = new System.Windows.Thickness(0);
                pluginStoreWindow.Plugins_Apps.Foreground = new SolidColorBrush(Color.FromArgb(255, 120, 121, 122));
                pluginStoreWindow.Plugins_Apps.BorderThickness = new System.Windows.Thickness(0);

                label.Foreground = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
                label.BorderBrush = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
                label.BorderThickness = new System.Windows.Thickness(0,0,0,4);
            }

        }


        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PluginStore.pluginStoreWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PluginStore.pluginStoreWindow.DWC_Window.WindowState == System.Windows.WindowState.Normal)
            {
                PluginStore.pluginStoreWindow.DWC_Window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                PluginStore.pluginStoreWindow.DWC_Window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PluginStore.pluginStoreWindow.DWC_Window.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        private void setGridColor()
        {

            pluginStoreWindow.HeaderBar.Background = ProjectVariables.Theme_DarkestDark;

            pluginStoreWindow.BackgroundImage.Background = ProjectVariables.Theme_DarkBackground;
            pluginStoreWindow.Search.Fill = ProjectVariables.Theme_DarkBackground;

        }

    }
}
