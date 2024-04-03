using AventStack.ExtentReports;

namespace TestProject
{
    [Parallelizable]
    public class LoginTest : TestBase
    {
        [Test]
        public void ValidLogin()
        {
            homePage.ClosePopUp();
            LoginPage loginPage = homePage.ClickOnAccountBtn();
            loginPage.EnterEmail(configuration.GetSection("TestData")["UserEmail"]);
            loginPage.EnterPswd(configuration.GetSection("TestData")["ValidPassword"]);
            AccountPage accountPage = loginPage.ClickOnSignIn();

            Assert.IsTrue(accountPage.IsMyAccountVisible());
        }

        [Test]
        public void InvalidLogin()
        {
            homePage.ClosePopUp();
            LoginPage loginPage = homePage.ClickOnAccountBtn();
            loginPage.EnterEmail(configuration.GetSection("TestData")["UserEmail"]);
            loginPage.EnterPswd(configuration.GetSection("TestData")["InvalidPassword"]);
            AccountPage accountPage = loginPage.ClickOnSignIn();

            Assert.IsTrue(loginPage.IsIncorrectCredentialsVisible());
        }
    }
}