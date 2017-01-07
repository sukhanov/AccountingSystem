using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountingSyatem.Shared.Automapper;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Services.Models;
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
            if (CheckHeader() == HttpStatusCode.Forbidden)
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "403 Error");
            return _transactionService.GetAll().OrderByDescending(n => n.DateTime).Select(new TransactionGridItemViewModel());
        }

        [HttpGet]
        public object GetTypesForSelect()
        {
            if (CheckHeader() == HttpStatusCode.Forbidden)
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "403 Error");

            var items = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>();
            var list = items.Select(n => new
            {
                Value = ((int)n).ToString(),
                Text = Enum.GetName(typeof(TransactionType), n)
            });
            return list;
        }

        [HttpGet]
        public object MoveToArchive()
        {
            if (CheckHeader() == HttpStatusCode.Forbidden)
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "403 Error");

            try
            {
                _transactionService.MoveToArchive();
                return new { success = true };
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
        public object Add(NewTransaction model)
        {
            if (CheckHeader() == HttpStatusCode.Forbidden)
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "403 Error");

            try
            {
                _transactionService.Create(model.MapTo(new TransactionModel()));
                return new { success = true };
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
    }
}
