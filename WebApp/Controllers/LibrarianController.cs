﻿using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles="librarian")]
    public class LibrarianController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
