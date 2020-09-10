using Assesment.Inventory.Core.API.Item;
using Assesment.Inventory.Core.Item;
using Assesment.Inventory.Data.EntityManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Assesment.Inventory.App_Start
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRepository, BaseRepository>();
            container.RegisterType<IItemService, ItemService>();
        }
    }
}