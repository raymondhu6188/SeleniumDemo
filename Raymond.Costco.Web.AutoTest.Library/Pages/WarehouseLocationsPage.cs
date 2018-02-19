using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class WarehouseLocationsPage : Base
    {
        public WarehouseLocationsPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement DivListTable
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("warehouse-list")));
            }
        }

        public IList<IWebElement> Warehouses
        {
            get
            {
                if (this.DivListTable.Displayed)
                {
                    return wait.Until(d => DivListTable.FindElements(By.XPath("tr[@class='warehouse table-row']"))).ToList();
                }

                return null;
            }
        }

        public IWebElement DivMap
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("bing-map")));
            }
        }

        public IWebElement DivErrorContainer
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("error-container")));
            }
        }
        
    }
}
