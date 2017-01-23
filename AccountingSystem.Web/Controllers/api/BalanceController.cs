using System.Net;
using System.Net.Http;
using AccountingSyatem.Shared.Automapper;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Web.Models;

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
            var items = _balanceService.GetForClient(clientId).Select(new BalanceViewModel());
            return items;
        }
    }
}