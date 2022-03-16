using System;

namespace DWC_VoiceAssistent.handler.commands
{
    interface ICommand
    {
        bool RunCmd(string cmd, string[] args);

        Exception ThrowException(string type, string message);

    }
}
