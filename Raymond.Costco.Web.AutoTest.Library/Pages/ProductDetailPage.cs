using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class ProductDetailPage : Base
    {
        public ProductDetailPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement DivProduct
        {
            get
            {
                return driver.FindElement(By.Id("product-page"));
            }
        }
        public IWebElement LabelCrumbs
        {
            get
            {
                return driver.FindElement(By.Id("crumbs_ul"));
            }
        }

        public IWebElement LabelProductName
        {
            get
            {
                return DivProduct.FindElement(By.ClassName("product-h1-container"));
            }
        }

        public IWebElement DivProductImage
        {
            get
            {
                return DivProduct.FindElement(By.Id("productImageContainer"));
            }
        }

        public IWebElement DivProductDetail
        {
            get
            {
                return DivProduct.FindElement(By.Id("product-details"));
            }
        }
        public IWebElement LablePrice
        {
            get
            {
                return DivProductDetail.FindElement(By.XPath("div[@id='math-table']/span[@class='value']"));
            }
        }
        public IWebElement InputCount
        {
            get
            {
                return DivProductDetail.FindElement(By.Id("minQtyText"));
            }
        }
        public IWebElement ButtonAddCart
        {
            get
            {
                return DivProductDetail.FindElement(By.Name("add-to-cart"));
            }
        }

        public void AddToCart(int count = 1)
        {
            this.WaitAndVerifyLoadingCompletion(this.DivProductDetail);
            if (count >= 1)
            {
                this.InputCount.Click();
                this.InputCount.SendKeys(Keys.Control + "a");
                this.InputCount.SendKeys(count.ToString());
            }
            this.ButtonAddCart.Click();
        }
    }
}
