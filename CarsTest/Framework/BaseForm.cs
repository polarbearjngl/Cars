using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace CarsTest
{
    public class BaseForm: BaseEntity
    {       
        protected BrowserConfig config = new BrowserConfig();

        protected void NavigateTo(string url)
        {
            browser.driver.Url = url;
        }

        protected ReadOnlyCollection<IWebElement> FindWebElements(By locator)
        {
            return browser.driver.FindElements(locator);
        }
    }
}
