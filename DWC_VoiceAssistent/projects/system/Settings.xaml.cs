using DarkWolfCraftSys;
using System;
using System.ComponentModel;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class Settings : Window
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static Settings SettingsWindow;

        /// <summary>
        /// Initialize Settings Window
        /// </summary>
        public Settings()
        {

            InitializeComponent();
            SettingsWindow = this;
            this.DWC_Window.WindowState = WindowState.Maximized;
            WindowOverlayManager.updateAllWindowContent(this.BackgroundImage);

            new handler.projects.settings.WindowControler();
            Closing += OnClose;
        }

        private void OnClose(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
