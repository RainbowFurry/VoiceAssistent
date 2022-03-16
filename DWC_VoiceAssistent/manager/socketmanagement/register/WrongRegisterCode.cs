using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.register
{
    class WrongRegisterCode
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public WrongRegisterCode(string response)
        {
            MessageBox.Show("Wrong Registercode! (" + response + ")");
        }

    }
}
