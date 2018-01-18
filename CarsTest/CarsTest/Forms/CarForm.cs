using System;

namespace CarsTest
{
    public class CarForm:BaseForm
    {
        private string Trims = "//a[contains(@href,'/trims')]";

        public void TryNavigateToTrims(MainForm mainform,string mainpage, string makesCmb, string modelsCmb, string yearsCmb)
        {
            WaitPageToLoad();
            try
            {
                new Label(Trims).ClickAndWait();
            }
            catch(Exception e)
            {
                mainform = new MainForm(mainpage);
                mainform.OpenSpecAndReviews();
                mainform.SelectRandomCar(makesCmb, modelsCmb, yearsCmb);
                mainform.Search();
                TryNavigateToTrims(mainform,mainpage,makesCmb,modelsCmb,yearsCmb);
            }
        }
    }
}
