using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Management;
using System.Windows;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Microphone
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show Microphones Information and Create Log File
        /// </summary>
        public static void MicrofonClick(object sender, RoutedEventArgs e)
        {

            ManagementObjectSearcher myAudioObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");

            systemInformationWindow.DWC_Microphone.Content = "Mikrofon:\n";

            foreach (ManagementObject obj in myAudioObject.Get())
            {
                systemInformationWindow.DWC_GPUInformation.Content += "Name  -  " + obj["Name"] + "\n" +
                    "ProductName  -  " + obj["ProductName"] + "\n" +
                    "Availability  -  " + obj["Availability"] + "\n" +
                    "DeviceID  -  " + obj["DeviceID"] + "\n" +
                    "PowerManagementSupported  -  " + obj["PowerManagementSupported"] + "\n" +
                    "Status  -  " + obj["Status"] + "\n" +
                    "StatusInfo  -  " + obj["StatusInfo"] + "\n" +
                    String.Empty.PadLeft(obj["ProductName"].ToString().Length, '=') + "\n\n";
            }

            LogFileManager.createLogEntrence(systemInformationWindow.DWC_Microphone.Content.ToString());

        }

    }
}
