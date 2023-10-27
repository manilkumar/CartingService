using Application.RepositoryInterfaces;
using Domain.Entities;
using LiteDB;
using WebAPI.Persistence.ContexInterfaces;

namespace Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ILiteDbContext _liteDbContext;

        public CartRepository(ILiteDbContext liteDbContext)
        {
            _liteDbContext = liteDbContext;
        }

        public async ValueTask<List<Item>> GetCartItems(Guid? cartId)
        {
            var collection = _liteDbContext.GetCollection<Item>("Items");

            return collection.Find(Query.EQ("CartId", cartId)).ToList();
        }

        public async Task AddItem(Cart entity)
        {
            var collection = _liteDbContext.GetCollection<Item>("Items");
            entity.CartItem.CartId = entity.CartId;
            collection.Insert(entity.CartItem);
        }

        public async Task RemoveItem(Guid? cartId, int? itemId)
        {
            var collection = (ILiteCollection<Item>)await GetCartItems(cartId);

            collection.Delete(itemId);
        }
    }
}