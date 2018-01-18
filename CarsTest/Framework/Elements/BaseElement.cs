using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CarsTest
{
    public class BaseElement: BaseEntity
    {
        public By Locator { get; protected set; }
        public IWebElement WebElement { get; protected set; }

        protected void CreateNew(By locator)
        {            
            Locator = locator;
            WaitPageToLoad();
            WaitUntilLocated(locator);
            WebElement = browser.driver.FindElement(locator);
        }

        protected IWebElement FindWebElement(By locator)
        {
            return browser.driver.FindElement(locator);
        }

        public string getAttribute(By locator, string attributeName)
        {
            return browser.driver.FindElement(locator).GetAttribute(attributeName);
        }

        public object getAttributeByJS(IWebElement element, string attributeName)
        {
            return ((IJavaScriptExecutor)browser.driver).ExecuteScript("return arguments[0]."+attributeName, element);
        }

        public void ClickAndWait_ViaJS()
        {
            WaitUntilClickable(Locator);
            Click_ViaJS();
            WaitPageToLoad();
        }

        public void ClickAndWait_ViaAction()
        {
            WaitUntilClickable(Locator);
            Click_ViaAction();
            WaitPageToLoad();
        }

        public void ClickAndWait()
        {
            WaitUntilClickable(Locator);
            WebElement.Click();
            WaitPageToLoad();
        }

        public void Click_ViaJS()
        {
            WaitUntilClickable(Locator);
            var js = (IJavaScriptExecutor)browser.driver;
            js.ExecuteScript("arguments[0].click();", WebElement);
        }

        public void Click_ViaAction()
        {
            WaitUntilClickable(Locator);
            new Actions(browser.driver).Click(WebElement).Build().Perform();
        }

        public void Click()
        {
            WaitUntilClickable(Locator);
            WebElement.Click();
        }

        public void MouseOver()
        {
            new Actions(browser.driver).MoveToElement(WebElement).Build().Perform();
        }

    }
}
