using LiteDB;
using WebAPI.Persistence.ContexInterfaces;

namespace Persistence.Context
{
    public class LiteDbContext : ILiteDbContext
    {
        private LiteDatabase _db;

        public LiteDbContext(string path)
        {
            _db = new LiteDatabase(path);
        }

        public ILiteCollection<T> GetCollection<T>(string name = null)
        {
            return _db.GetCollection<T>(name);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}