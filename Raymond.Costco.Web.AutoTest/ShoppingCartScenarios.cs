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

            header.LinkCart.Click();

            CheckoutCartViewPage checkoutCartViewPage = new CheckoutCartViewPage(driver, wait);

            Assert.IsTrue(checkoutCartViewPage.ButtonContinueShoppingPrimary.Displayed);

            checkoutCartViewPage.ButtonContinueShoppingPrimary.Click();

            if (!header.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("Redirect failed after signed in");
            }
        }

        [Test]
        public void ShoppingCartScenarios_WithItems()
        {
            Header header = new Header(driver, wait);

            // step 1: search keyword1, and add the item into cart
            header.Search("sofa");

            CatalogSearchPage catalogSearchPage = new CatalogSearchPage(driver, wait);
            catalogSearchPage.Items[0].ImgProduct.Click();

            ProductDetailPage productDetailPage = new ProductDetailPage(driver, wait);
 
            Assert.IsTrue(productDetailPage.DivProductDetail.Displayed);
            Assert.IsTrue(productDetailPage.DivProductImage.Displayed);
            Assert.IsTrue(productDetailPage.DivProductDetail.Displayed);

            productDetailPage.AddToCart(2);

            ModelAddedCart modelAddedCart = new ModelAddedCart(driver, wait);
            // TODO: Wait for the model dialog - need to be updated instead of hardcoding here
            System.Threading.Thread.Sleep(5000);

            Assert.IsTrue(modelAddedCart.DivContent.Displayed);
            modelAddedCart.ButtonViewCart.Click();

            // step 2: verify shopping cart
            CheckoutCartViewPage checkoutCartViewPage = new CheckoutCartViewPage(driver, wait);
            Assert.IsTrue(checkoutCartViewPage.DivItemList.Displayed);
            Assert.IsTrue(checkoutCartViewPage.ButtonCheckout.Displayed);
            Assert.IsTrue(checkoutCartViewPage.ButtonContinueShopping.Displayed);
            Assert.AreEqual(1, checkoutCartViewPage.Items.Count);

            // step 3: add another item into shopping cart
            driver.Url = "https://www.costco.com/trunature-Resveratrol-Plus%2c-140-Vegetarian-Capsules.product.100118534.html";
            if (!productDetailPage.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("Redirect failed");
            }
            Assert.IsTrue(productDetailPage.DivProductDetail.Displayed);

            productDetailPage.AddToCart();

            // TODO: Wait for the model dialog - need to be updated instead of hardcoding here
            System.Threading.Thread.Sleep(5000);
            if (!modelAddedCart.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("The ModelAddedCart is not loaded during expected time");
            }

            modelAddedCart.ButtonViewCart.Click();

            // step 4: verify shopping cart
            if (!checkoutCartViewPage.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("The CheckoutCartViewPage is not loaded during expected time");
            }

            Assert.IsTrue(checkoutCartViewPage.ButtonCheckout.Displayed);
            Assert.IsTrue(checkoutCartViewPage.ButtonContinueShopping.Displayed);
            Assert.AreEqual(2, checkoutCartViewPage.Items.Count);

        }
    }
}
