using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{
    public partial class DWC_CheckBox : UserControl
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public DWC_CheckBox()
        {
            InitializeComponent();
            this.isChecked = true;
            this.Checked_Rectangle.Fill = CheckBoxFill;
            ProjectVariables.LoadSvgImage("src/own/Checked.svg", this.Checked_Image);

            this.DWC_CheckBox_Grid.MouseLeftButtonDown += CheckCheckBox;
        }

        public bool isChecked { get; set; }
        public double Rounding { get; set; }
        public SolidColorBrush CheckBoxBorderFill { get; set; }
        public SolidColorBrush CheckBoxFill { get; set; }

        private void CheckCheckBox(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (this.Checked_Image.Visibility == System.Windows.Visibility.Visible)
            {
                this.Checked_Image.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                this.Checked_Image.Visibility = System.Windows.Visibility.Visible;
            }

        }

    }
}
