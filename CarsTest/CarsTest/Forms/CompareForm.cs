using OpenQA.Selenium;

namespace CarsTest
{
    public class CompareForm:BaseForm
    {
        private ComboBox ComboBox;
        private string comboBoxLocator = "//div[contains(@class,'dropdown')]//select[contains(@id,'{0}')]";
        private Button StartCompare = new Button("//button[@class='done-button']");
        private string AddAnotherCar = "//a[@id='add-from-your-favorite-cars-link']";
        private string Done = "//button[@class='modal-button']";
        

        public void AddCarInfo(string makesCmb, string modelsCmb, string yearsCmb, Car car)
        {
            string [] array = { makesCmb, modelsCmb, yearsCmb };
            string[] text = { car.Maker, car.Model, car.Year };
            for(int i = 0; i < array.Length; i++)
            {
                ComboBox = new ComboBox(string.Format(comboBoxLocator, array[i]));
                ComboBox.SelectElementByText(text[i]);
            }
        }

        public void StartComparison()
        {
            StartCompare.ClickAndWait_ViaJS();          
        }

        public void OpenAddAnotherCarMenu()
        {
            new Button(AddAnotherCar).ClickAndWait_ViaJS();
        }

        public void ConfirmAddCar()
        {           
            new Button(Done).ClickAndWait_ViaJS();
        }
    }
}
