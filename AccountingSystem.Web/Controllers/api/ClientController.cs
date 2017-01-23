using System.Linq;
using System.Net;
using System.Net.Http;
using AccountingSystem.Services.Interfaces;

namespace AccountingSystem.Web.Controllers.api
{
    public class ClientController : BaseApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public object GetForSelect()
        {
            var items = _clientService.GetAll().Select(n => new
            {
                Value = n.Id.ToString(),
                Text = n.Name
            });
            return items;
        }
    }
}