using System;
using System.IO;
using System.Runtime.CompilerServices;
using NewsApp.Droid.Services;
using NewsApp.Interfaces;
using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(SqLite))]

namespace NewsApp.Droid.Services
{
    class SqLite : ISQLite
    {
        private static readonly string SqliteFilename = "xxxxxxx.db3";
        private static string _path = "";


        public SqLite()
        {
            var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _path = Path.Combine(libraryPath, SqliteFilename);
        }
        public SQLite.SQLiteConnection GetConnection()
        {
            var conn = new SQLite.SQLiteConnection(_path);
            return conn;
        }
    }
}
