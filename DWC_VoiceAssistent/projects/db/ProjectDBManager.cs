using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.db.rating;
using System;
using System.Resources;

namespace DWC_VoiceAssistent.projects.db
{
    class ProjectDBManager
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static String language = ConfigManager.language;
        private static ResourceManager resourceManager;

        public static String loadDBValueSettings(String searchWord)
        {
            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(settings.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(settings.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(settings.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(settings.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(settings.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(settings.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(settings.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueReport(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(report.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(report.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(report.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(report.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(report.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(report.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(report.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueLogin(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(login.login.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(login.login.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(login.login.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(login.login.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(login.login.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(login.login.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(login.login.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueLoginRegisterConfirm(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(login.confirmregistration.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueLoginRegister(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(login.registration.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(login.registration.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(login.registration.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(login.registration.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(login.registration.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(login.registration.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(login.registration.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValuePluginStore(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(pluginstore.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueProgrammInformation(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(programminformation.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(programminformation.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(programminformation.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(programminformation.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(programminformation.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(programminformation.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(programminformation.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueColorPicker(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(colorpicker.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

        public static String loadDBValueRating(String searchWord)
        {

            if (language == "de-DE")
            {
                resourceManager = new ResourceManager(typeof(rating.German));
            }
            else if (language == "en-EN")
            {
                resourceManager = new ResourceManager(typeof(rating.English));
            }
            else if (language == "fr-FR")
            {
                resourceManager = new ResourceManager(typeof(rating.French));
            }
            else if (language == "ru-RU")
            {
                resourceManager = new ResourceManager(typeof(rating.Russian));
            }
            else if (language == "chn-CHN")
            {
                resourceManager = new ResourceManager(typeof(rating.Chinese));
            }
            else if (language == "it-IT")
            {
                resourceManager = new ResourceManager(typeof(rating.Italian));
            }
            else if (language == "es-ES")
            {
                resourceManager = new ResourceManager(typeof(rating.Spanish));
            }

            if (resourceManager.GetString(searchWord) != null)
                return resourceManager.GetString(searchWord);
            else
                return "NULL";

        }

    }
}
