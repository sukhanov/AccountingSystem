using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using AccountingSystem.DataBase.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.Services.Models;

namespace AccountingSystem.Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly ICommandExecuter _executer;

        public ClientService(ICommandExecuter executer)
        {
            _executer = executer;
        }

        public IEnumerable<ClientModel> GetAll()
        {
            var result = new List<ClientModel>();
            var command = new SqlCommand
            {
                CommandText = "SELECT * FROM Clients"
            };

            var reader = _executer.Execute(command);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(new ClientModel
                        {
                            Id = (int) reader["Id"],
                            Name = reader["Name"].ToString()
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