using DarkWolfCraftSys;
using System;
using System.Resources;

namespace DWC_VoiceAssistent.handler.notificationwindow.db
{
    class DBManager
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static String language = ConfigManager.language;
        private static ResourceManager resourceManager;

        public static String loadDBValueNoWebConnection(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(db.NoWebConnection_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(db.NoWebConnection_English));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueWrongLogin(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(db.WrongLogin_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(db.WrongLogin_English));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

    }
}
