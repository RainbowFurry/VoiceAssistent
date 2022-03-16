using System;
using DarkWolfCraftSys;

/***********************************************
 * Porject Name : DWC_VoiceAssistent           *
 * Company Name : DarkWolfCraft.net            *
 * Description : Simulate a Command with your  *
 *               Voice                         *
 * Author : Jason Hoffmann (DarkSide_Wolf)     *
 **********************************************/

namespace DWC_VoiceAssistent.functions
{
    class Simulate
    {

        /// <summary>
        /// Simulate an Command - for Developer to test better if your Voice gets not detected correctly
        /// </summary>
        public static void SimulateInput(string command)
        {
            commands.RegisterCommands.h.EmulateRecognizeAsync(command);
            LogFileManager.createDeveloperLogEntrence("[Simulate][Command] The following Command has successfully been executed: " + command);
        }

    }
}
