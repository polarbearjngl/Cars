using System;
using OpenQA.Selenium;
using System.Text;

namespace CarsTest
{
    public class TrimsForm:BaseForm
    {
        private Label Engine = new Label("//div[contains(@class,'trim-card')]/following-sibling::div//div[@class='cell cell-bg grow-2']");
        private Label Transmission = new Label("//div[contains(@class,'trim-card')]/following-sibling::div//div[@class='cell grow-2']");
        
        private By Locator(string text)
        {
            return By.XPath(string.Format("//li//a[contains(@data-linkname,'{0}')]",text));
        }

        public Car createNewCar(string Make,string Model, string Year)
        {
            return new Car(Locator(Make), Locator(Model), 
                Locator(Year), Engine.Locator, 
                Transmission.Locator);
        }
    }
}
