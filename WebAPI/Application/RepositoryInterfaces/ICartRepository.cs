using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICartRepository
    {
        ValueTask<Item?> GetById(int? itemId);

        ValueTask<List<Item>> GetCartItems(Guid? cartId);
        Task RemoveItem(int? itemId);
        Task AddItem(Cart cart);
    }
}