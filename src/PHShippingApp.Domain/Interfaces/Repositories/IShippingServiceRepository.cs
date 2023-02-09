using PHShippingApp.Domain.Entities;

namespace PHShippingApp.Domain.Interfaces.Repositories
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllServicesAsync();

        //Task AddAsync(ShippingOrderService shippingOrderService);
    }
}
