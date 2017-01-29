using System.Collections.Generic;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using AccountingSystem.Services.Interfaces;

namespace AccountingSystem.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _currencyRepository.GetAll();
        }
    }
}