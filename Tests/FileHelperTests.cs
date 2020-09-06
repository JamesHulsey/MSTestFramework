using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class FileHelperTests
    {
        [TestMethod]
        public void RetrieveFileContentsTest()
        {
            var contents = FileHelper.RetrieveFileContents("json2.json", "Json");
            Assert.IsTrue(contents.Contains("value10"));
            Assert.IsTrue(contents.Contains("value20"));
        }
    }
}
