using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Spa.Controllers
{
    public class ReaderController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllBooks()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
