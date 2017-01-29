using System.Configuration;

namespace AccountingSystem.Repositories.Implementation
{
    public class BaseRepository
    {
        protected string ConnectionString => ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
    }
}