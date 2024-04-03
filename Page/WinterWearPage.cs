using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class WinterWearPage : PageBase
    {
        public WinterWearPage(WebDriver webDriver, WebDriverWait wait) : base(webDriver,wait)
        {
            PageFactory.InitElements(webDriver,this);
        }

        public ProductPage SelectProductWithId(int id)
        {
            ClickElement(FindElement($"//div[contains(text(),'RDKLU#{id}')]"));
            return new ProductPage(webDriver,wait);
        }
    }
}