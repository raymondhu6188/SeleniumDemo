using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace Raymond.Costco.Web.AutoTest
{
    public class Base
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public TimeSpan DefaultTimeSpan = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["DefaultTimeSpan"]));

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, DefaultTimeSpan);

            driver.Url = ConfigurationManager.AppSettings["Homepage"];
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
