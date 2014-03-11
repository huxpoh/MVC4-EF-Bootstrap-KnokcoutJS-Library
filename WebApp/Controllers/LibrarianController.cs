using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class LibrarianController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
