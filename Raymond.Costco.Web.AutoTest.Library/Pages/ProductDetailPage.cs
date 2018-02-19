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
                return wait.Until(d => d.FindElement(By.Id("product-page")));
            }
        }
        public IWebElement LabelCrumbs
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("crumbs_ul")));
            }
        }

        public IWebElement LabelProductName
        {
            get
            {
                return wait.Until(d => d.FindElement(By.XPath("//h1[@itemprop='name']")));
            }
        }

        public IWebElement DivProductImage
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("productImageContainer")));
            }
        }

        public IWebElement DivProductDetail
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("product-details")));
            }
        }
        public IWebElement LabelPrice
        {
            get
            {
                return wait.Until(d => DivProductDetail.FindElement(By.XPath("//div[@id='math-table']")).FindElement(By.XPath("//span[@class='value']")));
            }
        }
        public IWebElement InputCount
        {
            get
            {
                return wait.Until(d => DivProductDetail.FindElement(By.Id("minQtyText")));
            }
        }
        public IWebElement ButtonAddCart
        {
            get
            {
                return wait.Until(d => DivProductDetail.FindElement(By.Name("add-to-cart")));
            }
        }

        public void AddToCart(int count = 1)
        {
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
