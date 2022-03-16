using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys
{
   class DropDownManager
   {
        /*
        * Creator: Adrian H.
         * Date: -
        * Comment: -
        */


        /*
     * Komplett eigene Methode zum zusammen basteln mit .queue oder so am ende und da kann man alles was man will/braucht festlegen
     */

        private static bool isOpen;

      /// <summary>
      /// Von Links nach Rechts
      /// </summary>
      public static void ToggleGridSliderRight(object sender, Grid grid, double gridWidthClosed)
      {

         Console.WriteLine(sender.GetType());
         if (sender.GetType().ToString().Contains("Image"))
         {

            Image image = (Image)sender;

            if (image.RenderTransform == new RotateTransform(90))
            {

               //SAVE WIDTH BEFORE!!!
               grid.Width = gridWidthClosed;
               isOpen = true;

            }
            else
            {

               //
               isOpen = false;

            }

         }

      }

      /// <summary>
      /// Von Rechts nach Links
      /// </summary>
      public static void ToggleGridSliderLeft(object sender, Grid grid, double gridWidthClosed)
      {

      }

      /// <summary>
      /// Von Unten nach Oben
      /// </summary>
      public static void ToggleGridSliderUp(object sender, Grid grid, double gridWidthClosed)
      {

      }

      /// <summary>
      /// Von Oben nach Unten
      /// </summary>
      public static void ToggleGridSliderDown(object sender, Grid grid, double gridWidthClosed)
      {

      }

      //public ToggleIconClick(object sender, Grid grid)
      //{

      //   Console.WriteLine(sender.GetType());
      //   if (sender.GetType().ToString().Contains("Image"))
      //   {
      //      System.Drawing.Image image = (System.Drawing.Image)sender;

      //      if (image.RenderTransform != rotationclosed)
      //      {

      //         while (grid.Width > 30)
      //         {
      //            grid.Width--;
      //         }

      //         image.RenderTransform = rotationopen;
      //         image.Margin = opened;
      //         isOpen = true;

      //      }
      //      else if (image.RenderTransform == rotationclosed)
      //      {

      //         while (grid.Width < 372)
      //         {
      //            grid.Width++;
      //         }

      //         image.RenderTransform = rotationclosed;
      //         image.Margin = closed;
      //         isOpen = false;

      //      }

      //   }
      //}

   }
}
