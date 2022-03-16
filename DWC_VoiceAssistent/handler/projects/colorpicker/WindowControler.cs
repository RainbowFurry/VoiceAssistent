using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.system;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DWC_VoiceAssistent.handler.projects.colorpicker
{
    internal class WindowControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //TODO
        //UPDATE: Eigene Color Templates anlegbar - eigene config
        //rounding and color desighn
        //Dropdown with all Windows Default Colors... - plus event wenn selected dann pass alle werte an.
        //https://www.codeproject.com/Articles/36848/WPF-Image-Pixel-Color-Picker-Element

        //Das Übergeben des Wertes bevor der Wert gelöscht wird.
        //in settings dann eigenen ColorPicker verwenden... -> ist es möglcih den so in die Sys zu bekommen?

        private Slider R = colorPickerWindow.RGB_Slider_R;
        private Slider G = colorPickerWindow.RGB_Slider_G;
        private Slider B = colorPickerWindow.RGB_Slider_B;
        private Slider A = colorPickerWindow.RGB_Slider_A;

        private static ColorPicker colorPickerWindow = ColorPicker.colorPickerWindow;

        public WindowControler()
        {
            setGridColor();
            WindowOverlayManager.updateAllWindowContent(colorPickerWindow.ColorPickerContentGrid);

            loadDB();
            loadDefaultValues();
            loadWindowOptions();
            ProjectVariables.LoadSvgImage("src/white/Close_White.svg", ColorPicker.colorPickerWindow.Window_Close);
            ProjectVariables.LoadSvgImage("src/white/WindowState_White.svg", ColorPicker.colorPickerWindow.Window_State);
            ProjectVariables.LoadSvgImage("src/white/Minimize_White.svg", ColorPicker.colorPickerWindow.Window_Minimize);
            //fillDropDownColors();

            colorPickerWindow.RGB_Slider_R.ValueChanged += ColorSlider_ValueChanged;
            colorPickerWindow.RGB_Slider_G.ValueChanged += ColorSlider_ValueChanged;
            colorPickerWindow.RGB_Slider_B.ValueChanged += ColorSlider_ValueChanged;
            colorPickerWindow.RGB_Slider_A.ValueChanged += ColorSlider_ValueChanged;

            //Window Controle
            colorPickerWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            colorPickerWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            colorPickerWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

            //Single Select Color Click Event
            for (int i = 0; i < colorPickerWindow.Defined_Colors_Grid.Children.Count; i++)
            {
                Rectangle rectangle = colorPickerWindow.Defined_Colors_Grid.Children[i] as Rectangle;
                rectangle.MouseLeftButtonDown += getClickedColor;
            }

            //Register Button Click
            colorPickerWindow.Accept_Button_Grid.MouseLeftButtonDown += AcceptButton_Click;
            colorPickerWindow.Cancel_Button_Grid.MouseLeftButtonDown += CancelButtton_Click;

        }

        private void loadDB()
        {
            colorPickerWindow.Accept_Button_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueColorPicker("Accept_Button_Text");
            colorPickerWindow.Cancel_Button_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueColorPicker("Cancel_Button_Text");
        }

        private void loadWindowOptions()
        {
            colorPickerWindow.ColorSelection.RadiusX = 0;
            colorPickerWindow.ColorSelection.RadiusY = 0;
            colorPickerWindow.ShownSelectedColor.RadiusX = 0;
            colorPickerWindow.ShownSelectedColor.RadiusY = 0;
        }

        private void fillDropDownColors()
        {

            Type colorType = typeof(System.Drawing.Color);

            PropertyInfo[] propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo propInfo in propInfos)
            {
                //Console.WriteLine(propInfo.Name);

                Grid grid = new Grid();

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 16;
                rectangle.Height = 16;
                //rectangle.Fill = propInfo;

                Label label = new Label();
                label.Content = propInfo.Name;

                grid.Children.Add(rectangle);
                grid.Children.Add(label);

                colorPickerWindow.AllWindowsColors.Items.Add(grid);

            }

        }

        private void loadDefaultValues()
        {
            colorPickerWindow.RGB_TextBox_R.Text = Math.Round(R.Value, 0).ToString();
            colorPickerWindow.RGB_TextBox_G.Text = Math.Round(G.Value, 0).ToString();
            colorPickerWindow.RGB_TextBox_B.Text = Math.Round(B.Value, 0).ToString();
            colorPickerWindow.RGB_TextBox_A.Text = Math.Round(A.Value, 0).ToString();

            colorPickerWindow.RGB_TextBox_Hexa.Text = colorPickerWindow.ShownSelectedColor.Fill.ToString();
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            Slider slider = sender as Slider;
            //Console.WriteLine(slider.Name);

            if (slider.Name == "RGB_Slider_R")
            {
                colorPickerWindow.RGB_TextBox_R.Text = Math.Round(slider.Value, 0).ToString();
            }
            else if (slider.Name == "RGB_Slider_G")
            {
                colorPickerWindow.RGB_TextBox_G.Text = Math.Round(slider.Value, 0).ToString();
            }
            else if (slider.Name == "RGB_Slider_B")
            {
                colorPickerWindow.RGB_TextBox_B.Text = Math.Round(slider.Value, 0).ToString();
            }
            else if (slider.Name == "RGB_Slider_A")
            {
                colorPickerWindow.RGB_TextBox_A.Text = Math.Round(slider.Value, 0).ToString();
            }

            //Show Color Change
            Color color = Color.FromArgb((byte)A.Value, (byte)R.Value, (byte)G.Value, (byte)B.Value);
            colorPickerWindow.ShownSelectedColor.Fill = new SolidColorBrush(color);

            //Show Hexa Code
            colorPickerWindow.RGB_TextBox_Hexa.Text = colorPickerWindow.ShownSelectedColor.Fill.ToString();

        }

        private void getClickedColor(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            Brush brush = rectangle.Fill;
            Color color = (brush as SolidColorBrush).Color;

            //Slider
            colorPickerWindow.RGB_Slider_R.Value = color.R;
            colorPickerWindow.RGB_Slider_G.Value = color.G;
            colorPickerWindow.RGB_Slider_B.Value = color.B;
            colorPickerWindow.RGB_Slider_A.Value = color.A;

            //TextBox
            colorPickerWindow.RGB_TextBox_R.Text = Math.Round(R.Value, 0).ToString();
            colorPickerWindow.RGB_TextBox_G.Text = Math.Round(G.Value, 0).ToString();
            colorPickerWindow.RGB_TextBox_B.Text = Math.Round(B.Value, 0).ToString();
            colorPickerWindow.RGB_TextBox_A.Text = Math.Round(A.Value, 0).ToString();

            //Color Image and Hexa
            colorPickerWindow.ShownSelectedColor.Fill = brush;
            colorPickerWindow.RGB_TextBox_Hexa.Text = colorPickerWindow.ShownSelectedColor.Fill.ToString();

        }

        #region Buttons
        private void AcceptButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //
        }

        private void CancelButtton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            colorPickerWindow.Close();
        }
        #endregion

        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            colorPickerWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (colorPickerWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                colorPickerWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                colorPickerWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            colorPickerWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

        private static void setGridColor()
        {

            colorPickerWindow.ColorPickerContentGrid.Background = ProjectVariables.Theme_MiddleDark;

            colorPickerWindow.RGB_Rectangle_R.Fill = ProjectVariables.Theme_LighterDark;
            colorPickerWindow.RGB_Rectangle_G.Fill = ProjectVariables.Theme_LighterDark;
            colorPickerWindow.RGB_Rectangle_B.Fill = ProjectVariables.Theme_LighterDark;
            colorPickerWindow.RGB_Rectangle_A.Fill = ProjectVariables.Theme_LighterDark;
            colorPickerWindow.RGB_Rectangle_Hexa.Fill = ProjectVariables.Theme_LighterDark;

            colorPickerWindow.Cancel_Button_Rectangle.Fill = ProjectVariables.Theme_LighterDark;
            colorPickerWindow.Accept_Button_Rectangle.Fill = ProjectVariables.Theme_LighterDark;

        }

    }
}
