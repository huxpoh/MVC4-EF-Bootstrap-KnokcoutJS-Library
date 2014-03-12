using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles="reader")]
    public class ReaderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
