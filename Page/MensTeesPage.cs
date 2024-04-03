using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class MensTeesPage : PageBase
    {
        [FindsBy(How = How.XPath, Using = "//span[text()='Previous']")]
        IWebElement _previousBtn;
        [FindsBy(How = How.XPath, Using = "//span[text()='Next']")]
        IWebElement _nextBtn;

        By _next = By.XPath("a[title='Next']");
        By _previous = By.XPath("a[title='Previous']");
        By _product = By.XPath("//div[class='grid-product__content']");

        public MensTeesPage(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver, this);
        }
        public int GetCountOfProductsListedOnPage()
        {
            return FindElements(_product).Count;
        }

        public bool IsPreviousBtnVisible()
        {
            return IsElementVisible(_previous);
        }

        public bool IsNextBtnVisible()
        {
            return IsElementVisible(_next);
        }

        public void GoToPage(int pageNumber)
        {
            ClickElement(FindElement($"//a[text()='{pageNumber}']"));
        }

        public string GetUrl()
        {
            return GetCurrentUrl();
        }
    }
}