using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{

    public partial class DWC_OnlineStatus : UserControl
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public DWC_OnlineStatus()
        {
            InitializeComponent();
        }

        public OnlineStatus OnlineState { get; set; }
        public ImageSource ProfilePicture { get; set; }
        public String UserName { get; set; }
        public String UserStatus { get; set; }
        public String MessageSentTime { get; set; }

        public double OverlayRounding { get; set; }
        public SolidColorBrush OverlayBackground { get; set; }

    }

    public class OnlineStatus
    {

        public string online;
        public string offline;
        public string afk;
        public string nichtStören;

    }

}
