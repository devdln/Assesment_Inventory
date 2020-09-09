using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Assesment.Inventory.Common.Ioc
{
    public static class IocResolver
    {
        private static readonly IUnityContainer container = new UnityContainer();

        static IocResolver()
        {
            try
            {
                container.LoadConfiguration("CommonContainer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
