using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Diagnostics;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.software
{
    class SystemProcesse
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show Processes Information and Create Log File
        /// </summary>
        [STAThread]
        public static void ProzesseClick()
        {

            String content = "";

            Process[] processes = Process.GetProcesses();//Process.GetProcesses(Environment.MachineName);
                                                         //Process[] remoteByName = Process.GetProcessesByName("notepad", Environment.MachineName);//get all processe from notepad

            for (int i = 0; i < processes.Length; i++)
            {
                content += "Process Name: " + processes[i].ProcessName + "\n";
                content += "ID: " + processes[i].Id + "\n";
                content += "Window Title: " + processes[i].MainWindowTitle + "\n";
                content += "Start Info: " + processes[i].StartInfo.FileName + "\n";
                content += "Base Priority: " + processes[i].BasePriority + "\n";
                content += "V-Ram 64: " + processes[i].VirtualMemorySize64 + "\n";
                content += "Threads: " + processes[i].Threads.Count + "\n";
                content += "Session ID: " + processes[i].SessionId + "\n";
                content += "\n";

            }

            systemInformationWindow.DWC_Process.Content = content;
            LogFileManager.createLogEntrence(systemInformationWindow.DWC_Process.Content.ToString());

        }

    }
}
