using CSSocket.core;
using System;
using System.IO;

namespace CSSocket.test.client
{
    class TestEventDataClient : IIncomingDataEvent
    {
        public void OnEvent(string channel, Guid guid, byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            string secretPw = binaryReader.ReadString();
            Console.WriteLine("ClientSecretPW: " + secretPw);
        }
    }
}
