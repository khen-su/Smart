using System.Data.SqlClient;

namespace Persistent.Repositories.Interfaces
{
    public class BaseRepository
    {
        internal readonly string _connectionString;
        internal BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}