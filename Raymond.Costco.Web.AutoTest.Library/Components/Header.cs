using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raymond.Costco.Web.AutoTest.Library.Components
{
    public class Header : Base
    {
        public Header(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        #region Top Links
        public IWebElement LinkFindWarehouse
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("warehouse-locations")));
            }
        }
        public IWebElement DivFindWarehouse
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("warehouse-locations-id")));
            }
        }
        public IWebElement InputWarehouseSearch
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("warehouse-search-field")));
            }
        }
        public IWebElement InputWarehouseSearchButton
        {
            get
            {
                return wait.Until(d => d.FindElement(By.XPath("//input[@type='submit' and @value='Find a Warehouse']")));
            }
        }
        #endregion

        public IWebElement LinkSignIn
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("header_sign_in")));
            }
        }

        public IWebElement LinkMyAccount
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("myaccount-d")));
            }
        }

        public IWebElement LinkCart
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("cart-d")));
            }
        }

        // can be emtpy if no cookie saved. 
        public IWebElement DivCartCount
        {
            get
            {
                return wait.Until(d => d.FindElement(By.ClassName("cart-number")));
            }
        }
        #region User Menu
        public IWebElement DivPopOverContent
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("my-account-popover-container")));
            }
        }

        public IList<IWebElement> UserPopMenuItems
        {
            get
            {
                if(this.DivPopOverContent.Displayed)
                {
                    return wait.Until(d => this.DivPopOverContent.FindElements(By.XPath("ol/li"))).ToList();
                }

                return null;
            }
        }

        public IWebElement SubmitSignOut
        {
            get
            {
                return wait.Until(d => d.FindElement(By.XPath("//input[@type='submit' and @value='Sign Out']")));
            }
        }
        #endregion

        #region Search WebElements
        public IWebElement DivSearch
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("search-widget")));
            }
        }
        
        public IWebElement BtnGroceryDown
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("grocery-dropdown")));
            }
        }

        public IWebElement InputSearch
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("search-field")));
            }
        }
        public IWebElement InputSearchButton
        {
            get
            {
                return wait.Until(d => d.FindElement(By.ClassName("co-search-thin")));
            }
        }

        public IList<IWebElement> LinkSearchGroceries
        {
            get
            {
                var ul = wait.Until(d => this.DivSearch.FindElement(By.ClassName("dropdown-menu")));

                if (ul.Displayed)
                {
                    return wait.Until(d => ul.FindElements(By.XPath("li/a"))).ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        
        #endregion

        /// <summary>
        /// Action: Mouse over "My Account" to show the User Menu
        /// Signed In status required
        /// </summary>
        public void ShowUserMenu()
        {
            this.ScrollIntoView(this.LinkMyAccount);
            this.MouseOver(this.LinkMyAccount);
        }

        /// <summary>
        /// Action: Click Sign Out from User Menu
        /// Signed In status required
        /// </summary>
        public void SignOut()
        {
            this.ShowUserMenu();
            this.SubmitSignOut.Click();
        }

        /// <summary>
        /// Action: Operate the whole search action on the header
        /// </summary>
        /// <param name="keyword">Search content</param>
        /// <param name="selectedGrocery">Optioanl. The selected displayed grocery index value from 0 on UI page</param>
        public void Search(string keyword, int selectedGrocery = -1)
        {
            if (string.IsNullOrEmpty(keyword))
                return;

            this.ScrollIntoView(this.InputSearch);
            if (selectedGrocery > -1)
            {
                this.BtnGroceryDown.Click();
                System.Threading.Thread.Sleep(500);

                var groceries = this.LinkSearchGroceries;
                if (groceries.Count > selectedGrocery)
                {
                    groceries[selectedGrocery].Click();
                }

            }
            this.InputSearch.Click();
            this.InputSearch.SendKeys(keyword);
            this.InputSearchButton.Click();
        }


        public void FindWarehouse(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return;

            this.ScrollIntoView(this.LinkFindWarehouse);

            this.MouseOver(this.LinkFindWarehouse);
            System.Threading.Thread.Sleep(500);
            this.InputWarehouseSearch.Click();
            this.InputWarehouseSearch.SendKeys(keyword);
            this.InputWarehouseSearchButton.Click();
        }
    }
}
