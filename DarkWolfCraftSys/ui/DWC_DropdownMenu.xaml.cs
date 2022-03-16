using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{

    public partial class DWC_DropdownMenu : UserControl
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public DWC_DropdownMenu()
        {
            InitializeComponent();
        }

        public bool isToggled { get; set; }
        public SolidColorBrush DropdownBackground { get; set; }
        //public SolidColorBrush DropdownBorderColor { get; set; }
        public SolidColorBrush DropdownForeground { get; set; }
        public String DropdownContent { get; set; }
        public double DropdownRounding { get; set; }
        public SolidColorBrush DropdownOptionFill { get; set; }


        public SolidColorBrush DropdownMenuBackground { get; set; }
        public Grid DropDownMenuContent { get; set; }

    }
}
