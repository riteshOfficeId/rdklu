using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class NavBarWomenSection : PageBase
    {
        [FindsBy(How=How.CssSelector,Using ="a[href='/collections/winter-w']")]
        IWebElement _winterWearBtn;
        public NavBarWomenSection(WebDriver webDriver, WebDriverWait wait) : base(webDriver,wait)
        {
            PageFactory.InitElements(webDriver,this);
        }
        
        public WinterWearPage ClickOnWinterWear()
        {
            ClickElement(_winterWearBtn);
            return new WinterWearPage(webDriver,wait);
        }
    }
}