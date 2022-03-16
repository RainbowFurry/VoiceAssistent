using DarkWolfCraftSys;
using System;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

   public partial class Alert : Window
   {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static Alert alertWindow;
      public static String content;

      /// <summary>
      /// Initialize Alert Window
      /// </summary>
      public Alert()
      {
         InitializeComponent();
         alertWindow = this;
         loadText();

            alertWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            alertWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            alertWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;
            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", Window_Minimize);
        }

      /// <summary>
      /// Load the shown Alert Window Text Content shown to the User
      /// </summary>
      public void loadText()
      {
         alertWindow.DWC_InfoText.Text = content;
      }

      /// <summary>
      /// Close the Window by clicking the OK Button
      /// </summary>
      private void DWC_OK_Button_Click(object sender, RoutedEventArgs e)
      {
         alertWindow.Close();
      }

        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            alertWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (alertWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                alertWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                alertWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            alertWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

    }
}
