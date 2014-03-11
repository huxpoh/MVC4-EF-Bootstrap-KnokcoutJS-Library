using System.Data.Entity;
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
using WebApp.Helpers;

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

        //protected void Application_PostAuthenticateRequest()
        //{
        //    if (ClaimsPrincipal.Current.Identity.IsAuthenticated)
        //    {
        //        var transformer = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager;
        //        var newPrincipal = transformer.Authenticate(string.Empty, ClaimsPrincipal.Current);

        //        Thread.CurrentPrincipal = newPrincipal;
        //        HttpContext.Current.User = newPrincipal;
        //    }
        //}


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