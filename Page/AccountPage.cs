using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    public class AccountPage : PageBase
    {
        By _myaccountText = By.CssSelector("h1[class='section-header__title']");
        public AccountPage(WebDriver webDriver,WebDriverWait wait) : base(webDriver,wait)
        {      
        }   
        
        public bool IsMyAccountVisible()
        {
            return IsElementVisibleLongWait(_myaccountText);
        }
    }
}