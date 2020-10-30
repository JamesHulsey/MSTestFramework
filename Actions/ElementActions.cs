using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Switches to an iFrame with the given name.
        /// </summary>
        /// <param name="frameName"></param>
        public void SwitchToFrame(string frameName)
        {
            try
            {
                driver.SwitchTo().Frame(frameName); 
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to switch to frame with name: {frameName}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Switches to an iFrame with the given index.
        /// </summary>
        /// <param name="frameIndex"></param>
        public void SwitchToFrame(int frameIndex)
        {
            try
            {
                driver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to switch to frame with index: {frameIndex}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Switches to an iFrame with the given IWebElement.
        /// </summary>
        /// <param name="frameElement"></param>
        public void SwitchToFrame(IWebElement frameElement)
        {
            try
            {
                driver.SwitchTo().Frame(frameElement);
            }
            catch (Exception e) 
            {
                MyLogger.Log.Error($"Failed to switch to frame with element: {frameElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Switches out of the iFrame and back to default content.
        /// </summary>
        public void SwitchToDefaultContent()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to switch to default content. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Clicks the given element.
        /// </summary>
        /// <param name="element"></param>
        public void Click(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to click element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Clicks the given element.
        /// </summary>
        /// <param name="element"></param>
        public void Click(By element)
        {
            try
            {
                driver.FindElement(element).Click();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to click element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Types the given text into the given element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void Type(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to enter text: {text} into element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Types the given text into the given element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void Type(By element, string text)
        {
            try
            {
                driver.FindElement(element).SendKeys(text);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to enter text: {text} into element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Clears the text from the given element.
        /// </summary>
        /// <param name="element"></param>
        public void Clear(IWebElement element)
        {
            try
            {
                element.Clear();
            }
            catch (Exception e) 
            {
                MyLogger.Log.Error($"Failed to clear element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Clears the text from the given element.
        /// </summary>
        /// <param name="element"></param>
        public void Clear(By element)
        {
            try
            {
                driver.FindElement(element).Clear();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to clear element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Submits the given element to the web server.
        /// </summary>
        /// <param name="element"></param>
        public void Submit(IWebElement element)
        {
            try
            {
                element.Submit();
            }
            catch (Exception e) 
            {
                MyLogger.Log.Error($"Failed to submit element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Submits the given element to the web server.
        /// </summary>
        /// <param name="element"></param>
        public void Submit(By element)
        {
            try
            {
                driver.FindElement(element).Submit();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to submit element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Retrieves the text value of the given element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public string GetText(IWebElement element)
        {
            string text;

            try
            {
                text = element.Text;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve text value from element: {element}. {e.Message}");
                throw e;
            }

            return text;
        }

        /// <summary>
        /// Retrieves the text value of the given element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public string GetText(By element)
        {
            string text;

            try
            {
                text = driver.FindElement(element).Text;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve text value from element: {element}. {e.Message}");
                throw e;
            }

            return text;
        }

        /// <summary>
        /// Checks if the given element is enabled.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsEnabled(IWebElement element)
        {
            bool isEnabled;

            try
            {
                isEnabled = element.Enabled;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check enabled status of element: {element}. {e.Message}");
                throw e;
            }

            return isEnabled;
        }

        /// <summary>
        /// Checks if the given element is enabled.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsEnabled(By element)
        {
            bool isEnabled;

            try
            {
                isEnabled = driver.FindElement(element).Enabled;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check enabled status of element: {element}. {e.Message}");
                throw e;
            }

            return isEnabled;
        }

        /// <summary>
        /// Checks if the given element is displayed.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsDisplayed(IWebElement element)
        {
            bool isDisplayed;

            try
            {
                isDisplayed = element.Displayed;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check displayed status of element: {element}. {e.Message}");
                throw e;
            }

            return isDisplayed;
        }

        /// <summary>
        /// Checks if the given element is displayed.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsDisplayed(By element)
        {
            bool isDisplayed;

            try
            {
                isDisplayed = driver.FindElement(element).Displayed;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check displayed status of element: {element}. {e.Message}");
                throw e;
            }

            return isDisplayed;
        }

        /// <summary>
        /// Checks if the given element is selected.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsSelected(IWebElement element)
        {
            bool isSelected;

            try
            {
                isSelected = element.Selected;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check selected status of element: {element}. {e.Message}");
                throw e;
            }

            return isSelected;
        }

        /// <summary>
        /// Checks if the given element is selected.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsSelected(By element)
        {
            bool isSelected;

            try
            {
                isSelected = driver.FindElement(element).Selected;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check selected status of element: {element}. {e.Message}");
                throw e;
            }

            return isSelected;
        }

        /// <summary>
        /// Retrieves a list of IWebElements matching the provided By object.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public IList<IWebElement> GetElementsAsList(By elements)
        {
            IList<IWebElement> elementList;

            try
            {
                elementList = driver.FindElements(elements);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve list of elements using: {elements}. {e.Message}");
                throw e;
            }

            return elementList;
        }

        /// <summary>
        /// Selects a dropdown value that matches the provided text.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="text"></param>
        public void SelectDropdownValueByText(IWebElement dropdownElement, string text)
        {
            try
            {
                var select = new SelectElement(dropdownElement);
                select.SelectByText(text);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to select text: {text} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Selects a dropdown value that matches the provided text.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="text"></param>
        public void SelectDropdownValueByText(By dropdownElement, string text)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(dropdownElement));
                select.SelectByText(text);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to select text: {text} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Selects a dropdown value with a matching "value" attribute.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="value"></param>
        public void SelectDropdownValueByValue(IWebElement dropdownElement, string value)
        {
            try
            {
                var select = new SelectElement(dropdownElement);
                select.SelectByValue(value);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to select value: {value} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Selects a dropdown value with a matching "value" attribute.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="value"></param>
        public void SelectDropdownValueByValue(By dropdownElement, string value)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(dropdownElement));
                select.SelectByValue(value);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to select value: {value} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Selects a dropdown value with a matching index.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="index"></param>
        public void SelectDropdownValueByIndex(IWebElement dropdownElement, int index)
        {
            try
            {
                var select = new SelectElement(dropdownElement);
                select.SelectByIndex(index);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to select index: {index} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Selects a dropdown value with a matching index.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="index"></param>
        public void SelectDropdownValueByIndex(By dropdownElement, int index)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(dropdownElement));
                select.SelectByIndex(index);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to select index: {index} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects a dropdown value based on the provided text.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="text"></param>
        public void DeselectDropdownValueByText(IWebElement dropdownElement, string text)
        {
            try
            {
                var select = new SelectElement(dropdownElement);
                select.DeselectByText(text);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select text: {text} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects a dropdown value based on the provided text.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="text"></param>
        public void DeselectDropdownValueByText(By dropdownElement, string text)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(dropdownElement));
                select.DeselectByText(text);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select text: {text} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects a dropdown value based on the "value" attribute.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="value"></param>
        public void DeselectDropdownValueByValue(IWebElement dropdownElement, string value)
        {
            try
            {
                var select = new SelectElement(dropdownElement);
                select.DeselectByValue(value);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select value: {value} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects a dropdown value based on the "value" attribute.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="value"></param>
        public void DeselectDropdownValueByValue(By dropdownElement, string value)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(dropdownElement));
                select.DeselectByValue(value);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select value: {value} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects a dropdown value based on the provided index.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="index"></param>
        public void DeselectDropdownValueByIndex(IWebElement dropdownElement, int index)
        {
            try
            {
                var select = new SelectElement(dropdownElement);
                select.DeselectByIndex(index);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select index: {index} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects a dropdown value based on the provided index.
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <param name="index"></param>
        public void DeselectDropdownValueByIndex(By dropdownElement, int index)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(dropdownElement));
                select.DeselectByIndex(index);
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select index: {index} from dropdown element: {dropdownElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects all the currently selected values from the given element.
        /// </summary>
        /// <param name="selectElement"></param>
        public void DeselectAll(IWebElement selectElement)
        {
            try
            {
                var select = new SelectElement(selectElement);
                select.DeselectAll();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select all selected options from select element: {selectElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Deselects all the currently selected values from the given element.
        /// </summary>
        /// <param name="selectElement"></param>
        public void DeselectAll(By selectElement)
        {
            try
            {
                var select = new SelectElement(driver.FindElement(selectElement));
                select.DeselectAll();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to de-select all selected options from select element: {selectElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Retrieves the currently selected option.
        /// </summary>
        /// <param name="selectElement"></param>
        /// <returns></returns>
        public IWebElement GetSelectedOption(IWebElement selectElement)
        {
            IWebElement selected;

            try
            {
                var select = new SelectElement(selectElement);
                selected = select.SelectedOption;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve currently selected option from select element: {selectElement}. {e.Message}");
                throw e;
            }

            return selected;
        }

        /// <summary>
        /// Retrieves the currently selected option.
        /// </summary>
        /// <param name="selectElement"></param>
        /// <returns></returns>
        public IWebElement GetSelectedOption(By selectElement)
        {
            IWebElement selected;

            try
            {
                var select = new SelectElement(driver.FindElement(selectElement));
                selected = select.SelectedOption;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve currently selected option from select element: {selectElement}. {e.Message}");
                throw e;
            }

            return selected;
        }

        /// <summary>
        /// Retrieves all currently selected options.
        /// </summary>
        /// <param name="selectElement"></param>
        /// <returns></returns>
        public IList<IWebElement> GetAllSelectedOptions(IWebElement selectElement)
        {
            IList<IWebElement> selected;

            try
            {
                var select = new SelectElement(selectElement);
                selected = select.AllSelectedOptions;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve all currently selected options from element: {selectElement}. {e.Message}");
                throw e;
            }

            return selected;
        }

        /// <summary>
        /// Retrieves all currently selected options.
        /// </summary>
        /// <param name="selectElement"></param>
        /// <returns></returns>
        public IList<IWebElement> GetAllSelectedOptions(By selectElement)
        {
            IList<IWebElement> selected;

            try
            {
                var select = new SelectElement(driver.FindElement(selectElement));
                selected = select.AllSelectedOptions;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to retrieve all currently selected options from element: {selectElement}. {e.Message}");
                throw e;
            }

            return selected;
        }

        /// <summary>
        /// Checks if provided element is a multi-select element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsMultiSelect(IWebElement element)
        {
            bool isMulti;

            try
            {
                var select = new SelectElement(element);
                isMulti = select.IsMultiple;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check if element: {element} is multi-select. {e.Message}");
                throw e;
            }

            return isMulti;
        }

        /// <summary>
        /// Waits for the provided element to be visible.
        /// <para />
        /// The default wait timeout is 30 seconds but can be overridden for another value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="maxTimeoutInSeconds"></param>
        public void WaitForElementToBeVisible(By element, int maxTimeoutInSeconds = 30)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeoutInSeconds)).Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to wait for element: {element} to be visible. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Waits for an alert to be visible.
        /// <para />
        /// The default wait timeout is 30 seconds but can be overridden for another value.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="maxTimeoutInSeconds"></param>
        public void WaitForAlertToBeVisible(int maxTimeoutInSeconds = 30)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeoutInSeconds)).Until(ExpectedConditions.AlertIsPresent());
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to wait for alert to be visible. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Drags the <paramref name="sourceElement"/> to the <paramref name="destinationElement"/>.
        /// </summary>
        /// <param name="sourceElement"></param>
        /// <param name="destinationElement"></param>
        public void DragAndDrop(IWebElement sourceElement, IWebElement destinationElement)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.DragAndDrop(sourceElement, destinationElement);
                builder.Build().Perform();
            } catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to drag source element: {sourceElement} to destination element: {destinationElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Drags the <paramref name="sourceElement"/> to the <paramref name="destinationElement"/>.
        /// </summary>
        /// <param name="sourceElement"></param>
        /// <param name="destinationElement"></param>
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
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to drag source element: {sourceElement} to destination element: {destinationElement}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Hovers the mouse pointer over the provided element.
        /// </summary>
        /// <param name="element"></param>
        public void Hover(IWebElement element)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to hover over element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Hovers the mouse pointer over the provided element.
        /// </summary>
        /// <param name="element"></param>
        public void Hover(By element)
        {
            try
            {
                var builder = new OpenQA.Selenium.Interactions.Actions(driver);
                builder.MoveToElement(driver.FindElement(element)).Perform();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to hover over element: {element}. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Checks if an alert is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsAlertDisplayed()
        {
            bool isDisplayed;

            try
            {
                driver.SwitchTo().Alert();
                isDisplayed = true;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to check if an alert is displayed. {e.Message}");
                throw e;
            }

            return isDisplayed;
        }

        /// <summary>
        /// Accepts the currently open alert.
        /// </summary>
        public void AcceptAlert()
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to accept alert. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Dismisses the currently open alert.
        /// </summary>
        public void DismissAlert()
        {
            try
            {
                driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to dismiss alert. {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Retrieves the currently open alert text.
        /// </summary>
        /// <returns></returns>
        public string GetAlertText()
        {
            string text;

            try
            {
                text = driver.SwitchTo().Alert().Text;
            }
            catch (Exception e) 
            {
                MyLogger.Log.Error($"Failed to retrieve alert text. {e.Message}");
                throw e;
            }

            return text;
        }

        /// <summary>
        /// PROTOTYPE!!!!
        /// <para />
        /// Retrieves the provided element. Will attempt to cycle through iFrames found in the DOM to find the element if <see cref="NoSuchElementException"/> is thrown.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public IWebElement FindElement(By element)
        {
            try
            {
                return driver.FindElement(element);
            }
            catch (NoSuchElementException)
            {
                // if the element wasnt found initially then we will check if its inside an iframe
                try
                {
                    return SwitchToFrameAndFindElement(element);
                }
                catch (Exception e)
                {
                    MyLogger.Log.Error($"Failed to find element: {element}. {e.Message}");
                    throw e;
                }
            }
        }

        private IWebElement SwitchToFrameAndFindElement(By element)
        {
            // getting a row of iframes if they exist
            var frames = driver.FindElements(By.XPath("//iframe"));

            // checking if iframe count is greater than 1
            if (frames.Count > 1)
            {
                // iterates through each iframe to check for the element
                foreach (var frame in frames)
                {
                    driver.SwitchTo().Frame(frame);

                    try
                    {
                        return driver.FindElement(element);
                    } catch (Exception)
                    {
                        // recursively goes back into the method to check if there are nested iframes from the current iframe
                        return SwitchToFrameAndFindElement(element);
                    }
                }
            } else if (frames.Count == 1)
            {
                // switching to the only iframe in the list
                driver.SwitchTo().Frame(frames.First());

                try
                {
                    return driver.FindElement(element);
                }
                catch (Exception)
                {
                    // recursively goes back into the method to check if there are nested iframes from the current iframe
                    return SwitchToFrameAndFindElement(element);
                }
            }

            return null;
        }
    }
}
