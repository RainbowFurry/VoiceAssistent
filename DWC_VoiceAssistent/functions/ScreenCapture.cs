using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.functions
{
   class ScreenCapture
   {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //screenshot https://stackoverflow.com/questions/1163761/capture-screenshot-of-active-window - https://ourcodeworld.com/articles/read/195/capturing-screenshots-of-different-ways-with-c-and-winforms

        private static String savePath = MainWindow.Save_Path + @"screenshots\";//screenshots

      public static void CaptureScreen()
      {
         //ToDo:
         //mehrere bildschirme
         //mehrere bildformate...
         //vlt funktion mit rectangle das user zieht wie in snipingtools dass dann erstellt und genommen wird und verarbeitet wird.
         //setting wo er es speichert sonst default Projekt ordner
         try
         {

            //Creating a new Bitmap object
            Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

            //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
            //Creating a Rectangle object which will  
            //capture our Current Screen
            Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

            //Creating a New Graphics Object
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);

            //Copying Image from The Screen
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

            captureBitmap.Save(savePath + saveFile() + ".jpg", ImageFormat.Png);
            NotificationMessage.Notification("DarkWolfCraft.net - Screenshot", "Your Screenshout has been saved!");

         }
         catch (Exception ex)
         {
            LogFileManager.createLogExeptionEntrence(ex);
         }

      }

      private static int saveFile(){

      if(!Directory.Exists(savePath)){
            Directory.CreateDirectory(savePath);
      }

         Random random = new Random();
         int ran = random.Next(1000000, 1000000000);

         if(!File.Exists("")){

            LogFileManager.createLogEntrence("A new Screenshot has been taken and saved under " + savePath + ran + ".jpg");
            return ran;

         }
         else{
            saveFile();
         }

         return 0;
      }

   }
}
