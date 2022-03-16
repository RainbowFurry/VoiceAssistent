using System;
using System.Net.Mail;
using System.Net;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.functions
{
   public class MailManager
   {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //Infos : https://www.e-iceblue.com/Knowledgebase/Spire.Email/Spire.Email-Program-Guide/Send-Email-with-Attachment-in-C-VB.NET.html

        private static String email = "darkwolfcraft.net@gmail.com";
      private static MailMessage mailMessage;

      /// <summary>
      /// Use defined Mail Heading
      /// </summary>
      public static class MailHeading
      {
         private static String heading = "DarkWolfCraft.net VoiceAssistent - ";
         public static String report = heading + "Report";
         public static String support = heading + "Support";
         public static String feedback = heading + "Feedback";
         public static String error = heading + "Error";
      }

      /// <summary>
      /// Create the Email and send it to DarkWolfCraft.net@gmail.com
      /// </summary>
      public static void sendMail(string heading, string content)
      {
         mailMessage = new MailMessage(email, email, heading, content);
         createAndSendMail();
      }

      /// <summary>
      /// Create the Email and send it to DarkWolfCraft.net@gmail.com
      /// </summary>
      public static void sendMailWithLog(string heading, string content)
      {
         mailMessage = new MailMessage(email, email, heading, content);
         mailMessage.Attachments.Add(new Attachment(MainWindow.Save_Path + @"logs\" + DateTime.Now.ToLongDateString() + ".txt"));
         createAndSendMail();
      }

      /// <summary>
      /// Send the Mail to the defined Values
      /// </summary>
      private static void createAndSendMail()
      {

         SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
         smtpClient.EnableSsl = true;
         smtpClient.UseDefaultCredentials = false;
         smtpClient.Credentials = new NetworkCredential(email, "JasonJT14Killer14JonasJT14");

         try
         {
            smtpClient.Send(mailMessage);
            LogFileManager.createLogEntrence("DWC_VoiceAssistent has successfully send a new Mail");
         }
         catch (Exception ex)
         {
            LogFileManager.createLogExeptionEntrence(ex);
         }

      }

   }
}
