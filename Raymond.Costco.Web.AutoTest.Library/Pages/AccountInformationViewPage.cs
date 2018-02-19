using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Raymond.Costco.Web.AutoTest.Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class AccountInformationViewPage : Base
    {
        public AccountInformationViewPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {
        }

        public IWebElement LabelLogonEmail
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("MembershipSignInInformation_logonEmail")));
            }
        }
    }
}
