using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class FinalCheckoutPage : PageBase
    {
        [FindsBy(How = How.XPath, Using = "//span[text()='Pay now']//parent::button")]
        IWebElement _payNowBtn;
        By _payNowBtnLocator = By.XPath("//span[text()='Pay now']//parent::button");

        [FindsBy(How = How.CssSelector, Using = "input[id='basic-Razorpay Secure (UPI, Cards, Wallets, NetBanking)']")]
        IWebElement _paymentMethod;
        public FinalCheckoutPage(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public bool IsPayNowBtnVisible()
        {
            return IsElementVisible(_payNowBtnLocator);
        }

        public PaymentPage ClickOnPayNow()
        {   
            ClickElement(_payNowBtn);
            return new PaymentPage(webDriver,wait);
        }

        public bool IsPaymentMethodSelected()
        {
            IsElementClickable(_paymentMethod);
            return _paymentMethod.Selected;
        } 
    }
}