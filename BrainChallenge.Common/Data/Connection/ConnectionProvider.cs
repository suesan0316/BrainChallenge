using SQLite;

namespace BrainChallenge.Common.Data.Connection
{
    public class ConnectionProvider
    {

        public static string dbPath { get; set; }

        public static SQLiteConnection getConnection()
        {
            return new SQLiteConnection(dbPath);
        }
    }
}
