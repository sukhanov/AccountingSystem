using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using AccountingSystem.DataBase.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Implementation
{
    public class BalanceService : IBalanceService
    {
        private readonly ICommandExecuter _executer;

        public BalanceService(ICommandExecuter executer)
        {
            _executer = executer;
        }

        public IEnumerable<BalanceModel> GetForClient(int clientId)
        {
            var result = new List<BalanceModel>();
           
            var command = new SqlCommand
            {
                CommandText = $"SELECT * FROM GetClientBalance WHERE ClientId = {clientId}"
            };

            var reader = _executer.Execute(command);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(new BalanceModel
                        {
                            Currency = (string)reader["Code"],
                            Amount = (decimal)reader["Amount"]
                        });
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