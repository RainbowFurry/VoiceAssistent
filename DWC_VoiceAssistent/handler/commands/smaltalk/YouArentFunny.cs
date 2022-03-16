using System;

namespace DWC_VoiceAssistent.handler.commands.smaltalk
{
    class YouArentFunny : ICommand
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public bool RunCmd(string cmd, string[] args)
        {
            voice.VoiceAssistentSpeechSynthesizer.speak(CommandController.randomCommandResultOutput(db.DatabaseManager.loadSmalTalkDBValue("YouAreNotFunny_Answer")));
            return true;
        }

        public Exception ThrowException(string type, string message)
        {
            throw new NotImplementedException();
        }
    }
}
