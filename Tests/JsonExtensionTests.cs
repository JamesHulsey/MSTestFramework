using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Extensions;
using MSTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class JsonExtensionTests
    {
        // get string
        // get int
        // get long
        // get double
        // get decimal
        // get bool

        [TestMethod]
        public void GetStringTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual("james", json.GetString("string"), "The string values didn't match.");
        }

        [TestMethod]
        public void GetIntTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual(1, json.GetInt("int"), "The int values didn't match.");
        }

        [TestMethod]
        public void GetDoubleTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual(1.1, json.GetDouble("double"), "The double values didn't match.");
        }

        [TestMethod]
        public void GetLongTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual(123456789, json.GetLong("long"), "The long values didn't match.");
        }

        [TestMethod]
        public void GetDecimalTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual(1.123m, json.GetDecimal("decimal"), "The decimal values didn't match.");
        }

        [TestMethod]
        public void GetBoolTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual(true, json.GetBoolean("bool"), "The bool values didn't match.");
        }

        [TestMethod]
        public void GetDateTimeTest()
        {
            var json = JsonHelper.LoadJson("jsonextensions.json", "Json");
            Assert.AreEqual(11, json.GetDateTime("datetime").Month, "The datetime month values didn't match.");
            Assert.AreEqual(22, json.GetDateTime("datetime").Day, "The datetime day values didn't match.");
            Assert.AreEqual(1986, json.GetDateTime("datetime").Year, "The datetime year values didn't match.");
        }
    }
}
