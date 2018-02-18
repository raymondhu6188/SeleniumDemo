using NUnit.Framework;
using Raymond.Costco.Web.AutoTest.Library.Pages;
using Raymond.Costco.Web.AutoTest.Library.Components;

namespace Raymond.Costco.Web.AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class ItemDetailScenarios : Base
    {
        [Test]
        public void ItemDetailScenarios_Basic()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }
        }

    }
}
