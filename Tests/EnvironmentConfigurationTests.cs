using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class EnvironmentConfigurationTests
    {
        [TestMethod]
        public void GetValueTest()
        {
            var url = EnvironmentConfiguration.GetValue("url");
            Assert.AreEqual("does this work", url, "The environment config values didn't match.");
        }
    }
}
