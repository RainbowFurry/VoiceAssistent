using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Twilio;
//using Twilio.Rest.Api.V2010.Account;

namespace DWC_VoiceAssistent.handler.backgroundtasks.messenging
{
    class SendWhatsappMessage
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private void sendMessage(string number, string content)
        {
            //WAS WEN ER ZURÜCK SCHREIBT?!
            //const string accountSid = "AC13fde6e9139b50f6dc6e66dbd30f17a2";
            //const string authToken = "ce9d0de179b3dc9826faa14741273130";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    body: content,
            //    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            //    to: new Twilio.Types.PhoneNumber("whatsapp:+" + number)
            //);

            //Console.WriteLine(message.Sid);
        }

    }
}
