using System.IO;
using Windows.Storage;
using NewsApp.Interfaces;
using NewsApp.UWP.Services;
using Xamarin.Forms;


[assembly: Dependency(typeof(SqLite))]

namespace NewsApp.UWP.Services
{
    class SqLite : ISQLite
    {
        private static readonly string SqliteFilename = "xxxxxxx.sqlite";
        private static string _path = "";


        public SqLite()
        {
            _path = Path.Combine(ApplicationData.Current.LocalFolder.Path, SqliteFilename);
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            SQLite.SQLiteConnection conn = null;
            // Create the connection
            conn = new SQLite.SQLiteConnection(_path);
            // Return the database connection
            return conn;
        }
    }
}
