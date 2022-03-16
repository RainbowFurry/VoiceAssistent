using DarkWolfCraftSys;
using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class SystemInformation : Window
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static SystemInformation systemInformationWindow;

        public SystemInformation()
        {
            InitializeComponent();
            systemInformationWindow = this;
            systemInformationWindow.Show();
            WindowOverlayManager.updateAllWindowContent(systemInformationWindow.Background);
            // new handler.projects.systeminformation.WindowControler();
            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", Window_Minimize);

        }

    }
}
