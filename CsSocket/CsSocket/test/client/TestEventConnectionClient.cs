using CSSocket.core;
using System;

namespace CSSocket.test.client
{
    class TestEventConnectionClient : IConnectionEvents
    {
        public void OnConnectEvent(Guid guid)
        {
            Console.WriteLine("Client is connected: New");   
        }

        public void OnDisconnectEvent(Guid guid)
        {
            Console.WriteLine("Client is disconnected: Old");
        }
    }
}
