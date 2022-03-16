using CSSocket.core;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSSocket.server
{
    class CsServerConnection
    {

        private readonly Socket _socket;
        private readonly CsServer _csServer;
        private Guid _guid;

        public CsServerConnection(Socket socket, CsServer csServer)
        {
            _socket = socket;
            _csServer = csServer;
            _guid = Guid.NewGuid();
            Console.WriteLine("[" + Thread.CurrentThread.Name + "] Create CsServerConnection...");
        }

        public void SetEnable()
        {
            OnConnect();
            while(IsValidConnection())
            {
                ReadInput();
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
            foreach (ChannelDataEventPacket channelData in _csServer._dataEventPackets)
            {
                if (channelData.Channel.Equals(headerChannel))
                    channelData.DataEvent.OnEvent(headerChannel, _guid, fullData);
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

        public void SetDisable()
        {
            CloseConnection();
        }

        public void CloseConnection()
        {
            if (IsValidConnection())
                _socket.Close();
            OnDisconnect();
            _csServer._csServerConections.Remove(_guid);
        }

        public void OnDisconnect()
        {
            foreach (IConnectionEvents connectionEvents in _csServer._connectionEvents)
            {
                connectionEvents.OnDisconnectEvent(_guid);
            }
        }

        public bool IsValidConnection()
        {
            return _socket.Connected;
        }

        private void OnConnect()
        {
            foreach (IConnectionEvents connectionEvent in _csServer._connectionEvents)
            {
                connectionEvent.OnConnectEvent(_guid);
            }
            
        }

        public Guid GetGuid()
        {
            return _guid;
        }

    }
}
