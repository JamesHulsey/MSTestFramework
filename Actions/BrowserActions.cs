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

        public string GetPageTitle()
        {
            var title = string.Empty;

            try
            {
                title = driver.Title;
            }
            catch (Exception)
            {

            }

            return title;
        }

        public string GetUrl()
        {
            var url = string.Empty;

            try
            {
                url = driver.Url;
            }
            catch (Exception)
            {

            }

            return url;
        }

        public void SwitchToNewestWindow()
        {
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception)
            {

            }
        }

        public void SwitchToWindow(string windowName)
        {
            try
            {
                driver.SwitchTo().Window(windowName);
            }
            catch (Exception)
            {

            }
        }
    }
}
