
using XNotify.Config;

using NUnit.Framework;

namespace XNotify.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void XNotify_Configuration_Section_Found()
        {
            var config = XNotifyConfigSection.GetSection();
            Assert.That(config != null);
        }
    }
}