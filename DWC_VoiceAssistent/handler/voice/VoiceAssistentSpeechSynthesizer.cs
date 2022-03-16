using System;

namespace DWC_VoiceAssistent.handler.voice
{
    class VoiceAssistentSpeechSynthesizer
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public static void speak(String contnent)
        {
            VoiceControler.say.SpeakTextAsync(contnent).ConfigureAwait(true);
            VoiceAssistentSpeechRecognition.speechTextOutput = contnent;//Get Output as Text
        }

    }
}
