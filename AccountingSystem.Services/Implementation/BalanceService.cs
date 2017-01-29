using System.Collections.Generic;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using AccountingSystem.Services.Interfaces;

namespace AccountingSystem.Services.Implementation
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceService(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public IEnumerable<Balance> GetForClient(int clientId)
        {
            return _balanceRepository.GetByClientId(clientId);
        }
    }
}