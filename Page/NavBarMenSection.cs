using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class NavBarMenSection : PageBase
    {

        [FindsBy(How=How.XPath,Using ="//a[contains(text(),'Tees')]//parent::div/button")]
        IWebElement _teesDropDown;
        [FindsBy(How=How.CssSelector,Using ="a[href='/collections/mens-tees-1']")]
        IWebElement _teesOption;

        public NavBarMenSection(WebDriver webDriver, WebDriverWait wait) : base(webDriver,wait)
        {
            PageFactory.InitElements(webDriver,this);
        }
        
        public NavBarMenSectionTees ClickOnTeesDropDown()
        {
            ClickElement(_teesDropDown);
            return new NavBarMenSectionTees(webDriver,wait);
        }

        public MensTeesPage ClickOnMensTees()
        {
            ClickElement(_teesOption);
            return new MensTeesPage(webDriver,wait);
        }
    }
}   