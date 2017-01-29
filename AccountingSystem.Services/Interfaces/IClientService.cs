using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
    }
}