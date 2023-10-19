using LiteDB;

namespace WebAPI.Persistence.ContexInterfaces
{
    public interface ILiteDbContext
    {
        ILiteCollection<T> GetCollection<T>(string name = null);
    }
}