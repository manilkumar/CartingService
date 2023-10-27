using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICartRepository
    {

        ValueTask<List<Item>> GetCartItems(Guid? cartId);
        Task RemoveItem(Guid? cartId,int? itemId);
        Task AddItem(Cart cart);
    }
}