using DWC_VoiceAssistent.plugin;
using DWC_VoiceAssistent.projects.system;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DWC_VoiceAssistent.manager.socketmanagement.pluginstore
{
    class HandleRequestedPlugins
    {
        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public HandleRequestedPlugins(string response)
        {
            
            string[] plugins = response.Split(';');
            int right = 0;
            int marginTop = 15;
            int marginLeft = 60;
            Grid grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = PluginStore.pluginStoreWindow.Menu_ForYou.Width
            };
            foreach(string pluginInfo in plugins)
            {
                if (string.IsNullOrEmpty(pluginInfo))
                    continue;
                string[] jsonSplit = pluginInfo.Split('-');
                JValue jValue = new JValue(jsonSplit[1]);
                string plugin = jsonSplit[0];
                byte[] data = jValue.ToObject<byte[]>();
                Grid pluginGrid = new Grid()
                {
                    Name = plugin,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 215,
                    Width = 400,
                    Background = new ImageBrush()
                    {
                        ImageSource = ByteImageConverter.ByteToImage(data)
                    },
                    Margin = new Thickness(marginLeft, marginTop, 0, 0)
                };
                Label label = new Label()
                {
                    Name = plugin,
                    Content = (plugin + ": ").Replace("_", "__"),
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                    Margin = new Thickness(marginLeft, marginTop + 250, 0, 0)
                };
                label.FontSize = 16;
                if (PluginManager.GetPlugin(plugin) == null)
                    label.Content += " Jetzt downloaden und installieren.";
                else
                    label.Content += " Schon erworben";

                label.MouseLeftButtonDown += OpenInfoWindow;
                pluginGrid.MouseLeftButtonDown += OpenInfoWindow;

                grid.Children.Add(pluginGrid);
                grid.Children.Add(label);
                right++;
                if (right == 3)
                {
                    right = 0;
                    marginLeft = 60;
                    marginTop += 350;
                }
                else if (right == 0)
                    marginLeft = 60;
                else if (right == 1)
                    marginLeft = 480;
                else
                    marginLeft = 905;
            }
            grid.Height += 300;
            PluginStore.pluginStoreWindow.Menu_ForYou.Children.Add(grid);
            PluginStore.pluginStoreWindow.Menu_ForYou.Children.Add(new Grid()
            {
                Height = 100,
                Width = 50
            });
        }

        private void OpenInfoWindow(object sender, MouseButtonEventArgs e)
        {

            PluginStore.pluginStoreWindow.Menu_ForYou.Visibility = Visibility.Hidden;
            PluginStore.pluginStoreWindow.PluginInformation.Visibility = Visibility.Visible;
        }

        private class ByteImageConverter
        {
            public static ImageSource ByteToImage(byte[] imageData)
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                ImageSource imgSrc = biImg as ImageSource;

                return imgSrc;
            }

            public static string ImageToByte(FileStream fs)
            {
                byte[] imgBytes = new byte[fs.Length];
                fs.Read(imgBytes, 0, Convert.ToInt32(fs.Length));
                string encodeData = Convert.ToBase64String(imgBytes, Base64FormattingOptions.InsertLineBreaks);

                return encodeData;
            }
        }

        private async void Download(object sender, MouseButtonEventArgs e)
        {
            if(sender.GetType().Equals(typeof(Label)))
                SocketManager.Send("download_plugin", ((Label)sender).Name);
            else
                SocketManager.Send("download_plugin", ((Grid)sender).Name);
            /*Label label = sender as Label;
            string plugin = label.Name;
            WebClient webClient = new WebClient();
            try
            {
                await webClient.DownloadFileTaskAsync(new Uri("http://darkwolfcraft.net/DWC_VoiceAssistant/plugins/" + plugin + ".zip"), MainWindow.Save_Path + "/Plugins/" + plugin + ".zip");
            }catch
            {
                MessageBox.Show("Plugin Konnte nicht gedownloaded werden. Bitte versuche es später noch einmal", "Fehler");
                webClient.Dispose();
                return;
            }
            webClient.Dispose();
            ZipArchive zipArchive = ZipFile.OpenRead(MainWindow.Save_Path + "/Plugins/" + plugin + ".zip");
            foreach (ZipArchiveEntry entry in zipArchive.Entries)
            {
                entry.ExtractToFile(MainWindow.Save_Path + "/Plugins/" + entry.Name, true);
            }
            zipArchive.Dispose();
            File.Delete(MainWindow.Save_Path + "/Plugins/" + plugin + ".zip");
            PluginManager.SetupAssembly(Assembly.LoadFrom(MainWindow.Save_Path + "/Plugins/" + plugin + ".exe"));
            MessageBox.Show("Plugin wurde erfolgreich installiert.", "Plugin: " + plugin);
            PluginStore.pluginStoreWindow.Close();*/
        }
    }
}
