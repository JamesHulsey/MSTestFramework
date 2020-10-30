using MSTestFramework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Actions
{
    public class BrowserActions
    {
        private readonly IWebDriver driver;

        public BrowserActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Retrieves the current page title.
        /// </summary>
        /// <returns></returns>
        public string GetPageTitle()
        {
            string title;

            try
            {
                title = driver.Title;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve current page title. {e.Message}");
                throw e;
            }

            return title;
        }

        /// <summary>
        /// Retrieves the focused browser url.
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            string url;

            try
            {
                url = driver.Url;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve browser url. {e.Message}");
                throw e;
            }

            return url;
        }

        /// <summary>
        /// Switches to the newest window. Will also switch to the last window in the list of currently opened browser windows.
        /// </summary>
        public void SwitchToNewestWindow()
        {
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception e) 
            {
                MyLogger.Log.Error($"Failed to switch to last window in list. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Switches to the window with a matching window name.
        /// </summary>
        /// <param name="windowName"></param>
        public void SwitchToWindow(string windowName)
        {
            try
            {
                driver.SwitchTo().Window(windowName);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to switch to window with name: {windowName}. {e.Message}");
                throw e;
            }
        }
    }
}
