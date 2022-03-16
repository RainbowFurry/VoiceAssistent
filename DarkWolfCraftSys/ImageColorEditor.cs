using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DarkWolfCraftSys
{
    public class ImageColorEditor
    {

        /*
         * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        /// <summary>
        /// Change The Color of an Image to the defined Configs
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static ImageSource changeImageColor(System.Windows.Controls.Image image)
        {
            return ConvertToImageSource(changecolor(ConvertWpfImageToImage(image)));
        }

        /// <summary>
        /// Change Image Color to selected User Main Color
        /// </summary>
        public static Bitmap changecolor(Image image)
        {
            System.Drawing.Color fromColor = System.Drawing.Color.FromArgb(15, 127, 238);
            System.Drawing.Color toColor = System.Drawing.Color.FromArgb(0, 237, 23);

            Bitmap img = new Bitmap(image);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    System.Drawing.Color pixelColor = img.GetPixel(i, j);
                    if (pixelColor == fromColor && pixelColor != System.Drawing.Color.FromArgb(0, 255, 255, 255))//Change Main Color
                    {
                        img.SetPixel(i, j, toColor);
                    }
                    else if(pixelColor == System.Drawing.Color.FromArgb(255, 0, 0, 0))//Wenn Schwarz
                    {
                        img.SetPixel(i, j, System.Drawing.Color.FromArgb(0, 0, 0, 0));
                    }
                    else if (pixelColor == System.Drawing.Color.FromArgb(255, 255, 255, 255))//Weiß zu Schwart
                    {
                        img.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                    }
                    else//falls keine farbe dabei ist
                    {
                        // TODO Entcomment when svg is implementiert
                        //img.SetPixel(i, j, System.Drawing.Color.FromArgb(0, 0, 0, 0));
                    }
                       
                }
            }
            return img;
        }

        public static Image ConvertWpfImageToImage(System.Windows.Controls.Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image", "Image darf nicht null sein.");

            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            MemoryStream ms = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));
            encoder.Save(ms);
            Image img = Image.FromStream(ms);
            return img;
        }

        public static ImageSource ConvertToImageSource(Bitmap bitmap)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        /// <summary>
        /// Change Image Color to given Color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="image"></param>
        public static Bitmap changecolor(System.Drawing.Color color, Image image)
        {
            System.Drawing.Color fromColor = System.Drawing.Color.FromArgb(15, 127, 238);
            System.Drawing.Color toColor = color;

            Bitmap img = new Bitmap(image);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    System.Drawing.Color pixelColor = img.GetPixel(i, j);
                    if (pixelColor == fromColor)
                        img.SetPixel(i, j, toColor);
                }
            }
            return img;
        }

    }
}
