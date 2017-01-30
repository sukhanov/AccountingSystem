using System.Globalization;
using System.Linq;
using System.Web.WebPages.Html;
using AccountingSystem.Services.Interfaces;

namespace AccountingSystem.Web.Controllers.api
{
    public class BalanceController : BaseApiController
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public object GetForClient(int clientId)
        {
            var items = _balanceService.GetForClient(clientId).Select(n=>new SelectListItem {Text = n.Currency, Value = n.Id.ToString()});
            return items;
        }

        public object GetAmountForClient(int clientId)
        {
            var items = _balanceService.GetForClient(clientId).Select(n => new SelectListItem { Text = n.Currency, Value = n.Amount.ToString(CultureInfo.InvariantCulture) });
            return items;
        }
    }
}