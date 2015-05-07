
using System;
using System.Collections.Generic;
using System.Linq;

using XNotify.Common;
using XNotify.Contracts;

using Twilio;
using XNotify.NotificationProviders;

namespace XNotify.Tests.NotificationProviders.Twilio
{

    public class TwilioSmsProvider : INotificationProvider
    {

        public ENotificationProviderType ProviderType { get; set; }
        public INotificationProviderConfig Config { get; set; }

        public TwilioSmsProvider()
        {
            this.ProviderType = ENotificationProviderType.Sms;
        }

        public void Send(string to, string message)
        {
            var twilio = new TwilioRestClient(Config.AccountSid, Config.AuthToken);
            twilio.SendMessage(Config.AccountName, to, message);
        }

        public void Send(string to, string subject, string message)
        {
            var twilio = new TwilioRestClient(Config.AccountSid, Config.AuthToken);
            twilio.SendMessage(Config.AccountName, to, message);
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message)
        {
            var twilio = new TwilioRestClient(Config.AccountSid, Config.AuthToken);
            to.ToList().ForEach(x =>
            {
                var response = twilio.SendMessage(Config.AccountName, x, message);
                Console.WriteLine(response.ErrorMessage);
            });

        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback)
        {
            var twilio = new TwilioRestClient(Config.AccountSid, Config.AuthToken);

            to.ToList().ForEach(x => twilio.SendMessage(Config.AccountName, x, message));

            callback("complete");
        }

        public IEnumerable<INotificationProviderResponse> Receive()
        {
            var twilio = new TwilioRestClient(Config.AccountSid, Config.AuthToken);

            var res = twilio.ListSmsMessages(string.Empty, string.Empty, DateTime.UtcNow, null, null);

            if (res == null) return new List<NotificationProviderResponse>();

            var responses = new List<NotificationProviderResponse>();

            foreach (var msg in res.SMSMessages.Where(msg => msg.From != Config.AccountName))
            {
                responses.Add(new NotificationProviderResponse
                {
                    Channel = this.ProviderType,
                    Message = msg.Body,
                    Received = msg.DateSent,
                    Sender = msg.From,
                    SourceId = msg.Sid
                });
            }

            return responses;

        }

    }

}