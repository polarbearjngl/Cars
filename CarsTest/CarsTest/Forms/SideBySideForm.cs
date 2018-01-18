using System;
using OpenQA.Selenium;

namespace CarsTest
{
    public class SideBySideForm:BaseForm
    {
        private string Name = "//span[contains(@index,'{0}')]//h4";
        private string Engine = "//cars-compare-compare-info[@header='Engine']//*[contains(@index,'{0}')]";
        private string Transmission = "//cars-compare-compare-info[@header='Transmission']//*[contains(@index,'{0}')]";

        public Car CarInfo(int number)
        {
            return new Car(By.XPath(string.Format(Name, number)),
                            By.XPath(string.Format(Engine, number)),
                            By.XPath(string.Format(Transmission, number)));
        }
    }
}
