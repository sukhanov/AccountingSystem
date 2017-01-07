using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AccountingSystem.Web.Controllers.api
{
    public class BaseApiController:ApiController
    {
        protected HttpStatusCode CheckHeader()
        {
            var request = HttpContext.Current.Request;
            if (request.Headers["Application"] == null || !request.Headers["Application"].Equals("Accounting-System"))
                return HttpStatusCode.Forbidden;
            return HttpStatusCode.OK;
        }
    }
}