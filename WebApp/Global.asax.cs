using System.Data.Entity;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Library.EF_DataLayer;
using Library.WebPr.App_Start;
using WebApp.App_Start;

namespace WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            AuthConfig.RegisterAuth();

            Database.SetInitializer(new EfInitializer());
        }

        protected void Application_BeginRequest()
        {
            HttpContext.Current.Items["_context"] = new LibraryContext();
        }

        protected void Application_EndRequest()
        {
            var context = HttpContext.Current.Items["_context"] as LibraryContext;
            if (context != null)
                context.Dispose();
        }
    }
}