using NewsApp.Data.Repositories;
using NewsApp.Interfaces;

namespace NewsApp.Services
{
    public class SqLiteService : DatabaseRepository
    {
        public SqLiteService(ISQLite sqlLite) : base(sqlLite.GetConnection())
        {
        }
    }
}
