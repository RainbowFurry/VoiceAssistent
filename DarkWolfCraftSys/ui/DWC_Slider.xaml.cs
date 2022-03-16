using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{

    public partial class DWC_Slider : UserControl
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public DWC_Slider()
        {
            InitializeComponent();
            //this.DataContext = this;
        }

        //Step Size per step
        //Border
        //width u height
        //max step size

        #region SliderBar
        public SolidColorBrush SliderBarFill { get; set; }
        public double SliderBarRounding { get; set; }
        #endregion

        #region SliderScale
        public SolidColorBrush SliderScaleFill { get; set; }
        public double SliderScaleRounding { get; set; }
        #endregion

    }
}
