using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MSTestFramework.Actions
{
    public class ElementActions
    {
        private readonly IWebDriver driver;

        public ElementActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToFrame(string frameName)
        {
            try
            {
                driver.SwitchTo().Frame(frameName); 
            }
            catch (Exception)
            {

            }
        }

        public void SwitchToFrame(int frameIndex)
        {
            try
            {
                driver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception)
            {

            }
        }

        public void SwitchToFrame(IWebElement frameElement)
        {
            try
            {
                driver.SwitchTo().Frame(frameElement);
            }
            catch (Exception)
            {

            }
        }

        public void SwitchToDefaultContent()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception)
            {

            }
        }

        public void Click(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception)
            {

            }
        }

        public void Click(By element)
        {
            try
            {
                driver.FindElement(element).Click();
            }
            catch (Exception)
            {
            }
        }

        public void Type(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception)
            {

            }
        }

        public void Type(By element, string text)
        {
            try
            {
                driver.FindElement(element).SendKeys(text);
            }
            catch (Exception)
            {

            }
        }

        public void Clear(IWebElement element)
        {
            try
            {
                element.Clear();
            }
            catch (Exception)
            {

            }
        }

        public void Clear(By element)
        {
            try
            {
                driver.FindElement(element).Clear();
            }
            catch (Exception)
            {

            }
        }

        public void Submit(IWebElement element)
        {
            try
            {
                element.Submit();
            }
            catch (Exception)
            {

            }
        }

        public void Submit(By element)
        {
            try
            {
                driver.FindElement(element).Submit();
            }
            catch (Exception)
            {

            }
        }

        public string GetText(IWebElement element)
        {
            var text = string.Empty;

            try
            {
                text = element.Text;
            }
            catch (Exception)
            {

            }

            return text;
        }

        public string GetText(By element)
        {
            var text = string.Empty;

            try
            {
                text = driver.FindElement(element).Text;
            }
            catch (Exception)
            {

            }

            return text;
        }

        public bool IsEnabled(IWebElement element)
        {
            bool isEnabled = false;

            try
            {
                isEnabled = element.Enabled;
            }
            catch (Exception)
            {

            }

            return isEnabled;
        }

        public bool IsEnabled(By element)
        {
            bool isEnabled = false;

            try
            {
                isEnabled = driver.FindElement(element).Enabled;
            }
            catch (Exception)
            {

            }

            return isEnabled;
        }

        public bool IsDisplayed(IWebElement element)
        {
            bool isDisplayed = false;

            try
            {
                isDisplayed = element.Displayed;
            }
            catch (Exception)
            {

            }

            return isDisplayed;
        }

        public bool IsDisplayed(By element)
        {
            bool isDisplayed = false;

            try
            {
                isDisplayed = driver.FindElement(element).Displayed;
            }
            catch (Exception)
            {

            }

            return isDisplayed;
        }

        public bool IsSelected(IWebElement element)
        {
            bool isSelected = false;

            try
            {
                isSelected = element.Selected;
            }
            catch (Exception)
            {

            }

            return isSelected;
        }

        public bool IsSelected(By element)
        {
            bool isSelected = false;

            try
            {
                isSelected = driver.FindElement(element).Selected;
            }
            catch (Exception)
            {

            }

            return isSelected;
        }

        public IList<IWebElement> GetElementsAsList(By element)
        {
            IList<IWebElement> elements = null;

            try
            {
                elements = driver.FindElements(element);
            }
            catch (Exception)
            {

            }

            return elements;
        }

        public void SelectDropdownValueByText(IWebElement element, string text)
        {
            try
            {
                var select = new SelectElement(element);
                select.SelectByText(text);
            }
            catch (Exception)
            {

            }
        }

        public void SelectDropdownValueByText(By element, string text)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.SelectByText(text);
            }
            catch (Exception)
            {

            }
        }

        public void SelectDropdownValueByValue(IWebElement element, string value)
        {
            try
            {
                var select = new SelectElement(element);
                select.SelectByValue(value);
            }
            catch (Exception)
            {

            }
        }

        public void SelectDropdownValueByValue(By element, string value)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.SelectByValue(value);
            }
            catch (Exception)
            {

            }
        }

        public void SelectDropdownValueByIndex(IWebElement element, int index)
        {
            try
            {
                var select = new SelectElement(element);
                select.SelectByIndex(index);
            }
            catch (Exception)
            {

            }
        }

        public void SelectDropdownValueByIndex(By element, int index)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.SelectByIndex(index);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectDropdownValueByText(IWebElement element, string text)
        {
            try
            {
                var select = new SelectElement(element);
                select.DeselectByText(text);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectDropdownValueByText(By element, string text)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.DeselectByText(text);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectDropdownValueByValue(IWebElement element, string value)
        {
            try
            {
                var select = new SelectElement(element);
                select.DeselectByValue(value);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectDropdownValueByValue(By element, string value)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.DeselectByValue(value);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectDropdownValueByIndex(IWebElement element, int index)
        {
            try
            {
                var select = new SelectElement(element);
                select.DeselectByIndex(index);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectDropdownValueByIndex(By element, int index)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.DeselectByIndex(index);
            }
            catch (Exception)
            {

            }
        }

        public void DeselectAll(IWebElement element)
        {
            try
            {
                var select = new SelectElement(element);
                select.DeselectAll();
            }
            catch (Exception)
            {

            }
        }

        public void DeselectAll(By element)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(element));
                select.DeselectAll();
            }
            catch (Exception)
            {

            }
        }

        public IWebElement GetSelectedOption(IWebElement element)
        {
            IWebElement selected = null;

            try
            {
                var select = new SelectElement(element);
                selected = select.SelectedOption;
            }
            catch (Exception)
            {

            }

            return selected;
        }

        public IWebElement GetSelectedOption(By element)
        {
            IWebElement selected = null;

            try
            {
                var select = new SelectElement(driver.FindElement(element));
                selected = select.SelectedOption;
            }
            catch (Exception)
            {

            }

            return selected;
        }

        public IList<IWebElement> GetAllSelectedOptions(IWebElement element)
        {
            IList<IWebElement> selected = null;

            try
            {
                var select = new SelectElement(element);
                selected = select.AllSelectedOptions;
            }
            catch (Exception)
            {

            }

            return selected;
        }

        public IList<IWebElement> GetAllSelectedOptions(By element)
        {
            IList<IWebElement> selected = null;

            try
            {
                var select = new SelectElement(driver.FindElement(element));
                selected = select.AllSelectedOptions;
            }
            catch (Exception)
            {

            }

            return selected;
        }

        public bool IsMultiSelect(IWebElement element)
        {
            bool isMulti = false;

            try
            {
                var select = new SelectElement(element);
                isMulti = select.IsMultiple;
            }
            catch (Exception)
            {

            }

            return isMulti;
        }

        public void WaitForElementToBeVisible(By element, int maxTimeoutInSeconds = 30)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeoutInSeconds)).Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception)
            {

            }
        }

        public void WaitForAlertToBeVisible(int maxTimeoutInSeconds = 30)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeoutInSeconds)).Until(ExpectedConditions.AlertIsPresent());
            }
            catch (Exception)
            {

            }
        }

        public void DragAndDrop(IWebElement sourceElement, IWebElement destinationElement)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.DragAndDrop(sourceElement, destinationElement);
                builder.Build().Perform();
            } catch (Exception)
            {

            }
        }

        public void DragAndDrop(By sourceElement, By destinationElement)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.ClickAndHold(driver.FindElement(sourceElement));
                builder.MoveToElement(driver.FindElement(destinationElement));
                builder.Release();
                builder.Build();
                builder.Perform();
            }
            catch (Exception)
            {

            }
        }

        public void Hover(IWebElement element)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            catch (Exception)
            {

            }
        }

        public void Hover(By element)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.MoveToElement(driver.FindElement(element)).Perform();
            }
            catch (Exception)
            {

            }
        }

        public bool IsAlertDisplayed()
        {
            var isDisplayed = false;

            try
            {
                driver.SwitchTo().Alert();
                isDisplayed = true;
            }
            catch (Exception)
            {

            }

            return isDisplayed;
        }

        public void AcceptAlert()
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception)
            {

            }
        }

        public void DismissAlert()
        {
            try
            {
                driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception)
            {

            }
        }

        public string GetAlertText()
        {
            var text = string.Empty;

            try
            {
                text = driver.SwitchTo().Alert().Text;
            }
            catch (Exception)
            {

            }

            return text;
        }
    }
}
