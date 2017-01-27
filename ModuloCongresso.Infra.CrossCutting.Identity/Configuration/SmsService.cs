﻿using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
//using Twilio;

namespace ModuloCongresso.Infra.CrossCutting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message. (Implementação de serviço para SMS)

            //// Utilizando TWILIO como SMS Provider.
            //// https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

            //const string accountSid = "SEU ID";
            //const string authToken = "SEU TOKEN";

            //var client = new TwilioRestClient(accountSid, authToken);

            //client.SendMessage("Seu Telefone", message.Destination, message.Body);

            return Task.FromResult(0);
        }
    }
}
