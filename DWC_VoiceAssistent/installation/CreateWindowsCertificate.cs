using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DWC_VoiceAssistent.installation
{
    class CreateWindowsCertificate
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /*
         windows suche mmc
         datei -> snapin -> Zertificat
         Eigene Zertifikate rechtsklicken und neues erstellen.
             */

        /*Shortcut Description
* 
* CN = NAME
* C = LAND
* E = EMAIL
* T = TITEL
* G = VORNAME
* L = ORT
* O = ORGANISATION
* S = LAND
* Street = STRAßE
* SN = NACHNAME
* 
*/

        private static String lizensContent = "CN=DarkWolfCraft, C=Germany, E=DarkWolfCraft.net@outlook.de, T=DarkWolfCraft";
        private static String certificatePW = "0000";

        /// <summary>
        /// Create the Windows CA - Certificate
        /// </summary>
        public static void createWindowsCertificate()
        {

            String codeName = "CN=DarkWolfCraft";

            var ecdsa = ECDsa.Create(); // generate asymmetric key pair
            var req = new CertificateRequest(codeName, ecdsa, HashAlgorithmName.SHA256);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(30));

            File.WriteAllText(MainWindow.Save_Path + @"DarkWolfCraft.cer",
           "-----BEGIN CERTIFICATE-----\r\n"
           + Convert.ToBase64String(cert.Export(X509ContentType.Cert, certificatePW), Base64FormattingOptions.InsertLineBreaks)
           + "\r\n-----END CERTIFICATE-----");
        }

        /// <summary>
        /// Create the PFX File (is used/needed) for the Code Signithion
        /// </summary>
        public static void createWindowsPFX()
        {
            String codeName = "CN=DarkWolfCraft";

            var ecdsa = ECDsa.Create(); // generate asymmetric key pair
            var req = new CertificateRequest(codeName, ecdsa, HashAlgorithmName.SHA256);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(30));

            File.WriteAllText(MainWindow.Save_Path + @"DarkWolfCraft.pfx",//.pfx
           "-----BEGIN CERTIFICATE-----\r\n"
           + Convert.ToBase64String(cert.Export(X509ContentType.Pfx, certificatePW), Base64FormattingOptions.InsertLineBreaks)
           + "\r\n-----END CERTIFICATE-----");
        }

        public static void installWindowsCertificate()
        {
            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Add(new X509Certificate2(X509Certificate2.CreateFromCertFile(MainWindow.Save_Path + @"DarkWolfCraft.cer")));
            store.Close();
        }

    }
}
