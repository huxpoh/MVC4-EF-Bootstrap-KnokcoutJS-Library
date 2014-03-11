using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var role = Roles.GetRolesForUser(HttpContext.User.Identity.Name).First();
                return RedirectToAction("Index", role);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}