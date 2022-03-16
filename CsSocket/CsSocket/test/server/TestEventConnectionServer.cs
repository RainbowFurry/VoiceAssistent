using CSSocket.core;
using System;

namespace CSSocket.test.server
{
    class TestEventConnectionServer : IConnectionEvents
    {
        public void OnConnectEvent(Guid guid)
        {
            Console.WriteLine("New client connected: " + guid.ToString());
        }

        public void OnDisconnectEvent(Guid guid)
        {
            Console.WriteLine("Old client disconnected: " + guid.ToString());
        }
    }
}
