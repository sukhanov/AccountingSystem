using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Repositories.Interfaces
{
    public interface IRateRepository
    {
        Rate GetByCurrencies(int from, int to);
    }
}