using DarkWolfCraftSys;
using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class PluginStore : Window
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public static PluginStore pluginStoreWindow;

        public PluginStore()
        {
            InitializeComponent();
            pluginStoreWindow = this;
            WindowOverlayManager.updateAllWindowContent(pluginStoreWindow.BackgroundImage);
            new handler.projects.pluginstore.WindowControler();

        }
    }
}
