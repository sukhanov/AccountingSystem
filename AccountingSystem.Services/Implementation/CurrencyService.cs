using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Versioning;
using AccountingSystem.DataBase.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICommandExecuter _executer;

        public CurrencyService(ICommandExecuter executer)
        {
            _executer = executer;
        }

        public IEnumerable<CurrencyModel> GetAll()
        {
            var result = new List<CurrencyModel>();
            var command = new SqlCommand
            {
                CommandText = "SELECT * FROM Currencies"
            };

            var reader = _executer.Execute(command);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(new CurrencyModel
                        {
                            Id = (int) reader["Id"],
                            Code = reader["Code"].ToString()
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