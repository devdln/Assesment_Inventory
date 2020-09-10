using Assesment.Inventory.Common.Util.Helpers;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Assesment.Inventory
{
    /// <summary>
    /// MvcApplication class
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Applications the start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Applications the error.
        /// </summary>
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            //log the error!
            LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);
        }
    }
}
