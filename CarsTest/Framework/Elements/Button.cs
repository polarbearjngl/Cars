using OpenQA.Selenium;

namespace CarsTest
{
    public class Button:BaseElement
    {
        public Button(string locator)
        {
            CreateNew(By.XPath(locator));
        }
    }
}
