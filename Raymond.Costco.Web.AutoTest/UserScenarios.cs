using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Raymond.Costco.Web.AutoTest.Library.Pages;
using Raymond.Costco.Web.AutoTest.Library.Components;
using Raymond.Costco.Web.AutoTest.Library;

namespace Raymond.Costco.Web.AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class UserScenarios : Base
    {
        [Test]
        public void UserScenarios_Register()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }
 
            Assert.AreEqual(@"Sign In / Register", header.LinkSignIn.Text);

            header.LinkSignIn.Click();

            LogonFormPage logonFormPage = new LogonFormPage(driver, wait);
            logonFormPage.WaitAndVerifyLoadingCompletion(logonFormPage.SubmitSignIn);
            logonFormPage.CreateAccount();

            RegisterViewPage registerViewPage = new RegisterViewPage(driver, wait);
            registerViewPage.WaitAndVerifyLoadingCompletion(registerViewPage.SubmitRegister);
            registerViewPage.Register(Tools.RandomString(7) + "@test.com", "Biscuit-1");

            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The redirected HomePage is not loaded after register during expected time. Quit.");
            }

            Assert.IsTrue(header.LinkMyAccount.Enabled);
        }

        [Test]
        public void UserScenarios_SignInOut()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            Assert.AreEqual(@"Sign In / Register", header.LinkSignIn.Text);

            header.LinkSignIn.Click();

            LogonFormPage logonFormPage = new LogonFormPage(driver, wait);
            logonFormPage.WaitAndVerifyLoadingCompletion(logonFormPage.SubmitSignIn);
            logonFormPage.SignIn("testhjy@test.com", "Biscuit-1");

            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The redirected HomePage is not loaded after register during expected time. Quit.");
            }

            Assert.IsTrue(header.LinkMyAccount.Enabled);

            header.SignOut();

            if (!logonFormPage.WaitAndVerifyLoadingCompletion(logonFormPage.SubmitSignIn))
            {
                Assert.Fail("The redirected logon is not loaded after signout expected time. Quit.");
            }
        }

        [Test]
        public void UserScenarios_AccountPage()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            Assert.AreEqual(@"Sign In / Register", header.LinkSignIn.Text);

            header.LinkSignIn.Click();

            LogonFormPage logonFormPage = new LogonFormPage(driver, wait);
            logonFormPage.WaitAndVerifyLoadingCompletion(logonFormPage.SubmitSignIn);
            logonFormPage.SignIn("testhjy@test.com", "Biscuit-1");

            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The redirected HomePage is not loaded after register during expected time. Quit.");
            }

            Assert.IsTrue(header.LinkMyAccount.Enabled);
            header.ShowUserMenu();

            var collection = header.UserPopMenuItems;
            int count = collection.Count;

            collection[0].Click();

            System.Threading.Thread.Sleep(2000);

            Assert.Greater(count, 0);
        }

    }
}
