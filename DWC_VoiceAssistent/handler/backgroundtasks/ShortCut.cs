using DarkWolfCraftSys;
using DWC_VoiceAssistent.functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    internal class ShortCut
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static MainWindow mainWindow = MainWindow.mainWindow;
        public static readonly string SavePath = Assembly.GetExecutingAssembly().Location.Replace("DWC_VoiceAssistent.exe", "").Replace(".dll", "").Replace("DarkWolfCraftSys", "");

        public static String pushToTalk;
        public static String voiceassistentTrigger;
        public static String muteStatus;
        public static String musikBotStatus;

        /// <summary>
        /// Control the Short Cut automaticly by calling it
        /// </summary>
        public static void DWC_ShortCut(object sender, KeyEventArgs e)
        {

            LogFileManager.createLogEntrence("Shortcut detected: " + e.Key);

            switch (e.Key)
            {

                case Key.F1:
                    //projects.system.Settings settingsWindow = new projects.system.Settings();
                    //settingsWindow.Show();
                    break;

                case Key.F2:
                    //mainWindow.Visibility = Visibility.
                    if (mainWindow.WindowState == WindowState.Minimized)
                    {
                        mainWindow.WindowState = WindowState.Maximized;

                    }
                    else
                    {
                        mainWindow.WindowState = WindowState.Minimized;
                    }
                    break;

                case Key.F3:
                    if (MainWindow.listen == true)
                    {
                        MainWindow.listen = false;
                    }
                    else
                    {
                        MainWindow.listen = true;
                    }
                    break;

                case Key.F4:
                    //
                    break;

                case Key.F5:
                    //
                    break;

                case Key.F6:
                    //
                    break;

                case Key.F7:
                    //
                    break;

                case Key.F8:
                    //
                    break;

                case Key.F9:
                    ScreenCapture.CaptureScreen();
                    break;

            }

        }

        private static Properties properties;
        public static void createShortCut()
        {

            if (!File.Exists(SavePath + @"\Shortcuts.conf"))
            {
                properties = new Properties(SavePath + @"\Shortcuts.conf");

                properties.Set("pushToTalk", "V");
                properties.Set("voiceassistentTrigger", "B");
                properties.Set("muteStatus", "N");
                properties.Set("musikBotStatus", "M");

                properties.Save();
                LogFileManager.createLogEntrence("Shortcut File has been successfully created!");
            }
            LoadConfigValues();
        }

        private static void LoadConfigValues()
        {
            properties = new Properties(SavePath + @"\Shortcuts.conf");

            pushToTalk = properties.Get("pushToTalk");
            voiceassistentTrigger = properties.Get("voiceassistentTrigger");
            muteStatus = properties.Get("muteStatus");
            musikBotStatus = properties.Get("musikBotStatus");

            LogFileManager.createLogEntrence("Shortcut File has been loaded and initialized successfull");
        }

        public static void Set(string key, string value)
        {
            properties.Set(key, value);
        }

        public static void SaveAndReload()
        {
            properties.Save();
            LoadConfigValues();
        }

    }

    public class Properties
    {
        private Dictionary<string, string> list;
        private string filename;

        public Properties(string file)
        {
            Reload(file);
        }

        public string GetOrDefault(string field, string defValue)
        {
            return Get(field) ?? defValue;
        }

        public string Get(string field)
        {
            return list.ContainsKey(field) ? list[field] : null;
        }

        public void Set(string field, string value)
        {
            if (!list.ContainsKey(field))
                list.Add(field, value);
            else
            {
                list.Remove(field);
                list.Add(field, value);
            }
        }

        public void Save()
        {
            Save(filename);
        }

        public void Save(string filename)
        {
            this.filename = filename;

            if (!File.Exists(filename))
                File.Create(filename);

            StreamWriter file = new StreamWriter(filename);

            foreach (string prop in list.Keys.ToArray())
            {
                if (!string.IsNullOrWhiteSpace(list[prop]))
                    file.WriteLine(prop + "=" + list[prop]);
            }
            file.Close();
        }

        public void Reload()
        {
            Reload(filename);
        }

        public void Reload(string filename)
        {
            this.filename = filename;
            list = new Dictionary<string, string>();

            if (File.Exists(filename))
                LoadFromFile(filename);
            else
                File.Create(filename).Close();
        }

        private void LoadFromFile(string file)
        {
            foreach (string line in File.ReadAllLines(file))
            {
                if ((!string.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) || (value.StartsWith("'") && value.EndsWith("'")))
                        value = value.Substring(1, value.Length - 2);
                    if (!list.ContainsKey(key))
                        list.Add(key, value);
                }
            }
        }
    }

}
