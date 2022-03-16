using System;
using System.Management;
using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.hardware
{
    class Mainboard
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /*
          All Infos for every Component you can get through Windows -> https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-bios
          Check components https://www.codeproject.com/Questions/813960/access-denied-while-getting-temperature-using-WMI (wbemtest.exe)
          */

        /*https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-portresource
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_TemperatureProbe");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Keyboard");//TASTATUR
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_PointingDevice");//MAUS
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_BaseBoard");//???
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from CIM_LogicalDevice");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_CacheMemory");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_CDROMDrive");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_DesktopMonitor");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_DeviceMemoryAddress");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_DiskDrive");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_NetworkConnection");//GET SERVER DRIVES
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_NetworkLoginProfile");//LOGGED IN USER INFO...
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_NetworkProtocol");//NETWOKR PROTOCOL
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_OnBoardDevice");//ONBOARD COMPONENTEN (NUR CPU???)
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_PortConnector");//PORT NUMBER???
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_PortResource");//PORT INFO
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");//AUDIO OUTPUTS
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_USBController");//USB CONTROLER
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_VideoController");//GPU
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Account");//GET ALL DOMAIN USER INFOS...
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_ComputerSystem");//PC SYSTEM
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_DCOMApplication");//APPLICATION INFO
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Desktop");//FILE DIRECTORY MANAGING...
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Environment");//system defaults
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Service");//GET ALL SERVICES
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Share");???
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_StartupCommand");//AUTOSTART???
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_SystemAccount");
   ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Thread");
   */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        public static void getMainBoardInformation()
        {
            //http://jayadevjyothi.blogspot.com/2013/02/getting-bios-information-using-c.html
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\\.\root\cimv2", "SELECT * FROM Win32_BIOS");
            String output = "";

            foreach (var _object in searcher.Get())
            {
                if (_object != null)
                {
                    try
                    {

                        if (_object["BiosCharacteristics"].ToString() != null)
                            output += "BiosCharacteristics: " + _object["BiosCharacteristics"].ToString() + "\n";

                        if (_object["BIOSVersion"].ToString() != null)
                            output += "BIOSVersion: " + _object["BIOSVersion"].ToString() + "\n";

                        if (_object["BuildNumber"].ToString() != null)
                            output += "BuildNumber: " + _object["BuildNumber"].ToString() + "\n";

                        if (_object["Caption"].ToString() != null)
                            output += "Caption: " + _object["Caption"].ToString() + "\n";

                        if (_object["CodeSet"].ToString() != null)
                            output += "CodeSet: " + _object["CodeSet"].ToString() + "\n";

                        if (_object["CurrentLanguage"].ToString() != null)
                            output += "CurrentLanguage: " + _object["CurrentLanguage"].ToString() + "\n";

                        if (_object["Description"].ToString() != null)
                            output += "Description: " + _object["Description"].ToString() + "\n";

                        if (_object["EmbeddedControllerMinorVersion"].ToString() != null)
                            output += "EmbeddedControllerMinorVersion: " + _object["EmbeddedControllerMinorVersion"].ToString() + "\n";

                        if (_object["EmbeddedControllerMajorVersion"].ToString() != null)
                            output += "EmbeddedControllerMajorVersion: " + _object["EmbeddedControllerMajorVersion"].ToString();

                        if (_object["IdentificationCode"].ToString() != null)
                            output += "IdentificationCode: " + _object["IdentificationCode"].ToString() + "\n";

                        if (_object["InstallableLanguages"].ToString() != null)
                            output += "InstallableLanguages: " + _object["InstallableLanguages"].ToString() + "\n";

                        if (_object["InstallDate"].ToString() != null)
                            output += "InstallDate: " + _object["InstallDate"].ToString() + "\n";

                        if (_object["LanguageEdition"].ToString() != null)
                            output += "LanguageEdition: " + _object["LanguageEdition"].ToString() + "\n";

                        if (_object["ListOfLanguages"].ToString() != null)
                            output += "ListOfLanguages: " + _object["ListOfLanguages"].ToString() + "\n";

                        if (_object["Manufacturer"].ToString() != null)
                            output += "Manufacturer: " + _object["Manufacturer"].ToString() + "\n";

                        if (_object["Name"].ToString() != null)
                            output += "Name: " + _object["Name"].ToString() + "\n";

                        if (_object["OtherTargetOS"].ToString() != null)
                            output += "OtherTargetOS: " + _object["OtherTargetOS"].ToString() + "\n";

                        if (_object["PrimaryBIOS"].ToString() != null)
                            output += "PrimaryBIOS: " + _object["PrimaryBIOS"].ToString() + "\n";

                        if (_object["ReleaseDate"].ToString() != null)
                            output += "ReleaseDate: " + _object["ReleaseDate"].ToString() + "\n";

                        if (_object["SerialNumber"].ToString() != null)
                            output += "SerialNumber: " + _object["SerialNumber"].ToString() + "\n";

                        if (_object["SMBIOSBIOSVersion"].ToString() != null)
                            output += "SMBIOSBIOSVersion: " + _object["SMBIOSBIOSVersion"].ToString() + "\n";

                        if (_object["SMBIOSMajorVersion"].ToString() != null)
                            output += "SMBIOSMajorVersion: " + _object["SMBIOSMajorVersion"].ToString() + "\n";

                        if (_object["SMBIOSMinorVersion"].ToString() != null)
                            output += "SMBIOSMinorVersion: " + _object["SMBIOSMinorVersion"].ToString() + "\n";

                        if (_object["SMBIOSPresent"].ToString() != null)
                            output += "SMBIOSPresent: " + _object["SMBIOSPresent"].ToString() + "\n";

                        if (_object["SoftwareElementID"].ToString() != null)
                            output += "SoftwareElementID: " + _object["SoftwareElementID"].ToString() + "\n";

                        if (_object["SoftwareElementState"].ToString() != null)
                            output += "SoftwareElementState: " + _object["SoftwareElementState"].ToString() + "\n";

                        if (_object["Status"].ToString() != null)
                            output += "Status: " + _object["Status"].ToString() + "\n";

                        if (_object["SystemBiosMajorVersion"].ToString() != null)
                            output += "SystemBiosMajorVersion: " + _object["SystemBiosMajorVersion"].ToString() + "\n";

                        if (_object["SystemBiosMinorVersion"].ToString() != null)
                            output += "SystemBiosMinorVersion: " + _object["SystemBiosMinorVersion"].ToString() + "\n";

                        if (_object["TargetOperatingSystem"].ToString() != null)
                            output += "TargetOperatingSystem: " + _object["TargetOperatingSystem"].ToString() + "\n";

                        if (_object["Version"].ToString() != null)
                            output += "Version: " + _object["Version"].ToString() + "\n";

                    }
                    catch (ManagementException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }

            systemInformationWindow.DWC_MainBoardInformation.Content = output;
            LogFileManager.createLogEntrence(systemInformationWindow.DWC_MainBoardInformation.Content.ToString());
        }

    }
}
