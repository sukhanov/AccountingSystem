using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        string Create(NewTransaction tran);
        void MoveTorchive();
    }
}