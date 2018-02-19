using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Raymond.Costco.Web.AutoTest.Library.Pages
{
    public class RegisterViewPage : Base
    {
        public RegisterViewPage(IWebDriver d, WebDriverWait w) : base(d, w)
        {

        }

        public IWebElement InputEmail
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("register_email1")));
            }
        }

        public IWebElement InputPassword
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("logonPassword")));
            }
        }

        public IWebElement InputPasswordVerify
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("logonPasswordVerify")));
            }
        }

        public IWebElement InputMembership
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("register_userField2")));
            }
        }

        public IWebElement SubmitRegister
        {
            get
            {
                return wait.Until(d => d.FindElement(By.XPath("//input[@type='submit' and @value='Register']")));
            }
        }
        
        public IWebElement InputSendEmail
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("register_sendMeEmail")));
            }
        }

        protected IWebElement DivRegister
        {
            get
            {
                return wait.Until(d => d.FindElement(By.Id("register")));
            }
        }

        public void Register(string email, string password, string membership = "")
        {
            this.InputEmail.Click();
            this.InputEmail.SendKeys(email);
            this.InputPassword.Click();
            this.InputPassword.SendKeys(password);
            this.InputPasswordVerify.Click();
            this.InputPasswordVerify.SendKeys(password);
            if(!string.IsNullOrEmpty(membership))
            {
                this.InputMembership.Click();
                this.InputMembership.SendKeys(membership);
            }
            this.ScrollIntoView(this.SubmitRegister);
            this.SubmitRegister.Click();
        }
    }
}
