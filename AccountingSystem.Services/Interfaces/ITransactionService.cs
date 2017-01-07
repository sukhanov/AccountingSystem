using System.Collections.Generic;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface ITransactionService
    {
        void Create(TransactionModel model);
        void MoveToArchive();
        List<TransactionTableModel> GetAll();
    }
}