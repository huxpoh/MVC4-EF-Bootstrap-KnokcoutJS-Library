using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Library.EF_DataLayer;

namespace WebApp.Controllers
{
    public class BaseApiController : ApiController
    {
        protected UnitOfWork UnitOfWork;

        public BaseApiController()
        {
            UnitOfWork = new UnitOfWork();
            UnitOfWork._libraryContext = (LibraryContext)HttpContext.Current.Items["_context"];
        }

        protected void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}
