using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class ShippingPage : PageBase
    {
        [FindsBy(How = How.XPath, Using = "//span[text()='Continue to payment']//parent::button")]
        IWebElement _proceedForPaymentBtn;
    
        By _shippingMethod =By.CssSelector("fieldset[id='shipping_methods']");

        public ShippingPage(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public FinalCheckoutPage ClickOnContinueToPayment()
        {
            ClickElement(_proceedForPaymentBtn);
            return new FinalCheckoutPage(webDriver, wait);
        }

        public bool IsShippingMethodVisible()
        {
            return IsElementVisible(_shippingMethod);
        } 
    }
}