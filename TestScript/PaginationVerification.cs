using AventStack.ExtentReports;

namespace TestProject
{
    [Parallelizable]
    public class PaginationVerificatoin : TestBase
    {
        [Test]
        public void CheckNumberOfProducts()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            MensTeesPage mensTeesPage = navBarMenSection.ClickOnMensTees();
            int listedProductsCountOnPage = mensTeesPage.GetCountOfProductsListedOnPage();

            Assert.That(listedProductsCountOnPage, Is.LessThan(24));
        }

        [Test]
        public void CheckPreviousBtnVisibility()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            MensTeesPage mensTeesPage = navBarMenSection.ClickOnMensTees();

            Assert.IsFalse(mensTeesPage.IsPreviousBtnVisible());
        }

        [Test]
        public void CheckNextBtnVisibility()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            MensTeesPage mensTeesPage = navBarMenSection.ClickOnMensTees();
            mensTeesPage.GoToPage(8);

            Assert.IsFalse(mensTeesPage.IsNextBtnVisible());
        }

        [Test]
        public void CheckUrlConatinsPageNumber()
        {
            NavBar navBar = homePage.ClickOnNavigationBtn();
            NavBarMenSection navBarMenSection = navBar.ClickOnMenSectionDropDown();
            MensTeesPage mensTeesPage = navBarMenSection.ClickOnMensTees();
            int pageNumber = 3;
            mensTeesPage.GoToPage(pageNumber);

            Assert.IsTrue(mensTeesPage.GetCurrentUrl().Contains($"page={pageNumber}"));
        }
    }
}