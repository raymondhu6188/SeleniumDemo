using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Raymond.Costco.Web.AutoTest.Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class CatalogSearchPage : Base
    {
        public CatalogSearchPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement LabelCrumbs
        {
            get
            {
                return driver.FindElement(By.Id("crumbs_ul"));
            }
        }

        public IWebElement DivSearchFilter
        {
            get
            {
                return driver.FindElement(By.Id("search-filter"));
            }
        }
        public IWebElement DivSearchResult
        {
            get
            {
                return driver.FindElement(By.Id("search-results"));
            }
        }

        public IWebElement LabelResult
        {
            get
            {
                return DivSearchResult.FindElement(By.ClassName("toolbar"));
            }
        }

        /// <summary>
        /// Return the search product item list
        /// </summary>
        public List<ProductTile> Items
        {
            get
            {
                if (!this.DivSearchResult.Displayed)
                {
                    return null;
                }

                List<ProductTile> items = new List<ProductTile>();

                var list = DivSearchResult.FindElements(By.XPath("//div[@class='product-tile-set']")).ToList();
                if (list.Count > 0)
                {
                    foreach(var element in list)
                    {
                        items.Add(new ProductTile(this.driver, this.wait, element));
                    }
                }

                return items;
            }
        }
        public IWebElement DivNoResult
        {
            get
            {
                return driver.FindElement(By.Id("no-results"));
            }
        }
    }
}
