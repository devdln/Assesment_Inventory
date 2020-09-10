using Assesment.Inventory.Common.Util.Helpers;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Reflection;
using Unity;

namespace Assesment.Inventory.Common.Ioc
{
    /// <summary>
    /// IocResolver class
    /// </summary>
    public static class IocResolver
    {
        /// <summary>
        /// The container
        /// </summary>
        private static readonly IUnityContainer container = new UnityContainer();

        /// <summary>
        /// Initializes the <see cref="IocResolver"/> class.
        /// </summary>
        static IocResolver()
        {
            try
            {
                // load unity configuration from web config section
                container.LoadConfiguration("CommonContainer");
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
