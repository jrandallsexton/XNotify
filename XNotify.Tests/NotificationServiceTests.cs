
using System.Collections.Generic;

using XNotify.Contracts;
using XNotify.Providers;
using XNotify.Services;
using XNotify.Tests.Fakes;

using NUnit.Framework;

namespace XNotify.Tests
{

    public class NotificationServiceTests
    {

        private List<FakeNotificationTarget> _targets = null;
        private List<FakeNotifiableEventProvider<INotifiableEvent>> _sources = null;
        private INotificationService _service = null;
        private INotificationProviderConfig _smsProviderConfig = null;
        private INotificationProvider _notificationProvider = null;

        [SetUp]
        public void SetUp()
        {
            _sources = FakesFactory.CreateFakeEventProviders();
            _targets = FakesFactory.CreateFakeTargets();
            _smsProviderConfig = new FakeSmsNotificationProviderConfig();
            _notificationProvider = new SmsNotificationProvider(_smsProviderConfig);
            _service = new NotificationService("XNotificationService", "Service Testing Service", new List<INotificationProvider>
            {
                _notificationProvider
            });
        }

        [Test]
        public void Notification_Config_Fails()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            
        }

    }

}