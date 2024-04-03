using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.Browser;
using OpenQA.Selenium.DevTools.V120.Debugger;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestProject
{
    public class ConfigBrowser
    {
        public ConfigData configData;
        public IConfigurationRoot configuration;
        public WebDriver GetBrowser()
        {
            configData = new ConfigData();
            configuration = configData.GetConfigurationBuilder();
            switch (configuration.GetSection("Browser")["BrowserName"])
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-notifications");
                    return new ChromeDriver(chromeOptions);
                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("--disable-notifications");
                    return new FirefoxDriver(firefoxOptions);
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}