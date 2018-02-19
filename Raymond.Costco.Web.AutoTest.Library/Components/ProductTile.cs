using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Raymond.Costco.Web.AutoTest.Library.Components
{
    /// <summary>
    /// The component of product tile in catalog search result page
    /// </summary>
    public class ProductTile : Base
    {
        private IWebElement container;
        public ProductTile(IWebDriver d, WebDriverWait w, IWebElement c) : base(d, w)
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

        public IWebElement LabelPrice
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.XPath("//div[@class='price']")));
            }
        }

        public string ProductName
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.XPath("//p[@class='description']"))).Text;
            }
        }

        public string ProductLink
        {
            get
            {
                return wait.Until(d => this.container.FindElement(By.XPath("//p[@class='description']/a"))).GetAttribute("href");
            }
        }
    }
}
