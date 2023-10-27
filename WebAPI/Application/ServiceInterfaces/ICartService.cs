using Domain.Entities;

namespace Application.ServiceInterfaces
{
    public interface ICartService
    {
        Task<string> AddItem(Cart entity, CancellationToken cancellationToken = default);

        Task<(IEnumerable<Item> entities, string Message)> GetAllItems(Guid? cartId, CancellationToken cancellationToken = default);

        Task<string> RemoveItem(Guid? cartId, int? itemId, CancellationToken cancellationToken = default);
    }
}