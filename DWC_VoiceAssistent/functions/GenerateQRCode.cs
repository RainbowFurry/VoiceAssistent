using System;
using System.Drawing;
using Zen.Barcode;

namespace DWC_VoiceAssistent.functions
{
    class GenerateQRCode
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static void generateQRCode(String qrCodeContent, String fileSaveName)
        {

            //QrCode
            CodeQrBarcodeDraw qrCode = BarcodeDrawFactory.CodeQr;
            Image image = qrCode.Draw(qrCodeContent, 50);

            //Save QrCode
            string saveFileName = @"C:\Users\DarkS\Documents\HeimServer\" + fileSaveName + ".png";
            image.Save(saveFileName);

        }

    }
}
