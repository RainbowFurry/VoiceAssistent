using CSSocket.client;
using CSSocket.server;
using CSSocket.test.client;
using CSSocket.test.server;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSocket.test
{
    class ServerTest
    {

        public static ServerTest serverTest;
        private static CsClientConnection client;


        public CsServer server;

        public ServerTest()
        {
            Server();
            Client();
        }

        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new System.ArgumentNullException(nameof(args));
            }

            serverTest = new ServerTest();
            Console.ReadLine();
        }

        private static void Client()
        {
            client = new CsClientConnection("192.168.2.103", 9090);
            client.RegisterIncomingDataListener("test_socket_connection", new TestEventDataClient());
            client.RegisterConnectionListener(new TestEventConnectionClient());
            new Task(client.SetEnable).Start();
            Thread.Sleep(1000);
            MemoryStream memory = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memory, Encoding.UTF8);

            writer.Write("GRE4gterfe23fw3g54EBFilzujasdEWR");
            
            client.WriteOutput("test_socket_connection", memory.ToArray());
        }

        public void Server()
        {
            server = new CsServer(9090);
            server.RegisterIncomingDataListener("test_socket_connection", new TestEventDataServer());
            server.RegisterConnectionListener(new TestEventConnectionServer());
            new Task(server.OpenServer).Start();
        }

    }
}
