using DarkWolfCraftSys;
using System;
using System.Resources;

namespace DWC_Weather.db
{
    class DatabaseManager
    {

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

            return resourceManager.GetString(searchWord);

        }

    }
}
