using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace DarkWolfCraftSys
{
    public class ProjectVariables
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        #region Color Definition
        public static SolidColorBrush Red = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));//#FF0000
        public static SolidColorBrush Green = new SolidColorBrush(Color.FromArgb(255, 30, 215, 96));//#1ED760
        public static SolidColorBrush Orange = new SolidColorBrush(Color.FromArgb(255, 255, 94, 0));//#FF5E00
        public static SolidColorBrush Yellow = new SolidColorBrush(Color.FromArgb(255, 255, 247, 0));//#FFF700

        public static SolidColorBrush LightGray = new SolidColorBrush(Color.FromArgb(255, 155, 155, 159));//#9B9B9F
        public static SolidColorBrush DarkGray = new SolidColorBrush(Color.FromArgb(255, 107, 107, 107));//#6B6B6B
        #endregion

        #region Theme Definition
        public static String ThemeMainColor = "#FF0F7FEE";
        public static SolidColorBrush MainColor;

        public static SolidColorBrush Theme_DarkestDark = new SolidColorBrush(Color.FromArgb(255, 28, 30, 32));//FF1C1E20
        public static SolidColorBrush Theme_MiddleDark = new SolidColorBrush(Color.FromArgb(255, 43, 43, 43));//FF2B2B2B
        public static SolidColorBrush Theme_DarkBackground = new SolidColorBrush(Color.FromArgb(255, 49, 49, 54));//FF313136
        public static SolidColorBrush Theme_LighterDark = new SolidColorBrush(Color.FromArgb(255, 55, 54, 63));//FF37363F
        public static SolidColorBrush Theme_DarkRectangleAccent = new SolidColorBrush(Color.FromArgb(255, 46, 46, 54));//#FF2E2E36
        public static SolidColorBrush Theme_DarkRectangleAccent_Dark = new SolidColorBrush(Color.FromArgb(255, 34, 36, 37));//#FF222425

        public static SolidColorBrush Theme_DarkestLight = new SolidColorBrush(Color.FromArgb(255, 110, 118, 126));//FF6E767E
        public static SolidColorBrush Theme_MiddleLight = new SolidColorBrush(Color.FromArgb(255, 147, 144, 144));//FF939090
        public static SolidColorBrush Theme_LightBackground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));//FF313136
        public static SolidColorBrush Theme_LighterLight = new SolidColorBrush(Color.FromArgb(255, 222, 222, 222)); //FF37363F
        public static SolidColorBrush Theme_LightRectangleAccent = new SolidColorBrush(Color.FromArgb(255, 46, 46, 54));//#NOT SET
        public static SolidColorBrush Theme_DarkRectangleAccent_Light = new SolidColorBrush(Color.FromArgb(255, 34, 36, 37));//#NOT SET

        public static SolidColorBrush Theme_DarkestDarkTransparent = new SolidColorBrush(Color.FromArgb(140, 28, 30, 32));//8C1C1E20
        public static SolidColorBrush Theme_MiddleDarkTransparent = new SolidColorBrush(Color.FromArgb(140, 43, 43, 43));//8C2B2B2B
        public static SolidColorBrush Theme_DarkBackgroundTransparent = new SolidColorBrush(Color.FromArgb(140, 49, 49, 54));//8C313136
        public static SolidColorBrush Theme_LighterDarkTransparent = new SolidColorBrush(Color.FromArgb(140, 55, 54, 63));//8C36363F
        public static SolidColorBrush Theme_DarkRectangleAccentTransparent = new SolidColorBrush(Color.FromArgb(255, 46, 46, 54));//#NOT SET
        public static SolidColorBrush Theme_DarkRectangleAccent_Transparent = new SolidColorBrush(Color.FromArgb(255, 34, 36, 37));//#NOT SET
        #endregion

        #region Shadow
        public static DropShadowEffect shadowEffect = new DropShadowEffect
        {
            Color = new Color { A = 200, R = 0, G = 0, B = 0 },
            Direction = 315,
            ShadowDepth = 1,
            Opacity = 10
        };

        //NICHT ANGEPASST!!!
        public static DropShadowEffect textShadowEffect = new DropShadowEffect
        {
            Color = new Color { A = 200, R = 0, G = 0, B = 0 },
            Direction = 315,
            ShadowDepth = 2,
            Opacity = 1
        };
        #endregion

        public static ToolTip CreateToolTip(string content)
        {
            return new ToolTip()
            {
                Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 33, 33, 33)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255)),
                Content = content
            };
        }

        public static void LoadSvgImage(string svgFile, Image source)
        {
            WpfDrawingSettings settings = new WpfDrawingSettings
            {
                TextAsGeometry = true
            };

            FileSvgReader converter = new FileSvgReader(settings);
            DrawingGroup drawing = converter.Read(svgFile);

            if (drawing != null)
                source.Source = new DrawingImage(drawing);
        }

        public static void LoadSvgImage(string svgFile, System.Windows.Shapes.Rectangle rectangle)
        {
            WpfDrawingSettings settings = new WpfDrawingSettings
            {
                TextAsGeometry = true
            };

            FileSvgReader converter = new FileSvgReader(settings);
            DrawingGroup drawing = converter.Read(svgFile);

            if (drawing != null)
                rectangle.Fill = new ImageBrush()
                {
                    ImageSource = new DrawingImage(drawing)
                };
        }

        #region Social Links
        public static String gitLab = "";
        public static String webside = @"https://www.darkwolfcraft.net/";
        public static String youtube = "";
        public static String facebook = "";
        public static String instagram = "";
        public static String twitter = "";
        #endregion

    }
}
