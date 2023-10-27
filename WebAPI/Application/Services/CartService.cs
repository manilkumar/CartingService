using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<(IEnumerable<Item> entities, string Message)> GetAllItems(Guid? cartId, CancellationToken cancellationToken = default)
        {
            var items = await _cartRepository.GetCartItems(cartId);
            return (items, "Cart items retrieved");
        }

        public async Task<string> AddItem(Cart entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await _cartRepository.AddItem(entity);
                return "Item added to the cart";
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveItem(Guid? cartId, int? itemId, CancellationToken cancellationToken = default)
        {
            await _cartRepository.RemoveItem(cartId, itemId);
            return "Item deleted from Cart";
        }
    }
}