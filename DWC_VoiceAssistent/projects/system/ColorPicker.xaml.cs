using DWC_VoiceAssistent.handler.projects.colorpicker;
using System.Windows;

namespace DWC_VoiceAssistent.projects.system
{

    public partial class ColorPicker : Window
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static ColorPicker colorPickerWindow;

        public ColorPicker()
        {
            InitializeComponent();
            colorPickerWindow = this;
            Show();
            new WindowControler();
        }

    }
}
