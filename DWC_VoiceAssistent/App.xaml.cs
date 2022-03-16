using System;
using System.Windows;

namespace DWC_VoiceAssistent
{

    public partial class App : Application
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static String StartParameter;

        /// <summary>
        /// Load Programm StartEvents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void App_Startup(object sender, StartupEventArgs e)
        {

            for(int i = 0; i < e.Args.Length; i++)
            {
                StartParameter += e.Args[i] + " ";
            }
                
        }

    }
}
