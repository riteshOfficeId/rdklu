using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace TestProject
{
    [Parallelizable]
    public class NavigationBarTest : TestBase
    {
        By _printedTeesBtn = By.XPath("//a[contains(text(),'Printed Tees')]");
        By _poloTeesBtn = By.XPath("//a[contains(text(),'Polo Tees')]");
        By _raglanTeesBtn = By.XPath("//a[contains(text(),'Raglan Tees')]");
        By _pocketTeesBtn = By.XPath("//a[contains(text(),'Pocket Tees')]");
        By _basicOversizeTeesBtn = By.XPath("//a[contains(text(),'Basic Oversize Tee')]");
        By _athleticoActiveTeesBtn = By.XPath("//a[contains(text(),'Athletico - Active Wear Tees')]");

        [Test]
        public void TestVisibilityOfSubMenusInMenSection()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            NavBarMenSectionTees navBarMenSectionTees = navBarMenSection.ClickOnTeesDropDown();
            Assert.IsTrue(navBarMenSectionTees.IsTeesOptionVisible(_pocketTeesBtn));
            Assert.IsTrue(navBarMenSectionTees.IsTeesOptionVisible(_basicOversizeTeesBtn));
            Assert.IsTrue(navBarMenSectionTees.IsTeesOptionVisible(_raglanTeesBtn));
            Assert.IsTrue(navBarMenSectionTees.IsTeesOptionVisible(_printedTeesBtn));
            Assert.IsTrue(navBarMenSectionTees.IsTeesOptionVisible(_poloTeesBtn));

            navBarMenSectionTees.ClickOnActiveWearDropDown();
            Assert.IsTrue(navBarMenSectionTees.IsTeesOptionVisible(_athleticoActiveTeesBtn));
        }
    }
}