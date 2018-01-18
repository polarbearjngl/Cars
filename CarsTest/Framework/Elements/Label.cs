using OpenQA.Selenium;

namespace CarsTest
{
    public class Label:BaseElement
    {
        public Label(string locator)
        {
            CreateNew(By.XPath(locator));
        }

        public Label(string locator, string name)
        {
            CreateNew(By.XPath(string.Format(locator, name)));
        }
    }
}
