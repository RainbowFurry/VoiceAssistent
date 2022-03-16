using System;

namespace DWC_VoiceAssistent.handler.commands.information
{
    class GetCurrentDate : ICommand
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public bool RunCmd(string cmd, string[] args)
        {
            voice.VoiceAssistentSpeechSynthesizer.speak(db.DatabaseManager.loadInformationDBValue("WhatDayIsItToday_Answer").Replace("%date%", DateTime.Now.ToLongDateString()));
            return true;
        }

        public Exception ThrowException(string type, string message)
        {
            throw new NotImplementedException();
        }

    }
}
