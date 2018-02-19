using NUnit.Framework;
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
 
            Assert.AreEqual(@"Sign In / Register", header.LinkSignIn.Text);

            header.LinkSignIn.Click();

            LogonFormPage logonFormPage = new LogonFormPage(driver, wait);
            logonFormPage.CreateAccount();

            RegisterViewPage registerViewPage = new RegisterViewPage(driver, wait);
            registerViewPage.Register(Tools.RandomString(7) + "@test.com", "Biscuit-1");

            if(!header.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("Redirect failed after register completion");
            }

            Assert.IsTrue(header.LinkMyAccount.Enabled);
        }

        [Test]
        public void UserScenarios_SignInOut()
        {
            Header header = new Header(driver, wait);

            Assert.AreEqual(@"Sign In / Register", header.LinkSignIn.Text);

            header.LinkSignIn.Click();

            LogonFormPage logonFormPage = new LogonFormPage(driver, wait);
            logonFormPage.SignIn("testhjy@test.com", "Biscuit-1");

            if (!header.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("Redirect failed after signed in");
            }

            Assert.IsTrue(header.LinkMyAccount.Enabled);

            header.SignOut();

            if (!logonFormPage.WaitPageAjaxLoadingCompletion || !logonFormPage.SubmitSignIn.Displayed)
            {
                Assert.Fail("The redirected logon is not loaded after signout expected time. Quit.");
            }
        }

        [Test]
        public void UserScenarios_AccountPage()
        {
            Header header = new Header(driver, wait);

            Assert.AreEqual(@"Sign In / Register", header.LinkSignIn.Text);

            header.LinkSignIn.Click();

            LogonFormPage logonFormPage = new LogonFormPage(driver, wait);
            logonFormPage.SignIn("testhjy@test.com", "Biscuit-1");

            if (!header.WaitPageAjaxLoadingCompletion)
            {
                Assert.Fail("Redirect failed after register");
            }

            Assert.IsTrue(header.LinkMyAccount.Enabled);

            header.ShowUserMenu();

            var collection = header.UserPopMenuItems;
            Assert.Greater(collection.Count, 0);

            collection[0].Click();

            AccountInformationViewPage accountInformationViewPage = new AccountInformationViewPage(driver, wait);

            Assert.AreEqual("testhjy@test.com", accountInformationViewPage.LabelLogonEmail.Text);
        }

    }
}
