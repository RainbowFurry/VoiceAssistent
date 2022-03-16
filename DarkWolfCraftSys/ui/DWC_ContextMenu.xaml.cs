using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{
    public partial class DWC_ContextMenu : UserControl
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public DWC_ContextMenu()
        {
            InitializeComponent();
        }

        public SolidColorBrush ContextMenuBackground { get; set; }
        public double ContextMenuRounding { get; set; }

    }
}
