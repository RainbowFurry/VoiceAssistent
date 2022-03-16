using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Net.NetworkInformation;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.software
{
    class Network
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Show Network Information and Create Log File
        /// </summary>
        public static void NetworkClick()
        {

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            systemInformationWindow.DWC_Network.Content =
                "Netzwerk:" + "\n\n" +
                "Interface information for " + computerProperties.HostName + "." + computerProperties.DomainName + "     " + "\n";


            if (nics == null || nics.Length < 1)
            {
                systemInformationWindow.DWC_Network.Content += "  No network interfaces found." + "\n";
                return;
            }

            systemInformationWindow.DWC_Network.Content += "  Number of interfaces .................... : " + nics.Length + "\n\n";

            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                systemInformationWindow.DWC_Network.Content += adapter.Description + "\n" +
                String.Empty.PadLeft(adapter.Description.Length, '=') + "\n" +
                "  Interface type .......................... : " + adapter.NetworkInterfaceType + "\n" +
                "  Physical Address ........................ : " + adapter.GetPhysicalAddress().ToString() + "\n" +
                "  Operational status ...................... : " + adapter.OperationalStatus + "\n";


                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }

                systemInformationWindow.DWC_Network.Content += "  IP version .............................. : " + versions + "\n";
                //ShowIPAddresses(properties);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }

                systemInformationWindow.DWC_Network.Content += "  DNS suffix .............................. : " + properties.DnsSuffix + "\n";

                string label;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    systemInformationWindow.DWC_Network.Content += "  MTU...................................... : " + ipv4.Mtu + "\n";
                    if (ipv4.UsesWins)
                    {

                        IPAddressCollection winsServers = properties.WinsServersAddresses;
                        if (winsServers.Count > 0)
                        {
                            label = "  WINS Servers ............................ :";
                            //ShowIPAddresses(label, winsServers);
                        }
                    }
                }

                systemInformationWindow.DWC_Network.Content += "  DNS enabled ............................. : " + properties.IsDnsEnabled + "\n" +
                "  Dynamically configured DNS .............. : " + properties.IsDynamicDnsEnabled + "\n" +
                "  Receive Only ............................ : " + adapter.IsReceiveOnly + "\n" +
                "  Multicast ............................... : " + adapter.SupportsMulticast + "\n";

            }

            LogFileManager.createLogEntrence(systemInformationWindow.DWC_Network.Content.ToString());

        }

    }
}
