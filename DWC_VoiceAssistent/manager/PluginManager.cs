using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using DarkWolfCraftSys;
using System.Windows.Controls;
using System.Drawing;
using DWC_VoiceAssistent.manager;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using DWC_VoiceAssistent.handler.backgroundtasks;
using Image = System.Windows.Controls.Image;

namespace DWC_VoiceAssistent.plugin
{

    /*
    * Creator: Adrian H.
    * Date: -
    * Comment: -
    */

    class PluginManager
    {

        private static readonly Dictionary<string, PluginObject> pluginList = new Dictionary<string, PluginObject>();
        private readonly List<string> rawPluginList;
        private readonly string SavePath;

        public PluginManager()
        {
            rawPluginList = new List<string>();
            SavePath = MainWindow.Save_Path + @"Plugins\";
            Init();
        }

        private void Init()
        {
            if (!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);
            string[] plugins = Directory.GetFiles(SavePath, "*.exe");
            foreach (var rawPlugin in plugins)
            {
                rawPluginList.Add(rawPlugin);
            }
            LoadPlugins();
        }

        public static void OpenPluginInExtraWindow(PluginObject pluginObject)
        {
            Window window = Activator.CreateInstance(pluginObject.Type) as Window;
            window.Show();
        }

        private void LoadPlugins()
        {
            foreach (var rawPlugin in rawPluginList)
            {
                Assembly assembly = Assembly.LoadFrom(rawPlugin);
                SetupAssembly(assembly);
            }
        }

        public static void SetupAssembly(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(true);
            AssemblyTitleAttribute titleAttribute = attributes[3] as AssemblyTitleAttribute;
            AssemblyDescriptionAttribute descriptionAttribute = attributes[4] as AssemblyDescriptionAttribute;
            AssemblyCompanyAttribute companyAttribute = attributes[6] as AssemblyCompanyAttribute;
            AssemblyCopyrightAttribute copyrightAttribute = attributes[8] as AssemblyCopyrightAttribute;
            AssemblyTrademarkAttribute trademarkAttribute = attributes[9] as AssemblyTrademarkAttribute;
            Type type = assembly.GetType(titleAttribute.Title + ".MainWindow");
            PluginObject pluginObject = new PluginObject(titleAttribute.Title, descriptionAttribute.Description, companyAttribute.Company, copyrightAttribute.Copyright, trademarkAttribute.Trademark, type, false);
            LoadPlugin(pluginObject, assembly);
        }

        private static void LoadPlugin(PluginObject pluginObject, Assembly assembly)
        {
            if (pluginObject.Loaded) return;
            pluginObject.Loaded = true;
            pluginList.Add(pluginObject.Name, pluginObject);
            Icon appIcon = Icon.ExtractAssociatedIcon(assembly.Location);

            Grid grid = new Grid()
            {
                Name = "Addon_" + pluginObject.Name,
                Width = 68,
                Height = 68,
                ToolTip = ProjectVariables.CreateToolTip(pluginObject.Name),
                Margin = new Thickness(0, 0, 0, 0)
            };

            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(appIcon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Image image = new Image()
            {
                Source = imageSource,
                Margin = new Thickness(0, 0, 0, 0),
                Width = 48,
                Height = 48
            };
            grid.Children.Add(image);
            grid.MouseLeftButtonDown += OnAddonClick;
            grid.MouseRightButtonUp += RegisterPluginObject;
            MainWindow.mainWindow.DWC_MainMenu_AppList.Children.Add(grid);
        }

        private static void RegisterPluginObject(object sender, MouseButtonEventArgs e)
        {
            RightClickMenu.pluginObject = GetPlugin((sender as Grid).Name.Replace("Addon_", ""));
        }

        private static void OnAddonClick(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;
            PluginObject a = GetPlugin(grid.Name.Replace("Addon_", ""));
            // TODO Fenster in MainWindow laden anstatt Activator
            try
            {
                Window window = Activator.CreateInstance(a.Type) as Window;
                Grid mainGrid = window.Content as Grid;
                window.Content = null;
                MainWindow.mainWindow.DWC_MainWindow_AppContent.Children.Clear();
                MainWindow.mainWindow.DWC_MainWindow_AppContent.Children.Add(mainGrid);

                //Set the OpenProgramm Title and Icon in the MainWindow
                Image openProgrammImage = grid.Children[0] as Image;
                MainWindow.mainWindow.DWC_OpenProgrammTitle.Content = grid.Name.Replace("Addon_", "").Replace("DWC","");
                MainWindow.mainWindow.DWC_OpenProgrammIcon.Source = openProgrammImage.Source;

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        public void UnloadPlugin(PluginObject pluginObject)
        {
            UIElementCollection elements = MainWindow.mainWindow.DWC_MainMenu_AppList.Children;
            Grid searched = null;
            foreach (UIElement element in elements)
            {
                if (element.GetType() == typeof(Grid))
                {
                    Grid grid = element as Grid;
                    if (grid.Name.Replace("Addon_", "").Equals(pluginObject.Name))
                        searched = grid;
                }
            }
            if (searched != null)
                MainWindow.mainWindow.DWC_MainMenu_AppList.Children.Remove(searched);
            pluginObject.Loaded = false;
            pluginList.Remove(pluginObject.Name);
        }

        public static PluginObject GetPlugin(string name)
        {
            if (pluginList.ContainsKey(name))
                return pluginList[name];
            else
                return null;
        }

    }
}
