using Meziantou.Framework.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DWC_VoiceAssistent.handler.projects.login
{
    class CredentialHandler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static string programmName = "DWC_VoiceAssistent";//kann auch webseite sein ist egal

        #region User Credentials
        //https://www.meziantou.net/how-to-store-a-password-on-windows.htm
        public static void CreateUserCredentials(string userName, string password)
        {
            CredentialManager.WriteCredential(
            applicationName: programmName,
            userName: userName,
            secret: password,
            comment: "DWC_VoiceAssistent User Credential",
            persistence: CredentialPersistence.LocalMachine);
        }

        public static Credential getUserCredentials()
        {
            return CredentialManager.ReadCredential(applicationName: programmName);
        }

        private void deleteUserCredentials()
        {
            CredentialManager.DeleteCredential(applicationName: programmName);
        }
        #endregion

        /// <summary>
        /// Create HashValue from entered User Password
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));//key verschlüsselungs vormat
                }
                return builder.ToString();
            }
        }

        #region Json User Storage
        private void saveUserData()
        {
            UserData userData = new UserData();
            userData.UUID = "gk98453ßhwbcvdbv2ß9eßh12ur";
            userData.userNickName = "DarkSide_Wolf";
            userData.firstName = "JasonJT";
            userData.secondName = "Hoffmann";
            userData.userPassword = ComputeSha256Hash("0000");
            userData.email = "jasonjt.hoffmann@gmail.com";
            userData.phoneNumber = "+49 07141 75214";
            userData.street = "Weinstraße";
            userData.houseNumber = "23";
            userData.place = "Freiberg am Neckar";
            userData.plz = "71691";
            userData.land = "Germany";
            userData.gender = "Male";
            userData.lizensKey = new string[] { "tzh4-gs5h", "S5jd-gk5T" };
            userData.userBirthday = "20.09.1998";
            userData.userStatus = "Developer for Live";
            userData.onlineState = "Online";
            userData.joinDate = DateTime.Now.ToLongDateString();
            userData.isVeryfied = true;

            string json = JsonConvert.SerializeObject(userData);
            File.AppendAllText(@"C:\Users\DarkS\Documents\HeimServer\Test.json", json);

        }

        //BESSERE SPEICHER FORMATIERUNG
        private void change()
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\DarkS\Documents\HeimServer\Test.json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);
            obj["userPassword"] = ComputeSha256Hash("1234");

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            File.AppendAllText(@"C:\Users\DarkS\Documents\HeimServer\Test2.json", output);
        }
        #endregion

    }

    /// <summary>
    /// Registered User Data Storage Info
    /// </summary>
    public class UserData
    {

        public string UUID { get; set; }//als array und danach richtet sich alles
        public string userNickName { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string userPassword { get; set; }//hashed Password
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string place { get; set; }
        public string plz { get; set; }
        public string land { get; set; } // - DE/US
        public string gender { get; set; }
        public string[] lizensKey { get; set; }
        public string userBirthday { get; set; }//DateTime?
        public string userStatus { get; set; }
        public string onlineState { get; set; }
        public string joinDate { get; set; }
        public bool isVeryfied { get; set; }

    }

}
