
using System.Collections.Generic;
using Ploeh.AutoFixture.Kernel;
using XNotify.Contracts;

namespace XNotify.Tests.Fakes
{

    public static class FakesFactory
    {

        public static List<FakeNotifiableEventProvider> CreateFakeEventProviders()
        {
            var sources = new List<FakeNotifiableEventProvider>
            {
                new FakeNotifiableEventProvider
                {
                    Description = "Fake data source",
                    Name = "MonitoredExternalData",
                    ExternalId = 1,
                    Source = "MyExternalSqlServer"
                }
            };

            return sources;
        }

        public static List<FakeNotificationTarget> CreateFakeTargets()
        {
            var targets = new List<FakeNotificationTarget>
            {
                new FakeNotificationTarget
                {
                    Name = "User, Fake",
                    Email = "jrandallsexton@gmail.com",
                    SendEmail = true,
                    SendSms = true,
                    Sms = "+1 865 386 5611"
                },
                new FakeNotificationTarget
                {
                    Name = "Blow, Joe",
                    Email = "joeblow@gmail.com",
                    SendEmail = false,
                    SendSms = false,
                    Sms = "+1 865 386 5611"
                },
                new FakeNotificationTarget
                {
                    Name = "Only, Sms",
                    Email = "joeblow@gmail.com",
                    SendEmail = false,
                    SendSms = true,
                    Sms = "+1 865 386 5611"
                },
                new FakeNotificationTarget
                {
                    Name = "Only, Email",
                    Email = "joeblow@gmail.com",
                    SendEmail = true,
                    SendSms = false,
                    Sms = "+1 865 386 5611"
                }
            };

            return targets;
        } 
    
    }

}