using System.Collections.Generic;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<CurrencyModel> GetAll();
    }
}