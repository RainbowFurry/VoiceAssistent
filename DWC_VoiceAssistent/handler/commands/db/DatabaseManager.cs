using DarkWolfCraftSys;
using System;
using System.Resources;

namespace DWC_VoiceAssistent.handler.commands.db
{
    class DatabaseManager
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static String language = ConfigManager.language;
        private static ResourceManager resourceManager;

        public static String loadInformationDBValue(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(information.Information_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(information.Information_English));
            }

            return resourceManager.GetString(searchWord).ToLower();

        }

        public static String loadSmalTalkDBValue(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(smaltalk.SmalTalk_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(smaltalk.SmalTalk_English));
            }

            return resourceManager.GetString(searchWord).ToLower();

        }

        public static String loadInternControleDBValue(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(interncontrole.InternControle_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(interncontrole.InternControle_English));
            }

            return resourceManager.GetString(searchWord).ToLower();

        }

        public static String loadComputerControleDBValue(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(computercontrole.ComputerControle_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(computercontrole.ComputerControle_English));
            }

            return resourceManager.GetString(searchWord).ToLower();

        }

    }
}
