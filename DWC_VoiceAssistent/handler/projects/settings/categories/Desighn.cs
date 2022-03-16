using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.settings.categories
{
    class Desighn
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static Settings settingsWindow = Settings.SettingsWindow;
        private static ColorDialog colorDlg = new ColorDialog();

        private static FontFamily[] fontFamilie = new FontFamily[Fonts.SystemFontFamilies.Count];
        private static int fontFamilieSelected = 0;

        private static String[] files = Directory.GetFiles(MainWindow.Save_Path + @"Cursors\");
        private static int cursorSelected = -1;

        public Desighn()
        {
            loadDB();
            loadImages();
            loadColors();
            loadSettings();

            //designChange
            settingsWindow.Design_DarkDesign_Rectangle.MouseLeftButtonDown += designChange;
            settingsWindow.Design_BrightDesign_Rectangle.MouseLeftButtonDown += designChange;
            settingsWindow.Design_TransparentDesign_Rectangle.MouseLeftButtonDown += designChange;

            //transparentImageChange
            settingsWindow.Design_Gaming_Rectangle.MouseLeftButtonDown += transparentImageChange;
            settingsWindow.Design_Landscape_Rectangle.MouseLeftButtonDown += transparentImageChange;
            settingsWindow.Design_City_Rectangle.MouseLeftButtonDown += transparentImageChange;
            settingsWindow.Design_Art_Rectangle.MouseLeftButtonDown += transparentImageChange;
            settingsWindow.Design_Custom_Rectangle.MouseLeftButtonDown += transparentImageChange;

            //MainColor
            settingsWindow.Design_MainColor_Default_Rectangle.MouseLeftButtonDown += mainColorChange;
            settingsWindow.Design_MainColor_Own_Rectangle.MouseLeftButtonDown += mainColorChange;

            //Font
            settingsWindow.Design_Font_Default_Rectangle.MouseLeftButtonDown += fontChange;
            settingsWindow.Design_Font_Rectangle_Image.MouseLeftButtonDown += fontChange;

            //rounding
            settingsWindow.Design_Rounding_Default_Rectangle.MouseLeftButtonDown += roundingChange;
            settingsWindow.Design_Rounding_NoRounding_Rectangle.MouseLeftButtonDown += roundingChange;
            settingsWindow.Design_Rounding_Max_Rectangle.MouseLeftButtonDown += roundingChange;



            //Change all window Content

            //settingsWindow.DWC_Design_BackgroundImage_Path.MouseLeftButtonDown += changeBackgroundImage_Click;

            //settingsWindow.Font_Back.MouseLeftButtonDown += Font_Back_Click;
            //settingsWindow.Font_Next.MouseLeftButtonDown += Font_Next_Click;

            //settingsWindow.Cursor_Back.MouseLeftButtonDown += Cursor_Back_Click;
            //settingsWindow.Cursor_Next.MouseLeftButtonDown += Cursor_Next_Click;

            //settingsWindow.DWC_ThemeColor_Click.MouseLeftButtonDown += ChangeThemeColor_Click;
            //settingsWindow.DWC_ColorPicker_Click.MouseLeftButtonDown += DWC_Settings_ColorPicker_Button_Click;
        }

        #region Load on Initialization
        private void loadSettings()
        {

            //Theme
            if (ConfigManager.userTheme == "dark")
            {
                settingsWindow.Design_DarkDesign_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_DarkDesign_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else if (ConfigManager.userTheme == "light")
            {
                settingsWindow.Design_BrightDesign_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_BrightDesign_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else
            {
                settingsWindow.Design_TransparentDesign_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_TransparentDesign_Rectangle.Stroke = ProjectVariables.MainColor;
            }

            //MainColor
            if (ConfigManager.userMainColor == "255,20,102,183")
            {
                settingsWindow.Design_MainColor_Default_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_MainColor_Own_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else
            {
                settingsWindow.Design_MainColor_Own_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_MainColor_Own_Rectangle.Stroke = ProjectVariables.MainColor;
            }

            //Background Image Category
            if (ConfigManager.userBackgroundImageCategory == "Gaming")
            {
                settingsWindow.Design_Gaming_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Gaming_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else if (ConfigManager.userBackgroundImageCategory == "Landscape")
            {
                settingsWindow.Design_Landscape_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Landscape_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else if (ConfigManager.userBackgroundImageCategory == "City")
            {
                settingsWindow.Design_City_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_City_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else if (ConfigManager.userBackgroundImageCategory == "Art")
            {
                settingsWindow.Design_Art_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Art_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else
            {
                settingsWindow.Design_Custom_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Custom_Rectangle.Stroke = ProjectVariables.MainColor;
            }

            /*BackgroundImage
            if (ConfigManager.userBackgroundImage != "-")
            {
                //Console.WriteLine(1);
                settingsWindow.DWC_Design_BackgroundImage_Path.Content = ConfigManager.userBackgroundImage;
            }
            else
            {
                settingsWindow.DWC_Design_BackgroundImage_Path.Content = "-";
            }*/


            //Font
            if (ConfigManager.userFont == "default")
            {
                settingsWindow.Design_Font_Default_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Font_Default_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else
            {
                settingsWindow.Design_Font_Own_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Font_Rectangle_Image.Stroke = ProjectVariables.MainColor;
            }

            //Rounding
            if (ConfigManager.roundDesign == "minimal")
            {
                settingsWindow.Design_Rounding_Default_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Example_Default_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Default_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else if (ConfigManager.roundDesign == "none")
            {
                settingsWindow.Design_Rounding_NoRounding_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Default_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_NoRounding_Rectangle.Stroke = ProjectVariables.MainColor;
            }
            else
            {
                settingsWindow.Design_Rounding_Max_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Example_Max_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Max_Rectangle.Stroke = ProjectVariables.MainColor;
            }

            //Cursor
            //...

            //Shadow
            settingsWindow.Design_Shaddow_Toggle.isActive = ConfigManager.shadow;






            //System.Drawing.Color color = System.Drawing.Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B);
            //colorDlg.Color = color;
            ////Color
            //settingsWindow.DWC_ColorPicker_Click.Fill = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            ////Rounded Design
            //settingsWindow.Rounding_Click.RadiusX = int.Parse(ConfigManager.roundDesign);
            //settingsWindow.Rounding_Click.RadiusY = int.Parse(ConfigManager.roundDesign);

            //////ColorPicker Fill
            //settingsWindow.DWC_ColorPicker_Click.Fill = new SolidColorBrush(Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));

            ////Load Font
            //int i = 0;
            //foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            //{
            //    fontFamilie[i] = fontFamily;
            //    i++;
            //}

            ////Selected Font
            //for (int a = 0; a < fontFamilie.Length; a++)
            //{
            //    if (fontFamilie.ToString() == ConfigManager.userTheme)
            //    {
            //        fontFamilieSelected = a;
            //        settingsWindow.Font_Text.Content = fontFamilie[a];
            //        settingsWindow.Font_Text.FontFamily = fontFamilie[a];
            //    }
            //}

            ////Load Cursor
            //if (ConfigManager.userCursor != "-")
            //{
            //    settingsWindow.Cursor_Text.Content = ConfigManager.userCursor.Replace(MainWindow.Save_Path + @"Cursors\", "");
            //}
            //else
            //{
            //    settingsWindow.Cursor_Text.Content = "-";
            //}

            ////Load Shadow
            //if(ConfigManager.shadow == "true")
            //{
            //    settingsWindow.Shadow_Click.Effect = ProjectVariables.shadowEffect;
            //}

        }

        public static void saveSettings()
        {

            //Theme
            if (settingsWindow.Design_DarkDesign_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userTheme = "dark";
            }
            else if (settingsWindow.Design_BrightDesign_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userTheme = "light";
            }
            else if (settingsWindow.Design_TransparentDesign_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userTheme = "transparent";
            }

            //Theme Image
            if (settingsWindow.Design_Gaming_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userBackgroundImageCategory = "Gaming";
            }
            else if (settingsWindow.Design_Landscape_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userBackgroundImageCategory = "Landscape";
            }
            else if (settingsWindow.Design_City_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userBackgroundImageCategory = "City";
            }
            else if (settingsWindow.Design_Art_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userBackgroundImageCategory = "Art";
            }
            else if (settingsWindow.Design_Custom_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userBackgroundImageCategory = "Custom";
            }

            ////BackgroundImage
            //ConfigManager.Set("userBackgroundImage", settingsWindow.DWC_Design_BackgroundImage_Path.Content.ToString());

            //Main Color
            if (settingsWindow.Design_MainColor_Default_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userMainColor = "255,20,102,183";
            }
            else if (settingsWindow.Design_MainColor_Own_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userMainColor = "NOTSET";
            }

            ////Color
            //System.Drawing.Color color = colorDlg.Color;
            //ConfigManager.R = color.R;
            //ConfigManager.G = color.G;
            //ConfigManager.B = color.B;
            //ConfigManager.A = color.A;

            //ConfigManager.Set("userMainColor", "255," + ConfigManager.R + "," + ConfigManager.G + "," + ConfigManager.B);

            //Font
            if (settingsWindow.Design_Font_Default_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userFont = "default";
            }
            else if (settingsWindow.Design_Font_Rectangle_Image.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.userFont = "NOTSET";
            }

            //Cursor
            //...

            //Rounding
            if (settingsWindow.Design_Rounding_Default_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.roundDesign = "min";
            }
            else if (settingsWindow.Design_Rounding_NoRounding_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.roundDesign = "none";
            }
            else if (settingsWindow.Design_Rounding_Max_Rectangle.Stroke == ProjectVariables.MainColor)
            {
                ConfigManager.roundDesign = "max";
            }

            //Shadow
            ConfigManager.shadow = settingsWindow.Design_Shaddow_Toggle.isActive;

        }

        private void loadDB()
        {
            settingsWindow.Design_OwnBackgrouond.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_OwnBackgrouond");
            settingsWindow.Design_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Description");
            settingsWindow.Design_DarkDesign_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_DarkDesign_Heading");
            settingsWindow.Design_DarkDesign_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_DarkDesign_Content");
            settingsWindow.Design_BrightDesign_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_BrightDesign_Heading");
            settingsWindow.Design_BrightDesign_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_BrightDesign_Content");
            settingsWindow.Design_TransparentDesign_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesign_Heading");
            settingsWindow.Design_TransparentDesign_Content.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesign_Content");
            settingsWindow.Design_TransparentDesignImage_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_Heading");
            settingsWindow.Design_TransparentDesignImage_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_Description");
            settingsWindow.Design_RatingBackground.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_RatingBackground");
            settingsWindow.Design_OwnBackgrouond.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_OwnBackgrouond");
            settingsWindow.Design_TransparentDesignImage_Gaming.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_Gaming");
            settingsWindow.Design_TransparentDesignImage_Landscape.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_Landscape");
            settingsWindow.Design_TransparentDesignImage_City.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_City");
            settingsWindow.Design_TransparentDesignImage_Art.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_Art");
            settingsWindow.Design_TransparentDesignImage_Custom.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_TransparentDesignImage_Custom");

            settingsWindow.Design_Color_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Color_Heading");
            settingsWindow.Design_Color_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Color_Description");
            settingsWindow.Design_Color_Default_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Color_Default_Heading");
            settingsWindow.Design_Color_Default_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Color_Default_Description");
            settingsWindow.Design_Color_Custom_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Color_Custom_Heading");
            settingsWindow.Design_Color_Custom_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Color_Custom_Description");
            settingsWindow.Design_Font_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Font_Heading");
            settingsWindow.Design_Font_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Font_Description");
            settingsWindow.Design_Font_Default_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Font_Default_Heading");
            settingsWindow.Design_Font_Custom_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Font_Custom_Heading");
            settingsWindow.Design_Font_Custom_Description.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Font_Custom_Description");
            settingsWindow.Design_Rounding_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Rounding_Heading");
            settingsWindow.Design_Rounding_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Rounding_Description");
            settingsWindow.Design_Rounding_MinimalRounding.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Rounding_MinimalRounding");
            settingsWindow.Design_Rounding_NoRounding.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Rounding_NoRounding");
            settingsWindow.Design_Rounding_MaximalRounding.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Rounding_MaximalRounding");
            settingsWindow.Design_Shaddow_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Shaddow_Heading");
            settingsWindow.Design_Shaddow_Description.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueSettings("Design_Shaddow_Description");
        }

        private void loadImages()
        {
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_DarkDesign_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_BrightDesign_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_TransparentDesign_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Gaming_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Landscape_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_City_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Art_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Custom_Image);

            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Transparent_LargeImage);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_MainColor_Default_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_MainColor_Own_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Font_Default_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Font_Own_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Rounding_Default_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Rounding_NoRounding_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Rounding_Max_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Rounding_Example_Default_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Transparent_LargeImage);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Rounding_Example_NoRounding_Image);
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", settingsWindow.Design_Rounding_Example_Max_Image);
        }

        private void loadColors()
        {
            settingsWindow.Design.Background = ProjectVariables.Theme_LighterDark;

            settingsWindow.Design_DarkDesign_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_BrightDesign_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_TransparentDesign_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Gaming_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Landscape_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_City_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Art_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Custom_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.Design_Spacer_1.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Spacer_2.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Spacer_3.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Spacer_4.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Spacer_5.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_MainColor_Default_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_MainColor_Own_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;

            settingsWindow.Design_Font_Default_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Font_Rectangle_Image.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Rounding_Default_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Rounding_NoRounding_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Rounding_Max_Rectangle.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Rounding_Example_Default.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Rounding_Example_Default.Fill = ProjectVariables.Theme_DarkRectangleAccent;
            settingsWindow.Design_Rounding_Example_Max.Fill = ProjectVariables.Theme_DarkRectangleAccent;

        }
        #endregion

        private void designChange(object sender, MouseButtonEventArgs e)
        {

            Rectangle rectangle = sender as Rectangle;

            settingsWindow.Design_DarkDesign_Rectangle.Stroke = null;
            settingsWindow.Design_BrightDesign_Rectangle.Stroke = null;
            settingsWindow.Design_TransparentDesign_Rectangle.Stroke = null;

            settingsWindow.Design_DarkDesign_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_BrightDesign_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_TransparentDesign_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "Design_DarkDesign_Rectangle")
            {
                settingsWindow.Design_DarkDesign_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_DarkDesign_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_BrightDesign_Rectangle")
            {
                settingsWindow.Design_BrightDesign_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_BrightDesign_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_TransparentDesign_Rectangle")
            {
                settingsWindow.Design_TransparentDesign_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_TransparentDesign_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void transparentImageChange(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;

            settingsWindow.Design_Gaming_Rectangle.Stroke = null;
            settingsWindow.Design_Landscape_Rectangle.Stroke = null;
            settingsWindow.Design_City_Rectangle.Stroke = null;
            settingsWindow.Design_Art_Rectangle.Stroke = null;
            settingsWindow.Design_Custom_Rectangle.Stroke = null;

            settingsWindow.Design_Gaming_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Landscape_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_City_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Art_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Custom_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "Design_Gaming_Rectangle")
            {
                settingsWindow.Design_Gaming_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Gaming_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_Landscape_Rectangle")
            {
                settingsWindow.Design_Landscape_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Landscape_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_City_Rectangle")
            {
                settingsWindow.Design_City_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_City_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_Art_Rectangle")
            {
                settingsWindow.Design_Art_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Art_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_Custom_Rectangle")
            {
                settingsWindow.Design_Custom_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Custom_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void mainColorChange(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;

            settingsWindow.Design_MainColor_Default_Rectangle.Stroke = null;
            settingsWindow.Design_MainColor_Own_Rectangle.Stroke = null;

            settingsWindow.Design_MainColor_Default_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_MainColor_Own_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "Design_MainColor_Default_Rectangle")
            {
                settingsWindow.Design_MainColor_Default_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_MainColor_Default_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_MainColor_Own_Rectangle")
            {
                settingsWindow.Design_MainColor_Own_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_MainColor_Own_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void fontChange(object sender, MouseButtonEventArgs e)
        {

            Rectangle rectangle = sender as Rectangle;

            settingsWindow.Design_Font_Default_Rectangle.Stroke = null;
            settingsWindow.Design_Font_Rectangle_Image.Stroke = null;

            settingsWindow.Design_Font_Default_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Font_Own_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "Design_Font_Default_Rectangle")
            {
                settingsWindow.Design_Font_Default_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Font_Default_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_Font_Rectangle_Image")
            {
                settingsWindow.Design_Font_Rectangle_Image.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Font_Own_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void roundingChange(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;

            settingsWindow.Design_Rounding_Default_Rectangle.Stroke = null;
            settingsWindow.Design_Rounding_NoRounding_Rectangle.Stroke = null;
            settingsWindow.Design_Rounding_Max_Rectangle.Stroke = null;

            settingsWindow.Design_Rounding_Default_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Rounding_NoRounding_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Rounding_Max_Image.Visibility = System.Windows.Visibility.Hidden;

            settingsWindow.Design_Rounding_Example_Default_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Rounding_Example_NoRounding_Image.Visibility = System.Windows.Visibility.Hidden;
            settingsWindow.Design_Rounding_Example_Max_Image.Visibility = System.Windows.Visibility.Hidden;

            if (rectangle.Name == "Design_Rounding_Default_Rectangle")
            {
                settingsWindow.Design_Rounding_Default_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Rounding_Default_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Example_Default_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_Rounding_NoRounding_Rectangle")
            {
                settingsWindow.Design_Rounding_NoRounding_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Rounding_NoRounding_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Example_NoRounding_Image.Visibility = System.Windows.Visibility.Visible;
            }
            else if (rectangle.Name == "Design_Rounding_Max_Rectangle")
            {
                settingsWindow.Design_Rounding_Max_Rectangle.Stroke = ProjectVariables.MainColor;
                settingsWindow.Design_Rounding_Max_Image.Visibility = System.Windows.Visibility.Visible;
                settingsWindow.Design_Rounding_Example_Max_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

        //private void changeBackgroundImage_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (!Directory.Exists(MainWindow.Save_Path + "Background_Images"))
        //        Directory.CreateDirectory(MainWindow.Save_Path + "Background_Images");

        //    OpenFileDialog opnFileDlg = new OpenFileDialog();
        //    opnFileDlg.Multiselect = true;
        //    opnFileDlg.Filter = "(png,jpg,gif)|*.png;*.jpg;*.gif;";
        //    opnFileDlg.ShowDialog();

        //    if (opnFileDlg != null)
        //    {

        //        String[] pictureFullPath = opnFileDlg.FileName.Split('\\');//Whole Path + File Name + File Ending
        //        String picturePath = "";//path
        //        String pictureName = pictureFullPath[pictureFullPath.Length - 1].Replace(".jpg", "").Replace(".png", "").Replace(".gif", "");//Image Name
        //        String pictureEnding = pictureFullPath[pictureFullPath.Length - 1].Split('.')[1];//File Ending  

        //        if (!File.Exists(MainWindow.Save_Path + @"Background_Images\" + pictureName + "." + pictureEnding)){
        //            File.Copy(opnFileDlg.FileName, MainWindow.Save_Path + @"Background_Images\" + pictureName + "." + pictureEnding);
        //        }
        //        settingsWindow.DWC_Design_BackgroundImage_Path.Content = pictureName + "." + pictureEnding;
        //    }

        //}

        //#region ColorPicker
        ///// <summary>
        ///// Open Color Picker selection
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DWC_Settings_ColorPicker_Button_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{

        //    colorDlg.ShowDialog();

        //    colorDlg.AllowFullOpen = true;
        //    colorDlg.AnyColor = true;
        //    colorDlg.SolidColorOnly = false;

        //    System.Drawing.Color color = colorDlg.Color;

        //    byte R = color.R;
        //    byte G = color.G;
        //    byte B = color.B;
        //    byte A = color.A;

        //    String colllor = colorDlg.Color.ToArgb().ToString();

        //    var wpfColor = Color.FromArgb(A, R, G, B);

        //    settingsWindow.DWC_ColorPicker_Click.Fill = new SolidColorBrush(Color.FromArgb(A, R, G, B));

        //}
        //#endregion


        //#region Font
        //private void Font_Next_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (fontFamilieSelected < fontFamilie.Length)
        //    {
        //        fontFamilieSelected++;
        //        settingsWindow.Font_Text.FontFamily = fontFamilie[fontFamilieSelected];
        //        settingsWindow.Font_Text.Content = fontFamilie[fontFamilieSelected];
        //    }
        //}

        //private void Font_Back_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (fontFamilieSelected > 0)
        //    {
        //        fontFamilieSelected--;
        //        settingsWindow.Font_Text.FontFamily = fontFamilie[fontFamilieSelected];
        //        settingsWindow.Font_Text.Content = fontFamilie[fontFamilieSelected];
        //    }
        //}
        //#endregion

        //#region Cursor
        //private void Cursor_Next_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (files.Length - 1 > cursorSelected)
        //    {
        //        cursorSelected++;
        //        settingsWindow.Cursor_Text.Content = files[cursorSelected].Replace(WindowOverlayManager.Save_Path + @"Cursors\", "");
        //    }
        //}

        //private void Cursor_Back_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (cursorSelected > 0)
        //    {
        //        cursorSelected--;
        //        settingsWindow.Cursor_Text.Content = files[cursorSelected].Replace(WindowOverlayManager.Save_Path + @"Cursors\", "");
        //    }
        //}
        //#endregion

    }
}
