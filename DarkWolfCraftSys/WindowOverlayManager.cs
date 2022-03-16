using DarkWolfCraftSys.ui;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DarkWolfCraftSys
{
    public class WindowOverlayManager
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static String Save_Path;

        /*Die GRID FARBEN BEIM AUFRUF DES FENSTERS SETZEN AUS SYS WindowOverlayManager sonst geht es ned
         * 
         DWC_Ignore = Für das main Window gedacht um das Grid zu ignorieren
         DWC_IgnoreRounding = Ignoriere rundungen
         DWC_ColorIgnore = Ignoreire Farben
         DWC_ChangeImageColor = ändere die Bildfarbe mit (sonst zu aufwendig...)
         DWC_TransparencyIgnore = Ignoriere transparenz 
             */

        /// <summary>
        /// Update MainColor and Theme in Grid and Grid-Children
        /// </summary>
        /// <param name="grid"></param>
        [STAThread]
        public static void updateAllWindowContent(Grid grid)
        {

            //Background Image
            if (grid.Name == "BackgroundImage")
            {
                changeBackgroundImage(grid);
            }

            for (int i = 0; i < grid.Children.Count; i++)
            {
                //Console.WriteLine(grid.Children[i].GetType());
                #region UI Elements
                //Grid
                if (grid.Children[i].ToString().Contains("Grid") && !grid.Children[i].ToString().Contains("GridSplitter"))
                {
                    if (grid.Uid != "DWC_Ignore")
                        overwriteGrid((Grid)grid.Children[i]);
                }

                if (grid.Children[i].ToString().Contains("TextBox"))
                {
                    if (grid.Uid != "DWC_Ignore")
                        overwriteTextBox((TextBox)grid.Children[i]);
                }

                //Label
                if (grid.Children[i].ToString().Contains("Label"))
                {
                    overwriteLabel((Label)grid.Children[i]);
                }

                //ScrollViewer
                if (grid.Children[i].ToString().Contains("ScrollViewer"))
                {
                    ScrollViewer scrollViewer = (ScrollViewer)grid.Children[i];
                    StackPanel stackPanel = (StackPanel)scrollViewer.Content;
                    overwriteStackPanel(stackPanel);
                }

                //Rectangle
                if (grid.Children[i].ToString().Contains("Rectangle"))
                {
                    overwriteRectangle(grid.Children[i] as System.Windows.Shapes.Rectangle);
                }

                //Border
                if (grid.Children[i].ToString().Contains("Border"))
                {
                    overwriteBorder(grid.Children[i] as Border);
                }

                if (grid.Children[i].ToString().Contains("Image"))
                {
                    overwriteImage(grid.Children[i] as Image);
                }
                #endregion

                #region Own UI Elements
                //DWC_CheckBox
                if (grid.Children[i].ToString().Contains("DWC_CheckBox"))
                {
                    overwriteDWC_CheckBox((DWC_CheckBox)grid.Children[i]);
                }

                //DWC_DropDownMenu
                if (grid.Children[i].ToString().Contains("DWC_DropDownMenu"))
                {
                    overwriteDWC_DropDownMenu((DWC_DropdownMenu)grid.Children[i]);
                }

                //DWC_OnlineStatus
                if (grid.Children[i].ToString().Contains("DWC_OnlineStatus"))
                {
                    overwriteDWC_OnlineStatus((DWC_OnlineStatus)grid.Children[i]);
                }

                //DWC_Slider
                if (grid.Children[i].ToString().Contains("DWC_Slider"))
                {
                    overwriteDWC_Slider((DWC_Slider)grid.Children[i]);
                }

                //DWC_Toggle
                if (grid.Children[i].ToString().Contains("DWC_Toggle"))
                {
                    overwriteDWC_Toggle((DWC_Toggle)grid.Children[i]);
                }

                //DWC_Widget
                if (grid.Children[i].ToString().Contains("DWC_Widget"))
                {
                    overwriteDWC_Widget((DWC_Widget)grid.Children[i]);
                }
                #endregion

            }

            //LogFileManager.createLogEntrence("All Window Content has successfully been updated!");

        }

        public static void updateWindowCursor(Window window)
        {
            Console.WriteLine(Save_Path + @"Cursors\" + ConfigManager.userCursor);
            if (ConfigManager.userCursor != "-")
            {
                Cursor c = new Cursor(Save_Path + @"Cursors\" + ConfigManager.userCursor);
                if (c != null)
                    window.Cursor = c;
            }
        }

        #region Overwrite UI Content
        private static void overwriteLabel(Label label)
        {
            if (!label.Uid.Contains("IgnoreShadow"))
                if (ConfigManager.shadow)
                    label.Effect = ProjectVariables.textShadowEffect;

            //label.FontFamily = customFont;
            if (!label.Uid.Contains("DWC_ColorIgnore") && !label.Uid.Contains("DWC_Ignore"))
            {
                //Label Theme Color
                if (ConfigManager.userTheme == "dark")
                {
                    if (label.Foreground.ToString() == "#00000000")
                        label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
                }
                else if (ConfigManager.userTheme == "light")
                {
                    if (label.Foreground.ToString() == "#FFFFFFFF")
                        label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                }
                else
                {
                    // 
                }

                //Font
                if(ConfigManager.userFont != null)
                    label.FontFamily = new FontFamily(ConfigManager.userFont);

                //MainColor
                if (label.Foreground.ToString() == ProjectVariables.ThemeMainColor)
                    label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            }
        }

        /// <summary>
        /// To Overwrite the Grid you need to set the Grid Color in the Window Call and
        /// Set the Color from the DarkWolfCraftSys WindowOverlayManager
        /// </summary>
        /// <param name="grid"></param>
        private static void overwriteGrid(Grid grid)
        {

            if (!grid.Uid.Contains("IgnoreShadow"))
                if (ConfigManager.shadow)
                    grid.Effect = ProjectVariables.textShadowEffect;

            if (!grid.Uid.Contains("DWC_ColorIgnore") && !grid.Uid.Contains("DWC_Ignore"))
            {
                //grid.Background = Theme_DarkestDark;
                if (ConfigManager.userTheme == "dark")
                {
                    if (grid.Background == ProjectVariables.Theme_DarkestLight || grid.Background == ProjectVariables.Theme_DarkestDarkTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_DarkestDark;
                    }
                    if (grid.Background == ProjectVariables.Theme_MiddleLight || grid.Background == ProjectVariables.Theme_MiddleDarkTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_MiddleDark;
                    }
                    if (grid.Background == ProjectVariables.Theme_LightBackground || grid.Background == ProjectVariables.Theme_DarkBackgroundTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_DarkBackground;
                    }
                    if (grid.Background == ProjectVariables.Theme_LighterLight || grid.Background == ProjectVariables.Theme_LighterDarkTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_LighterDark;
                    }
                }
                else if (ConfigManager.userTheme == "light")
                {

                    //Console.WriteLine(grid.Background);
                    //Console.WriteLine(Theme_DarkestDark);
                    //Console.WriteLine(ConfigManager.user_Theme);

                    if (grid.Background == ProjectVariables.Theme_DarkestDark || grid.Background == ProjectVariables.Theme_DarkestDarkTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_DarkestLight;
                    }
                    if (grid.Background == ProjectVariables.Theme_MiddleDark || grid.Background == ProjectVariables.Theme_MiddleDarkTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_MiddleLight;
                    }
                    if (grid.Background == ProjectVariables.Theme_DarkBackground || grid.Background == ProjectVariables.Theme_DarkBackgroundTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_LightBackground;
                    }
                    if (grid.Background == ProjectVariables.Theme_LighterDark || grid.Background == ProjectVariables.Theme_LighterDarkTransparent)
                    {
                        grid.Background = ProjectVariables.Theme_LighterLight;
                    }

                }
                else
                {
                    if (!grid.Uid.Contains("DWC_TransparencyIgnore"))
                    {
                        if (grid.Background == ProjectVariables.Theme_DarkestDark || grid.Background == ProjectVariables.Theme_LighterLight)
                        {
                            grid.Background = ProjectVariables.Theme_DarkestDarkTransparent;
                        }
                        if (grid.Background == ProjectVariables.Theme_MiddleDark || grid.Background == ProjectVariables.Theme_MiddleLight)
                        {
                            grid.Background = ProjectVariables.Theme_MiddleDarkTransparent;
                        }
                        if (grid.Background == ProjectVariables.Theme_DarkBackground || grid.Background == ProjectVariables.Theme_LightBackground)
                        {
                            grid.Background = ProjectVariables.Theme_DarkBackgroundTransparent;
                        }
                        if (grid.Background == ProjectVariables.Theme_LighterDark || grid.Background == ProjectVariables.Theme_LighterLight)
                        {
                            grid.Background = ProjectVariables.Theme_LighterDarkTransparent;
                        }
                    }
                }
                updateAllWindowContent(grid);
            }

        }

        private static void overwriteTextBox(TextBox textBox)
        {
            if (!textBox.Uid.Contains("IgnoreShadow"))
                if (ConfigManager.shadow)
                    textBox.Effect = ProjectVariables.textShadowEffect;

            textBox.SelectionBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
        }

        private static void overwriteRectangle(System.Windows.Shapes.Rectangle rectangle)
        {
            if(!rectangle.Uid.Contains("IgnoreShadow"))
                if (ConfigManager.shadow)
                    rectangle.Effect = ProjectVariables.textShadowEffect;

            if (!rectangle.Uid.Contains("DWC_ColorIgnore"))
            {

                if (ConfigManager.userTheme == "dark")
                {

                    if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF6E767E" || rectangle.Fill != null && rectangle.Fill.ToString() == "#661C1E20")
                    {
                        rectangle.Fill = ProjectVariables.Theme_DarkestDark;
                    }
                    else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF2B2B2B" || rectangle.Fill != null && rectangle.Fill.ToString() == "#662B2B2B")
                    {
                        rectangle.Fill = ProjectVariables.Theme_MiddleDark;
                    }
                    else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF313136" || rectangle.Fill != null && rectangle.Fill.ToString() == "#66313136")
                    {
                        rectangle.Fill = ProjectVariables.Theme_DarkBackground;
                    }
                    else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF37363F" || rectangle.Fill != null && rectangle.Fill.ToString() == "#6636363F")
                    {
                        rectangle.Fill = ProjectVariables.Theme_LighterDark;
                    }
                }
                else if (ConfigManager.userTheme == "light")
                {

                    if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF1C1E20" || rectangle.Fill != null && rectangle.Fill.ToString() == "#661C1E20")
                    {
                        rectangle.Fill = ProjectVariables.Theme_DarkestLight;
                    }
                    else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF2B2B2B" || rectangle.Fill != null && rectangle.Fill.ToString() == "#662B2B2B")
                    {
                        rectangle.Fill = ProjectVariables.Theme_MiddleLight;
                    }
                    else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF313136" || rectangle.Fill != null && rectangle.Fill.ToString() == "#66313136")
                    {
                        rectangle.Fill = ProjectVariables.Theme_LightBackground;
                    }
                    else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF37363F" || rectangle.Fill != null && rectangle.Fill.ToString() == "#6636363F")
                    {
                        rectangle.Fill = ProjectVariables.Theme_LighterLight;
                    }

                }
                else
                {
                    if (!rectangle.Uid.Contains("DWC_TransparencyIgnore"))
                    {
                        if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF1C1E20" || rectangle.Fill != null && rectangle.Fill.ToString() == "#FF6E767E")
                        {
                            rectangle.Fill = ProjectVariables.Theme_DarkestDarkTransparent;
                        }
                        else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF2B2B2B" || rectangle.Fill != null && rectangle.Fill.ToString() == "#FF2B2B2B")
                        {
                            rectangle.Fill = ProjectVariables.Theme_MiddleDarkTransparent;
                        }
                        else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF313136" || rectangle.Fill != null && rectangle.Fill.ToString() == "#FF313136")
                        {
                            rectangle.Fill = ProjectVariables.Theme_DarkBackgroundTransparent;
                        }
                        else if (rectangle.Fill != null && rectangle.Fill.ToString() == "#FF37363F" || rectangle.Fill != null && rectangle.Fill.ToString() == "#FF37363F")
                        {
                            rectangle.Fill = ProjectVariables.Theme_DarkestDarkTransparent;
                        }
                    }
                }
            }

            //Rounding
            if (!rectangle.Uid.Contains("DWC_IgnoreRounding"))
            {
                double rounding = 0;

                if (ConfigManager.roundDesign == "min")
                    rounding = 15.0;

                if (ConfigManager.roundDesign == "max")
                    rounding = 45.0;

                if (ConfigManager.roundDesign == "none")
                    rounding = 0;

                rectangle.RadiusX = rounding;//0, 15, 45
                rectangle.RadiusY = rounding;//ConfigManager.desighnShape
            }

        }

        private static void overwriteStackPanel(StackPanel stackPanel)
        {
            for (int a = 0; a < stackPanel.Children.Count; a++)
            {
                if (stackPanel.Children[a].ToString().Contains("Grid") && !stackPanel.Children[a].ToString().Contains("GridSplitter"))
                {
                    Grid grid2 = (Grid)stackPanel.Children[a];
                    updateAllWindowContent(grid2);
                }
            }
        }

        private static void overwriteScrollPannel()
        {

        }

        private static void overwriteBorder(Border border)
        {
            if (border.BorderBrush.ToString() == ProjectVariables.ThemeMainColor)
                border.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, ConfigManager.R, ConfigManager.G, ConfigManager.B));
        }

        private static void overwriteImage(Image image)
        {
            if (image.Uid.Contains("DWC_ChangeImageColor"))
            {
                //wenn image color maincolor dann replace main color
                //wenn weiß dann schwarz und wenn schwarz dann weiß

                //image.Source = ImageColorEditor.changeImageColor(image);
            }

        }
        #endregion

        #region Overwrite own UI Content
        //DWC_CheckBox
        private static void overwriteDWC_CheckBox(DWC_CheckBox dwc_CheckBox)
        {

        }

        //DWC_DropDownMenu
        private static void overwriteDWC_DropDownMenu(DWC_DropdownMenu dwc_DropdownMenu)
        {

        }

        //DWC_OnlineStatus
        private static void overwriteDWC_OnlineStatus(DWC_OnlineStatus dwc_OnlineStatus)
        {

        }

        //DWC_Slider
        private static void overwriteDWC_Slider(DWC_Slider dwc_Slider)
        {

        }

        //DWC_Toggle
        private static void overwriteDWC_Toggle(DWC_Toggle dwc_Toggle)
        {

        }

        //DWC_Widget
        private static void overwriteDWC_Widget(DWC_Widget dwc_Widget)
        {

        }
        #endregion

        private static void changeBackgroundImage(Grid grid)
        {

            if (!grid.Uid.Contains("IgnoreBackgroundImage"))
            {
                if (ConfigManager.userBackgroundImage != "-" && ConfigManager.userBackgroundImage != null)
                {
                    var imgBrush = new ImageBrush();
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(Save_Path + @"Background_Images\" + ConfigManager.userBackgroundImage);
                    bi3.EndInit();
                    imgBrush.ImageSource = bi3;
                    if (ConfigManager.userBackgroundImage.Contains(".gif"))
                    {
                        //ImageBehavior.SetAnimatedSource(grid.Background, bi3);
                    }
                    else
                    {
                        grid.Background = imgBrush;
                    }
                }
            }

        }

    }
}
