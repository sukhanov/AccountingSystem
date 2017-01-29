using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using Dapper;

namespace AccountingSystem.Repositories.Implementation
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public IEnumerable<Client> GetAll()
        {
            List<Client> items;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                items = db.Query<Client>("SELECT * FROM Clients").ToList();
            }
            return items;
        }
    }
}