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
                return driver.FindElement(By.Id("logonId"));
            }
        }

        public IWebElement InputPassword
        {
            get
            {
                return driver.FindElement(By.Id("logonPassword"));
            }
        }
        
        public IWebElement SubmitSignIn
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@type='submit' and @value='Sign In']"));
            }
        }

        public IWebElement LinkCreateAccount
        {
            get
            {
                return driver.FindElement(By.LinkText("Create Account"));
            }
        }
        protected IWebElement DivLogon
        {
            get
            {
                return driver.FindElement(By.Id("logon"));
            }
        }


        public void SignIn(string email, string password)
        {
            this.WaitAndVerifyLoadingCompletion(this.DivLogon);

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
