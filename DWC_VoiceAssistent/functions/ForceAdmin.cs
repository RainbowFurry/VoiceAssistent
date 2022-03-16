using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.functions
{
   class ForceAdmin
   {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static bool programmStartedAsAdmin()
      {

         var identity = WindowsIdentity.GetCurrent();
         var principal = new WindowsPrincipal(identity);

         //check for admin rights
         if (principal.IsInRole(WindowsBuiltInRole.Administrator))
         {
            Console.WriteLine(principal.IsInRole(WindowsBuiltInRole.Administrator));

            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine(WindowsIdentity.GetCurrent().IsSystem);
            Console.WriteLine(WindowsIdentity.GetCurrent().User);
            Console.WriteLine(WindowsIdentity.GetCurrent().Owner);
            Console.WriteLine(WindowsIdentity.GetCurrent().Token);
            LogFileManager.createLogEntrence("DWC_VoiceAssistent is started with Administrativ Rights");
            return true;
         }
         else
         {
            //start this programm as Admin with all Administrativ Rights
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Assembly.GetEntryAssembly().CodeBase;
            proc.Verb = "runas";//run as admin
            Process.Start(proc);
            MainWindow.mainWindow.Close();
            LogFileManager.createLogEntrence("DWC_VoiceAssistent is not started with Administrativ Rights\n Restarting now with Administrativ rights");
            return false;
         }

      }

   }
}
