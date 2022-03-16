using System;
using System.Speech.Synthesis;

/***********************************************
 * Porject Name : DWC_VoiceAssistent           *
 * Company Name : DarkWolfCraft.net            *
 * Description : TalkManager controls the      *
 *               Voice of this Programm        *
 * Author : Jason Hoffmann (DarkSide_Wolf)     *
 **********************************************/

namespace DWC_VoiceAssistent.configmanager
{
    class TalkManager
    {

        /// <summary>
        /// Control the VoiceAssistents Voice (speed, breaks, Volum)
        /// </summary>
        public static void talkManager()
        {

            commands.RegisterCommands.say.Volume = 100;  // (0 - 100)
            commands.RegisterCommands.say.Rate = 3; // speed of talking         

            PromptBuilder builder = new PromptBuilder();

            builder.StartStyle(new PromptStyle(PromptRate.Medium));
            builder.StartSentence();
            builder.AppendText("Das ist ein langer Text den ich zum testen meiner Sprachkentnisse vorlese.");
            builder.EndSentence();
            builder.EndStyle();

            builder.AppendBreak(new TimeSpan(0, 0, 0, 0, 50)); // a break of 1 second

            builder.StartStyle(new PromptStyle(PromptVolume.Loud));
            builder.StartSentence();
            builder.AppendText("Gefällt es dir wie ich dir den Text vorlesen kann oder ist es nicht gut?");
            builder.EndSentence();
            builder.EndStyle();

            commands.RegisterCommands.say.Speak(builder);
            commands.RegisterCommands.say.Dispose();

        }

    }
}
