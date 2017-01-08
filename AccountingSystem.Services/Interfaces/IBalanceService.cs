using System.Collections.Generic;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface IBalanceService
    {
        IEnumerable<BalanceModel> GetForClient(int clientId);
    }
}