using System;
using System.Text;
using System.Windows;

namespace DWC_TEST
{

    /*
 SCREENSHOT:
 ScreenCapture sc = new ScreenCapture();
 // capture entire screen, and save it to a file
 Image img = sc.CaptureScreen();
 // display image in a Picture control named imageDisplay
 this.imageDisplay.Image = img;
 // capture this window, and save it
 sc.CaptureWindowToFile(this.Handle,"C:\\temp2.gif",ImageFormat.Gif);
 */

    public partial class MainWindow : Window
    {

        private MainWindow mainWindow;
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static StringBuilder connString;

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            Show();

        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    System.Diagnostics.Debug.WriteLine(file);
                    Console.WriteLine(file);
                }
            }
        }

    }

}
