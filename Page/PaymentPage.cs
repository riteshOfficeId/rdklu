using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class PaymentPage : PageBase
    {
        [FindsBy(How =How.XPath,Using ="//input[@name='contact']")]
        IWebElement _contactField;
        
        [FindsBy(How =How.XPath,Using ="//button[text()='Pay now']")]
        IWebElement _payNowBtn;

        [FindsBy(How =How.XPath,Using ="//div[text()='Card']")]
        IWebElement _cardPaymentMethod;

        [FindsBy(How =How.CssSelector,Using ="input[id='card_number']")]
        IWebElement _cardNumberBox;

        [FindsBy(How =How.CssSelector,Using ="input[id='card_name']")]
        IWebElement _cardNameBox;

        [FindsBy(How =How.CssSelector,Using ="input[id='card_expiry']")]
        IWebElement _cardExpiryBox;

        [FindsBy(How =How.CssSelector,Using ="input[id='card_cvv']")]
        IWebElement _cardCvvBox;

        [FindsBy(How =How.CssSelector,Using ="//button[text()='Pay without Saving Card]")]
        IWebElement _payWithoutSavingCardBtn;
        By _brandName =  By.CssSelector("p[title='RDKLU']");
        public PaymentPage(WebDriver webDriver,WebDriverWait wait) : base(webDriver,wait)
        {
            webDriver.SwitchTo().Window(webDriver.CurrentWindowHandle);
            string url = webDriver.Url;
            PageFactory.InitElements(webDriver,wait);
        }

        public void ClickOnPayNow()
        {
            ClickElement(_payNowBtn);
            ClickElement(_payWithoutSavingCardBtn);
        }

        public bool IsBrandTitleVisible()
        {
            return IsElementVisible(_brandName);
        }

        public void ClickOnCard()
        {
            ClickElement(_cardPaymentMethod);
        }

        public void FillCardDetails(string cardNum, string cardName, string cardExpiry, string cardCvv)
        {   
            SendInput(_cardNumberBox,cardNum);
            SendInput(_cardNameBox,cardName);
            SendInput(_cardExpiryBox,cardExpiry);
            SendInput(_cardCvvBox,cardCvv);
        }

        public void AcceptCancelPaymentAlert()
        {
            DismissAlert();
            NavigateToUrl("https://www.rdklu.com");
        }

        public void FillContactNumber(string number)
        {
            SendInput(_contactField,number);
        }
    }
}