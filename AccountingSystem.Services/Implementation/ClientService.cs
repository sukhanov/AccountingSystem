using System.Collections.Generic;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using AccountingSystem.Services.Interfaces;

namespace AccountingSystem.Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}