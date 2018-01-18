using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CarsTest
{
    public class BrowserFactory
    {
        private static BrowserFactory value = new BrowserFactory();

        public IWebDriver driver { get; private set; }
        public WebDriverWait wait { get; private set; }
        public string BrowserName { get; private set; }

        private BrowserFactory()
        {
            BrowserConfig config = new BrowserConfig();
            switch (config.Browser())
            {
                case "Chrome":
                    BrowserName = "Chrome";
                    var optionsChrome = new ChromeOptions();                   
                    optionsChrome.AddArguments("disable-infobars");
                    optionsChrome.AddUserProfilePreference("download.default_directory", System.IO.Directory.GetCurrentDirectory());
                    optionsChrome.AddUserProfilePreference("download.prompt_for_download", false);
                    optionsChrome.AddUserProfilePreference("safebrowsing.enabled", true);
                    driver = new ChromeDriver(optionsChrome);
                    break;
                case "Firefox":
                    BrowserName = "Firefox";
                    var profile = new FirefoxProfile();
                    profile.SetPreference("browser.download.dir", System.IO.Directory.GetCurrentDirectory());
                    profile.SetPreference("browser.download.folderList", 2);
                    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk","application/octet-stream");
                    profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                    profile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
                    driver = new FirefoxDriver(profile);
                    break;
                default:
                    throw new Exception("Incorrect Browser Name " + config.Browser());
            }

            driver.Manage().Timeouts().ImplicitWait = config.ImplicitWait();
            driver.Manage().Timeouts().PageLoad = config.PageLoad();

            wait = new WebDriverWait(driver, config.WebDriverWait());
        }

        public static BrowserFactory GetBrowser()
        {
            return value;
        }
    }
}
