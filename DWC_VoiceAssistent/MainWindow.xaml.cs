using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.backgroundtasks;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace DWC_VoiceAssistent
{

    public partial class MainWindow : Window
    {

        /*
        * Creator: Jason H. && Adrian H.
        * Date: -
        * Comment: -
        */

        public static MainWindow mainWindow;
        public static bool hasKey = false;
        public static bool listen = false;
        public static string projectName;
        public static string Save_Path = Assembly.GetExecutingAssembly().Location.Replace("DWC_VoiceAssistent.exe", "");

        #region main
        /// <summary>
        /// Start the Main Programm and load the main Partsdsdsad
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;

            //PrinterContoller.startPrinting(@"C:\Users\DarkS\Documents\HeimServer\MyLogFile.log");

            //TEST
            //Console.WriteLine("PORSCHE");
            //Console.WriteLine(TranslateText.translateText("Morgen muss ich nicht arbeiten wie geil!!!!").GetAwaiter().GetResult());

            new ConfigManager();
            ShortCut.createShortCut();
            Hide();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            projectName = Process.GetCurrentProcess().ProcessName;
            
            LogFileManager.createLogEntrence("Programm DWC_VoiceAssistent is starting up...");

            LoadProgramm.loadAll();

            try
            {

                if (handler.backgroundtasks.CheckForInternetConnection.CheckConnection() == true)
                {
                    LogFileManager.createLogEntrence("Web Connection was found");
                    //NUR ZUM TESTEN SO ANSONSTEN NEUE INSTANC VON DER CLASS ERSTELLEN...
                    handler.backgroundtasks.LoadProgramm.loadProgramm();//Load Programm Settings
                    GC.Collect();//Clean unused cash

                }
                else
                {
                    LogFileManager.createLogEntrence("No Web Connection found\nProgramm is starting shutdown.");
                    //Close the two opened Windows if no NetworkConnection detected
                    if (mainWindow != null)
                    {
                        mainWindow.Close();
                    }

                    System.Windows.Forms.MessageBox.Show("To use this Programm you need a valiable Network Connection.\n Please check your Network.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                LogFileManager.createLogExeptionEntrence(e);
            }
        }

        private void SetupDragAndDrop()
        {
            DWC_MainMenu_AppList.PreviewMouseLeftButtonDown += DragAndDrop.sp_PreviewMouseLeftButtonDown;
            DWC_MainMenu_AppList.PreviewMouseLeftButtonUp += DragAndDrop.sp_PreviewMouseLeftButtonUp;
            DWC_MainMenu_AppList.PreviewMouseMove += DragAndDrop.sp_PreviewMouseMove;
            DWC_MainMenu_AppList.DragEnter += DragAndDrop.sp_DragEnter;
            DWC_MainMenu_AppList.Drop += DragAndDrop.sp_Drop;
        }

        #endregion

    }
}
