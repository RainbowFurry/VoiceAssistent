using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace DWC_Weather.manager
{

    //ICONS: - https://openweathermap.org/weather-conditions

    class JsonManager
    {

        //Eventuell für mehrere Tage z.b. mo-fr anzeigen.
        //user can add postcode and programm outputs ...

        /// <summary>
        /// Get the Weather Information by the Users current GeoLocation
        /// </summary>
        [STAThread]
        public static void getWeatherWithGeoLocation()
        {

            loadIp();

            WebClient webClient = new WebClient();
            //webClient.DownloadFile(@"https://api.openweathermap.org/data/2.5/weather?zip=lat=" + lat + "&lon=" + lng + "&units=metric&apikey=bb3d887e7c1f4952de3e58319bf1410a", MainWindow.Save_Path + @"Weather.json");
            webClient.DownloadFile(@"https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lng + "&units=metric&apikey=bb3d887e7c1f4952de3e58319bf1410a", MainWindow.Save_Path + @"Location_Weather.json");

            StreamReader streamReader = new StreamReader(MainWindow.Save_Path + "Location_Weather.json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);

            Weather.Info.temp = obj["main"]["temp"].ToString();
            Weather.Info.tempMin = obj["main"]["temp_min"].ToString();
            Weather.Info.tempMax = obj["main"]["temp_max"].ToString();
            Weather.Info.cityName = obj["name"].ToString();
            Weather.Info.iconID = obj["weather"][0]["icon"].ToString();
            Weather.Info.clouds = obj["clouds"]["all"].ToString();

            //Console.WriteLine("ACH DU KACKE WAS GEHT:::");
            //Console.WriteLine(obj["sys"]["sunrise"].ToString());
            //Console.WriteLine(DateTime.FromFileTimeUtc(1581092940 * 1000).ToLocalTime());

            Weather.Info.wind = obj["wind"]["speed"].ToString();
            Weather.Info.weather = obj["weather"][0]["description"].ToString();

        }

        /// <summary>
        /// Get the Weather Information of the given ZipCode City
        /// </summary>
        /// <param name="zipCode">The ZipCode of the searching City Info</param>
        [STAThread]
        public static void getWeatherWithZipCode(String zipCode)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(@"https://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",de&units=metric&apikey=bb3d887e7c1f4952de3e58319bf1410a", MainWindow.Save_Path + @"ZipCode_Weather.json");

            StreamReader streamReader = new StreamReader(MainWindow.Save_Path + "ZipCode_Weather.json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);

            Weather.Info.temp = obj["main"]["temp"].ToString();
            Weather.Info.tempMin = obj["main"]["temp_min"].ToString();
            Weather.Info.tempMax = obj["main"]["temp_max"].ToString();
            Weather.Info.cityName = obj["name"].ToString();
            Weather.Info.iconID = obj["weather"]["icon"].ToString();

            Weather.Info.wind = obj["wind"]["speed"].ToString();
            Weather.Info.weather = obj["weather"][0]["description"].ToString();

        }

        private static String lat = "";
        private static String lng = "";

        /// <summary>
        /// Get the Users Ip Address and look up the GeoLocation
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

    class Weather
    {

        public struct Info
        {

            public static String temp;//temp
            public static String tempMin;//min temp
            public static String tempMax;//max temp
            public static String cityName;//city Name
            public static String weather;// sun/rain etc
            public static String wind;//wind strength
            public static String iconID;//Image ID
            public static String clouds;

        }

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
