using PHShippingApp.Domain.Entities;

namespace PHShippingApp.Domain.Interfaces.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetByCodeAsync(string code);

        Task AddAsync(ShippingOrder shippingOrder);
    }
}
