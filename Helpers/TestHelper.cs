using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Factories;
using OpenQA.Selenium;
using System;

namespace MSTestFramework.Helpers
{
    public class TestHelper
    {
        [ThreadStatic]
        private static TestContext testContext;
        public TestContext TestContext { get; set; }

        [ThreadStatic]
        public static IWebDriver Driver = null;

        [TestInitialize]
        public void SetupDriver()
        {
            try
            {
                testContext = TestContext;
            } catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to set the test context object with {TestContext}. {e.Message}");
                Assert.Fail($"Failed to set the test context object with {TestContext}. {e.Message}");
            }

            try
            {
                if ("ui".Equals(testContext.Properties["TestType"]?.ToString().ToLower()))
                {
                    Driver = WebDriverFactory.GetDriver();
                }
            } catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to create driver. {e.Message}");
                Assert.Fail($"Failed to create driver. {e.Message}");
            }            
        }

        [TestCleanup]
        public void CloseDriver()
        {
            if (null != Driver)
            {
                // checking for alert to close before stopping driver
                try
                {
                    Driver.SwitchTo().Alert().Dismiss();
                }
                catch (Exception)
                {
                    // do nothing if no alert exists
                }

                Driver.Close();
                Driver.Quit();
            }
        }
    }
}
