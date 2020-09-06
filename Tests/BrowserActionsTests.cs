using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Actions;
using MSTestFramework.DataProvider;
using MSTestFramework.Helpers;
using NLog.Internal;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class BrowserActionsTests : TestHelper
    {
        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void PageTitleTest()
        {
            var browserActions = new BrowserActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.AreEqual("The Internet", browserActions.GetPageTitle(), "The page titles didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void UrlTest()
        {
            var browserActions = new BrowserActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.AreEqual("http://the-internet.herokuapp.com/", browserActions.GetUrl(), "The url's didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SwitchToNewestWindowTest()
        {
            var browserActions = new BrowserActions(Driver);
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Multiple Windows']"));
            elementActions.Click(By.XPath("//a[text()='Click Here']"));
            browserActions.SwitchToNewestWindow();
            Assert.AreEqual("New Window", browserActions.GetPageTitle(), "The newest window page title didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SwitchToWindowWithNameTest()
        {
            var browserActions = new BrowserActions(Driver);
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Multiple Windows']"));
            elementActions.Click(By.XPath("//a[text()='Click Here']"));
            var windows = Driver.WindowHandles;
            browserActions.SwitchToWindow(windows.Last());
            Assert.AreEqual("New Window", browserActions.GetPageTitle(), "The newest window page title didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DownloadFileTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='File Download']"));
            var items = elementActions.GetElementsAsList(By.XPath("//div[@class='example']/a"));
            var downloadFile = items[1].Text;
            FileHelper.DeleteFile($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\", downloadFile);
            elementActions.Click(items[1]);
            FileHelper.WaitForFileDownload($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\", downloadFile);
            Assert.IsTrue(File.Exists($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\{downloadFile}"), "The file wasn't downloaded successfully.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void CustomDownloadFileLocationTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='File Download']"));
            var items = elementActions.GetElementsAsList(By.XPath("//div[@class='example']/a"));
            var downloadFile = items[1].Text;
            FileHelper.DeleteFile($"{System.Configuration.ConfigurationManager.AppSettings["DownloadLocation"]}\\", downloadFile);
            elementActions.Click(items[1]);
            FileHelper.WaitForFileDownload($"{System.Configuration.ConfigurationManager.AppSettings["DownloadLocation"]}\\", downloadFile);
            Assert.IsTrue(File.Exists($"{System.Configuration.ConfigurationManager.AppSettings["DownloadLocation"]}\\{downloadFile}"), "The file wasn't downloaded successfully.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeleteFileTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='File Download']"));
            var items = elementActions.GetElementsAsList(By.XPath("//div[@class='example']/a"));
            var downloadFile = items[1].Text;
            FileHelper.DeleteFile($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\", downloadFile);
            elementActions.Click(items[1]);
            FileHelper.WaitForFileDownload($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\", downloadFile);
            FileHelper.DeleteFile($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\", downloadFile);
            Assert.IsFalse(File.Exists($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads\\{downloadFile}"), "The file wasn't deleted successfully.");
        }
    }
}
