using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V120.WebAuthn;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestProject
{
    public class PageBase
    {
        protected WebDriver webDriver;
        protected WebDriverWait wait;
        
        public PageBase(WebDriver webDriver, WebDriverWait wait)
        {
            this.webDriver = webDriver;
            this.wait = wait;
        }
        public IAlert SwitchToAlert()
        {
            IAlert alert = webDriver.SwitchTo().Alert();
            return alert;
        }

        public void DismissAlert()
        {
            SwitchToAlert().Dismiss();
        }

        public void MaximizeWindow()
        {
            webDriver.Manage().Window.Maximize();
        }

        public void ClickElement(IWebElement webElement)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
            }
            catch (StaleElementReferenceException)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
            }
            catch (ElementClickInterceptedException)
            {
                ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", webElement);
            }
            catch(ElementNotInteractableException)
            {
                ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", webElement);
            }
            catch (NoSuchElementException error)
            {
                throw new Exception(error.Message);
            }
            catch (WebDriverTimeoutException error)
            {
                throw new ApplicationException(error.Message);
            }
        }

        public void CloseTab()
        {
            webDriver.Close();
        }

        public void SendInput(IWebElement webElement, string input)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).SendKeys(input);
            }
            catch (StaleElementReferenceException)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).SendKeys(input);
            }
        }

        public void SendEnterKey(IWebElement webElement)
        {
            webElement.SendKeys(Keys.Enter);
        }

        public void RefreshTab()
        {
            webDriver.Navigate().Refresh();
        }

        public IWebElement FindElement(IWebElement webElement, string xpathToFind)
        {
            return webElement.FindElement(By.XPath(xpathToFind));
        }

        public IWebElement FindElement(string xpathToFind)
        {
            IsElementVisible(By.XPath("//div[contains(text(),'TEE#330')]"));
            return webDriver.FindElement(By.XPath(xpathToFind));
        }

        public IList<IWebElement> FindElements(By locator)
        {
            return webDriver.FindElements(locator);
        }

        public void SwitchToWindow(int i)
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles[i]);
        }

        public bool IsElementVisibleLongWait(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(2));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsElementVisible(By locator)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void NavigateToUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public string GetCurrentUrl()
        {
            return webDriver.Url;
        }

        public void IsElementClickable(IWebElement webElement)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }
    }
}