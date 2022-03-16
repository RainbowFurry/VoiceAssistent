using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Management;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Graphicscard
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformation = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show Graphics Card Information and Create Log File
        /// </summary>
        public static void GraficsCart_Click()
        {

            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                systemInformation.DWC_GPUInformation.Content =
                    "Grafik Karte:" + "\n\n" +
                    "Name            -  " + obj["Name"] + "\n" +
                    "Status          -  " + obj["Status"] + "\n" +
                    "Caption         -  " + obj["Caption"] + "\n" +
                    "DeviceID        -  " + obj["DeviceID"] + "\n" +
                    "AdapterRAM      -  " + obj["AdapterRAM"] + "\n" +
                    "AdapterDACType  -  " + obj["AdapterDACType"] + "\n" +
                    "DriverVersion   -  " + obj["DriverVersion"] + "\n";
            }

            LogFileManager.createLogEntrence(systemInformation.DWC_GPUInformation.Content.ToString());

        }

    }
}
