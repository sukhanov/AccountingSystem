using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AccountingSystem.Services.Interfaces;

namespace AccountingSystem.Web.Controllers.api
{
    public class CurrencyController : BaseApiController
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public object GetForSelect()
        {
            if (CheckHeader() == HttpStatusCode.Forbidden)
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "403 Error");

            var items = _currencyService.GetAll().Select(n => new
            {
                Value = n.Id.ToString(),
                Text = n.Code
            });
            return items;
        }
    }
}