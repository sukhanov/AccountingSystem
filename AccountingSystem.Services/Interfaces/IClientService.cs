using System.Collections.Generic;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientModel> GetAll();
    }
}