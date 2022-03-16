using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.register
{
    class AccountNotExists
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public AccountNotExists(string response)
        {
            MessageBox.Show("Account does not exists! (" + response + ")");
        }

    }
}
