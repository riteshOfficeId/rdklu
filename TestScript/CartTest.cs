using AventStack.ExtentReports;
using NUnit.Framework.Internal;

namespace TestProject
{
    [Parallelizable]
    public class CartTest : TestBase
    {
        [Test]
        public void VerifyProductAddedToCart()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            NavBarMenSectionTees navBarMenSectionTees = navBarMenSection.ClickOnTeesDropDown();
            PrintedTees printedTees = navBarMenSectionTees.ClickOnPrintedTees();
            ProductPage productPage = printedTees.SelectProductWithId(330);

            string size = "M";
            productPage.SelectSize(size);

            string productName = productPage.GetProductName();
            productPage.ClickOnAddToCart();

            Assert.That(productPage.GetProductSizeFromCartPane(), Is.EqualTo($"Size: {size}"));
            Assert.That(productName, Is.EqualTo(productPage.GetProductNameFromCartPane()));
        }
    }
}