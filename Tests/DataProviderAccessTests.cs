using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.DataProvider;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class DataProviderAccessTests
    {
        [TestMethod]
        public void DataProviderAccessTest()
        {
            var json = DataProviderAccess.GetData("testjson1.json");
            Assert.AreEqual("testvalue10", json["key1"], "The key 1 value wasn't testvalue10");
            Assert.AreEqual("testvalue20", json["key2"], "The key 2 value wasn't testvalue20");
        }
    }
}
