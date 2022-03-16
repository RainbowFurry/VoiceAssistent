using DarkWolfCraftSys;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    class LoadImages
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public LoadImages()
        {
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", MainWindow.mainWindow.HomeImage);
            ProjectVariables.LoadSvgImage("src/menu/Home.svg", MainWindow.mainWindow.DWC_OpenProgrammIcon);

            ProjectVariables.LoadSvgImage("src/menu/New_Setting.svg", MainWindow.mainWindow.New_Setting);
            ProjectVariables.LoadSvgImage("src/menu/New_Message.svg", MainWindow.mainWindow.New_Message);
            ProjectVariables.LoadSvgImage("src/menu/New_Friend.svg", MainWindow.mainWindow.New_Friend);

            ProjectVariables.LoadSvgImage("src/white/Skip_Left_White.svg", MainWindow.mainWindow.DWC_Music_Menu_Skip_Backward);
            ProjectVariables.LoadSvgImage("src/white/Play_White.svg", MainWindow.mainWindow.DWC_Music_Menu_Play);
            ProjectVariables.LoadSvgImage("src/white/Skip_Right_White.svg", MainWindow.mainWindow.DWC_Music_Menu_Skip_Forward);
            ProjectVariables.LoadSvgImage("src/white/Arrow_Left_White.svg", MainWindow.mainWindow.DWC_Music_Menu_Toggle);
            MainWindow.mainWindow.DWC_Music_Menu_Toggle.RenderTransform = new RotateTransform(180);

            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", MainWindow.mainWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", MainWindow.mainWindow.Window_Minimize);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", MainWindow.mainWindow.Window_State);

            //ProjectVariables.LoadSvgImage("src/menu/Micro.svg", MainWindow.mainWindow.Micro);
            ProjectVariables.LoadSvgImage("src/menu/Headset.svg", MainWindow.mainWindow.Headset);

            ProjectVariables.LoadSvgImage("src/white/Add_White.svg", MainWindow.mainWindow.Add);
           // ProjectVariables.LoadSvgImage("src/menu/Test.svg", MainWindow.mainWindow.VoiceAssistant_Micro);
        }

    }
}
