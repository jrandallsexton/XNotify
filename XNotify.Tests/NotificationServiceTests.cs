using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using XNotify.Contracts;
using XNotify.Tests.Fakes;

namespace XNotify.Tests
{

    public class NotificationServiceTests
    {

        private List<FakeNotificationTarget> _targets = null;
        
        [TestFixtureSetUp]
        public void SetUp()
        {
            _targets = FakeNotificationTargetFactory.CreateFakeTargets();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            
        }
    }

}