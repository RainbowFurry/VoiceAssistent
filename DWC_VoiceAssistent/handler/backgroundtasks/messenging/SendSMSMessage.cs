using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Twilio;
//using Twilio.Rest.Api.V2010.Account;

namespace DWC_VoiceAssistent.handler.backgroundtasks.messenging
{
    class SendSMSMessage
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private void sendSMS(string number, string content)
        {
            //const string accountSid = "AC13fde6e9139b50f6dc6e66dbd30f17a2";
            //const string authToken = "ce9d0de179b3dc9826faa14741273130";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    body: content,
            //    messagingServiceSid: "MGa42bcbc86bb4cf9fb075e0f91f632c75",//NOT NEEDED?
            //    from: new Twilio.Types.PhoneNumber("+13093167263"),
            //    to: new Twilio.Types.PhoneNumber("+" + number)//+4915734712223
            //);

            //Console.WriteLine(message.Sid);
        }

    }
}
