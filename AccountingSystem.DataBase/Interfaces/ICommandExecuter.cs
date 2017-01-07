using System.Data.SqlClient;

namespace AccountingSystem.DataBase.Interfaces
{
    public interface ICommandExecuter
    {
        SqlDataReader Execute(SqlCommand command);
        void CloseConnection();
    }
}