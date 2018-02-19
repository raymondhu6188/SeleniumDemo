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

            header.FindWarehouse("98052");

            WarehouseLocationsPage warehouseLocationsPage = new WarehouseLocationsPage(driver, wait);

            Assert.IsTrue(warehouseLocationsPage.DivListTable.Displayed);

            var list = warehouseLocationsPage.Warehouses;
            Assert.Greater(list.Count, 0);

            Assert.IsTrue(warehouseLocationsPage.DivMap.Displayed);
        }

        [Test]
        public void FindWareHouseScenarios_NoResult()
        {
            Header header = new Header(driver, wait);

            header.FindWarehouse("asdasd");

            WarehouseLocationsPage warehouseLocationsPage = new WarehouseLocationsPage(driver, wait);

            Assert.IsTrue(warehouseLocationsPage.DivErrorContainer.Displayed);
            Assert.IsTrue(warehouseLocationsPage.DivMap.Displayed);
        }
    }
}
