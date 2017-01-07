using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AccountingSystem.DataBase.Interfaces;

namespace AccountingSystem.DataBase.Implementation
{
    public class CommandExecuter : ICommandExecuter
    {
        private SqlConnection _connection;

        public CommandExecuter()
        {
            Init();
        }

        public SqlDataReader Execute(SqlCommand command)
        {
            command.Connection = _connection;
            Open();

            var result = command.ExecuteReader();
            //_connection.Close();

            return result;
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        private void Init()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        }

        private void Open()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }
    }
}