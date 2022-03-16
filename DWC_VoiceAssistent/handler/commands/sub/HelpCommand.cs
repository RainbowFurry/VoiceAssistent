using System;

namespace DWC_VoiceAssistent.handler.commands
{
    internal class HelpCommand : ICommand
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public bool RunCmd(string cmd, string[] args)
        {
            return true;
        }

        public Exception ThrowException(string type, string message)
        {
            switch (type)
            {
                case "normal":
                    return new Exception(message);
                case "invalidcast":
                    return new InvalidCastException(message);
                default:
                    return new Exception(message);
            }
        }
    }
}