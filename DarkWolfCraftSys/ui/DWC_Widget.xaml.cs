using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{
    public partial class DWC_Widget : UserControl
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */
        public DWC_Widget()
        {
            InitializeComponent();
        }

        public SolidColorBrush WidgetBackground { get; set; }
        public double WidgetRounding { get; set; }

        #region docu
        #region Way 1
        //public string MyText
        //{
        //    get { return (string)GetValue(MyTextProperty); }
        //    set { SetValue(MyTextProperty, value); }
        //}

        //public static readonly DependencyProperty MyTextProperty = DependencyProperty.Register("MyText", typeof(string), typeof(DWC_MenuButton), new PropertyMetadata("<leer>"));
        #endregion

        #region Way 2
        //public SolidColorBrush MenuButtonBackground { get; set; }
        #endregion
        #endregion

    }
}
