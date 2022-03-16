using DarkWolfCraftSys;
using DWC_VoiceAssistent.functions;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DWC_VoiceAssistent.handler.backgroundtasks
{
    class CreateCertificate
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        /// <summary>
        /// Create the Certificate (CER|PFX)
        /// </summary>
        /// <param name="certificateType"></param>
        public static void createCertificate(certificate certificateType)
        {
            String certificateInformation = "cn=DWC_VoiceAssistent, O=DarkWolfCraft";

            var ecdsa = ECDsa.Create(); // generate asymmetric key pair
            var req = new CertificateRequest(certificateInformation, ecdsa, HashAlgorithmName.SHA256);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(30));

            if (certificateType == certificate.cer)
            {
                File.WriteAllText(MainWindow.Save_Path + @"DWC_VoiceAssistent." + certificateType,
               "-----BEGIN CERTIFICATE-----\r\n"
               + Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)
               + "\r\n-----END CERTIFICATE-----");
            }
            else if(certificateType == certificate.pfx)
            {
                File.WriteAllText(MainWindow.Save_Path + @"DWC_VoiceAssistent." + certificateType,
            "-----BEGIN CERTIFICATE-----\r\n"
            + Convert.ToBase64String(cert.Export(X509ContentType.Pfx), Base64FormattingOptions.InsertLineBreaks)
            + "\r\n-----END CERTIFICATE-----");
            }
        }

        /// <summary>
        /// Install the Certificate (CER|PFX)
        /// </summary>
        public static void installCertificate(certificate certificateType)
        {
            X509Store store = new X509Store(StoreName.AuthRoot, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Add(new X509Certificate2(X509Certificate2.CreateFromCertFile(MainWindow.Save_Path + @"DWC_VoiceAssistent." + certificateType)));
            Console.WriteLine(MainWindow.Save_Path + @"DWC_VoiceAssistent." + certificateType);//
            store.Close();
        }

        /// <summary>
        /// Check if the Certificate already Exists
        /// </summary>
        public static void checkIfCertificateExists()
        {
            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            var certificates = store.Certificates.Find(
                X509FindType.FindBySubjectName,
                "DWC_VoiceAssistent",
                false);
            if (certificates != null && certificates.Count > 0)
            {
                Console.WriteLine("Certificate already exists");
            }
            else
            {
                ForceAdmin.programmStartedAsAdmin();
                createCertificate(certificate.cer);
                installCertificate(certificate.cer);
                LogFileManager.createLogEntrence("Das Zertifikat wurde erfolgreich installiert!");
            }
        }

    }

    public enum certificate 
    {
        cer,
        pfx
    }

}
