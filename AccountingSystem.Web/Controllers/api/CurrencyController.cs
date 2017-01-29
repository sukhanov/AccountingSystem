using System.Linq;
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
            var items = _currencyService.GetAll().Select(n => new
            {
                Value = n.Id.ToString(),
                Text = n.Code
            });
            return items;
        }
    }
}