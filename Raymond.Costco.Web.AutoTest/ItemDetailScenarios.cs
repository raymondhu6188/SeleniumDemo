using NUnit.Framework;
using Raymond.Costco.Web.AutoTest.Library.Pages;
using Raymond.Costco.Web.AutoTest.Library.Components;

namespace Raymond.Costco.Web.AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class ItemDetailScenarios : Base
    {
        [Test]
        public void ItemDetailScenarios_Basic()
        {
            Header header = new Header(driver, wait);

            header.Search("sofa");

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);
            catalogSearchPage.Items[0].ImgProduct.Click();

            ProductDetailPage productDetailPage = new ProductDetailPage(driver, wait);

            Assert.IsTrue(productDetailPage.DivProductImage.Displayed);
            Assert.IsTrue(productDetailPage.DivProductDetail.Displayed);
            Assert.IsNotEmpty(productDetailPage.LabelPrice.Text);
            Assert.IsNotEmpty(productDetailPage.LabelCrumbs.Text);

        }

    }
}
