using System;
using System.Collections;
using System.Resources;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    class TranslateLocalLanguageDB
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //Create ALL DBS INSTAND
        //in the right spot - folder

        private String[] languages = { "English", "French", "Italian", "Russia", "Spanish", "China" }; //German is default

        private String[] hashDB_Key = new String[1000];
        private String[] hashDB_Value = new String[1000];
        private int position = 0;

        public TranslateLocalLanguageDB()
        {
            loadLanguages(@"C:\Users\DarkS\Documents\HeimServer\German.resx");//Kann man die Source Datei angeben???
        }

        private void loadLanguages(String languagePath)
        {
            for (int i = 0; i < languages.Length; i++)
            {
                position = i;

                loadContenetForDB(languagePath);
                writeContentToDB(languagePath);
            }
        }
        
        private void loadContenetForDB(String languagePath)
        {
            ResXResourceReader resxReader = new ResXResourceReader(languagePath);

            int step = -1;
            
            foreach (DictionaryEntry entry in resxReader)
            {
                Console.WriteLine("Key: " + entry.Key);
                Console.WriteLine("Value: " + entry.Value);

                if (entry.Value != null && entry.Key != null)
                {

                    step++;
                    hashDB_Key[step] = entry.Key.ToString();
                    hashDB_Value[step] = entry.Value.ToString();

                } 

            }


        }

        private void writeContentToDB(String languagePath)
        {

            ResXResourceWriter resx = new ResXResourceWriter(languagePath + languages[position] + @".resx");

            for (int i = 0; i < hashDB_Value.Length; i++)
            {
                if(hashDB_Key[i] != null && hashDB_Value[i] != null)
                    resx.AddResource(hashDB_Key[i], hashDB_Value[i]);//TranslateText.translateText(hashDB_Value[i]).Result);
            }
            resx.Generate();

        }

    }
}
