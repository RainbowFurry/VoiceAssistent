using System;
using System.IO;
using System.Reflection;

namespace DarkWolfCraftSys
{
    public class LogFileManager
    {

        /*
        * Creator: Jason H.
         * Date: -
        * Comment: -
        */

        public static string save_path = Assembly.GetExecutingAssembly().Location.Replace("DWC_VoiceAssistent.exe", "").Replace(".dll", "").Replace("DarkWolfCraftSys", "") + @"\logs\";
        private static string save_path_devlogs = Assembly.GetExecutingAssembly().Location.Replace("DWC_VoiceAssistent.exe", "").Replace(".dll", "").Replace("DarkWolfCraftSys", "") + @"\logs\devlogs\";

        /// <summary>
        /// Create a daily Logfile if not exist and add new Message
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="logMessage"></param>
        public static void createLogEntrence(String logMessage)
        {

            //create logfile if not exist with given name
            if (!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);
            }

            File.AppendAllText(save_path + DateTime.Now.ToLongDateString() + ".txt", "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "] " + logMessage + "\n");

            Console.WriteLine("New Log entrence added -> [" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "] " + logMessage + "\n");

        }

        /// <summary>
        /// Create a daily Logfile if not exist and add new Message
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="logMessage"></param>
        //public static void createDeveloperLogEntrence(String logMessage)
        //{

        //   //create logfile if not exist with given name
        //   if (!Directory.Exists(save_path_devlogs))
        //   {
        //      Directory.CreateDirectory(save_path_devlogs);
        //   }

        //   File.AppendAllText(save_path_devlogs + DateTime.Now.ToLongDateString() + ".txt", "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "] " + logMessage + "\n");

        //   Console.WriteLine("New Log entrence added -> [" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "] " + logMessage + "\n");

        //}

        /// <summary>
        /// Add Exeption output to the User Log File
        /// </summary>
        /// <param name="exception"></param>
        public static void createLogExeptionEntrence(Exception exception)//später error description adden um nicht den fehlercode auszugeben sondern zu sagen xyz ging nicht weil...
        {                                                                 //DB übersetzen... //Report senden??? darunter als feld und man muss nur ja nein drücken...

            string errorMessage = "[ERROR]\n" +
                             "[ERROR][Message] - " + exception.Message + "\n" +
                             "[ERROR][Message] - " + exception.Source + "\n" +
                             "[ERROR][Message] - " + exception.Data + "\n" +
                             "[ERROR][Message] - " + exception.StackTrace + "\n" +
                             "[ERROR][Message] - " + exception.TargetSite;

            createLogEntrence(errorMessage);
            Console.WriteLine(errorMessage);
            NotificationMessage.errorNotification("Oops es tut uns leid doch ein Fehler ist aufgetreten!", "");
        }

    }
}
