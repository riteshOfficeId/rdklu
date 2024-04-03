using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class CheckoutPage : PageBase
    {
        [FindsBy(How=How.CssSelector,Using ="input[name='marketing_opt_in']")]
        IWebElement _marketingCheckbox;

        [FindsBy(How=How.CssSelector, Using ="input[name='email']")]
        IWebElement _email;

        [FindsBy(How=How.CssSelector, Using ="input[name='firstName']")]
        IWebElement _firstName;

        [FindsBy(How=How.CssSelector, Using ="input[name='lastName']")]
        IWebElement _lastName;
        
        [FindsBy(How =How.CssSelector,Using ="input[id='shipping-address1']")]
        IWebElement _addressField;

        [FindsBy(How =How.CssSelector,Using ="input[name='city']")]
        IWebElement _cityField; 

        [FindsBy(How=How.CssSelector, Using ="input[name='postalCode']")]
        IWebElement _pincodeField;

        [FindsBy(How=How.CssSelector, Using ="input[name='phone']")]
        IWebElement _phoneField;

        [FindsBy(How =How.CssSelector,Using ="select[name='zone']")]
        IWebElement _stateDropDown;

        [FindsBy(How =How.XPath,Using ="//span[text()='Continue to shipping']//parent::button")]
        IWebElement _proceedBtn;

        SelectElement selectState;

        public CheckoutPage(WebDriver webDriver,WebDriverWait wait) : base(webDriver,wait)
        {
            PageFactory.InitElements(webDriver,this);
        }

        public void OptOutEmailMeCheckbox()
        {
            ClickElement(_marketingCheckbox);
        }

        public void FillAddress(string email,string firstName,string lastName,string address,string city,string state,string pincode,string phone)
        {
            SendInput(_email, email);
            SendInput(_firstName,firstName);
            SendInput(_lastName,lastName);
            SendInput(_addressField, address);
            SendInput(_cityField,city);
            SelectState(state);
            SendInput(_pincodeField,pincode);
            SendInput(_phoneField,phone);
        }

        public void SelectState(string state)
        {
            selectState = new SelectElement(_stateDropDown);
            selectState.SelectByValue(state);
        }

        public ShippingPage ClickOnContinueToShipping()
        {
            ClickElement(_proceedBtn);
            return new ShippingPage(webDriver,wait);
        }
    }
}
