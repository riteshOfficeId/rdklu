using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace TestProject
{
    [Parallelizable]
    public class FilterTest : TestBase
    {
        [Test]
        public void VerifyProductSequence()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            NavBarMenSectionTees navBarMenSectionTees = navBarMenSection.ClickOnTeesDropDown();
            PrintedTees printedTees = navBarMenSectionTees.ClickOnPrintedTees();
            printedTees.SetFilter();
            IList<IWebElement> productList = printedTees.GetProductsList();

            IWebElement firstProduct = productList[0];
            for (int i = 1; i < productList.Count; i++)
            {
                Assert.That(productList[i].Text, Is.LessThanOrEqualTo(firstProduct.Text));
                firstProduct = productList[i];
            }
        }
    }
}