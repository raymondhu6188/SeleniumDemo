using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Raymond.Costco.Web.AutoTest.Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class CheckoutCartViewPage : Base
    {
        public CheckoutCartViewPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement FormShopCart
        {
            get
            {
                return driver.FindElement(By.Id("ShopCartForm"));
            }
        }

        #region WithItems
        public IWebElement ButtonContinueShopping
        {
            get
            {
                return driver.FindElement(By.Name("continueShopping"));
            }
        }
        public IWebElement ButtonCheckout
        {
            get
            {
                return driver.FindElement(By.Id("shopCartCheckoutSubmitButton"));
            }
        }

        public IWebElement DivItemList
        {
            get
            {
                return driver.FindElement(By.Id("order-items-regular"));
            }
        }

        public List<OrderItem> Items
        {
            get
            {
                if (!this.DivItemList.Displayed)
                {
                    return null;
                }

                List<OrderItem> items = new List<OrderItem>();

                var list = DivItemList.FindElements(By.XPath("/div[@class='order-item']/div")).ToList();
                if (list.Count > 0)
                {
                    foreach (var element in list)
                    {
                        items.Add(new OrderItem(this.driver, this.wait, element));
                    }
                }

                return items;
            }
        }

        public IWebElement LabelOrderTotal
        {
            get
            {
                return driver.FindElement(By.Id("order-estimated-total"));
            }
        }

        #endregion

        public IWebElement ButtonContinueShoppingPrimary
        {
            get
            {
                return driver.FindElement(By.Name("continue-shopping"));
            }
        }
    }
}
