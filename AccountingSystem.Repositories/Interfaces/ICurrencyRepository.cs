using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Repositories.Interfaces
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAll();
    }
}