using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AccountingSystem.Web.Helpers
{
    public class FilterHeader : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var request = HttpContext.Current.Request;
            return request.Headers["X-Application"] != null && request.Headers["X-Application"].Equals("Accounting-System");
        }
    }
}