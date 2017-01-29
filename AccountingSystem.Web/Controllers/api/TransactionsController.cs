using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountingSyatem.Shared.Automapper;
using AccountingSystem.Models;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Shared.Infra;
using AccountingSystem.Web.Models;

namespace AccountingSystem.Web.Controllers.api
{
    public class TransactionsController : BaseApiController
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public object GetAll()
        {
            return
                _transactionService.GetAll()
                    .OrderByDescending(n => n.DateTime)
                    .Select(new TransactionGridItemViewModel());
        }

        [HttpGet]
        public object GetTypesForSelect()
        {
            var items = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>();
            var list = items.Select(n => new
            {
                Value = ((int) n).ToString(),
                Text = Enum.GetName(typeof(TransactionType), n)
            });
            return list;
        }

        [HttpGet]
        public object MoveToArchive()
        {
            try
            {
                _transactionService.MoveToArchive();
                return new {success = true};
            }
            catch (Exception e)
            {
                return new
                {
                    message = e.Message,
                    success = false
                };
            }
        }

        [HttpPost]
        public HttpResponseMessage Add(NewTransactionModel model)
        {
            string error;

            try
            {
                error = _transactionService.Create(model.MapTo(new NewTransaction()));
            }
            catch(ServiceException e)
            {
                error = e.Message;
            }
            catch(Exception e)
            {
                error = "Failed create transaction";
            }

            return string.IsNullOrWhiteSpace(error) ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
        }
    }
}