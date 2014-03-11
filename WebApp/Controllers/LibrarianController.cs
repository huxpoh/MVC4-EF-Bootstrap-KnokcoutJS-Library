using System.Web.Mvc;
using Library.Model.Models;

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
