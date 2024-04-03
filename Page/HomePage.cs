using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class HomePage : PageBase
    {
        [FindsBy(How= How.XPath,Using = "//div[@class='site-nav__icons']//child::a[@href='/account']")]
        IWebElement _accountBtn;

        [FindsBy(How=How.XPath,Using ="//span[text()='Site navigation']")]
        IWebElement _navBarBtn;

        [FindsBy(How=How.XPath,Using ="//a[@href='/search']")]
        IWebElement _searchBtn;

        [FindsBy(How=How.CssSelector,Using ="input[id='Search']")]
        IWebElement _searchBox;        

        [FindsBy(How=How.CssSelector,Using ="div[class='button--text']")]
        IWebElement _offerPopUp;

        public HomePage(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver,this);
        }

        public void LoadUrl(string url)
        {
            MaximizeWindow();
            webDriver.Url = url;
        }

        public void ClosePopUp()
        {
            ClickElement(_offerPopUp);
        }

        public LoginPage ClickOnAccountBtn()
        {
            ClickElement(_accountBtn);
            return new LoginPage(webDriver,wait);
        }

        public void ClickOnSearchBtn()
        {
            ClickElement(_searchBtn);
        }

        public void SearchQuery(string query)
        {
            SendInput(_searchBox,query);
        }

        public DealOfTheDayPage GoToDealOfTheDayPage(string url)
        {
            NavigateToUrl(url);
            return new DealOfTheDayPage(webDriver,wait);
        }

        public NavBar ClickOnNavigationBtn()
        {
            ClickElement(_navBarBtn);
            return new NavBar(webDriver,wait);
        }

        public void DismissAllowNotificationAlert()
        {
            DismissAlert();
        }
    }
}
