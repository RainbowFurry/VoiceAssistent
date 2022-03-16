using DarkWolfCraftSys;
using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class Report : Window
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static Report reportWindow;

        /// <summary>
        /// Initialize Report Window
        /// </summary>
        public Report()
        {
            InitializeComponent();
            reportWindow = this;
            WindowOverlayManager.updateAllWindowContent(reportWindow.BackgroundImage);
            new handler.projects.reports.WindowControler();
            this.Show();
        }

    }
}
