using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetAll();
    }
}