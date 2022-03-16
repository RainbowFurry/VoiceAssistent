using System;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.software
{
    class Firewall
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static String save_path = MainWindow.Save_Path + "";

        public static void getFirewallInformation()
        {

            //getFirewallActivity();//get firewall status
            //ScanPort();//get open ports
            FirewallIntegration();//get firewall rules

        }

        private static void FirewallIntegration()
        {



            //https://doumer.me/allow-your-app-through-the-firewall-with-c/
            //http://gowdhamn.blogspot.com/2016/10/firewall-inbound-and-outbound-rules-in.html

            /*INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FWRule"));

             INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                 Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

             firewallRule.ApplicationName = "//App Executable Path";

             firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
             firewallRule.Description = "sample rule mera";
             firewallRule.Enabled = true;
             firewallRule.InterfaceTypes = "All";
             firewallRule.Name = $"// App Name";

             firewallPolicy.Rules.Add(firewallRule);
             //firewallPolicy.Rules.Remove($"// App Name");*/

        }

        //private static void getFirewallActivity()
        //{
        //    // Create consts for firewall types.
        //    const int NET_FW_PROFILE2_DOMAIN = 1;
        //    const int NET_FW_PROFILE2_PRIVATE = 2;
        //    const int NET_FW_PROFILE2_PUBLIC = 4;

        //    string message = "";

        //    if (File.Exists(save_path + "FirewallStatus.txt"))
        //    {
        //        File.Delete(save_path + "FirewallStatus.txt");
        //    }

        //    // Create the firewall type.
        //    Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");

        //    // Use the firewall type to create a firewall manager object.
        //    dynamic FWManager = Activator.CreateInstance(FWManagerType);

        //    // Get the firewall settings.
        //    bool CheckDomain =
        //        FWManager.FirewallEnabled(NET_FW_PROFILE2_DOMAIN);
        //    bool CheckPrivate =
        //        FWManager.FirewallEnabled(NET_FW_PROFILE2_PRIVATE);
        //    bool CheckPublic =
        //        FWManager.FirewallEnabled(NET_FW_PROFILE2_PUBLIC);

        //    // Check the status of the firewall.
        //    message = "DomainFirewall: " + CheckDomain +
        //        "\nPrivateFirewall: " + CheckPrivate +
        //        "\nPublicFirewall: " + CheckPublic;

        //    File.AppendAllText(save_path + "FirewallStatus.txt", message);

        //}

        //private static void ScanPort()
        //{
        //    string hostname = "127.0.0.1";
        //    String message = "";

        //    if (File.Exists(save_path + "OpenPorts.txt"))
        //    {
        //        File.Delete(save_path + "OpenPorts.txt");
        //    }

        //    Socket sock = new Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

        //    int port = 2000;

        //    for (int i = 1; i < port; i++)
        //    {
        //        port++;

        //        try
        //        {

        //            sock.Connect(hostname, i);
        //            if (sock.Connected == true) // Port is in use and connection is successful
        //                message = "Port : " + i + " -> true\n";
        //            sock.Close();
        //        }
        //        catch (System.Net.Sockets.SocketException ex)
        //        {
        //            if (ex.ErrorCode == 10061) // Port is unused and could not establish connection 
        //                message = "Port : " + i + " -> false\n";
        //            else
        //                message = "Error : " + ex.Message;
        //        }

        //        File.AppendAllText(save_path + "OpenPorts.txt", message);

        //    }

        //}

    }
}
