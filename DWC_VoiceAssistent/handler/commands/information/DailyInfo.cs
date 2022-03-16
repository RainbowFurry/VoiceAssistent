using DarkWolfCraftSys;
using System;

namespace DWC_VoiceAssistent.handler.commands.information
{
    class DailyInfo : ICommand
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public bool RunCmd(string cmd, string[] args)
        {
            voice.VoiceAssistentSpeechSynthesizer.speak(db.DatabaseManager.loadInformationDBValue("Tagesinfo_Answer").Replace("%time%", DateTime.Now.ToLongTimeString()).Replace("%date%", DateTime.Now.ToLongDateString()));
            return true;
        }

        public Exception ThrowException(string type, string message)
        {
            throw new NotImplementedException();
        }
    }
}
