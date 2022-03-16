using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DarkWolfCraftSys
{

    public class ConfigManager
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        #region Configvariables
        public static readonly string SavePath = Assembly.GetExecutingAssembly().Location.Replace("DWC_VoiceAssistent.exe", "").Replace(".dll", "").Replace("DarkWolfCraftSys", "");

        public static byte R, G, B, A;
        public static byte R1, G1, B1, A1;
        public static byte R2, G2, B2, A2;

        #region Design
        public static string userMainColor;//color code
        public static string userTheme;//light, dark, transparent

        public static string userBackgroundImage;//image path
        public static string userBackgroundImageCategory;//image category
        public static string roundDesign;//rounding 
        public static bool shadow;//shadow
        public static string userFont;//font path
        public static string userCursor;//cursor path
        #endregion

        #region Language
        public static string language;//de, en, it, es, fr, ru, chn(china), prt(portugal), jpn(Japan), mex(Mexiko)
        #endregion

        #region Editors Mode
        public static string editorsMode;//normal , editor, developer
        #endregion

        #region Notification
        public static bool desktopNotification;//recieve general notification
        public static bool textMessageNotification;//if a friend is writing you
        public static bool friendIsOnline;//shows if a frind goes online
        public static bool systemNotification;//if errors happen
        public static bool securityNotification;//if a wrong login happens
        public static bool updateEmailNotification;//get update news
        public static bool eventEmialNotification;//for premium or other events
        public static bool shoppingCardEmailNotification;//if a game in the shopping card is cheaper
        public static bool storeUpdateEmailNotification;//if a store event is aktive
        #endregion

        #region In-Game-Overlay
        public static bool aktivateIngameOverlay;//aktivate InGameOverlay
        public static string positionInGameOverlay;//top-left, top-right, bottom-left, bottom-right
        public static bool showOverlayIfTalking;//show the overlay oenly if somebody is talking
        public static bool hideProfilePicture;//hide the profile pictures
        public static bool showMusicBot;//show the music bot in the Overlay
        #endregion

        #region Client Start
        public static bool autostartClient;//autostart the Client
        public static bool startMinimized;//start the Client minimized
        #endregion

        #region Updates
        public static bool automaticUpdate;//update automaticly when started
        public static bool blockAutoUpdate;//block auto updates in some situations
        #endregion

        #region Microphone
        public static string selectedMicrophone;//selected Microphone
        public static string selectedHeadset;//selected Headset
        public static double inputVolume;//microfon
        public static double outputVolume;//lautsprecher
        public static bool speechAktivation;//speech aktivation
        public static bool microphoneSensitivity;//detect microphone sensitivity
        public static double sensitivityVolume;//sensitivity Volum
        public static bool audioHelp;//
        public static bool audioOptimisation;//
        #endregion

        #region HotKey
        public static bool enableHotKeys;//
        public static bool enableOwnHotKeys;//
        #endregion



        #region Program
        public static string welcomeMessage;
        public static string closeWindowOnClose;
        public static string autoLogIn;
        #endregion

        #region VoiceAssistant
        public static string voiceReactName;
        public static string userName;
        public static string voiceGender;
        public static string voiceAge;
        public static string voiceassistantActive;
        public static string voiceassistantReactInGame;
        #endregion

        #region Sonstiges
        public static string volum;
        public static string pruductVersion = "1.0.00005";
        #endregion

        #endregion

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */
        private static Properties properties;
        public ConfigManager()
        {
            if (!Directory.Exists(SavePath + @"\Background_Images"))
                Directory.CreateDirectory(SavePath + @"\Background_Images");
            if (!Directory.Exists(SavePath + @"\Cursors"))
                Directory.CreateDirectory(SavePath + @"\Cursors");
            if (!File.Exists(SavePath + @"\Config.conf"))
            {
                properties = new Properties(SavePath + @"\Config.conf");

                #region Design
                properties.Set("userMainColor", "255,20,102,183");
                properties.Set("userTheme", "dark");
                properties.Set("userBackgroundImage", "-");
                properties.Set("userBackgroundImageCategory", "Gaming");
                properties.Set("roundDesign", "15");
                properties.Set("shadow", "false");
                properties.Set("userFont", "default");
                properties.Set("userCursor", "-");
                #endregion

                #region Language
                properties.Set("language", "de-DE");
                #endregion

                #region Editors Mode
                properties.Set("editorsMode", "min");
                #endregion

                #region Notification
                properties.Set("desktopNotification", "true");
                properties.Set("textMessageNotification", "true");
                properties.Set("friendIsOnline", "true");
                properties.Set("systemNotification", "true");
                properties.Set("securityNotification", "true");
                properties.Set("updateEmailNotification", "true");
                properties.Set("eventEmialNotification", "true");
                properties.Set("shoppingCardEmailNotification", "true");
                properties.Set("storeUpdateEmailNotification", "true");
                #endregion

                #region In-Game-Overlay
                properties.Set("aktivateIngameOverlay", "true");
                properties.Set("positionInGameOverlay", "top-left");
                properties.Set("showOverlayIfTalking", "true");
                properties.Set("hideProfilePicture", "true");
                properties.Set("showMusicBot", "true");
                #endregion

                #region Client Start
                properties.Set("autostartClient", "true");
                properties.Set("startMinimized", "false");
                #endregion

                #region Update
                properties.Set("automaticUpdate", "true");
                properties.Set("blockAutoUpdate", "true");
                #endregion

                #region Microphonhe
                properties.Set("selectedMicrophone", "-");
                properties.Set("selectedHeadset", "-");
                properties.Set("inputVolume", "100.0");
                properties.Set("outputVolume", "100.0");
                properties.Set("speechAktivation", "true");
                properties.Set("microphoneSensitivity", "true");
                properties.Set("sensitivityVolume", "35");
                properties.Set("audioHelp", "true");
                properties.Set("audioOptimisation", "true");
                #endregion

                #region HotKey
                properties.Set("enableHotKeys", "true");
                properties.Set("enableOwnHotKeys", "false");
                #endregion



                #region SONSTIGES
                properties.Set("notification", "true");
                properties.Set("welcomeMessage", "true");
                properties.Set("autoStart", "false");
                properties.Set("autoUpdate", "false");
                properties.Set("closeWindowOnClose", "false");
                properties.Set("autoLogin", "true");
                properties.Set("voiceReactName", "Hey PC");
                properties.Set("userName", Environment.UserName);
                properties.Set("voiceGender", "female");
                properties.Set("voiceAge", "adult");
                properties.Set("voiceassistantActive", "true");
                properties.Set("voiceassistantReactInGame", "false");
                properties.Set("volume", "50.0");
                #endregion

                properties.Save();
                LogFileManager.createLogEntrence("Config File has been successfully created!");
            }
            LoadConfigValues();
        }

        private static void LoadConfigValues()
        {
            properties = new Properties(SavePath + @"\Config.conf");

            #region Design
            userMainColor = properties.Get("userMainColor");
            userTheme = properties.Get("userTheme");
            userBackgroundImage = properties.Get("userBackgroundImage");
            roundDesign = properties.Get("roundDesign");
            shadow = properties.GetBool("shadow");
            userFont = properties.Get("userFont");
            userCursor = properties.Get("userCursor");
            userBackgroundImageCategory = properties.Get("userBackgroundImageCategory");
            #endregion

            #region Language
            language = properties.Get("language");
            #endregion

            #region Editors Mode
            editorsMode = properties.Get("editorsMode");
            #endregion

            #region Notification
            desktopNotification = properties.GetBool("desktopNotification");
            textMessageNotification = properties.GetBool("textMessageNotification");
            friendIsOnline = properties.GetBool("friendIsOnline");
            systemNotification = properties.GetBool("systemNotification");
            securityNotification = properties.GetBool("securityNotification");
            updateEmailNotification = properties.GetBool("updateEmailNotification");
            eventEmialNotification = properties.GetBool("eventEmialNotification");
            shoppingCardEmailNotification = properties.GetBool("shoppingCardEmailNotification");
            storeUpdateEmailNotification = properties.GetBool("storeUpdateEmailNotification");
            #endregion

            #region In-Game-Overlay
            aktivateIngameOverlay = properties.GetBool("aktivateIngameOverlay");
            positionInGameOverlay = properties.Get("positionInGameOverlay");
            showOverlayIfTalking = properties.GetBool("showOverlayIfTalking");
            hideProfilePicture = properties.GetBool("hideProfilePicture");
            showMusicBot = properties.GetBool("showMusicBot");
            #endregion

            #region Client Start
            autostartClient = properties.GetBool("autostartClient");
            startMinimized = properties.GetBool("startMinimized");
            #endregion

            #region Update
            automaticUpdate = properties.GetBool("automaticUpdate");
            blockAutoUpdate = properties.GetBool("blockAutoUpdate");
            #endregion

            #region Microphonhe
            selectedMicrophone = properties.Get("selectedMicrophone");
            selectedHeadset = properties.Get("selectedHeadset");
            inputVolume = properties.GetDouble("inputVolume");
            outputVolume = properties.GetDouble("outputVolume");
            speechAktivation = properties.GetBool("speechAktivation");
            microphoneSensitivity = properties.GetBool("microphoneSensitivity");
            sensitivityVolume = properties.GetDouble("sensitivityVolume");
            audioHelp = properties.GetBool("audioHelp");
            audioOptimisation = properties.GetBool("audioOptimisation");
            #endregion

            #region HotKey
            enableHotKeys = properties.GetBool("enableHotKeys");
            enableHotKeys = properties.GetBool("enableOwnHotKeys");
            #endregion

            #region SONSTIGES
            welcomeMessage = properties.Get("welcomeMessage");
            closeWindowOnClose = properties.Get("closeWindowOnClose");
            autoLogIn = properties.Get("autoLogin");
            voiceReactName = properties.Get("voiceReactName");
            userName = properties.Get("userName");
            voiceGender = properties.Get("voiceGender");
            voiceAge = properties.Get("voiceAge");
            voiceassistantActive = properties.Get("voiceassistantActive");
            voiceassistantReactInGame = properties.Get("voiceassistantReactInGame");
            #endregion

            LoadColor();
            LogFileManager.createLogEntrence("Config File has been loaded and initialized successfull");
        }

        public static void SaveConfigValues()
        {

            if (File.Exists(SavePath + @"\Config.conf"))
            {
                File.Delete(SavePath + @"\Config.conf");
            }

            properties = new Properties(SavePath + @"\Config.conf");

            #region Design
            properties.Set("userMainColor", "255,20,102,183");//userMainColor
            properties.Set("userTheme", userTheme);
            properties.Set("userBackgroundImage", userBackgroundImage);
            properties.Set("userBackgroundImageCategory", userBackgroundImageCategory);
            properties.Set("roundDesign", roundDesign);
            properties.Set("shadow", shadow.ToString());
            properties.Set("userFont", userFont);
            properties.Set("userCursor", userCursor);
            #endregion

            #region Language
            properties.Set("language", language);
            #endregion

            #region Editors Mode
            properties.Set("editorsMode", editorsMode);
            #endregion

            #region Notification
            properties.Set("desktopNotification", desktopNotification.ToString());
            properties.Set("textMessageNotification", textMessageNotification.ToString());
            properties.Set("friendIsOnline", friendIsOnline.ToString());
            properties.Set("systemNotification", systemNotification.ToString());
            properties.Set("securityNotification", securityNotification.ToString());
            properties.Set("updateEmailNotification", updateEmailNotification.ToString());
            properties.Set("eventEmialNotification", eventEmialNotification.ToString());
            properties.Set("shoppingCardEmailNotification", shoppingCardEmailNotification.ToString());
            properties.Set("storeUpdateEmailNotification", storeUpdateEmailNotification.ToString());
            #endregion

            #region In-Game-Overlay
            properties.Set("aktivateIngameOverlay", aktivateIngameOverlay.ToString());
            properties.Set("positionInGameOverlay", positionInGameOverlay.ToString());
            properties.Set("showOverlayIfTalking", showOverlayIfTalking.ToString());
            properties.Set("hideProfilePicture", hideProfilePicture.ToString());
            properties.Set("showMusicBot", showMusicBot.ToString());
            #endregion

            #region Client Start
            properties.Set("autostartClient", autostartClient.ToString());
            properties.Set("startMinimized", startMinimized.ToString());
            #endregion

            #region Update
            properties.Set("automaticUpdate", automaticUpdate.ToString());
            properties.Set("blockAutoUpdate", blockAutoUpdate.ToString());
            #endregion

            #region Microphonhe
            properties.Set("selectedMicrophone", selectedMicrophone);
            properties.Set("selectedHeadset", selectedHeadset);
            properties.Set("inputVolume", inputVolume.ToString());
            properties.Set("outputVolume", outputVolume.ToString());
            properties.Set("speechAktivation", speechAktivation.ToString());
            properties.Set("microphoneSensitivity", microphoneSensitivity.ToString());
            properties.Set("sensitivityVolume", sensitivityVolume.ToString());
            properties.Set("audioHelp", audioHelp.ToString());
            properties.Set("audioOptimisation", audioOptimisation.ToString());
            #endregion

            #region HotKey
            properties.Set("enableHotKeys", enableHotKeys.ToString());
            properties.Set("enableOwnHotKeys", enableOwnHotKeys.ToString());
            #endregion

            #region SONSTIGES
            properties.Set("notification", "true");
            properties.Set("welcomeMessage", "true");
            properties.Set("autoStart", "false");
            properties.Set("autoUpdate", "false");
            properties.Set("closeWindowOnClose", "false");
            properties.Set("autoLogin", "true");
            properties.Set("voiceReactName", "Hey PC");
            properties.Set("userName", Environment.UserName);
            properties.Set("voiceGender", "female");
            properties.Set("voiceAge", "adult");
            properties.Set("voiceassistantActive", "true");
            properties.Set("voiceassistantReactInGame", "false");
            properties.Set("volume", "50.0");
            #endregion

            properties.Save();
            LogFileManager.createLogEntrence("Config File has been successfully created!");
            LoadConfigValues();

        }

        private static void LoadColor()
        {
            string[] colorList = userMainColor.Split(',');

            //Main Color
            R = Convert.ToByte(colorList[1]);
            G = Convert.ToByte(colorList[2]);
            B = Convert.ToByte(colorList[3]);
            A = Convert.ToByte(colorList[0]);

            //Second Main Color
            R1 = Convert.ToInt32(colorList[1]) - 30 > 0 ? Convert.ToByte(Convert.ToInt32(colorList[1]) - 30) : Convert.ToByte(0);
            G1 = Convert.ToInt32(colorList[2]) - 32 > 0 ? Convert.ToByte(Convert.ToInt32(colorList[2]) - 32) : Convert.ToByte(0);
            B1 = Convert.ToInt32(colorList[3]) - 20 > 0 ? Convert.ToByte(Convert.ToInt32(colorList[3]) - 20) : Convert.ToByte(0);
            A1 = Convert.ToByte(colorList[0]);

            //Third Main Color
            R2 = Convert.ToInt32(colorList.GetValue(1)) - 60 > 0 ? Convert.ToByte(Convert.ToInt32(colorList.GetValue(1)) - 60) : Convert.ToByte(0);
            G2 = Convert.ToInt32(colorList.GetValue(2)) - 64 > 0 ? Convert.ToByte(Convert.ToInt32(colorList.GetValue(2)) - 64) : Convert.ToByte(0);
            B2 = Convert.ToInt32(colorList.GetValue(3)) - 40 > 0 ? Convert.ToByte(Convert.ToInt32(colorList.GetValue(3)) - 40) : Convert.ToByte(0);
            A2 = Convert.ToByte(colorList.GetValue(0));

            LogFileManager.createLogEntrence("Color Codes has been loaded and initialized successfull");
        }

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */
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

    /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */
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

        public bool GetBool(string field)
        {
            return Convert.ToBoolean(list.ContainsKey(field) ? list[field] : null);
        }

        public double GetDouble(string field)
        {
            return Convert.ToDouble(list.ContainsKey(field) ? list[field] : null);
        }

        public void Set(string field, string value)
        {
            if (!list.ContainsKey(field))
                if (value == "True" || value == "False") {
                    list.Add(field, value.ToLower());
                }
                else
                {
                    list.Add(field, value);
                }
            else
                {
                    list.Remove(field);
                    list.Add(field, value);
                }
        }

        public void Save()
        {
            Save(this.filename);
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
            Reload(this.filename);
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
