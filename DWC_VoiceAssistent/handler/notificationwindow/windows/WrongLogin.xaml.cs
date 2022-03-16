using System;
using System.Windows;

namespace DWC_VoiceAssistent.handler.notificationwindow.windows
{
    public partial class WrongLogin : Window
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public static WrongLogin wrongLoginWindow;

        public WrongLogin()
        {
            InitializeComponent();
            wrongLoginWindow = this;
            new handler.WrongLoginHandler();

        }
    }
}
