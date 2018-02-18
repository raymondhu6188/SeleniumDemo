using NUnit.Framework;
using Raymond.Costco.Web.AutoTest.Library.Pages;
using Raymond.Costco.Web.AutoTest.Library.Components;

namespace Raymond.Costco.Web.AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class FindWareHouseScenarios : Base
    {
        [Test]
        public void FindWareHouseScenarios_Basic()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            header.FindWarehouse("98052");

            WarehouseLocationsPage warehouseLocationsPage = new WarehouseLocationsPage(driver, wait);
            if (!warehouseLocationsPage.WaitAndVerifyLoadingCompletion(warehouseLocationsPage.DivListTable))
            {
                Assert.Fail("The WarehouseLocationsPage is not loaded during expected time. Quit.");
            }

            var list = warehouseLocationsPage.Warehouses;
            Assert.Greater(list.Count, 0);

            Assert.IsTrue(warehouseLocationsPage.DivMap.Displayed);
        }

        [Test]
        public void FindWareHouseScenarios_NoResult()
        {
            Header header = new Header(driver, wait);
            if (!header.WaitAndVerifyLoadingCompletion(header.DivSearch))
            {
                Assert.Fail("The HomePage is not loaded during expected time. Quit.");
            }

            header.FindWarehouse("asdasd");

            WarehouseLocationsPage warehouseLocationsPage = new WarehouseLocationsPage(driver, wait);
            if (!warehouseLocationsPage.WaitAndVerifyLoadingCompletion(warehouseLocationsPage.DivErrorContainer))
            {
                Assert.Fail("The WarehouseLocationsPage is not loaded during expected time. Quit.");
            }

            Assert.IsTrue(warehouseLocationsPage.DivMap.Displayed);
        }
    }
}
