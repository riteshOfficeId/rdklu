using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject
{
    public class ProductPage : PageBase
    {
        [FindsBy(How=How.XPath,Using ="//option[@value='XS']//parent::select")]
        IWebElement _sizeDropDown;

        [FindsBy(How=How.CssSelector,Using ="button[name='add']")]
        IWebElement _addToCartBtn;

        [FindsBy(How= How.CssSelector,Using = "button[name='checkout']")]
        IWebElement _checkoutBtn;

        [FindsBy(How=How.XPath,Using ="//span[text()='Size:']//parent::div")]
        IWebElement _productSizeOnCartPane;

        [FindsBy(How=How.XPath,Using ="//a[@class='cart__item-name']")]
        IWebElement _productNameOnCartPane;
        By _productSizeOnCartPaneLocator = By.XPath("//span[text()='Size:']//parent::div");

        [FindsBy(How=How.XPath,Using ="//span[contains(text(),'Close cart')]")]
        IWebElement _closeCartBtn;

        [FindsBy(How=How.CssSelector,Using ="h1[class='h2 product-single__title']")]
        IWebElement _productName;
        SelectElement selectSize;
        public ProductPage(WebDriver webDriver,WebDriverWait wait) : base(webDriver,wait)
        {
            PageFactory.InitElements(webDriver,this);
        }
        
        public void SelectSize(string size)
        {
            IsElementClickable(_sizeDropDown);
            selectSize = new SelectElement(_sizeDropDown);
            selectSize.SelectByValue(size);
        }

        public void ClickOnAddToCart()
        {
            ClickElement(_addToCartBtn);
        }

        public string GetProductSizeFromCartPane()
        {
            IsElementVisible(_productSizeOnCartPaneLocator );
            return _productSizeOnCartPane.Text;
        }

        public string GetProductName()
        {
            return _productName.Text;
        }

        public string GetProductNameFromCartPane()
        {
            return _productNameOnCartPane.Text;
        }

        public void CloseCart()
        {
            ClickElement(_closeCartBtn);
        }

        public CheckoutPage ClickOnCheckout()
        {
            ClickElement(_checkoutBtn);
            return new CheckoutPage(webDriver,wait);
        }
    }
}