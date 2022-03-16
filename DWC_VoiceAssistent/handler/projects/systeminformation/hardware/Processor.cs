using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Diagnostics;
using System.Management;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Processor
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;
        public static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        /// <summary>
        /// Show Processor Information and Create Log File
        /// </summary>
        [STAThread]
        public static void Processor_Click()
        {

            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {

                systemInformationWindow.DWC_CPUInformation.Content =
                   "Prozessor:" + "\n\n" +
                "Name                        -  " + obj["Name"] + "\n" +
                "DeviceID                   -  " + obj["DeviceID"] + "\n" +
                "Manufacturer               -  " + obj["Manufacturer"] + "\n" +
                "CurrentClockSpeed          -  " + obj["CurrentClockSpeed"] + "\n" +
                "Caption                    -  " + obj["Caption"] + "\n" +
                "NumberOfCores              -  " + obj["NumberOfCores"] + "\n" +
                "NumberOfEnabledCore        -  " + obj["NumberOfEnabledCore"] + "\n" +
                "NumberOfLogicalProcessors  -  " + obj["NumberOfLogicalProcessors"] + "\n" +
                "Architecture               -  " + obj["Architecture"] + "\n" +
                "Family                     -  " + obj["Family"] + "\n" +
                "ProcessorType              -  " + obj["ProcessorType"] + "\n" +
                "Characteristics            -  " + obj["Characteristics"] + "\n" +
                "AddressWidth               -  " + obj["AddressWidth"] + "\n";

                coreCount = Convert.ToInt32(obj["NumberOfCores"]);
            }

            LogFileManager.createLogEntrence(systemInformationWindow.DWC_CPUInformation.Content.ToString());

            //CPU_RefreshTimer();

        }

        private static int coreCount;

        private static PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private static PerformanceCounter theCPUCore1 = new PerformanceCounter("Processor", "% Processor Time", "0");
        private static PerformanceCounter theCPUCore2 = new PerformanceCounter("Processor", "% Processor Time", "1");
        private static PerformanceCounter theCPUCore3 = new PerformanceCounter("Processor", "% Processor Time", "2");
        private static PerformanceCounter theCPUCore4 = new PerformanceCounter("Processor", "% Processor Time", "3");

        private static PerformanceCounter theCPUCore5 = new PerformanceCounter("Processor", "% Processor Time", "4");
        private static PerformanceCounter theCPUCore6 = new PerformanceCounter("Processor", "% Processor Time", "5");
        private static PerformanceCounter theCPUCore7 = new PerformanceCounter("Processor", "% Processor Time", "6");
        private static PerformanceCounter theCPUCore8 = new PerformanceCounter("Processor", "% Processor Time", "7");

        [STAThread]
        public static void updateCPUCores()
        {

            if (coreCount == 2)
            {
                systemInformationWindow.DWC_CPUCore_Info1.Content = "  CPU    : " + theCPUCounter.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 1 : " + theCPUCore1.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 2 : " + theCPUCore2.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 3 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 4 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content = " Core 5 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 6 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 7 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 8 : " + " -  \n";
            }
            else if (coreCount == 4)
            {
                systemInformationWindow.DWC_CPUCore_Info1.Content = "  CPU    : " + theCPUCounter.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 1 : " + theCPUCore1.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 2 : " + theCPUCore2.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 3 : " + theCPUCore3.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 4 : " + theCPUCore4.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content = "  Core 5 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 6 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 7 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 8 : " + " -  \n";
            }
            else if (coreCount == 6)
            {
                systemInformationWindow.DWC_CPUCore_Info1.Content = "  CPU    : " + theCPUCounter.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 1 : " + theCPUCore1.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 2 : " + theCPUCore2.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 3 : " + theCPUCore3.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 4 : " + theCPUCore4.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content = "  Core 5 : " + theCPUCore5.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 6 : " + theCPUCore6.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 7 : " + " -  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 8 : " + " -  \n";
            }
            else if (coreCount == 8)
            {
                systemInformationWindow.DWC_CPUCore_Info1.Content = "  CPU    : " + theCPUCounter.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 1 : " + theCPUCore1.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 2 : " + theCPUCore2.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 3 : " + theCPUCore3.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info1.Content += "  Core 4 : " + theCPUCore4.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content = "  Core 5 : " + theCPUCore5.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 6 : " + theCPUCore6.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 7 : " + theCPUCore7.NextValue().ToString("0.00") + " %  \n";
                systemInformationWindow.DWC_CPUCore_Info2.Content += "  Core 8 : " + theCPUCore8.NextValue().ToString("0.00") + " %  \n";
            }
            else
            {
                systemInformationWindow.DWC_CPUCore_Info2.Content = "The CPU could not be initialized! \n";
            }

        }

        public static void CPU_RefreshTimer()
        {

            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            updateCPUCores();
        }

    }
}
