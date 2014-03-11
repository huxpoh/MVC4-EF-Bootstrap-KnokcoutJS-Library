using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class LibrarianController : Controller
    {
        //
        // GET: /Librarian/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Librarian/Details/5

        [HttpGet]
        public JsonResult Details(int id)
        {
            return Json("w");
        }

        //
        // GET: /Librarian/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Librarian/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

  

        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
