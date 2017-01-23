using System.Web.Http;
using System.Web.Mvc;
using AccountingSystem.Web.Helpers;

namespace AccountingSystem.Web.Controllers.api
{
    [FilterIP(IPsConfig = "AllowedIPs")]
    [RequireHttps]
    public class BaseApiController : ApiController
    {
    }
}