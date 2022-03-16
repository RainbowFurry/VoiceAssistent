using System;

namespace CSSocket.core
{
    interface IIncomingDataEvent
    {

        void OnEvent(string channel, Guid guid, byte[] bytes);

    }
}
