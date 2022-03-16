using System.Reflection;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    class AutostartManager
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private static Assembly curAssembly = Assembly.GetExecutingAssembly();

        private static void createAutostart()
        {
            key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
        }

        public static void deleteAutostart()
        {
            key.DeleteValue(curAssembly.GetName().Name);
        }

    }
}
