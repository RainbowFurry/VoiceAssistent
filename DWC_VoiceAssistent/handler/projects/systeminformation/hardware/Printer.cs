using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Management;
using System.Windows;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Printer
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show Printer Information and Create Log File
        /// </summary>
        public static void PrinterClick(object sender, RoutedEventArgs e)
        {

            ManagementObjectSearcher myPrinterObject = new ManagementObjectSearcher("select * from Win32_Printer");

            systemInformationWindow.DWC_PrinterInformation.Content = "Drucker:\n";

            foreach (ManagementObject obj in myPrinterObject.Get())
            {
                systemInformationWindow.DWC_PrinterInformation.Content += "Name  -  " + obj["Name"] + "\n" +
                    "Network  -  " + obj["Network"] + "\n" +
                    "Availability  -  " + obj["Availability"] + "\n" +
                    "Is default printer  -  " + obj["Default"] + "\n" +
                    "DeviceID  -  " + obj["DeviceID"] + "\n" +
                    "Status  -  " + obj["Status"] + "\n" +
                    String.Empty.PadLeft(obj["Name"].ToString().Length, '=') + "\n";
            }

            LogFileManager.createLogEntrence(systemInformationWindow.DWC_PrinterInformation.Content.ToString());

        }

    }
}
