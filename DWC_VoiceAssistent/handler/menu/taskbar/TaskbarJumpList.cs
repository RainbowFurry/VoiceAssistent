using DarkWolfCraftSys;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Reflection;

namespace DWC_VoiceAssistent.handler.menu.taskbar
{
    internal class TaskbarJumpList
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /*Die JumpListe ist das Rechtsklick Menü das kommt wenn man in der Taskleiste
         * auf das ProgrammIcon einen Rechtsklick macht.
         */

        private static JumpList jumpList;
        private static string save_path = Assembly.GetEntryAssembly().Location.Replace("DWC_VoiceAssistent.exe", "") + @"src\taskbar\";
        private static string save_path_onlinestate = Assembly.GetEntryAssembly().Location.Replace("DWC_VoiceAssistent.exe", "") + @"src\onlinestate\";

        /// <summary>
        /// Initialize the Windows Taskbar Programm Icon JumpList
        /// </summary>
        public static void loadJumpList()
        {

            //jumpList.ClearAllUserTasks();
            //JumpListItem i = new JumpListItem("");

            jumpList = JumpList.CreateJumpList();

            string myExecutablePath = Assembly.GetEntryAssembly().Location;//Kann später weg...

            JumpListCustomCategory personalCategory = new JumpListCustomCategory("DWC_VoiceAssistent");//Category Name

            JumpListLink status = new JumpListLink(myExecutablePath, db.DBManager.loadDBValueThumbnailJumplist("Onlinestatus"));//db.DBManager.loadDBValueThumbnailJumplist("Onlinestatus")
            status.IconReference = new IconReference(save_path_onlinestate + "Online.ico", 0);//Image Location im ordner das erste bild
            status.Arguments = "/Window:Onlinestatus";
            personalCategory.AddJumpListItems(status);

            JumpListLink settings = new JumpListLink(myExecutablePath, db.DBManager.loadDBValueThumbnailJumplist("Settings"));
            settings.IconReference = new IconReference(save_path + "settings.ico", 0);
            settings.Arguments = "Command-B";
            personalCategory.AddJumpListItems(settings);

            JumpListLink logout = new JumpListLink(myExecutablePath, db.DBManager.loadDBValueThumbnailJumplist("Logout"));
            logout.IconReference = new IconReference(save_path + @"exit.ico", 0);
            logout.Arguments = "Command-C";
            personalCategory.AddJumpListItems(logout);

            JumpListLink exit = new JumpListLink(myExecutablePath, db.DBManager.loadDBValueThumbnailJumplist("Exit"));
            exit.IconReference = new IconReference(save_path + @"close.ico", 0);
            exit.Arguments = "Command-D";
            personalCategory.AddJumpListItems(exit);

            jumpList.AddCustomCategories(personalCategory);

            LogFileManager.createLogEntrence("The Windows Task bar Icon JumpList has successfully been loaded!");

            refrehsJumpList();
        }

        /// <summary>
        /// Add an Item to the Windows Taskbar Programm Icon Jumplist
        /// </summary>
        public void addJumpList()
        {

        }

        /// <summary>
        /// Refresh the Windows Taskbar Programm Icon Jumplist
        /// </summary>
        public static void refrehsJumpList()
        {
            try
            {
                if (jumpList != null)
                    jumpList.Refresh();
            }
            catch
            {

            }
            //JumpList.SetJumpList(Application.Current, jumpList);
        }

        private void JumpList_JumpItemsRejected(object sender, System.Windows.Shell.JumpItemsRejectedEventArgs e)
        {
            Console.WriteLine(e.RejectedItems.ToString());
        }

    }
}
