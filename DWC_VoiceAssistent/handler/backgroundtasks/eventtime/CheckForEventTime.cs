using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWC_VoiceAssistent.handler.backgroundtasks.eventtime
{
    class CheckForEventTime
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public void getEventTime()
        {

            String dateTime = DateTime.Now.ToLongDateString();

            //New Year
            if (dateTime.Contains("31. Dezember"))
            {
                //
            }

            //Weihnachten
            if (dateTime.Contains("Dezember") && !(dateTime.Contains("31.")))
            {
                //
            }

            //1 April
            if (dateTime.Contains("1. April"))
            {
                //
            }

            //Ostern

            //Halloween

        }

    }
}
