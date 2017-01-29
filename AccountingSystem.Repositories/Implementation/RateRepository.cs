using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using Dapper;

namespace AccountingSystem.Repositories.Implementation
{
    public class RateRepository : BaseRepository, IRateRepository
    {
        public Rate GetByCurrencies(int @from, int to)
        {
            Rate item;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var items = db.Query<Rate>($"SELECT * FROM Rates");
                item = items.FirstOrDefault(n=>n.FromCurrencyId == from && n.ToCurrencyId == to);
            }
            return item;
        }
    }
}