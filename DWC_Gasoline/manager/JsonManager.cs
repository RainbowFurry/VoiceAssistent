using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows.Controls;
using System.Windows.Media;
using System.Globalization;

namespace DWC_Gasoline.manager
{
    class JsonManager
    {

        //INFO : https://creativecommons.tankerkoenig.de/api_register_part2.php?email=darkwolfcraft.net%40gmail.com&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95

        private static string savePath = MainWindow.Save_Path + @"DWC_GasolinCurse\";
        private static WebClient webClient = new WebClient();
        private static Gassolin gassolin = new Gassolin();

        /// <summary>
        /// Load Gasolin Top Price infos
        /// </summary>
        [STAThread]
        private static void loadTopPrices(String id)
        {

            //if (!File.Exists(savePath + "GasolinInfo_" + id + ".json"))
            //{
            //    webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/prices.php?ids=" + id + "&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", savePath + "GasolinInfo_" + id + ".json");
            //}

            //StreamReader streamReader = new StreamReader(savePath + "GasolinInfo_" + id + ".json");
            //string json = streamReader.ReadToEnd();

            //JObject obj = JObject.Parse(json);

            //try
            //{

            //    //gassolin.diesel = obj["prices"][id]["diesel"];
            //    //gassolin.e5 = obj["prices"][id]["e5"];
            //    //gassolin.e10 = obj["prices"][id]["e10"];

            //    #region show Gasoline Price
            //    mainWindow.DWC_Diesel_Price.Content = Math.Round(Convert.ToDouble(obj["prices"][id]["diesel"]), 2) + "€";
            //    mainWindow.DWC_E5_Price.Content = Math.Round(Convert.ToDouble(obj["prices"][id]["e5"]), 2) + "€";
            //    mainWindow.DWC_E10_Price.Content = Math.Round(Convert.ToDouble(obj["prices"][id]["e10"]), 2) + "€";
            //    #endregion

            //}
            //catch (Exception e)
            //{

            //}

        }

        /// <summary>
        /// Load Gasolin Shop infos
        /// </summary>
        [STAThread]
        public static void loadGasolineStationInfo(String id)
        {

            if (!File.Exists(savePath + "GasolinInfo_" + id + ".json"))
            {
                webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/prices.php?ids=" + id + "&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", savePath + "GasolinInfo_" + id + ".json");
            }

            if (id != "" || id != null)
            {
                //Load more info - öffnungszeiten..

                StreamReader streamReader = new StreamReader(savePath + "GasolinInfo_" + id + ".json");
                string json = streamReader.ReadToEnd();

                JObject obj = JObject.Parse(json);

                try
                {

                    if (!String.IsNullOrEmpty(obj["prices"][id]["diesel"].ToString()))
                    {
                        gassolin.diesel = obj["prices"][id]["diesel"];
                        gassolin.e5 = obj["prices"][id]["e5"];
                        gassolin.e10 = obj["prices"][id]["e10"];
                    }

                }
                catch (Exception e)
                {

                }
            }
            //UND FILIALEN INFO GENERELL... + IMAGE

        }

        /// <summary>
        /// Load Location and distanced Shops
        /// </summary>
        [STAThread]
        public static void loadGasolinPostcode()
        {

            loadIp();

            webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/list.php?lat=" + lat + "&lng=" + lng + "&rad=10&sort=price&type=diesel&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", savePath + "GasolinPostcode.json");

            StreamReader streamReader = new StreamReader(savePath + "GasolinPostcode.json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);
            loadTopPrices(obj["stations"][0]["id"].ToString());

            try
            {

                for (int i = 0; i < 15; i++)
                {
                    if (!String.IsNullOrEmpty(obj["stations"][i]["id"].ToString()))
                    {

                        gassolin.id = obj["stations"][i]["id"];
                        gassolin.name = obj["stations"][i]["name"];
                        gassolin.street = obj["stations"][i]["street"];
                        gassolin.place = obj["stations"][i]["place"];
                        gassolin.lat = obj["stations"][i]["lat"];
                        gassolin.lng = obj["stations"][i]["lng"];
                        gassolin.distance = obj["stations"][i]["dist"];
                        gassolin.diesel = obj["stations"][i]["diesel"];
                        gassolin.e5 = obj["stations"][i]["e5"];
                        gassolin.e10 = obj["stations"][i]["e10"];
                        gassolin.isopen = obj["stations"][i]["isOpen"];
                        gassolin.housenumber = obj["stations"][i]["houseNumber"];
                        gassolin.postcode = obj["stations"][i]["postCode"];
                        gassolin.brand = obj["stations"][i]["brand"];

                        loadGasolineStationInfo(obj["stations"][i]["id"].ToString());


                        #region create View Content

                        /*Image image = new Image();
                        System.Windows.Media.Imaging.BitmapImage bitmapimage = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"C:\Users\jhoffmann\Desktop\Server\a.jpg", UriKind.Relative));
                        image.Source = bitmapimage;
                        image.With = 100;
                        image.Height = 100;
                        stackPanel.Children.Add(image);*/

                        Grid grid = new Grid();

                        Label name = new Label();
                        name.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        name.Content = gassolin.name + "  (" + gassolin.brand + ")";
                        name.Margin = new System.Windows.Thickness(100, 6, 0, 0);
                        grid.Children.Add(name);

                        Label street = new Label();
                        street.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        street.Content = gassolin.street + " " + gassolin.housenumber;
                        street.Margin = new System.Windows.Thickness(359, 10, 0, 0);
                        grid.Children.Add(street);

                        Label place = new Label();
                        place.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        place.Content = gassolin.place + " " + gassolin.postcode;
                        place.Margin = new System.Windows.Thickness(359, 32, 0, 0);
                        grid.Children.Add(place);

                        Label isopen = new Label();
                        isopen.Margin = new System.Windows.Thickness(105, 56, 0, 0);

                        if (gassolin.isopen.ToString() == "True")
                        {
                            isopen.Foreground = new SolidColorBrush(Color.FromRgb(2, 240, 70));
                            isopen.Content = "Open";
                        }
                        else
                        {
                            isopen.Foreground = new SolidColorBrush(Color.FromRgb(242, 16, 0));
                            isopen.Content = "Closed";
                        }
                        grid.Children.Add(isopen);

                        Label diesel = new Label();
                        diesel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        diesel.Content = Math.Round(Convert.ToDouble(gassolin.diesel), 2);
                        diesel.Margin = new System.Windows.Thickness(606, 17, 0, 0);
                        diesel.FontSize = 36;
                        grid.Children.Add(diesel);

                        Label super = new Label();
                        super.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        super.Content = Math.Round(Convert.ToDouble(gassolin.e5), 2);
                        super.Margin = new System.Windows.Thickness(724, 17, 0, 0);
                        super.FontSize = 36;
                        grid.Children.Add(super);

                        Label superPlus = new Label();
                        superPlus.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        superPlus.Content = Math.Round(Convert.ToDouble(gassolin.e5), 2);
                        superPlus.Margin = new System.Windows.Thickness(840, 17, 0, 0);
                        superPlus.FontSize = 36;
                        grid.Children.Add(superPlus);

                        Label e10 = new Label();
                        e10.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        e10.Content = Math.Round(Convert.ToDouble(gassolin.e5), 2);
                        e10.Margin = new System.Windows.Thickness(952, 17, 0, 0);
                        e10.FontSize = 36;
                        grid.Children.Add(e10);

                        Border border1 = new Border();
                        border1.BorderThickness = new System.Windows.Thickness(1);
                        border1.Margin = new System.Windows.Thickness(3, 88, 0, 0);
                        border1.Width = 541;
                        grid.Children.Add(border1);

                        Border border2 = new Border();
                        border2.BorderThickness = new System.Windows.Thickness(1);
                        border2.Margin = new System.Windows.Thickness(595, 88, 0, 0);
                        border1.Width = 520;
                        grid.Children.Add(border2);

                        MainWindow.mainWindow.DWC_Gasolin_Content.Children.Add(grid);

                        #endregion

                    }
                }

                loadTopPrices(obj["stations"][0]["id"].ToString());

            }
            catch (Exception e)
            {

                String errorMessage = "[ERROR]\n" +
                "[ERROR][Message] - " + e.Message + "\n" +
                "[ERROR][Message] - " + e.Source + "\n" +
                "[ERROR][Message] - " + e.HelpLink + "\n" +
                "[ERROR][Message] - " + e.Data + "\n" +
                "[ERROR][Message] - " + e.StackTrace + "\n" +
                "[ERROR][Message] - " + e.InnerException + "\n";

                Console.WriteLine(errorMessage);

            }

        }

        private static String lat = "";
        private static String lng = "";

        /// <summary>
        /// Load the Users GeoLocation with the IP Address
        /// </summary>
        [STAThread]
        private static void loadIp()
        {

            IpInfo ipInfo = new IpInfo();
            string info = new WebClient().DownloadString("http://ipinfo.io/");
            ipInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfo>(info);
            RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
            ipInfo.Country = myRI1.EnglishName;

            String[] lol = ipInfo.Loc.Split(',');
            lat = lol[0];
            lng = lol[1];

        }

    }

    class Gassolin
    {
        public object id { get; set; }
        public object name { get; set; }
        public object street { get; set; }
        public object place { get; set; }
        public object lat { get; set; }
        public object lng { get; set; }
        public object distance { get; set; }
        public object diesel { get; set; }
        public object e5 { get; set; }
        public object e10 { get; set; }
        public object isopen { get; set; }
        public object housenumber { get; set; }
        public object postcode { get; set; }
        public object brand { get; set; }

    }

    public class IpInfo
    {

        [Newtonsoft.Json.JsonProperty("ip")]
        public string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("hostname")]
        public string Hostname { get; set; }

        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty("region")]
        public string Region { get; set; }

        [Newtonsoft.Json.JsonProperty("country")]
        public string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("loc")]
        public string Loc { get; set; }

        [Newtonsoft.Json.JsonProperty("org")]
        public string Org { get; set; }

        [Newtonsoft.Json.JsonProperty("postal")]
        public string Postal { get; set; }
    }

}
