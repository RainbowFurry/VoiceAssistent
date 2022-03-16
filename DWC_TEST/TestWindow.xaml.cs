using System;
using System.Windows;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;


namespace DWC_TEST
{
   public partial class TestWindow : Window
   {
      public TestWindow()
      {
         InitializeComponent();
         //watermarkImage(@"C:\Users\DarkS\Documents\HeimServer\clouds.jpg", "Wolfi", @"C:\Users\DarkS\Documents\HeimServer\Test.png", ImageFormat.Png);
      }

      //CREATE IMAGE WATERMARK

      private void buttonCapture_Click(object sender, RoutedEventArgs e)
      {

      }

      public void watermarkImage(string sourceImage, string text, string targetImage, ImageFormat fmt)
      {

         try
         {

            // open source image as stream and create a memorystream for output

            FileStream source = new FileStream(sourceImage, FileMode.Open);

            Stream output = new MemoryStream();

            Image img = Image.FromStream(source);



            // choose font for text
            Font font = new Font("Arial", 20, System.Drawing.FontStyle.Bold, GraphicsUnit.Pixel);


            //choose color and transparency

            Color color = Color.FromArgb(100, 255, 0, 0);



            //location of the watermark text in the parent image

            System.Drawing.Point pt = new System.Drawing.Point(10, 5);

            SolidBrush brush = new SolidBrush(color);



            //draw text on image

            Graphics graphics = Graphics.FromImage(img);

            graphics.DrawString(text, font, brush, pt);

            graphics.Dispose();



            //update image memorystream

            img.Save(output, fmt);

            Image imgFinal = Image.FromStream(output);



            //write modified image to file

            Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height, img.PixelFormat);

            Graphics graphics2 = Graphics.FromImage(bmp);

            graphics2.DrawImage(imgFinal, new System.Drawing.Point(0, 0));

            bmp.Save(targetImage, fmt);



            imgFinal.Dispose();

            img.Dispose();

         }

         catch (Exception ex)
         {

            MessageBox.Show(ex.Message);

         }

      }

   }
}
