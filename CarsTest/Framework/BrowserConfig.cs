using System;
using System.Xml.Linq;

namespace CarsTest
{
    public class BrowserConfig
    {
        private XDocument config = XDocument.Parse(Resources.Configuration);

        public TimeSpan ImplicitWait()
        {
            return new TimeSpan(int.Parse(config.Root.Element("ImplicitWait").Attribute("hours").Value),
                int.Parse(config.Root.Element("ImplicitWait").Attribute("minutes").Value),
                int.Parse(config.Root.Element("ImplicitWait").Attribute("seconds").Value));
        }

        public TimeSpan PageLoad()
        {
            return new TimeSpan(int.Parse(config.Root.Element("PageLoad").Attribute("hours").Value),
                int.Parse(config.Root.Element("PageLoad").Attribute("minutes").Value),
                int.Parse(config.Root.Element("PageLoad").Attribute("seconds").Value));
        }

        public TimeSpan WebDriverWait()
        {
            return new TimeSpan(int.Parse(config.Root.Element("WebDriverWait").Attribute("hours").Value),
                int.Parse(config.Root.Element("WebDriverWait").Attribute("minutes").Value),
                int.Parse(config.Root.Element("WebDriverWait").Attribute("seconds").Value));
        }

        public string Browser()
        {
            return config.Root.Element("WebBrowser").Attribute("name").Value;
        }

        public string DownloadsPath()
        {
            return config.Root.Element("DownloadsPath").Attribute(Browser()).Value;
        }

        public string DownloadTimer()
        {
            return config.Root.Element("DownloadTimer").Attribute("seconds").Value;
        }
    }
}
