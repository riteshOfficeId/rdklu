using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class NavBarMenSectionTees : PageBase
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Active Wear')]//parent::div/button")]
        IWebElement _activeWearDropDown;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Printed Tees')]")]
        IWebElement _printedTeesMenu;
        public NavBarMenSectionTees(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public void ClickOnActiveWearDropDown()
        {
            ClickElement(_activeWearDropDown);
        }

        public bool IsTeesOptionVisible(By locator)
        {
            return IsElementVisible(locator);
        }

        public PrintedTees ClickOnPrintedTees()
        {
            ClickElement(_printedTeesMenu);
            return new PrintedTees(webDriver, wait);
        }
    }
}