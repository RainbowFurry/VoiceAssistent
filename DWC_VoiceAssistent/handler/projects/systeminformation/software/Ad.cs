using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;

namespace DWC_VoiceAssistent.handler.projects.systeminformation.software
{
    class Ad
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        /// <summary>
        /// Get all loggedin AD users
        /// </summary>
        [STAThread]
        public static void getADUserInfo()
        {

            string content = "";

            //WICHTIGE AD INFOS https://www.codeproject.com/Articles/18102/Howto-Almost-Everything-In-Active-Directory-via-C#23

            using (var context = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;

                        content += "First Name: " + de.Properties["givenName"].Value + "\n";
                        content += "Last Name : " + de.Properties["sn"].Value + "\n";
                        content += "SAM account name   : " + de.Properties["samAccountName"].Value + "\n";
                        content += "User principal name: " + de.Properties["userPrincipalName"].Value + "\n";
                        content += "Description: " + de.Properties["Description"].Value + "\n";
                        content += "Mac Adress: " + BitConverter.ToString((byte[])de.Properties["objectguid"][0]).Replace(" - ", string.Empty) + "\n";


                        //Console.WriteLine("IP : " + de.Properties["ipHostNumber"].Value);
                        //Console.WriteLine("PC Name:" + de.Properties["userAccountControl"].Value);

                        String groupName = "";

                        if (de != null)
                        {
                            if (de.Properties.Contains("department"))
                            {
                                groupName = de.Properties["department"][0].ToString();
                            }
                        }

                        Console.WriteLine("Group Name: " + groupName);

                        if (de.Properties["title"].Value != null) { content += "Title   : " + de.Properties["title"].Value + "\n"; }
                        if (de.Properties["company"].Value != null) { content += "Company   : " + de.Properties["company"].Value + "\n"; }
                        if (de.Properties["st"].Value != null) { content += "Street   : " + de.Properties["st"].Value + "\n"; }
                        if (de.Properties["1"].Value != null) { content += "Number   : " + de.Properties["1"].Value + "\n"; }
                        if (de.Properties["co"].Value != null) { content += "KP   : " + de.Properties["co"].Value + "\n"; }
                        if (de.Properties["postalCode"].Value != null) { content += "Post Code   : " + de.Properties["postalCode"].Value + "\n"; }
                        if (de.Properties["telephoneNumber"].Value != null) { content += "Phone Number   : " + de.Properties["telephoneNumber"].Value + "\n"; }
                        if (de.Properties["otherTelephone"].Value != null) { content += "Mobile Number   : " + de.Properties["otherTelephone"].Value + "\n"; }
                        if (de.Properties["facsimileTelephoneNumber"].Value != null) { content += "KP   : " + de.Properties["facsimileTelephoneNumber"].Value + "\n\n"; }

                        Console.WriteLine(content);

                        LogFileManager.createLogEntrence(systemInformationWindow.DWC_ADInformation.Content.ToString());
                        systemInformationWindow.DWC_ADInformation.Content = content;
                        Thread.Sleep(1000);

                    }
                }
            }

            //string Name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            //Console.WriteLine("Loggedin User: " + Name);
            //systemInformationWindow.DWC_ADLoadingBar.Visibility = Visibility.Hidden;
            //systemInformationWindow.DWC_ADInformation.Height += 20;
            //systeminformation.log.ComponentsLogManager.CreateSystemInfoFile("AD", content);
            //systemInformationWindow.DWC_ADInformation.Text = content;

        }

    }
}
