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
    public class ScreenshotTests : TestHelper
    {
        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void TakeScreenshotTest()
        {
            Driver.Url = "https://www.google.com";
            var name = $"screenshot-{DateTime.Now.Second}";
            ScreenshotHelper.TakeScreenshot(Driver, screenshotFileName: name);
            Assert.IsTrue(File.Exists($"C:\\Users\\james\\Desktop\\Screenshots\\{name}.png"), "The screenshot doesn't exist in the specified file location.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void TakeScreenshotNoProvidedNameTest()
        {
            var date = DateTime.Now;
            Driver.Url = "https://www.google.com";
            ScreenshotHelper.TakeScreenshot(Driver);
            var files = Directory.GetFiles("C:\\Users\\james\\Desktop\\Screenshots\\", $"{date.Month}{date.Day}{date.Year}*", SearchOption.TopDirectoryOnly);
            Assert.IsTrue(files.Length > 0, "The screenshot doesn't exist in the specified file location.");
        }
    }
}
