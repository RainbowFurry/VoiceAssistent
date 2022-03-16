using DWC_VoiceAssistent.projects.system;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.menu.topbar
{
    class TopBarHandler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private ContextMenu contextMenu_Extras = new ContextMenu();
        private ContextMenu contextMenu_Help = new ContextMenu();

        public TopBarHandler()
        {

            //Set ContextMenus
            setExtrasContextMenu();
            setHelpContextMenu();

            //for(int i = 0; i < MainWindow.mainWindow.TopBar_Grid.Children.Count; i++)
            //{
            //    if (MainWindow.mainWindow.TopBar_Grid.Children[i].ToString().Contains("Label"))
            //    {
            //        Label label = MainWindow.mainWindow.TopBar_Grid.Children[i] as Label;
            //        label.GotFocus += MouseOver;
            //        label.LostFocus += MouseLost;
            //    }
            //}

            //Call Click Event for ContextMenus
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Extras.MouseLeftButtonDown += Extras_Click;
            MainWindow.mainWindow.DWC_MainMenu_Topbar_Help.MouseLeftButtonDown += Help_Click;
        }

        //#region MouseOver Animation
        //private void MouseOver(object sender, RoutedEventArgs e)
        //{
        //    Console.WriteLine("dfhoasifhoebviespbvbprszifgvbepbvszeivpvbzhes");
        //    Label label = sender as Label;
        //    label.Foreground = ProjectVariables.MainColor;
        //}

        //private void MouseLost(object sender, RoutedEventArgs e)
        //{
        //    Label label = sender as Label;
        //    label.Foreground = new SolidColorBrush(Color.FromArgb(255,0,0,0));
        //}
        //#endregion

        #region Set ContextMenus

        private ContextMenu setContextMenuDefault(ContextMenu contextMenu)
        {
            contextMenu.Background = new SolidColorBrush(Color.FromArgb(255, 33, 33, 33));
            contextMenu.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            return contextMenu;
        }

        private void setExtrasContextMenu()
        {
            contextMenu_Extras = setContextMenuDefault(contextMenu_Extras);

            MenuItem menuItem = new MenuItem();
            menuItem.Header = db.DBManager.loadDBValue("SystemInformation");
            menuItem.Click += SystemInfo_Click;
            contextMenu_Extras.Items.Add(menuItem);

        }

        private void setHelpContextMenu()
        {
            contextMenu_Help = setContextMenuDefault(contextMenu_Help);

            MenuItem menuItem = new MenuItem
            {
                Header = db.DBManager.loadDBValue("Webside")
            };
            // menuItem.Click += "";

            MenuItem menuItem1 = new MenuItem();
            menuItem1.Header = db.DBManager.loadDBValue("VoiceCommands");
            // menuItem.Click += "";

            MenuItem menuItem2 = new MenuItem();
            menuItem2.Header = db.DBManager.loadDBValue("FAQ");
            // menuItem.Click += "";

            MenuItem menuItem3 = new MenuItem();
            menuItem3.Header = db.DBManager.loadDBValue("Legal");
            // menuItem.Click += "";

            MenuItem menuItem4 = new MenuItem();
            menuItem4.Header = db.DBManager.loadDBValue("Info");
            menuItem4.Click += Info_Click;

            contextMenu_Help.Items.Add(menuItem);
            contextMenu_Help.Items.Add(menuItem1);
            contextMenu_Help.Items.Add(menuItem2);
            contextMenu_Help.Items.Add(menuItem3);
            contextMenu_Help.Items.Add(menuItem4);

        }
        #endregion

        #region ContextMenu Click Events
        private ContextMenu default_Click(ContextMenu contextMenu)
        {
            contextMenu.PlacementTarget = MainWindow.mainWindow.DWC_MainMenu_Topbar_Extras;
            contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            contextMenu.IsOpen = true;
            return contextMenu;
        }
        private void Extras_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = default_Click(contextMenu_Extras);

            MainWindow.mainWindow.DWC_MainMenu_Topbar_Extras.ContextMenu = contextMenu;
        }

        private void Help_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = default_Click(contextMenu_Help);

            MainWindow.mainWindow.DWC_MainMenu_Topbar_Help.ContextMenu = contextMenu;
        }
        #endregion

        #region MenuItem Event Call

        private void SystemInfo_Click(object sender, RoutedEventArgs e)
        {
            SystemInformation systemInformation = new SystemInformation();
            systemInformation.Show();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            //ProgramInfo programmInfo = new ProgramInfo();
            //programmInfo.Show();
            ProgrammInformation programmInformation = new ProgrammInformation();
            programmInformation.Show();
        }
        #endregion

    }
}
