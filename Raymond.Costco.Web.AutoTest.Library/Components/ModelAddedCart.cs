using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Raymond.Costco.Web.AutoTest.Library.Components
{
    public class ModelAddedCart : Base
    {
        public ModelAddedCart(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement DivContent
        {
            get
            {
                return driver.FindElement(By.ClassName("modal-content"));
            }
        }

        public IWebElement ButtonContinueShopping
        {
            get
            {
                return DivContent.FindElement(By.ClassName("btn btn-tertiary btn-block"));
            }
        }
        public IWebElement ButtonViewCart
        {
            get
            {
                return DivContent.FindElement(By.ClassName("btn btn-primary btn-block"));
            }
        }

        public IWebElement LiItemDetail
        {
            get
            {
                return DivContent.FindElement(By.ClassName("item-details"));
            }
        }
    }
}
