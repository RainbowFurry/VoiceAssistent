using DWC_VoiceAssistent.plugin;
using DWC_VoiceAssistent.projects.system;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DWC_VoiceAssistent.manager.socketmanagement.pluginstore
{
    class DownloadPluginJson
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public DownloadPluginJson(string jsonString)
        {
            JObject jObject = JObject.Parse(jsonString);
            byte[] data = jObject["SourceFilesFromZip"].ToObject<byte[]>();
            File.WriteAllBytes(MainWindow.Save_Path + "/Plugins/" + jObject["Name"] + ".zip", data);
            ZipArchive zipArchive = ZipFile.OpenRead(MainWindow.Save_Path + "/Plugins/" + jObject["Name"] + ".zip");
            foreach (ZipArchiveEntry entry in zipArchive.Entries)
                entry.ExtractToFile(MainWindow.Save_Path + "/Plugins/" + entry.Name, true);
            zipArchive.Dispose();
            File.Delete(MainWindow.Save_Path + "/Plugins/" + jObject["Name"] + ".zip");
            PluginManager.SetupAssembly(Assembly.LoadFrom(MainWindow.Save_Path + "/Plugins/" + jObject["Name"] + ".exe"));
            MessageBox.Show("Plugin wurde erfolgreich installiert.", "Plugin: " + jObject["Name"]);
            PluginStore.pluginStoreWindow.Close();
        }

    }
}
