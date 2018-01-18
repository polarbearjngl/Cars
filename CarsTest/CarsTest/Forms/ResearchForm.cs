using System;

namespace CarsTest
{
    public class ResearchForm:BaseForm
    {
        private Button CompareCars = new Button("//a[@class='comparisons-button']");

        public void ToCompareForm()
        {
            CompareCars.ClickAndWait();
        }
    }
}
