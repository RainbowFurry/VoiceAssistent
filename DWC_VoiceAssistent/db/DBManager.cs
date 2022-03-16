using System;
using System.Resources;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.db
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

        public static String loadDBValue(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(db.German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(db.English));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";
        }

    }
}
