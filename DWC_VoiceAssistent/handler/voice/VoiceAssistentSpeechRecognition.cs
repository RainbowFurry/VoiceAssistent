using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.commands;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DWC_VoiceAssistent.handler.voice
{
    class VoiceAssistentSpeechRecognition
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        //GrammarList g = GrammarList.FromRecognizer(recognizer);
        //Grammar citiesGrammar = Grammar.FromStorageId("xml/Test.xml");
        //g.Add(citiesGrammar);

        public static async Task RecognizeSpeechAsync()
        {

            VoiceControler.speechRecognizerName.Recognized += recognizeName;
            VoiceControler.speechRecognizer.Recognized += recognize;

            try
            {

                //var result = await VoiceControler.speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false);//await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                //if (result.Reason == ResultReason.RecognizedSpeech)
                //{
                //    Console.WriteLine($"We recognized: {result.Text}");
                //    //VoiceAssistentStartSpeaking();//GIVE ANSWER
                //}
                //else if (result.Reason == ResultReason.NoMatch)
                //{
                //    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                //}
                //else if (result.Reason == ResultReason.Canceled)
                //{
                //    var cancellation = CancellationDetails.FromResult(result);
                //    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                //    if (cancellation.Reason == CancellationReason.Error)
                //    {
                //        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                //        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                //        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                //    }
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.Source + "\n" + e.StackTrace + "\n" + e.Data);
            }

        }

        private static void recognizeName(object sender, SpeechRecognitionEventArgs e)
        {
            
            String result = e.ToString().Split('<')[1].Replace(">.", "");
            //Console.WriteLine(e);
            //Console.WriteLine(result);

            MainWindow.listen = true;
            textOutout(result);
            VoiceControler.speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false);
            VoiceRecognitionListeningAnimation.startListeningAnimation();
        }

        private static void recognize(object sender, RecognitionEventArgs e)
        {

            String result = e.ToString().Split('<')[1].Replace(">.", "").ToLower();
            Console.WriteLine(result);

            MainWindow.listen = false;
            textOutout(result);
            CommandController.OnCommand(result, new String[0]);
            LogFileManager.createLogEntrence("[VoiceCommand][Recognized] " + result);
            VoiceRecognitionListeningAnimation.stopListeningAnimation();

            //Delay in Result Text Output
            Task.Run(async delegate
            {
                await Task.Delay(2500);
                textOutout(speechTextOutput);
            });

        }

        public static String speechTextOutput = "";

        private static void textOutout(string shownText)
        {
            Task.Run(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainWindow.mainWindow.VoiceAssistent_TextOutput.Text = shownText;
                    MainWindow.mainWindow.VoiceAssistent_TextOutput.TextWrapping = TextWrapping.Wrap;
                }), DispatcherPriority.Render);
                Thread.Sleep(50);
             
            });
        }

    }
}
