using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.db;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.systeminformation
{
    class WindowControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private SystemInformation systemInformationWindow = SystemInformation.systemInformationWindow;

        private StackPanel menuStackPanel = SystemInformation.systemInformationWindow.DWC_MenuList;

        /// <summary>
        /// Initialize SystemInformation WindowControler
        /// </summary>
        public WindowControler()
        {
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(systemInformationWindow.Background);

            loadDB();

            //Add Menu Click Events
            foreach (Grid grid in menuStackPanel.Children)
            {
                grid.MouseLeftButtonDown += menuClick;
            }

            systemInformationWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            systemInformationWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;
            systemInformationWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;

        }

        /// <summary>
        /// Load the Database
        /// </summary>
        private void loadDB()
        {
            systemInformationWindow.AllComponents_Text.Content = ProjectDBManager.loadDBValueSettings("AllComponents_Text");
            systemInformationWindow.Processor_Text.Content = ProjectDBManager.loadDBValueSettings("Processor_Text");
            systemInformationWindow.Graphicscard_Text.Content = ProjectDBManager.loadDBValueSettings("Graphicscard_Text");
            systemInformationWindow.Ram_Text.Content = ProjectDBManager.loadDBValueSettings("Ram_Text");
            systemInformationWindow.Storage_Text.Content = ProjectDBManager.loadDBValueSettings("Storage_Text");
            systemInformationWindow.Mainboard_Text.Content = ProjectDBManager.loadDBValueSettings("Mainboard_Text");
            systemInformationWindow.System_Text.Content = ProjectDBManager.loadDBValueSettings("System_Text");
            systemInformationWindow.Network_Text.Content = ProjectDBManager.loadDBValueSettings("Network_Text");
            systemInformationWindow.Firewall_Text.Content = ProjectDBManager.loadDBValueSettings("Firewall_Text");
            systemInformationWindow.Dhcp_Text.Content = ProjectDBManager.loadDBValueSettings("Dhcp_Text");
            systemInformationWindow.Ad__Text.Content = ProjectDBManager.loadDBValueSettings("Ad__Text");
            systemInformationWindow.Process_Text.Content = ProjectDBManager.loadDBValueSettings("Process_Text");
            systemInformationWindow.Mikrophone_Text.Content = ProjectDBManager.loadDBValueSettings("Mikrophone_Text");
            systemInformationWindow.Printer_Text.Content = ProjectDBManager.loadDBValueSettings("Printer_Text");
            systemInformationWindow.Menu_Hardware_Text.Content = ProjectDBManager.loadDBValueSettings("Menu_Hardware");
            systemInformationWindow.Menu_Software_Text.Content = ProjectDBManager.loadDBValueSettings("Menu_Software");
            systemInformationWindow.Menu_Usb_Text.Content = ProjectDBManager.loadDBValueSettings("Menu_Usb_Text");
        }

        /// <summary>
        /// Get klicked Menu Category and change the shown Content to the Clicked Menu entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuClick(object sender, MouseButtonEventArgs e)
        {

            //alle grids entladen und neue grid laden

            Grid grid = sender as Grid;
            Rectangle rectangle = grid.Children[0] as Rectangle;
            Label label = grid.Children[1] as Label;

            //Menu Grid
            foreach (Grid gr in menuStackPanel.Children)
            {
                Rectangle rec = gr.Children[0] as Rectangle;
                rec.Fill = null;
            }

            //Content Grid
            foreach (Grid gd in SystemInformation.systemInformationWindow.Background.Children)
            {
                if (gd.Name != "Menu")
                {
                    gd.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            menuSelection(grid);
            rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));

        }

        /// <summary>
        /// Change shown Content form menu Selection
        /// </summary>
        /// <param name="grid"></param>
        private void menuSelection(Grid grid)
        {

            switch (grid.Name.Replace("Menu_", ""))
            {

                case "Processor":
                    hardware.Processor.Processor_Click();
                    break;

                case "Graphicscard":
                    hardware.Graphicscard.GraficsCart_Click();
                    break;

                case "Ram":
                    hardware.Ram.RAMClick();
                    break;

                case "Storage":
                    hardware.Storage.StorageInformation();
                    break;

                case "Mainboard":
                    hardware.Mainboard.getMainBoardInformation();
                    break;

                case "System":
                    software.System.OwnWinSysClick();
                    break;

                case "Network":
                    software.Network.NetworkClick();
                    break;

                case "Firewall":
                    software.Firewall.getFirewallInformation();
                    break;

                case "Dhcp":
                    //
                    break;

                case "Ad":
                    software.Ad.getADUserInfo();
                    break;

                case "Process":
                    software.SystemProcesse.ProzesseClick();
                    break;

                case "Microphone":
                    //
                    break;

                case "Printer":
                    //
                    break;

            }

        }

        #region Window Options
        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            SystemInformation.systemInformationWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, MouseButtonEventArgs e)
        {
            if (SystemInformation.systemInformationWindow.DWC_Window.WindowState == System.Windows.WindowState.Normal)
            {
                SystemInformation.systemInformationWindow.DWC_Window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                SystemInformation.systemInformationWindow.DWC_Window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SystemInformation.systemInformationWindow.DWC_Window.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        private void setGridColor()
        {

            systemInformationWindow.Background.Background = ProjectVariables.Theme_DarkBackground;
            systemInformationWindow.Menu.Background = ProjectVariables.Theme_MiddleDark;

        }

    }
}
