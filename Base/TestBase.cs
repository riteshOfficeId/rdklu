using System.ComponentModel.DataAnnotations;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.Debugger;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.RelativeBy;
[assembly: LevelOfParallelism(3)]

namespace TestProject
{
    public class TestBase
    {
        public WebDriver webDriver;
        public WebDriverWait wait;
        public HomePage homePage;
        protected ExtentReports extent;
        protected ExtentManager extentManager;
        protected ExtentTest extentTest;
        public IConfigurationRoot configuration;
        public ConfigData configData;
        public ConfigBrowser configBrowser;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extentManager = new ExtentManager();
            configData = new ConfigData();
            extentManager.InitializeExtent();
            configuration = configData.GetConfigurationBuilder();
        }

        [SetUp]
        public void Setup()
        {
            configBrowser = new ConfigBrowser();
            webDriver = configBrowser.GetBrowser();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            homePage = new HomePage(webDriver, wait);
            extentManager.CreateTest(TestContext.CurrentContext.Test.Name);
            homePage.LoadUrl(configuration.GetSection("Url")["BaseUrl"]);
        }

        [TearDown]
        public void TearDown()
        {
            extentManager.EndTest();
            extentManager.LogScreenshot("Ending Test with screenshot", ((ITakesScreenshot)webDriver).GetScreenshot().AsBase64EncodedString);
            webDriver.Quit();
        }

        [OneTimeTearDown]
        public void CloseExtent()
        {
            extentManager.CloseExtent();
        }
    }
}