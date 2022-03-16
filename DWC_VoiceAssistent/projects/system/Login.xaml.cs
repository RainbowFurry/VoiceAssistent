using DarkWolfCraftSys;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class Login : Window
    {

        /*
        * Creator: Jason H. && Adrian H.
        * Date: -
        * Comment: -
        */

        //Login but also Registration...
        public static Login loginWindow;

        public Login()
        {
            InitializeComponent();
            loginWindow = this;
            LoadImages();
            new handler.projects.login.WindowControlerRegister();
            new handler.projects.login.WindowControlerLogin();
            new handler.projects.login.WindowControlerRegisterConfirm();
            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", Window_Minimize);
        }

        private void LoadImages()
        {

            ProjectVariables.LoadSvgImage("src/own/Info.svg", UserNameImage);
            ProjectVariables.LoadSvgImage("src/own/Visible.svg", Show_FirstPassword);
            ProjectVariables.LoadSvgImage("src/own/Visible.svg", Show_SecondPassword);
            ProjectVariables.LoadSvgImage("src/own/Info.svg", PasswordInfo);
            ProjectVariables.LoadSvgImage("src/own/Lock.svg", YourDataImage);

            ProjectVariables.LoadSvgImage("src/icons/Minimize.svg", Window_Minimize);
            ProjectVariables.LoadSvgImage("src/icons/WindowState.svg", Window_State);
            ProjectVariables.LoadSvgImage("src/icons/Close.svg", Window_Close);
        }
    }
}
