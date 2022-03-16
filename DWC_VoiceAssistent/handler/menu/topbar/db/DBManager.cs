﻿using DarkWolfCraftSys;
using System;
using System.Resources;

namespace DWC_VoiceAssistent.handler.menu.topbar.db
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
                resourceManager = new ResourceManager(typeof(TopBar_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(TopBar_English));
            }

            return resourceManager.GetString(searchWord);

        }

    }
}