using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{
    public partial class ProgrammInformation : Window
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static ProgrammInformation programmInformationWindow;

        public ProgrammInformation()
        {
            InitializeComponent();
            programmInformationWindow = this;
            new handler.projects.programminformation.WindowControler();
        } 
    }
}
