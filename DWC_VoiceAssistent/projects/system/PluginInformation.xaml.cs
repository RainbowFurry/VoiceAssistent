using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DWC_VoiceAssistent.projects.system
{

   public partial class PluginInformation : Window
   {

      public static PluginInformation pluginManager;
      private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
      public static int PluginsLoaded = 0;

      /// <summary>
      /// Initialize Plugin Information Window
      /// </summary>
      public PluginInformation()
      {
         InitializeComponent();
         pluginManager = this;
         this.Show();

         myTimer.Tick += timer_Tick;
         myTimer.Start();

         if (plugin.PluginManager.pluginName.Count > 0)
         {

            for (int i = 0; i < plugin.PluginManager.pluginName.Count; i++)
            {
               #region create Plugin

               Plugin.pluginName = DWC_VoiceAssistent.plugin.PluginManager.pluginName[i];
               Plugin.pluginVersion = DWC_VoiceAssistent.plugin.PluginManager.pluginVersion[i];
               Plugin.pluginDescription = DWC_VoiceAssistent.plugin.PluginManager.pluginDescription[i];
               Plugin.pluginCopyRight = DWC_VoiceAssistent.plugin.PluginManager.pluginCopyRight[i];
               Plugin.pluginCompany = DWC_VoiceAssistent.plugin.PluginManager.pluginCompany[i];
               #endregion

               loadPluginInfoList();
            }

         }

      }

      /// <summary>
      /// Create own Programm Plugin list
      /// </summary>
      public struct Plugin
      {
         public static String pluginName;
         public static String pluginCompany;
         public static String pluginDescription;
         public static String pluginVersion;
         public static String pluginCopyRight;
      }

      /// <summary>
      /// Create the Plugin entry List shown with the Plugin Information Text
      /// </summary>
      public static void loadPluginInfoList()
      {

         Color color = (Color)ColorConverter.ConvertFromString("#5e5e5e");

         #region Plugin Background
         StackPanel plugin = new StackPanel();
         plugin.Background = new SolidColorBrush(color);
         plugin.Width = 775;
         plugin.Height = 110;
         #endregion

         #region Create Text Fields

         #region Plugin Name
         Label pluginName = new Label();
         pluginName.Content = "Name: " + Plugin.pluginName;
         pluginName.Width = pluginManager.DWC_PluginName.Width;
         pluginName.Height = pluginManager.DWC_PluginName.Height;
         //pluginName.Foreground = new SolidColorBrush(Colors.White);
         pluginName.Margin = new Thickness(0, 0, 0, 0);
         plugin.Children.Add(pluginName);
         #endregion

         #region Plugin Description
         Label pluginDescription = new Label();
         pluginDescription.Content = "Description: " + Plugin.pluginDescription;
         pluginDescription.Width = pluginManager.DWC_PluginDescription.Width;
         pluginDescription.Height = pluginManager.DWC_PluginDescription.Height;
         pluginDescription.Margin = new Thickness(0, 0, 0, 0);
         plugin.Children.Add(pluginDescription);
         #endregion

         #region Plugin Company
         Label pluginCompany = new Label();
         pluginCompany.Content = "Company: " + Plugin.pluginCompany;
         pluginCompany.Width = pluginManager.DWC_PluginCompany.Width;
         pluginCompany.Height = pluginManager.DWC_PluginCompany.Height;
         pluginCompany.Margin = new Thickness(-415, 0, 0, 0);
         plugin.Children.Add(pluginCompany);
         #endregion

         #region Plugin CopyRight
         Label pluginCopyRight = new Label();
         pluginCopyRight.Content = "CopyRight: " + Plugin.pluginCopyRight;
         pluginCopyRight.Width = pluginManager.DWC_PluginCopyRight.Width;
         pluginCopyRight.Height = pluginManager.DWC_PluginCopyRight.Height;
         pluginCopyRight.Margin = new Thickness(-285, 0, 0, 0);
         plugin.Children.Add(pluginCopyRight);
         #endregion

         #region Plugin Version
         Label pluginVersion = new Label();
         pluginVersion.Content = "Version: " + Plugin.pluginVersion;
         pluginVersion.Width = pluginManager.DWC_PluginVersion.Width;
         pluginVersion.Height = pluginManager.DWC_PluginVersion.Height;
         pluginVersion.Margin = new Thickness(0, -20, -650, 0);
         plugin.Children.Add(pluginVersion);
         #endregion


         #endregion

         #region Verify Plugin
         if (Plugin.pluginName.Contains("DWC") || Plugin.pluginName.Contains("DarkWolfCraft"))
         {
            System.Windows.Controls.Image verify = new System.Windows.Controls.Image();
            verify.Source = pluginManager.DWC_ProtectedPlugin.Source;
            verify.Width = pluginManager.DWC_ProtectedPlugin.Width;
            verify.Height = pluginManager.DWC_ProtectedPlugin.Height;
            verify.ToolTip = "This Plugin is a secure Plugin";
            verify.Margin = new Thickness(0, -190, -700, 0);
            plugin.Children.Add(verify);

         }
         #endregion

         #region CheckBox
         CheckBox checkBox = new CheckBox();
         checkBox.Width = pluginManager.DWC_SelectPlugin.Width;
         checkBox.Height = pluginManager.DWC_SelectPlugin.Height;
         checkBox.Margin = new Thickness(20, -60, 0, 0);
         plugin.Children.Add(checkBox);
         #endregion

         #region Buttons

         #region Drop Down
         //Button dropDown = new Button();
         //add event
         #endregion

         #region Activate / Disable Plugin
         Button loadedState = new Button();
         loadedState.Content = pluginManager.DWC_ActivePlugin.Content;
         loadedState.Width = pluginManager.DWC_ActivePlugin.Width;
         loadedState.Height = pluginManager.DWC_ActivePlugin.Height;



         StackPanel loadedStateContainer = new StackPanel();
         loadedStateContainer.Children.Add(loadedState);
         loadedStateContainer.Margin = new Thickness(740, -105, 0, 0);


         plugin.Children.Add(loadedStateContainer);
         //register event
         #endregion

         #endregion

         pluginManager.DWC_PluginOverView.Children.Add(plugin);

      }

      #region window

      private void DWC_ShortCut(object sender, KeyEventArgs e)
      {
         functions.ShortCut.DWC_ShortCut(sender, e);
      }

      private void timer_Tick(object sender, EventArgs e)
      {
         DWC_Time.Content = DateTime.Now.ToLongTimeString();
         DWC_Date.Content = DateTime.Now.ToLongDateString();
      }

      #endregion

      /*
       Obere menu leiste wo man alles auswählen kann und bearbeiten kann. laden entladen etc.
       haken um auswählen links außen - select all
       Plugin prüfen ob Im Compiler Info DWC_ -> dann protected icon hinzufügen
       Der haken = geladen das x = entladen
       */

   }
}
