using SQLite;

namespace BrainChallenge.Common.Data.Connection
{
    public class ConnectionProvider
    {

        public static string DbPath { get; set; }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(DbPath);
        }
    }
}
