using System;
using System.Net;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    class CheckForInternetConnection
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /// <summary>
        /// Check if the User has a valid Web Connection and return the answer
        /// </summary>
        public static bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
