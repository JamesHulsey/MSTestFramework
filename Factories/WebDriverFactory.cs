﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace MSTestFramework.Factories
{
    public class WebDriverFactory
    {
        [ThreadStatic]
        public static IWebDriver driver = null;

        public static IWebDriver GetDriver()
        {
            var browser = string.Empty;
            var startMaximized = false;
            var ignoreSslErrors = false;
            // checking if the "DownloadLocation" key in app.config has a value. if it does then use that value for the download location. if not then use the directory location
            var downloadDirectory = string.IsNullOrEmpty(ConfigurationManager.AppSettings["DownloadLocation"]?.ToString()) ? $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\downloads" : ConfigurationManager.AppSettings["DownloadLocation"].ToString(); 

            try
            {
                browser = ConfigurationManager.AppSettings["Browser"];
                startMaximized = bool.Parse(ConfigurationManager.AppSettings["StartMaximized"]);
                ignoreSslErrors = bool.Parse(ConfigurationManager.AppSettings["IgnoreSsl"]);
            } catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve app.config value. {e.Message}");
                Assert.Fail($"Failed to retrieve app.config value. {e.Message}");
            }

            try
            {
                switch (browser)
                {
                    case "c":
                    case "ch":
                        var chromeOptions = new ChromeOptions();
                        if (ignoreSslErrors) { chromeOptions.AcceptInsecureCertificates = true; } // ignoring ssl errors if applicable
                        if (browser.Equals("ch")) { chromeOptions.AddArguments("headless"); } // making the browser headless if applicable
                        chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                        chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                        driver = new ChromeDriver(chromeOptions);
                        MyLogger.Log.Info("Instantiated chrome driver.");
                        break;
                    case "ff":
                    case "fh":
                        var firefoxOptions = new FirefoxOptions();
                        if (ignoreSslErrors) { firefoxOptions.AcceptInsecureCertificates = true; } // ignoring ssl errors if applicable
                        if (browser.Equals("fh")) { firefoxOptions.AddArguments("--headless"); } // making the browser headless if applicable
                        firefoxOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                        var firefoxProfile = new FirefoxProfile();
                        firefoxProfile.SetPreference("browser.download.folderList", 2);
                        firefoxProfile.SetPreference("browser.download.dir", downloadDirectory); 
                        firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf,application/x-pdf,application/octet-stream"); //list of MIME types to save to disk without asking what to use to open the file
                        firefoxProfile.SetPreference("pdfjs.disabled", true);  // disable the built-in PDF viewer
                        firefoxOptions.Profile = firefoxProfile;
                        driver = new FirefoxDriver(firefoxOptions);
                        MyLogger.Log.Info("Instantiated firefox driver.");
                        break;
                    case "ie":
                        var ieOptions = new InternetExplorerOptions
                        {
                            RequireWindowFocus = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                            EnsureCleanSession = true,
                            IgnoreZoomLevel = true
                        };
                        driver = new InternetExplorerDriver(ieOptions);
                        MyLogger.Log.Info("Instantiated ie driver.");
                        break;
                    case "e":
                    case "eh":
                        var eOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions
                        {
                            UseChromium = true
                        };
                        if (ignoreSslErrors) { eOptions.AcceptInsecureCertificates = true; } // ignoring ssl errors if applicable
                        if (browser.Equals("eh")) { eOptions.AddArguments("--headless"); } // making the browser headless if applicable
                        eOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                        driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(eOptions);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                if (null != driver)
                {
                    driver.Close();
                    driver.Quit();
                }

                MyLogger.Log.Error($"Failed to instantiate driver. {e.Message}");
                Assert.Fail($"Failed to instantiate driver. {e.Message}");
            }
             
            if (startMaximized)
            {
                driver.Manage().Window.Maximize();
            }

            return driver;
        }
    }
}
