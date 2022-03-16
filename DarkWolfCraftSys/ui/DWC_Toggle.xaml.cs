using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{

    public partial class DWC_Toggle : UserControl
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private Brush hashColor;

        public DWC_Toggle()
        {
            InitializeComponent();
            this.Toggle.Margin = new Thickness(2, 1, 0, 0);
            hashColor = this.Toggle.Fill;//hash Color

            this.Slider_Grid.MouseLeftButtonDown += SliderClick_Event;

        }

        private void SliderClick_Event(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.isActive)
            {
                this.Toggle.Margin = new Thickness(45, 1, 0, 0);
                this.Toggle.Fill = ToggleMarkerColorOff;
                this.isActive = false;
            }
            else
            {
                this.Toggle.Margin = new Thickness(2, 1, 0, 0);
                this.Toggle.Fill = hashColor;
                this.isActive = true;
            }
        }

        public SolidColorBrush ToggleBackGround { get; set; }
        public double ToggleRounding { get; set; }
        public double BorderRoundung { get; set; }
        public SolidColorBrush ToggleBorderBrush { get; set; }
        public SolidColorBrush ToggleMarkerColor { get; set; }
        public SolidColorBrush ToggleMarkerColorOff { get; set; }
        public bool isActive { get; set; }

    }
}
