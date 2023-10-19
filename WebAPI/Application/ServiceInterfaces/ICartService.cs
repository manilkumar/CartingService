using Domain.Entities;

namespace Application.ServiceInterfaces
{
    public interface ICartService
    {
        Task<string> AddItem(Cart entity, CancellationToken cancellationToken = default);

        Task<(IEnumerable<Item> entities, string Message)> GetAllItems(Guid? cartId, CancellationToken cancellationToken = default);

        Task<string> RemoveItem(int? itemId, CancellationToken cancellationToken = default);
    }
}