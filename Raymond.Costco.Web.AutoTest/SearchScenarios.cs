using NUnit.Framework;
using Raymond.Costco.Web.AutoTest.Library.Pages;
using Raymond.Costco.Web.AutoTest.Library.Components;

namespace Raymond.Costco.Web.AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class SearchScenarios : Base
    {
        [Test]
        public void SearchScenarios_Basic()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(header.DivSearch.Displayed);

            header.Search("sofa", 0);

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);
            if (!catalogSearchPage.WaitAndVerifyLoadingCompletion(catalogSearchPage.DivSearchResult))
            {
                Assert.Fail("The search catelog page is not loaded during expected time. Quit.");
            }

            Assert.IsNotEmpty(catalogSearchPage.LabelCrumbs.Text);      // Verification: Search crumbs
            Assert.IsNotEmpty(catalogSearchPage.LabelResult.Text);      // Verification: Search results

            var items = catalogSearchPage.Items;
            Assert.Greater(items.Count, 0);

            Assert.IsTrue(items[0].ImgProduct.Displayed);
            Assert.IsNotEmpty(items[0].LabelPrice.Text);
            Assert.IsNotEmpty(items[0].ProductName);
            Assert.IsNotEmpty(items[0].ProductLink);

            items[0].ImgProduct.Click();

            ProductDetailPage productDetailPage = new ProductDetailPage(driver, wait);
            if (!productDetailPage.WaitAndVerifyLoadingCompletion(productDetailPage.DivProductDetail))
            {
                Assert.Fail("The ProductDetailPage is not loaded during expected time. Quit.");
            }
        }

        [Test]
        public void SearchScenarios_NoResult()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(header.DivSearch.Displayed);

            header.Search("asdasdasd", -1);

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);
            if (!catalogSearchPage.WaitAndVerifyLoadingCompletion(catalogSearchPage.DivNoResult))
            {
                Assert.Fail("The search catelog page is not loaded during expected time. Quit.");
            }

            Assert.IsNotEmpty(catalogSearchPage.LabelCrumbs.Text);      // Verification: Search crumbs
        }
    }
}
