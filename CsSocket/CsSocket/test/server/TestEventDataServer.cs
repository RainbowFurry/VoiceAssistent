using CSSocket.core;
using System;
using System.IO;

namespace CSSocket.test.server
{
    class TestEventDataServer : IIncomingDataEvent
    {
        public void OnEvent(string channel, Guid guid, byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            string secretPw = binaryReader.ReadString();
            Console.WriteLine("ClientSecretPW: " + secretPw);
            MemoryStream memory = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memory);
            writer.Write(secretPw);
            ServerTest.serverTest.server.GetClient(guid).WriteOutput("test_socket_connection", memory.ToArray());
        }
    }
}
