using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.windows
{

    public partial class Rating : Window
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static Rating ratingWindow;

        public Rating()
        {
            InitializeComponent();
            ratingWindow = this;
            new handler.projects.windows.rating.WindowControler();
        }
    }
}
