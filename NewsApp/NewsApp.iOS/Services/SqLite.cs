using System;
using System.IO;
using NewsApp.iOS.Services;
using NewsApp.Interfaces;


[assembly: Xamarin.Forms.Dependency(typeof(SqLite))]

namespace NewsApp.iOS.Services
{
    class SqLite : ISQLite
    {
        public SqLite() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "xxxxxxx.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
