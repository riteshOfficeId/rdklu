using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace TestProject
{
    [Parallelizable]
    public class ProductPurchaseTest : TestBase
    {
        [Test]
        public void VerifyProductPurchase()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarWomenSection navBarWomenSection = navBar.ClickOnWomenSectionDropDown();
            WinterWearPage winterWearPage = navBarWomenSection.ClickOnWinterWear();
            ProductPage productPage = winterWearPage.SelectProductWithId(18);

            string size = "M";
            productPage.SelectSize(size);
            productPage.ClickOnAddToCart();

            CheckoutPage checkoutPage = productPage.ClickOnCheckout();
            checkoutPage.OptOutEmailMeCheckbox();
            checkoutPage.FillAddress(configuration.GetSection("ShippingAddress")["UserEmail"],
                                    configuration.GetSection("ShippingAddress")["FirstName"],
                                    configuration.GetSection("ShippingAddress")["LastName"],
                                    configuration.GetSection("ShippingAddress")["Address"],
                                    configuration.GetSection("ShippingAddress")["City"],
                                    configuration.GetSection("ShippingAddress")["State"],
                                    configuration.GetSection("ShippingAddress")["PostalCode"],
                                    configuration.GetSection("ShippingAddress")["ContactNumber"]);
            ShippingPage shippingPage = checkoutPage.ClickOnContinueToShipping();

            Assert.IsTrue(shippingPage.IsShippingMethodVisible());

            FinalCheckoutPage finalCheckoutPage = shippingPage.ClickOnContinueToPayment();

            Assert.IsTrue(finalCheckoutPage.IsPaymentMethodSelected());
            Assert.IsTrue(finalCheckoutPage.IsPayNowBtnVisible());
        }
    }
}
