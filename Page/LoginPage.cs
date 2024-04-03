using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class LoginPage : PageBase
    {
        [FindsBy(How= How.CssSelector,Using = "input[id='CustomerEmail']")]
        IWebElement _emailInput;

        [FindsBy(How= How.CssSelector,Using = "input[id='CustomerPassword']")]
        IWebElement _pswdInput;

        [FindsBy(How= How.XPath,Using = "//button[contains(text(),'Sign In')]")]
        IWebElement _signInBtn;

        By _incorrectCredentialsMsg = By.ClassName("errors");

        public LoginPage(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver,this);
        }

        public void EnterEmail(string email)
        {
            SendInput(_emailInput,email);
        }

        public void EnterPswd(string pswd)
        {
            SendInput(_pswdInput,pswd);
        }

        public AccountPage ClickOnSignIn()
        {
            ClickElement(_signInBtn);
            return new AccountPage(webDriver,wait);
        }

        public bool IsIncorrectCredentialsVisible()
        {
            return IsElementVisibleLongWait(_incorrectCredentialsMsg);
        }   
    }
}