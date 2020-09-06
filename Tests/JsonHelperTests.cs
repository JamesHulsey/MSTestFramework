using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class JsonHelperTests
    {
        [TestMethod]
        public void JsonMultiFolderPathTest()
        {
            var json = JsonHelper.LoadJson("json1.json", "TestFiles", "json");
            Assert.AreEqual("value1", json["key1"], "The key 1 value wasn't value1");
            Assert.AreEqual("value2", json["key2"], "The key 2 value wasn't value2");
        }

        [TestMethod]
        public void JsonFolderPathTest()
        {
            var json = JsonHelper.LoadJson("json2.json");
            Assert.AreEqual("value10", json["key1"], "The key 1 value wasn't value10");
            Assert.AreEqual("value20", json["key2"], "The key 2 value wasn't value20");
        }
    }
}
