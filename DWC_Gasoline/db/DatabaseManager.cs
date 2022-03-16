﻿using DarkWolfCraftSys;
using System;
using System.Resources;

namespace DWC_Gasoline.db
{
    class DatabaseManager
    {

        private static String language = ConfigManager.language;
        private static ResourceManager resourceManager;

        public static String loadDBValue(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(English));
            }

            return resourceManager.GetString(searchWord);

        }

    }
}
