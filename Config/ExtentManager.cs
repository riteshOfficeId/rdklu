using System.Security.Cryptography;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace TestProject
{
    public class ExtentManager : TestBase
    {
        public void InitializeExtent()
        {
            string dir = @"D:\Training\FinalProject\Rdklu\TestReport\";
            string fileName = $"Report{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.html";
            ExtentSparkReporter sparkReporter = new ExtentSparkReporter(dir + fileName);
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
        }

        public void CreateTest(string testName)
        {
            extentTest = extent.CreateTest(testName).Info("Test Started");
        }

        public void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

        public void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    extentTest.Fail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    extentTest.Info($"Test has skipped {message}");
                    break;
                case TestStatus.Passed:
                    extentTest.Info($"Test has Passed {message}");
                    break;
                default:
                    break;
            }
        }

        public void CloseExtent()
        {
            extent.Flush();
        }
    }
}