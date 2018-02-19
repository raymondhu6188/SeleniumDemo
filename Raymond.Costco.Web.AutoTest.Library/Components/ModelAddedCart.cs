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
                return wait.Until(d => d.FindElement(By.ClassName("modal-content")));
            }
        }

        public IWebElement ButtonContinueShopping
        {
            get
            {
                return wait.Until(d => DivContent.FindElement(By.ClassName("btn-tertiary")));
            }
        }
        public IWebElement ButtonViewCart
        {
            get
            {
                return wait.Until(d => DivContent.FindElement(By.ClassName("btn-primary")));
            }
        }

        public IWebElement LiItemDetail
        {
            get
            {
                return wait.Until(d => DivContent.FindElement(By.ClassName("item-details")));
            }
        }
    }
}
