using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApp.Helpers
{
    //public class AuthorizeVerifiedUsersAttribute : AuthorizeAttribute
    //{

    //    protected override bool IsAuthorized(HttpActionContext actionContext)
    //    {
    //        if (HttpContext.Current.User.Identity.IsAuthenticated)
    //        {
    //            //retrieve controller action's authorization attributes
    //            var authorizeAttributes =
    //                actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeVerifiedUsersAttribute>();

    //            //check controller and action BypassValidation value
    //            return true;

    //            return base.IsAuthorized(actionContext);
    //        }
    //        return true;
    //    }
    //}
}