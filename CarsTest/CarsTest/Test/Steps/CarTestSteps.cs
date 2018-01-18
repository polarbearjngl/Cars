using System.Collections.Generic;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarsTest
{
    [Binding]
    public class CarTestSteps:BaseTest
    {
        private List<Car> CarsList = new List<Car>();
        private MainForm mainForm;
        private CarForm carForm;
        private TrimsForm trimsForm;
        private ResearchForm researchForm;
        private CompareForm compareForm;
        SideBySideForm sidebysideForm;

        [Given(@"Browser navigate to '(.*)' page")]
        public void GivenBrowserNavigateToPage(string url)
        {
            mainForm = new MainForm(url);
            LogStep(1);
        }

        [When(@"Select random car by '(.*)' and '(.*)' and '(.*)' for searching")]
        public void WhenSelectRandomCarByAndAndForSearching(string makesCmb, string modelsCmb, string yearsCmb)
        {
            mainForm.OpenSpecAndReviews();
            LogStep(2);
            mainForm.SelectRandomCar(makesCmb, modelsCmb, yearsCmb);
            mainForm.Search();
            LogStep(3);
        }

        [Then(@"Try navigate to Trim Comparsion or find another car by '(.*)' and '(.*)' and '(.*)' on '(.*)' page")]
        public void ThenTryNavigateToTrimComparsionOrFindAnotherCarByAndAndOnPage(string makesCmb, string modelsCmb, string yearsCmb, string url)
        {
            carForm = new CarForm();
            carForm.TryNavigateToTrims(mainForm, url, makesCmb, modelsCmb, yearsCmb);
            LogStep(4);
        }

        [Then(@"Saving parametres '(.*)' and '(.*)' and '(.*)' of First Car")]
        public void ThenSavingParametresAndAndOfFirstCar(string Make, string Model, string Year)
        {
            trimsForm = new TrimsForm();
            CarsList.Add(trimsForm.createNewCar(Make, Model, Year));
            LogStep(5);
        }

        [When(@"Browser navigate to '(.*)' page")]
        public void WhenBrowserNavigateToPage(string url)
        {
            mainForm = new MainForm(url);
            LogStep(6);
        }

        [Then(@"Select another car by '(.*)' and '(.*)' and '(.*)' for searching")]
        public void ThenSelectAnotherCarByAndAndForSearching(string makesCmb, string modelsCmb, string yearsCmb)
        {
            mainForm.OpenSpecAndReviews();
            mainForm.SelectRandomCar(makesCmb, modelsCmb, yearsCmb);
            mainForm.Search();
        }

        [Then(@"Try navigate to Trim Comparsion or find another car by '(.*)' '(.*)' '(.*)' on '(.*)'")]
        public void ThenTryNavigateToTrimComparsionOrFindAnotherCarByOn(string makesCmb, string modelsCmb, string yearsCmb, string url)
        {
            carForm = new CarForm();
            carForm.TryNavigateToTrims(mainForm, url, makesCmb, modelsCmb, yearsCmb);
        }

        [Then(@"Saving parametres '(.*)' and '(.*)' and '(.*)' of Second Car")]
        public void ThenSavingParametresAndAndOfSecondCar(string Make, string Model, string Year)
        {
            trimsForm = new TrimsForm();
            CarsList.Add(trimsForm.createNewCar(Make, Model, Year));
            LogStep(7);
        }

        [Then(@"From page '(.*)' navigate to Side_by_Side Comparisons page")]
        public void ThenFromPageNavigateToSide_By_SideComparisonsPage(string url)
        {
            mainForm = new MainForm(url);
            mainForm.NavigateToMenuItem(MainForm.Menu.RESEARCHCARMODELS);
            researchForm = new ResearchForm();
            LogStep(8);
            researchForm.ToCompareForm();
            LogStep(9);
        }

        [Then(@"Add parametres '(.*)' and '(.*)' and '(.*)' of Cars")]
        public void ThenAddParametresAndAndOfCars(string makesCmb, string modelsCmb, string yearsCmb)
        {
            compareForm = new CompareForm();
            compareForm.AddCarInfo(makesCmb, modelsCmb, yearsCmb, CarsList[0]);
            compareForm.StartComparison();
            LogStep(10);

            compareForm.OpenAddAnotherCarMenu();
            compareForm.AddCarInfo(makesCmb, modelsCmb, yearsCmb, CarsList[1]);
            compareForm.ConfirmAddCar();            
            LogStep(11);
        }

        [Then(@"Compare parametres from page to saved parametres")]
        public void ThenCompareParametresFromPageToSavedParametres()
        {
            sidebysideForm = new SideBySideForm();

            var enumerator = CarsList.GetEnumerator();

            for (int i = 0; enumerator.MoveNext(); i++)
            {
                var expected = CarsList[i];
                var actual = sidebysideForm.CarInfo(i);

                MultiAssert.SoftAssert(
                    () => Assert.AreEqual(expected.Name, actual.Name, "Name is not equal"),
                    () => Assert.AreEqual(expected.EngineParam.capacity, actual.EngineParam.capacity, "Capacity is not equal"),
                    () => Assert.AreEqual(expected.EngineParam.power, actual.EngineParam.power, "Power is not equal"),
                    () => Assert.AreEqual(expected.EngineParam.type, actual.EngineParam.type, "Type is not equal"),
                    () => Assert.AreEqual(expected.EngineParam.gasoline, actual.EngineParam.gasoline, "Gasoline is not equal"),
                    () => Assert.AreEqual(expected.Transmission, actual.Transmission, "Transmission is not equal"));
            }

            Assert.IsTrue(MultiAssert.NotFailed, "One or more tests failed");
            LogStep(12);
        }        
    }
}
