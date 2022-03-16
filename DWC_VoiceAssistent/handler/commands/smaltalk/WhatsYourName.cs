using System;

namespace DWC_VoiceAssistent.handler.commands.smaltalk
{
    class WhatsYourName : ICommand
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public bool RunCmd(string cmd, string[] args)
        {
            voice.VoiceAssistentSpeechSynthesizer.speak(CommandController.randomCommandResultOutput(db.DatabaseManager.loadSmalTalkDBValue("WhatsYourName_Answer")));
            return true;
        }

        public Exception ThrowException(string type, string message)
        {
            throw new NotImplementedException();
        }
    }
}
