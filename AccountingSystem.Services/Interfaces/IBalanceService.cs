using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface IBalanceService
    {
        IEnumerable<Balance> GetForClient(int clientId);
    }
}