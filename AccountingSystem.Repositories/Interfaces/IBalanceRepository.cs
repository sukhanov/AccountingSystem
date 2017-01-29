using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Repositories.Interfaces
{
    public interface IBalanceRepository
    {
        IEnumerable<Balance> GetByClientId(int clientId);
        Balance GetById(int id);
    }
}