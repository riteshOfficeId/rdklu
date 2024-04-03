using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public enum PriceEnum
    {
        discountedPriceList,discountPercentageList,originalPriceList
    }
    public class DealOfTheDayPage : PageBase
    {
        By _dotdProductsOriginalPrice = By.XPath("//span[@class='grid-product__price--original']");
        By _dotdProductsDiscountedPrice = By.XPath("//span[@class='grid-product__price--original']//following-sibling::span[@class='money']");
        By _dotdProductsDiscountPercentage = By.XPath("//span[@class='grid-product__price--savings']");
        public IList<IWebElement> originalPriceList;
        public IList<IWebElement> discountedPriceList;
        public IList<IWebElement> discountPercentageList;

        public DealOfTheDayPage(WebDriver webDriver, WebDriverWait wait) : base(webDriver, wait)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public void StoreProductsPriceDetails()
        {
            originalPriceList = FindElements(_dotdProductsOriginalPrice);
            discountedPriceList = FindElements(_dotdProductsDiscountedPrice);
            discountPercentageList = FindElements(_dotdProductsDiscountPercentage);
        }

        public int PriceStringToInt(string input)
        {
            string[] result = input.Split(".");
            return ExtractNumericValue(result[1]);
        }

        public int ExtractNumericValue(string input)
        {
            string pattern = @"\d+";
            input = input.Replace(",", "");

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                string numericString = match.Value;
                input = input.Replace(",", "");
                int result = 0;
                int.TryParse(numericString, out result);
                return result;
            }
            return 0;
        }
    }
}