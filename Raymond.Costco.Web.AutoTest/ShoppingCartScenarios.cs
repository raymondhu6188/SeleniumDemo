using NUnit.Framework;
using Raymond.Costco.Web.AutoTest.Library.Pages;
using Raymond.Costco.Web.AutoTest.Library.Components;

namespace Raymond.Costco.Web.AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class ShoppingCartScenarios : Base
    {
        [Test]
        public void ShoppingCartScenarios_NoItems()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.LinkCart))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            header.LinkCart.Click();

            CheckoutCartViewPage checkoutCartViewPage = new CheckoutCartViewPage(driver, wait);
            if (!checkoutCartViewPage.WaitAndVerifyLoadingCompletion(checkoutCartViewPage.FormShopCart))
            {
                Assert.Fail("The CheckoutCartViewPage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(checkoutCartViewPage.ButtonContinueShoppingPrimary.Displayed);

            checkoutCartViewPage.ButtonContinueShoppingPrimary.Click();

            if (!header.WaitAndVerifyLoadingCompletion(header.LinkCart))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }
        }

        [Test]
        public void ShoppingCartScenarios_WithItems()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.LinkCart))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            // step 1: search keyword1, and add the item into cart
            header.Search("sofa");

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);
            if (!catalogSearchPage.WaitAndVerifyLoadingCompletion(catalogSearchPage.DivSearchResult))
            {
                Assert.Fail("The search catelog page is not loaded during expected time. Quit.");
            }

            catalogSearchPage.Items[0].ImgProduct.Click();

            ProductDetailPage productDetailPage = new ProductDetailPage(driver, wait);
            if (!productDetailPage.WaitAndVerifyLoadingCompletion(productDetailPage.DivProductDetail))
            {
                Assert.Fail("The ProductDetailPage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(productDetailPage.DivProductImage.Displayed);
            Assert.IsTrue(productDetailPage.DivProductDetail.Displayed);

            productDetailPage.AddToCart(2);

            ModelAddedCart modelAddedCart = new ModelAddedCart(driver, wait);
            if (!modelAddedCart.WaitAndVerifyLoadingCompletion(modelAddedCart.DivContent))
            {
                Assert.Fail("The ModelAddedCart is not loaded during expected time. Quit.");
            }

            modelAddedCart.ButtonViewCart.Click();

            // step 2: verify shopping cart
            CheckoutCartViewPage checkoutCartViewPage = new CheckoutCartViewPage(driver, wait);
            if (!checkoutCartViewPage.WaitAndVerifyLoadingCompletion(checkoutCartViewPage.DivItemList))
            {
                Assert.Fail("The CheckoutCartViewPage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(checkoutCartViewPage.ButtonCheckout.Displayed);
            Assert.IsTrue(checkoutCartViewPage.ButtonContinueShopping.Displayed);
            Assert.AreEqual(1, checkoutCartViewPage.Items.Count);

            // step 3: add another item into shopping cart
            driver.Url = "https://www.costco.com/trunature-Resveratrol-Plus%2c-140-Vegetarian-Capsules.product.100118534.html";
            if (!productDetailPage.WaitAndVerifyLoadingCompletion(productDetailPage.DivProductDetail))
            {
                Assert.Fail("The ProductDetailPage is not loaded during expected time. Quit.");
            }

            productDetailPage.AddToCart();

            if (!modelAddedCart.WaitAndVerifyLoadingCompletion(modelAddedCart.DivContent))
            {
                Assert.Fail("The ModelAddedCart is not loaded during expected time. Quit.");
            }

            modelAddedCart.ButtonViewCart.Click();

            // step 4: verify shopping cart
            if (!checkoutCartViewPage.WaitAndVerifyLoadingCompletion(checkoutCartViewPage.DivItemList))
            {
                Assert.Fail("The CheckoutCartViewPage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(checkoutCartViewPage.ButtonCheckout.Displayed);
            Assert.IsTrue(checkoutCartViewPage.ButtonContinueShopping.Displayed);
            Assert.AreEqual(2, checkoutCartViewPage.Items.Count);

        }
    }
}
