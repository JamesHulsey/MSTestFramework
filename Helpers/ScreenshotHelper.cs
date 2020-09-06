using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace MSTestFramework.Helpers
{
    public class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string screenshotFileName = "", string screenshotFileLocation = "")
        {
            var date = DateTime.Now;
            var name = string.IsNullOrEmpty(screenshotFileName) ? $"{date.Month}{date.Day}{date.Year}_{date.Hour}{date.Minute}{date.Second}" : screenshotFileName;
            var screenshotDriver = driver as ITakesScreenshot;
            var screenshot = screenshotDriver.GetScreenshot();

            if (string.IsNullOrEmpty(screenshotFileLocation))
            {
                screenshot.SaveAsFile($"C:\\Users\\james\\Desktop\\Screenshots\\{name}.png", ScreenshotImageFormat.Png);
            } else
            {
                screenshot.SaveAsFile($"{screenshotFileLocation}\\{name}");
            }
        }
    }
}
