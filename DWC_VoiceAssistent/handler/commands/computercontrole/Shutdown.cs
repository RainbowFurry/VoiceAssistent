using System;

namespace DWC_VoiceAssistent.handler.commands.computercontrole
{
    class Shutdown : ICommand
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public bool RunCmd(string cmd, string[] args)
        {
            voice.VoiceAssistentSpeechSynthesizer.speak(CommandController.randomCommandResultOutput(db.DatabaseManager.loadComputerControleDBValue("ShutdownComputer_Answer")));
            System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");
            return true;
        }

        public Exception ThrowException(string type, string message)
        {
            throw new NotImplementedException();
        }
    }
}
