using DWC_VoiceAssistent.manager.socketmanagement.login;
using DWC_VoiceAssistent.manager.socketmanagement.pluginstore;
using DWC_VoiceAssistent.manager.socketmanagement.register;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DWC_VoiceAssistent.manager
{
    public class SocketManager
    {

        private static bool isRunning = false;
        private const int port = 9090;
        private static ManualResetEvent connectDone;
        private static ManualResetEvent sendDone;
        private static ManualResetEvent receiveDone;
        private static string response;
        private static IPEndPoint remoteEP;
        private static Socket client;
        public static StateObject state;

        public static void Send(string header, string message)
        {
            if (isRunning)
                return;
            isRunning = true;
            try
            {
                response = string.Empty;
                connectDone = new ManualResetEvent(false);
                sendDone = new ManualResetEvent(false);
                receiveDone = new ManualResetEvent(false);
                if (!IPAddress.TryParse("darkwolfcraft.net", out IPAddress ipAddress))
                    ipAddress = Dns.GetHostEntry("darkwolfcraft.net").AddressList[0];
                remoteEP = new IPEndPoint(ipAddress, port);
                client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                Send(client, Convert.ToBase64String(Encoding.UTF8.GetBytes(header + ":" + message)));
                sendDone.WaitOne();

                Receive(client);
                receiveDone.WaitOne();

                ManageResponse();

                client.Shutdown(SocketShutdown.Both);
                client.Close();
                isRunning = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ManageResponse()
        {
            switch (response.Split(':')[0])
            {
                case "register_request_success":
                    new RegisterRequestSuccess();
                    break;
                case "wrong_register_code":
                    new WrongRegisterCode(response.Split(':')[1]);
                    break;
                case "register_code_already_in_use":
                    new RegisterCodeAlreadyUsed(response.Split(':')[1]);
                    break;
                case "account_already_verified":
                    new AccountAlreadyVerified(response.Split(':')[1]);
                    break;
                case "account_not_exists":
                    new AccountNotExists(response.Split(':')[1]);
                    break;
                case "register_success":
                    new RegisterSuccess();
                    break;
                case "login_successfull":
                    new LoginSuccessful();
                    break;
                case "login_not_successfull":
                    new LoginNotSuccessful();
                    break;
                case "account_not_verified":
                    new AccountNotVerified(response.Split(':')[1]);
                    break;
                case "requested_plugin_for_store":
                    new HandleRequestedPlugins(response.Substring(27, response.Length - 27));
                    break;
                case "download_plugin_json":
                    new DownloadPluginJson(response.Substring(21, response.Length - 21));
                    break;
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());

                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                StateObject state = new StateObject
                {
                    WorkSocket = client
                };

                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                state = (StateObject)ar.AsyncState;
                Socket client = state.WorkSocket;

                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    state.StringBuilder.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

                    client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    if (state.StringBuilder.Length > 1)
                    {
                        response = state.StringBuilder.ToString();
                    }
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public class StateObject
        {
            public Socket WorkSocket = null;
            public const int BufferSize = 256;
            public byte[] Buffer = new byte[BufferSize];
            public StringBuilder StringBuilder = new StringBuilder();
        }

    }
}
