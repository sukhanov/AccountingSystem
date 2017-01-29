using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface ITransactionService
    {
        string Create(NewTransaction tran);
        void MoveToArchive();
        IEnumerable<Transaction> GetAll();
    }
}