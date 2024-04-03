using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject  
{
    public class NavBar : PageBase
    {
        [FindsBy(How=How.XPath,Using ="//a[@href='/collections/mens']//following-sibling::div/button")]
        IWebElement _mensSectionDropDown;

        [FindsBy(How=How.XPath,Using ="//a[@href='/collections/womens']//following-sibling::div/button")]
        IWebElement _womensSectionDropDown;
        public NavBar(WebDriver webDriver, WebDriverWait wait) : base(webDriver,wait)
        {
            PageFactory.InitElements(webDriver,this);
        }

        public NavBarMenSection ClickOnMenSectionDropDown()
        {
            ClickElement(_mensSectionDropDown);
            return new NavBarMenSection(webDriver,wait);
        }

        public NavBarWomenSection ClickOnWomenSectionDropDown()
        {
            ClickElement(_womensSectionDropDown);
            return new NavBarWomenSection(webDriver,wait);
        }
    }
}