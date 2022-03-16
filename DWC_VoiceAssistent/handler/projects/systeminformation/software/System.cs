using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Management;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.software
{
    class System
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show Pc Information and Create Log File
        /// </summary>
        public static void OwnWinSysClick()
        {

            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {

                systemInformationWindow.DWC_SystemInformation.Content =
                 "Betriebssystem:" + "\n\n" +
                 "Caption  -  " + obj["Caption"] + "\n" +
                 "WindowsDirectory  -  " + obj["WindowsDirectory"] + "\n" +
                 "ProductType  -  " + obj["ProductType"] + "\n" +
                 "SerialNumber  -  " + obj["SerialNumber"] + "\n" +
                 "SystemDirectory  -  " + obj["SystemDirectory"] + "\n" +
                 "CountryCode  -  " + obj["CountryCode"] + "\n" +
                 "CurrentTimeZone  -  " + obj["CurrentTimeZone"] + "\n" +
                 "EncryptionLevel  -  " + obj["EncryptionLevel"] + "\n" +
                 "OSType  -  " + obj["OSType"] + "\n" +
                 "Version  -  " + obj["Version"] + "\n";

            }

            LogFileManager.createLogEntrence(systemInformationWindow.DWC_SystemInformation.Content.ToString());

        }

    }
}
