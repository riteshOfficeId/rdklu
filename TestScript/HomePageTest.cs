using AventStack.ExtentReports;

namespace TestProject
{
    [Parallelizable]
    public class HomePageTest : TestBase
    {
        [Test]
        public void LandedOnHomePage()
        {
            Assert.That(homePage.GetCurrentUrl(), Is.EqualTo(configuration.GetSection("Url")["BaseUrl"]));
        }
    }
}