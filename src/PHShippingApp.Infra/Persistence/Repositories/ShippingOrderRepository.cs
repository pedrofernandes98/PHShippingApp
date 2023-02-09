using MongoDB.Driver;
using PHShippingApp.Domain.Entities;
using PHShippingApp.Domain.Interfaces.Repositories;

namespace PHShippingApp.Infra.Persistence.Repositories
{
    public class ShippingOrderRepository : IShippingOrderRepository
    {
        private readonly IMongoCollection<ShippingOrder> _collection;

        public ShippingOrderRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<ShippingOrder>("shipping-orders");
        }

        public async Task AddAsync(ShippingOrder shippingOrder)
        {
            await _collection.InsertOneAsync(shippingOrder);
        }

        public async Task<ShippingOrder> GetByCodeAsync(string code)
        {
            return await _collection.Find(so => so.TranckingCode == code).SingleOrDefaultAsync();
        }
    }
}
