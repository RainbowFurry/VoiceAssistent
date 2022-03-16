using System;
using System.Windows.Media;
using DarkWolfCraftSys;
using DWC_VoiceAssistent.handler.commands;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace DWC_VoiceAssistent.handler.voice
{
    class VoiceControler
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static String _VoiceSubscriptionKey = "8f4e71eef45f401a92686277cbc5590e";
        public static String _VoiceRegion = "westeurope";

        public static SpeechConfig speechRecognitionConfig = SpeechConfig.FromSubscription(_VoiceSubscriptionKey, _VoiceRegion);
        public static SpeechConfig speechSyntheniserConfig = SpeechConfig.FromSubscription(_VoiceSubscriptionKey, _VoiceRegion);
        public static SpeechRecognizer speechRecognizerName;
        public static SpeechRecognizer speechRecognizer;
        public static SpeechSynthesizer say;

        /// <summary>
        /// Initialize VoiceAssistent Config and Commands.
        /// Start VoiceRecognition.
        /// </summary>
        public static void initializeVoiceAssistent()
        {

            //Register Config
            speechRecognitionConfig.SpeechRecognitionLanguage = ConfigManager.language; //AUS CONFIG EINFÜGEN - ABER ALLE SPRACHEN MÖGLICH übersetzbar?
            speechRecognitionConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio16Khz32KBitRateMonoMp3);

            //Add Config to VoiceAssistent
            speechRecognizerName = new SpeechRecognizer(speechRecognitionConfig);//listen only on Name
            speechRecognizer = new SpeechRecognizer(speechRecognitionConfig);//listen to everything
            //speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false); //Listen loop

            speechSyntheniserConfig.SpeechSynthesisLanguage = ConfigManager.language;
            say = new SpeechSynthesizer(speechSyntheniserConfig, AudioConfig.FromDefaultSpeakerOutput());//DEVICE CHANGEABLE

            KeywordRecognitionModel k = KeywordRecognitionModel.FromFile(MainWindow.Save_Path + "Hey_PC.table");
            speechRecognizerName.StartKeywordRecognitionAsync(k).ConfigureAwait(false);

            new CommandController();

            //setColorCodes
            MainWindow.mainWindow.DWC_Mainwindow_Talk_Active_1.Fill = new SolidColorBrush(Color.FromArgb(80, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            MainWindow.mainWindow.DWC_Mainwindow_Talk_Active_2.Fill = new SolidColorBrush(Color.FromArgb(80, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            MainWindow.mainWindow.DWC_Mainwindow_Talk_Active_3.Fill = new SolidColorBrush(Color.FromArgb(80, ConfigManager.R, ConfigManager.G, ConfigManager.B));
            MainWindow.mainWindow.DWC_Mainwindow_Talk_Active_4.Fill = new SolidColorBrush(Color.FromArgb(80, ConfigManager.R, ConfigManager.G, ConfigManager.B));

            VoiceAssistentSpeechRecognition.RecognizeSpeechAsync().Wait();//Register Output

            VoiceAssistentSpeechSynthesizer.speak("Hallo Jason");//TEST
        
        }

    }
}
