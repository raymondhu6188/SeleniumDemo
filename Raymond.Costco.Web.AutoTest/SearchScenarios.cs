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

            Assert.IsTrue(header.DivSearch.Displayed);

            header.Search("sofa", 0);

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);

            Assert.IsNotEmpty(catalogSearchPage.LabelCrumbs.Text);      // Verification: Search crumbs
            Assert.IsNotEmpty(catalogSearchPage.LabelResult.Text);      // Verification: Search results

            var items = catalogSearchPage.Items;
            Assert.Greater(items.Count, 0);                             // Verification: Search results

            Assert.IsTrue(items[0].ImgProduct.Displayed);
            Assert.IsNotEmpty(items[0].LabelPrice.Text);
            Assert.IsNotEmpty(items[0].ProductName);
            Assert.IsNotEmpty(items[0].ProductLink);

            items[0].ImgProduct.Click();

            ProductDetailPage productDetailPage = new ProductDetailPage(driver, wait);
            Assert.IsTrue(productDetailPage.DivProductDetail.Displayed);
        }

        [Test]
        public void SearchScenarios_NoResult()
        {
            Header header = new Header(driver, wait);

            Assert.IsTrue(header.DivSearch.Displayed);

            header.Search("asdasdasd");

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);

            Assert.IsTrue(catalogSearchPage.DivNoResult.Displayed);     // Verification: No Result Div
            Assert.IsNotEmpty(catalogSearchPage.LabelCrumbs.Text);      // Verification: Search crumbs
        }
    }
}
