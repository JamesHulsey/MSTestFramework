using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Actions;
using MSTestFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MSTestFramework.Tests
{
    [TestClass]
    public class ElementActionsTests : TestHelper
    {
        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void ClickByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='A/B Testing']"));
            Assert.IsTrue(Driver.Url.Contains("/abtest"), "URL didn't contain '/abtest'.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void ClickIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='A/B Testing']")));
            Assert.IsTrue(Driver.Url.Contains("/abtest"), "URL didn't contain '/abtest'.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void TypeByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Forgot Password']")));
            new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='email']")));
            elementActions.Type(By.XPath("//input[@id='email']"), "james");
            Assert.AreEqual("james", Driver.FindElement(By.Id("email")).GetAttribute("value"), "The textbox values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void TypeIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Forgot Password']")));
            elementActions.Type(Driver.FindElement(By.XPath("//input[@id='email']")), "james");
            Assert.AreEqual("james", Driver.FindElement(By.Id("email")).GetAttribute("value"), "The textbox values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void ClearByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            MyLogger.Log.Info("went to a url");
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Forgot Password']")));
            MyLogger.Log.Info("clicked a thing");
            new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='email']")));
            elementActions.Type(By.XPath("//input[@id='email']"), "james");
            MyLogger.Log.Info("entered james");
            elementActions.Clear(By.XPath("//input[@id='email']"));
            MyLogger.Log.Info("cleared a thing");
            Assert.AreEqual(string.Empty, Driver.FindElement(By.Id("email")).GetAttribute("value"), "The textbox values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void ClearIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Forgot Password']")));
            elementActions.Type(Driver.FindElement(By.XPath("//input[@id='email']")), "james");
            elementActions.Clear(Driver.FindElement(By.XPath("//input[@id='email']")));
            Assert.AreEqual(string.Empty, Driver.FindElement(By.Id("email")).GetAttribute("value"), "The textbox values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetTextByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.AreEqual("Welcome to the-internet", elementActions.GetText(By.XPath("//h1")), "The text didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetTextIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.AreEqual("Welcome to the-internet", elementActions.GetText(Driver.FindElement(By.XPath("//h1"))), "The text didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsEnabledByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.IsTrue(elementActions.IsEnabled(By.XPath("//a[text()='A/B Testing']")), "The A/B link wasn't enabled.");

        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsEnabledIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.IsTrue(elementActions.IsEnabled(Driver.FindElement(By.XPath("//a[text()='A/B Testing']"))), "The A/B link wasn't enabled.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsDisplayedByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.IsTrue(elementActions.IsDisplayed(By.XPath("//a[text()='A/B Testing']")), "The A/B link wasn't displayed.");

        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsDisplayedIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.IsTrue(elementActions.IsDisplayed(Driver.FindElement(By.XPath("//a[text()='A/B Testing']"))), "The A/B link wasn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsSelectedByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Checkboxes']"));
            elementActions.Click(By.XPath("//form[@id='checkboxes']/input[1]"));
            Assert.IsTrue(elementActions.IsSelected(By.XPath("//form[@id='checkboxes']/input[1]")), "The checkbox wasn't selected.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsSelectedIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Checkboxes']"));
            elementActions.Click(By.XPath("//form[@id='checkboxes']/input[1]"));
            Assert.IsTrue(elementActions.IsSelected(Driver.FindElement(By.XPath("//form[@id='checkboxes']/input[1]"))), "The checkbox wasn't selected.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetElementsAsListTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            Assert.IsTrue(elementActions.GetElementsAsList(By.XPath("//ul/li")).Count > 0, "Element list wasn't created.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SelectDropdownValueByTextByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Dropdown']")));
            elementActions.SelectDropdownValueByText(By.Id("dropdown"), "Option 1");
            Assert.AreEqual("Option 1", elementActions.GetSelectedOption(By.Id("dropdown")).Text, "The selected dropdown values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SelectDropdownValueByTextIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Dropdown']")));
            elementActions.SelectDropdownValueByText(Driver.FindElement(By.Id("dropdown")), "Option 1");
            Assert.AreEqual("Option 1", elementActions.GetSelectedOption(Driver.FindElement(By.Id("dropdown"))).Text, "The selected dropdown values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SelectDropdownValueByValueByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Dropdown']")));
            elementActions.SelectDropdownValueByValue(By.Id("dropdown"), "1");
            Assert.AreEqual("Option 1", elementActions.GetSelectedOption(By.Id("dropdown")).Text, "The selected dropdown values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SelectDropdownValueByValueIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Dropdown']")));
            elementActions.SelectDropdownValueByValue(Driver.FindElement(By.Id("dropdown")), "1");
            Assert.AreEqual("Option 1", elementActions.GetSelectedOption(Driver.FindElement(By.Id("dropdown"))).Text, "The selected dropdown values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SelectDropdownValueByIndexByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Dropdown']")));
            elementActions.SelectDropdownValueByIndex(By.Id("dropdown"), 1);
            Assert.AreEqual("Option 1", elementActions.GetSelectedOption(By.Id("dropdown")).Text, "The selected dropdown values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void SelectDropdownValueByIndexIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(Driver.FindElement(By.XPath("//a[text()='Dropdown']")));
            elementActions.SelectDropdownValueByIndex(Driver.FindElement(By.Id("dropdown")), 1);
            Assert.AreEqual("Option 1", elementActions.GetSelectedOption(Driver.FindElement(By.Id("dropdown"))).Text, "The selected dropdown values didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectDropdownValueByTextByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.AreEqual("BMW", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected dropdown values didn't match.");
            elementActions.DeselectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.IsNull(elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")), "The selected dropdown option wasn't null.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectDropdownValueByTextIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.AreEqual("BMW", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected dropdown values didn't match.");
            elementActions.DeselectDropdownValueByText(Driver.FindElement(By.XPath("//select[@name='cars']")), "BMW");
            Assert.IsNull(elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")), "The selected dropdown option wasn't null.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectDropdownValueByValueByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.AreEqual("BMW", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected dropdown values didn't match.");
            elementActions.DeselectDropdownValueByValue(By.XPath("//select[@name='cars']"), "B");
            Assert.IsNull(elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")), "The selected dropdown option wasn't null.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectDropdownValueByValueIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.AreEqual("BMW", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected dropdown values didn't match.");
            elementActions.DeselectDropdownValueByValue(Driver.FindElement(By.XPath("//select[@name='cars']")), "B");
            Assert.IsNull(elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")), "The selected dropdown option wasn't null.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectDropdownValueByIndexByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.AreEqual("BMW", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected dropdown values didn't match.");
            elementActions.DeselectDropdownValueByIndex(By.XPath("//select[@name='cars']"), 2);
            Assert.IsNull(elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")), "The selected dropdown option wasn't null.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectDropdownValueByValueIndexTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.AreEqual("BMW", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected dropdown values didn't match.");
            elementActions.DeselectDropdownValueByIndex(Driver.FindElement(By.XPath("//select[@name='cars']")), 2);
            Assert.IsNull(elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")), "The selected dropdown option wasn't null.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectAllByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.IsTrue(elementActions.GetAllSelectedOptions(By.XPath("//select[@name='cars']")).Count == 2, "The total selected dropdown options wasn't 2.");
            elementActions.DeselectAll(By.XPath("//select[@name='cars']"));
            Assert.IsTrue(elementActions.GetAllSelectedOptions(By.XPath("//select[@name='cars']")).Count == 0, "The total selected dropdown options wasn't 0.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DeselectAllIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.IsTrue(elementActions.GetAllSelectedOptions(By.XPath("//select[@name='cars']")).Count == 2, "The total selected dropdown options wasn't 2.");
            elementActions.DeselectAll(Driver.FindElement(By.XPath("//select[@name='cars']")));
            Assert.IsTrue(elementActions.GetAllSelectedOptions(By.XPath("//select[@name='cars']")).Count == 0, "The total selected dropdown options wasn't 0.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetAllSelectedOptionsByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.IsTrue(elementActions.GetAllSelectedOptions(By.XPath("//select[@name='cars']")).Count == 2, "The total selected dropdown options wasn't 2.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetAllSelectedOptionsIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.IsTrue(elementActions.GetAllSelectedOptions(Driver.FindElement(By.XPath("//select[@name='cars']"))).Count == 2, "The total selected dropdown options wasn't 2.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetSelectedOptionByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            Assert.AreEqual("Honda", elementActions.GetSelectedOption(By.XPath("//select[@name='cars']")).Text, "The selected options didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetSelectedOptionIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            Assert.AreEqual("Honda", elementActions.GetSelectedOption(Driver.FindElement(By.XPath("//select[@name='cars']"))).Text, "The selected options didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsMultiSelectTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://automate-apps.com/select-multiple-options-from-a-drop-down-list/";
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "Honda");
            elementActions.SelectDropdownValueByText(By.XPath("//select[@name='cars']"), "BMW");
            Assert.IsTrue(elementActions.GetAllSelectedOptions(Driver.FindElement(By.XPath("//select[@name='cars']"))).Count == 2, "The total selected dropdown options wasn't 2.");
        }

        [TestMethod, Ignore("drag and drop sucks")]
        [TestProperty("TestType", "UI")]
        public void DragAndDropByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Drag and Drop']"));
            Assert.AreEqual("A", Driver.FindElement(By.XPath("//div[@id='columns']/div[1]/header")).Text);
            elementActions.DragAndDrop(By.Id("column-a"), By.Id("column-b"));
            Assert.AreEqual("B", Driver.FindElement(By.XPath("//div[@id='columns']/div[1]/header")).Text, "The boxes didn't drag and drop.");
        }

        [TestMethod, Ignore("drag and drop sucks")]
        [TestProperty("TestType", "UI")]
        public void DragAndDropIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Drag and Drop']"));
            Assert.AreEqual("A", Driver.FindElement(By.XPath("//div[@id='columns']/div[1]/header")).Text);
            elementActions.DragAndDrop(Driver.FindElement(By.Id("column-a")), Driver.FindElement(By.Id("column-b")));
            Assert.AreEqual("B", Driver.FindElement(By.XPath("//div[@id='columns']/div[1]/header")).Text, "The boxes didn't drag and drop.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void HoverIWebElementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Hovers']"));
            Assert.IsFalse(elementActions.IsDisplayed(By.XPath("//h5[text()='name: user1']")), "The specified text isn't displayed.");
            elementActions.Hover(Driver.FindElement(By.XPath("//div[@class='figure'][1]")));
            Assert.IsTrue(elementActions.IsDisplayed(By.XPath("//h5[text()='name: user1']")), "The specified text isn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void HoverByTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Hovers']"));
            Assert.IsFalse(elementActions.IsDisplayed(By.XPath("//h5[text()='name: user1']")), "The specified text isn't displayed.");
            elementActions.Hover(By.XPath("//div[@class='figure'][1]"));
            Assert.IsTrue(elementActions.IsDisplayed(By.XPath("//h5[text()='name: user1']")), "The specified text isn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IframeNameTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Frames']"));
            elementActions.Click(By.XPath("//li/a[text()='iFrame']"));
            Assert.IsFalse(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text is displayed.");
            elementActions.SwitchToFrame("mce_0_ifr");
            Assert.IsTrue(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text isn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IframeIndexTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Frames']"));
            elementActions.Click(By.XPath("//li/a[text()='iFrame']"));
            Assert.IsFalse(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text isn't displayed.");
            elementActions.SwitchToFrame(0);
            Assert.IsTrue(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text isn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IframeIWebelementTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Frames']"));
            elementActions.Click(By.XPath("//li/a[text()='iFrame']"));
            Assert.IsFalse(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text isn't displayed.");
            elementActions.SwitchToFrame(Driver.FindElement(By.Id("mce_0_ifr")));
            Assert.IsTrue(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text isn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DefaultContentTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='Frames']"));
            elementActions.Click(By.XPath("//li/a[text()='iFrame']"));
            Assert.IsFalse(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text is displayed.");
            elementActions.SwitchToFrame(Driver.FindElement(By.Id("mce_0_ifr")));
            Assert.IsTrue(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text isn't displayed.");
            elementActions.SwitchToDefaultContent();
            Assert.IsFalse(elementActions.IsDisplayed(By.Id("tinymce")), "The specified text is displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void IsAlertDisplayedTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='JavaScript Alerts']"));
            elementActions.Click(By.XPath("//button[text()='Click for JS Alert']"));
            elementActions.WaitForAlertToBeVisible(30);
            Assert.IsTrue(elementActions.IsAlertDisplayed(), "Alert wasn't displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void GetAlertTextTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='JavaScript Alerts']"));
            elementActions.Click(By.XPath("//button[text()='Click for JS Alert']"));
            var text = elementActions.GetAlertText();
            Assert.AreEqual("I am a JS Alert", text, "The alert text didn't match.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void AcceptAlertTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='JavaScript Alerts']"));
            elementActions.Click(By.XPath("//button[text()='Click for JS Confirm']"));
            Assert.IsTrue(elementActions.IsAlertDisplayed(), "Alert wasn't displayed.");
            elementActions.AcceptAlert();
            Assert.IsFalse(elementActions.IsAlertDisplayed(), "Alert was still displayed.");
        }

        [TestMethod]
        [TestProperty("TestType", "UI")]
        public void DismissAlertTest()
        {
            var elementActions = new ElementActions(Driver);
            Driver.Url = "http://the-internet.herokuapp.com/";
            elementActions.Click(By.XPath("//a[text()='JavaScript Alerts']"));
            elementActions.Click(By.XPath("//button[text()='Click for JS Confirm']"));
            Assert.IsTrue(elementActions.IsAlertDisplayed(), "Alert wasn't displayed.");
            elementActions.DismissAlert();
            Assert.IsFalse(elementActions.IsAlertDisplayed(), "Alert was still displayed.");
        }
    }
}
