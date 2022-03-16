using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.register
{
    class RegisterCodeAlreadyUsed
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public RegisterCodeAlreadyUsed(string response)
        {
            MessageBox.Show("Registercode already in use! (" + response + ")");
        }

    }
}
