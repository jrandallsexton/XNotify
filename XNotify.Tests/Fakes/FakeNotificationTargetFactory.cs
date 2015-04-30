
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Tests.Fakes
{
    public class FakeNotificationTargetFactory
    {
        public static List<FakeNotificationTarget> CreateFakeTargets()
        {
            var targets = new List<FakeNotificationTarget>();

            targets.Add(new FakeNotificationTarget
            {
                Name = "User, Fake",
                Email = "jrandallsexton@gmail.com",
                SendEmail = true,
                SendSms = true,
                Sms = "+1 865 386 5611"
            });

            targets.Add(new FakeNotificationTarget
            {
                Name = "Blow, Joe",
                Email = "joeblow@gmail.com",
                SendEmail = false,
                SendSms = false,
                Sms = "+1 865 386 5611"
            });

            targets.Add(new FakeNotificationTarget
            {
                Name = "Only, Sms",
                Email = "joeblow@gmail.com",
                SendEmail = false,
                SendSms = true,
                Sms = "+1 865 386 5611"
            });

            targets.Add(new FakeNotificationTarget
            {
                Name = "Only, Email",
                Email = "joeblow@gmail.com",
                SendEmail = true,
                SendSms = false,
                Sms = "+1 865 386 5611"
            });

            return targets;
        } 
    }
}