
using System;
using System.Collections.Generic;
using System.Linq;

using XNotify.Common;
using XNotify.Contracts;

using Twilio;

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

        //private void GetSMS()
        //{
        //    string AccountSid = "ACc782348738b5dfc97e92309e487bfef8";
        //    string AuthToken = "c16ce4a7bf19e1368a92d290edb12ddf";

        //    var twilio = new TwilioRestClient(AccountSid, AuthToken);

        //    SmsMessageResult res = twilio.ListSmsMessages();

        //    var values = new SortedDictionary<string, SMSMessage>();

        //    if (res != null)
        //    {
        //        foreach (SMSMessage msg in res.SMSMessages)
        //        {
        //            if ((msg.From == TWILIO_NUMBER) || (msg.To == TWILIO_NUMBER))
        //            {
        //                if (!values.ContainsKey(msg.DateSent.ToString())) { values.Add(msg.DateSent.ToString(), msg); }
        //                //Console.WriteLine("{0}\tFrom: {1}\tTo: {2}\tMsg: {3}", msg.DateSent, msg.From, msg.To, msg.Body);
        //            }
        //        }
        //    }

        //    foreach (KeyValuePair<string, SMSMessage> kvp in values)
        //    {
        //        SMSMessage msg = kvp.Value;

        //        if ((msg.From == TWILIO_NUMBER) || (msg.To == TWILIO_NUMBER))
        //        {
        //            Console.WriteLine("{0}\tFrom: {1}\tTo: {2}\tStatus: {3}\tMsg: {4}", msg.DateSent, msg.From, msg.To, msg.Status, msg.Body);
        //        }
        //    }

        //}

    }

}