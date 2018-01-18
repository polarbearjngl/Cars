using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace CarsTest
{
    public class Car: BaseElement
    {                
        public string Name { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; private set; }
        public string Year { get; private set; }
        public string Transmission { get; private set; }
        public Engine EngineParam = new Engine();

        public struct Engine
        {
            public string power { get;  private set; }
            public string capacity { get; private set; }
            public string type { get; private set; }
            public string gasoline { get; private set; }

            public Engine WriteInfo(string engine)
            {
                power = Regex.Match(engine, "\\S+(?=,)").Value;
                capacity = Regex.Match(engine, "(?<=,) \\S+(?=-)").Value;
                type = Regex.Match(engine, "\\b[A-Z].\\d\\b").Value;
                gasoline = Regex.Match(engine, "\\((.*?)\\)").Value;
                return new Engine();
            }
        }

        public Car(By maker, By model, By year, By engine, By transmission)
        {
            Maker = getAttribute(maker, "textContent");
            Model = getAttribute(model, "textContent");
            Year = getAttribute(year, "textContent");                       
            Name = Year + " " + Maker + " " + Model;
            Transmission = getAttribute(transmission, "textContent").Trim();
            EngineParam.WriteInfo(getAttribute(engine, "textContent"));
        }

        public Car(By carName,By engine,By transmission)
        {
            Name = getAttribute(carName, "textContent");
            EngineParam.WriteInfo(getAttribute(engine, "textContent"));
            Transmission = getAttribute(transmission, "textContent").Trim();
        }
    }
}
