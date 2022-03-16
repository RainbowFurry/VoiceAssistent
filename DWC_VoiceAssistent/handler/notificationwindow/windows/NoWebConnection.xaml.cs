using System;
using System.Windows;

namespace DWC_VoiceAssistent.handler.notificationwindow.windows
{
    public partial class NoWebConnection : Window
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static NoWebConnection noWebConnectionWindow;

        public NoWebConnection()
        {
            InitializeComponent();
            noWebConnectionWindow = this;
            new handler.NoWebConnectionHandler();
        }

    }
}
