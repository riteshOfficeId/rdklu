using System.IO.Compression;
using AventStack.ExtentReports;

namespace TestProject
{
    [Parallelizable]
    public class DiscountVerification : TestBase
    {
        [Test]
        public void DiscountVerificationTest()
        {
            DealOfTheDayPage dealOfTheDayPage = homePage.GoToDealOfTheDayPage(configuration.GetSection("Url")["DotdUrl"]);
            dealOfTheDayPage.StoreProductsPriceDetails();
            for (int i = 0; i < 5; i++)
            {
                double expectedPrice = (100 - dealOfTheDayPage.ExtractNumericValue(dealOfTheDayPage.discountPercentageList[i].Text))
                                    * dealOfTheDayPage.PriceStringToInt(dealOfTheDayPage.originalPriceList[i].Text) / 100.00;
                expectedPrice = Math.Round(expectedPrice);
                double actualPrice = dealOfTheDayPage.PriceStringToInt(dealOfTheDayPage.discountedPriceList[i].Text);
                Assert.That(actualPrice, Is.EqualTo(expectedPrice).Within(5.0d));
            }
        }
    }
}