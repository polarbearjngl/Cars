using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CarsTest
{
    public class MainForm:BaseForm
    {
        private string SpecsReviews = "//div[@class='hero-search-widget']//li[@tab-for='research']";
        private string Buy = "//a[@title='Buy']";
        private string SearchBtn = "//div[@class='hero-search-widget']//input[@value = 'Search']";
        private string comboBoxLocator = "//div[contains(@class,'{0}')]//select";
        private string menuCommon = "//a[text()='{0}']";

        public struct Menu
        {
            public static string CARSFORSALE { get { return "Find Cars for Sale"; } }
            public static string CARSFORSALEBYOWNER { get { return "Find Cars for Sale by Owner"; } }
            public static string USEDCARSFORSALE { get { return "Used Cars for Sale"; } }
            public static string RESEARCHCARMODELS { get { return "Research Car Models"; } }
            public static string FINDADEALER { get { return "Find a Dealer"; } }
            public static string REVIEWADEALER { get { return "Review a Dealer"; } }
            public static string REVIEWACAR { get { return "Review a Car"; } }
            public static string ESTUSEDCARVALUES { get { return "Estimate Used Car Values"; } }
            public static string ESTYOURPAYMENTS { get { return "Estimate Your Payments"; } }
            public static string SERTIFCARS { get { return "Certified Pre-Owned Cars"; } }
        }

        public MainForm (string url)
        {
            NavigateTo(url);                                
        }

        public void OpenSpecAndReviews()
        {
            new Label(SpecsReviews).ClickAndWait();
        }

        public void SelectRandomCar(string makesCmb, string modelsCmb, string yearsCmb)
        {
            string[] array = { makesCmb, modelsCmb, yearsCmb };
            for(int i = 0; i < array.Length; i++)
            {
                new ComboBox(string.Format(comboBoxLocator, array[i])).SelectRandomElement();
            }           
        }

        public void Search()
        {
            new Button(SearchBtn).ClickAndWait_ViaJS();
        }

        public void NavigateToMenuItem(string item)
        {
            new Label(Buy).ClickAndWait_ViaJS();
            new Label(string.Format(menuCommon,item)).ClickAndWait_ViaJS();
        }
    }
}
