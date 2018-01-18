using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CarsTest
{
    public class ComboBox:BaseElement
    {
        private SelectElement select;

        public ComboBox(string locator)
        {
            CreateNew(By.XPath(locator));           
        }

        public void SelectElementByText(string text)
        {
            select = new SelectElement(WebElement);
            select.SelectByText(text);
        }

        public void SelectRandomElement()
        {
            WaitUntilClickable(Locator);
            ClickAndWait_ViaAction();
            select = new SelectElement(WebElement);
            WaitComboboxUpdate(select);
            var random = new System.Random().Next(1, select.Options.Count - 1);
            select.SelectByIndex(random);
            WaitPageToLoad();
        }

        public void WaitComboboxUpdate(SelectElement select)
        {
            var wait = new DefaultWait<IWebDriver>(browser.driver);
            wait.Timeout = new BrowserConfig().WebDriverWait();
            wait.Until(d =>
            {
                return select.Options.Count > 1;
            });
        }
    }
}
