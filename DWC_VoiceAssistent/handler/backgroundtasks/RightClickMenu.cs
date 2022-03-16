using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DarkWolfCraftSys;
using DWC_VoiceAssistent.manager;
using DWC_VoiceAssistent.plugin;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    class RightClickMenu
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static ContextMenu context;
        public static PluginObject pluginObject;

        /// <summary>
        /// Create the right Click Menu
        /// </summary>
        public static void loadRightClickMenuItems()
        {
            if(context == null)
                context = new ContextMenu();

            context.Background = new SolidColorBrush(Color.FromArgb(255, 33, 33, 33));
            context.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));


            MenuItem menuItemCopy = new MenuItem
            {
                Header = "Copy"
            };
            menuItemCopy.Click += copy;

            MenuItem menuItemPaste = new MenuItem
            {
                Header = "Paste"
            };
            menuItemPaste.Click += paste;

            context.Items.Add(menuItemCopy);
            context.Items.Add(menuItemPaste);

            MenuItem menuItemNewWindow = new MenuItem
            {
                Header = "In neuem Fenster öffnen"
            };
            menuItemNewWindow.Click += OnNewWindow;
            context.Items.Add(menuItemNewWindow);
            context.Items.Add("Item 4");

            LogFileManager.createLogEntrence("Right Click Menu was successfully loaded");
        }

        private static void OnNewWindow(object sender, RoutedEventArgs e)
        {
            PluginManager.OpenPluginInExtraWindow(pluginObject);
        }

        public static void copy(object Sender, EventArgs e)
        {
            TextBox t = new TextBox();
            System.Windows.Clipboard.SetText(t.SelectedText);
        }

        public static void paste(object Sender, EventArgs e)
        {
            TextBox t = new TextBox
            {
                Text = Clipboard.GetText()
            };
        }

    }
}
