using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.backgroundtasks.programmstartparametercontroler;
using DWC_VoiceAssistent.handler.menu.module;
using DWC_VoiceAssistent.handler.menu.taskbar;
using DWC_VoiceAssistent.handler.menu.topbar;
using DWC_VoiceAssistent.handler.voice;
using DWC_VoiceAssistent.plugin;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    internal class LoadProgramm
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public LoadProgramm()
        {
            loadSplashScreen();
        }

        public static void loadSplashScreen()
        {
            SplashScreen splashScreen = new SplashScreen("./src/Forum4.png");
            splashScreen.Show(false);//show Loading/Logo Image and stop own managing

            Thread.Sleep(5000);//set Loading Image timeout
            splashScreen.Close(TimeSpan.FromSeconds(0));//fadeout the Logo Welcome/Loading Image
            loadProgramm();
        }

        /// <summary>
        /// Load the Programm and all default Values
        /// </summary>
        [STAThread]
        public static void loadProgramm()
        {
            if(App.StartParameter != null)
                WindowsProgrammStartParameterControler.programmstartparametercontroler(App.StartParameter);
            //Chceck for Certificate
            //CreateCertificate.checkIfCertificateExists();//WIRD NOCH AUFGERUFEN AUCH WENNS INSTALLIERT ISST...

            ProjectVariables.MainColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            //if (!bool.Parse(ConfigManager.autoLogIn))
            //{
            //    Login login = new Login();
            //    login.Show();
            //    login.DWC_Login.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    Credential credentials = CredentialHandler.getUserCredentials();
            //    SocketManager.Send("request_auto_login", credentials.UserName.ToString() + "," + CredentialHandler.ComputeSha256Hash(credentials.Password.ToString()));
            //}
        }

        public static void loadAll()
        {
            MainWindow.mainWindow.Show();
            new LoadImages();
            setGridColor();
            WindowOverlayManager.Save_Path = MainWindow.Save_Path;
            WindowOverlayManager.updateAllWindowContent(MainWindow.mainWindow.BackgroundImage);//Update MainWindow Theme
            WindowOverlayManager.updateWindowCursor(MainWindow.mainWindow);
            TaskbarJumpList.loadJumpList();//Create Taskbar Rightclic Menu
            ThumbnailToolbar.createThumbnailToolbar();//Create Thumbnail Toolbar

            VoiceControler.initializeVoiceAssistent();//Register VoiceAssistents

            new PluginManager();//Load Plugin Manager and all Plugins the User has installed
            new voice.menu.WindowControle();
            new menu.WindowControle();
            new TopBarHandler();
            new music.menu.WindowControler();

            new Settings();
            new OftenUsedProgramms();//Load from User often Load Programms to UI

            new infoicon.InfoIcon();//Windows Notification Icon

            RightClickMenu.loadRightClickMenuItems();//Load Right Klick menu Function
                                                     //mainWindow.DWC_Window.ContextMenu = functions.RightClickMenu.context;//Load Right Klick menu Function

            MainWindow.mainWindow.BackgroundImage.ContextMenu = RightClickMenu.context;//set right Click Cunction
            LogFileManager.createLogEntrence("Programm successfully started and loaded!");//Create Log

            NotificationMessage.Notification("DarkWolfCraft", "Willkommen " + ConfigManager.userName);//Send Welcome Message as PushNotification
        }

        private static SolidColorBrush Theme_DarkestDark = ProjectVariables.Theme_DarkestDark;
        private static SolidColorBrush Theme_MiddleDark = ProjectVariables.Theme_MiddleDark;
        private static SolidColorBrush Theme_DarkBackground = ProjectVariables.Theme_DarkBackground;
        private static SolidColorBrush Theme_LighterDark = ProjectVariables.Theme_LighterDark;

        private static void setGridColor()
        {

            MainWindow.mainWindow.MainWindow_Menu.Background = Theme_DarkestDark;
            MainWindow.mainWindow.MainWindow_QuieckAccess.Background = Theme_MiddleDark;
            MainWindow.mainWindow.DWC_Chats.Background = Theme_MiddleDark;
            MainWindow.mainWindow.MeinWindow_TopMenuBar.Background = Theme_LighterDark;
            MainWindow.mainWindow.DWC_MainWindow_AppContent.Background = Theme_DarkBackground; 
            MainWindow.mainWindow.DWC_Music_Menu.Background = Theme_DarkestDark;
            MainWindow.mainWindow.DWC_OpenProgrammTitle.Background = Theme_DarkBackground;

            MainWindow.mainWindow.DWC_VoiceAssistent_Menu.Background = Theme_DarkestDark;
            MainWindow.mainWindow.UserInfo_Background.Fill = Theme_DarkestDark;


        }

    }
}
