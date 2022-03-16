using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.register
{
    class AccountAlreadyVerified
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public AccountAlreadyVerified(string response)
        {
            MessageBox.Show("Account is already verified! (" + response + ")");
        }

    }
}
