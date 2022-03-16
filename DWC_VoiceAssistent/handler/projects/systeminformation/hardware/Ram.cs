using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System.Management;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Ram
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show RAM Information and Create Log File
        /// </summary>
        public static void RAMClick()
        {

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                systemInformationWindow.DWC_RAMInformation.Content =
                  "RAM:" + "\n\n" +
                  "Total Visible Memory: " + result["TotalVisibleMemorySize"] + " KB" + "\n" +
                  "Free Physical Memory: " + result["FreePhysicalMemory"] + " KB" + "\n" +
                  "Total Virtual Memory: " + result["TotalVirtualMemorySize"] + " KB" + "\n" +
                  "Free Virtual Memory: " + result["FreeVirtualMemory"] + " KB" + "\n";
            }

            LogFileManager.createLogEntrence(systemInformationWindow.DWC_RAMInformation.Content.ToString());

        }

    }
}
