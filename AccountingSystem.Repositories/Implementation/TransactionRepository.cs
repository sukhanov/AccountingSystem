using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AccountingSystem.Models;
using AccountingSystem.Repositories.Interfaces;
using Dapper;

namespace AccountingSystem.Repositories.Implementation
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public IEnumerable<Transaction> GetAll()
        {
            List<Transaction> items;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                items = db.Query<Transaction>("SELECT * FROM GetAllTransactions").ToList();
            }
            return items;
        }

        public string Create(NewTransaction tran)
        {
            var dt = new DataTable();
            dt.Columns.Add("Type", typeof(int));
            dt.Columns.Add("ClientId", typeof(int));
            dt.Columns.Add("BalanceId", typeof(int));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("CurrencyId", typeof(int));
            dt.Rows.Add(tran.Type, tran.ClientId, tran.BalanceId, tran.Amount, tran.CurrencyId);

            var parameters = new DynamicParameters();
            parameters.Add("@Transaction", dt.AsTableValuedParameter("TransactionType"));
            parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute("CreateTransaction", parameters, commandType:CommandType.StoredProcedure);
            }
            var result = parameters.Get<int>("@Result");
            return result == 0 ? string.Empty : "Client hasn't account";
        }

        public void MoveTorchive()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute("MoveTransactionToArchive", commandType: CommandType.StoredProcedure);
            }
        }
    }
}