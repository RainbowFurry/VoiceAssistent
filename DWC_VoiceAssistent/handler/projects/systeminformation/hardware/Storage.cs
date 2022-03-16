using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Management;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Storage
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;
        private static string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        /// <summary>
        /// Show Storage Information and Create Log File
        /// </summary>
        public static void StorageInformation()
        {

            long mb = 1073741824; //megabyte in # of bytes 1024x1024x1024

            //Connection credentials to the remote computer - not needed if the logged in account has access
            ConnectionOptions oConn = new ConnectionOptions();
            //oConn.Username = "username";
            //oConn.Password = "password";
            System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\\\localhost", oConn);

            //get Fixed disk stats
            System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oReturnCollection = oSearcher.Get();

            //variables for numerical conversions
            double fs = 0;
            double us = 0;
            double tot = 0;
            double up = 0;
            double fp = 0;

            //for string formating args
            object[] oArgs = new object[2];
            systemInformationWindow.DWC_Storage.Content = "*******************************************\n";
            systemInformationWindow.DWC_Storage.Content += "Hard Disks\n";
            systemInformationWindow.DWC_Storage.Content += "*******************************************\n";

            //loop through found drives and write out info
            foreach (ManagementObject oReturn in oReturnCollection)
            {
                // Disk name
                systemInformationWindow.DWC_Storage.Content += "Name : " + oReturn["Name"].ToString() + "\n";

                //Free space in MB
                fs = Convert.ToInt64(oReturn["FreeSpace"]) / mb;

                //Used space in MB
                us = (Convert.ToInt64(oReturn["Size"]) - Convert.ToInt64(oReturn["FreeSpace"])) / mb;

                //Total space in MB
                tot = Convert.ToInt64(oReturn["Size"]) / mb;

                //used percentage
                up = us / tot * 100;

                //free percentage
                fp = fs / tot * 100;

                //used space args
                oArgs[0] = (object)us;
                oArgs[1] = (object)up;

                //write out used space stats
                //Console.WriteLine("Used: {0:#,###.##} GB ({1:###.##})%", oArgs);
                systemInformationWindow.DWC_Storage.Content += "Used: " + oArgs[0] + " GB " + oArgs[1] + "%\n";

                //free space args
                oArgs[0] = fs;
                oArgs[1] = fp;

                //write out free space stats
                systemInformationWindow.DWC_Storage.Content += "Free: " + oArgs[0] + " GB " + oArgs[1] + "%\n";
                systemInformationWindow.DWC_Storage.Content += "Size :  " + tot + " GB\n";
                systemInformationWindow.DWC_Storage.Content += "*******************************************\n";

                LogFileManager.createLogEntrence(systemInformationWindow.DWC_Storage.Content.ToString());

            }

        }

    }
}
