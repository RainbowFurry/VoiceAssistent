using DarkWolfCraftSys;
using System;
using System.Resources;

namespace DWC_VoiceAssistent.handler.menu.taskbar.db
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

        public static String loadDBValueThumbnailJumplist(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(ThumbnailJumplist_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(ThumbnailJumplist_English));
            }

            return resourceManager.GetString(searchWord);

        }

        public static String loadDBValueThumbnailToolbar(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(ThumbnailToolbar_German));
            }
            else
            {
                resourceManager = new ResourceManager(typeof(ThumbnailToolbar_English));
            }

            return resourceManager.GetString(searchWord);

        }

    }
}
