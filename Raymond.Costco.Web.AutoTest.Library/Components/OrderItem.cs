using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Raymond.Costco.Web.AutoTest.Library.Components
{
    /// <summary>
    /// The component of items in shopping cart page
    /// </summary>
    public class OrderItem : Base
    {
        private IWebElement container;
        public OrderItem(IWebDriver d, WebDriverWait w, IWebElement c) : base(d, w)
        {
            this.container = c;
        }

        public IWebElement ImgProduct
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.ClassName("img-responsive")));
            }
        }

        public string ProductName
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.XPath("//div[@class='product-title']/a"))).Text;
            }
        }

        public string ProductUnitPrice
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.XPath("//span[@class='price']"))).Text;
            }
        }
        public string ProductTotalPrice
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.XPath("//div[@class='item-total']//span[@class='price']"))).Text;
            }
        }

        public IWebElement InputQuantity
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.Id("quantity")));
            }
        }

        public IWebElement InputUpdate
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.Id("update_link_")));
            }
        }

        public IWebElement InputRemove
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.LinkText("Remove")));
            }
        }
    }
}
