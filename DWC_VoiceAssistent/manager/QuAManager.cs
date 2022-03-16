using System;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using DarkWolfCraftSys;

namespace DWC_VoiceAssistent.manager
{
   class QuAManager
   {

      /// <summary>
      /// Set the Question and Answer Content shown in the Menu
      /// </summary>
      public static void questionAnswer(string question, string answer)
      {

         MainWindow mainWindow = MainWindow.mainWindow;

         //if (mainWindow.DWC_QuA_A_Text != null)
         //{
         //   if (mainWindow.DWC_QuA_A_Text.Content != null)
         //   {
         //      mainWindow.DWC_QuA_Q_Text.Content = "Question : " + question;
         //      mainWindow.DWC_QuA_A_Text.Content = "Answer : " + answer;

         //      mainWindow.DWC_QuA_A_Background.Width = mainWindow.DWC_QuA_A_Text.Width + 100;
         //      mainWindow.DWC_QuA_Q_Background.Width = mainWindow.DWC_QuA_Q_Text.Width + 100;

         //      QAlog(question, answer);
         //   }
         //}

      }

      /// <summary>
      /// Reference Daily Log - Create Question and Answer Log Format
      /// </summary>
      private static void QAlog(string question, string answer)
      {

         if (!Directory.Exists(LogFileManager.save_path))
         {
            Directory.CreateDirectory(LogFileManager.save_path);
         }

         File.AppendAllText(LogFileManager.save_path + DateTime.Now.ToLongDateString() + ".txt", "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "][Command] For the latest Command we have following Information:\n" + "\n");
         File.AppendAllText(LogFileManager.save_path + DateTime.Now.ToLongDateString() + ".txt", "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "][Question] " + question + "\n");
         File.AppendAllText(LogFileManager.save_path + DateTime.Now.ToLongDateString() + ".txt", "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "][Answer] " + answer + "\n");

      }

      /// <summary>
      /// Reference Dev Log - Create Command Info Log Format
      /// </summary>
      public static void CommandInfo(SpeechRecognizedEventArgs e)
      {

         Console.WriteLine("\n[CommandInfo] The System remembers the following Information about your latest Command:");

         Console.WriteLine("[CommandInfo] Grammar: " + e.Result.Grammar.Name);
         Console.WriteLine("[CommandInfo] Recognized text: " + e.Result.Text);
         Console.WriteLine("[CommandInfo] Confidence score: " + e.Result.Confidence + "\n");

         //create devlog 
         LogFileManager.createDeveloperLogEntrence("\n[CommandInfo] The System remembers the following Information about your latest Command:");
         LogFileManager.createDeveloperLogEntrence("[CommandInfo] Grammar: " + e.Result.Grammar.Name);
         LogFileManager.createDeveloperLogEntrence("[CommandInfo] Recognized text: " + e.Result.Text);
         LogFileManager.createDeveloperLogEntrence("[CommandInfo] Confidence score: " + e.Result.Confidence + "\n");

      }

      /// <summary>
      /// Reference Dev Log - Create Voice Info Log Format
      /// </summary>
      public static void VoiceInfo()
      {

         Console.WriteLine("\n[VoiceInfo] Here is the Information for all avaliable Voice Packs installed on the Computer.");
         LogFileManager.createDeveloperLogEntrence("\n[VoiceInfo] Here is the Information for all avaliable Voice Packs installed on the Computer.");

         foreach (InstalledVoice voice in commands.RegisterCommands.say.GetInstalledVoices())

         {

            VoiceInfo info = voice.VoiceInfo;

            Console.WriteLine("[VoiceInfo] Voice Name:           " + info.Name);
            Console.WriteLine("[VoiceInfo] Voice Age:            " + info.Age);
            Console.WriteLine("[VoiceInfo] Voice Culture:        " + info.Culture);
            Console.WriteLine("[VoiceInfo] Voice Description:    " + info.Description + "\n");

            LogFileManager.createDeveloperLogEntrence("[VoiceInfo] Voice Name:           " + info.Name);
            LogFileManager.createDeveloperLogEntrence("[VoiceInfo] Voice Age:            " + info.Age);
            LogFileManager.createDeveloperLogEntrence("[VoiceInfo] Voice Culture:        " + info.Culture);
            LogFileManager.createDeveloperLogEntrence("[VoiceInfo] Voice Description:    " + info.Description + "\n");

         }

      }

   }
}
