using System;
using NewsApp.Model;
using SQLite;


namespace NewsApp.Data.Repositories
{
    public class DatabaseRepository
    {

        private static SQLiteConnection _connection;

        public DatabaseRepository(SQLiteConnection connection)
        {
            _connection = connection;
            CreateTables();
        }

        public void CreateTables()
        {

            if (_connection == null) return;
            try
            {
                _connection.CreateTable<User>();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERRORE DB CREATE:" + e.Message);
            }

        }
        public bool Login(string name, string password)
        {
            try
            {
                var user = _connection.Table<User>().FirstOrDefault(u => u.Name == name && u.Password == password);
                if (user != null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERRORE DB LOGIN:" + e.Message);
            }
            return false;
        }

        public bool SaveUser(User user)
        {
            try
            {
                _connection.Insert(user);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERRORE DB SAVE USER:" + e.Message);
            }
            return false;
        }
    }
}