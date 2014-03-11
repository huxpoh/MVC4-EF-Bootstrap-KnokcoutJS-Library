using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebApp
{
    //public class ClaimsTransformer : ClaimsAuthenticationManager
    //{
    //    public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
    //    {
    //        if (!incomingPrincipal.Identity.IsAuthenticated)
    //        {
    //            return base.Authenticate(resourceName, incomingPrincipal);
    //        }

    //        var name = incomingPrincipal.Identity.Name;

    //        return Principal.Create("Custom",new Claim(ClaimTypes.Name, name + " (transformed)"));
    //    }
    //}

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var authConfig = new AuthenticationConfiguration
            //{
            //    InheritHostClientIdentity = true,
            //    ClaimsAuthenticationManager = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager
            //};

            //// setup authentication against membership
            //authConfig.AddBasicAuthentication((userName, password) => Membership.ValidateUser(userName, password));

            //config.MessageHandlers.Add(new AuthenticationHandler(authConfig));


            config.EnableSystemDiagnosticsTracing();

            // Use camel case for JSON data.
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
