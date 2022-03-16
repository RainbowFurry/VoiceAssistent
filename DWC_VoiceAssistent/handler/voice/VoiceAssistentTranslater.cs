using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;
using System;
using System.Threading.Tasks;

namespace DWC_VoiceAssistent.handler.voice
{
    class VoiceAssistentTranslater
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private static SpeechTranslationConfig speechTranslationConfig;
        public static TranslationRecognizer translationRecognizer;

        private static string _fromLanguage;
        private static string _toLanguage;

        public static void setConfig(String fromLanguage, String toLanguage)
        {
            speechTranslationConfig.SpeechRecognitionLanguage = fromLanguage;
            speechTranslationConfig.AddTargetLanguage(toLanguage);

            speechTranslationConfig = SpeechTranslationConfig.FromSubscription(VoiceControler._VoiceSubscriptionKey, VoiceControler._VoiceRegion);

            _fromLanguage = fromLanguage;
            _toLanguage = toLanguage;

            translationRecognizer = new TranslationRecognizer(speechTranslationConfig);
        }

        public static async Task TranslateSpeechToText()
        {

            Console.WriteLine("Say something...");
            var result = await translationRecognizer.RecognizeOnceAsync();

            // Checks result.
            if (result.Reason == ResultReason.TranslatedSpeech)
            {
                Console.WriteLine($"RECOGNIZED '{_fromLanguage}': {result.Text}");
                Console.WriteLine($"TRANSLATED into '{_toLanguage}': {result.Translations[_toLanguage]}");
            }
            else if (result.Reason == ResultReason.RecognizedSpeech)
            {
                Console.WriteLine($"RECOGNIZED '{_fromLanguage}': {result.Text} (text could not be translated)");
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                    Console.WriteLine($"CANCELED: Did you update the subscription info?");
                }
            }
        }

    }
}
