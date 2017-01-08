using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AccountingSystem.Web.Helpers;

namespace AccountingSystem.Web.Controllers.api
{
    [FilterIP(IPsConfig = "AllowedIPs")]
    [RequireHttps]
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