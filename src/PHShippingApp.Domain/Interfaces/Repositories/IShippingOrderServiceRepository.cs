using PHShippingApp.Domain.Entities;

namespace PHShippingApp.Domain.Interfaces.Repositories
{
    public interface IShippingOrderServiceRepository
    {
        IEnumerable<ShippingOrderService> GetAllServicesAsync();

        Task AddAsync(ShippingOrderService shippingOrderService);
    }
}
