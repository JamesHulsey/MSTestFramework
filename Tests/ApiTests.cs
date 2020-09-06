using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.API;
using MSTestFramework.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class ApiTests : TestHelper
    {
        [TestMethod]
        public void IRestResponseTest()
        {
            var request = new RequestObject("http://api.openweathermap.org/data/2.5/weather?q=wentzville&appid=0ee6f4c510be459cbe54d01cf30b0366", Method.GET);
            var response = request.ExecuteAndGetIRestResponse();
            Assert.IsTrue(response.Content.Contains("Wentzville"), "API response content didn't contain Wentzville.");
        }

        [TestMethod]
        public void JsonTest()
        {
            var request = new RequestObject("http://api.openweathermap.org/data/2.5/weather?q=wentzville&appid=0ee6f4c510be459cbe54d01cf30b0366", Method.GET);
            var response = request.ExecuteAndGetJson();
            Assert.AreEqual("Wentzville", response.GetValue("name").ToString(), "API response name node values didn't match.");
        }
    }
}
