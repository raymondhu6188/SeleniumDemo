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
                return driver.FindElement(By.Id("warehouse-list"));
            }
        }

        public IList<IWebElement> Warehouses
        {
            get
            {
                if (this.DivListTable.Displayed)
                {
                    return this.DivListTable.FindElements(By.XPath("tr[@class='warehouse table-row']")).Where(e => e.Displayed).ToList();
                }

                return null;
            }
        }

        public IWebElement DivMap
        {
            get
            {
                return driver.FindElement(By.Id("bing-map"));
            }
        }

        public IWebElement DivErrorContainer
        {
            get
            {
                return driver.FindElement(By.Id("error-container"));
            }
        }
        
    }
}
