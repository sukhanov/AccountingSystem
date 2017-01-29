using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using Dapper;

namespace AccountingSystem.Repositories.Implementation
{
    public class CurrencyRepository : BaseRepository, ICurrencyRepository
    {
        public IEnumerable<Currency> GetAll()
        {
            List<Currency> items;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                items = db.Query<Currency>("SELECT * FROM Currencies").ToList();
            }
            return items;
        }
    }
}