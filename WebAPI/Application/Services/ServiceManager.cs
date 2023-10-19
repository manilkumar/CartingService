using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICartService> _lazyCartService;

        public ServiceManager(ICartRepository cartRepository)
        {
            _lazyCartService = new Lazy<ICartService>(() => new CartService(cartRepository));
        }

        public ICartService CartService => _lazyCartService.Value;
    }
}