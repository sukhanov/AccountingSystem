using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using Dapper;

namespace AccountingSystem.Repositories.Implementation
{
    public class BalanceRepository : BaseRepository, IBalanceRepository
    {
        public IEnumerable<Balance> GetByClientId(int clientId)
        {
            List<Balance> items;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                items = db.Query<Balance>("SELECT * FROM GetClientBalance").Where(n => n.ClientId == clientId).ToList();
            }
            return items;
        }

        public Balance GetById(int id)
        {
            Balance item;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                item = db.Query<Balance>($"SELECT * FROM ClientBalances").FirstOrDefault(n => n.Id == id);
            }
            return item;
        }
    }
}