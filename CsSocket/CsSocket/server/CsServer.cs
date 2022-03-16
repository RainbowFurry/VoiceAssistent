using CSSocket.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CSSocket.server
{

    class CsServer
    {
        private readonly int _port;

        Socket _socket;
        public readonly List<ChannelDataEventPacket> _dataEventPackets;
        public readonly List<IConnectionEvents> _connectionEvents;
        public readonly Dictionary<Guid, CsServerConnection> _csServerConections;

        public CsServer(int port)
        {
            _port = port;
            _csServerConections = new Dictionary<Guid, CsServerConnection>();
            _connectionEvents = new List<IConnectionEvents>();
            _dataEventPackets = new List<ChannelDataEventPacket>();
            Console.WriteLine("[" + Thread.CurrentThread.Name + "] Create CsServer...");
        }

        public void OpenServer()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _port);

            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(localEndPoint);
            _socket.Listen(10);
            Thread.CurrentThread.Name = "CsServer";
            do
            {
                Socket handler = _socket.Accept();
                handler.NoDelay = true;
                CsServerConnection serverConnection = new CsServerConnection(handler, this);
                _csServerConections.Add(serverConnection.GetGuid(), serverConnection);
                serverConnection.SetEnable();
            } while (_socket.Connected);
        }

        public void CloseServer()
        {
            _socket.Close();
            List<Guid> guids = new List<Guid>(_csServerConections.Keys);
            guids.ForEach((guid) =>
            {
                _csServerConections[guid].SetDisable();
            });
            _csServerConections.Clear();
        }

        public void RegisterIncomingDataListener(string channel, IIncomingDataEvent dataEvent)
        {
            _dataEventPackets.Add(new ChannelDataEventPacket(channel, dataEvent));
        }

        public void RegisterConnectionListener(IConnectionEvents connection)
        {
            _connectionEvents.Add(connection);
        }

        public CsServerConnection GetClient(Guid guid)
        {
            return _csServerConections[guid];
        }

        public Dictionary<Guid, CsServerConnection> GetClients()
        {
            return _csServerConections;
        }

    }

}
