using DarkWolfCraftSys;
using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class Store : Window
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public static Store storeWindow;

        public Store()
        {
            InitializeComponent();
            storeWindow = this;
            new handler.projects.store.WindowControler();
            //WindowOverlayManager.updateAllWindowContent(storeWindow.);
        }
    }
}
