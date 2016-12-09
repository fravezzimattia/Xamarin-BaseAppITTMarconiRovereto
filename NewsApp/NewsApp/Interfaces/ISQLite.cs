using SQLite;

namespace NewsApp.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
