using CSSocket.core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace CSSocket.client
{
   
    class CsClientConnection
    {

        private readonly string _host;
        private readonly int _port;
        private readonly Socket _socket;
        private bool _keepAlive;
        private Guid _guid;
        private readonly List<ChannelDataEventPacket> _dataEventPackets;
        private readonly List<IConnectionEvents> _connectionEvents;
        private readonly IPEndPoint _remoteEp;

        public CsClientConnection(string host, int port)
        {
            _host = host;
            _port = port;
            _keepAlive = true;

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPAddress ipAddress = IPAddress.Parse(_host);
            _remoteEp = new IPEndPoint(ipAddress, _port);
            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            _dataEventPackets = new List<ChannelDataEventPacket>();
            _connectionEvents = new List<IConnectionEvents>();
            _guid = Guid.NewGuid();
            Console.WriteLine("[" + Thread.CurrentThread.Name + "] Create CsClientConnection...");
        }

        [STAThread, MethodImpl(MethodImplOptions.Synchronized)]
        public void SetEnable()
        {
            _keepAlive = true;
            while(_keepAlive)
            {
                try
                {
                    Connect();
                    while(IsValidConnection())
                    {
                        ReadInput();
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Cannot connect to Socket");
                }
            }
        }

        public bool IsValidConnection()
        {
            return _socket.Connected;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetDisable()
        {
            _keepAlive = false;
            CloseConnection();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void CloseConnection()
        {
            if(IsValidConnection())
                _socket.Close();
            OnDisconnect();
        }

        public void OnDisconnect()
        {
            foreach(IConnectionEvents connectionEvents in _connectionEvents)
            {
                connectionEvents.OnDisconnectEvent(_guid);
            }
        }

        public void Connect()
        {
            _socket.NoDelay = true;
            _socket.Connect(_remoteEp);
            foreach (IConnectionEvents events in _connectionEvents)
            {
                events.OnConnectEvent(_guid);
            }
        }

        public void WriteOutput(string headerChannel, byte[] bytes)
        {
            if (IsValidConnection())
            {
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                string data = headerChannel + ";" + Encoding.UTF8.GetString(bytes);
                binaryWriter.Write(data);
                _socket.Send(memoryStream.ToArray());
                binaryWriter.Flush();
                binaryWriter.Close();
                memoryStream.Close();
            }
        }

        public void ReadInput()
        {
            byte[] bytes = new byte[_socket.ReceiveBufferSize];
            if (_socket.Available > 0)
            {
                int bytesRec = _socket.Receive(bytes, 0, _socket.Available, SocketFlags.None);

                byte[] fullData = new byte[bytesRec];
                MemoryStream memory = new MemoryStream(bytes);
                BinaryReader binaryReader = new BinaryReader(memory);
                string[] data = binaryReader.ReadString().Split(';');
                string headerChannel = data[0];

                if (headerChannel == null || headerChannel.Length == 0)
                    return;

                OnDataInput(headerChannel, Encoding.UTF8.GetBytes(data[1]));
                binaryReader.Close();
                memory.Close();
            }
        }

        public void OnDataInput(string headerChannel, byte[] fullData)
        {
            foreach(ChannelDataEventPacket channelData in _dataEventPackets)
            {
                if (channelData.Channel.Equals(headerChannel))
                    channelData.DataEvent.OnEvent(headerChannel, _guid, fullData);
            }
        }

        public void UnregisterIncomingDataListener(IIncomingDataEvent dataEvent)
        {
            ChannelDataEventPacket searched = null;
            foreach (ChannelDataEventPacket channelData in _dataEventPackets)
            {
                if (channelData.DataEvent.Equals(dataEvent))
                    searched = channelData;
            }
            if(searched != null)
                _dataEventPackets.Remove(searched);
        }

        public void UnregisterConnectionListener(IConnectionEvents connection)
        {
            _connectionEvents.Remove(connection);
        }

        public void RegisterIncomingDataListener(string channel, IIncomingDataEvent dataEvent)
        {
            _dataEventPackets.Add(new ChannelDataEventPacket(channel, dataEvent));
        }

        public void RegisterConnectionListener(IConnectionEvents connection)
        {
            _connectionEvents.Add(connection);
        }

    }

}