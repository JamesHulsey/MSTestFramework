using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Actions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Helpers
{
    public class BasePage
    {
        public ElementActions ElementActions { get; set; }
        public BrowserActions BrowserActions { get; set; }

        public BasePage(IWebDriver driver)
        {
            ElementActions = new ElementActions(driver);
            BrowserActions = new BrowserActions(driver);
        }
    }
}
