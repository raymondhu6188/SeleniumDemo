using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class LogonFormPage : Base
    {
        public LogonFormPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement InputEmail
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("logonId")));
            }
        }

        public IWebElement InputPassword
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("logonPassword")));
            }
        }
        
        public IWebElement SubmitSignIn
        {
            get
            {
                return wait.Until(d => d.FindElement(By.XPath("//input[@type='submit' and @value='Sign In']")));
            }
        }

        public IWebElement LinkCreateAccount
        {
            get
            {
                return wait.Until(d => d.FindElement(By.LinkText("Create Account")));
            }
        }
        protected IWebElement DivLogon
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("logon")));
            }
        }


        public void SignIn(string email, string password)
        {
            this.InputEmail.Click();
            this.InputEmail.SendKeys(email);
            this.InputPassword.Click();
            this.InputPassword.SendKeys(password);

            this.ScrollIntoView(this.SubmitSignIn);
            this.SubmitSignIn.Click();
        }

        public void CreateAccount()
        {
            this.ScrollIntoView(this.LinkCreateAccount);
            this.LinkCreateAccount.Click();
        }
    }
}
