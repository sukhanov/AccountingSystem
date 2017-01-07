using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using AccountingSystem.DataBase.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ICommandExecuter _executer;

        public TransactionService(ICommandExecuter executer)
        {
            _executer = executer;
        }

        public void Create(TransactionModel model)
        {
            var dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("ClientId");
            dt.Columns.Add("ClientToId");
            dt.Columns.Add("Amount");
            dt.Columns.Add("CurrencyId");
            dt.Rows.Add(model.Type, model.ClientId, model.ClientToId, model.Amount, model.CurrencyId);

            var param = new SqlParameter("Transaction", dt);
            var command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "CreateTransaction"
            };
            command.Parameters.Add(param);

            var result = _executer.Execute(command);
        }

        public void MoveToArchive()
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "MoveTransactionToArchive"
            };

            var result = _executer.Execute(command);
        }

        public List<TransactionTableModel> GetAll()
        {
            var result = new List<TransactionTableModel>();
            var command = new SqlCommand
            {
                CommandText = "SELECT * FROM GetAllTransactions"
            };

            var reader = _executer.Execute(command);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        var tr = new TransactionTableModel
                        {
                            Amount = (decimal)reader["Amount"],
                            Client = reader["ClientName"].ToString(),
                            ClientTo = reader["ClientToName"].ToString(),
                            Currency = reader["Currency"].ToString(),
                            Type = (int)reader["Type"],
                            DateTime = (DateTime)reader["DateTime"]
                        };
                        var archiveDatetime = reader.GetOrdinal("ArchiveDateTime");
                        if (!reader.IsDBNull(archiveDatetime))
                            tr.ArchiveDatetime = reader.GetDateTime(archiveDatetime);

                        result.Add(tr);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Ошибка при получении данных: " + e.Message);
                    }
                }
            }

            reader.Close();
            _executer.CloseConnection();

            return result;
        }
    }
}
