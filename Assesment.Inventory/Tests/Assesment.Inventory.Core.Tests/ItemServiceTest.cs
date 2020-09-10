using System;
using Assesment.Inventory.Common.Ioc;
using Assesment.Inventory.Common.Model.Item;
using Assesment.Inventory.Core.API.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assesment.Inventory.Core.Tests
{
    [TestClass]
    public class ItemServiceTest
    {
        [TestMethod]
        public void DeleteTestMethod()
        {
            try
            {
                IItemService itemService = IocResolver.Resolve<IItemService>();

                bool isSuccess = itemService.Delete(1, new ItemDTO { LoggedUserId = "TestUserId" });

                Assert.AreEqual(true, isSuccess);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void CreateTestMethod()
        {
            try
            {
                ItemDTO item = new ItemDTO { Id = 1, Name = "Red Rice", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, LoggedUserId = "TestUserId" };

                IItemService itemService = IocResolver.Resolve<IItemService>();

                ItemDTO createdItem = itemService.Create(item);

                Assert.AreEqual(item, createdItem);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void UpdateTestMethod()
        {
            try
            {
                ItemDTO item = new ItemDTO { Id = 1, Name = "Red Rice", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, LoggedUserId = "TestUserId" };

                IItemService itemService = IocResolver.Resolve<IItemService>();

                ItemDTO createdItem = itemService.Update(item);

                Assert.AreEqual(item, createdItem);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
